using NarradorPorEventos.Dominio;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod
{
    internal sealed class ConsumirRespostasNarrativasCasoDeUso
    {
        private readonly IAdaptadorArquivos _arquivos;
        private readonly ConfiguracaoModNarrativa _configuracao;

        public ConsumirRespostasNarrativasCasoDeUso(IAdaptadorArquivos arquivos, ConfiguracaoCentral configuracao)
        {
            _arquivos = arquivos;
            _configuracao = ConfiguracaoModNarrativa.Criar(configuracao);
        }

        public ConsumirRespostasNarrativasSaidaDto Executar(ConsumirRespostasNarrativasEntradaDto entrada)
        {
            ConsumirRespostasNarrativasSaidaDto saida = new ConsumirRespostasNarrativasSaidaDto();
            if (!_configuracao.Arquivos.CaminhoRespostas.EstaDefinido)
                return saida;

            if (!_arquivos.VerificarCaminhoExiste(_configuracao.Arquivos.CaminhoRespostas.Valor))
                return saida;

            List<RespostaNarrativaJsonContrato> contratos = AdaptadorContratosJsonNarrativos.LerRespostas(_arquivos, _configuracao.Arquivos.CaminhoRespostas.Valor);
            if (contratos == null || contratos.Count == 0)
                return saida;

            foreach (RespostaNarrativaJsonContrato contrato in contratos)
            {
                RespostaNarrativa resposta = RespostaNarrativa.Criar(
                    contrato.Id,
                    contrato.Tipo,
                    contrato.SimAtivo,
                    contrato.HorarioReal,
                    PromptNarrativo.Criar(contrato.Tipo, string.Empty, contrato.Prompt),
                    contrato.Resposta);

                if (resposta.EhValida())
                    saida.Respostas.Add(resposta);

                // fork sims-agents: extraer la acción tipada (si viene) para el EjecutorDeAcciones
                AcaoDeSim acao;
                if (contrato.AcaoBruta != null
                    && AdaptadorAcaoResposta.TentarExtrair(contrato.AcaoBruta, contrato.Id,
                        contrato.SimAtivo, out acao))
                    saida.Acoes.Add(acao);
            }

            if (entrada == null || entrada.LimparArquivoAposLeitura)
                AdaptadorContratosJsonNarrativos.LimparRespostas(_arquivos, _configuracao.Arquivos.CaminhoRespostas.Valor);

            saida.QuantidadeRespostas = saida.Respostas.Count;
            return saida;
        }
    }

    internal sealed class ConsumirRespostasNarrativasEntradaDto
    {
        public bool LimparArquivoAposLeitura { get; set; }
    }

    internal sealed class ConsumirRespostasNarrativasSaidaDto
    {
        public ConsumirRespostasNarrativasSaidaDto()
        {
            Respostas = new List<RespostaNarrativa>();
            Acoes = new List<AcaoDeSim>();
        }

        public int QuantidadeRespostas { get; set; }
        public IList<RespostaNarrativa> Respostas { get; private set; }
        public IList<AcaoDeSim> Acoes { get; private set; }
    }
}