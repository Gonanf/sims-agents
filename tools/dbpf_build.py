"""Empaqueta un DLL de script mod en un .package DBPF v2 con recurso S3SA.

Formato validado contra: s3pi ScriptResource.cs (mirror ellacharmed), Sims3MonoModder
package_reader, y muestra real descifrada de gameplay.package.
"""
import struct, sys, os
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from s3sa import encrypt_s3sa

TYPE_S3SA = 0x073FAA07

def build_package(dll_path, out_path, instance=0xD8957B186B7324FE, group=0,
                  game_version=None):
    plain = open(dll_path, 'rb').read()
    assert plain[:2] == b'MZ', "no es un PE"
    blob = encrypt_s3sa(plain, name=game_version)

    # índice v3 con type/group/instanceHi constantes (flags 7)
    ih = (instance >> 32) & 0xFFFFFFFF
    il = instance & 0xFFFFFFFF

    header_size = 96
    index_flags = 0x07
    index_offset = header_size
    # entrada: instanceLo, offset, fileSize, memSize, (compressed u16 + unknown u16)
    index_size = 4 + 12 + (4 + 4 + 4 + 4 + 2 + 2)  # flags + 3 consts + entrada = 36
    # el recurso va DESPUÉS del índice en el archivo
    resource_offset = index_offset + index_size
    index_body = struct.pack('<III', TYPE_S3SA, group, ih)
    index_body += struct.pack('<IIIIHH', il, resource_offset, len(blob),
                              len(blob), 0, 0)

    h = bytearray(96)
    h[0:4] = b'DBPF'
    struct.pack_into('<I', h, 4, 2)        # major
    struct.pack_into('<I', h, 8, 0)        # minor
    struct.pack_into('<I', h, 24, 0)       # dateCreated
    struct.pack_into('<I', h, 28, 0)       # dateModified
    struct.pack_into('<I', h, 32, 3)       # index major version
    struct.pack_into('<I', h, 36, 1)       # entry count
    struct.pack_into('<I', h, 40, 0)       # indexFirstOffset (unused)
    struct.pack_into('<I', h, 44, index_size)
    struct.pack_into('<I', h, 60, 3)       # index version
    struct.pack_into('<I', h, 64, index_offset)

    out = bytes(h) + struct.pack('<I', index_flags) + index_body + blob
    open(out_path, 'wb').write(out)
    return dict(resource=len(blob), total=len(out),
                instance=f'{instance:016X}')

def extract_and_verify(package_path, dll_path):
    """Round-trip: leer el package con MI lector y comparar contra el DLL original."""
    from dbpf_extract import parse_package, get_resource
    from s3sa import decrypt_s3sa
    d, entries = parse_package(package_path)
    for e in entries:
        if e['t'] == TYPE_S3SA:
            blob = get_resource(d, e)
            assert blob is not None, "recurso ilegible"
            plain, info = decrypt_s3sa(blob)
            original = open(dll_path, 'rb').read()
            ok = plain[:len(original)] == original
            return dict(mz=plain[:2] == b'MZ',
                        identical=ok,
                        dll=len(original), recovered=len(plain),
                        blocks=info['blocks'])
    raise AssertionError('S3SA no encontrado en el package')

if __name__ == '__main__':
    dll = sys.argv[1]
    out = sys.argv[2]
    meta = build_package(dll, out)
    print(f"package: {out} | recurso={meta['resource']}B total={meta['total']}B inst={meta['instance']}")
    print("verificación:", extract_and_verify(out, dll))
