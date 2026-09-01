[CmdletBinding()]
param(
    [string]$RepoRoot,
    [string]$Configuration = 'Debug'
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
    $RepoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
}

$repoNormalizado = (Resolve-Path $RepoRoot).Path
$diretorioTemporario = Join-Path $env:TEMP ('narrador_validate_' + (Get-Date -Format yyyyMMdd_HHmmss))

New-Item -ItemType Directory -Path $diretorioTemporario | Out-Null

$copias = @(
    @{
        Origem = Join-Path $repoNormalizado 'Dominio'
        Destino = Join-Path $diretorioTemporario 'Dominio'
    },
    @{
        Origem = Join-Path $repoNormalizado 'NarradorEngine.Server'
        Destino = Join-Path $diretorioTemporario 'NarradorEngine.Server'
    },
    @{
        Origem = Join-Path $repoNormalizado 'NarradorEngine.Server.Tests'
        Destino = Join-Path $diretorioTemporario 'NarradorEngine.Server.Tests'
    }
)

foreach ($copia in $copias) {
    robocopy $copia.Origem $copia.Destino /E /XD bin obj /NFL /NDL /NJH /NJS /NP | Out-Null
    if ($LASTEXITCODE -gt 7) {
        throw ('Falha ao copiar ' + $copia.Origem + ' para validação limpa.')
    }
}

Copy-Item (Join-Path $repoNormalizado 'NarradorPorEventos.config.json') (Join-Path $diretorioTemporario 'NarradorPorEventos.config.json')

Write-Host ('TMP=' + $diretorioTemporario)

$projetoServidor = Join-Path $diretorioTemporario 'NarradorEngine.Server\NarradorEngine.Server.csproj'
$projetoTestes = Join-Path $diretorioTemporario 'NarradorEngine.Server.Tests\NarradorEngine.Server.Tests.csproj'

dotnet build $projetoServidor -c $Configuration /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
if ($LASTEXITCODE -ne 0) {
    throw 'Falha ao compilar o servidor na cópia limpa.'
}

dotnet test $projetoTestes -c $Configuration
if ($LASTEXITCODE -ne 0) {
    throw 'Falha ao executar os testes do servidor na cópia limpa.'
}