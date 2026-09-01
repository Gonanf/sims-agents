@echo off
setlocal

for %%I in ("%~dp0..\..") do set "repo=%%~fI"
set "script=%~dp0executar_servidor.ps1"

powershell -NoProfile -ExecutionPolicy Bypass -File "%script%" -Modo simulate -RepoRoot "%repo%"

set "exitCode=%ERRORLEVEL%"
endlocal & exit /b %exitCode%