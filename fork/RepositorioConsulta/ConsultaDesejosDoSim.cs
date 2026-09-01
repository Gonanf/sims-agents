using Sims3.Gameplay.Actors;
using Sims3.Gameplay.DreamsAndPromises;
using System.Collections.Generic;
using System.Text;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    /// <summary>
    /// Consulta os desejos realmente ocupando os slots do HUD do TS3.
    /// </summary>
    public static class ConsultaDesejosDoSim
    {
        private const int PrimeiroSlotDeDesejoHud = 1;
        private const int QuantidadeSlotsDeDesejoHud = 4;

        /// <summary>
        /// Retorna apenas os desejos ocupando os quatro slots pequenos do HUD.
        /// </summary>
        public static List<ActiveDreamNode> DesejosAtivos(Sim sim)
        {
            DreamsAndPromisesManager gerenciador = ObterGerenciadorDeSonhos(sim);
            List<ActiveDreamNode> desejos = gerenciador == null
                ? new List<ActiveDreamNode>()
                : DesejosAtivos(gerenciador);

            AdaptadorVerboseDesejosDoSim.RegistrarEstadoAtual(sim, gerenciador, desejos, DesejosEmTexto(desejos));
            return desejos;
        }

        /// <summary>
        /// Retorna os desejos ativos em texto simples para o contexto narrativo.
        /// </summary>
        public static string DesejosDoSimEmTexto(Sim sim)
        {
            return DesejosEmTexto(DesejosAtivos(sim));
        }

        private static List<ActiveDreamNode> DesejosAtivos(DreamsAndPromisesManager gerenciador)
        {
            List<ActiveDreamNode> desejos = new List<ActiveDreamNode>();
            ActiveDreamNode[] promessas = gerenciador.GetPromisedNodes();
            if (promessas == null)
                return desejos;

            for (int indice = PrimeiroSlotDeDesejoHud; indice < promessas.Length; indice++)
            {
                ActiveDreamNode desejo = promessas[indice];
                if (!DesejoOcupaSlotHud(desejo))
                    continue;

                AdicionarUnico(desejos, desejo);

                if (desejos.Count >= QuantidadeSlotsDeDesejoHud)
                    break;
            }

            return desejos;
        }

        private static DreamsAndPromisesManager ObterGerenciadorDeSonhos(Sim sim)
        {
            if (sim == null)
                return null;

            return sim.DreamsAndPromisesManager;
        }

        private static bool DesejoOcupaSlotHud(ActiveDreamNode desejo)
        {
            if (desejo == null)
                return false;

            if (desejo.NodeInstance == null)
                return false;

            return !desejo.IsComplete;
        }

        private static void AdicionarUnico(List<ActiveDreamNode> destino, ActiveDreamNode desejo)
        {
            if (desejo == null)
                return;

            if (ContemNoLista(destino, desejo))
                return;

            destino.Add(desejo);
        }

        private static bool ContemNoLista(List<ActiveDreamNode> lista, ActiveDreamNode desejo)
        {
            if (lista == null || desejo == null)
                return false;

            foreach (ActiveDreamNode item in lista)
            {
                if (SaoMesmoDesejo(item, desejo))
                    return true;
            }

            return false;
        }

        private static bool SaoMesmoDesejo(ActiveDreamNode primeiro, ActiveDreamNode segundo)
        {
            if (primeiro == null || segundo == null)
                return false;

            if (primeiro == segundo)
                return true;

            DreamNodeInstance nodeA = primeiro.NodeInstance;
            DreamNodeInstance nodeB = segundo.NodeInstance;
            if (nodeA == null || nodeB == null)
                return false;

            return nodeA.OwnerTreeId == nodeB.OwnerTreeId && nodeA.NodeId == nodeB.NodeId;
        }

        private static string NomeDoDesejo(ActiveDreamNode desejo)
        {
            if (desejo == null || desejo.NodeInstance == null)
                return string.Empty;

            if (desejo.Name != string.Empty)
                return desejo.Name;

            DreamNodePrimitive primitive = desejo.NodeInstance.Primitive;
            string nome = primitive == null ? string.Empty : primitive.Name;

            if (string.IsNullOrEmpty(nome))
                nome = desejo.NodeInstance.PrimitiveId.ToString();

            return nome;
        }

        private static string DesejosEmTexto(List<ActiveDreamNode> desejos)
        {
            if (desejos == null || desejos.Count == 0)
                return "nenhum";

            StringBuilder sb = new StringBuilder();
            foreach (ActiveDreamNode desejo in desejos)
            {
                string nome = NomeDoDesejo(desejo);

                if (string.IsNullOrEmpty(nome))
                    nome = "desconhecido";

                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(nome);
            }

            return sb.Length > 0 ? sb.ToString() : "nenhum";
        }
    }
}