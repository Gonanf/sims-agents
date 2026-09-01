using NarradorPorEventos.Dominio;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio
{
    /// <summary>
    /// Visão de domínio da configuração efetiva usada pelo mod TS3.
    /// </summary>
    internal sealed class ConfiguracaoModNarrativa
    {
        private ConfiguracaoModNarrativa()
        {
        }

        public bool AtivarProcessamentoNarrativo { get; private set; }
        public int QuantidadeEventosPensamento { get; private set; }
        public int QuantidadeEventosConto { get; private set; }
        public int LimiteResumoPensamento { get; private set; }
        public int LimiteResumoConto { get; private set; }
        public int LimiteCaracteresContexto { get; private set; }
        public ConfiguracaoArquivosNarrativos Arquivos { get; private set; }
        public ConfiguracaoOllamaNarrativa Ollama { get; private set; }

        public bool TemInfraNarrativaMinima
        {
            get { return AtivarProcessamentoNarrativo && Arquivos.TemFilaNarrativaPrincipal; }
        }

        public static ConfiguracaoModNarrativa Criar(ConfiguracaoCentral configuracao)
        {
            ConfiguracaoModNarrativa configuracaoDominio = new ConfiguracaoModNarrativa();
            configuracaoDominio.AtivarProcessamentoNarrativo = configuracao.AtivarProcessamentoNarrativo;
            configuracaoDominio.QuantidadeEventosPensamento = configuracao.QuantidadeEventosPensamento;
            configuracaoDominio.QuantidadeEventosConto = configuracao.QuantidadeEventosConto;
            configuracaoDominio.LimiteResumoPensamento = configuracao.LimiteResumoPensamento;
            configuracaoDominio.LimiteResumoConto = configuracao.LimiteResumoConto;
            configuracaoDominio.LimiteCaracteresContexto = configuracao.LimiteCaracteresContexto;
            configuracaoDominio.Arquivos = ConfiguracaoArquivosNarrativos.Criar(
                configuracao.CaminhoPedidos,
                configuracao.CaminhoRespostas,
                configuracao.CaminhoPerfilUsuario,
                configuracao.CaminhoContextoPrevio,
                configuracao.CaminhoLogNarrativo,
                configuracao.CaminhoLogExcecoes);
            configuracaoDominio.Ollama = ConfiguracaoOllamaNarrativa.Criar(
                configuracao.OllamaUrl,
                configuracao.OllamaModelo,
                string.Empty,
                configuracao.OllamaTimeoutSegundos,
                null);
            return configuracaoDominio;
        }
    }
}