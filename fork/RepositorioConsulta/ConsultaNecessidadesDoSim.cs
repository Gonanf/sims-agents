using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using System.Collections.Generic;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public class NecessidadeInfo
    {
        public string Nome;
        public float Valor;
    }

    public static class ConsultaNecessidadesDoSim
    {
        private const float LimiteCriticoNecessidade = -50f;

        private static readonly CommodityKind[] GrupoBanheiro = new CommodityKind[]
        {
            CommodityKind.Bladder
        };

        private static readonly CommodityKind[] GrupoFome = new CommodityKind[]
        {
            CommodityKind.VampireThirst,
            CommodityKind.Hunger
        };

        private static readonly CommodityKind[] GrupoEnergia = new CommodityKind[]
        {
            CommodityKind.BatteryPower,
            CommodityKind.AlienBrainPower,
            CommodityKind.Energy
        };

        private static readonly CommodityKind[] GrupoHigiene = new CommodityKind[]
        {
            CommodityKind.Maintenence,
            CommodityKind.MermaidDermalHydration,
            CommodityKind.Hygiene
        };

        private static readonly CommodityKind[] GrupoDiversao = new CommodityKind[]
        {
            CommodityKind.Fun
        };

        private static readonly CommodityKind[] GrupoSocial = new CommodityKind[]
        {
            CommodityKind.Social
        };

        public static List<CommodityKind> ListaDeNecessidadesAlvo = new List<CommodityKind>
        {
            CommodityKind.Bladder,
            CommodityKind.Hunger,
            CommodityKind.Energy,
            CommodityKind.Hygiene,
            CommodityKind.Fun,
            CommodityKind.Social
        };

        public static List<NecessidadeInfo> ListaDeNecessidades(Sim sim)
        {
            List<NecessidadeInfo> lista = new List<NecessidadeInfo>();
            if (sim == null || sim.Motives == null)
                return lista;

            List<CommodityKind> necessidadesDoSim = ObterNecessidadesBasicasDoSim(sim, ListaDeNecessidadesAlvo);
            foreach (CommodityKind necessidade in necessidadesDoSim)
            {
                float valor = sim.Motives.GetMotiveValue(necessidade);

                NecessidadeInfo item = new NecessidadeInfo();
                item.Nome = ObterNomeExibicao(necessidade);
                item.Valor = valor;
                lista.Add(item);
            }

            return lista;
        }

        public static string NecessidadesDoSimEmTexto(Sim sim)
        {
            List<NecessidadeInfo> lista = ListaDeNecessidades(sim);
            if (lista.Count == 0)
                return "sem necessidades";

            StringBuilder sb = new StringBuilder();
            foreach (NecessidadeInfo necessidade in lista)
            {
                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(necessidade.Nome);
                sb.Append("=");
                sb.Append(necessidade.Valor.ToString("F0"));
            }

            return sb.ToString();
        }

        public static string NecessidadesCriticasEmTexto(Sim sim)
        {
            List<NecessidadeInfo> lista = ListaDeNecessidades(sim);
            if (lista.Count == 0)
                return "nenhuma";

            StringBuilder sb = new StringBuilder();
            foreach (NecessidadeInfo necessidade in lista)
            {
                if (necessidade.Valor > LimiteCriticoNecessidade)
                    continue;

                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(necessidade.Nome);
            }

            return sb.Length > 0 ? sb.ToString() : "nenhuma";
        }

        public static string LimitesNecessidadesParaLlm()
        {
            return "valor aproximado de necessidade: -100..100";
        }

        public static string LimitesNecessidadesCriticasParaLlm()
        {
            return "critica quando valor<=" + LimiteCriticoNecessidade.ToString("F0");
        }

        private static List<CommodityKind> ObterNecessidadesBasicasDoSim(Sim sim, List<CommodityKind> fallback)
        {
            List<CommodityKind> necessidades = new List<CommodityKind>();
            if (sim == null || sim.Motives == null)
                return necessidades;

            AdicionarNecessidadeDisponivel(sim, necessidades, GrupoBanheiro, CommodityKind.Bladder, fallback);
            AdicionarNecessidadeDisponivel(sim, necessidades, GrupoFome, CommodityKind.Hunger, fallback);
            AdicionarNecessidadeDisponivel(sim, necessidades, GrupoEnergia, CommodityKind.Energy, fallback);
            AdicionarNecessidadeDisponivel(sim, necessidades, GrupoHigiene, CommodityKind.Hygiene, fallback);
            AdicionarNecessidadeDisponivel(sim, necessidades, GrupoDiversao, CommodityKind.Fun, fallback);
            AdicionarNecessidadeDisponivel(sim, necessidades, GrupoSocial, CommodityKind.Social, fallback);

            return necessidades;
        }

        private static string ObterNomeExibicao(CommodityKind necessidade)
        {
            switch (necessidade)
            {
                case CommodityKind.Bladder:
                    return "banheiro";
                case CommodityKind.Hunger:
                case CommodityKind.VampireThirst:
                    return "fome";
                case CommodityKind.Energy:
                case CommodityKind.BatteryPower:
                case CommodityKind.AlienBrainPower:
                    return "energia";
                case CommodityKind.Hygiene:
                case CommodityKind.Maintenence:
                case CommodityKind.MermaidDermalHydration:
                    return "higiene";
                case CommodityKind.Fun:
                    return "diversao";
                case CommodityKind.Social:
                    return "social";
                default:
                    return necessidade.ToString();
            }
        }

        private static void AdicionarNecessidadeDisponivel(
            Sim sim,
            List<CommodityKind> necessidades,
            CommodityKind[] grupo,
            CommodityKind necessidadeBase,
            List<CommodityKind> fallback)
        {
            CommodityKind? necessidadeEncontrada = ObterNecessidadeDisponivelNoGrupo(sim, grupo);
            if (necessidadeEncontrada.HasValue)
            {
                necessidades.Add(necessidadeEncontrada.Value);
                return;
            }

            if (fallback != null && fallback.Contains(necessidadeBase))
                necessidades.Add(necessidadeBase);
        }

        private static CommodityKind? ObterNecessidadeDisponivelNoGrupo(Sim sim, CommodityKind[] grupo)
        {
            foreach (CommodityKind necessidade in grupo)
            {
                if (sim.Motives.GetMotive(necessidade) != null)
                    return necessidade;
            }

            return null;
        }
    }
}
