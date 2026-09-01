using Sims3.Gameplay.Actors;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Persiste eventos narrativos nos estados de sim, família e mundo com roteamento por tipo de classe.
    /// </summary>
    /// <remarks>
    /// <para><b>Regra de roteamento:</b></para>
    /// <list type="bullet">
    /// <item><description><c>Sim</c>: grava quando o tipo inclui escopo <c>Sim</c>.</description></item>
    /// <item><description><c>Família</c>: grava quando o tipo inclui escopo <c>Familia</c>.</description></item>
    /// <item><description><c>Mundo</c>: grava quando o tipo inclui <c>Mundo</c> e peso <c>Alto</c> ou superior.</description></item>
    /// <item><description>Tipos não mapeados usam fallback permissivo para manter compatibilidade.</description></item>
    /// </list>
    /// </remarks>
    internal sealed class EscritorEstadosNarrativos
    {
        private readonly IAdaptadorArquivos _arquivos;
        private readonly ConfiguracaoCentral _config;

        public EscritorEstadosNarrativos(IAdaptadorArquivos arquivos, ConfiguracaoCentral config)
        {
            _arquivos = arquivos;
            _config = config;
        }

        public void RegistrarEvento(EventoNarrativo evento, EventoTheSims3 tipo)
        {
            if (evento == null)
                return;

            if (tipo is EventoRuido)
                return;

            Sim simBase = evento.Ator ?? evento.Alvo;
            bool simJogavel = simBase != null && ConsultaSim.EhSimJogavel(simBase);

            bool registraNoSim = simJogavel
                && (tipo == null || tipo is EventoApenasSim || tipo is EventoSimEFamilia || tipo is EventoCompleto);

            bool registraNaFamilia = simJogavel
                && (tipo == null || tipo is EventoSimEFamilia || tipo is EventoCompleto);

            bool registraNoMundo = tipo != null && (tipo is EventoApenasMundo || tipo is EventoCompleto);
            bool registraNoLote = simJogavel
                && (tipo == null || tipo is EventoLote);

            if (registraNoSim)
                RegistrarNoEstadoDoSim(simBase, evento);

            if (registraNaFamilia)
                RegistrarNoEstadoDaFamilia(simBase, evento);

            if (registraNoMundo)
                RegistrarNoEstadoDoMundo(evento);

            if (registraNoLote)
                RegistrarNoEstadoDoLote(simBase, evento);
        }

        internal static bool DeveRegistrarNoMundo(EventoTheSims3 tipo)
        {
            return tipo != null && (tipo is EventoApenasMundo || tipo is EventoCompleto);
        }

        public void RegistrarAtualizacoesDeCabecalhosArquivosEstado()
        {
            Sim simAtivo = ConsultaSim.SimAtivo;
            if (simAtivo != null && ConsultaSim.EhSimJogavel(simAtivo))
            {
                AtualizarEstadoDoSim(simAtivo);
                AtualizarEstadoDaFamilia(simAtivo);
                AtualizarEstadoDoLote(simAtivo);
            }

            AtualizarEstadoDoMundo();
        }

        private void AtualizarEstadoDoSim(Sim sim)
        {
            string caminho = ObterCaminhoEstadoDoSim(sim);
            AdaptadorContratosJsonNarrativos.AtualizarCabecalhoDoEstado(
                _arquivos,
                caminho,
                "sim",
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaSim.ObterNomeSim(sim)),
                string.Empty,
                ContextoParaLLM.SnapshotDoSimEmCampos(sim));
        }

        private void AtualizarEstadoDaFamilia(Sim sim)
        {
            string caminho = ObterCaminhoEstadoDaFamilia(sim);
            AdaptadorContratosJsonNarrativos.AtualizarCabecalhoDoEstado(
                _arquivos,
                caminho,
                "familia",
                ConsultaFamiliaAtiva.NomeDaFamilia(sim),
                string.Empty,
                ContextoParaLLM.SnapshotDaFamiliaEmCampos(sim));
        }

        private void AtualizarEstadoDoMundo()
        {
            AdaptadorContratosJsonNarrativos.AtualizarCabecalhoDoEstado(
                _arquivos,
                _config.CaminhoEstadoMundo,
                "mundo",
                ConsultaMundo.NomeMundoAtual(),
                string.Empty,
                ContextoParaLLM.SnapshotDoMundoEmCampos());
        }

        private void AtualizarEstadoDoLote(Sim sim)
        {
            string caminho = ObterCaminhoEstadoDoLote(sim);
            if (AdaptadorTextoNarrativo.TextoVazio(caminho))
                return;

            AdaptadorContratosJsonNarrativos.AtualizarCabecalhoDoEstado(
                _arquivos,
                caminho,
                "lote",
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaAmbiente.NomeLoteAtual(sim)),
                string.Empty,
                ContextoParaLLM.SnapshotDoLoteEmCampos(sim));
        }

        private void RegistrarNoEstadoDoSim(Sim sim, EventoNarrativo evento)
        {
            string caminho = ObterCaminhoEstadoDoSim(sim);
            AdaptadorContratosJsonNarrativos.RegistrarEventoNoEstado(
                _arquivos,
                caminho,
                "sim",
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaSim.ObterNomeSim(sim)),
                string.Empty,
                ContextoParaLLM.SnapshotDoSimEmCampos(sim),
                evento.ParaContratoJson());
        }

        private void RegistrarNoEstadoDaFamilia(Sim sim, EventoNarrativo evento)
        {
            string caminho = ObterCaminhoEstadoDaFamilia(sim);
            AdaptadorContratosJsonNarrativos.RegistrarEventoNoEstado(
                _arquivos,
                caminho,
                "familia",
                ConsultaFamiliaAtiva.NomeDaFamilia(sim),
                string.Empty,
                ContextoParaLLM.SnapshotDaFamiliaEmCampos(sim),
                evento.ParaContratoJson());
        }

        private void RegistrarNoEstadoDoMundo(EventoNarrativo evento)
        {
            AdaptadorContratosJsonNarrativos.RegistrarEventoNoEstado(
                _arquivos,
                _config.CaminhoEstadoMundo,
                "mundo",
                ConsultaMundo.NomeMundoAtual(),
                string.Empty,
                ContextoParaLLM.SnapshotDoMundoEmCampos(),
                evento.ParaContratoJson());
        }

        private void RegistrarNoEstadoDoLote(Sim sim, EventoNarrativo evento)
        {
            string caminho = ObterCaminhoEstadoDoLote(sim);
            if (AdaptadorTextoNarrativo.TextoVazio(caminho))
                return;

            AdaptadorContratosJsonNarrativos.RegistrarEventoNoEstado(
                _arquivos,
                caminho,
                "lote",
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaAmbiente.NomeLoteAtual(sim)),
                string.Empty,
                ContextoParaLLM.SnapshotDoLoteEmCampos(sim),
                evento.ParaContratoJson());
        }

        private string ObterCaminhoEstadoDoSim(Sim sim)
        {
            return AdaptadorArquivosNarrativos.ResolverCaminhoEstadoDoSim(
                _config.CaminhoEstadoSimTemplate,
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaSim.ObterNomeSim(sim)),
                ConsultaSim.ObterIdDoSim(sim));
        }

        private string ObterCaminhoEstadoDaFamilia(Sim sim)
        {
            return AdaptadorArquivosNarrativos.ResolverCaminhoEstadoDaFamilia(
                _config.CaminhoEstadoFamiliaTemplate,
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaFamiliaAtiva.NomeDaFamilia(sim)));
        }

        private string ObterCaminhoEstadoDoLote(Sim sim)
        {
            if (AdaptadorTextoNarrativo.ObjetoNulo(sim) || AdaptadorTextoNarrativo.ObjetoNulo(sim.LotCurrent))
                return string.Empty;

            return AdaptadorArquivosNarrativos.ResolverCaminhoEstadoDoLote(
                _config.CaminhoEstadoLoteTemplate,
                AdaptadorTextoNarrativo.SanitizarLinha(ConsultaAmbiente.NomeLoteAtual(sim)),
                sim.LotCurrent.LotId.ToString());
        }
    }
}



