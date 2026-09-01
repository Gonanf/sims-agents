@echo off
setlocal

set "script=%~dp0encerrar_processos_narrativos.ps1"

powershell -NoProfile -ExecutionPolicy Bypass -File "%script%" %*

set "exitCode=%ERRORLEVEL%"
endlocal & exit /b %exitCode%