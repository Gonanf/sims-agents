# Informe técnico: NarradorPorEventosSimsPensantes (mod C# para The Sims 3)

Repo clonado en `/home/chaos/proyectos/sims-agents/research/narrador-fork-ref/` (análisis estático, ~89 archivos .cs, ~27k LOC). Código en portugués, docs en inglés. Inspirado en "Generative Agents" (Stanford) y los Zois "thinking" de inZOI.

## 1. Mapa de archivos clave

| Área | Archivo | Rol |
|---|---|---|
| Entry point | `GerenciadorPrincipalModNarracaoPorEventos.cs` | Hook `World.OnWorldLoadFinishedEventHandler`; registra listeners, alarmes y recursos visuales |
| Eventos | `ServicosDoMod/Eventos/RepositorioEventosTheSims3.cs`, `CatalogoEventos.cs` (12.5k LOC) | Catálogo tipado de event IDs del juego con peso/categoría/leyenda/ruido |
| Fila | `ServicosDoMod/Fila/ControladorFilaEventosNarrativos.cs`, `NucleoNarrativo/PoliticaFilaEventosNarrativos.cs` | Buffer en memoria + drenaje por alarme |
| Motor | `NucleoNarrativo/MotorNarrativo.cs` | Orquestador: convierte evento → acumula → dispara pedidos → consume respuestas |
| Ciclos | `NucleoNarrativo/CicloNarrativoBase.cs`, `CicloNarrativoPensamento.cs`, `CicloNarrativoConto.cs` | Umbrales de pensamiento vs. cuento |
| Contexto | `ServicosDoMod/Contexto/ContextoParaLLM.cs` + `RepositorioConsulta/*` (ConsultaSim, ConsultaHumorDoSim, ConsultaNecessidadesDoSim, ConsultaHabilidadesDoSim, ConsultaFamiliaAtiva, ConsultaMundo, ConsultaAmbiente, ConsultaRelacionamentosDoSim…) | Snapshots de estado por scopes sim/familia/lote/mundo |
| Contrato I/O | `Aplicacao/Mod/{AnexarPedidoNarrativoCasoDeUso,ConsumirRespostasNarrativasCasoDeUso}.cs` | Archivos JSON puente mod↔servidor |
| Servidor externo | `NarradorEngine.Server/{Processamento/LoopServidor.cs, Processamento/PromptsNarrativos.cs, Servicos/OllamaService.cs}` | Proceso .NET 8 aparte que llama a Ollama |
| Visuales | `ServicosDoMod/Visuais/{ControladorRecursosVisuaisNarrativos,ControladorCabecaSimFixa,ControladorTooltipNarrativoSobreCabeca}.cs` | Overlay de cabeza + tooltip = "globo de pensamiento" |
| Utilidades clave | `Infraestrutura/Adaptadores/LeitorPorReflexaoUtil.cs`, `AdaptadorColecoesPorReflexaoUtil.cs` | **Reflexión** sobre propiedades privadas/internas de clases del juego |

## 2. Arquitectura: cómo engancha con el motor

- **No usa Harmony ni patching de IL.** Usa la superficie oficial de modding de TS3 (estilo NRaas/S3SE): clase con `[Tunable] kInstantiator` + constructor estático que se suscribe a `World.OnWorldLoadFinishedEventHandler` (namespace `Sims3.SimIFace`). Todo el trabajo ocurre al terminar de cargar el mundo.
- Runtime objetivo: **.NET Framework 2.0** dentro del proceso del juego (TS3 corre un CLR legacy); por eso el código evita LINQ y usa delegados anónimos.
- **Patrón arquitectónico**: clean architecture (Dominio/Aplicacao/Infraestrutura/RepositorioConsulta) sobre una API de juego hostil.
- **Truco transversal**: como el ensamblado del juego no expone todo públicamente, el mod accede a miembros internos vía reflexión (`LeitorPorReflexaoUtil.LerPropriedade(sim.SimDescription, "IsPet")`, `LerTexto(e, "InteractionName", ...)`, e incluso `LerPropriedade(typeof(Sim), "ActiveActor")`). Esto es el patrón a replicar para cualquier API no documentada.
- Timers: `AlarmManager.Global.AddAlarmRepeating(...)` (`Sims3.Gameplay.Utilities`) — ciclo programado (persistencia cada 1h de juego), hot-reload de config (~10s reales) y consumidor de fila (5 min).

## 3. Pipeline de eventos

1. **Registro**: para cada entrada del catálogo (`RepositorioEventosTheSims3.Todos()`), hace `Enum.Parse(typeof(EventTypeId), id)` y `EventTracker.AddListener(id, AoEventoNarrativo)` (`Sims3.Gameplay.EventSystem`). Solo registra IDs que existen en el enum actual (mapa precomputado con `Enum.GetNames`), tolerando versiones sin packs.
2. **Listener ligero**: el callback solo filtra ruido (`tipo.EhRuido` del catálogo) y encola: `ControladorFilaEventosNarrativos.Enfileirar(e)`. Nada pesado en el hilo del evento.
3. **Rate-limit en la cola** (`PoliticaFilaEventosNarrativos`, hardcodeado): ventana de 50 eventos aceptados, máx. **3 ocurrencias por tipo** en esa ventana, drain cada **5 min**, máx. **25 eventos por ciclo**.
4. **Dedup en el motor** (`MotorNarrativo.DeveIgnorarDuplicidade`): cache LRU-ish de 500 eventos con clave `tipo|horarioJuego|actor|alvo|descripción`; caso especial para interacciones sociales sin target (evita doble conteo actor/alvo).
5. **Tipado**: `RepositorioEventosTheSims3.Resolver(id)` devuelve `EventoTheSims3` con categoría (`Pensamento`/`Conto`), `Peso` y leyenda pt-BR. La descripción se arma con datos extraídos por reflexión del `Event` (nombre de skill, nombre de interacción social, etc.). Actor/alvo: `e.Actor as Sim`, `e.TargetObject as Sim`, fallback reflexión (`TargetSim`, `OtherSim`, `Target`...).
6. **Umbrales de disparo** (dos ciclos paralelos, config compartida):
   - Pensamiento: acumula **5 eventos relevantes** que involucren al sim activo → genera pedido.
   - Cuento: **100 eventos** (incluye estado familia+mundo).
   - Límite de resumen: 20 / 100 eventos; contexto capado a **12.000 caracteres**.
7. **Snapshot de estados**: `EscritorEstadosNarrativos` persiste `NarradorPorEventos.estado.{sim,familia,lote,mundo}.json` cada hora de juego.
8. **Pedido**: cuando un ciclo alcanza su umbral arma un `PedidoNarrativo {Id, Tipo, SimAtivo, HorarioReal, Contexto}` y lo **anexa a `Mods/NarradorPorEventos.pedidos.json`**.

Formato del contexto (texto plano `k=v | k=v`):
```
tipo=pensamento | sim=Bella Goth | estado_sim=identidad=... humor_codigo=3 ... necesidades=... habilidades_resumo=... desejos=... | estado_lote=... | eventos=[resumen]
```
Los valores vienen de `ConsultaSim/Humor/Necessidades/Habilidades/Familia/Mundo` — todos lecturas de la API del juego (mood via `ConsultaHumorDoSim.CodigoNivelAtual(sim)`, traits, deseos/Wishes via `AdaptadorVerboseDesejosDoSim`, etc.).

## 4. Integración LLM

- **Desacoplada por archivos, no HTTP desde el juego**: el CLR 2.0 in-process no puede hacer HTTP cómodamente, así que hay un **servidor externo .NET 8** (`NarradorEngine.Server`) con loop de polling (`LoopServidor.ExecutarAsync`, intervalo `IntervaloPollMs`):
  - Lee `pedidos.json` → borra tras leer.
  - `PromptsNarrativos.CriarPrompt`: compone prompt principal + perfil de usuario (tono/audiencia) + directriz por traits (`DiretrizPorTracos` parsea los traits del contexto) + foco emocional (`ModificadoresDeTomNarrativo`).
  - Memoria narrativa: `RepositorioContextoNarrativoPrevio` mantiene `NarradorPorEventos.contexto.previo.json` (respuestas anteriores reinyectadas si `feature.incluir_contexto_previo`); además un prompt de "perfil del narrador" generado por el propio modelo se cachea y refresca (`ProcessadorPerfilNarrativoUsuario`).
- **OllamaService**: POST JSON a `http://127.0.0.1:11434/api/generate` con `{model (default deepseek-r1:7b), prompt, stream:false, options{...}}`; respuesta `{response}`. Timeout configurable (min 5s), sin proxy.
- Sanitización de salida (`AdaptadorRespostaNarrativa.Sanitizar`): una línea, quita aspas/arte factos tipo `<think>` residual.
- Escribe `NarradorPorEventos.respostas.json`; el mod lo consume en cada ciclo de fila y en el alarme horario (`MotorNarrativo.LidarComRespostasDoServidor`).

## 5. Renderizado de la salida

Dos canales:
1. **Pensamientos ("globo")**: NO usa el ThoughtBalloon nativo del juego. Es un overlay UI propio:
   - `ControladorCabecaSimFixa`: replica/ancla la SimHead del Pie Menu HUD (ventana del UI de TS3 vía `Sims3.UI`).
   - `ControladorTooltipNarrativoSobreCabeca`: crea un `SimpleTextTooltip` con word-wrap, `IgnoreMouse=true`, posicionado sobre la cabeza usando conversiones `WindowToScreen/ScreenToWindow`. Si no hay pensamiento fresco muestra mensajes idle rotativos. Actualiza solo si cambia el texto.
   - `ControladorRecursosVisuaisNarrativos` coordina ambos y recibe las respuestas vía callback `AoRespostaNarrativaRecebida`.
2. **Cuentos**: notificación estilo juego — `NotificadorDoMod.Notificar(msg, StyledNotification.NotificationStyle.kGameMessagePositive)` (y `kGameMessageNegative` para errores), con dedup de 200 claves de notificación.

## 6. Cómo implementar acciones por LLM (lo importante para sims-agents)

**Hallazgo central: el fork es 100% read-only respecto del motor.** No toca `InteractionSystem`, autonomía, ni situaciones. Sus referencias al juego son de lectura (`Sims3.Gameplay.Actors.Sim`, `Sims3.Gameplay.CAS`, `EventSystem`, `Sims3.UI`) más escrituras cosméticas (notificaciones, tooltip). Tampoco hay wish-pushing. Por tanto la superficie de acciones hay que construirla; el fork aporta el esqueleto (eventos→LLM→respuesta) y dos mecanismos reutilizables: (a) reflexión para alcanzar APIs internas, (b) el contrato de archivos pedidos/respostas, que ya es bidireccional — bastaría agregar un campo `acao` a la respuesta.

Superficies concretas de The Sims 3 (clases del namespace `Sims3.Gameplay.*` que el juego provee; el fork ya referencia varias de ellas indirectamente):

1. **Push de una interacción (la vía principal)** — `Sims3.Gameplay.Actors.Sim`:
   - `sim.InteractionQueue.AddNext(InteractionInstance)` — encola prioridad alta.
   - `sim.InteractionQueue.PushAsContinuation(...)` / `InteractionInstance.TryPushAsContinuation(...)` — inserta como continuación de lo que hace ahora (menos disruptivo, ideal para agentes autónomos).
   - `sim.InteractionQueue.CancelAllInteractions()` para cancelar.
   - Crear la instancia: cada acción es una `InteractionDefinition` estática, p.ej. `Sims3.Gameplay.Objects.Seating.Sit.Singleton` o `Sims3.Gameplay.Socializing.SocialInteractionA.Definition("Talk", ...)`; patrón típico: `def.CreateInstance(simObjetivo, simActor, priority, isAutonomous, cancellable)` y luego push. Para descubrir definiciones disponibles en runtime: reflexión sobre campos `Singleton` (el fork ya tiene `LeitorPorReflexaoUtil` exactamente para esto).
2. **Autonomía dirigida**: `Sims3.Gameplay.Autonomy.Autonomy` — se puede sesgar/marcar deseos; más frágil, mejor usar push directo.
3. **Wishes (deseos)**: el fork ya *lee* deseos (`ConsultaDesejosDoSim`, `AdaptadorVerboseDesejosDoSim`); el espejo de escritura es `SimDescription.Wishlist`/`WishManager.TryPushWish(...)` — útil para "sugerir" metas al motor sin control directo.
4. **Situaciones** (`Sims3.Gameplay.Situations.*`): para conductas compuestas multi-sim (pelea, romance); instanciar una Situation es la forma correcta de escenas largas.
5. **Movimiento simple**: `sim.DoRoute(...)` / `GoToLot` para reposicionar antes de interactuar.
6. **Teleología de bajo nivel**: `CommodityChange`, motives vía `sim.Motives` (ya consultados por `ConsultaNecessidadesDoSim`) — pueden escribirse para forzar estados.

### Diseño recomendado para el fork/agente

```
EventTracker listeners ──► Fila (5min/25ev) ──► MotorNarrativo ──► pedidos.json
                                                                     │
                                              Servidor .NET 8 ◄──────┘
                                                │ Ollama (/api/generate)
                                                ▼
                              respostas.json  ← nuevo campo "acao":
                              { tipo:"pensamento", texto:"...", acao:{
                                  "interacao":"Talk", "alvo":"<simId>",
                                  "modo":"continuation|next", "prioridade":"normal" } }
                                     │
                                     ▼ (consumidor existente, MotorNarrativo)
                        Nuevo EjecutorDeAcciones (en-game, main thread del juego):
                        resolver Sim por SimDescriptionId → buscar InteractionDefinition.Singleton
                        por reflexión → CreateInstance(...) → InteractionQueue.PushAsContinuation/AddNext
```

Puntos críticos de implementación:
- **Todo push debe correr en el hilo lógico del juego** (dentro de callbacks de `AlarmManager` o listeners — el fork ya garantiza eso; nunca desde el servidor externo).
- Validar edad/especie/ocultismo antes de pushear (el fork ya tiene `EhSimValidoSemPet`, `IdadeEmTexto`).
- Confirmación en lazo cerrado: tras el push, escuchar el `EventTypeId` correspondiente (p.ej. `kSocialInteraction`) — el catálogo del fork ya mapea esos IDs, así que el agente puede verificar que la acción ocurrió y realimentarla al LLM como nuevo evento.
- Mantener la lista blanca de acciones permitidas (seguridad) en el catálogo tipado existente (`EventoTheSims3`-style), no en prompts.
