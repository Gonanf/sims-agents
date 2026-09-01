[CmdletBinding()]
param(
    [string]$RepoRoot,
    [string]$Configuration = 'Debug',
    [string]$Platform = 'x86'
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
    $RepoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
}

. (Join-Path $PSScriptRoot '..\Configuracao\ResolverConfiguracaoFerramentas.ps1')
. (Join-Path $PSScriptRoot 'ProcessosNarrativos.ps1')

$script:TotalEtapas = 10
$script:EtapaAtual = 0

function Write-Etapa {
    param([string]$Mensagem)

    $script:EtapaAtual++
    Write-Host ('[{0}/{1}] {2}' -f $script:EtapaAtual, $script:TotalEtapas, $Mensagem) -ForegroundColor Cyan
}

function Write-Info {
    param([string]$Mensagem)

    Write-Host ('    ' + $Mensagem) -ForegroundColor DarkGray
}

function Invoke-ProgramaExterno {
    param(
        [string]$Titulo,
        [string]$Arquivo,
        [string[]]$Argumentos,
        [string]$DiretorioTrabalho
    )

    $moveuDiretorio = $false
    try {
        if (-not [string]::IsNullOrWhiteSpace($DiretorioTrabalho)) {
            Push-Location $DiretorioTrabalho
            $moveuDiretorio = $true
        }

        & $Arquivo @Argumentos
        $exitCode = $LASTEXITCODE
    }
    finally {
        if ($moveuDiretorio) {
            Pop-Location
        }
    }

    if ($exitCode -ne 0) {
        throw ('Falha em ' + $Titulo + ' com exit code ' + $exitCode + '.')
    }
}

function Invoke-ScriptPowerShell {
    param(
        [string]$Titulo,
        [string]$ScriptPath,
        [string[]]$Argumentos,
        [string]$DiretorioTrabalho
    )

    $argumentosPowerShell = @(
        '-NoProfile',
        '-ExecutionPolicy',
        'Bypass',
        '-File',
        $ScriptPath
    ) + $Argumentos

    Invoke-ProgramaExterno -Titulo $Titulo -Arquivo 'powershell.exe' -Argumentos $argumentosPowerShell -DiretorioTrabalho $DiretorioTrabalho
}

function Resolver-CandidatoTs3 {
    param([string]$Caminho)

    $expandido = [Environment]::ExpandEnvironmentVariables($Caminho)
    if ([string]::IsNullOrWhiteSpace($expandido)) {
        return [string]::Empty
    }

    if ([string]::Equals([System.IO.Path]::GetExtension($expandido), '.exe', [System.StringComparison]::OrdinalIgnoreCase)) {
        return $expandido
    }

    return Join-Path $expandido 'TS3W.exe'
}

function Resolver-ExecutavelTs3 {
    param([string]$Configurado)

    $candidatos = @()

    if (-not [string]::IsNullOrWhiteSpace($Configurado)) {
        $candidatos += $Configurado
    }

    $candidatos += @(
        '%ProgramFiles(x86)%\\Electronic Arts\\The Sims 3\\Game\\Bin',
        '%ProgramFiles(x86)%\\Origin Games\\The Sims 3\\Game\\Bin',
        '%ProgramFiles(x86)%\\Steam\\steamapps\\common\\The Sims 3\\Game\\Bin',
        '%ProgramW6432%\\Electronic Arts\\The Sims 3\\Game\\Bin',
        '%ProgramW6432%\\Origin Games\\The Sims 3\\Game\\Bin',
        '%ProgramW6432%\\Steam\\steamapps\\common\\The Sims 3\\Game\\Bin',
        '%ProgramFiles%\\Electronic Arts\\The Sims 3\\Game\\Bin',
        '%ProgramFiles%\\Origin Games\\The Sims 3\\Game\\Bin',
        '%ProgramFiles%\\Steam\\steamapps\\common\\The Sims 3\\Game\\Bin'
    )

    $verificados = @()

    foreach ($candidato in $candidatos) {
        $executavelCandidato = Resolver-CandidatoTs3 -Caminho $candidato
        if ([string]::IsNullOrWhiteSpace($executavelCandidato)) {
            continue
        }

        $verificados += $executavelCandidato

        if (Test-Path $executavelCandidato) {
            return (Resolve-Path $executavelCandidato).Path
        }
    }

    throw ('TS3W.exe nao encontrado. Ajuste ts3.caminho_executavel_jogo para a pasta Game\\Bin ou para o caminho completo do executavel em Ferramentas.local.json. Caminhos verificados: ' + ($verificados -join '; '))
}

function Encerrar-ServidorNarrativoExistente {
    $processos = @(Stop-ProcessosServidorNarrativo)
    if ($processos.Count -eq 0) {
        Write-Info 'nenhum servidor narrativo anterior em execucao.'
        return
    }

    foreach ($processo in $processos) {
        Stop-Process -Id $processo.ProcessId -Force -ErrorAction Stop
        Write-Info ('servidor anterior encerrado: PID ' + $processo.ProcessId)
    }
}

function Encerrar-OllamaLocalExistente {
    param([string]$UrlOllama)

    if (-not (Testar-HostLocal -Url $UrlOllama)) {
        Write-Info 'host do Ollama nao eh local; nenhuma instancia local anterior sera encerrada.'
        return
    }

    $processos = @(Stop-ProcessosOllamaLocal)
    if ($processos.Count -eq 0) {
        Write-Info 'nenhuma instancia local anterior do Ollama em execucao.'
        return
    }

    foreach ($processo in $processos) {
        Write-Info ('Ollama anterior encerrado: PID ' + $processo.ProcessId)
    }
}

function Abrir-JogoTs3 {
    param(
        [string]$ExecutavelTs3,
        [string]$Argumentos
    )

    $processoExistente = Get-Process -Name 'TS3W' -ErrorAction SilentlyContinue | Select-Object -First 1
    if ($processoExistente -ne $null) {
        Write-Info ('TS3W.exe ja esta em execucao com PID ' + $processoExistente.Id)
        return
    }

    $opcoes = @{
        FilePath = $ExecutavelTs3
        WorkingDirectory = Split-Path -Parent $ExecutavelTs3
        PassThru = $true
    }

    if (-not [string]::IsNullOrWhiteSpace($Argumentos)) {
        $opcoes['ArgumentList'] = $Argumentos
    }

    $processoJogo = Start-Process @opcoes
    Write-Info ('TS3 iniciado com PID ' + $processoJogo.Id)
}

$repoNormalizado = (Resolve-Path $RepoRoot).Path
$config = Obter-ConfiguracaoFerramentas -RaizRepositorio $repoNormalizado
$caminhoConfigAtiva = Obter-CaminhoConfigModAtiva -ConfigFerramentas $config
$configMod = Obter-ConfiguracaoCompartilhadaDoMod -ConfigPath $caminhoConfigAtiva
$urlOllama = Obter-UrlOllama -ConfigMod $configMod
$urlSaudeOllama = Obter-UrlSaudeOllama -UrlGeracao $urlOllama
$executavelTs3 = Resolver-ExecutavelTs3 -Configurado $config.Paths.Ts3GameExecutablePath

Write-Etapa 'Preflight das configuracoes locais e caminhos resolvidos'
Write-Info ('repo: ' + $repoNormalizado)
Write-Info ('dll do mod: ' + $config.Paths.ModDllPath)
Write-Info ('config fonte do repo: ' + $config.Paths.ModConfigPath)
Write-Info ('config ativa em Mods: ' + $config.Paths.ModRuntimeConfigPath)
Write-Info ('package: ' + $config.Paths.PackagePath)
Write-Info ('projeto do servidor: ' + $config.Paths.ServerProjectPath)
Write-Info ('TS3W.exe: ' + $executavelTs3)
Write-Info ('Ollama url: ' + $urlOllama)
Write-Info ('Ollama healthcheck: ' + $urlSaudeOllama)

Write-Etapa 'Compilar DLL x86 do mod'
Invoke-ScriptPowerShell -Titulo 'compilar o mod TS3 x86' -ScriptPath (Join-Path $repoNormalizado 'Ferramentas\Build\compilar_mod.ps1') -Argumentos @('-RepoRoot', $repoNormalizado, '-Configuration', $Configuration, '-Platform', $Platform) -DiretorioTrabalho $repoNormalizado

Write-Etapa 'Sincronizar NarradorPorEventos.config.json na pasta Mods'
Invoke-ScriptPowerShell -Titulo 'sincronizar config do mod' -ScriptPath (Join-Path $repoNormalizado 'Ferramentas\Automacoes\sincronizar_config_mod.ps1') -Argumentos @('-RepoRoot', $repoNormalizado) -DiretorioTrabalho $repoNormalizado

Write-Etapa 'Atualizar o package do mod com a DLL recem-compilada'
Invoke-ScriptPowerShell -Titulo 'atualizar package do mod' -ScriptPath (Join-Path $repoNormalizado 'Ferramentas\Automacoes\atualizar_package_mod.ps1') -Argumentos @('-RepoRoot', $repoNormalizado) -DiretorioTrabalho $repoNormalizado

Write-Etapa 'Encerrar servidor narrativo anterior para evitar binario desatualizado'
Encerrar-ServidorNarrativoExistente

Write-Etapa 'Compilar o servidor externo em modo Debug'
Invoke-ProgramaExterno -Titulo 'compilar o servidor externo' -Arquivo 'dotnet' -Argumentos @('build', $config.Paths.ServerProjectPath, '-c', $Configuration, '/property:GenerateFullPaths=true', '/consoleloggerparameters:NoSummary') -DiretorioTrabalho $config.Paths.ServerProjectDirectory

Write-Etapa 'Encerrar instancias locais anteriores do Ollama para subir limpo'
Encerrar-OllamaLocalExistente -UrlOllama $urlOllama

Write-Etapa 'Garantir que o Ollama esteja respondendo na porta configurada'
Garantir-OllamaEmExecucao -UrlOllama $urlOllama -ExecutavelConfigurado $config.Paths.OllamaExecutablePath -TimeoutSegundos $config.Runtime.OllamaStartupTimeoutSeconds

Write-Etapa 'Iniciar o servidor narrativo em background'
Invoke-ScriptPowerShell -Titulo 'iniciar o servidor narrativo em background' -ScriptPath (Join-Path $PSScriptRoot 'executar_servidor.ps1') -Argumentos @('-Modo', 'server', '-RepoRoot', $repoNormalizado, '-SemBuild', '-EmSegundoPlano', '-AguardarPronto', '-TimeoutInicializacaoSegundos', $config.Runtime.ServerStartupTimeoutSeconds) -DiretorioTrabalho $repoNormalizado

Write-Etapa 'Abrir o The Sims 3 pelo TS3W.exe configurado'
Abrir-JogoTs3 -ExecutavelTs3 $executavelTs3 -Argumentos $config.Runtime.Ts3GameLaunchArguments

Write-Host 'Fluxo completo concluido.' -ForegroundColor Green