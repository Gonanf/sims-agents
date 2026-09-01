import sys
sys.path.insert(0, '/tmp')
from dbpf import parse_package

base = "/run/media/chaos/secundario/proyectos/Games/thesims3/drive_c/Program Files (x86)/The Sims 3 Ultimate Collection/The Sims 3/Game/Bin"

def dechunk_stream(data, pos, out, max_out=30*1024*1024):
    while pos < len(data) and len(out) < max_out:
        packing = data[pos]; pos += 1
        copysize = copyoffset = dl = 0
        if packing < 0x80:
            o = data[pos]; pos += 1
            dl = packing & 0x03
            copysize = ((packing >> 2) & 0x07) + 3
            copyoffset = (((packing << 3) & 0x300) | o) + 1
        elif packing < 0xC0:
            d0 = data[pos]; d1 = data[pos+1]; pos += 2
            dl = (d0 >> 6) & 0x03
            copysize = (packing & 0x3F) + 4
            copyoffset = (((d0 << 8) & 0x3F00) | d1) + 1
        elif packing < 0xE0:
            d0 = data[pos]; d1 = data[pos+1]; d2 = data[pos+2]; pos += 3
            dl = packing & 0x03
            copysize = (((packing << 6) & 0x300) | d2) + 5
            copyoffset = (((packing << 12) & 0x10000) | (d0 << 8) | d1) + 1
        elif packing < 0xFC:
            dl = ((packing & 0x1F) + 1) << 2
        else:
            dl = packing & 0x03
        if dl > 0:
            out += data[pos:pos+dl]; pos += dl
        if copysize:
            if copyoffset > len(out):
                raise ValueError("bad offset")
            if copysize < copyoffset and copyoffset > 8:
                while copysize > 0:
                    n = min(copyoffset, copysize)
                    start = len(out) - copyoffset
                    out += out[start:start+n]
                    copysize -= n
            else:
                for _ in range(copysize):
                    out.append(out[-copyoffset])
    return pos

def main():
    d, entries = parse_package(f"{base}/scripts.package")
    raw = d[entries[0]['off']:entries[0]['off']+entries[0]['fsz']]
    for start in range(23, 40):
        out = bytearray()
        try:
            endpos = dechunk_stream(raw, start, out)
        except Exception as ex:
            print(f"start={start}: fail {ex}")
            continue
        head = bytes(out[:16])
        tag = "MZ!" if head[:2] == b'MZ' else ("BSJB" if b'BSJB' in bytes(out[:2000]) else "")
        print(f"start={start}: {len(out)}B consumed={endpos-start} head={head.hex()} {tag}")

main()
