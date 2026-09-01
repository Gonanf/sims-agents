@echo off
setlocal

for %%I in ("%~dp0..\..") do set "repo=%%~fI"
set "script=%~dp0atualizar_package_mod.ps1"

powershell -NoProfile -ExecutionPolicy Bypass -File "%script%" -RepoRoot "%repo%"

set "exitCode=%ERRORLEVEL%"
endlocal & exit /b %exitCode%