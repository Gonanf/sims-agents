using System;
using ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public interface IAdaptadorExcecoesMod
    {
        void RegistrarExcecao(string origemDoFluxo, Exception excecaoCapturada, string contexto);
    }

    public sealed class AdaptadorExcecoesArquivo : IAdaptadorExcecoesMod
    {
        private readonly IAdaptadorArquivos _arquivos;
        private readonly string _caminhoArquivoExcecoes;

        public AdaptadorExcecoesArquivo(IAdaptadorArquivos arquivos, ConfiguracaoCentral configuracao)
        {
            _arquivos = arquivos;
            _caminhoArquivoExcecoes = configuracao.CaminhoLogExcecoes;
        }

        public void RegistrarExcecao(string origemDoFluxo, Exception excecaoCapturada, string contexto)
        {
            if (excecaoCapturada == null)
                return;

            AdaptadorContratosJsonNarrativos.AnexarLogNarrativo(_arquivos, _caminhoArquivoExcecoes, new RegistroLogNarrativoJsonContrato
            {
                HorarioReal = ConsultaDeHorario.HorarioDoMundoReal,
                Categoria = "excecao:" + (origemDoFluxo ?? string.Empty),
                Detalhe = AdaptadorTextoNarrativo.MontarDetalheDeExcecao(excecaoCapturada, contexto)
            });
        }
    }
}
