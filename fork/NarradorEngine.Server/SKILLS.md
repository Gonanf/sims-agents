# SKILLS - NarradorEngine.Server

Agent-facing technical context for the external server. The public overview stays in [../README.md](../README.md), while this file keeps the lower-level server details that do not belong in the main landing page.

## Responsibilities

- Read [../NarradorPorEventos.config.json](../NarradorPorEventos.config.json) and resolve runtime paths.
- Process queued narrative requests in batches.
- Generate responses through Ollama's `/api/generate` endpoint using `HttpClient`.
- Apply separate prompt templates for `pensamento`, `conto`, and profile calibration.
- Write responses in the JSON contract expected by the TS3 mod.
- Purge processed requests to avoid replay.
- Refresh `NarradorPorEventos.perfil.usuario.json` with the active prompt and calibrated profile guideline.

## Runtime Snapshot

- Platform: `.NET 8`
- CLI entry points: `--server`, `--simulate`, `--config=`
- Config reload policy: once per polling cycle
- Request file behavior: clear after processing

## Prompt Assembly Notes

Templates live under these config branches:

- `prompt.contexto.template`
- `prompt.pensamento.template`
- `prompt.conto.template`
- `prompt.perfil.template_geracao`
- `prompt.perfil.template_fallback`
- `prompt.variaveis.*`

Key runtime placeholders include:

- `{sim_ativo}`
- `{contexto}`
- `{bloco_contextual}`
- `{diretriz_perfil}`
- `{diretriz_perfil_formatada}`
- `{foco_emocional}`
- `{foco_emocional_formatado}`
- `{diretriz_por_tracos}`
- `{diretriz_usuario}`
- `{diretriz_usuario_formatada}`
- `{diretriz_faixa_etaria}`
- `{diretriz_faixa_etaria_formatada}`
- `{personalidades_narrador}`
- `{estilos_criativos}`
- `{conteudos_permitidos}`
- `{conteudos_bloqueados}`

`prompt.variaveis.*` is merged with the runtime placeholders and acts as the configurable base for tone, labels, and reusable instructions.

## Shared Contract Summary

Envelope fields:

- `versao_contrato`
- `pedidos[]` or `respostas[]`

Per-item fields:

- `id`
- `tipo`
- `sim_ativo`
- `horario_real`
- `contexto` on requests
- `resposta` on responses

Definitions live in [Contratos/ContratosNarrativos.cs](Contratos/ContratosNarrativos.cs).

## Path Rules

- The mod and server share the same config, but the server can use modern `System.IO` because it runs outside the TS3 process.
- If `diretorio.documentos_mod` points to `...\Mods\Packages`, the server must still write requests and responses to `...\Mods`.
- If files are unexpectedly landing at the root `Mods` directory, first verify that `NarradorPorEventos.config.json` is present where the mod expects it.
