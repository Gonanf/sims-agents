using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    internal static class TesteRegrasRegistroNarrativo
    {
        public static IList<string> Executar()
        {
            List<string> falhas = new List<string>();

            ValidarFallbackSemTipo(falhas);
            ValidarBloqueioMundoPorEscopo(falhas);
            ValidarBloqueioMundoPorPeso(falhas);
            ValidarPermissaoMundoPorEscopoEPeso(falhas);

            return falhas;
        }

        private static void ValidarFallbackSemTipo(IList<string> falhas)
        {
            if (EscritorEstadosNarrativos.DeveRegistrarNoMundo(null))
                falhas.Add("Sem tipo mapeado, o mundo não deve registrar evento.");
        }

        private static void ValidarBloqueioMundoPorEscopo(IList<string> falhas)
        {
            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver("kGotPregnant");
            if (tipo == null)
            {
                falhas.Add("kGotPregnant deveria estar mapeado para validar roteamento.");
                return;
            }

            if (EscritorEstadosNarrativos.DeveRegistrarNoMundo(tipo))
                falhas.Add("kGotPregnant não deveria registrar no mundo (não é EventoApenasMundo/EventoCompleto).");
        }

        private static void ValidarBloqueioMundoPorPeso(IList<string> falhas)
        {
            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver("kPlayedGuitar");

            if (tipo == null)
            {
                falhas.Add("kPlayedGuitar deveria estar mapeado para validar roteamento.");
                return;
            }

            if (EscritorEstadosNarrativos.DeveRegistrarNoMundo(tipo))
                falhas.Add("Evento que não herda de EventoApenasMundo/EventoCompleto não deve registrar no mundo.");
        }

        private static void ValidarPermissaoMundoPorEscopoEPeso(IList<string> falhas)
        {
            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver("kWeatherStarted");
            if (tipo == null)
            {
                falhas.Add("kWeatherStarted deveria estar mapeado para validar mundo.");
                return;
            }

            if (!EscritorEstadosNarrativos.DeveRegistrarNoMundo(tipo))
                falhas.Add("kWeatherStarted deveria registrar no mundo quando herda de EventoApenasMundo/EventoCompleto.");
        }
    }
}
