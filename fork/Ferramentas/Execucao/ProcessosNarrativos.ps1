Set-StrictMode -Version 2

function Write-InfoProcessosNarrativos {
    [CmdletBinding()]
    param([string]$Mensagem)

    $comandoWriteInfo = Get-Command 'Write-Info' -CommandType Function -ErrorAction SilentlyContinue
    if ($comandoWriteInfo -ne $null) {
        Write-Info $Mensagem
        return
    }

    Write-Host ('    ' + $Mensagem) -ForegroundColor DarkGray
}

function Get-ProcessosServidorNarrativo {
    [CmdletBinding()]
    param(
        [switch]$IncluirSimulacao
    )

    $regexModo = if ($IncluirSimulacao) { '--(server|simulate)' } else { '--server' }

    return @(
        Get-CimInstance Win32_Process | Where-Object {
            $_.CommandLine -and
            $_.CommandLine -match 'NarradorEngine\.Server' -and
            $_.CommandLine -match $regexModo
        } | Sort-Object ProcessId -Descending
    )
}

function Stop-ProcessosServidorNarrativo {
    [CmdletBinding()]
    param(
        [switch]$IncluirSimulacao
    )

    $processos = Get-ProcessosServidorNarrativo -IncluirSimulacao:$IncluirSimulacao
    foreach ($processo in $processos) {
        Stop-Process -Id $processo.ProcessId -Force -ErrorAction Stop
    }

    return $processos
}

function Get-ProcessosOllamaLocal {
    [CmdletBinding()]
    param()

    return @(
        Get-CimInstance Win32_Process | Where-Object {
            $_.Name -ieq 'ollama.exe' -and
            $_.CommandLine -and
            ($_.CommandLine -match '\bserve\b' -or $_.CommandLine -match '\brunner\b')
        } | Sort-Object @{ Expression = { if ($_.CommandLine -match '\brunner\b') { 0 } else { 1 } } }, @{ Expression = { $_.ProcessId }; Descending = $true }
    )
}

function Stop-ProcessosOllamaLocal {
    [CmdletBinding()]
    param()

    $processos = Get-ProcessosOllamaLocal
    foreach ($processo in $processos) {
        Stop-Process -Id $processo.ProcessId -Force -ErrorAction Stop
    }

    return $processos
}

function Obter-CaminhoConfigModAtiva {
    [CmdletBinding()]
    param([object]$ConfigFerramentas)

    if ($ConfigFerramentas -eq $null -or $ConfigFerramentas.Paths -eq $null) {
        throw 'Configuracao de ferramentas invalida para resolver a config ativa do mod.'
    }

    if ([string]::IsNullOrWhiteSpace([string]$ConfigFerramentas.Paths.ModRuntimeConfigPath)) {
        return [string]$ConfigFerramentas.Paths.ModConfigPath
    }

    return [string]$ConfigFerramentas.Paths.ModRuntimeConfigPath
}

function Obter-ConfiguracaoCompartilhadaDoMod {
    [CmdletBinding()]
    param([string]$ConfigPath)

    if (-not (Test-Path $ConfigPath)) {
        throw ('Config compartilhada do mod nao encontrada: ' + $ConfigPath)
    }

    return Get-Content -Raw -Path $ConfigPath | ConvertFrom-Json
}

function Obter-UrlOllama {
    [CmdletBinding()]
    param([object]$ConfigMod)

    if ($ConfigMod -ne $null -and $ConfigMod.ollama -ne $null -and -not [string]::IsNullOrWhiteSpace([string]$ConfigMod.ollama.url)) {
        return [string]$ConfigMod.ollama.url
    }

    return 'http://127.0.0.1:11434/api/generate'
}

function Obter-UrlSaudeOllama {
    [CmdletBinding()]
    param([string]$UrlGeracao)

    $builder = New-Object System.UriBuilder([System.Uri]$UrlGeracao)
    $builder.Path = 'api/tags'
    $builder.Query = [string]::Empty
    $builder.Fragment = [string]::Empty
    return $builder.Uri.AbsoluteUri
}

function Testar-HostLocal {
    [CmdletBinding()]
    param([string]$Url)

    $uri = [System.Uri]$Url
    $hostName = $uri.DnsSafeHost

    if ([string]::IsNullOrWhiteSpace($hostName)) {
        return $false
    }

    if ($hostName -eq 'localhost' -or $hostName -eq '127.0.0.1' -or $hostName -eq '::1') {
        return $true
    }

    if ($hostName -eq $env:COMPUTERNAME) {
        return $true
    }

    if (-not [string]::IsNullOrWhiteSpace($env:USERDNSDOMAIN) -and $hostName -eq ($env:COMPUTERNAME + '.' + $env:USERDNSDOMAIN)) {
        return $true
    }

    return $false
}

function Testar-OllamaDisponivel {
    [CmdletBinding()]
    param([string]$UrlSaude)

    try {
        $resposta = Invoke-WebRequest -UseBasicParsing -Uri $UrlSaude -TimeoutSec 3
        return $resposta.StatusCode -ge 200 -and $resposta.StatusCode -lt 400
    }
    catch {
        return $false
    }
}

function Resolver-ExecutavelOllama {
    [CmdletBinding()]
    param([string]$Configurado)

    $candidatos = @()

    if (-not [string]::IsNullOrWhiteSpace($Configurado)) {
        $candidatos += $Configurado
    }

    $comandoOllama = Get-Command 'ollama' -CommandType Application -ErrorAction SilentlyContinue | Select-Object -First 1
    if ($comandoOllama -ne $null) {
        if (-not [string]::IsNullOrWhiteSpace($comandoOllama.Source)) {
            $candidatos += $comandoOllama.Source
        }
        elseif (-not [string]::IsNullOrWhiteSpace($comandoOllama.Path)) {
            $candidatos += $comandoOllama.Path
        }
    }

    $candidatos += @(
        '%LOCALAPPDATA%\\Programs\\Ollama\\ollama.exe',
        '%ProgramFiles%\\Ollama\\ollama.exe',
        '%ProgramFiles(x86)%\\Ollama\\ollama.exe'
    )

    foreach ($candidato in $candidatos) {
        $expandido = [Environment]::ExpandEnvironmentVariables($candidato)
        if ([string]::IsNullOrWhiteSpace($expandido)) {
            continue
        }

        if ([System.IO.Path]::IsPathRooted($expandido)) {
            if (Test-Path $expandido) {
                return (Resolve-Path $expandido).Path
            }

            continue
        }

        return $expandido
    }

    return [string]::Empty
}

function Garantir-OllamaEmExecucao {
    [CmdletBinding()]
    param(
        [string]$UrlOllama,
        [string]$ExecutavelConfigurado,
        [int]$TimeoutSegundos
    )

    $urlSaude = Obter-UrlSaudeOllama -UrlGeracao $UrlOllama
    if (Testar-OllamaDisponivel -UrlSaude $urlSaude) {
        Write-InfoProcessosNarrativos ('Ollama ja respondeu em ' + $urlSaude)
        return
    }

    if (-not (Testar-HostLocal -Url $UrlOllama)) {
        throw ('Ollama nao respondeu em ' + $urlSaude + ' e o host configurado nao eh local. Ajuste NarradorPorEventos.config.json ou suba esse endpoint antes de rodar o fluxo.')
    }

    $executavelOllama = Resolver-ExecutavelOllama -Configurado $ExecutavelConfigurado
    if ([string]::IsNullOrWhiteSpace($executavelOllama)) {
        throw 'Executavel do Ollama nao encontrado. Ajuste ollama.caminho_executavel em Ferramentas.local.json ou deixe o comando ollama disponivel no PATH.'
    }

    Write-InfoProcessosNarrativos ('iniciando Ollama local com ' + $executavelOllama)
    $processoOllama = Start-Process -FilePath $executavelOllama -ArgumentList @('serve') -WindowStyle Hidden -PassThru

    $cronometro = [System.Diagnostics.Stopwatch]::StartNew()
    while ($cronometro.Elapsed.TotalSeconds -lt $TimeoutSegundos) {
        if (Testar-OllamaDisponivel -UrlSaude $urlSaude) {
            Write-InfoProcessosNarrativos ('Ollama pronto na porta ' + ([System.Uri]$UrlOllama).Port)
            return
        }

        if ($processoOllama.HasExited) {
            throw ('O processo do Ollama encerrou antes de responder em ' + $urlSaude + '.')
        }

        Start-Sleep -Milliseconds 500
    }

    throw ('Ollama nao ficou pronto em ate ' + $TimeoutSegundos + 's. Endpoint esperado: ' + $urlSaude)
}