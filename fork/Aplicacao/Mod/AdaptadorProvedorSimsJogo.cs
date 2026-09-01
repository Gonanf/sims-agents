using Sims3.Gameplay;
using Sims3.Gameplay.Actors;
using Sims3.SimIFace.CAS;
using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;
using ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod
{
    /// <summary>
    /// Implementación REAL de IProvedorSims contra el juego (fork sims-agents, ítem 4
    /// del checklist "qué queda pendiente contra el juego real").
    ///
    /// ResolverSim: busca por SimDescriptionId o FullName sobre Queries.GetObjects&lt;Sim&gt;()
    /// (mismo patrón del upstream: RepositorioConsulta/ConsultaMundo.cs).
    /// EhSimValido: validación real estilo ConsultaSim.EhSimValidoSemPet + edad —
    /// existe, tiene SimDescription, NO es pet y su edad permite interactuar (Teen+).
    ///
    /// Este archivo toca APIs del juego → SOLO compila en build_mod_real.py (csproj),
    /// no en build-testes-fase1.sh (que mantiene EjecutorDeAcciones.cs libre de Sims3).
    /// </summary>
    public sealed class AdaptadorProvedorSimsJogo : IProvedorSims
    {
        public object ResolverSim(string idOuNome)
        {
            if (string.IsNullOrEmpty(idOuNome))
                return null;

            string chave = idOuNome.Trim();
            if (chave.Length == 0)
                return null;

            Sim[] sims = Queries.GetObjects<Sim>();
            if (sims == null)
                return null;

            // 1) match exacto por SimDescriptionId
            for (int i = 0; i < sims.Length; i++)
            {
                Sim sim = sims[i];
                if (sim == null || sim.SimDescription == null)
                    continue;
                if (string.Equals(sim.SimDescription.SimDescriptionId.ToString(), chave,
                    StringComparison.OrdinalIgnoreCase))
                    return sim;
            }

            // 2) fallback por nombre completo
            for (int i = 0; i < sims.Length; i++)
            {
                Sim sim = sims[i];
                if (sim == null || sim.SimDescription == null)
                    continue;
                if (string.Equals(sim.FullName, chave, StringComparison.OrdinalIgnoreCase))
                    return sim;
            }

            return null;
        }

        /// <summary>
        /// Validación real: null-check + SimDescription + no-pet + edad Teen o mayor.
        /// Bebés/niños pequeños/niños no ejecutan interacciones dirigidas por el LLM.
        /// </summary>
        public bool EhSimValido(object sim)
        {
            Sim s = sim as Sim;
            if (!ConsultaSim.EhSimValidoSemPet(s))
                return false;

            switch (ConsultaSim.Idade(s))
            {
                case CASAgeGenderFlags.None:
                case CASAgeGenderFlags.Baby:
                case CASAgeGenderFlags.Toddler:
                case CASAgeGenderFlags.Child:
                    return false;
                default:
                    return true;
            }
        }
    }

    /// <summary>
    /// Lazo cerrado (ítem 5 del checklist): registra las acciones sociales que fueron
    /// pusheadas al juego y las confirma cuando llega el EventTypeId.kSocialInteraction
    /// correspondiente. La confirmación se marca en la acción (EstadoAcao.Confirmada) y
    /// se realimenta al LLM vía log narrativo (MotorNarrativo.RegistrarConfirmacionAcao).
    /// </summary>
    internal static class SupervisorConfirmacionesAcciones
    {
        private const int LimitePendientes = 50;

        // clave = id o nombre del sim actor tal como vino en la acao
        private static readonly Dictionary<string, List<AcaoDeSim>> _pendientes =
            new Dictionary<string, List<AcaoDeSim>>(StringComparer.OrdinalIgnoreCase);

        public static void RegistrarPendiente(AcaoDeSim acao)
        {
            if (acao == null || string.IsNullOrEmpty(acao.SimAtivo))
                return;

            lock (_pendientes)
            {
                if (_pendientes.Count >= LimitePendientes)
                    _pendientes.Clear();

                string clave = acao.SimAtivo.Trim();
                List<AcaoDeSim> lista;
                if (!_pendientes.TryGetValue(clave, out lista))
                {
                    lista = new List<AcaoDeSim>();
                    _pendientes[clave] = lista;
                }
                lista.Add(acao);
            }
        }

        /// <summary>
        /// Si el actor del evento coincide con una acción social pendiente, la confirma,
        /// la saca de pendientes y la devuelve (null si no hay match).
        /// </summary>
        public static AcaoDeSim ConfirmarSiCorresponde(object actorJogo)
        {
            Sim actor = actorJogo as Sim;
            if (actor == null || actor.SimDescription == null)
                return null;

            string idActor = actor.SimDescription.SimDescriptionId.ToString();
            string nomeActor = actor.FullName;

            lock (_pendientes)
            {
                foreach (KeyValuePair<string, List<AcaoDeSim>> par in _pendientes)
                {
                    string chave = par.Key;
                    bool coincide = string.Equals(chave, idActor, StringComparison.OrdinalIgnoreCase)
                        || string.Equals(chave, nomeActor, StringComparison.OrdinalIgnoreCase);
                    if (!coincide)
                        continue;

                    List<AcaoDeSim> lista = par.Value;
                    AcaoDeSim acao = lista[0];
                    lista.RemoveAt(0);
                    if (lista.Count == 0)
                        _pendientes.Remove(chave);

                    acao.Estado = EstadoAcao.Confirmada;
                    return acao;
                }
            }

            return null;
        }
    }
}
