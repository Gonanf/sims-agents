using Sims3.Gameplay.Actors;
using System.Collections.Generic;
using System.Text;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta;
using TipoNarrativaCompartilhada = NarradorPorEventos.Dominio.TipoNarrativa;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Critérios auxiliares das políticas narrativas.
    /// </summary>
    internal static class CriteriosEventosNarrativos
    {
        public static bool DeveAcumularPensamento(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simAtivo)
        {
            return eventoBase != null
                && tipoEvento != null
                && simAtivo != null
                && tipoEvento.RelevantePara(CategoriaEventoNarrativo.Pensamento)
                && EnvolveSim(simAtivo, eventoBase);
        }

        public static bool DeveAcumularConto(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simBase)
        {
            if (eventoBase == null || tipoEvento == null || !tipoEvento.RelevantePara(CategoriaEventoNarrativo.Conto))
                return false;

            ClassificadorTemporal.JanelaTemporal janelaTemporal = ClassificadorTemporal.Classificar(eventoBase.Tipo);
            if (janelaTemporal == ClassificadorTemporal.JanelaTemporal.Ruido)
                return false;

            if (janelaTemporal == ClassificadorTemporal.JanelaTemporal.LongoPrazo)
                return true;

            if (simBase != null && (EnvolveSim(simBase, eventoBase) || EnvolveFamilia(simBase, eventoBase)))
                return true;

            return tipoEvento.Peso >= PesoNarrativo.Alto && (tipoEvento is EventoApenasMundo || tipoEvento is EventoCompleto);
        }

        public static List<EventoNarrativoJsonContrato> CopiarEventosValidos(IList<EventoNarrativoJsonContrato> eventos)
        {
            List<EventoNarrativoJsonContrato> resultado = new List<EventoNarrativoJsonContrato>();
            if (eventos == null)
                return resultado;

            foreach (EventoNarrativoJsonContrato evento in eventos)
            {
                if (evento != null)
                    resultado.Add(evento);
            }

            return resultado;
        }

        public static string MontarContextoPensamento(Sim simBase, IList<EventoNarrativoJsonContrato> eventos, int limiteResumo)
        {
            return MontarContexto(TipoNarrativaCompartilhada.Pensamento, simBase, eventos, limiteResumo, false, false);
        }

        public static string MontarContextoConto(Sim simBase, IList<EventoNarrativoJsonContrato> eventos, int limiteResumo)
        {
            return MontarContexto(TipoNarrativaCompartilhada.Conto, simBase, eventos, limiteResumo, true, true);
        }

        private static string MontarContexto(string tipoNarrativa, Sim simBase, IList<EventoNarrativoJsonContrato> eventos, int limiteResumo, bool incluirEstadoFamilia, bool incluirEstadoMundo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tipo=").Append(tipoNarrativa).Append(" | ");
            sb.Append("sim=").Append(AdaptadorTextoNarrativo.SanitizarLinha(ConsultaSim.ObterNomeSim(simBase))).Append(" | ");
            sb.Append("estado_sim=").Append(AdaptadorTextoNarrativo.SanitizarLinha(ContextoParaLLM.SnapshotDoSim(simBase))).Append(" | ");

            if (incluirEstadoFamilia)
                sb.Append("estado_familia=").Append(AdaptadorTextoNarrativo.SanitizarLinha(ContextoParaLLM.SnapshotDaFamilia(simBase))).Append(" | ");

            sb.Append("estado_lote=").Append(AdaptadorTextoNarrativo.SanitizarLinha(ContextoParaLLM.SnapshotDoLote(simBase))).Append(" | ");

            if (incluirEstadoMundo)
                sb.Append("estado_mundo=").Append(AdaptadorTextoNarrativo.SanitizarLinha(ContextoParaLLM.SnapshotDoMundo())).Append(" | ");

            sb.Append("eventos=").Append(AdaptadorTextoNarrativo.SanitizarLinha(AdaptadorTextoNarrativo.ResumirEventosNarrativos(eventos, limiteResumo)));
            return sb.ToString();
        }

        private static bool EnvolveSim(Sim simBase, EventoNarrativo eventoBase)
        {
            ulong idSim = ObterIdSim(simBase);
            if (idSim == 0 || eventoBase == null)
                return false;

            return idSim == ObterIdSim(eventoBase.Ator)
                || idSim == ObterIdSim(eventoBase.Alvo);
        }

        private static bool EnvolveFamilia(Sim simBase, EventoNarrativo eventoBase)
        {
            if (simBase == null || eventoBase == null)
                return false;

            ulong idAtor = ObterIdSim(eventoBase.Ator);
            ulong idAlvo = ObterIdSim(eventoBase.Alvo);
            if (idAtor == 0 && idAlvo == 0)
                return false;

            List<Sim> membrosDaCasa = ConsultaFamiliaAtiva.TodosMembrosDaCasa(simBase);
            foreach (Sim membro in membrosDaCasa)
            {
                ulong idMembro = ObterIdSim(membro);
                if (idMembro == 0)
                    continue;

                if (idMembro == idAtor || idMembro == idAlvo)
                    return true;
            }

            return false;
        }

        private static ulong ObterIdSim(Sim sim)
        {
            return sim != null && sim.SimDescription != null ? sim.SimDescription.SimDescriptionId : 0;
        }
    }
}