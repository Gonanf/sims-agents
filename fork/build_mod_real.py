#!/usr/bin/env python3
"""Extrae los <Compile Include> del .csproj y compila el mod completo con mcs
contra las DLLs reales de referencia de TS3 1.67. Clasifica errores por código."""
import re, subprocess, sys, os
from collections import Counter

ROOT = os.path.expanduser("~/proyectos/sims-agents/fork")
REF = "/home/chaos/Documents/Electronic Arts/ReferenceAssemblies"
ERRLOG = os.path.join(ROOT, "build", "mcs-errores.log")

with open(os.path.join(ROOT, "ZZZZitalo.TS3Mods.NarradorPorEventos.csproj"), encoding="utf-8") as f:
    csproj = f.read()

sources = [f.replace("\\\\", "/").replace("\\", "/")
           for f in re.findall(r'<Compile Include="([^"]+)"\s*/>', csproj)]

missing = [s for s in sources if not os.path.exists(os.path.join(ROOT, s))]
print(f"Archivos en csproj: {len(sources)}")
if missing:
    print("FALTAN en disco:")
    for m in missing:
        print("  ", m)
    sys.exit(2)

refs = ["mscorlib.dll", "System.dll", "System.Xml.dll", "ScriptCore.dll", "SimIFace.dll",
        "Sims3GameplayObjects.dll", "Sims3GameplaySystems.dll", "Sims3MetaData.dll",
        "Sims3StoreObjects.dll", "UI.dll"]
# Estrategia BCL + EA (ago 2026): la mscorlib de NRaas es recortada por EA y NO trae
# System.IO.{Path,File,Directory}. Se usa el perfil 2.0-api de Mono como BCL base
# (misma superficie API que el CLR custom del juego) y las DLLs EA encima.
BCL = "/usr/lib/mono/2.0-api"
ref_args = (["-r:" + os.path.join(BCL, r) for r in refs[:3]]
            + ["-r:" + os.path.join(REF, r) for r in refs[3:]]
            + ["-noconfig", "-sdk:2"])
# Stub de compilación para Battery.Utility (S3SE) — ver stubs/Battery.Utility.CompileStub.cs
sources = sources + ["stubs/Battery.Utility.CompileStub.cs"]

out = os.path.join(ROOT, "build/ZZZZitalo.TS3Mods.NarradorPorEventos.dll")
# -nostdlib: usa SOLO los ensamblados de referencia de EA (runtime 2.5 custom),
# sin mezclar con el perfil 4.5 de Mono (evita CS1703/CS1685).
cmd = (["mcs", "-target:library", "-warn:4", "-nostdlib",
        "-define:DEBUG;TRACE", "-out:" + out]
       + ref_args + sources)
proc = subprocess.run(cmd, cwd=ROOT, capture_output=True, text=True)

full = proc.stdout + proc.stderr
with open(ERRLOG, "w") as f:
    f.write(full)

errs = re.findall(r"error (CS\d+): (.+)", full)
codes = Counter(c for c, _ in errs)
print(f"Total errores: {len(errs)} | exit={proc.returncode}")
for c, n in codes.most_common(25):
    print(f"  {c}: {n}")
seen = set()
print("\n--- Muestra (primer error por código) ---")
for line in full.splitlines():
    m = re.search(r"error (CS\d+)", line)
    if m and m.group(1) not in seen:
        seen.add(m.group(1))
        print(" ", line[:200])
sys.exit(0 if proc.returncode == 0 else 1)
