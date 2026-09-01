[CmdletBinding()]
param(
    [switch]$IncluirOllama
)

$ErrorActionPreference = 'Stop'

. (Join-Path $PSScriptRoot 'ProcessosNarrativos.ps1')

$processosServidor = @(Stop-ProcessosServidorNarrativo -IncluirSimulacao)
if ($processosServidor.Count -eq 0) {
    Write-Host 'Nenhum servidor narrativo em execucao.' -ForegroundColor DarkGray
}
else {
    foreach ($processo in $processosServidor) {
        Write-Host ('Servidor narrativo encerrado: PID ' + $processo.ProcessId) -ForegroundColor Yellow
    }
}

if (-not $IncluirOllama) {
    return
}

$processosOllama = @(Stop-ProcessosOllamaLocal)
if ($processosOllama.Count -eq 0) {
    Write-Host 'Nenhum Ollama local em execucao.' -ForegroundColor DarkGray
    return
}

foreach ($processo in $processosOllama) {
    Write-Host ('Ollama local encerrado: PID ' + $processo.ProcessId) -ForegroundColor Yellow
}