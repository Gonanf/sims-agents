using NarradorEngine.Server.Servicos;
using NarradorPorEventos.Dominio;
using System.Text.RegularExpressions;

namespace NarradorEngine.Server.Dominio
{
    /// <summary>
    /// Visão de domínio da configuração efetiva usada pelo servidor narrativo.
    /// </summary>
    internal sealed class ConfiguracaoServidorNarrativa
    {
        private ConfiguracaoServidorNarrativa()
        {
        }

        public ConfiguracaoArquivosNarrativos Arquivos { get; private set; }
        public ConfiguracaoOllamaNarrativa Ollama { get; private set; }
        public ConfiguracaoPromptNarrativoServidor Prompt { get; private set; }
        public PerfilUsuarioNarrativo PerfilUsuario { get; private set; }
        public TextoNarrativo DiretrizNarrativaPerfilAtiva { get; private set; }
        public bool IncluirContextoPrevio { get; private set; }
        public bool LogarHotReload { get; private set; }
        public int IntervaloPollMs { get; private set; }
        public IReadOnlyDictionary<string, object> OllamaOpcoes
        {
            get { return new Dictionary<string, object>(Ollama.OpcoesExecucao); }
        }

        public string UrlOllama
        {
            get { return Ollama.UrlEndpoint.Valor; }
        }

        public string ModeloOllama
        {
            get { return Ollama.ModeloPrincipal.Valor; }
        }

        public string ModeloOllamaPerfilAtivo
        {
            get { return Ollama.ObterModeloPerfilAtivo().Valor; }
        }

        public int TimeoutSegundos
        {
            get { return Ollama.TimeoutSegundos; }
        }

        public static ConfiguracaoServidorNarrativa Criar(ConfiguracaoServidor configuracao)
        {
            ConfiguracaoServidorNarrativa configuracaoDominio = new ConfiguracaoServidorNarrativa();
            configuracaoDominio.Arquivos = ConfiguracaoArquivosNarrativos.Criar(
                configuracao.CaminhoPedidos,
                configuracao.CaminhoRespostas,
                configuracao.CaminhoPerfilUsuario,
                configuracao.CaminhoContextoPrevio,
                string.Empty,
                string.Empty);
            configuracaoDominio.PerfilUsuario = PerfilUsuarioNarrativo.Criar(
                configuracao.PerfilNarrativo.FaixaEtaria,
                ConverterLista(configuracao.PerfilNarrativo.PersonalidadesNarrador),
                ConverterLista(configuracao.PerfilNarrativo.EstilosCriativos),
                ConverterLista(configuracao.PerfilNarrativo.ConteudosPermitidos),
                ConverterLista(configuracao.PerfilNarrativo.ConteudosBloqueados),
                configuracao.DiretrizPerfilUsuario);
            configuracaoDominio.DiretrizNarrativaPerfilAtiva = TextoNarrativo.Criar(configuracao.DiretrizNarrativaPerfil);
            configuracaoDominio.IncluirContextoPrevio = configuracao.IncluirContextoPrevio;
            configuracaoDominio.LogarHotReload = configuracao.LogarHotReload;
            configuracaoDominio.Ollama = ConfiguracaoOllamaNarrativa.Criar(
                configuracao.UrlOllama,
                configuracao.ModeloOllama,
                configuracao.ModeloOllamaPerfilAtivo,
                configuracao.TimeoutSegundos,
                CopiarOpcoes(configuracao.OllamaOpcoes));
            configuracaoDominio.IntervaloPollMs = configuracao.IntervaloPollMs;
            configuracaoDominio.Prompt = ConfiguracaoPromptNarrativoServidor.Criar(
                CopiarVariaveis(configuracao.VariaveisPrompt),
                configuracao.TemplateBlocoContextual,
                configuracao.TemplatePromptPensamento,
                configuracao.TemplatePromptConto,
                configuracao.TemplatePromptPerfilNarrador,
                configuracao.TemplateFallbackDiretrizPerfil);
            return configuracaoDominio;
        }

        private static IDictionary<string, string> CopiarVariaveis(IReadOnlyDictionary<string, string> origem)
        {
            Dictionary<string, string> destino = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            if (origem == null)
                return destino;

            foreach (KeyValuePair<string, string> item in origem)
                destino[item.Key] = item.Value ?? string.Empty;

            return destino;
        }

        private static IDictionary<string, object> CopiarOpcoes(IReadOnlyDictionary<string, object> origem)
        {
            Dictionary<string, object> destino = new Dictionary<string, object>(System.StringComparer.OrdinalIgnoreCase);
            if (origem == null)
                return destino;

            foreach (KeyValuePair<string, object> item in origem)
                destino[item.Key] = item.Value;

            return destino;
        }

        private static IList<string> ConverterLista<T>(IReadOnlyList<T> origem)
        {
            List<string> destino = new List<string>();
            if (origem == null)
                return destino;

            for (int i = 0; i < origem.Count; i++)
            {
                T item = origem[i];
                if (item == null)
                    continue;

                destino.Add(item.ToString());
            }

            return destino;
        }
    }

    /// <summary>
    /// Agrega templates e variáveis do servidor para composição de prompts no domínio.
    /// </summary>
    internal sealed class ConfiguracaoPromptNarrativoServidor
    {
        private static readonly Regex RegexPlaceholder = new Regex("\\{(?<token>[A-Za-z0-9_]+)\\}", RegexOptions.Compiled);

        private ConfiguracaoPromptNarrativoServidor()
        {
        }

        public IDictionary<string, string> VariaveisPrompt { get; private set; }
        public TemplateNarrativo TemplateBlocoContextual { get; private set; }
        public TemplateNarrativo TemplatePromptPensamento { get; private set; }
        public TemplateNarrativo TemplatePromptConto { get; private set; }
        public TemplateNarrativo TemplatePromptPerfil { get; private set; }
        public TemplateNarrativo TemplateFallbackPerfil { get; private set; }

        public static ConfiguracaoPromptNarrativoServidor Criar(
            IDictionary<string, string> variaveisPrompt,
            string templateBlocoContextual,
            string templatePromptPensamento,
            string templatePromptConto,
            string templatePromptPerfil,
            string templateFallbackPerfil)
        {
            ConfiguracaoPromptNarrativoServidor configuracao = new ConfiguracaoPromptNarrativoServidor();
            configuracao.VariaveisPrompt = CopiarVariaveis(variaveisPrompt);
            configuracao.TemplateBlocoContextual = TemplateNarrativo.Criar(templateBlocoContextual);
            configuracao.TemplatePromptPensamento = TemplateNarrativo.Criar(templatePromptPensamento);
            configuracao.TemplatePromptConto = TemplateNarrativo.Criar(templatePromptConto);
            configuracao.TemplatePromptPerfil = TemplateNarrativo.Criar(templatePromptPerfil);
            configuracao.TemplateFallbackPerfil = TemplateNarrativo.Criar(templateFallbackPerfil);
            return configuracao;
        }

        public PromptNarrativo CriarPromptPrincipal(PedidoNarrativo pedido, PerfilUsuarioNarrativo perfilUsuario, string diretrizPerfilAtiva, string focoEmocional, string diretrizPorTracos)
        {
            TemplateNarrativo templatePrincipal = ResolverTemplatePrincipal(pedido);
            Dictionary<string, string> variaveis = CriarVariaveisBase(perfilUsuario);
            variaveis["sim_ativo"] = pedido != null ? pedido.SimAtivo.Valor : string.Empty;
            variaveis["bloco_contextual"] = CriarBlocoContextual(pedido, perfilUsuario, diretrizPerfilAtiva, focoEmocional, diretrizPorTracos);

            return PromptNarrativo.Criar(
                pedido != null ? pedido.TipoNarrativa : string.Empty,
                templatePrincipal.Conteudo,
                InterpolarTemplate(templatePrincipal.Conteudo, variaveis));
        }

        public string CriarPromptPerfilNarrador(PerfilUsuarioNarrativo perfilUsuario)
        {
            return InterpolarTemplate(TemplatePromptPerfil.Conteudo, CriarVariaveisBase(perfilUsuario));
        }

        public string CriarDiretrizFallbackPerfilNarrador(PerfilUsuarioNarrativo perfilUsuario)
        {
            return InterpolarTemplate(TemplateFallbackPerfil.Conteudo, CriarVariaveisBase(perfilUsuario));
        }

        private TemplateNarrativo ResolverTemplatePrincipal(PedidoNarrativo pedido)
        {
            if (pedido != null && pedido.EhPensamento)
                return TemplatePromptPensamento;

            return TemplatePromptConto;
        }

        private string CriarBlocoContextual(PedidoNarrativo pedido, PerfilUsuarioNarrativo perfilUsuario, string diretrizPerfilAtiva, string focoEmocional, string diretrizPorTracos)
        {
            Dictionary<string, string> variaveis = CriarVariaveisBase(perfilUsuario);
            string diretrizPerfilProcessada = ResolverDiretrizPerfilAtiva(diretrizPerfilAtiva);

            variaveis["contexto"] = pedido != null ? pedido.Contexto.Valor : string.Empty;
            variaveis["diretriz_perfil"] = diretrizPerfilProcessada;
            variaveis["diretriz_perfil_formatada"] = FormatarLinha("rotulo_diretriz_perfil", diretrizPerfilProcessada);
            variaveis["foco_emocional"] = TextoNarrativo.Criar(focoEmocional).Valor;
            variaveis["foco_emocional_formatada"] = FormatarLinha("rotulo_foco_emocional", focoEmocional);
            variaveis["foco_emocional_formatado"] = variaveis["foco_emocional_formatada"];
            variaveis["diretriz_por_tracos"] = TextoNarrativo.Criar(diretrizPorTracos).Valor;

            return InterpolarTemplate(TemplateBlocoContextual.Conteudo, variaveis);
        }

        private string ResolverDiretrizPerfilAtiva(string diretrizPerfilAtiva)
        {
            TextoNarrativo diretrizAtiva = TextoNarrativo.Criar(diretrizPerfilAtiva);
            if (diretrizAtiva.EstaPreenchido)
                return diretrizAtiva.Valor;

            return ObterVariavel("diretriz_perfil_padrao", "manter estilo social-dramático de The Sims 3 com foco em naturalidade.");
        }

        private Dictionary<string, string> CriarVariaveisBase(PerfilUsuarioNarrativo perfilUsuario)
        {
            Dictionary<string, string> variaveis = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (KeyValuePair<string, string> item in VariaveisPrompt)
                variaveis[item.Key] = item.Value ?? string.Empty;

            variaveis["diretriz_usuario"] = string.Empty;
            variaveis["diretriz_usuario_formatada"] = string.Empty;
            variaveis["diretriz_usuario_sufixo"] = string.Empty;

            if (perfilUsuario == null)
                return variaveis;

            foreach (KeyValuePair<string, string> item in perfilUsuario.CriarVariaveisDePrompt())
                variaveis[item.Key] = item.Value ?? string.Empty;

            string diretrizUsuario = perfilUsuario.ObterDiretrizUsuarioCompactada().Valor;
            variaveis["diretriz_usuario"] = diretrizUsuario;
            variaveis["diretriz_usuario_formatada"] = FormatarLinha("rotulo_diretriz_usuario", diretrizUsuario);
            variaveis["diretriz_usuario_sufixo"] = CriarSufixoDiretrizUsuario(diretrizUsuario);

            return variaveis;
        }

        private static string CriarSufixoDiretrizUsuario(string diretrizUsuario)
        {
            TextoNarrativo diretriz = TextoNarrativo.Criar(diretrizUsuario);
            if (diretriz.EstaVazio)
                return string.Empty;

            return " Diretriz adicional do usuário: " + diretriz.Valor + ".";
        }

        private string FormatarLinha(string chaveRotulo, string valor)
        {
            TextoNarrativo texto = TextoNarrativo.Criar(valor);
            if (texto.EstaVazio)
                return string.Empty;

            string rotulo = ObterVariavel(chaveRotulo, string.Empty);
            if (string.IsNullOrEmpty(rotulo))
                return texto.Valor;

            return TextoNarrativo.Criar(rotulo).Valor + ": " + texto.Valor;
        }

        private string ObterVariavel(string chave, string padrao)
        {
            if (string.IsNullOrEmpty(chave))
                return padrao ?? string.Empty;

            string valor;
            if (VariaveisPrompt != null && VariaveisPrompt.TryGetValue(chave, out valor) && !string.IsNullOrEmpty(valor))
                return valor;

            return padrao ?? string.Empty;
        }

        private static IDictionary<string, string> CopiarVariaveis(IDictionary<string, string> origem)
        {
            Dictionary<string, string> destino = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (origem == null)
                return destino;

            foreach (KeyValuePair<string, string> item in origem)
                destino[item.Key] = item.Value ?? string.Empty;

            return destino;
        }

        private static string InterpolarTemplate(string template, IReadOnlyDictionary<string, string> variaveis)
        {
            if (string.IsNullOrEmpty(template))
                return string.Empty;

            string interpolado = RegexPlaceholder.Replace(template, delegate (Match match)
            {
                string token = match.Groups["token"].Value;
                string valor;
                return variaveis != null && variaveis.TryGetValue(token, out valor) ? valor ?? string.Empty : match.Value;
            });

            return NormalizarBloco(interpolado);
        }

        private static string NormalizarBloco(string texto)
        {
            string[] linhas = (texto ?? string.Empty)
                .Replace("\r\n", "\n")
                .Replace('\r', '\n')
                .Split('\n');

            List<string> resultado = new List<string>();
            bool ultimaLinhaVazia = true;

            for (int i = 0; i < linhas.Length; i++)
            {
                string textoLinha = linhas[i].TrimEnd();
                if (string.IsNullOrWhiteSpace(textoLinha))
                {
                    if (ultimaLinhaVazia)
                        continue;

                    resultado.Add(string.Empty);
                    ultimaLinhaVazia = true;
                    continue;
                }

                resultado.Add(textoLinha);
                ultimaLinhaVazia = false;
            }

            while (resultado.Count > 0 && string.IsNullOrWhiteSpace(resultado[resultado.Count - 1]))
                resultado.RemoveAt(resultado.Count - 1);

            return string.Join(Environment.NewLine, resultado.ToArray());
        }

    }
}