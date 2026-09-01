[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$PackagePath,

    [Parameter(Mandatory = $true)]
    [string]$DllPath,

    [Parameter(Mandatory = $true)]
    [string]$ResourceType,

    [Parameter(Mandatory = $true)]
    [string]$ResourceGroup,

    [Parameter(Mandatory = $true)]
    [string]$ResourceInstance,

    [string]$S3peDirectory
)

$ErrorActionPreference = 'Stop'

function Resolve-S3peDirectory {
    param([string]$ConfiguredPath)

    $candidates = @()
    if (-not [string]::IsNullOrWhiteSpace($ConfiguredPath)) {
        $candidates += $ConfiguredPath
    }

    $candidates += 'C:\Program Files\S3PE'
    $candidates += 'C:\Program Files\s3pe'

    foreach ($candidate in $candidates) {
        if (-not [string]::IsNullOrWhiteSpace($candidate) -and (Test-Path (Join-Path $candidate 's3pi.Package.dll'))) {
            return $candidate
        }
    }

    throw 'Diretorio do S3PE nao encontrado. Informe -S3peDirectory ou instale o S3PE em C:\Program Files\S3PE.'
}

function Convert-HexToUInt32 {
    param([string]$HexValue)

    return [Convert]::ToUInt32(($HexValue -replace '^0x', ''), 16)
}

function Convert-HexToUInt64 {
    param([string]$HexValue)

    return [Convert]::ToUInt64(($HexValue -replace '^0x', ''), 16)
}

function Format-Hex32 {
    param([uint32]$Value)

    return ('0x{0:X8}' -f $Value)
}

function Format-Hex64 {
    param([uint64]$Value)

    return ('0x{0:X16}' -f $Value)
}

function New-BackupPackagePath {
    param([string]$ActivePackagePath)

    $directory = Split-Path -Parent $ActivePackagePath
    $baseName = [System.IO.Path]::GetFileNameWithoutExtension($ActivePackagePath)
    $stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
    return Join-Path $directory ($baseName + '.' + $stamp + '._package')
}

function Assert-PackageUnlocked {
    param([string]$ActivePackagePath)

    $stream = $null

    try {
        $stream = [System.IO.File]::Open($ActivePackagePath, [System.IO.FileMode]::Open, [System.IO.FileAccess]::ReadWrite, [System.IO.FileShare]::None)
    }
    catch {
        throw ('O package esta em uso e nao pode ser atualizado agora: ' + $ActivePackagePath + '. Feche s3pe, TS3W.exe ou qualquer processo que esteja com esse arquivo aberto e rode o comando novamente.')
    }
    finally {
        if ($stream -ne $null) {
            $stream.Close()
            $stream.Dispose()
        }
    }
}

if (-not (Test-Path $PackagePath)) {
    throw ('Package nao encontrado: ' + $PackagePath)
}

if (-not (Test-Path $DllPath)) {
    throw ('DLL nao encontrada: ' + $DllPath)
}

Assert-PackageUnlocked -ActivePackagePath $PackagePath

$resolvedS3peDirectory = Resolve-S3peDirectory -ConfiguredPath $S3peDirectory
$resourceTypeId = Convert-HexToUInt32 -HexValue $ResourceType
$resourceGroupId = Convert-HexToUInt32 -HexValue $ResourceGroup
$resourceInstanceId = Convert-HexToUInt64 -HexValue $ResourceInstance

$packageAssemblyPath = Join-Path $resolvedS3peDirectory 's3pi.Package.dll'
$interfacesAssemblyPath = Join-Path $resolvedS3peDirectory 's3pi.Interfaces.dll'
$scriptAssemblyPath = Join-Path $resolvedS3peDirectory 's3pi.ScriptResource.dll'

$null = [Reflection.Assembly]::LoadFrom($interfacesAssemblyPath)
$packageAssembly = [Reflection.Assembly]::LoadFrom($packageAssemblyPath)
$null = [Reflection.Assembly]::LoadFrom($scriptAssemblyPath)

$packageType = $packageAssembly.GetType('s3pi.Package.Package')
if ($null -eq $packageType) {
    throw 'Tipo s3pi.Package.Package nao encontrado.'
}

$tempOutputPath = Join-Path ([System.IO.Path]::GetDirectoryName($PackagePath)) (([System.IO.Path]::GetFileNameWithoutExtension($PackagePath)) + '.tmp.package')
$backupPackagePath = New-BackupPackagePath -ActivePackagePath $PackagePath

if (Test-Path $tempOutputPath) {
    Remove-Item -Force $tempOutputPath
}

$package = $null
$resourceStream = $null
$dllStream = $null
$dllReader = $null

try {
    $package = $packageType::OpenPackage(0, $PackagePath)

    $entry = $package.GetResourceList |
        Where-Object {
            $_.ResourceType -eq $resourceTypeId -and
            $_.ResourceGroup -eq $resourceGroupId -and
            [uint64]$_.Instance -eq $resourceInstanceId
        } |
        Select-Object -First 1

    if ($null -eq $entry) {
        throw ('S3SA nao encontrado no package: type=' + (Format-Hex32 $resourceTypeId) + '; group=' + (Format-Hex32 $resourceGroupId) + '; instance=' + (Format-Hex64 $resourceInstanceId))
    }

    $resourceStream = $package.GetResource($entry)
    $scriptResource = New-Object 'ScriptResource.ScriptResource' 1, $resourceStream
    $dllStream = [System.IO.MemoryStream]::new([System.IO.File]::ReadAllBytes($DllPath))
    $dllReader = [System.IO.BinaryReader]::new($dllStream)

    $scriptResource.Assembly = $dllReader
    $package.ReplaceResource($entry, $scriptResource)
    $package.SaveAs($tempOutputPath)
}
finally {
    if ($dllReader -ne $null) {
        $dllReader.Close()
    }

    if ($dllStream -ne $null) {
        $dllStream.Dispose()
    }

    if ($resourceStream -ne $null) {
        $resourceStream.Dispose()
    }

    if ($package -ne $null) {
        [void]$packageType::ClosePackage(0, $package)
    }
}

$publishSucceeded = $false

try {
    Rename-Item -Path $PackagePath -NewName ([System.IO.Path]::GetFileName($backupPackagePath))
    Move-Item -Path $tempOutputPath -Destination $PackagePath -Force
    $publishSucceeded = $true
}
catch {
    if (Test-Path $backupPackagePath) {
        if (-not (Test-Path $PackagePath)) {
            Move-Item -Path $backupPackagePath -Destination $PackagePath -Force
        }
    }

    throw
}
finally {
    if (-not $publishSucceeded -and (Test-Path $tempOutputPath)) {
        Remove-Item -Force $tempOutputPath
    }
}

$packageCheck = $null

try {
    $packageCheck = $packageType::OpenPackage(0, $PackagePath)
    $entryCheck = $packageCheck.GetResourceList |
        Where-Object {
            $_.ResourceType -eq $resourceTypeId -and
            $_.ResourceGroup -eq $resourceGroupId -and
            [uint64]$_.Instance -eq $resourceInstanceId
        } |
        Select-Object -First 1

    if ($null -eq $entryCheck) {
        throw 'Falha na verificacao final do package atualizado.'
    }

    Write-Output ('Package atualizado: ' + $PackagePath)
    Write-Output ('Backup comentado: ' + $backupPackagePath)
    Write-Output ('DLL importada: ' + $DllPath)
    Write-Output ('S3SA atualizado: type=' + (Format-Hex32 $resourceTypeId) + '; group=' + (Format-Hex32 $resourceGroupId) + '; instance=' + (Format-Hex64 $resourceInstanceId))
    Write-Output ('Entry filesize: ' + $entryCheck.Filesize)
    Write-Output ('Entry memsize: ' + $entryCheck.Memsize)
}
finally {
    if ($packageCheck -ne $null) {
        [void]$packageType::ClosePackage(0, $packageCheck)
    }
}