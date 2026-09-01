[CmdletBinding()]
param(
    [ValidateSet('server', 'simulate')]
    [string]$Modo = 'server',
    [string]$RepoRoot,
    [switch]$IncluirOllama,
    [switch]$SemBuild,
    [switch]$EmSegundoPlano,
    [switch]$AguardarPronto,
    [int]$TimeoutInicializacaoSegundos = 20,
    [string]$DiretorioLogs
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
    $RepoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
}

. (Join-Path $PSScriptRoot '..\Configuracao\ResolverConfiguracaoFerramentas.ps1')
. (Join-Path $PSScriptRoot 'ProcessosNarrativos.ps1')

function Obter-ResumoArquivo {
    param([string]$Caminho)

    if (-not (Test-Path $Caminho)) {
        return [string]::Empty
    }

    return (Get-Content -Path $Caminho -Tail 20 -ErrorAction SilentlyContinue) -join [Environment]::NewLine
}

function Iniciar-ServidorEmSegundoPlano {
    param(
        [string]$RepoRootNormalizado,
        [string]$ModoExecucao,
        [switch]$PularBuild,
        [int]$TimeoutSegundos,
        [string]$DiretorioLogsConfigurado,
        [switch]$AguardarConfirmacao
    )

    $diretorioLogsFinal = $DiretorioLogsConfigurado
    if ([string]::IsNullOrWhiteSpace($diretorioLogsFinal)) {
        $diretorioLogsFinal = Join-Path $env:TEMP 'NarradorPorEventos'
    }

    if (-not (Test-Path $diretorioLogsFinal)) {
        New-Item -ItemType Directory -Path $diretorioLogsFinal | Out-Null
    }

    $prefixo = if ([string]::Equals($ModoExecucao, 'simulate', [System.StringComparison]::OrdinalIgnoreCase)) { 'servidor.simulacao' } else { 'servidor' }
    $stdoutPath = Join-Path $diretorioLogsFinal ($prefixo + '.stdout.log')
    $stderrPath = Join-Path $diretorioLogsFinal ($prefixo + '.stderr.log')

    foreach ($caminhoLog in @($stdoutPath, $stderrPath)) {
        if (Test-Path $caminhoLog) {
            Remove-Item -Force $caminhoLog
        }
    }

    $argumentosPowerShell = @(
        '-NoProfile',
        '-ExecutionPolicy',
        'Bypass',
        '-File',
        $PSCommandPath,
        '-Modo',
        $ModoExecucao,
        '-RepoRoot',
        $RepoRootNormalizado
    )

    if ($PularBuild) {
        $argumentosPowerShell += '-SemBuild'
    }

    $processoServidor = Start-Process -FilePath 'powershell.exe' -ArgumentList $argumentosPowerShell -WorkingDirectory $RepoRootNormalizado -RedirectStandardOutput $stdoutPath -RedirectStandardError $stderrPath -WindowStyle Hidden -PassThru

    if (-not $AguardarConfirmacao) {
        Write-Host ('Servidor iniciado em background com PID ' + $processoServidor.Id) -ForegroundColor DarkGray
        Write-Host ('stdout: ' + $stdoutPath) -ForegroundColor DarkGray
        Write-Host ('stderr: ' + $stderrPath) -ForegroundColor DarkGray
        return
    }

    $cronometro = [System.Diagnostics.Stopwatch]::StartNew()
    while ($cronometro.Elapsed.TotalSeconds -lt $TimeoutSegundos) {
        if ($processoServidor.HasExited) {
            $stdoutResumo = Obter-ResumoArquivo -Caminho $stdoutPath
            $stderrResumo = Obter-ResumoArquivo -Caminho $stderrPath
            throw ('O servidor encerrou antes de inicializar. stdout: ' + $stdoutResumo + ' | stderr: ' + $stderrResumo)
        }

        if (Test-Path $stdoutPath) {
            $stdoutAtual = Get-Content -Raw -Path $stdoutPath -ErrorAction SilentlyContinue
            if ($stdoutAtual -match 'NarradorEngine\.Server em execução') {
                Write-Host ('Servidor iniciado em background com PID ' + $processoServidor.Id) -ForegroundColor DarkGray
                Write-Host ('stdout: ' + $stdoutPath) -ForegroundColor DarkGray
                Write-Host ('stderr: ' + $stderrPath) -ForegroundColor DarkGray
                return
            }
        }

        Start-Sleep -Milliseconds 500
    }

    throw ('O servidor nao confirmou inicializacao em ate ' + $TimeoutSegundos + 's. Veja os logs em ' + $stdoutPath + ' e ' + $stderrPath)
}

$config = Obter-ConfiguracaoFerramentas -RaizRepositorio $RepoRoot
$caminhoConfigAtiva = Obter-CaminhoConfigModAtiva -ConfigFerramentas $config
$modoServidorContinuo = [string]::Equals($Modo, 'server', [System.StringComparison]::OrdinalIgnoreCase)

if ($IncluirOllama) {
    $configMod = Obter-ConfiguracaoCompartilhadaDoMod -ConfigPath $caminhoConfigAtiva
    $urlOllama = Obter-UrlOllama -ConfigMod $configMod
    Garantir-OllamaEmExecucao -UrlOllama $urlOllama -ExecutavelConfigurado $config.Paths.OllamaExecutablePath -TimeoutSegundos $config.Runtime.OllamaStartupTimeoutSeconds
}

if ($EmSegundoPlano) {
    Iniciar-ServidorEmSegundoPlano -RepoRootNormalizado $RepoRoot -ModoExecucao $Modo -PularBuild:$SemBuild -TimeoutSegundos $TimeoutInicializacaoSegundos -DiretorioLogsConfigurado $DiretorioLogs -AguardarConfirmacao:$AguardarPronto
    exit 0
}

if ($modoServidorContinuo) {
    $processosAnteriores = @(Stop-ProcessosServidorNarrativo)
    if ($processosAnteriores.Count -eq 0) {
        Write-Host 'Nenhum servidor narrativo anterior em execucao.' -ForegroundColor DarkGray
    }
    else {
        foreach ($processo in $processosAnteriores) {
            Write-Host ('Servidor narrativo anterior encerrado: PID ' + $processo.ProcessId) -ForegroundColor DarkGray
        }
    }
}

$argumentos = @(
    'run',
    '--project',
    $config.Paths.ServerProjectPath
)

if ($SemBuild) {
    $argumentos += '--no-build'
}

$argumentos += @(
    '--',
    ('--' + $Modo),
    ('--config=' + $caminhoConfigAtiva)
)

& dotnet @argumentos
exit $LASTEXITCODE
