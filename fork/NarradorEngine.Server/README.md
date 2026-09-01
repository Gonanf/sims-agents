# NarradorEngine.Server

External `.NET 8` service that reads `NarradorPorEventos.pedidos.json`, generates narrative text through Ollama, and writes `NarradorPorEventos.respostas.json` for the TS3 mod to consume.

The public project overview, player setup, and architecture summary live in [../README.md](../README.md). This file focuses on server runtime behavior.

## Run Modes

- `--server`: continuous polling loop with request purging after each processing cycle.
- `--simulate`: one-shot run that creates representative `pensamento` and `conto` requests from existing state and log files, then prints diagnostics.

## Commands

From the `NarradorEngine.Server` directory:

- `dotnet run -- --server`
- `dotnet run -- --simulate`
- `dotnet run -- --server --config="C:\path\NarradorPorEventos.config.json"`

From the repository root:

- `dotnet run --project .\NarradorEngine.Server\NarradorEngine.Server.csproj -- --server`
- `dotnet run --project .\NarradorEngine.Server\NarradorEngine.Server.csproj -- --simulate`
- [../Ferramentas/Execucao/rodar_servidor.bat](../Ferramentas/Execucao/rodar_servidor.bat)
- [../Ferramentas/Execucao/rodar_servidor_e_ollama.bat](../Ferramentas/Execucao/rodar_servidor_e_ollama.bat)

Do not run `dotnet run -- --server` from the repository root. Because the root also contains the legacy `net20` TS3 project, the CLI may try to evaluate that project and fail with `MSB3644`.

## What the Server Owns

- Read the shared config and resolve runtime paths.
- Rebuild prompts from the latest config on each polling cycle.
- Calibrate the narrative profile from `perfil_usuario.*` settings.
- Call Ollama through `HttpClient`.
- Write responses in the JSON contract expected by the TS3 mod.
- Purge processed requests so they are not replayed.

## Prompting Model

- `pensamento`: short, first-person, emotionally immediate output for the active Sim.
- `conto`: short narrated scene with a stronger social or world-facing angle.

The actual templates live in `NarradorPorEventos.config.json`, so tone and prompt wording can change without recompiling the server.

## Shared Config and Hot Reload

The authoritative explanation of the shared config file lives in [../README.md](../README.md). Server-specific behavior is summarized here:

- the server reloads `NarradorPorEventos.config.json` every polling cycle using `servidor.intervalo_poll_ms`;
- `feature.incluir_contexto_previo` decides whether previous narrative memory enters the prompt;
- `perfil_usuario.diretriz` changes the profile-calibration prompt and takes effect on the next poll;
- `prompt.*` controls prompt assembly;
- `ollama.*` changes model, timeout, and generation options on the next cycle.

The generated profile file, `NarradorPorEventos.perfil.usuario.json`, is refreshed by the server with the prompt used for calibration and the active narrative guideline derived from the current config.

For low-level placeholder details and prompt-variable notes, see [SKILLS.md](SKILLS.md).

## JSON Contract Summary

Requests and responses use the same logical envelope:

- requests: `versao_contrato` + `pedidos[]`
- responses: `versao_contrato` + `respostas[]`

Per-item fields:

- `id`
- `tipo` (`pensamento` or `conto`)
- `sim_ativo`
- `horario_real`
- `contexto` on requests / `resposta` on responses

The DTO definitions live in [Contratos/ContratosNarrativos.cs](Contratos/ContratosNarrativos.cs).

## Runtime File Behavior

After each cycle, the server clears the request file to avoid duplicate processing.

When `diretorio.documentos_mod` resolves inside `...\Mods\Packages`, the server intentionally writes requests and responses to `...\Mods`, not to `Packages`.

If narrative files are appearing directly under `...\The Sims 3\Mods` instead of `...\Mods\NarradorPorEventos`, the usual cause is a missing mod config file at `...\Mods\NarradorPorEventos.config.json`.

## Validation Note

If a running server instance keeps binaries locked and blocks `dotnet build` or `dotnet test`, use [../Ferramentas/Testes/validar_servidor_limpo.ps1](../Ferramentas/Testes/validar_servidor_limpo.ps1). That script copies the server projects into a clean temporary directory and runs validation there.
