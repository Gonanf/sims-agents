# Spec técnica — Agentes LLM autónomos en Sims 3

**Estado:** borrador v0.1 (2026-08-24) — en discusión con Chaman
**Origen:** blog `agentes-autonomos-sims3.md` (docs Kateto, /blog/)
**Referencia técnica base:** [NarradorPorEventosSimsPensantes](https://github.com/itpzzi/NarradorPorEventosSimsPensantes)

## Concepto

3 agentes LLM viviendo una vida completa en Sims 3, streameados. La autonomía nativa del motor es el cuerpo (motives, traits, interacciones); el LLM es la biografía (estrategia, memoria, personalidad expresada). Viewers pagan por efecto individual, cada uno entra como intención al mundo, nunca como comando.

## Decisiones cerradas

- 3 agentes para MVP
- Fork del repo NarradorPorEventosSimsPensantes
- Interacciones nativas del motor expuestas como acciones tipadas; MVP con ~10 curadas
- Cerebro en proceso externo, contrato tipo MCP (acciones tipadas JSON), primer puente HTTP local
- Triggers event-driven: threshold de acumulación + umbrales críticos inmediatos
- Monetización: catálogo plano de efectos con precio por impacto, tope anti-caos configurable

## Arquitectura

```
┌─────────────────┐     eventos (JSON)      ┌──────────────────┐
│  Sims 3 + mod    │ ───────────────────────▶│   Cerebro         │
│  (fork Narrador) │                         │  (proceso externo)│
│                  │ ◀─────────────────────── │  - scheduler      │
│  InteractionSystem│     acciones tipadas    │  - memoria x agente│
└─────────────────┘                          │  - prompts        │
                                             └────────┬─────────┘
                                                      │ API
                                             freellmapi (modelos chicos)
```

### Componentes

1. **Mod C# (fork del Narrator)**
   - Capa eventos (heredada): despacha eventos del juego con threshold de acumulación.
   - Capa acción (nueva): endpoint HTTP local que recibe acciones tipadas y las ejecuta vía InteractionSystem del motor. Validación gratis: si el motor tiene la interacción, es legal.
   - Umbrales críticos inmediatos: need al rojo, donación entrante, interacción social iniciada → saltan la cola sin esperar el buffer.

2. **Cerebro (proceso externo)**
   - Scheduler multi-agente: quién decide cuándo, qué memoria ve cada agente, presupuesto de llamadas.
   - Memoria por agente: traits nativos del sim + resumen histórico de eventos propios (patrón Smallville: record → reflect → plan).
   - Contrato de salida: lista finita de acciones tipadas JSON (`{agent, action, target?, params}`), definida desde el día 1 como si fuera MCP para poder portar el cerebro.

3. **Capa viewer (fase 2, después del MVP local)**
   - Webhook de donaciones (StreamElements/Ko-fi/etc.) → cola de intenciones.
   - Catálogo de efectos con precio; cada efecto se traduce a evento del mundo (rumor, objeto, visitante, cambio de forzado).
   - Tope anti-caos: máx N efectos estructurales por hora (configurable).
   - Overlay/stream: cámara libre o automática, globos de texto legibles.

## MVP actions (~10 curadas)

Por confirmar contra el catálogo real del motor al hacer el fork:
comer, dormir, ir al trabajo, hablar (social genérica), invitar a salir/lugar, coquetear, comprar objeto, usar objeto de pasión (ej. escribir novela), reaccionar a evento recibido, idle con pensamiento.

## Modelo de costos

- Llamada LLM solo en triggers (threshold/crítico), no por acción del motor.
- Modelos chicos baratos (freellmapi) para decisión rutinaria; modelo más grande reservado para conversaciones entre agentes y reacciones a donaciones (presupuesto diferenciado).

## Fases

1. **Fase 0 — Reconocimiento:** clonar y correr el mod Narrador tal cual; mapear su pipeline real (eventos, threshold, formato de prompt), inventariar interacciones disponibles vía C#.
2. **Fase 1 — MVP local:** fork → capa acción HTTP → cerebro externo con 1 agente decidiendo sobre ~5 acciones. Métrica de éxito: un sim toma decisiones no deterministas visibles durante 30 min sin intervención.
3. **Fase 2 — Multi-agente:** 3 agentes, memoria separada, interacciones sociales entre ellos. Métrica: al menos un intercambio social emergente no scripteado por sesión.
4. **Fase 3 — Stream:** overlay, globos legibles, TTS opcional. Stream de prueba privado.
5. **Fase 4 — Viewer interaction:** webhook donaciones → catálogo de efectos pagos → tope anti-caos. Stream público.

## Preguntas abiertas

- ~~Versión de Sims 3~~ → resuelto: v1.67.2.024037 (instalación no oficial). Nota: 1.67 es la última versión que soporta la mayoría de los script mods de la era NRaas, o sea ecosistema C# maduro disponible.
- freellmapi function calling → asumido sí, verificar en Fase 0 con un test mínimo.
- Stream: YouTube primero (webhook de donaciones: YouTube Super Chat / API de memberships), Twitch posible a futuro — el diseño del webhook debe ser agnóstico del platform desde el día 1.
- Hardware: todo corre en Chaman (RX 6500 XT 4GB + DG1, 31GiB RAM) — juego + cerebro externo + OBS + encode de stream en la misma máquina. Implica: resolución de stream conservadora, y el cerebro NO puede ser pesado localmente (refuerza la decisión freellmapi remoto).

## Nota legal/operativa (Chaman)

La copia de Sims 3 es no oficial (v1.67.2.024037). Consecuencias prácticas para el proyecto:
- El stream NO puede mostrar UI/assets que identifiquen el origen pirata sin riesgo; streamear gameplay de una copia no oficial viola ToS de EA y puede traer strikes de copyright en YouTube. Riesgo real a evaluar antes de la Fase 3.
- Alternativa legítima a evaluar en paralelo: Sims 3 suele estar muy barato en ventas de Steam/EA App; comprarlo elimina el riesgo de strike por unos pesos. Decisión de negocio de Chaman, no bloquea Fase 0-2 (desarrollo local).
- Los mods/script mods funcionan igual en copia no oficial si la versión matchea (1.67 es la versión estándar de la escena modding).
