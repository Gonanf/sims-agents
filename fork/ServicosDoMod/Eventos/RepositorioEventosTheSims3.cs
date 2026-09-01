using System;
using System.Collections.Generic;
using System.Reflection;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    // =========================================================
    // ENUMS BASE
    // =========================================================

    public enum PesoNarrativo
    {
        MuitoBaixo = 0,
        Baixo = 1,
        Neutro = 2,
        Alto = 3,
        MuitoAlto = 4
    }

    public enum CategoriaEventoNarrativo
    {
        Pensamento, // alimenta pensamentos do sim ativo
        Conto,      // alimenta narrativas / fofocas do mundo
        Generico    // serve para ambos
    }

    // =========================================================
    // CLASSE BASE
    // =========================================================

    public abstract class EventoTheSims3
    {
        public abstract string EventoId { get; }
        public abstract string LegendaPtBr { get; }
        public abstract PesoNarrativo Peso { get; }
        public abstract CategoriaEventoNarrativo Categoria { get; }

        public bool RelevantePara(CategoriaEventoNarrativo cat) =>
            Categoria == cat || Categoria == CategoriaEventoNarrativo.Generico;

        public virtual bool EhRuido => false;

        public virtual bool IncluirAlvoNaTraducao
        {
            get { return false; }
        }

        public virtual ClassificadorTemporal.JanelaTemporal ClassificacaoTemporal
        {
            get
            {
                if (EhRuido)
                    return ClassificadorTemporal.JanelaTemporal.Ruido;

                if (Peso == PesoNarrativo.MuitoAlto && Categoria != CategoriaEventoNarrativo.Pensamento)
                    return ClassificadorTemporal.JanelaTemporal.LongoPrazo;

                if (Categoria == CategoriaEventoNarrativo.Pensamento)
                    return ClassificadorTemporal.JanelaTemporal.CurtoPrazo;

                if (Peso == PesoNarrativo.Alto)
                    return ClassificadorTemporal.JanelaTemporal.MedioPrazo;

                if (this is EventoApenasMundo || this is EventoCompleto)
                    return ClassificadorTemporal.JanelaTemporal.MedioPrazo;

                return ClassificadorTemporal.JanelaTemporal.CurtoPrazo;
            }
        }

    }

    // =========================================================
    // HELPERS INTERNOS — evitam repetição de escopo comum
    // =========================================================

    internal abstract class EventoLote : EventoTheSims3
    {
    }

    internal abstract class EventoApenasSim : EventoTheSims3
    {
    }

    internal abstract class EventoSimEFamilia : EventoTheSims3
    {
    }

    internal abstract class EventoCompleto : EventoTheSims3
    {
    }

    internal abstract class EventoApenasMundo : EventoTheSims3
    {
    }

    internal abstract class EventoRuido : EventoTheSims3
    {
        public override bool EhRuido => true;
    }

    /// <summary>
    /// Classifica eventos por horizonte temporal para compor contexto de pensamento e conto.
    /// </summary>
    public static class ClassificadorTemporal
    {
        public enum JanelaTemporal
        {
            CurtoPrazo,
            MedioPrazo,
            LongoPrazo,
            Ruido
        }

        public static JanelaTemporal Classificar(string eventoId)
        {
            if (!AdaptadorTextoNarrativo.EventoIdEhValido(eventoId))
                return JanelaTemporal.Ruido;

            EventoTheSims3 evento_ts3 = RepositorioEventosTheSims3.Resolver(eventoId);
            if (evento_ts3 != null)
                return evento_ts3.ClassificacaoTemporal;

            return JanelaTemporal.CurtoPrazo;
        }

    }

    // =========================================================
    // REPOSITÓRIO
    // =========================================================

    public static class RepositorioEventosTheSims3
    {
        private static readonly Dictionary<string, EventoTheSims3> _mapa =
            new Dictionary<string, EventoTheSims3>(StringComparer.OrdinalIgnoreCase);

        static RepositorioEventosTheSims3()
        {
            RegistrarEventosAtributadosPorReflexao();
        }

        private static void RegistrarEventosAtributadosPorReflexao()
        {
            Type tipoBase = typeof(EventoTheSims3);
            Type[] tipos = tipoBase.Assembly.GetTypes();

            foreach (Type evento_ts3 in tipos)
            {
                if (evento_ts3 == null || evento_ts3.IsAbstract || !tipoBase.IsAssignableFrom(evento_ts3))
                    continue;

                ConstructorInfo construtor = evento_ts3.GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    null,
                    Type.EmptyTypes,
                    null);

                if (construtor == null)
                    continue;

                EventoTheSims3 evento = construtor.Invoke(null) as EventoTheSims3;
                if (evento != null)
                    Registrar(evento);
            }
        }


        private static void Registrar(EventoTheSims3 evento_ts3)
        {
            if (!EventoTheSims3EhRegistravel(evento_ts3))
                return;

            _mapa[evento_ts3.EventoId] = evento_ts3;
        }

        private static bool EventoTheSims3EhRegistravel(EventoTheSims3 evento_ts3)
        {
            return evento_ts3 != null && AdaptadorTextoNarrativo.EventoIdEhValido(evento_ts3.EventoId);
        }

        /// <summary>
        /// Resolve o evento_ts3 narrativo de um evento pelo ID do jogo.
        /// Retorna null para eventos não mapeados (sem valor narrativo definido).
        /// </summary>
        public static EventoTheSims3 Resolver(string eventoId)
        {
            if (!AdaptadorTextoNarrativo.EventoIdEhValido(eventoId))
                return null;

            string chave = eventoId.Trim();
            if (chave.Length == 0)
                return null;

            EventoTheSims3 evento_ts3;
            return _mapa.TryGetValue(chave, out evento_ts3) ? evento_ts3 : null;
        }

        /// <summary>
        /// Retorna todos os eventos registrados. Útil para debug e inspeção.
        /// </summary>
        public static IEnumerable<EventoTheSims3> Todos() => _mapa.Values;
    }
}
