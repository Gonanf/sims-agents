using Sims3.Gameplay.Utilities;
using System;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaDeHorario
    {
        public static string HorarioDoJogo
        {
            get { return SimClock.CurrentTime().ToString(); }
        }

        public static string HorarioDoMundoReal
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public static string PeriodoDoDia
        {
            get
            {
                int hora;
                if (!TentarLerHoraDoJogo(out hora)) return "indefinido";
                if (hora < 6) return "madrugada";
                if (hora < 12) return "manhã";
                if (hora < 18) return "tarde";
                return "noite";
            }
        }

        public static bool TentarLerHoraDoJogo(out int hora)
        {
            hora = -1;
            string horario = HorarioDoJogo;
            if (string.IsNullOrEmpty(horario)) return false;

            int separador = horario.IndexOf(':');
            if (separador <= 0) return false;

            return int.TryParse(horario.Substring(0, separador), out hora);
        }
    }
}
