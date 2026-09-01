"""S3SA decrypt/encrypt + análisis del campo md5sum contra scripts reales del juego."""
import struct, sys, hashlib

def decrypt_s3sa(data):
    """Port del algoritmo s3pi (via Sims3MonoModder). Devuelve (plain, info)."""
    p = 0
    version = data[p]; p += 1
    assert version in (1, 2), f"version {version}"
    name = None
    if version == 2:
        name_len = struct.unpack_from('<I', data, p)[0]; p += 4
        raw = data[p:p + name_len * 2]; p += name_len * 2
        name = raw.decode('utf-16-le', 'ignore').rstrip('\x00')
    rsa_pub = struct.unpack_from('<I', data, p)[0]; p += 4
    md5sum_field = data[p:p + 64]; p += 64
    block_count = struct.unpack_from('<H', data, p)[0]; p += 2
    md5table = data[p:p + block_count * 8]; p += block_count * 8
    md5data = data[p:]

    seed = 0
    for i in range(0, len(md5table), 8):
        seed += struct.unpack_from('<Q', md5table, i)[0]
    seed &= (len(md5table) - 1)

    out = bytearray(block_count * 512)
    rp = 0
    for i in range(0, len(md5table), 8):
        block_out_idx = (i // 8) * 512
        if not (md5table[i] & 1):
            enc = md5data[rp:rp + 512]; rp += 512
            for j in range(512):
                v = enc[j]
                out[block_out_idx + j] = v ^ md5table[seed]
                seed = (seed + v) % len(md5table)
    info = dict(version=version, name=name, rsa=rsa_pub,
                md5sum_field=md5sum_field, blocks=block_count,
                consumed=p + rp, total=len(data))
    return bytes(out), info

def encrypt_s3sa(plain, name=None, rsa_pub=0x92C6C60D):
    """Empaqueta un PE en formato S3SA v1/v2 con key-table aleatoria válida."""
    import os
    n = len(plain)
    block_count = (n + 511) // 512
    padded = plain.ljust(block_count * 512, b'\x00')
    # key table: todos los bloques presentes, seeds aleatorias (cualquier valor sirve:
    # la tabla ES la clave; solo importa que flag&1==0 y que sum()&mask sea consistente)
    keys = [struct.pack('<Q', i * 0x9E3779B97F4A7C15 & 0xFFFFFFFFFFFFFFFF)
            for i in range(block_count)]
    # asegurar bit0==0 en cada entrada de 8 bytes (flag "presente") - LE: byte 0 es low
    keys = [bytes([k[0] & 0xFE]) + k[1:] for k in keys]
    md5table = b''.join(keys)
    mask = len(md5table) - 1
    seed = 0
    for i in range(0, len(md5table), 8):
        seed += struct.unpack_from('<Q', md5table, i)[0]
    seed &= mask

    out = bytearray()
    if name is None:
        out.append(1)  # version 1: sin nombre
    else:
        out.append(2)
        nb = name.encode('utf-16-le')
        out += struct.pack('<I', len(name)) + nb
    out += struct.pack('<I', rsa_pub)
    out += b'\x00' * 64          # md5sum field (ver abajo si el loader lo valida)
    out += struct.pack('<H', block_count)
    out += md5table
    for b in range(block_count):
        chunk = padded[b * 512:(b + 1) * 512]
        enc = bytearray(512)
        for j in range(512):
            v = chunk[j]
            enc[j] = v ^ md5table[seed]
            seed = (seed + enc[j]) % len(md5table)
        out += enc
    return bytes(out)

if __name__ == '__main__':
    # Descifrar un S3SA real del juego y analizar su campo md5sum
    sys.path.insert(0, '/home/chaos/proyectos/sims-agents/tools')
    from dbpf_extract import parse_package, get_resource

    GAME = "/run/media/chaos/secundario/proyectos/Games/thesims3/drive_c/Program Files (x86)/The Sims 3 Ultimate Collection"
    pkg = GAME + "/The Sims 3/Game/Bin/gameplay.package"
    d, entries = parse_package(pkg)
    # primer recurso S3SA que encontremos
    target = None
    for e in entries:
        if e['t'] == 0x073FAA07:
            blob = get_resource(d, e)
            if blob and blob[0] in (1, 2):
                target = (e, blob)
                break
    e, blob = target
    print(f"muestra: T={e['t']:08X} I={e['i']:016X} size={len(blob)}")
    plain, info = decrypt_s3sa(blob)
    print(f"version={info['version']} name={info['name']!r} rsa={info['rsa']:#x} blocks={info['blocks']}")
    print(f"MZ: {plain[:2] == b'MZ'} | primeros bytes: {plain[:16].hex()}")
    md5f = info['md5sum_field']
    print(f"md5sum field (64B): {md5f.hex()}")

    # hipótesis sobre el campo md5sum
    h_md5_all = hashlib.md5(plain).digest()
    h_first = hashlib.md5(plain[:512]).digest()
    h_sha = hashlib.sha256(plain).digest()
    cands = {
        'md5(plain)x4': h_md5_all * 4,
        'md5(plain)+zeros': h_md5_all + b'\x00' * 48,
        'sha256(plain)+sha256(plain)': h_sha + h_sha,
        'md5(first512)x4': h_first * 4,
        'zeros': b'\x00' * 64,
    }
    for nombre, cand in cands.items():
        match = cand[:64] == md5f
        parcial = sum(a == b for a, b in zip(cand, md5f))
        print(f"  {nombre}: {'MATCH EXACTO' if match else f'{parcial}/64 bytes iguales'}")
