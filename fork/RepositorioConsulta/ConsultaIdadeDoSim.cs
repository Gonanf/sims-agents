using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.SimIFace.CAS;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaIdadeDoSim
    {
        private const string LimitesFaixaEtaria = "0:Bebê,1:Criança de colo,2:Criança,3:Adolescente,4:Jovem adulto,5:Adulto,6:Idoso";
        private const float LimiteDiasProximoEvento = 2f;

        private static bool TemFaixaEtaria(CASAgeGenderFlags idadeAtual, CASAgeGenderFlags faixa)
        {
            return (idadeAtual & faixa) == faixa;
        }

        public static string IdadeEmTexto(Sim sim)
        {
            if (sim == null || sim.SimDescription == null)
                return "idade desconhecida";

            CASAgeGenderFlags idadeAtual = sim.SimDescription.Age;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Baby))
                return "bebê";
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Toddler))
                return "criança de colo";
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Child))
                return "criança";
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Teen))
                return "adolescente";
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.YoungAdult))
                return "jovem adulto";
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Adult))
                return "adulto";
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Elder))
                return "idoso";

            return idadeAtual.ToString();
        }

        public static int CodigoFaixaEtaria(Sim sim)
        {
            if (sim == null || sim.SimDescription == null)
                return -1;

            CASAgeGenderFlags idadeAtual = sim.SimDescription.Age;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Baby))
                return 0;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Toddler))
                return 1;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Child))
                return 2;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Teen))
                return 3;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.YoungAdult))
                return 4;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Adult))
                return 5;
            if (TemFaixaEtaria(idadeAtual, CASAgeGenderFlags.Elder))
                return 6;

            return -1;
        }

        public static string LimitesFaixaEtariaParaLlm()
        {
            return LimitesFaixaEtaria;
        }

        public static float DiasDeVidaRestantes(Sim sim)
        {
            if (sim == null || sim.SimDescription == null || sim.SimDescription.AgingState == null)
                return -1f;

            if (AgingManager.Singleton == null)
                return -1f;

            float tamanhoFaseEmAnos = AgingManager.Singleton.GetCurrentAgingStageLength(sim.SimDescription);
            float anosPassados = sim.SimDescription.AgingYearsSinceLastAgeTransition;
            float anosRestantes = tamanhoFaseEmAnos - anosPassados;
            if (anosRestantes < 0f)
                anosRestantes = 0f;

            return AgingManager.Singleton.AgingYearsToSimDays(anosRestantes);
        }

        public static bool EnvelhecimentoAtivo()
        {
            return AgingManager.Singleton != null && AgingManager.Singleton.Enabled;
        }

        public static bool EstaProximoDoAniversario(Sim sim)
        {
            float dias = DiasDeVidaRestantes(sim);
            return dias >= 0f && dias <= LimiteDiasProximoEvento;
        }

        public static bool EstaProximoDeMorrer(Sim sim)
        {
            if (sim == null || sim.SimDescription == null) return false;

            if (!TemFaixaEtaria(sim.SimDescription.Age, CASAgeGenderFlags.Elder)) return false;

            float dias = DiasDeVidaRestantes(sim);
            return dias >= 0f && dias <= LimiteDiasProximoEvento;
        }

        public static bool EnvelhecimentoEmProgresso(Sim sim)
        {
            if (sim == null || sim.SimDescription == null || sim.SimDescription.AgingState == null)
                return false;

            return sim.SimDescription.AgingState.IsAgingInProgress();
        }

        public static string ProximaFaixaEtariaEmTexto(Sim sim)
        {
            if (sim == null || sim.SimDescription == null)
                return "faixa etária desconhecida";

            CASAgeGenderFlags proximaFaixa = AgingState.GetNextOlderAge(sim.SimDescription.Age, sim.SimDescription.Species);
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.Baby))
                return "bebê";
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.Toddler))
                return "criança de colo";
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.Child))
                return "criança";
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.Teen))
                return "adolescente";
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.YoungAdult))
                return "jovem adulto";
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.Adult))
                return "adulto";
            if (TemFaixaEtaria(proximaFaixa, CASAgeGenderFlags.Elder))
                return "idoso";

            return proximaFaixa.ToString();
        }

        public static string CicloDeVidaEmTexto(Sim sim)
        {
            if (!EnvelhecimentoAtivo())
                return "CICLO DE VIDA: envelhecimento desativado nas opções";

            float diasRestantes = DiasDeVidaRestantes(sim);
            if (diasRestantes < 0f)
                return "CICLO DE VIDA: dados indisponíveis";

            string aviso = EstaProximoDeMorrer(sim) ? " [PRÓXIMO DA MORTE]"
                : EstaProximoDoAniversario(sim) ? " [ANIVERSÁRIO EM BREVE]"
                : string.Empty;

            return "CICLO DE VIDA: " + diasRestantes.ToString("F1") + " dias de fase" + aviso;
        }
    }
}
