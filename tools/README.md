# Tools — Sims 3 package tooling (hecho a mano, sin dependencias)

## dbpf_extract.py
Parser DBPF v2 completo (header + índice v3 con indextype flags) y descompresor
RefPack de EA. Validado contra la instalación 1.67.2: ~35k recursos
descomprimidos OK en DeltaBuild0.package. Uso:

```python
from dbpf_extract import parse_package, get_resource
d, entries = parse_package(path)          # entries: dicts t/g/i/off/fsz/msz/comp
blob = get_resource(d, entries[0])        # descomprime si hace falta
```

## Hallazgo clave: dónde viven los ensamblados del motor

TS3 NO trae ScriptCore.dll etc. como archivos sueltos. Viajan como recursos
DBPF con instance IDs fijos, dentro de contenedores custom en Game/Bin:

| Package | Instances | Ensamblados |
|---|---|---|
| simcore.package | 0x28EE9D383A73463E, 0x342EE04373CF1E1C, 0x6AC101133051BEF1 | mscorlib, System, System.Xml |
| gameplay.package | 0x0CAE1C361E05B2B3, 0x03D6C8D903CE868C, 0xB9C90FDC6793BC0A, 0xF7C3ADE896D4E765 | Sims3StoreObjects, Sims3GameplaySystems, Sims3GameplayObjects, UI |
| scripts.package | 0xC356DF69B70ADD42, 0x78CF6CF5304D0C4F, 0x600F9EA1DDC99FB1 | SimIFace, ScriptCore, Sims3MetaData |

Formato del contenedor interno (reversado parcial): header propio
`[01|02] [u32 strlen si 02] [versión UTF-16LE tipo "0.2.0.209"] [magia 9F F7 C4 2B]`
y después payload de entropía ~7.94/8: compresor/cifrado propio de EA,
NO RefPack plano ni zlib/bz2/lzma. Reversarlo requeriría tocar los binarios
nativos del juego.

## Cómo se resuelve en la práctica

Los instances son estables entre instalaciones → la comunidad los extrae una
vez y los comparte. Fuente usada: repo **Chain-Reaction/NRaas** carpeta
`Sims3/Compiler` (los filenames traen el instance como prefijo, verificado 1:1
contra esta instalación). Copias limpias en:
`<prefix>/users/chaos/Documents/Electronic Arts/ReferenceAssemblies/*.dll`
(runtime 2.5 = CLR custom EA; mcs las consume bien con -nostdlib).

## probe_container.py
Script de la sesión que probó offsets/decoders contra el contenedor interno.
Lo dejamos por si alguien retoma el reversado del formato.
