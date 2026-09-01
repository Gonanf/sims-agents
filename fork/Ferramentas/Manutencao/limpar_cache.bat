@echo off
setlocal

for %%I in ("%~dp0..\..") do set "repo=%%~fI"

taskkill /f /im devenv.exe 2>nul

if exist "%repo%\.vs" rmdir /s /q "%repo%\.vs"

for /d /r "%repo%" %%d in (bin,obj) do (
    if exist "%%d" rmdir /s /q "%%d"
)

if exist "%LocalAppData%\GitHubCopilot" rmdir /s /q "%LocalAppData%\GitHubCopilot"

for /d %%d in ("%LocalAppData%\Microsoft\VisualStudio\*") do (
    if exist "%%d\ComponentModelCache" rmdir /s /q "%%d\ComponentModelCache"
)

echo Limpeza concluida para %USERNAME%.

endlocal