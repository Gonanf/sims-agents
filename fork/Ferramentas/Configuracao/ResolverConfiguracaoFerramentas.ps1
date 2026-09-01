function ConvertTo-HashtableRecursivo {
    param([object]$Valor)

    if ($null -eq $Valor) {
        return $null
    }

    if ($Valor -is [System.Collections.IDictionary]) {
        $resultado = @{}
        foreach ($chave in $Valor.Keys) {
            $resultado[$chave] = ConvertTo-HashtableRecursivo -Valor $Valor[$chave]
        }

        return $resultado
    }

    if ($Valor -is [System.Management.Automation.PSCustomObject]) {
        $resultado = @{}
        foreach ($propriedade in $Valor.PSObject.Properties) {
            $resultado[$propriedade.Name] = ConvertTo-HashtableRecursivo -Valor $propriedade.Value
        }

        return $resultado
    }

    if (($Valor -is [System.Collections.IEnumerable]) -and -not ($Valor -is [string])) {
        $itens = @()
        foreach ($item in $Valor) {
            $itens += ,(ConvertTo-HashtableRecursivo -Valor $item)
        }

        return $itens
    }

    return $Valor
}

function Merge-HashtableRecursivo {
    param(
        [hashtable]$Base,
        [hashtable]$Override
    )

    $resultado = @{}

    if ($Base -ne $null) {
        foreach ($chave in $Base.Keys) {
            $resultado[$chave] = $Base[$chave]
        }
    }

    if ($Override -eq $null) {
        return $resultado
    }

    foreach ($chave in $Override.Keys) {
        $valorBase = $null
        $possuiBase = $resultado.ContainsKey($chave)
        if ($possuiBase) {
            $valorBase = $resultado[$chave]
        }

        if ($valorBase -is [hashtable] -and $Override[$chave] -is [hashtable]) {
            $resultado[$chave] = Merge-HashtableRecursivo -Base $valorBase -Override $Override[$chave]
            continue
        }

        $resultado[$chave] = $Override[$chave]
    }

    return $resultado
}

function Expandir-CaminhoComAmbiente {
    param([string]$Caminho)

    if ([string]::IsNullOrWhiteSpace($Caminho)) {
        return $Caminho
    }

    return [Environment]::ExpandEnvironmentVariables($Caminho)
}

function Resolver-CaminhoRepositorio {
    param(
        [string]$RaizRepositorio,
        [string]$CaminhoConfigurado
    )

    $caminhoExpandido = Expandir-CaminhoComAmbiente -Caminho $CaminhoConfigurado
    if ([string]::IsNullOrWhiteSpace($caminhoExpandido)) {
        return $caminhoExpandido
    }

    if ([System.IO.Path]::IsPathRooted($caminhoExpandido)) {
        return $caminhoExpandido
    }

    return Join-Path $RaizRepositorio $caminhoExpandido
}

function Obter-CaminhosCacheDoJogo {
    param([string]$CacheRoot)

    return @(
        (Join-Path $CacheRoot 'CASPartCache.package'),
        (Join-Path $CacheRoot 'compositorCache.package'),
        (Join-Path $CacheRoot 'scriptCache.package'),
        (Join-Path $CacheRoot 'simCompositorCache.package'),
        (Join-Path $CacheRoot 'socialCache.package')
    )
}

function Obter-ValorObrigatorio {
    param(
        [hashtable]$Tabela,
        [string]$Chave,
        [string]$Contexto
    )

    if ($Tabela -eq $null -or -not $Tabela.ContainsKey($Chave) -or [string]::IsNullOrWhiteSpace([string]$Tabela[$Chave])) {
        throw ('Valor obrigatorio ausente em ' + $Contexto + ': ' + $Chave)
    }

    return [string]$Tabela[$Chave]
}

function Obter-SecaoComAlias {
    param(
        [hashtable]$Tabela,
        [string[]]$Chaves
    )

    if ($Tabela -eq $null -or $Chaves -eq $null) {
        return $null
    }

    foreach ($chave in $Chaves) {
        if (-not [string]::IsNullOrWhiteSpace($chave) -and $Tabela.ContainsKey($chave) -and $Tabela[$chave] -is [hashtable]) {
            return $Tabela[$chave]
        }
    }

    return $null
}

function Obter-ValorObrigatorioComAlias {
    param(
        [hashtable]$Tabela,
        [string[]]$Chaves,
        [string]$Contexto
    )

    foreach ($chave in $Chaves) {
        if ($Tabela -ne $null -and $Tabela.ContainsKey($chave) -and -not [string]::IsNullOrWhiteSpace([string]$Tabela[$chave])) {
            return [string]$Tabela[$chave]
        }
    }

    throw ('Valor obrigatorio ausente em ' + $Contexto + ': ' + ($Chaves -join ' ou '))
}

function Obter-TextoOpcionalComAlias {
    param(
        [hashtable]$Tabela,
        [string[]]$Chaves
    )

    foreach ($chave in $Chaves) {
        if ($Tabela -ne $null -and $Tabela.ContainsKey($chave) -and $null -ne $Tabela[$chave]) {
            return [string]$Tabela[$chave]
        }
    }

    return [string]::Empty
}

function Obter-InteiroOpcionalComAlias {
    param(
        [hashtable]$Tabela,
        [string[]]$Chaves,
        [int]$ValorPadrao
    )

    foreach ($chave in $Chaves) {
        if ($Tabela -eq $null -or -not $Tabela.ContainsKey($chave) -or $null -eq $Tabela[$chave]) {
            continue
        }

        $resultado = 0
        if ([int]::TryParse([string]$Tabela[$chave], [ref]$resultado)) {
            return $resultado
        }
    }

    return $ValorPadrao
}

function Obter-TextoOpcional {
    param(
        [hashtable]$Tabela,
        [string]$Chave
    )

    if ($Tabela -eq $null -or -not $Tabela.ContainsKey($Chave) -or $null -eq $Tabela[$Chave]) {
        return [string]::Empty
    }

    return [string]$Tabela[$Chave]
}

function Obter-InteiroOpcional {
    param(
        [hashtable]$Tabela,
        [string]$Chave,
        [int]$ValorPadrao
    )

    if ($Tabela -eq $null -or -not $Tabela.ContainsKey($Chave) -or $null -eq $Tabela[$Chave]) {
        return $ValorPadrao
    }

    $resultado = 0
    if ([int]::TryParse([string]$Tabela[$Chave], [ref]$resultado)) {
        return $resultado
    }

    return $ValorPadrao
}

function Obter-ConfiguracaoFerramentas {
    param([string]$RaizRepositorio)

    if ([string]::IsNullOrWhiteSpace($RaizRepositorio)) {
        throw 'Raiz do repositorio nao informada.'
    }

    $raizNormalizada = (Resolve-Path $RaizRepositorio).Path
    $diretorioConfiguracao = Join-Path $raizNormalizada 'Ferramentas\Configuracao'
    $caminhoConfigBase = Join-Path $diretorioConfiguracao 'Ferramentas.config.json'
    $caminhoConfigLocal = Join-Path $diretorioConfiguracao 'Ferramentas.local.json'

    if (-not (Test-Path $caminhoConfigBase)) {
        throw ('Config base das ferramentas nao encontrada: ' + $caminhoConfigBase)
    }

    $configBase = ConvertTo-HashtableRecursivo -Valor (Get-Content -Raw -Path $caminhoConfigBase | ConvertFrom-Json)
    $configLocal = @{}

    if (Test-Path $caminhoConfigLocal) {
        $configLocal = ConvertTo-HashtableRecursivo -Valor (Get-Content -Raw -Path $caminhoConfigLocal | ConvertFrom-Json)
    }

    $configMesclada = Merge-HashtableRecursivo -Base $configBase -Override $configLocal
    $configTs3 = Obter-SecaoComAlias -Tabela $configMesclada -Chaves @('ts3')
    $configMod = Obter-SecaoComAlias -Tabela $configMesclada -Chaves @('mod')
    $configPacote = Obter-SecaoComAlias -Tabela $configMesclada -Chaves @('pacote_mod')
    $configOllama = Obter-SecaoComAlias -Tabela $configMesclada -Chaves @('ollama')
    $configServidor = Obter-SecaoComAlias -Tabela $configMesclada -Chaves @('servidor', 'server')

    if ($configTs3 -eq $null -or $configMod -eq $null -or $configPacote -eq $null -or $configServidor -eq $null) {
        throw 'Estrutura invalida em Ferramentas.config.json.'
    }

    if ($configOllama -eq $null) {
        $configOllama = @{}
    }

    $modsRoot = Expandir-CaminhoComAmbiente -Caminho (Obter-ValorObrigatorioComAlias -Tabela $configTs3 -Chaves @('raiz_mods', 'mods_root') -Contexto 'ts3')
    $cacheRoot = Expandir-CaminhoComAmbiente -Caminho (Obter-ValorObrigatorioComAlias -Tabela $configTs3 -Chaves @('raiz_cache', 'cache_root') -Contexto 'ts3')
    $gameExecutablePath = Expandir-CaminhoComAmbiente -Caminho (Obter-TextoOpcionalComAlias -Tabela $configTs3 -Chaves @('caminho_executavel_jogo', 'game_executable_path'))
    $gameLaunchArguments = Obter-TextoOpcionalComAlias -Tabela $configTs3 -Chaves @('argumentos_execucao_jogo', 'game_launch_arguments')
    $dllPath = Resolver-CaminhoRepositorio -RaizRepositorio $raizNormalizada -CaminhoConfigurado (Obter-ValorObrigatorioComAlias -Tabela $configMod -Chaves @('caminho_relativo_dll', 'dll_relative_path') -Contexto 'mod')
    $modConfigPath = Resolver-CaminhoRepositorio -RaizRepositorio $raizNormalizada -CaminhoConfigurado (Obter-ValorObrigatorioComAlias -Tabela $configMod -Chaves @('caminho_relativo_config', 'config_relative_path') -Contexto 'mod')
    $modRuntimeConfigPath = Join-Path $modsRoot ([System.IO.Path]::GetFileName($modConfigPath))
    $serverProjectPath = Resolver-CaminhoRepositorio -RaizRepositorio $raizNormalizada -CaminhoConfigurado (Obter-ValorObrigatorioComAlias -Tabela $configServidor -Chaves @('caminho_relativo_projeto', 'project_relative_path') -Contexto 'servidor')
    $serverProjectDirectory = Split-Path -Parent $serverProjectPath
    $serverStartupTimeoutSeconds = Obter-InteiroOpcionalComAlias -Tabela $configServidor -Chaves @('timeout_inicializacao_segundos', 'startup_timeout_seconds') -ValorPadrao 20
    $ollamaExecutablePath = Expandir-CaminhoComAmbiente -Caminho (Obter-TextoOpcionalComAlias -Tabela $configOllama -Chaves @('caminho_executavel', 'executable_path'))
    $ollamaStartupTimeoutSeconds = Obter-InteiroOpcionalComAlias -Tabela $configOllama -Chaves @('timeout_inicializacao_segundos', 'startup_timeout_seconds') -ValorPadrao 20
    $packageName = Obter-ValorObrigatorio -Tabela $configPacote -Chave 'nome_arquivo' -Contexto 'pacote_mod'
    $packagesRoot = Join-Path $modsRoot 'Packages'
    $packagePath = Join-Path $packagesRoot $packageName
    $gameCacheFiles = Obter-CaminhosCacheDoJogo -CacheRoot $cacheRoot

    return @{
        Paths = @{
            RepoRoot = $raizNormalizada
            ModsRoot = $modsRoot
            PackagesRoot = $packagesRoot
            CacheRoot = $cacheRoot
            GameCacheFiles = $gameCacheFiles
            ModDllPath = $dllPath
            ModConfigSourcePath = $modConfigPath
            ModConfigPath = $modConfigPath
            ModRuntimeConfigPath = $modRuntimeConfigPath
            ServerProjectPath = $serverProjectPath
            ServerProjectDirectory = $serverProjectDirectory
            PackagePath = $packagePath
            Ts3GameExecutablePath = $gameExecutablePath
            OllamaExecutablePath = $ollamaExecutablePath
        }
        Package = @{
            Name = $packageName
            ResourceType = Obter-ValorObrigatorioComAlias -Tabela $configPacote -Chaves @('tipo_recurso', 'resource_type') -Contexto 'pacote_mod'
            ResourceGroup = Obter-ValorObrigatorioComAlias -Tabela $configPacote -Chaves @('grupo_recurso', 'resource_group') -Contexto 'pacote_mod'
            ResourceInstance = Obter-ValorObrigatorioComAlias -Tabela $configPacote -Chaves @('instancia_recurso', 'resource_instance') -Contexto 'pacote_mod'
        }
        Runtime = @{
            Ts3GameLaunchArguments = $gameLaunchArguments
            OllamaStartupTimeoutSeconds = $ollamaStartupTimeoutSeconds
            ServerStartupTimeoutSeconds = $serverStartupTimeoutSeconds
        }
        Source = @{
            BaseConfigPath = $caminhoConfigBase
            LocalConfigPath = $caminhoConfigLocal
        }
    }
}
