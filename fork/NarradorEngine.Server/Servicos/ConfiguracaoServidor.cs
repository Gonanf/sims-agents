using System.Text.Json;

namespace NarradorEngine.Server.Servicos;

/// <summary>
/// Fonte unica de configuracao runtime do servidor narrativo.
/// </summary>
/// <remarks>
/// <para>Resolve caminhos, templates, flags e opcoes do Ollama a partir de <c>NarradorPorEventos.config.json</c>.</para>
/// <para>Tambem mantem o estado minimo necessario para hot reload seguro, incluindo versao runtime e timestamp da ultima leitura valida.</para>
/// <example>
/// <code>
/// var configuracao = ConfiguracaoServidor.Carregar("NarradorPorEventos.config.json");
/// if (configuracao.RecarregarSeNecessario())
/// {
///     Console.WriteLine(configuracao.CriarResumoHotReload());
/// }
/// </code>
/// </example>
/// </remarks>
public sealed class ConfiguracaoServidor
{
    public const string NomeArquivoConfigPadrao = "NarradorPorEventos.config.json";
    private const string CaminhoRelativoMods = "Electronic Arts\\The Sims 3\\Mods";
    private const string UrlOllamaPadrao = "http://127.0.0.1:11434/api/generate";
    private const string ModeloOllamaPadrao = "deepseek-r1:7b";
    private static readonly IReadOnlyDictionary<string, string> VariaveisPromptPadrao = CriarVariaveisPromptPadrao();
    private static readonly IReadOnlyDictionary<string, object> OllamaOpcoesPadrao = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

    private DateTime _ultimaEscritaConfigUtc = DateTime.MinValue;
    private DateTime _ultimaEscritaConfigFalhaUtc = DateTime.MinValue;

    public string CaminhoConfigOrigem { get; private set; } = string.Empty;
    public string CaminhoPedidos { get; private set; } = string.Empty;
    public string CaminhoRespostas { get; private set; } = string.Empty;
    public string CaminhoPerfilUsuario { get; private set; } = string.Empty;
    public string CaminhoContextoPrevio { get; private set; } = string.Empty;
    public string UrlOllama { get; private set; } = UrlOllamaPadrao;
    public string ModeloOllama { get; private set; } = ModeloOllamaPadrao;
    public string ModeloOllamaPerfil { get; private set; } = string.Empty;
    public int TimeoutSegundos { get; private set; } = 45;
    public int IntervaloPollMs { get; private set; } = 1500;
    public bool LogarHotReload { get; private set; } = true;
    public bool IncluirContextoPrevio { get; private set; } = true;
    public PerfilNarrativoEscolhas PerfilNarrativo { get; private set; } = PerfilNarrativoEscolhas.CriarPadrao();
    public string DiretrizPerfilUsuario { get; private set; } = string.Empty;
    public string DiretrizNarrativaPerfil { get; private set; } = string.Empty;
    public IReadOnlyDictionary<string, string> VariaveisPrompt { get; private set; } = VariaveisPromptPadrao;
    public string TemplateBlocoContextual { get; private set; } = CriarTemplateBlocoContextualPadrao();
    public string TemplatePromptPensamento { get; private set; } = CriarTemplatePromptPensamentoPadrao();
    public string TemplatePromptConto { get; private set; } = CriarTemplatePromptContoPadrao();
    public string TemplatePromptPerfilNarrador { get; private set; } = CriarTemplatePromptPerfilNarradorPadrao();
    public string TemplateFallbackDiretrizPerfil { get; private set; } = CriarTemplateFallbackDiretrizPerfilPadrao();
    public IReadOnlyDictionary<string, object> OllamaOpcoes { get; private set; } = OllamaOpcoesPadrao;
    public long VersaoRuntime { get; private set; } = 1;

    /// <summary>
    /// Retorna o modelo efetivamente usado para gerar a diretriz de perfil.
    /// </summary>
    public string ModeloOllamaPerfilAtivo
    {
        get { return string.IsNullOrWhiteSpace(ModeloOllamaPerfil) ? ModeloOllama : ModeloOllamaPerfil; }
    }

    /// <summary>
    /// Carrega a configuracao do servidor a partir do caminho informado.
    /// </summary>
    /// <remarks>
    /// <para>Quando o arquivo nao existe, o servidor cai nos caminhos e defaults padrao sem falhar a inicializacao.</para>
    /// </remarks>
    public static ConfiguracaoServidor Carregar(string caminhoConfig)
    {
        var caminhoNormalizado = ResolverCaminhoConfig(caminhoConfig);
        var config = new ConfiguracaoServidor
        {
            CaminhoConfigOrigem = caminhoNormalizado
        };

        if (string.IsNullOrWhiteSpace(caminhoNormalizado) || !File.Exists(caminhoNormalizado))
        {
            config.DefinirCaminhosPadrao();
            return config;
        }

        using var documento = JsonDocument.Parse(File.ReadAllText(caminhoNormalizado));
        config.AplicarConfiguracao(documento.RootElement);
        config._ultimaEscritaConfigUtc = File.GetLastWriteTimeUtc(caminhoNormalizado);

        return config;
    }

    private void DefinirCaminhosPadrao()
    {
        var baseDir = ResolverDiretorioNarrativo(string.Empty);
        CaminhoPedidos = Path.Combine(baseDir, "NarradorPorEventos.pedidos.json");
        CaminhoRespostas = Path.Combine(baseDir, "NarradorPorEventos.respostas.json");
        CaminhoPerfilUsuario = Path.Combine(baseDir, "NarradorPorEventos.perfil.usuario.json");
        CaminhoContextoPrevio = Path.Combine(baseDir, "NarradorPorEventos.contexto.previo.json");
    }

    /// <summary>
    /// Atualiza em memoria a diretriz narrativa atualmente ativa para o perfil do usuario.
    /// </summary>
    public void DefinirDiretrizNarrativaPerfil(string diretriz)
    {
        DiretrizNarrativaPerfil = string.IsNullOrWhiteSpace(diretriz)
            ? string.Empty
            : diretriz.Trim();
    }

    /// <summary>
    /// Rele o arquivo de configuracao somente quando o timestamp muda desde a ultima leitura valida.
    /// </summary>
    /// <returns><c>true</c> quando uma nova configuracao foi aplicada em memoria.</returns>
    public bool RecarregarSeNecessario()
    {
        if (string.IsNullOrWhiteSpace(CaminhoConfigOrigem) || !File.Exists(CaminhoConfigOrigem))
        {
            return false;
        }

        var ultimaEscritaAtual = File.GetLastWriteTimeUtc(CaminhoConfigOrigem);
        if (ultimaEscritaAtual <= _ultimaEscritaConfigUtc || ultimaEscritaAtual == _ultimaEscritaConfigFalhaUtc)
        {
            return false;
        }

        try
        {
            using var documento = JsonDocument.Parse(File.ReadAllText(CaminhoConfigOrigem));
            var atualizada = new ConfiguracaoServidor
            {
                CaminhoConfigOrigem = CaminhoConfigOrigem
            };

            atualizada.AplicarConfiguracao(documento.RootElement);
            CopiarDe(atualizada);
            _ultimaEscritaConfigUtc = ultimaEscritaAtual;
            _ultimaEscritaConfigFalhaUtc = DateTime.MinValue;
            VersaoRuntime++;
            return true;
        }
        catch
        {
            _ultimaEscritaConfigFalhaUtc = ultimaEscritaAtual;
            throw;
        }
    }

    /// <summary>
    /// Gera um resumo curto, orientado a log, do estado atual da configuracao runtime.
    /// </summary>
    public string CriarResumoHotReload()
    {
        return $"modelo={ModeloOllama} | modelo_perfil={ModeloOllamaPerfilAtivo} | timeout={TimeoutSegundos}s | poll={IntervaloPollMs}ms | contexto_previo={(IncluirContextoPrevio ? "on" : "off")}";
    }

    /// <summary>
    /// Obtém uma variavel configurada em <c>prompt.variaveis.*</c>, com fallback opcional.
    /// </summary>
    public string ObterVariavelPrompt(string chave, string valorPadrao = "")
    {
        if (string.IsNullOrWhiteSpace(chave))
        {
            return valorPadrao;
        }

        if (VariaveisPrompt.TryGetValue(chave, out var valor) && !string.IsNullOrWhiteSpace(valor))
        {
            return valor;
        }

        return valorPadrao;
    }

    private void AplicarConfiguracao(JsonElement raiz)
    {
        var diretorioNarrativo = ResolverDiretorioNarrativo(LerTexto(raiz, "diretorio", "documentos_mod"));

        var arquivoPedidos = LerTextoOuPadrao(raiz, "NarradorPorEventos.pedidos.json", "arquivo", "pedidos");
        var arquivoRespostas = LerTextoOuPadrao(raiz, "NarradorPorEventos.respostas.json", "arquivo", "respostas");
        var arquivoPerfil = LerTextoOuPadrao(raiz, "NarradorPorEventos.perfil.usuario.json", "arquivo", "perfil_usuario");
        var arquivoContextoPrevio = LerTextoOuPadrao(raiz, "NarradorPorEventos.contexto.previo.json", "arquivo", "contexto_previo");

        CaminhoPedidos = ResolverCaminho(diretorioNarrativo, arquivoPedidos);
        CaminhoRespostas = ResolverCaminho(diretorioNarrativo, arquivoRespostas);
        CaminhoPerfilUsuario = ResolverCaminho(diretorioNarrativo, arquivoPerfil);
        CaminhoContextoPrevio = ResolverCaminho(diretorioNarrativo, arquivoContextoPrevio);
        UrlOllama = LerTextoOuPadrao(raiz, UrlOllamaPadrao, "ollama", "url");
        ModeloOllama = LerTextoOuPadrao(raiz, ModeloOllamaPadrao, "ollama", "modelo");
        ModeloOllamaPerfil = LerTextoOuPadrao(raiz, string.Empty, "ollama", "modelo_perfil");
        TimeoutSegundos = LerInt(raiz, 45, "ollama", "timeout_segundos");
        IntervaloPollMs = LerInt(raiz, 1500, "servidor", "intervalo_poll_ms");
        LogarHotReload = LerBool(raiz, true, "servidor", "logar_hotreload");
        IncluirContextoPrevio = LerBool(raiz, true, "feature", "incluir_contexto_previo");
        PerfilNarrativo = CarregarPerfilNarrativo(raiz);
        DiretrizPerfilUsuario = LerTextoOuPadrao(raiz, string.Empty, "perfil_usuario", "diretriz");
        VariaveisPrompt = LerVariaveisPrompt(raiz);
        TemplateBlocoContextual = LerBlocoTextoOuPadrao(raiz, CriarTemplateBlocoContextualPadrao(), "prompt", "contexto", "template");
        TemplatePromptPensamento = LerBlocoTextoOuPadrao(raiz, CriarTemplatePromptPensamentoPadrao(), "prompt", "pensamento", "template");
        TemplatePromptConto = LerBlocoTextoOuPadrao(raiz, CriarTemplatePromptContoPadrao(), "prompt", "conto", "template");
        TemplatePromptPerfilNarrador = LerBlocoTextoOuPadrao(raiz, CriarTemplatePromptPerfilNarradorPadrao(), "prompt", "perfil", "template_geracao");
        TemplateFallbackDiretrizPerfil = LerBlocoTextoOuPadrao(raiz, CriarTemplateFallbackDiretrizPerfilPadrao(), "prompt", "perfil", "template_fallback");
        OllamaOpcoes = LerObjetoGenerico(raiz, "ollama", "opcoes");

        if (IntervaloPollMs < 250)
        {
            IntervaloPollMs = 250;
        }

        if (TimeoutSegundos < 5)
        {
            TimeoutSegundos = 5;
        }
    }

    private void CopiarDe(ConfiguracaoServidor origem)
    {
        CaminhoConfigOrigem = origem.CaminhoConfigOrigem;
        CaminhoPedidos = origem.CaminhoPedidos;
        CaminhoRespostas = origem.CaminhoRespostas;
        CaminhoPerfilUsuario = origem.CaminhoPerfilUsuario;
        CaminhoContextoPrevio = origem.CaminhoContextoPrevio;
        UrlOllama = origem.UrlOllama;
        ModeloOllama = origem.ModeloOllama;
        ModeloOllamaPerfil = origem.ModeloOllamaPerfil;
        TimeoutSegundos = origem.TimeoutSegundos;
        IntervaloPollMs = origem.IntervaloPollMs;
        LogarHotReload = origem.LogarHotReload;
        IncluirContextoPrevio = origem.IncluirContextoPrevio;
        PerfilNarrativo = origem.PerfilNarrativo;
        DiretrizPerfilUsuario = origem.DiretrizPerfilUsuario;
        VariaveisPrompt = origem.VariaveisPrompt;
        TemplateBlocoContextual = origem.TemplateBlocoContextual;
        TemplatePromptPensamento = origem.TemplatePromptPensamento;
        TemplatePromptConto = origem.TemplatePromptConto;
        TemplatePromptPerfilNarrador = origem.TemplatePromptPerfilNarrador;
        TemplateFallbackDiretrizPerfil = origem.TemplateFallbackDiretrizPerfil;
        OllamaOpcoes = origem.OllamaOpcoes;
    }

    private static string ResolverCaminhoConfig(string caminhoConfig)
    {
        if (string.IsNullOrWhiteSpace(caminhoConfig))
        {
            return string.Empty;
        }

        return Path.GetFullPath(ExpandirVariaveis(caminhoConfig));
    }

    private static string LerTexto(JsonElement raiz, params string[] caminho)
    {
        if (!TentarObterElemento(raiz, out var elemento, caminho))
        {
            return string.Empty;
        }

        return ConverterElementoParaTexto(elemento);
    }

    private static string LerTextoOuPadrao(JsonElement raiz, string valorPadrao, params string[] caminho)
    {
        var texto = LerTexto(raiz, caminho);
        return string.IsNullOrWhiteSpace(texto) ? valorPadrao : texto;
    }

    private static int LerInt(JsonElement raiz, int valorPadrao, params string[] caminho)
    {
        var bruto = LerTexto(raiz, caminho);
        return int.TryParse(bruto, out var valor) ? valor : valorPadrao;
    }

    private static bool LerBool(JsonElement raiz, bool valorPadrao, params string[] caminho)
    {
        var bruto = LerTexto(raiz, caminho);
        return bool.TryParse(bruto, out var valor) ? valor : valorPadrao;
    }

    private static string LerBlocoTextoOuPadrao(JsonElement raiz, string valorPadrao, params string[] caminho)
    {
        var texto = LerTexto(raiz, caminho);
        return string.IsNullOrWhiteSpace(texto) ? valorPadrao : texto;
    }

    private static IReadOnlyList<string> LerListaTexto(JsonElement raiz, params string[] caminho)
    {
        if (!TentarObterElemento(raiz, out var valor, caminho))
        {
            return Array.Empty<string>();
        }

        if (valor.ValueKind == JsonValueKind.Array)
        {
            var itens = new List<string>();
            foreach (var item in valor.EnumerateArray())
            {
                var texto = ConverterElementoParaTexto(item);
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    itens.Add(texto.Trim());
                }
            }

            return itens;
        }

        var bruto = ConverterElementoParaTexto(valor);
        if (string.IsNullOrWhiteSpace(bruto))
        {
            return Array.Empty<string>();
        }

        return bruto
            .Split(new[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.Trim())
            .Where(v => !string.IsNullOrWhiteSpace(v))
            .ToArray();
    }

    private static IReadOnlyDictionary<string, string> LerVariaveisPrompt(JsonElement raiz)
    {
        var mescladas = new Dictionary<string, string>(VariaveisPromptPadrao, StringComparer.OrdinalIgnoreCase);
        if (!TentarObterElemento(raiz, out var variaveis, "prompt", "variaveis") || variaveis.ValueKind != JsonValueKind.Object)
        {
            return mescladas;
        }

        AdicionarVariaveisPrompt(mescladas, variaveis, string.Empty);
        return mescladas;
    }

    private static void AdicionarVariaveisPrompt(Dictionary<string, string> destino, JsonElement objeto, string prefixo)
    {
        foreach (var propriedade in objeto.EnumerateObject())
        {
            var nome = string.IsNullOrWhiteSpace(prefixo)
                ? propriedade.Name
                : prefixo + "_" + propriedade.Name;

            if (propriedade.Value.ValueKind == JsonValueKind.Object)
            {
                AdicionarVariaveisPrompt(destino, propriedade.Value, nome);
                continue;
            }

            destino[nome] = ConverterElementoParaTexto(propriedade.Value);
        }
    }

    private static IReadOnlyDictionary<string, object> LerObjetoGenerico(JsonElement raiz, params string[] caminho)
    {
        if (!TentarObterElemento(raiz, out var elemento, caminho) || elemento.ValueKind != JsonValueKind.Object)
        {
            return OllamaOpcoesPadrao;
        }

        var valores = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        foreach (var propriedade in elemento.EnumerateObject())
        {
            valores[propriedade.Name] = ConverterValorJson(propriedade.Value);
        }

        return valores;
    }

    private static object ConverterValorJson(JsonElement valor)
    {
        switch (valor.ValueKind)
        {
            case JsonValueKind.String:
                return valor.GetString();
            case JsonValueKind.Number:
                if (valor.TryGetInt64(out var inteiro))
                {
                    return inteiro;
                }

                if (valor.TryGetDouble(out var real))
                {
                    return real;
                }

                return valor.ToString();
            case JsonValueKind.True:
            case JsonValueKind.False:
                return valor.GetBoolean();
            case JsonValueKind.Array:
                return valor.EnumerateArray().Select(ConverterValorJson).ToList();
            case JsonValueKind.Object:
                var objeto = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                foreach (var propriedade in valor.EnumerateObject())
                {
                    objeto[propriedade.Name] = ConverterValorJson(propriedade.Value);
                }

                return objeto;
            default:
                return null;
        }
    }

    private static bool TentarObterElemento(JsonElement raiz, out JsonElement elemento, params string[] caminho)
    {
        elemento = raiz;
        foreach (var segmento in caminho)
        {
            if (elemento.ValueKind != JsonValueKind.Object || !elemento.TryGetProperty(segmento, out elemento))
            {
                elemento = default;
                return false;
            }
        }

        return true;
    }

    private static string ConverterElementoParaTexto(JsonElement valor)
    {
        switch (valor.ValueKind)
        {
            case JsonValueKind.String:
                return valor.GetString() ?? string.Empty;
            case JsonValueKind.Array:
                return string.Join(Environment.NewLine, valor.EnumerateArray().Select(ConverterElementoParaTexto));
            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
                return string.Empty;
            default:
                return valor.ToString();
        }
    }

    private static PerfilNarrativoEscolhas CarregarPerfilNarrativo(JsonElement raiz)
    {
        var faixaEtaria = LerTextoOuPadrao(raiz, "Adulto", "perfil_usuario", "faixa_etaria");
        var personalidades = LerListaTexto(raiz, "perfil_usuario", "personalidades_narrador");
        var estilos = LerListaTexto(raiz, "perfil_usuario", "estilos_criativos");
        var conteudosPermitidos = LerListaTexto(raiz, "perfil_usuario", "conteudos_permitidos");
        var conteudosBloqueados = LerListaTexto(raiz, "perfil_usuario", "conteudos_bloqueados");

        return PerfilNarrativoEscolhas.Criar(
            faixaEtaria,
            ConversorPerfilNarrativo.ConverterListaEnums(personalidades, PersonalidadeNarrador.Dramatico),
            ConversorPerfilNarrativo.ConverterListaEnums(estilos, EstiloCriativoNarrativo.DramaSocial),
            ConversorPerfilNarrativo.ConverterListaEnums<ConteudoNarrativo>(conteudosPermitidos),
            ConversorPerfilNarrativo.ConverterListaEnums<ConteudoNarrativo>(conteudosBloqueados));
    }

    private static string ResolverCaminho(string diretorio, string arquivoOuCaminho)
    {
        var caminho = ExpandirVariaveis(arquivoOuCaminho);
        if (Path.IsPathRooted(caminho))
        {
            return caminho;
        }

        return Path.Combine(diretorio, caminho);
    }

    private static string ResolverDiretorioNarrativo(string diretorioConfigurado)
    {
        var diretorioExpandido = ExpandirVariaveis(diretorioConfigurado);
        if (!string.IsNullOrWhiteSpace(diretorioExpandido))
        {
            if (Path.IsPathRooted(diretorioExpandido))
            {
                return diretorioExpandido;
            }

            var baseDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(baseDir, diretorioExpandido);
        }

        var documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return Path.Combine(documentos, CaminhoRelativoMods);
    }

    private static string ExpandirVariaveis(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            return string.Empty;
        }

        return Environment.ExpandEnvironmentVariables(valor);
    }

    private static IReadOnlyDictionary<string, string> CriarVariaveisPromptPadrao()
    {
        return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["tom_pensamento"] = "Menos relatório, mais fofoca social do bairro.",
            ["tom_conto"] = "Menos relatório, mais fofoca social com personalidade e conflito.",
            ["diretriz_perfil_padrao"] = "manter estilo social-dramático de The Sims 3 com foco em naturalidade.",
            ["rotulo_diretriz_perfil"] = "Diretriz criativa do perfil do usuário",
            ["rotulo_diretriz_usuario"] = "Diretriz adicional do usuário",
            ["rotulo_foco_emocional"] = "Foco emocional"
        };
    }

    private static string CriarTemplateBlocoContextualPadrao()
    {
        return string.Join(Environment.NewLine, new[]
        {
            "{diretriz_perfil_formatada}",
            string.Empty,
            "{foco_emocional_formatado}",
            "{diretriz_por_tracos}",
            string.Empty,
            "{contexto}"
        });
    }

    private static string CriarTemplatePromptPensamentoPadrao()
    {
        return string.Join(Environment.NewLine, new[]
        {
            "Você narra The Sims 3 em português brasileiro.",
            "Escreva um pensamento interno de {sim_ativo} com voz de jogo: espontânea, viva e criativa.",
            "Use apenas fatos do contexto. Não invente personagens, lugares, parentesco, idade ou eventos.",
            "Respeite todos os limites numéricos e enums do contexto: idade_*, humor_*, necessidades_*, carreira_*, habilidade_* e classe_economica_*.",
            "Não faça relatório literal de dados técnicos. Foque no sentimento e no impacto social do momento, alinhado à diretriz de perfil.",
            "{tom_pensamento}",
            "Não mencionar lote, mundo, enum ou números, exceto se for essencial para o pensamento.",
            "Uma única frase, até 220 caracteres, sem aspas e sem markdown.",
            "{bloco_contextual}",
            string.Empty,
            "Pensamento de {sim_ativo}:"
        });
    }

    private static string CriarTemplatePromptContoPadrao()
    {
        return string.Join(Environment.NewLine, new[]
        {
            "Você narra The Sims 3 em português brasileiro.",
            "Escreva um conto curto sobre o momento atual de {sim_ativo} com foco social no estilo de The Sims.",
            "Use apenas fatos do contexto. Não invente personagens, lugares, parentesco, idade ou eventos.",
            "Respeite todos os limites numéricos e enums do contexto: idade_*, humor_*, necessidades_*, carreira_*, habilidade_* e classe_economica_*.",
            "Use a diretriz de perfil para definir tom, humor e intensidade; em luto, conflito sensível ou tristeza, preserve respeito e sensibilidade.",
            "Evite lista de atributos e evite repetir detalhes neutros sem impacto narrativo.",
            "{tom_conto}",
            "Escreva de 3 a 5 frases, sem aspas e sem markdown.",
            "{bloco_contextual}",
            string.Empty,
            "Narrativa:"
        });
    }

    private static string CriarTemplatePromptPerfilNarradorPadrao()
    {
        return string.Join(Environment.NewLine, new[]
        {
            "Você é um calibrador de estilo narrativo para The Sims 3 em português brasileiro.",
            "Sua tarefa é converter escolhas de enum do usuário em uma diretriz única de escrita, clara e prática.",
            "Retorne somente uma diretriz em texto simples, sem markdown, sem listas e sem aspas.",
            "Não use contexto do jogo aqui; use apenas as escolhas do perfil.",
            "Mantenha a diretriz entre 280 e 520 caracteres, com foco em voz do narrador, nível de ousadia e limites de conteúdo.",
            string.Empty,
            "Perfil do usuário:",
            "- faixa_etaria: {faixa_etaria}",
            "- personalidades_narrador: {personalidades_narrador}",
            "- estilos_criativos: {estilos_criativos}",
            "- conteudos_permitidos: {conteudos_permitidos}",
            "- conteudos_bloqueados: {conteudos_bloqueados}",
            "{diretriz_usuario_formatada}",
            string.Empty,
            "Diretriz narrativa final:"
        });
    }

    private static string CriarTemplateFallbackDiretrizPerfilPadrao()
    {
        return "Narrador com personalidade [{personalidades_narrador}], estilo [{estilos_criativos}], faixa etária [{faixa_etaria}], permitido [{conteudos_permitidos}] e bloqueado [{conteudos_bloqueados}].{diretriz_usuario_sufixo}";
    }
}
