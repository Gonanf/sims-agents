# PROGRESS.md — Estado del mod NarradorPorEventos (fork sims-agents)

Actualizado: 2026-08-31 23:15 -03, sesión debug completa (para retomar mañana).

## Hecho y verificado

### 2026-08-25 (corte previo)
- **Compilación**: `python3 build_mod_real.py` → 0 errores, 66 archivos, DLL 746 KB. BCL Mono 2.0-api + EA 1.67. Tests Fase 1 OK.
- **Catálogo acciones + Ejecutor**: 4 bugs corregidos (assembly `Sims3GameplaySystems/Objects`, `Singleton` FIELD, `InteractionPriority` struct, overloads `PushAsContinuation`).
- **S3SA/DBPF**: formato descifrado (`tools/s3sa.py`), TGI `073FAA07/0/D8957B186B7324FE`, S3SE dual (fallback System.IO).

### 2026-08-31 día (verificación directa contra disco)
- **Build actual**: `build_mod_real.py` → 0 errores, 1 warning `CS0162` (hard-disable `SincronizarRecursosVisuais`). DLL `fork/build/ZZZZitalo.TS3Mods.NarradorPorEventos.dll` 764,416 B. `package_mod.py` DBPF v2 2 entries (`0x40E1FA25` S3SA + `0x0333406C` XML), `bitfield=0`, `idxSize=68`, `indexPos` 764,647, `VALIDACION COMPLETA OK`, `S3SA[8:]==DLL` byte-identical. TGI DLL `FNV64(assembly)=45359eba95bcc053`, XML `FNV64(assembly.class)=9d4d4084e664bdba`. Comp `0x00010000` (raw s3pe) tras fix, `GROUP_NONE=0x0`.
- **Instalación Wine**: `Los Sims 3` es el doc activo (ES, `DeviceConfig.log` confirma), `The Sims 3` es mirror EN. `Los/Mods/Packages/ZZZZ…package` 747 KB en ambas rutas, `Los/Mods/Resource.cfg` 836 B (P500 `Packages/*.package`, P1000 `Overrides/*`), `The/Mods/Resource.cfg` copiado (antes faltaba). `scriptCache.package` 260 B tras cada reinicio (2 entradas base, sin nuestro `S3SA` dentro — buscado UTF-16LE, no está).
- **Crash `0xAC32A`**: 5+ `xcpt CHAMAN` `TS3W.exe+0xAC32A` leyendo `0x46c50000/0x5c8d0000`, sin stack managed. `cabeca_sim_fixa=false` + `SincronizarRecursosVisuais` hard-disabled, persiste → no es nuestro visual. Nuevo crash 23:11 `msvcr80.dll 0x758bc71a` leyendo `0x07f50000` mientras escaneaba `C:\…\Mods\Packages\Sims 3 Store…` (stack muestra path) → heap 32-bit + Store 6 GB.
- **Eventos vacíos**: `pedidos.json` `{"pedidos":[]}` 47 B en ambos ES/EN, `respostas.json` solo smoke `smoke-1` Bella (22:30) y viejos. `boot.log`/`boot_raw.log` nunca aparecen → `AoCarregarMundo` no escribe.
- **Server**: `llama.cpp` `:11434` (Kateto) y `:57449` vivos. `fork/build/narrador_server.py` habla OpenAI `/v1/chat/completions` correcto. `.NET OllamaService` usa `/api/generate` → mismatch. `narrador_server.py` smoke sintético `smoke-1` OK (pedido Bella → resposta 220c sin `</think>`, `pedidos` limpiado a `[]`).

### 2026-08-31 noche (sesión debug 22:30-23:15, ponytail)
- **Diagnóstico Lista de modificaciones**: Usuario confirma que la lista que no muestra `ZZZZ` es el diálogo startup "Lista de modificaciones" (no el Store Installed Content). Con 8 paquetes (4 Store 5.8 GB + dummies + velocitygrass + ZZZZ) solo 2 Store (`021-040`, `041-055`) aparecían; con 4 pequeños (dummies+velocitygrass+ZZZZ) **0** aparecían; con `FrameworkSetup` dummies (`NoBuildSparkles` 628 B + `nointro` 836 B) instalados, tampoco aparecían. Python `glob` confirma `Resource.cfg` sí encuentra 6-8 matches en `Packages/*.package` (incluye ZZZZ), pero `scriptCache` nunca cachea nuestro `S3SA` (búsqueda `0x45359…` UTF-16LE negativa) y `boot_raw` UTF-16LE no aparece en DLL empaquetada hasta rebuild 22:38.
- **Fixes aplicados (todos rebuild + reinstalado, `Packages` en ambas ES/EN, `scriptCache` borrado cada vez)**:
  1. `InfraestruturaMod.cs` fallback EN-hardcoded → detecta `Los` vs `The` (prefiere `Los` si existe, crea `Los` por defecto en Wine ES). `ponytail: detecta locale`.
  2. `GerenciadorPrincipalModNarracaoPorEventos.cs` `AoCarregarMundo` → `boot_raw.log` vía `System.IO` directo a ambos `Los`/`The` absolutos antes de `InicializarDependencias()` (bypass `ContextoMod`), más `boot.log` vía adapter después. Fix `Environment` ambiguo (`System.Environment`).
  3. Configs ES/EN `diretorio.documentos_mod` → `Los Sims 3` (antes `The`), `ollama.url` → `http://127.0.0.1:11434/v1/chat/completions`, `modelo=Kateto`, `log_verbose=true` en ambas + `fork/NarradorPorEventos.config.json`.
  4. `Resource.cfg` copiado a `The Sims 3/Mods/`.
  5. `package_mod.py` `comp` `0x00000000` → `0x00010000` (raw s3pe) — `GROUP_NONE` se corrigió de vuelta a `0x0` tras patch global erróneo.
  6. `FrameworkSetup.zip` (chii.modthesims.info) extraído — dummies instalados. `Overrides/ZZZZ` duplicado (765 KB viejo 26-08) eliminado.
  7. Aislamiento memoria: movido Store 5.8 GB a `/tmp/StoreBackup` → `Packages` 3.8 MB (4 pequeños), luego restaurado (ahora 8 paquetes 5.8 GB). En cada ciclo `scriptCache` borrado, `TS3W.exe` matado (`pkill`, timeout 120s, 2 restarts: PID 3064364→3089444→3157941→3198293).
- **Estado al cierre (23:15)**: `Packages` restaurado 8 paquetes 5.8 GB, `scriptCache` borrado (no existe), `narrador_server` PID 3130259 sigue polling `Los` (`pedidos=[]`), `boot*.log` siguen sin aparecer, `pedidos.json` 47 B, `Lista de modificaciones` sigue sin `ZZZZ` ni notificación `StyledNotification` en world load.

## Pendiente para mañana (plan propio, no repetir handoff)

### P0. Tests automatizados (sin intervención) ✅ Implementado 2026-09-01
|- `run-tests.sh` en raíz del repo ejecuta TODO el suite sin intervención:
|  - `pytest tests/` (21 tests Python: build, package_mod, narrador_server)
|  - `dotnet test` NarradorEngine.Server.Tests (xunit, 28 tests .NET)
|  - `python3 build_mod_real.py` (compila, valida 0 errores)
|  - `python3 build/package_mod.py` (genera + valida .package DBPF)
|- GitHub Actions `.github/workflows/tests.yml` — jobs paralelos:
|  - `tests-python` (pytest + bun)
|  - `tests-dotnet` (xunit)
|  - `build-mod` (mcs + validate package)
|  - `full-suite` (depende de los 3 anteriores)
|- Tests nuevos creados en `fork/tests/`:
|  - `test_build_mod_real.py`: existencia, 66 fuentes csproj, 0 errores mcs, DLL generada
|  - `test_package_mod.py`: .package DBPF válido, validate(), idempotente, S3SA byte-identical a DLL
|  - `test_narrador_server.py`: Config carga, interpolar, crear_prompt, sanitizar, foco, pedidos vacío
|- Tests existentes verificados: `TesteContratoAcaoEExecucao` (mono), `TesteRegrasRegistroNarrativo`, `TesteRepositorioTiposEvento`, `TestRunnerFase1` — y `NarradorEngine.Server.Tests` xunit (28 tests).
|- Pipeline completamente idempotente: re-ejecutar `run-tests.sh` da el mismo resultado.

### P1. Debug con NRaas DebugEnabler (https://lizzielilyy.com/sims-3/guides/mods-cc/nraas-debugenabler-tutorial/)
- Instalar `NRaas_DebugEnabler.package` en `Los/Mods/Packages` (framework ya ok). Habilita menú Debug en City Hall / Sim → `NRaas > DebugEnabler > ...` y logs en `Logs/ScriptError_*.xml`. Usarlo para:
  - Ver si el juego reconoce `GerenciadorPrincipalModNarracaoPorEventos` como `kInstantiator` (lista `Script` en DebugEnabler).
  - Forzar `World.sOnWorldLoadFinished` y ver si nuestro `AlarmHandle` se registra.
  - Capturar `ScriptError` si la DLL falla al cargar (ej. `MissingMethodException` por `GetFolderPath` en mscorlib EA recortado — aunque antes cargó y crasheó, ahora no).
- Verificar `Sims3Logs.xml` y `Logs/` tras cada intento.

### P2. Compilar el upstream base (https://github.com/itpzzi/NarradorPorEventosSimsPensantes) tal cual
- Clonar en `/tmp/upstream` y `python3 build_mod_real.py` con las mismas refs EA 1.67 + BCL 2.0-api. Empaquetar con el mismo `package_mod.py` y instalar como `AAAA_TestUpstream.package` (prefijo `AAAA` para cargar antes). Si **tampoco** aparece en "Lista de modificaciones" ni notifica → el problema no es del fork (es del entorno Wine/heap/Resource). Si **sí** aparece → diffear `Gerenciador`, `Infraestrutura` y `Configuracao` entre upstream y fork para aislar la regresión (nuestros 3 fixes + `SincronizarRecursosVisuais` hard-disable).

### P3. Aislar scan de Packages (si P1/P2 no aclaran)
- Con `Packages` solo con `ZZZZ` + dummies (3.8 MB) y Store en `/tmp`, renombrar Store a nombres cortos `S01.package` etc. y probar de nuevo (crash 23:11 fue `msvcr80` sobre path largo `Sims 3 Store Updates …`).
- Probar `ZZZZ` sin `ZZZZ` prefix (`NarradorPorEventos.package`) y en subcarpeta `Packages/Test/` (Resource escanea 5 niveles).
- Verificar `DeviceConfig.log` y `Options.ini` por flags de mods deshabilitados.

### P4. Control con mod de referencia que sí carga (https://boringbones.blogspot.com/2024/05/supreme-ia-sims-autoconscientes.html)
- **Qué es**: `SUPREME IA - Sims Autoconscientes` (BoringBones) — autonomy mod que desbloquea todas las interacciones del jugador (módulos `BB-SUPREME-AI` + `BB-Renaissance`). No es LLM, pero es un **control puro XML-tuning**: debería aparecer siempre en "Lista de modificaciones" si el framework escanea bien. Instrucción del autor: instalar en `Overrides/` (no `Packages/`) para optimizar carga.
- **Uso como test**: Descargar `SUPREME IA` (Drive `1LSWMzXZ…` / V2 `1YsEKXQz…`) y ponerlo en `Los/Mods/Overrides/` junto a `ZZZZ`. Si **Supreme IA aparece** pero `ZZZZ` no → nuestro `S3SA`/`FNV64`/`comp` es el filtro (package). Si **tampoco** aparece Supreme IA → el scan de `Overrides`/`Packages` está roto globalmente (Resource/heap/Wine), no es nuestro DLL.
- **Nota**: Requiere `Classic Sims Revival` + `Get Out Project` para el modo "1 Sim controlado + resto autónomo" (`Opções > Desativar autonomia para o Sim selecionado` + `Vontade Própria Alta`). No interfiere con `NRaas StoryProgression` (alternativa más liviana, según BoringBones).

## Contexto útil para retomar

- Fork root: `/home/chaos/proyectos/sims-agents/fork/`
- Build: `fork/build/ZZZZitalo.TS3Mods.NarradorPorEventos.dll` (764,416 B) + `.package` (764,715 B, 2 entries, `comp 0x10000`). Último `package.instalado.package` 764,203 B (pre-fix, también probado 22:57 y tampoco cargó).
- Editor: `GerenciadorPrincipalModNarracaoPorEventos.cs:63` `boot_raw` (UTF-16LE ok), `InfraestruturaMod.cs:84` fallback Los/The.
- Packages ES `Los Sims 3/Mods/Packages/` (8): `NoBuildSparkles` 628 B, `nointro` 836 B, `Sims 3 Store Fixes` 25 MB, `Store Updates 001-020` 2.0 GB, `021-040` 2.0 GB, `041-055` 2.0 GB, `velocitygrass` 3.1 MB, `ZZZZ` 747 KB. EN `The Sims 3/Mods/Packages/` (3): dummies + ZZZZ.
- Docs ES `Los Sims 3/Mods/NarradorPorEventos/`: `config.json` (Los, Kateto, verbose true, `pedidos.json` 47 B, `respostas.json` 1.5 KB smoke), sin `boot*.log`. EN mirror idem (The, sin `scriptCache`).
- Server: `narrador_server.py` PID 3130259 `UPSTREAM http://127.0.0.1:11434/v1/chat/completions` (Kateto), `llama.cpp` `:11434` y `:57449`. `.NET` server apagado (mismatch `/api/generate`).
- Wine: `Personal=C:\users\chaos\Documents` → `drive_c/users/chaos/Documents`, `Los Sims 3` es el doc activo (ES), `The` es mirror. `Resource.cfg` 836 B en ambos. `scriptCache` 260 B (2 entradas base) tras cada arranque; `S3SA` no cacheado.
- Herramientas: `build_mod_real.py`, `build/package_mod.py` (DBPF v2, `bitfield=0`, `S3SA` raw), `fork/build/narrador_server.py`, `server_maps.json`.
- Crash logs: `xcpt CHAMAN 26-08-31 23.03.08` + `23.11.13` nuevos (msvcr80 y 0xAC32A), además de 5 previos.
- URLs mañana: DebugEnabler https://lizzielilyy.com/sims-3/guides/mods-cc/nraas-debugenabler-tutorial/ , upstream https://github.com/itpzzi/NarradorPorEventosSimsPensantes
