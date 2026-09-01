# VS Code Setup

Este workspace foi configurado para dois alvos diferentes:

- mod legado em .NET Framework 2.0 via MSBuild
- servidor externo em .NET 8.0 via dotnet SDK

## O que ja foi configurado

- [.vscode/tasks.json](.vscode/tasks.json) com build, testes rápidos do servidor, cobertura e validação em cópia limpa
- [.vscode/launch.json](.vscode/launch.json) com debug do servidor em modo contínuo/simulação, attach ao servidor e attach ao processo do The Sims 3
- [.vscode/settings.json](.vscode/settings.json) apontando a solution e forçando OmniSharp para melhor compatibilidade com projeto legado
- [ZZZZitalo.TS3Mods.NarradorPorEventos.csproj](ZZZZitalo.TS3Mods.NarradorPorEventos.csproj) ajustado para usar `mscorlib.dll` da pasta `Documents\\Electronic Arts\\ReferenceAssemblies`

## Instalar dependencias pelo terminal

Abra um PowerShell normal e rode:

```powershell
winget install --id Microsoft.DotNet.SDK.8 -e --source winget --silent --accept-source-agreements --accept-package-agreements
winget install --id Microsoft.VisualStudio.2022.BuildTools -e --source winget --silent --accept-source-agreements --accept-package-agreements --override "--quiet --wait --norestart --add Microsoft.VisualStudio.Workload.ManagedDesktopBuildTools --add Microsoft.Net.Component.3.5.DeveloperTools --includeRecommended"
```

O segundo comando instala:

- `MSBuild`
- workload `Microsoft.VisualStudio.Workload.ManagedDesktopBuildTools`
- componente `Microsoft.Net.Component.3.5.DeveloperTools`

Esse componente de 3.5 e o que cobre os reference assemblies antigos usados pelo `TargetFrameworkVersion v2.0`.

## Extensoes do VS Code

Instale as recomendadas quando o editor pedir:

- `ms-dotnettools.csharp`
- `ms-dotnettools.csdevkit`

## Como usar

### Build rapido

- `Ctrl+Shift+B` roda `compilar: workspace debug`
- `Terminal > Run Task > compilar: mod debug x86` compila so a DLL do mod
- `Terminal > Run Task > sincronizar: package do mod` publica a DLL atual no package configurado em `Ferramentas/Configuracao/Ferramentas.config.json`, comentando o package antigo com extensao `._package` e limpando antes os 5 caches principais do TS3
- `Terminal > Run Task > compilar: package do mod` compila a DLL do mod e publica o package em seguida, com a mesma limpeza automatica dos caches do jogo
- `Terminal > Run Task > compilar: servidor debug` compila so o servidor
- `Terminal > Run Task > testar: servidor debug` roda a suíte xUnit do servidor direto do workspace
- `Terminal > Run Task > testar: servidor cobertura` roda a suíte xUnit com coleta `XPlat Code Coverage`
- `Terminal > Run Task > validar: servidor em cópia limpa` valida build e testes do servidor em cópia temporária sem lock de binário
- `Terminal > Run Task > sincronizar: config do mod` copia a config do repo para a pasta `Mods` usada pelo TS3
- `Terminal > Run Task > executar: servidor` sobe o servidor da raiz do repo sem puxar o projeto legado
- `Terminal > Run Task > executar: servidor e ollama` sobe o servidor e garante o `ollama serve` local sem recompilar, sincronizar config nem atualizar package
- `Terminal > Run Task > executar: simulacao do servidor` roda a simulacao uma vez

### Debug do servidor

- `F5`
- escolha `Server .NET 8 (servidor)` para loop contínuo ou `Server .NET 8 (simulação)` para uma rodada única
- se o servidor já estiver rodando por task, use `Attach ao servidor .NET 8 em execução`
- alternativa fora do debugger: rode [Ferramentas/Execucao/rodar_servidor.bat](Ferramentas/Execucao/rodar_servidor.bat)

### Debug dos testes do servidor

1. Abra a aba `Testing` do VS Code.
2. Coloque breakpoints no teste ou na classe do servidor que deseja inspecionar.
3. Clique no ícone de gutter do teste ou no comando `Debug Test`.
4. O workspace está configurado com `testing.defaultGutterClickAction = debug`, então o clique no gutter prioriza depuração em vez de execução simples.

Quando o binário do servidor estiver bloqueado por um processo já em execução, use primeiro `validar: servidor em cópia limpa` para confirmar que a suíte continua saudável sem depender do diretório `bin` do workspace.

### Debug do mod no The Sims 3

1. Rode `compilar: mod debug x86`.
2. Garanta que a DLL e o PDB dessa build foram copiados para o local realmente carregado pelo jogo.
3. Rode `sincronizar: config do mod` uma vez para colocar `NarradorPorEventos.config.json` em `Documents\\Electronic Arts\\The Sims 3\\Mods`.
4. Abra o jogo e entre em um mundo salvo. O attach fica bem mais previsivel depois que o runtime do jogo e o mod ja foram carregados.
5. No VS Code, abra `Run and Debug`.
6. Escolha `Attach ao TS3 (.NET Framework 2.0)`.
7. Quando a lista de processos abrir, escolha o executavel real do jogo, nao o launcher. Em geral sera o processo com mais memoria e com a janela do jogo aberta.
8. Depois do attach, acione um fluxo simples do mod para testar breakpoint. O ponto mais facil costuma ser um metodo frequentemente chamado pelo fluxo narrativo, nao algo que so roda no boot do mundo.

### Como saber se o attach esta certo

- breakpoint vermelho cheio: simbolos carregados e arquivo fonte compatível com o PDB
- breakpoint vazado ou cinza: o jogo carregou outra DLL, outro PDB, ou uma build diferente da sua
- attach sem breakpoint nunca disparar: voce anexou no processo errado, o mod nao foi carregado, ou o evento testado nao aconteceu

### Checklist rapido de attach

1. Confirmar timestamp da DLL e do PDB que foram parar no local usado pelo jogo.
2. Confirmar que o processo escolhido e o do jogo, nao o launcher.
3. Confirmar que o mundo ja terminou de carregar antes do attach.
4. Testar primeiro um breakpoint em um trecho de execucao frequente.
5. Se o breakpoint ficar vazado, refazer a copia da DLL/PDB e anexar de novo.

## Build output vs arquivos narrativos

- a DLL do mod continua saindo em `bin\\x86\\Debug`
- os arquivos narrativos (`estado`, `pedidos`, `respostas`, `logs`) sao gravados em runtime pelo mod e pelo servidor
- se a config do mod nao estiver em `Documents\\Electronic Arts\\The Sims 3\\Mods\\NarradorPorEventos.config.json`, o mod cai no padrao de `UserModDirectory` e grava direto em `...\\The Sims 3\\Mods`
- por isso existe [Ferramentas/Automacoes/sincronizar_config_mod.bat](Ferramentas/Automacoes/sincronizar_config_mod.bat): ele sincroniza a config do repo com a pasta lida pelo jogo
- os caminhos e nomes finais usados pelas ferramentas ficam centralizados em [Ferramentas/Configuracao/Ferramentas.config.json](Ferramentas/Configuracao/Ferramentas.config.json)
- customizacoes locais nao versionadas podem ficar em `Ferramentas/Configuracao/Ferramentas.local.json`

## Pre-requisitos que este repo espera

- `C:\Users\\<seu-usuario>\\Documents\\Electronic Arts\\ReferenceAssemblies` com as DLLs do TS3
- `mscorlib.dll` tambem nessa mesma pasta
- SDK do .NET 8 instalado de verdade, nao apenas runtime
- `NarradorPorEventos.config.json` copiado para `Documents\\Electronic Arts\\The Sims 3\\Mods\\NarradorPorEventos.config.json` se voce quiser que o mod respeite `diretorio.documentos_mod`
- [Ferramentas/README.md](Ferramentas/README.md) descreve os wrappers `.bat`, os scripts `.ps1` e a configuracao dedicada das ferramentas
- [Ferramentas/Testes/validar_servidor_limpo.ps1](Ferramentas/Testes/validar_servidor_limpo.ps1) encapsula a validação do servidor em cópia temporária limpa

## Rodar o servidor do jeito certo

Da raiz do repo, use uma destas opcoes:

```powershell
dotnet run --project .\NarradorEngine.Server\NarradorEngine.Server.csproj -- --server
dotnet run --project .\NarradorEngine.Server\NarradorEngine.Server.csproj -- --simulate
```

Ou use os atalhos:

- [Ferramentas/Execucao/rodar_servidor.bat](Ferramentas/Execucao/rodar_servidor.bat)
- [Ferramentas/Execucao/rodar_servidor_e_ollama.bat](Ferramentas/Execucao/rodar_servidor_e_ollama.bat)
- [Ferramentas/Execucao/simular_servidor.bat](Ferramentas/Execucao/simular_servidor.bat)

Nao use `dotnet run -- --server` na raiz do repo. Nessa pasta existe uma solution com o projeto legado `net20`, e o CLI pode tentar avaliar a solution inteira, bater no projeto TS3 e disparar `MSB3644`.

## Validacao rapida

Depois da instalacao, estes comandos precisam funcionar:

```powershell
dotnet --list-sdks
& "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -products * -find MSBuild\**\Bin\MSBuild.exe
```

Se `dotnet --list-sdks` voltar vazio, voce tem runtime sem SDK.
Se o `vswhere` nao achar `MSBuild.exe`, o Build Tools nao terminou de instalar.

Se `dotnet run -- --server` acusar `MSB3644` do projeto `v2.0`, o problema nao e o servidor: o comando foi executado da pasta errada ou sem `--project`.
