[CmdletBinding()]
param([string]$RepoRoot)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
    $RepoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
}

. (Join-Path $PSScriptRoot '..\Configuracao\ResolverConfiguracaoFerramentas.ps1')

function Resolver-DiretorioNarrativo {
    param(
        [string]$CaminhoConfigurado,
        [string]$ModsRoot
    )

    $expandido = [Environment]::ExpandEnvironmentVariables($CaminhoConfigurado)
    if ([string]::IsNullOrWhiteSpace($expandido)) {
        return Join-Path $ModsRoot 'NarradorPorEventos'
    }

    if ([System.IO.Path]::IsPathRooted($expandido)) {
        return $expandido
    }

    return Join-Path $ModsRoot $expandido
}

$config = Obter-ConfiguracaoFerramentas -RaizRepositorio $RepoRoot
$sourceConfigPath = $config.Paths.ModConfigSourcePath
$modsRoot = $config.Paths.ModsRoot
$destConfigPath = $config.Paths.ModRuntimeConfigPath

if ([string]::IsNullOrWhiteSpace($sourceConfigPath)) {
    $sourceConfigPath = $config.Paths.ModConfigPath
}

if ([string]::IsNullOrWhiteSpace($destConfigPath)) {
    $destConfigPath = Join-Path $modsRoot ([System.IO.Path]::GetFileName($sourceConfigPath))
}

if (-not (Test-Path $sourceConfigPath)) {
    throw ('Config do mod nao encontrada: ' + $sourceConfigPath)
}

if (-not (Test-Path $modsRoot)) {
    throw ('Pasta Mods nao encontrada: ' + $modsRoot)
}

$configMod = Get-Content -Raw -Path $sourceConfigPath | ConvertFrom-Json
$documentosMod = $null
if ($configMod.diretorio -ne $null) {
    $documentosMod = [string]$configMod.diretorio.documentos_mod
}

$diretorioNarrativo = Resolver-DiretorioNarrativo -CaminhoConfigurado $documentosMod -ModsRoot $modsRoot
if (-not (Test-Path $diretorioNarrativo)) {
    New-Item -ItemType Directory -Path $diretorioNarrativo | Out-Null
}

Copy-Item -Path $sourceConfigPath -Destination $destConfigPath -Force

Write-Output ('Config sincronizada em ' + $destConfigPath)
Write-Output ('Diretorio narrativo garantido em ' + $diretorioNarrativo)
