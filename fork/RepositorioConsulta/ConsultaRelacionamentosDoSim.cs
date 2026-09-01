using Sims3.Gameplay.Actors;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Socializing;
using System.Collections.Generic;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaRelacionamentosDoSim
    {
        private const float LimiteInimigo = -50f;
        private const float LimiteDesafeto = -20f;
        private const float LimiteAmigo = 30f;
        private const float LimiteBomAmigo = 60f;
        private const float LimiteMelhorAmigo = 80f;

        public static List<Relationship> ListaDeRelacionamentos(Sim sim)
        {
            var lista = new List<Relationship>();
            if (sim == null || sim.SocialComponent == null) return lista;

            foreach (Relationship rel in sim.SocialComponent.Relationships)
            {
                if (rel == null) continue;
                lista.Add(rel);
            }
            return lista;
        }

        public static List<Relationship> ListaDeAmigos(Sim sim)
        {
            List<Relationship> rels = ListaDeRelacionamentos(sim);
            return FiltrarRelacoes(rels, true);
        }

        public static List<Relationship> ListaDeDesafetos(Sim sim)
        {
            List<Relationship> rels = ListaDeRelacionamentos(sim);
            return FiltrarRelacoes(rels, false);
        }

        public static Relationship ObterRelacionamento(Sim ator, Sim alvo, bool criarSeNaoExistir)
        {
            if (ator == null || alvo == null)
                return null;

            if (ator.SimDescription == null || alvo.SimDescription == null)
                return null;

            return Relationship.Get(ator, alvo, criarSeNaoExistir);
        }

        public static string TipoRelacaoEmTexto(Sim ator, Sim alvo)
        {
            if (ator == null || alvo == null)
                return "desconhecida";

            if (SaoDaMesmaFamilia(ator, alvo))
                return "família";

            Relationship relacao = ObterRelacionamento(ator, alvo, false);
            if (relacao == null)
                return "conhecidos";

            string tipoFormal = TipoFormalDaRelacao(relacao);
            if (!string.IsNullOrEmpty(tipoFormal))
                return tipoFormal;

            if (relacao.AreEnemies())
                return "inimigos";

            if (relacao.AreFriends())
                return TipoAmizadePorLiking(relacao.CurrentLTRLiking);

            return TipoNeutroPorLiking(relacao.CurrentLTRLiking);
        }

        private static bool SaoDaMesmaFamilia(Sim ator, Sim alvo)
        {
            if (ator.Household != null && alvo.Household != null && ator.Household == alvo.Household)
                return true;

            if (ator.SimDescription == null || alvo.SimDescription == null)
                return false;

            if (ator.SimDescription.Genealogy == null || alvo.SimDescription.Genealogy == null)
                return false;

            return ator.SimDescription.Genealogy.IsBloodRelated(alvo.SimDescription.Genealogy);
        }

        private static string TipoFormalDaRelacao(Relationship relacao)
        {
            string tipoLTR = relacao.CurrentLTR.ToString();
            switch (tipoLTR)
            {
                case "Spouse":
                    return "cônjuge";
                case "Fiancee":
                    return "noivo(a)";
                case "Partner":
                    return "parceiro(a)";
                case "RomanticInterest":
                    return "interesse romântico";
            }

            if (relacao.AreRomantic())
                return "interesse romântico";

            return string.Empty;
        }

        private static string TipoAmizadePorLiking(float liking)
        {
            if (liking > LimiteMelhorAmigo) return "melhor amigo";
            if (liking > LimiteBomAmigo) return "bom amigo";
            if (liking > LimiteAmigo) return "amigos";
            return "amigos";
        }

        private static string TipoNeutroPorLiking(float liking)
        {
            if (liking <= LimiteInimigo) return "inimigos";
            if (liking < LimiteDesafeto) return "desafetos";
            if (liking > LimiteAmigo) return "amigos";
            return "conhecidos";
        }

        public static List<Sim> AmigosNoLote(Sim sim, Lot lote)
        {
            return FiltrarSimsNoLote(ListaDeAmigos(sim), lote, sim);
        }

        public static List<Sim> DesafetosNoLote(Sim sim, Lot lote)
        {
            return FiltrarSimsNoLote(ListaDeDesafetos(sim), lote, sim);
        }

        public static string RelacionamentosEmTexto(List<Relationship> rels, Sim simBase)
        {
            if (rels == null || rels.Count == 0) return "nenhum";

            StringBuilder sb = new StringBuilder();
            foreach (Relationship rel in rels)
            {
                SimDescription outro = rel.GetOtherSimDescription(simBase.SimDescription);
                if (outro == null) continue;
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(outro.FullName);
            }
            return sb.Length > 0 ? sb.ToString() : "nenhum";
        }

        private static List<Relationship> FiltrarRelacoes(List<Relationship> rels, bool amigos)
        {
            var lista = new List<Relationship>();
            foreach (Relationship rel in rels)
            {
                if (rel == null)
                    continue;

                if (amigos && EhRelacaoAmigavel(rel))
                    lista.Add(rel);

                if (!amigos && EhRelacaoDeDesafeto(rel))
                    lista.Add(rel);
            }

            return lista;
        }

        private static bool EhRelacaoAmigavel(Relationship rel)
        {
            if (rel.AreFriends())
                return true;

            return rel.CurrentLTRLiking > LimiteAmigo;
        }

        private static bool EhRelacaoDeDesafeto(Relationship rel)
        {
            if (rel.AreEnemies())
                return true;

            return rel.CurrentLTRLiking < LimiteDesafeto;
        }

        private static List<Sim> FiltrarSimsNoLote(List<Relationship> rels, Lot lote, Sim simBase)
        {
            var lista = new List<Sim>();
            if (lote == null) return lista;

            foreach (Relationship rel in rels)
            {
                SimDescription desc = rel.GetOtherSimDescription(simBase.SimDescription);
                if (desc == null) continue;
                Sim sim = desc.CreatedSim;
                if (sim == null) continue;
                if (sim.LotCurrent != lote) continue;
                lista.Add(sim);
            }
            return lista;
        }
    }
}
