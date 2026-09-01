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

$repo = (Resolve-Path $RepoRoot).Path
$project = Join-Path $repo 'ZZZZitalo.TS3Mods.NarradorPorEventos.csproj'
$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
$candidates = @()

if (Test-Path $vswhere) {
    $candidates += & $vswhere -latest -products * -find 'MSBuild\**\Bin\MSBuild.exe'
}

$candidates += 'C:\Program Files\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe'
$candidates += 'C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe'
$candidates += 'C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe'

$msbuild = $candidates | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
if (-not $msbuild) {
    throw 'MSBuild nao encontrado. Instale o Build Tools com Microsoft.VisualStudio.Workload.ManagedDesktopBuildTools e Microsoft.Net.Component.3.5.DeveloperTools.'
}

& $msbuild $project '/t:Build' ("/p:Configuration=" + $Configuration) ("/p:Platform=" + $Platform) '/property:GenerateFullPaths=true' '/consoleloggerparameters:NoSummary'
exit $LASTEXITCODE
