# Repository Tooling

This directory contains the local entry points for building, packaging, synchronizing, running, testing, and maintaining the mod.

## Configuration

Base file: [Configuracao/Ferramentas.config.json](Configuracao/Ferramentas.config.json)

Main configurable values:

- `ts3.raiz_mods`: root of the player's The Sims 3 `Mods` folder.
- `ts3.raiz_cache`: root used by local cache-cleaning routines.
- `ts3.caminho_executavel_jogo`: accepts either the `Game/Bin` folder or the full `TS3W.exe` path; if not found, the full-flow script tries known default locations (`Electronic Arts`, `Origin Games`, and `Steam`).
- `ts3.argumentos_execucao_jogo`: optional arguments passed when starting `TS3W.exe`.
- `mod.caminho_relativo_dll`: mod DLL to publish into the package.
- `mod.caminho_relativo_config`: shared config file used by the mod and the server.
- `pacote_mod.nome_arquivo`: final `.package` file that receives the compiled DLL.
- `pacote_mod.tipo_recurso`, `grupo_recurso`, `instancia_recurso`: TGI of the S3SA resource that gets replaced.
- `ollama.caminho_executavel`: local executable used when the full-flow script needs to start `ollama serve`.
- `ollama.timeout_inicializacao_segundos`: timeout while waiting for Ollama to answer on the port configured in [../NarradorPorEventos.config.json](../NarradorPorEventos.config.json).
- `servidor.caminho_relativo_projeto`: relative path to the external .NET server project.
- `servidor.timeout_inicializacao_segundos`: timeout while waiting for the external server startup banner.

The resolver still accepts older English keys only for backward compatibility with an existing `Ferramentas.local.json`.

Ollama host and port still come from [../NarradorPorEventos.config.json](../NarradorPorEventos.config.json) so the mod, server, and automation scripts share the same runtime source of truth.

Optional local override:

1. Copy [Configuracao/Ferramentas.local.json.example](Configuracao/Ferramentas.local.json.example).
2. Rename it to `Ferramentas.local.json`.
3. Change only the machine-specific values you need.

## Automation Scripts

- [Automacoes/sincronizar_config_mod.bat](Automacoes/sincronizar_config_mod.bat): simple wrapper that syncs `NarradorPorEventos.config.json` into the game's `Mods` folder.
- [Automacoes/sincronizar_config_mod.ps1](Automacoes/sincronizar_config_mod.ps1): implementation that reads tooling config, copies the mod config, and ensures the configured narrative directory exists.
- [Automacoes/atualizar_package_mod.bat](Automacoes/atualizar_package_mod.bat): simple wrapper that publishes the current DLL into the configured package after clearing the five main TS3 cache files.
- [Automacoes/atualizar_package_mod.ps1](Automacoes/atualizar_package_mod.ps1): configurable wrapper that resolves paths, clears the main game caches, and only then calls the generic package-publish routine.
- [Automacoes/atualizar_package_s3sa.ps1](Automacoes/atualizar_package_s3sa.ps1): low-level generic routine that replaces an S3SA resource inside a `.package` through `s3pi`.

## Build

- [Build/compilar_mod.ps1](Build/compilar_mod.ps1): builds the TS3 project with MSBuild without depending on the inline VS Code task command.

## Execution

- [Execucao/rodar_servidor.bat](Execucao/rodar_servidor.bat): starts the narrative server in continuous mode.
- [Execucao/rodar_servidor_e_ollama.bat](Execucao/rodar_servidor_e_ollama.bat): starts the narrative server in continuous mode and guarantees a local `ollama serve` for the URL configured in [../NarradorPorEventos.config.json](../NarradorPorEventos.config.json).
- [Execucao/simular_servidor.bat](Execucao/simular_servidor.bat): runs the server once in simulation mode.
- [Execucao/executar_servidor.ps1](Execucao/executar_servidor.ps1): shared implementation for both server modes, for the background start used by the full workflow, and for the optional Ollama bootstrap reused by the simple server+Ollama entry point; when starting continuous mode, it stops any previous narrative server instance first to avoid stale binaries and orphan processes.
- [Execucao/encerrar_processos_narrativos.bat](Execucao/encerrar_processos_narrativos.bat): simple wrapper that stops the narrative server and, optionally, the local `ollama.exe` used by the workflow.
- [Execucao/encerrar_processos_narrativos.ps1](Execucao/encerrar_processos_narrativos.ps1): PowerShell routine that explicitly stops the local narrative processes without requiring manual PID lookup.
- [Execucao/ProcessosNarrativos.ps1](Execucao/ProcessosNarrativos.ps1): shared utility for locating, stopping, and ensuring startup of the narrative server and the local Ollama process.
- [Execucao/rodar_fluxo_completo.bat](Execucao/rodar_fluxo_completo.bat): full feedback-driven workflow that rebuilds the x86 mod, syncs config, publishes the package, rebuilds or restarts the server, stops previous local Ollama processes, ensures `ollama serve`, and opens `TS3W.exe`.
- [Execucao/executar_fluxo_completo.ps1](Execucao/executar_fluxo_completo.ps1): PowerShell orchestrator for the full workflow, reusing the central tooling config and the shared mod config.

## Tests

- [Testes/validar_servidor_limpo.ps1](Testes/validar_servidor_limpo.ps1): copies `NarradorEngine.Server` and `NarradorEngine.Server.Tests` into a temporary directory without `bin/obj`, rebuilds there, and runs the xUnit suite without suffering from executable locks in the workspace.

## Maintenance

- [Manutencao/limpar_cache.bat](Manutencao/limpar_cache.bat): clears local workspace and Visual Studio caches using the current repository root instead of a user-specific hardcoded path.
