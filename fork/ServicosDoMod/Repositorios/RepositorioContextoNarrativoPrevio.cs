using NarradorPorEventos.Dominio;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    internal sealed class RepositorioContextoNarrativoPrevio
    {
        private readonly IAdaptadorArquivos _arquivos;
        private readonly ConfiguracaoCentral _configuracao;
        private readonly RegistrarContextoNarrativoPrevioCasoDeUso _registrarContextoNarrativoPrevioCasoDeUso;

        public RepositorioContextoNarrativoPrevio(IAdaptadorArquivos arquivos, ConfiguracaoCentral configuracao)
        {
            _arquivos = arquivos;
            _configuracao = configuracao;
            _registrarContextoNarrativoPrevioCasoDeUso = new RegistrarContextoNarrativoPrevioCasoDeUso(arquivos, configuracao);
        }

        public string LerPensamentoAnterior()
        {
            return LerContextoDominio().PensamentoAnterior.Valor;
        }

        public string LerContoAnterior()
        {
            return LerContextoDominio().ContoAnterior.Valor;
        }

        public void RegistrarRespostaAnterior(RespostaNarrativa resposta)
        {
            _registrarContextoNarrativoPrevioCasoDeUso.Executar(new RegistrarContextoNarrativoPrevioEntradaDto
            {
                Resposta = resposta
            });
        }

        public void Limpar()
        {
            AdaptadorContratosJsonNarrativos.LimparContextoNarrativoPrevio(_arquivos, _configuracao.CaminhoContextoPrevio);
        }

        private ContextoNarrativoPrevio LerContextoDominio()
        {
            ContextoNarrativoPrevioJsonContrato contexto = AdaptadorContratosJsonNarrativos.LerContextoNarrativoPrevio(_arquivos, _configuracao.CaminhoContextoPrevio);
            return ContextoNarrativoPrevio.Criar(contexto.PensamentoAnterior, contexto.ContoAnterior);
        }
    }
}