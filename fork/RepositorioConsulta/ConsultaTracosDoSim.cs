using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using System.Collections.Generic;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaTracosDoSim
    {
        public static List<TraitNames> ListaDeTracos(Sim sim)
        {
            var lista = new List<TraitNames>();
            if (sim == null || sim.SimDescription == null) return lista;
            if (sim.SimDescription.TraitManager == null) return lista;

            foreach (Trait trait in sim.SimDescription.TraitManager.List)
            {
                if (trait == null) continue;
                lista.Add(trait.Guid);
            }
            return lista;
        }

        public static bool PossuiTraco(Sim sim, TraitNames traco)
        {
            if (sim == null || sim.SimDescription == null) return false;
            if (sim.SimDescription.TraitManager == null) return false;
            return sim.SimDescription.TraitManager.HasElement(traco);
        }

        public static string TracosDoSimEmTexto(Sim sim)
        {
            List<TraitNames> tracos = ListaDeTracos(sim);
            if (tracos.Count == 0) return "sem traços";

            StringBuilder sb = new StringBuilder();
            foreach (TraitNames traco in tracos)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(traco.ToString());
            }
            return sb.ToString();
        }
    }
}
