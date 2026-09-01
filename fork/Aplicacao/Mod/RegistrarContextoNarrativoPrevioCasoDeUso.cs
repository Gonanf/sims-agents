using NarradorPorEventos.Dominio;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod
{
    internal sealed class RegistrarContextoNarrativoPrevioCasoDeUso
    {
        private readonly IAdaptadorArquivos _arquivos;
        private readonly ConfiguracaoModNarrativa _configuracao;

        public RegistrarContextoNarrativoPrevioCasoDeUso(IAdaptadorArquivos arquivos, ConfiguracaoCentral configuracao)
        {
            _arquivos = arquivos;
            _configuracao = ConfiguracaoModNarrativa.Criar(configuracao);
        }

        public RegistrarContextoNarrativoPrevioSaidaDto Executar(RegistrarContextoNarrativoPrevioEntradaDto entrada)
        {
            RegistrarContextoNarrativoPrevioSaidaDto saida = new RegistrarContextoNarrativoPrevioSaidaDto();
            if (entrada == null || entrada.Resposta == null || !entrada.Resposta.EhValida() || !_configuracao.Arquivos.CaminhoContextoPrevio.EstaDefinido)
            {
                saida.ContextoAtual = LerContextoAtual();
                return saida;
            }

            AdaptadorContratosJsonNarrativos.AtualizarContextoNarrativoPrevio(
                _arquivos,
                _configuracao.Arquivos.CaminhoContextoPrevio.Valor,
                entrada.Resposta.TipoNarrativa,
                entrada.Resposta.TextoResposta.Valor);

            saida.Atualizou = true;
            saida.ContextoAtual = LerContextoAtual();
            return saida;
        }

        private ContextoNarrativoPrevio LerContextoAtual()
        {
            ContextoNarrativoPrevioJsonContrato contexto = AdaptadorContratosJsonNarrativos.LerContextoNarrativoPrevio(_arquivos, _configuracao.Arquivos.CaminhoContextoPrevio.Valor);
            return ContextoNarrativoPrevio.Criar(contexto.PensamentoAnterior, contexto.ContoAnterior);
        }
    }

    internal sealed class RegistrarContextoNarrativoPrevioEntradaDto
    {
        public RespostaNarrativa Resposta { get; set; }
    }

    internal sealed class RegistrarContextoNarrativoPrevioSaidaDto
    {
        public bool Atualizou { get; set; }
        public ContextoNarrativoPrevio ContextoAtual { get; set; }
    }
}