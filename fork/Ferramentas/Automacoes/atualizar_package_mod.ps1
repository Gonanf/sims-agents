[CmdletBinding()]
param(
    [string]$RepoRoot,
    [string]$S3peDirectory
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
    $RepoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
}

. (Join-Path $PSScriptRoot '..\Configuracao\ResolverConfiguracaoFerramentas.ps1')

function Remover-ArquivosCacheDoJogo {
    param([string[]]$CacheFiles)

    foreach ($cacheFile in $CacheFiles) {
        if ([string]::IsNullOrWhiteSpace($cacheFile)) {
            continue
        }

        if (Test-Path $cacheFile) {
            Remove-Item -Force $cacheFile
            Write-Output ('Cache removido: ' + $cacheFile)
            continue
        }

        Write-Output ('Cache ausente: ' + $cacheFile)
    }
}

$config = Obter-ConfiguracaoFerramentas -RaizRepositorio $RepoRoot
$scriptAtualizacao = Join-Path $PSScriptRoot 'atualizar_package_s3sa.ps1'

Remover-ArquivosCacheDoJogo -CacheFiles $config.Paths.GameCacheFiles

$argumentos = @{
    PackagePath = $config.Paths.PackagePath
    DllPath = $config.Paths.ModDllPath
    ResourceType = $config.Package.ResourceType
    ResourceGroup = $config.Package.ResourceGroup
    ResourceInstance = $config.Package.ResourceInstance
}

if (-not [string]::IsNullOrWhiteSpace($S3peDirectory)) {
    $argumentos['S3peDirectory'] = $S3peDirectory
}

& $scriptAtualizacao @argumentos
exit $LASTEXITCODE
