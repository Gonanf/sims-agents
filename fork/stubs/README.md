# stubs/

## Battery.Utility.CompileStub.cs — stub SOLO de compilación

`Battery.Utility.dll` (namespace `S3SE`) se distribuye con el loader S3SE y se
carga en runtime dentro del juego; no forma parte de las 10 DLLs de referencia
de TS3 1.67 (NRaas Compiler) porque es un agregado del ecosistema de modding.

El mod la usa en un único archivo (`Infraestrutura/InfraestruturaMod.cs`) para
el IO del mod (`S3SE.IO.File`, `S3SE.IO.Directory.UserModDirectory`,
`S3SE.IsInitialized`). Para poder compilar el mod completo contra las DLLs
reales del juego **sin tocar el código fuente** —y respetando la regla del
upstream de que el IO del mod pasa por S3SE, nunca por `System.IO`— este stub
declara solo esa superficie.

- Se agrega como fuente extra en `build_mod_real.py` (no está en el `.csproj`).
- En runtime NUNCA se usa: el juego resuelve `Battery.Utility` contra la DLL
  real del loader S3SE.
- Si algún día aparece la DLL real de referencia, eliminar el stub y referenciarla.

## Historia: los "527 errores" ya no aplican

La validación anterior concluyó que compilar el mod completo "contra stubs" era
inviable (habría que stubear toda la API del juego). Con las DLLs reales de
referencia TS3 1.67 disponibles en
`~/Documents/Electronic Arts/ReferenceAssemblies/` eso quedó obsoleto: el mod
completo compila con **0 errores / 0 warnings** contra las APIs reales. Este
stub queda únicamente para el hueco de `Battery.Utility`. Ver README.md
§"Estado de compilación".
