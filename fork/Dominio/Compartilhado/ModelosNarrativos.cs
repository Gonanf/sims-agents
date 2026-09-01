using System;
using System.Collections.Generic;

namespace NarradorPorEventos.Dominio
{
    /// <summary>
    /// Agrupa os caminhos de arquivos narrativos usados pelos fluxos do mod e do servidor.
    /// </summary>
    public sealed class ConfiguracaoArquivosNarrativos
    {
        private ConfiguracaoArquivosNarrativos()
        {
        }

        public CaminhoArquivoNarrativo CaminhoPedidos { get; private set; }
        public CaminhoArquivoNarrativo CaminhoRespostas { get; private set; }
        public CaminhoArquivoNarrativo CaminhoPerfilUsuario { get; private set; }
        public CaminhoArquivoNarrativo CaminhoContextoPrevio { get; private set; }
        public CaminhoArquivoNarrativo CaminhoLogNarrativo { get; private set; }
        public CaminhoArquivoNarrativo CaminhoLogExcecoes { get; private set; }

        public bool TemFilaNarrativaPrincipal
        {
            get { return CaminhoPedidos.EstaDefinido && CaminhoRespostas.EstaDefinido; }
        }

        public bool PodePersistirContextoPrevio
        {
            get { return CaminhoContextoPrevio.EstaDefinido; }
        }

        public static ConfiguracaoArquivosNarrativos Criar(
            string caminhoPedidos,
            string caminhoRespostas,
            string caminhoPerfilUsuario,
            string caminhoContextoPrevio,
            string caminhoLogNarrativo,
            string caminhoLogExcecoes)
        {
            ConfiguracaoArquivosNarrativos configuracao = new ConfiguracaoArquivosNarrativos();
            configuracao.CaminhoPedidos = CaminhoArquivoNarrativo.Criar(caminhoPedidos);
            configuracao.CaminhoRespostas = CaminhoArquivoNarrativo.Criar(caminhoRespostas);
            configuracao.CaminhoPerfilUsuario = CaminhoArquivoNarrativo.Criar(caminhoPerfilUsuario);
            configuracao.CaminhoContextoPrevio = CaminhoArquivoNarrativo.Criar(caminhoContextoPrevio);
            configuracao.CaminhoLogNarrativo = CaminhoArquivoNarrativo.Criar(caminhoLogNarrativo);
            configuracao.CaminhoLogExcecoes = CaminhoArquivoNarrativo.Criar(caminhoLogExcecoes);
            return configuracao;
        }
    }

    /// <summary>
    /// Configuração de conexão e modelos do provedor LLM usado pelos fluxos narrativos.
    /// </summary>
    public sealed class ConfiguracaoOllamaNarrativa
    {
        private ConfiguracaoOllamaNarrativa()
        {
        }

        public TextoNarrativo UrlEndpoint { get; private set; }
        public TextoNarrativo ModeloPrincipal { get; private set; }
        public TextoNarrativo ModeloPerfil { get; private set; }
        public int TimeoutSegundos { get; private set; }
        public IDictionary<string, object> OpcoesExecucao { get; private set; }

        public static ConfiguracaoOllamaNarrativa Criar(string urlEndpoint, string modeloPrincipal, string modeloPerfil, int timeoutSegundos, IDictionary<string, object> opcoesExecucao)
        {
            ConfiguracaoOllamaNarrativa configuracao = new ConfiguracaoOllamaNarrativa();
            configuracao.UrlEndpoint = TextoNarrativo.Criar(urlEndpoint);
            configuracao.ModeloPrincipal = TextoNarrativo.Criar(modeloPrincipal);
            configuracao.ModeloPerfil = TextoNarrativo.Criar(modeloPerfil);
            configuracao.TimeoutSegundos = timeoutSegundos;
            configuracao.OpcoesExecucao = ClonarMapa(opcoesExecucao);
            return configuracao;
        }

        public TextoNarrativo ObterModeloPerfilAtivo()
        {
            if (ModeloPerfil.EstaPreenchido)
                return ModeloPerfil;

            return ModeloPrincipal;
        }

        private static IDictionary<string, object> ClonarMapa(IDictionary<string, object> origem)
        {
            Dictionary<string, object> destino = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (origem == null)
                return destino;

            foreach (KeyValuePair<string, object> item in origem)
                destino[item.Key] = item.Value;

            return destino;
        }
    }

    /// <summary>
    /// Representa um pedido narrativo antes de ser serializado em JSON.
    /// </summary>
    public sealed class PedidoNarrativo
    {
        private PedidoNarrativo()
        {
        }

        public TextoNarrativo Id { get; private set; }
        public string TipoNarrativa { get; private set; }
        public TextoNarrativo SimAtivo { get; private set; }
        public TextoNarrativo HorarioReal { get; private set; }
        public TextoNarrativo Contexto { get; private set; }

        public bool EhPensamento
        {
            get { return global::NarradorPorEventos.Dominio.TipoNarrativa.Corresponde(TipoNarrativa, global::NarradorPorEventos.Dominio.TipoNarrativa.Pensamento); }
        }

        public bool EhConto
        {
            get { return global::NarradorPorEventos.Dominio.TipoNarrativa.Corresponde(TipoNarrativa, global::NarradorPorEventos.Dominio.TipoNarrativa.Conto); }
        }

        public string ChaveContextoPrevio
        {
            get { return global::NarradorPorEventos.Dominio.TipoNarrativa.ResolverChaveContextoPrevio(TipoNarrativa); }
        }

        public bool TemContextoPrevioAnexado
        {
            get { return Contexto.ContemIgnorandoMaiusculas(ChaveContextoPrevio + "="); }
        }

        public static PedidoNarrativo Criar(string id, string tipoNarrativa, string simAtivo, string horarioReal, string contexto)
        {
            PedidoNarrativo pedido = new PedidoNarrativo();
            pedido.Id = TextoNarrativo.Criar(id);
            pedido.TipoNarrativa = (tipoNarrativa ?? string.Empty).Trim();
            pedido.SimAtivo = TextoNarrativo.Criar(simAtivo);
            pedido.HorarioReal = TextoNarrativo.Criar(horarioReal);
            pedido.Contexto = TextoNarrativo.Criar(contexto);
            return pedido;
        }

        public static PedidoNarrativo CriarNovo(string tipoNarrativa, string simAtivo, string contexto, DateTime horarioAtual)
        {
            DateTime horarioBase = horarioAtual == DateTime.MinValue ? DateTime.Now : horarioAtual;
            return Criar(
                CriarIdPedido(horarioBase),
                tipoNarrativa,
                simAtivo,
                horarioBase.ToString("yyyy-MM-dd HH:mm:ss"),
                contexto);
        }

        public bool EhValido()
        {
            return !Id.EstaVazio
                && global::NarradorPorEventos.Dominio.TipoNarrativa.EhConhecido(TipoNarrativa)
                && !Contexto.EstaVazio;
        }

        public PedidoNarrativo ComContextoAtualizado(string contextoAtualizado)
        {
            return Criar(Id.Valor, TipoNarrativa, SimAtivo.Valor, HorarioReal.Valor, contextoAtualizado);
        }

        public PedidoNarrativo ComNarrativaAnterior(ContextoNarrativoPrevio contextoPrevio, bool incluirContextoPrevio)
        {
            if (!incluirContextoPrevio || contextoPrevio == null || string.IsNullOrEmpty(ChaveContextoPrevio) || TemContextoPrevioAnexado)
                return this;

            string narrativaAnterior = contextoPrevio.ObterNarrativaPorTipo(TipoNarrativa);
            TextoNarrativo narrativaNormalizada = TextoNarrativo.CriarCompactado((narrativaAnterior ?? string.Empty).Trim('"'));
            if (narrativaNormalizada.EstaVazio)
                return this;

            string contextoAtualizado = Contexto.EstaVazio
                ? ChaveContextoPrevio + "=" + narrativaNormalizada.Valor
                : Contexto.Valor + " | " + ChaveContextoPrevio + "=" + narrativaNormalizada.Valor;

            return ComContextoAtualizado(contextoAtualizado);
        }

        private static string CriarIdPedido(DateTime horarioAtual)
        {
            int semente = horarioAtual.Millisecond + horarioAtual.Second + (int)(horarioAtual.Ticks % 997);
            Random random = new Random(semente);
            int sufixo = random.Next(1000, 9999);
            return horarioAtual.Ticks.ToString() + "_" + sufixo.ToString();
        }
    }

    /// <summary>
    /// Representa o prompt efetivamente montado e enviado ao modelo.
    /// </summary>
    public sealed class PromptNarrativo
    {
        private PromptNarrativo()
        {
        }

        public string TipoNarrativa { get; private set; }
        public TemplateNarrativo Template { get; private set; }
        public TextoNarrativo TextoFinal { get; private set; }

        public static PromptNarrativo Criar(string tipoNarrativa, string template, string textoFinal)
        {
            PromptNarrativo prompt = new PromptNarrativo();
            prompt.TipoNarrativa = (tipoNarrativa ?? string.Empty).Trim();
            prompt.Template = TemplateNarrativo.Criar(template);
            prompt.TextoFinal = TextoNarrativo.Criar(textoFinal);
            return prompt;
        }

        public bool EhValido()
        {
            return global::NarradorPorEventos.Dominio.TipoNarrativa.EhConhecido(TipoNarrativa)
                && Template != null
                && Template.EstaDefinido
                && TextoFinal.EstaPreenchido;
        }
    }

    /// <summary>
    /// Representa a resposta final produzida para um pedido narrativo.
    /// </summary>
    public sealed class RespostaNarrativa
    {
        private RespostaNarrativa()
        {
        }

        public TextoNarrativo IdPedido { get; private set; }
        public string TipoNarrativa { get; private set; }
        public TextoNarrativo SimAtivo { get; private set; }
        public TextoNarrativo HorarioReal { get; private set; }
        public PromptNarrativo PromptAplicado { get; private set; }
        public TextoNarrativo TextoResposta { get; private set; }

        public bool EhTipoConhecido
        {
            get { return global::NarradorPorEventos.Dominio.TipoNarrativa.EhConhecido(TipoNarrativa); }
        }

        public static RespostaNarrativa Criar(string idPedido, string tipoNarrativa, string simAtivo, string horarioReal, PromptNarrativo promptAplicado, string textoResposta)
        {
            RespostaNarrativa resposta = new RespostaNarrativa();
            resposta.IdPedido = TextoNarrativo.Criar(idPedido);
            resposta.TipoNarrativa = (tipoNarrativa ?? string.Empty).Trim();
            resposta.SimAtivo = TextoNarrativo.Criar(simAtivo);
            resposta.HorarioReal = TextoNarrativo.Criar(horarioReal);
            resposta.PromptAplicado = promptAplicado;
            resposta.TextoResposta = TextoNarrativo.Criar(textoResposta);
            return resposta;
        }

        public bool EhValida()
        {
            return !IdPedido.EstaVazio
                && EhTipoConhecido
                && !TextoResposta.EstaVazio;
        }

        public bool PodeSerExibidaNoJogo()
        {
            return EhValida() && TextoNarrativo.CriarCompactado(TextoResposta.Valor).EstaPreenchido;
        }

        public string CriarChaveNotificacao()
        {
            if (!IdPedido.EstaVazio)
                return IdPedido.Valor;

            return (TipoNarrativa ?? string.Empty)
                + "|"
                + SimAtivo.Valor
                + "|"
                + TextoNarrativo.CriarCompactado(TextoResposta.Valor).Valor;
        }

        public string CriarMensagemExibicao()
        {
            string tipoExibicao = string.IsNullOrEmpty(TipoNarrativa) ? "narrativa" : TipoNarrativa;
            string prefixoSim = SimAtivo.EstaVazio ? string.Empty : SimAtivo.Valor + " - ";
            return prefixoSim + tipoExibicao + ": " + TextoNarrativo.CriarCompactado(TextoResposta.Valor).Valor;
        }
    }

    /// <summary>
    /// Representa o contexto narrativo anterior persistido para pensamento e conto.
    /// </summary>
    public sealed class ContextoNarrativoPrevio
    {
        private ContextoNarrativoPrevio()
        {
        }

        public TextoNarrativo PensamentoAnterior { get; private set; }
        public TextoNarrativo ContoAnterior { get; private set; }

        public bool EstaVazio
        {
            get { return PensamentoAnterior.EstaVazio && ContoAnterior.EstaVazio; }
        }

        public static ContextoNarrativoPrevio Criar(string pensamentoAnterior, string contoAnterior)
        {
            ContextoNarrativoPrevio contexto = new ContextoNarrativoPrevio();
            contexto.PensamentoAnterior = TextoNarrativo.Criar(pensamentoAnterior);
            contexto.ContoAnterior = TextoNarrativo.Criar(contoAnterior);
            return contexto;
        }

        public string ObterNarrativaPorTipo(string tipoNarrativa)
        {
            if (global::NarradorPorEventos.Dominio.TipoNarrativa.Corresponde(tipoNarrativa, global::NarradorPorEventos.Dominio.TipoNarrativa.Pensamento))
                return PensamentoAnterior.Valor;

            if (global::NarradorPorEventos.Dominio.TipoNarrativa.Corresponde(tipoNarrativa, global::NarradorPorEventos.Dominio.TipoNarrativa.Conto))
                return ContoAnterior.Valor;

            return string.Empty;
        }
    }

    /// <summary>
    /// Representa o perfil de usuario que influencia a geração de prompts e diretrizes.
    /// </summary>
    public sealed class PerfilUsuarioNarrativo
    {
        private PerfilUsuarioNarrativo()
        {
        }

        public TextoNarrativo FaixaEtaria { get; private set; }
        public IList<string> PersonalidadesNarrador { get; private set; }
        public IList<string> EstilosCriativos { get; private set; }
        public IList<string> ConteudosPermitidos { get; private set; }
        public IList<string> ConteudosBloqueados { get; private set; }
        public TextoNarrativo DiretrizUsuario { get; private set; }

        public static PerfilUsuarioNarrativo Criar(
            string faixaEtaria,
            IList<string> personalidadesNarrador,
            IList<string> estilosCriativos,
            IList<string> conteudosPermitidos,
            IList<string> conteudosBloqueados,
            string diretrizUsuario)
        {
            PerfilUsuarioNarrativo perfil = new PerfilUsuarioNarrativo();
            perfil.FaixaEtaria = TextoNarrativo.Criar(faixaEtaria);
            perfil.PersonalidadesNarrador = ClonarLista(personalidadesNarrador);
            perfil.EstilosCriativos = ClonarLista(estilosCriativos);
            perfil.ConteudosPermitidos = ClonarLista(conteudosPermitidos);
            perfil.ConteudosBloqueados = ClonarLista(conteudosBloqueados);
            perfil.DiretrizUsuario = TextoNarrativo.Criar(diretrizUsuario);
            return perfil;
        }

        public TextoNarrativo ObterDiretrizUsuarioCompactada()
        {
            return TextoNarrativo.CriarCompactado(DiretrizUsuario.Valor.Trim('"'));
        }

        public IDictionary<string, string> CriarVariaveisDePrompt()
        {
            Dictionary<string, string> variaveis = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            variaveis["faixa_etaria"] = FaixaEtaria.Valor;
            variaveis["personalidades_narrador"] = JuntarLista(PersonalidadesNarrador);
            variaveis["estilos_criativos"] = JuntarLista(EstilosCriativos);
            variaveis["conteudos_permitidos"] = JuntarLista(ConteudosPermitidos);
            variaveis["conteudos_bloqueados"] = JuntarLista(ConteudosBloqueados);
            variaveis["diretriz_usuario"] = ObterDiretrizUsuarioCompactada().Valor;
            return variaveis;
        }

        private static string JuntarLista(IList<string> valores)
        {
            if (valores == null || valores.Count == 0)
                return string.Empty;

            return string.Join(", ", new List<string>(valores).ToArray());
        }

        private static IList<string> ClonarLista(IList<string> origem)
        {
            List<string> destino = new List<string>();
            if (origem == null)
                return destino;

            for (int i = 0; i < origem.Count; i++)
            {
                string item = origem[i];
                if (string.IsNullOrEmpty(item))
                    continue;

                destino.Add(item);
            }

            return destino;
        }
    }
}