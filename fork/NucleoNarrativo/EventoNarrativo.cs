using Sims3.Gameplay.Actors;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    internal sealed class EventoNarrativo
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string HorarioJogo { get; set; }
        public Sim Ator { get; set; }
        public Sim Alvo { get; set; }

        public EventoNarrativoJsonContrato ParaContratoJson()
        {
            return new EventoNarrativoJsonContrato
            {
                HorarioJogo = HorarioJogo ?? string.Empty,
                Tipo = Tipo ?? string.Empty,
                Ator = Ator != null ? Ator.FullName : string.Empty,
                Alvo = Alvo != null ? Alvo.FullName : string.Empty,
                Descricao = Descricao ?? string.Empty
            };
        }
    }
}
