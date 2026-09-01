using Sims3.Gameplay.Actors;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaFamiliaAtiva
    {
        public static List<Sim> MembrosHumanosDaCasa(Sim sim)
        {
            var lista = new List<Sim>();
            if (sim == null || sim.Household == null) return lista;

            foreach (Sim membro in sim.Household.Sims)
            {
                if (membro == null) continue;
                if (!ConsultaSim.EhPet(membro))
                    lista.Add(membro);
            }
            return lista;
        }

        public static List<Sim> TodosMembrosDaCasa(Sim sim)
        {
            var lista = new List<Sim>();
            if (sim == null || sim.Household == null) return lista;

            foreach (Sim membro in sim.Household.Sims)
            {
                if (membro != null) lista.Add(membro);
            }
            return lista;
        }

        public static List<Sim> MembrosJogaveisDaCasaAtual
        {
            get { return ConjuntoDeSimsDaCasaAtual; }
        }

        public static int TotalMembros(Sim sim)
        {
            if (sim == null || sim.Household == null) return 0;
            return sim.Household.Sims.Count;
        }

        public static List<Sim> ConjuntoDeSimsDaCasaAtual
        {
            get
            {
                var lista = new List<Sim>();
                Sim sim = ConsultaSim.SimAtivo;
                if (sim == null) return lista;
                if (sim.Household == null) return lista;

                foreach (Sim membro in sim.Household.Sims)
                {
                    if (membro == null) continue;
                    lista.Add(membro);
                }
                return lista;
            }
        }

        public static int SimoloeosDaFamiliaAtual
        {
            get
            {
                Sim sim = ConsultaSim.SimAtivo;
                if (sim == null || sim.Household == null) return 0;
                return sim.Household.FamilyFunds;
            }
        }

        public static int SaldoFamiliar(Sim sim)
        {
            if (sim == null || sim.Household == null) return 0;
            return sim.Household.FamilyFunds;
        }

        public static int ConsultarValorDoLoteDaFamiliaPorSim(Sim sim)
        {
            return ConsultarValorDoLotePorSim(sim);
        }

        public static int ConsultarValorDoLotePorSim(Sim sim)
        {
            if (sim == null || sim.SimDescription == null || sim.SimDescription.LotHome == null) return 0;
            return sim.LotHome.Cost;
        }

        // public static string SituacaoFinanceiraEmTexto(Sim sim)
        // {
        //     int saldo = SaldoFamiliar(sim);
        //     return ConsultaClasseEconomica.SituacaoFinanceiraEmTexto(saldo);
        // }

        public static string SituacaoFinanceiraAcumulandoTerrenoEmTexto(Sim sim)
        {
            int saldo = SaldoFamiliar(sim);
            int valorDoLote = ConsultarValorDoLotePorSim(sim);

            int totalSomaLoteComFundos = saldo + valorDoLote;

            return ConsultaClasseEconomica.SituacaoFinanceiraEmTexto(totalSomaLoteComFundos);
        }

        public static string NomeDaFamilia(Sim sim)
        {
            if (sim == null || sim.Household == null)
                return "familia_desconhecida";

            return string.IsNullOrEmpty(sim.Household.Name) ? "familia" : sim.Household.Name;
        }

        public static string MembrosDaFamiliaEmTexto(Sim sim)
        {
            return NomesDosMembrosSeparadosPorVirgula(sim);
        }

        public static string NomesDosMembrosSeparadosPorVirgula(Sim sim)
        {
            if (sim == null || sim.Household == null)
                return "sem família";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Sim membro in sim.Household.Sims)
            {
                if (membro == null) continue;
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, ConsultaSim.NomeCompleto(membro), ", ");
            }

            return sb.Length > 0 ? sb.ToString() : "sem membros";
        }

        public static string TracosDosMembrosDaFamiliaEmTexto(Sim sim)
        {
            return TracosDosMembrosSeparadosPorBarra(sim);
        }

        public static string TracosDosMembrosSeparadosPorBarra(Sim sim)
        {
            if (sim == null || sim.Household == null)
                return "nenhum";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Sim membro in sim.Household.Sims)
            {
                if (membro == null) continue;

                string tracosDoMembro = ConsultaSim.NomeCompleto(membro) + ": " + ConsultaTracosDoSim.TracosDoSimEmTexto(membro);
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, tracosDoMembro, " | ");
            }

            return sb.Length > 0 ? sb.ToString() : "nenhum";
        }

        public static string IdadesDosMembrosEmTexto(Sim sim)
        {
            if (sim == null || sim.Household == null) return string.Empty;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Sim membro in sim.Household.Sims)
            {
                if (membro == null) continue;

                string entrada = ConsultaSim.NomeCompleto(membro) + " (" + ConsultaSim.IdadeEmTexto(membro) + ")";
                AdaptadorTextoNarrativo.AdicionarComSeparador(sb, entrada, ", ");
            }

            return sb.ToString();
        }

        public static string BioDaFamiliaEmTexto(Sim sim)
        {
            return BioDaFamilia(sim);
        }

        public static string BioDaFamilia(Sim sim)
        {
            if (sim == null || sim.Household == null)
                return string.Empty;

            object bio = LeitorPorReflexaoUtil.LerPropriedade(sim.Household, "BioText");

            return bio == null ? string.Empty : bio.ToString();
        }

        public static string ResumoNarrativoDaFamilia(Sim sim)
        {
            if (sim == null || sim.Household == null) return "família desconhecida";

            string nome = NomeDaFamilia(sim);
            string membros = NomesDosMembrosSeparadosPorVirgula(sim);
            string situacao = SituacaoFinanceiraAcumulandoTerrenoEmTexto(sim);
            string bio = BioDaFamilia(sim);

            string resumo = "Família " + nome + " — membros: " + membros + " — situação financeira: " + situacao;
            if (!string.IsNullOrEmpty(bio))
                resumo += " — " + bio;

            return resumo;
        }
    }
}