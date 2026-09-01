# SKILLS - NarradorPorEventos

Agent-facing technical context for the root repository. The public overview, player setup, and portfolio-style explanation live in [README.md](README.md). This file keeps the lower-level constraints and search anchors out of the public landing page.

## Read Order

1. Start with [README.md](README.md), especially the "Quick Repository Navigation (formerly \"Navegacao rapida do repositorio\")" section.
2. For mod runtime flow, follow [GerenciadorPrincipalModNarracaoPorEventos.cs](GerenciadorPrincipalModNarracaoPorEventos.cs) -> [ServicosDoMod/Fila/ControladorFilaEventosNarrativos.cs](ServicosDoMod/Fila/ControladorFilaEventosNarrativos.cs) -> [NucleoNarrativo/MotorNarrativo.cs](NucleoNarrativo/MotorNarrativo.cs) -> [NucleoNarrativo/EscritorEstadosNarrativos.cs](NucleoNarrativo/EscritorEstadosNarrativos.cs).
3. For server flow, follow [NarradorEngine.Server/Program.cs](NarradorEngine.Server/Program.cs) -> [NarradorEngine.Server/Processamento/LoopServidor.cs](NarradorEngine.Server/Processamento/LoopServidor.cs) -> [NarradorEngine.Server/Processamento/ProcessadorPedidosNarrativos.cs](NarradorEngine.Server/Processamento/ProcessadorPedidosNarrativos.cs) -> [NarradorEngine.Server/Servicos/OllamaService.cs](NarradorEngine.Server/Servicos/OllamaService.cs).

## Core Responsibilities

- Capture and type raw TS3 gameplay events.
- Build narrative context from Sim, family, lot, and world queries.
- Trigger `pensamento` and `conto` requests from accumulated event batches.
- Persist narrative requests, responses, previous context, and state snapshots.
- Consume generated responses and surface them in the TS3 UI.
- Record diagnostics through the mod adapters and narrative logs.

## Runtime Snapshot

- Mod platform: `.NET Framework 2.0`
- Game/runtime: `The Sims 3` + `S3SE`
- External runtime: [.NET 8 server](NarradorEngine.Server/README.md)
- Shared configuration: [NarradorPorEventos.config.json](NarradorPorEventos.config.json)
- File handoff: `NarradorPorEventos.pedidos.json` -> external processing -> `NarradorPorEventos.respostas.json`

## Hard Constraints

- Inside the TS3 mod, file I/O must continue to use S3SE/BatteryUtils. Do not replace it with `System.IO`.
- The external server is intentionally separate so modern dependencies stay outside the legacy game runtime.
- `RepositorioEventosTheSims3` registers events through concrete subclasses of `EventoTheSims3`.
- `RepositorioConsulta` should contain only `RepoConsulta.cs` and `Consulta*.cs` files.
- Requests and responses belong under the `Mods` directory, not `Mods/Packages`.
- Shared configuration should stay centralized in [NarradorPorEventos.config.json](NarradorPorEventos.config.json) whenever possible.
- Player-facing documentation belongs in [README.md](README.md); low-level implementation notes belong here or in the server/tooling docs.

## Search Anchors

- TS3 listener registration: [GerenciadorPrincipalModNarracaoPorEventos.cs](GerenciadorPrincipalModNarracaoPorEventos.cs)
- Event catalog and concrete type resolution: [ServicosDoMod/Eventos/RepositorioEventosTheSims3.cs](ServicosDoMod/Eventos/RepositorioEventosTheSims3.cs), [ServicosDoMod/Eventos/CatalogoEventos.cs](ServicosDoMod/Eventos/CatalogoEventos.cs)
- Queue recurrence policy: [NucleoNarrativo/PoliticaFilaEventosNarrativos.cs](NucleoNarrativo/PoliticaFilaEventosNarrativos.cs)
- Narrative orchestration: [NucleoNarrativo/MotorNarrativo.cs](NucleoNarrativo/MotorNarrativo.cs)
- State snapshot writer: [NucleoNarrativo/EscritorEstadosNarrativos.cs](NucleoNarrativo/EscritorEstadosNarrativos.cs)
- LLM/context assembly: [ServicosDoMod/Contexto/ContextoParaLLM.cs](ServicosDoMod/Contexto/ContextoParaLLM.cs)
- Shared JSON contract: [NarradorEngine.Server/Contratos/ContratosNarrativos.cs](NarradorEngine.Server/Contratos/ContratosNarrativos.cs)
- Mod-side diagnostic adapters: [Infraestrutura/Adaptadores](Infraestrutura/Adaptadores)

## Documentation Map

- Public overview and player guidance: [README.md](README.md)
- External server runtime: [NarradorEngine.Server/README.md](NarradorEngine.Server/README.md)
- Local scripts and automation: [Ferramentas/README.md](Ferramentas/README.md)
- TS3-side sanity checks: [TestesDoMod/README.md](TestesDoMod/README.md)
- Server-specific technical index: [NarradorEngine.Server/SKILLS.md](NarradorEngine.Server/SKILLS.md)

## Local Tasks and Scripts

- Build TS3 mod: VS Code task `compilar: mod debug x86` or [Ferramentas/Build/compilar_mod.ps1](Ferramentas/Build/compilar_mod.ps1)
- Build server: VS Code task `compilar: servidor debug`
- Test server: VS Code task `testar: servidor debug`
- Sync mod config: VS Code task `sincronizar: config do mod`
- Publish package: VS Code task `compilar: package do mod`
- Run server: VS Code task `executar: servidor` or [Ferramentas/Execucao/rodar_servidor.bat](Ferramentas/Execucao/rodar_servidor.bat)
- Run server and guarantee local Ollama: VS Code task `executar: servidor e ollama` or [Ferramentas/Execucao/rodar_servidor_e_ollama.bat](Ferramentas/Execucao/rodar_servidor_e_ollama.bat)
