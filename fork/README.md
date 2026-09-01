# sims-agents fork (Fase 1)

Fork de [NarradorPorEventosSimsPensantes] preparado para el proyecto **sims-agents**
(ver `../SPEC.md` y `../research/informe-narrador.md`). Runtime: **.NET Framework 2.0
in-process** dentro de TS3 1.67 — sin LINQ, delegados anónimos, reflexión vía
`LeitorPorReflexaoUtil` para todo lo que la API del juego no expone.

## Qué se agregó en Fase 1

| Archivo | Rol |
|---|---|
| `Dominio/Mod/AcaoDeSim.cs` | Acción tipada del LLM + enums `ModoExecucaoAcao` (continuation/next), `PrioridadeAcao`, `EstadoAcao`. |
| `Dominio/Mod/CatalogoAcoesPermitidas.cs` | **Lista blanca en catálogo tipado** (nunca en prompts). Matching tolerante: case-insensitive, sin acentos/espacios/guiones. |
| `Infraestrutura/Adaptadores/AdaptadorAcaoResposta.cs` | Parseo puro del campo opcional `acao:{interacao, alvo, modo, prioridade}` de la respuesta JSON. Sin APIs del juego → 100% testeable con mocks. |
| `Infraestrutura/Adaptadores/LeitorPorReflexaoUtil.cs` | Se agregó `InvocarMetodo()` (invocación reflexiva de métodos). |
| `Aplicacao/Mod/EjecutorDeAcciones.cs` | Ejecutor: valida contrato → lista blanca → resuelve sims → drena en hilo del juego → push. Lógica pura separada de las APIs del juego mediante `IProvedorSims` / `IFilaInteracoes`; la implementación real (`AdaptadorFilaInteracoesJogo`) resuelve `InteractionDefinition.Singleton` por reflexión, hace `CreateInstance(...)` y `InteractionQueue.PushAsContinuation/AddNext`. |
| `Infraestrutura/Adaptadores/{ContratosJsonNarrativos,AdaptadorArquivosNarrativos}.cs` | Contrato extendido: `RespostaNarrativaJsonContrato.AcaoBruta` propaga el dict crudo de `acao`. |
| `TestesDoMod/Autoverificacoes/TesteContratoAcaoEExecucao.cs` | Autoverificaciones (patrón del repo: `Executar()` devuelve lista de falhas) sobre lógica pura con mocks de `IProvedorSims`/`IFilaInteracoes`: parseo completo/mínimo/sin acao, defaults (modo=continuation, prioridad=normal), alvo obligatorio, matching de lista blanca, flujo feliz del ejecutor, rechazo fuera-de-lista y sim inválido, y verificación de que el push NO ocurre fuera del drenaje (hilo del juego). |

### Contrato de acción (respuesta del cerebro)

```json
{ "id": "...", "tipo": "pensamento", "resposta": "...",
  "acao": { "interacao": "hablar", "alvo": "<simId o nombre>",
            "modo": "continuation", "prioridade": "normal" } }
```

`modo` ∈ {continuation (default), next}; `prioridade` ∈ {baixa, normal (default), alta}.
Acciones que requieren sim objetivo (`hablar`, `coquetear`, `invitar_salir`, `reaccionar`)
rechazan sin `alvo`.

## Qué queda pendiente contra el juego real

El mod ya compila contra las APIs reales de TS3 1.67 (ver "Estado de compilación");
queda validar **semántica** in-game:

1. ~~**Nombres de tipos reales**~~ → ✅ VERIFICADOS (ago 2026) por reflexión directa contra
   las DLLs 1.67 (probes en /tmp, hallazgos volcados al catálogo). Mapeo final:

   | acción | tipo (NombreTipoDefinicion) | Singleton |
   |---|---|---|
   | comer | `Sims3.Gameplay.Objects.FoodObjects.Eat` | ✓ |
   | dormir | `Sims3.Gameplay.InteractionsShared.SleepAndNapOnObject` | ✓ (antes: `Sim+Sleep` NO existía) |
   | ir_al_trabajo | `Sims3.Gameplay.Careers.WorkInRabbitHole` | ✓ (antes: `ActorSystems.Career` no era interacción) |
   | hablar/coquetear/invitar_salir | `Sims3.Gameplay.Socializing.SocialInteractionA` | sin Singleton: data-driven |
   | usar_objeto_pasión | `Sims3.Gameplay.Objects.HobbiesSkills.Easel+Paint` | ✓ (placeholder concreto; `InteractionDefinitionProxy` NO existía) |
   | reaccionar/idle_con_pensamiento | `Sims3.Gameplay.Actors.Sim+StandIdle` | ✓ (`ReactToDisaster`/`Idle` NO existían) |

   Nota sociales: `SocialInteractionA+Definition` NO tiene Singleton; se instancia con
   ctor `(String name, String[] path, ActiveTopic topic, Boolean initialGreet)` — el
   adaptador necesita esa rama para las 3 acciones sociales (hoy resuelve solo Singletons).
   Cambios de hipótesis→real aplicados en `CatalogoAcoesPermitidas.cs` y rebuild OK.
2. ~~**Firmas de `CreateInstance` / `PushAsContinuation` / `AddNext`**~~ → ✅ VERIFICADAS y
   CORREGIDAS (ago 2026). Hallazgos contra la 1.67:
   - `CreateInstance(IGameObject target, IActor actor, InteractionPriority priority, bool isAutonomous, bool cancellableByPlayer)` — orden de args ya correcto, pero la prioridad era un float inventado: es el **struct** `Sims3.Gameplay.Interactions.InteractionPriority` con ctor `(InteractionPriorityLevel)`. Enum verificado: Zero/Autonomous/NonCriticalNPCBehavior/UserDirected/High/… Mapeo del mod: baixa=NonCriticalNPCBehavior(2), normal=UserDirected(3), alta=High(4).
   - `bool AddNext(InteractionInstance)` ✓ existía; `PushAsContinuation` requiere `(InteractionInstance, bool mustRun)` (hay 4 overloads — se agregó resolución de sobrecargas por tipos en `InvocarMetodo`, antes lanzaría AmbiguousMatchException).
   - `Singleton` es un **field**, no property: nuevo `LeitorPorReflexaoUtil.LerEstatico()`.
   - Resolución de tipos arreglada: los ensamblados son `Sims3GameplaySystems/Sims3GameplayObjects/SimIFace`; `"Sims3.Gameplay"` no existe como assembly.
   Neto: el adaptador viejo devolvía `false` SIEMPRE in-game. Ahora usa firmas reales.
3. ~~**Wiring del alarme**~~ → ✅ IMPLEMENTADO (ago 2026). `GerenciadorPrincipal`
   crea `EjecutorDeAcciones(new AdaptadorProvedorSimsJogo(), new AdaptadorFilaInteracoesJogo())`,
   pasa `AoAcaoNarrativaRecebida` como callback al `MotorNarrativo` (nuevo ctor) y ese
   callback llama `Encolar()` desde `LidarComRespostasDoServidor` (hilo lógico del juego).
   El push real ocurre en `DrenarPendentes()` invocado por un alarme
   `AlarmManager.Global.AddAlarmRepeating` de 1 minuto (`NarradorPorEventos.DrenajeAcciones`),
   mismo patrón que los drain/ciclos existentes; se re-registra en hot reload.
   El consumidor (`ConsumirRespostasNarrativasCasoDeUso`) extrae ahora la acción tipada
   del campo `acao` (`AdaptadorAcaoResposta.TentarExtrair`) y la expone en `saida.Acoes`.
4. ~~**Validación de sim**~~ → ✅ IMPLEMENTADA (ago 2026). Nuevo
   `Aplicacao/Mod/AdaptadorProvedorSimsJogo.cs`: `ResolverSim` busca por
   `SimDescriptionId` o `FullName` sobre `Queries.GetObjects<Sim>()` (patrón del upstream);
   `EhSimValido` = `ConsultaSim.EhSimValidoSemPet` + edad (rechaza Baby/Toddler/Child,
   solo Teen+ ejecuta acciones dirigidas). Archivo con APIs del juego → solo en el csproj,
   NO en `build-testes-fase1.sh`.
5. ~~**Lazo cerrado**~~ → ✅ IMPLEMENTADO (ago 2026). Tras el push, las sociales ejecutadas
   (`entrada.RequiereAlvoSim`) quedan pendientes en `SupervisorConfirmacionesAcciones`;
   un listener `EventTracker.AddListener(EventTypeId.kSocialInteraction, ...)` confirma la
   ejecución matcheando actor por id/nombre, marca `EstadoAcao.Confirmada` (nuevo valor = 5)
   y realimenta al LLM vía log narrativo (`MotorNarrativo.RegistrarConfirmacionAcao`,
   categoría `acao_confirmada`).
6. Correr las autoverificaciones in-game (`TesteContratoAcaoEExecucao.Executar()`)
   y probar la carga real del DLL dentro del juego.

## Estado de compilación (verificado con mono 6.12 / mcs)

| Target | Comando | Resultado |
|---|---|---|
| Autoverificaciones Fase 1 (exe standalone) | `sh build-testes-fase1.sh` | ✅ compila y **pasa: 0 falhas** (`build/testes-fase1.exe`) |
| Mod completo (65 archivos del `.csproj`) contra DLLs reales TS3 1.67 | `python3 build_mod_real.py` | ✅ **compila: 0 errores, 0 warnings** (`build/ZZZZitalo.TS3Mods.NarradorPorEventos.dll`, PE32 .NET válido) |

### Cómo se compila el mod completo

Requisitos (ya resueltos en esta máquina):

1. Las 10 DLLs de referencia de TS3 1.67 (fuente NRaas Compiler, runtime 2.5
   custom EA) en
   `~/Documents/Electronic Arts/ReferenceAssemblies/` — hoy es un symlink a la
   copia en el disco secundario (`ln -sfn <ruta real> "$HOME/Documents/Electronic Arts/ReferenceAssemblies"`).
2. Compilar con `-nostdlib` pasando solo los ensamblados de EA como referencias:
   mezclarlos con el perfil de Mono produce CS1703/CS1685 (identidades duplicadas).

```sh
python3 build_mod_real.py   # extrae los <Compile> del .csproj, invoca mcs y reporta errores por código
```

Fixes aplicados durante la primera compilación exitosa:

- `GerenciadorPrincipalModNarracaoPorEventos.cs`: `World.OnWorldLoadFinishedEventHandler`
  → `World.sOnWorldLoadFinishedEventHandler` (convención EA 1.67 real: campo estático
  con prefijo `s`; verificado con `monop` contra `SimIFace.dll`). Era exactamente el
  punto 1 del listado "pendiente": nombres reales contra el juego.
- `Battery.Utility.dll` (S3SE) no está entre las DLLs estándar ni en la instalación:
  se agrega `stubs/Battery.Utility.CompileStub.cs` **solo para compilar** (superficie
  mínima usada: `S3SE.IsInitialized`, `S3SE.IO.File.*`, `S3SE.IO.Directory.UserModDirectory`).
  En runtime el juego resuelve ese namespace contra la DLL real del loader S3SE;
  el stub nunca se embarca. El IO del mod sigue siendo S3SE (regla del upstream).

Detalles:

- El código de Fase 1 (`AcaoDeSim`, `CatalogoAcoesPermitidas`,
  `AdaptadorAcaoResposta`, `EjecutorDeAcciones`) **no usa ninguna API directa del
  juego** (desacople por `IProvedorSims`/`IFilaInteracoes` + reflexión), así que
  compila directo con `mcs` y corre con mono, **sin necesidad de stubs**.
- `TestesDoMod/TestRunnerFase1.cs` es un runner standalone (no forma parte del
  `.csproj` del mod); ejecuta `Executar()` y sale 0/1.
- Fix aplicado durante la validación: el test `ValidarEjecutorFueraDeLista`
  asumía que una acción fuera-de-lista aparecía en `DrenarPendentes()`, pero el
  ejecutor la rechaza ya en `Encolar()` sin encolarla (comportamiento deseado).
  Test corregido para verificar rechazo en `Encolar()` + drenaje vacío.
- Nota mcs: NO usar `-langversion:3` aunque el target sea .NET 2.0 — la sintaxis
  del repo usa features C#6+ (expression-bodied members) que mcs compila igual a
  IL 2.x válido para el CLR custom del juego.
