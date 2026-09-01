using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Careers;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaCarreiraDoSim
    {
        public static int CodigoSituacaoCarreira(Sim sim)
        {
            return EstaEmpregado(sim) ? 1 : 0;
        }

        public static string LimitesSituacaoCarreiraParaLlm()
        {
            return "0:Desempregado,1:Empregado";
        }

        public static string LimitesNivelCarreiraParaLlm()
        {
            return "nivel>=0";
        }

        public static bool EstaEmpregado(Sim sim)
        {
            return ObterOcupacao(sim) != null;
        }

        public static string NomeDaCarreira(Sim sim)
        {
            Occupation ocupacao = ObterOcupacao(sim);
            if (ocupacao == null) return "desempregado";

            string nome = ocupacao.CareerName;
            if (!string.IsNullOrEmpty(nome))
                return nome;

            return ocupacao.GetType().Name;
        }

        public static int NivelNaCarreira(Sim sim)
        {
            Occupation ocupacao = ObterOcupacao(sim);
            if (ocupacao == null) return 0;

            return ocupacao.CareerLevel;
        }

        public static string TituloNaCarreira(Sim sim)
        {
            Career carreira = ObterOcupacao(sim) as Career;
            if (carreira == null) return string.Empty;

            return carreira.CurLevelJobTitle;
        }

        public static float DesempenhoNoTrabalho(Sim sim)
        {
            Career carreira = ObterOcupacao(sim) as Career;
            if (carreira == null) return 0f;

            return carreira.Performance;
        }

        public static string CarreiraEmTexto(Sim sim)
        {
            if (!EstaEmpregado(sim)) return "desempregado";
            return string.Format("{0} — nível {1} ({2}) | desempenho: {3:F0}%",
                NomeDaCarreira(sim),
                NivelNaCarreira(sim),
                TituloNaCarreira(sim),
                DesempenhoNoTrabalho(sim));
        }

        public static bool EstaNoTrabalhoAgora(Sim sim)
        {
            Occupation ocupacao = ObterOcupacao(sim);
            if (ocupacao == null) return false;

            return ocupacao.IsAtWork;
        }

        public static string HorarioDeTrabalho(Sim sim)
        {
            Occupation ocupacao = ObterOcupacao(sim);
            if (ocupacao == null) return "sem horário";

            object hora = LeitorPorReflexaoUtil.LerPropriedade(ocupacao, "StartTime")
                       ?? LeitorPorReflexaoUtil.LerPropriedade(ocupacao, "mStartTime");
            return hora != null ? hora.ToString() : "horário desconhecido";
        }

        private static Occupation ObterOcupacao(Sim sim)
        {
            if (sim == null) return null;
            return sim.Occupation;
        }
    }
}
