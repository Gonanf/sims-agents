@echo off
setlocal

for %%I in ("%~dp0..\..") do set "repo=%%~fI"
set "script=%~dp0executar_fluxo_completo.ps1"

powershell -NoProfile -ExecutionPolicy Bypass -File "%script%" -RepoRoot "%repo%" %*

set "exitCode=%ERRORLEVEL%"
endlocal & exit /b %exitCode%