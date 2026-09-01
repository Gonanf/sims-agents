import struct, sys, os, re

def read_header(d):
    assert d[:4] == b'DBPF'
    return dict(
        count=struct.unpack_from('<i', d, 36)[0],
        size=struct.unpack_from('<i', d, 44)[0],
        pos=struct.unpack_from('<i', d, 64)[0],
        pos_alt=struct.unpack_from('<i', d, 40)[0],
    )

def refpack_decompress(data, memsize):
    out = bytearray()
    pos = 0
    b0 = data[pos]; b1 = data[pos+1]; pos += 2
    szlen = ((4 if (b0 & 0x80) else 3) * (2 if (b0 & 0x01) else 1))
    realsize = int.from_bytes(data[pos:pos+szlen], 'big'); pos += szlen
    if realsize != memsize:
        raise ValueError(f"realsize {realsize} != memsize {memsize}")
    end = len(data)
    while pos < end:
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
            if copysize < copyoffset and copyoffset > 8:
                while copysize > 0:
                    n = min(copyoffset, copysize)
                    start = len(out) - copyoffset
                    out += out[start:start+n]
                    copysize -= n
            else:
                for _ in range(copysize):
                    out.append(out[-copyoffset])
    return bytes(out)

def parse_package(path, want_mz=False):
    d = open(path, 'rb').read()
    h = read_header(d)
    p = h['pos'] if h['pos'] else h['pos_alt']
    indextype = struct.unpack_from('<I', d, p)[0]; p += 4
    consts = {}
    if indextype & 1:
        consts['t'] = struct.unpack_from('<I', d, p)[0]; p += 4
    if indextype & 2:
        consts['g'] = struct.unpack_from('<I', d, p)[0]; p += 4
    if indextype & 4:
        consts['ih'] = struct.unpack_from('<I', d, p)[0]; p += 4
    entries = []
    for _ in range(h['count']):
        t = consts.get('t') if indextype & 1 else None
        g = consts.get('g') if indextype & 2 else None
        ih = consts.get('ih') if indextype & 4 else None
        if not (indextype & 1):
            t = struct.unpack_from('<I', d, p)[0]; p += 4
        if not (indextype & 2):
            g = struct.unpack_from('<I', d, p)[0]; p += 4
        if not (indextype & 4):
            ih = struct.unpack_from('<I', d, p)[0]; p += 4
        il = struct.unpack_from('<I', d, p)[0]; p += 4
        off = struct.unpack_from('<I', d, p)[0]; p += 4
        fsz = struct.unpack_from('<I', d, p)[0]; p += 4
        msz = struct.unpack_from('<I', d, p)[0]; p += 4
        p += 4  # compressed flag + unknown2
        entries.append(dict(t=t, g=g, i=(ih << 32) | il, off=off,
                            fsz=fsz & 0x7fffffff, msz=msz,
                            comp=bool(fsz & 0x80000000)))
    return d, entries

def get_resource(d, e):
    if e['off'] == 0xffffffff:
        return None
    raw = d[e['off']:e['off']+e['fsz']]
    if e['fsz'] == 1 and e['msz'] == 0xffffffff:
        return None
    if e['fsz'] == e['msz']:
        return raw
    try:
        return refpack_decompress(raw, e['msz'])
    except Exception as ex:
        return None

def asm_name(blob):
    # heuristic: search UTF-16LE / ascii for "-name" style or common patterns
    m = re.search(rb'(?:[\x20-\x7e]\x00){4,40}', blob[:200000])
    cands = []
    for mm in re.finditer(rb'(?:[\x20-\x7e]\x00){4,40}', blob[:400000]):
        s = mm.group().decode('utf-16-le', 'ignore')
        cands.append(s)
        if len(cands) > 400:
            break
    # look for something like X.dll or X, Version=
    for s in cands:
        if '.dll' in s.lower() or 'Version=' in s:
            return s
    return None

if __name__ == '__main__':
    path = sys.argv[1]
    d, entries = parse_package(path)
    print(f"{os.path.basename(path)}: {len(entries)} entries")
    found = []
    for idx, e in enumerate(entries):
        blob = get_resource(d, e)
        if blob and blob[:2] == b'MZ':
            nm = asm_name(blob)
            found.append((idx, e, len(blob), nm))
    for idx, e, ln, nm in found:
        print(f"[{idx}] T={e['t']:08X} G={e['g']:08X} I={e['i']:016X} off={e['off']:08X} size={ln} name={nm!r}")
    print("MZ resources:", len(found))
