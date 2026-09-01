#!/usr/bin/env python3
"""Empaqueta el DLL del mod NarradorPorEventos como .package TS3 (DBPF 2.0) con recurso S3SA.

Layout verificado contra packages reales del juego (velocitygrass, Store Updates) y SimsWiki:
Header 96 bytes:
    0x00 magic 'DBPF'
    0x04 u32 major = 2
    0x08 u32 minor = 0
    0x0C byte[24] unknown1 (cero)
    0x24 u32 index entry count
    0x28 u32 unknown2 (cero)
    0x2C u32 index size on disk (bytes)
    0x30 byte[12] unknown3 (cero)
    0x3C u32 index_version = 3
    0x40 u32 index position (absoluto)
    0x44 byte[28] unknown4 (cero)
Index: en `index position`:
    u32 bitfield (index type): bits set => ese campo vive en el Index HEADER (constante);
                                bits unset => el campo va en CADA entrada.
    Campos en orden: 0 Type, 1 Group, 2 InstanceHi, 3 InstanceLo, 4 ChunkOffset,
                     5 FileSize(lo31)+flag(hi), 6 MemSize, 7 Compressed(wo16)+unknown2(hw16)
Para un solo recurso con valores propios usamos bitfield=0: entrada completa de 8 dwords (32 bytes).
Recurso sin comprimir => Compressed lo-word = 0x0000. Hi-word (unknown2) = 0x0001 se observa en
packages del juego; s3pi escribe 0x0001FFFF para comprimidos y 0x00010000/0x00010000 para crudos.
Usamos 0x00010000 (raw, como escribe s3pe "sin compresión").
"""
import struct
import sys
from pathlib import Path

TYPE_S3SA = 0x40E1FA25
GROUP_NONE = 0x00000000


def fnv64(data: bytes) -> int:
    h = 0xCBF29CE484222325
    for b in data.lower().encode():
        h = ((h ^ b) * 0x100000001B3) & 0xFFFFFFFFFFFFFFFF
    return h


XML_TYPE = 0x0333406C


def build_package(dll_path: Path, out_path: Path) -> None:
    dll = dll_path.read_bytes()

    # Recurso S3SA crudo: magic + longitud + DLL. Sin este wrapper el juego no lo reconoce.
    resource = b"S3SA" + len(dll).to_bytes(4, "little") + dll

    # XML de tuning que instancia la clase entry point (obligatorio para que corra el static ctor).
    xml_res = (
        '<?xml version="1.0" encoding="utf-8"?>\n'
        "<base>\n"
        "  <Current_Tuning>\n"
        '    <kInstantiator value="True" />\n'
        "  </Current_Tuning>\n"
        "</base>"
    ).encode("utf-8")

    instance = fnv64(Path(dll_path).stem)  # FNV64 del NOMBRE COMPLETO DEL ENSAMBLADO
    xml_instance = fnv64(
        Path(dll_path).stem + ".GerenciadorPrincipalModNarracaoPorEventos"
    )

    header_size = 96
    s3sa_offset = header_size
    xml_offset = s3sa_offset + len(resource)
    index_pos = xml_offset + len(xml_res)

    # Index: bitfield=0 -> cada entrada tiene los 8 campos (32 bytes)
    def entry8(tid, inst, off, size):
        return struct.pack("<8I", tid, GROUP_NONE,
                           (inst >> 32) & 0xFFFFFFFF, inst & 0xFFFFFFFF,
                           off, size & 0x7FFFFFFF, size, 0x00010000)

    entries = (
        entry8(TYPE_S3SA, instance, s3sa_offset, len(resource))
        + entry8(XML_TYPE, xml_instance, xml_offset, len(xml_res))
    )
    index = struct.pack("<I", 0) + entries  # bitfield 0 + 2 entradas
    index_size = len(index)

    header = bytearray(96)
    struct.pack_into("<4s", header, 0, b"DBPF")
    struct.pack_into("<I", header, 4, 2)          # major
    struct.pack_into("<I", header, 8, 0)          # minor
    struct.pack_into("<I", header, 36, 2)         # entry count
    struct.pack_into("<I", header, 40, 0)         # unknown2
    struct.pack_into("<I", header, 44, index_size)
    struct.pack_into("<I", header, 60, 3)         # index version = 3
    struct.pack_into("<I", header, 64, index_pos)

    out_path.write_bytes(bytes(header) + resource + xml_res + index)
    print(f"OK: {out_path} ({out_path.stat().st_size:,} bytes)")


def validate(path: Path) -> None:
    data = path.read_bytes()
    assert data[:4] == b"DBPF"
    count = struct.unpack_from("<I", data, 36)[0]
    idx_size = struct.unpack_from("<I", data, 44)[0]
    iver = struct.unpack_from("<I", data, 60)[0]
    ipos = struct.unpack_from('<I', data, 64)[0]
    print(f"count={count} idxSize={idx_size} idxVer={iver} idxPos={ipos}")
    assert count == 2 and iver == 3
    bf = struct.unpack_from("<I", data, ipos)[0]
    assert bf == 0, f"bitfield inesperado {bf:#x}"
    seen_s3sa = False
    for k in range(count):
        t, g, ih, il, pos, size, mem, comp = struct.unpack_from("<8I", data, ipos + 4 + 32 * k)
        inst = (ih << 32) | il
        print(f"TID={t:#x} G={g:#x} I={inst:#x} pos={pos} size={size} mem={mem} comp={comp:#x}")
        res = data[pos:pos + mem]
        if t == TYPE_S3SA:
            seen_s3sa = True
            assert res[:4] == b"S3SA", f"recurso sin magic S3SA: {res[:8]!r}"
            inner_len = int.from_bytes(res[4:8], "little")
            assert inner_len == len(res) - 8, "largo interno inconsistente"
        elif t == XML_TYPE:
            assert res.startswith(b"<?xml"), "XML de tuning corrupto"
    assert seen_s3sa, "falta el recurso S3SA"
    print("VALIDACION COMPLETA OK")


if __name__ == "__main__":
    base = Path(__file__).parent
    dll = base / "ZZZZitalo.TS3Mods.NarradorPorEventos.dll"
    out = base / "ZZZZitalo.TS3Mods.NarradorPorEventos.package"
    build_package(dll, out)
    validate(out)
