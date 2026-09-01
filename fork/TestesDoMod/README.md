# TestesDoMod

This directory contains lightweight TS3-side self-checks that do not use the server's xUnit runner.

Goals:

- keep quick checks for event mapping and routing rules outside `NucleoNarrativo`;
- separate sanity checks from runtime implementation code;
- avoid making tests feel scattered across production folders.

Current scope:

- `Autoverificacoes/TesteRepositorioTiposEvento.cs`
- `Autoverificacoes/TesteRegrasRegistroNarrativo.cs`

These files are still compiled together with the legacy mod project and act as local sanity checks for pure rules that do not depend on the modern server-side test runner.
