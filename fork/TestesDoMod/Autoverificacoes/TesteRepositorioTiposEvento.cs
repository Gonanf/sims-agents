using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    internal static class TesteRepositorioTiposEvento
    {
        public static IList<string> Executar()
        {
            List<string> falhas = new List<string>();

            ValidarEventoSimples(falhas);
            ValidarEventoDeMundo(falhas);
            ValidarCaseInsensitive(falhas);

            return falhas;
        }

        private static void ValidarEventoSimples(IList<string> falhas)
        {
            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver("kEventSimSelected");
            if (tipo == null)
            {
                falhas.Add("kEventSimSelected deveria estar mapeado.");
                return;
            }

            if (!tipo.EhRuido)
                falhas.Add("kEventSimSelected deveria ser classificado como ruído.");

            if (!tipo.RelevantePara(CategoriaEventoNarrativo.Pensamento))
                falhas.Add("kEventSimSelected deveria ser relevante para Pensamento.");
        }

        private static void ValidarEventoDeMundo(IList<string> falhas)
        {
            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver("kRelationshipChanged");
            if (tipo == null)
            {
                falhas.Add("kRelationshipChanged deveria estar mapeado.");
                return;
            }

            if (tipo.Peso < PesoNarrativo.Alto)
                falhas.Add("kRelationshipChanged deveria ter peso Alto ou maior.");

            if (!tipo.RelevantePara(CategoriaEventoNarrativo.Conto))
                falhas.Add("kRelationshipChanged deveria ser relevante para Conto.");
        }

        private static void ValidarCaseInsensitive(IList<string> falhas)
        {
            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver("krelationshipchanged");
            if (tipo == null)
                falhas.Add("Resolver deveria aceitar EventId sem diferença de maiúsculas/minúsculas.");
        }
    }
}
