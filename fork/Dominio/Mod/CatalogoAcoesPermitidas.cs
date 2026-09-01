using System;
using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod
{
    /// <summary>
    /// Lista blanca de acciones permitidas, definida en catálogo tipado (nunca en prompts).
    /// Cada entrada mapea el nombre canónico de la acción (el que el LLM usa en `acao.interacao`)
    /// al nombre completo del tipo InteractionDefinition del juego cuyo campo estático `Singleton`
    /// se resuelve por reflexión con LeitorPorReflexaoUtil.
    ///
    /// Nombres VERIFICADOS contra las DLLs reales de TS3 1.67 por reflexión
    /// (probe_catalogo/probe2/probe4, ago 2026): todos existen y exponen
    /// `public static Singleton` salvo los sociales (ver README).
    /// </summary>
    public sealed class EntradaCatalogoAcoes
    {
        public string Nome { get; private set; }
        public string NomeTipoDefinicion { get; private set; }
        public bool RequiereAlvoSim { get; private set; }

        public EntradaCatalogoAcoes(string nome, string nomeTipoDefinicion, bool requiereAlvoSim)
        {
            Nome = nome;
            NomeTipoDefinicion = nomeTipoDefinicion;
            RequiereAlvoSim = requiereAlvoSim;
        }
    }

    public static class CatalogoAcoesPermitidas
    {
        private static readonly List<EntradaCatalogoAcoes> Entradas = CriarEntradas();

        private static List<EntradaCatalogoAcoes> CriarEntradas()
        {
            List<EntradaCatalogoAcoes> lista = new List<EntradaCatalogoAcoes>();
            lista.Add(new EntradaCatalogoAcoes("comer",
                "Sims3.Gameplay.Objects.FoodObjects.Eat", false));
            lista.Add(new EntradaCatalogoAcoes("dormir",
                "Sims3.Gameplay.InteractionsShared.SleepAndNapOnObject", false));
            lista.Add(new EntradaCatalogoAcoes("ir_al_trabajo",
                "Sims3.Gameplay.Careers.WorkInRabbitHole", false));
            lista.Add(new EntradaCatalogoAcoes("hablar",
                "Sims3.Gameplay.Socializing.SocialInteractionA", true));
            lista.Add(new EntradaCatalogoAcoes("coquetear",
                "Sims3.Gameplay.Socializing.SocialInteractionA", true));
            lista.Add(new EntradaCatalogoAcoes("invitar_salir",
                "Sims3.Gameplay.Socializing.SocialInteractionA", true));
            lista.Add(new EntradaCatalogoAcoes("usar_objeto_pasión",
                "Sims3.Gameplay.Objects.HobbiesSkills.Easel+Paint", false));
            lista.Add(new EntradaCatalogoAcoes("reaccionar",
                "Sims3.Gameplay.Actors.Sim+StandIdle", true));
            lista.Add(new EntradaCatalogoAcoes("idle_con_pensamiento",
                "Sims3.Gameplay.Actors.Sim+StandIdle", false));
            return lista;
        }

        public static EntradaCatalogoAcoes Resolver(string interacao)
        {
            if (string.IsNullOrEmpty(interacao))
                return null;

            string buscado = Normalizar(interacao);
            foreach (EntradaCatalogoAcoes entrada in Entradas)
            {
                if (Normalizar(entrada.Nome) == buscado)
                    return entrada;
            }

            return null;
        }

        public static IList<EntradaCatalogoAcoes> Todas()
        {
            return Entradas.AsReadOnly();
        }

        /// <summary>
        /// Matching tolerante: case-insensitive, sin acentos ni guiones bajos/espacios.
        /// El LLM escribe variaciones; el catálogo es la fuente de verdad.
        /// </summary>
        public static string Normalizar(string texto)
        {
            if (texto == null)
                return string.Empty;

            string minusculas = texto.ToLowerInvariant();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in minusculas)
            {
                if (c == ' ' || c == '-' || c == '_' || c == '.')
                    continue;
                // desacentuar básico latino
                switch (c)
                {
                    case 'á': case 'à': case 'ã': case 'â': sb.Append('a'); break;
                    case 'é': case 'è': case 'ê': sb.Append('e'); break;
                    case 'í': case 'ì': sb.Append('i'); break;
                    case 'ó': case 'ò': case 'õ': case 'ô': sb.Append('o'); break;
                    case 'ú': case 'ù': sb.Append('u'); break;
                    case 'ç': sb.Append('c'); break;
                    default: sb.Append(c); break;
                }
            }

            return sb.ToString();
        }
    }
}
