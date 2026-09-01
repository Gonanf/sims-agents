using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod
{
    /// <summary>
    /// Abstracciones para desacoplar la lógica pura del EjecutorDeAcciones de las APIs del juego.
    /// En runtime del juego las implementan AdaptadorProvedorSimsJogo / AdaptadorFilaInteracoesJogo
    /// (abajo). En tests se mockean — la lógica de decisión corre sin The Sims 3 instalado.
    /// </summary>
    public interface IProvedorSims
    {
        /// <summary>Resuelve el sim actor por SimDescriptionId o nombre; null si no existe.</summary>
        object ResolverSim(string idOuNome);
        /// <summary>Validación básica: existe, no pet, edad válida para interactuar.</summary>
        bool EhSimValido(object sim);
    }

    public interface IFilaInteracoes
    {
        bool TentarPush(EntradaCatalogoAcoes entrada, object simAtor, object simAlvo,
            ModoExecucaoAcao modo, PrioridadeAcao prioridade);
    }

    /// <summary>
    /// Ejecutor de acciones tipadas pedidas por el LLM.
    /// Lógica pura (validación de contrato + lista blanca + resolución) testeable con mocks;
    /// el push real ocurre SIEMPRE en el hilo lógico del juego vía callback de AlarmManager
    /// (el mismo patrón del consumidor de fila del MotorNarrativo — nunca desde el servidor externo).
    ///
    /// Flujo: respuesta JSON → AdaptadorAcaoResposta.TentarExtrair → Encolar() desde el hilo
    /// del juego → DrenarPendentes() dentro de un alarme → push por reflexión.
    /// </summary>
    public sealed class EjecutorDeAcciones
    {
        private readonly IProvedorSims _provedorSims;
        private readonly IFilaInteracoes _fila;
        private readonly List<AcaoDeSim> _pendentes;

        public EjecutorDeAcciones(IProvedorSims provedorSims, IFilaInteracoes fila)
        {
            if (provedorSims == null)
                throw new ArgumentNullException("provedorSims");
            if (fila == null)
                throw new ArgumentNullException("fila");

            _provedorSims = provedorSims;
            _fila = fila;
            _pendentes = new List<AcaoDeSim>();
        }

        // ---- hilo externo (servidor/consumidor de respuestas): solo encola ----

        public void Encolar(AcaoDeSim acao)
        {
            if (acao == null || !acao.EhValida())
            {
                MarcarRejeitada(acao, "contrato_invalido");
                return;
            }

            EntradaCatalogoAcoes entrada = CatalogoAcoesPermitidas.Resolver(acao.Interacao);
            if (entrada == null)
            {
                acao.Estado = EstadoAcao.Rejeitada;
                acao.MotivoRejeicao = "interacao_fora_da_lista_branca:" + acao.Interacao;
                return;
            }

            lock (_pendentes)
            {
                _pendentes.Add(acao);
            }
        }

        // ---- hilo del juego (callback AlarmManager): drena y pushea ----

        public IList<AcaoDeSim> DrenarPendentes()
        {
            List<AcaoDeSim> lote;
            lock (_pendentes)
            {
                if (_pendentes.Count == 0)
                    return new AcaoDeSim[0];
                lote = new List<AcaoDeSim>(_pendentes);
                _pendentes.Clear();
            }

            foreach (AcaoDeSim acao in lote)
                ExecutarUma(acao);

            return lote.AsReadOnly();
        }

        private void ExecutarUma(AcaoDeSim acao)
        {
            EntradaCatalogoAcoes entrada = CatalogoAcoesPermitidas.Resolver(acao.Interacao);
            if (entrada == null)
            {
                acao.Estado = EstadoAcao.Rejeitada;
                acao.MotivoRejeicao = "interacao_fora_da_lista_branca:" + acao.Interacao;
                return;
            }

            object simAtor = _provedorSims.ResolverSim(acao.SimAtivo);
            if (!_provedorSims.EhSimValido(simAtor))
            {
                acao.Estado = EstadoAcao.Rejeitada;
                acao.MotivoRejeicao = "sim_ativo_invalido:" + acao.SimAtivo;
                return;
            }

            object simAlvo = null;
            if (!string.IsNullOrEmpty(acao.Alvo))
            {
                simAlvo = _provedorSims.ResolverSim(acao.Alvo);
                if (!_provedorSims.EhSimValido(simAlvo))
                {
                    acao.Estado = EstadoAcao.Rejeitada;
                    acao.MotivoRejeicao = "sim_alvo_invalido:" + acao.Alvo;
                    return;
                }
            }
            else if (entrada.RequiereAlvoSim)
            {
                acao.Estado = EstadoAcao.Rejeitada;
                acao.MotivoRejeicao = "alvo_obrigatorio_ausente";
                return;
            }

            bool ok = _fila.TentarPush(entrada, simAtor, simAlvo, acao.Modo, acao.Prioridade);
            acao.Estado = ok ? EstadoAcao.Executada : EstadoAcao.Falhou;
            if (!ok)
                acao.MotivoRejeicao = "push_falló";
        }

        private static void MarcarRejeitada(AcaoDeSim acao, string motivo)
        {
            if (acao != null)
            {
                acao.Estado = EstadoAcao.Rejeitada;
                acao.MotivoRejeicao = motivo;
            }
        }
    }

    /// <summary>
    /// Implementación que toca APIs reales del juego (compilable sin juego, sin tests runtime).
    /// Resuelve InteractionDefinition.Singleton por reflexión con LeitorPorReflexaoUtil,
    /// hace CreateInstance y pushea en la InteractionQueue del sim actor.
    /// TODO(juego): verificar firmas reales de CreateInstance/PushAsContinuation contra TS3 1.67.
    /// </summary>
    public sealed class AdaptadorFilaInteracoesJogo : IFilaInteracoes
    {
        public bool TentarPush(EntradaCatalogoAcoes entrada, object simAtor, object simAlvo,
            ModoExecucaoAcao modo, PrioridadeAcao prioridade)
        {
            try
            {
                // 1) tipo de la definición contra los ensamblados REALES de TS3 1.67.
                //    (verificado por reflexión: los tipos viven en Sims3GameplaySystems /
                //    Sims3GameplayObjects / SimIFace; el nombre "Sims3.Gameplay" NO existe)
                Type tipoDefinicion = ResolverTipoJuego(entrada.NomeTipoDefinicion);
                if (tipoDefinicion == null)
                    return false;

                // 2) campo estático Singleton (es un FIELD, no una property)
                object singleton = LeitorPorReflexaoUtil.LerEstatico(tipoDefinicion, "Singleton");
                if (singleton == null)
                    return false;

                // 3) CreateInstance(target, actor, priority, isAutonomous, cancellableByPlayer)
                //    Firma verificada en Sims3.Gameplay.Interactions.InteractionDefinition:
                //    InteractionInstance CreateInstance(IGameObject, IActor, InteractionPriority, bool, bool)
                //    InteractionPriority es un STRUCT (ctor(InteractionPriorityLevel)), no un float.
                Type tipoPrioridad = TipoInteractionPriority();
                if (tipoPrioridad == null)
                    return false;
                object prioridadJuego = CrearInteractionPriority(tipoPrioridad, prioridade);
                if (prioridadJuego == null)
                    return false;

                object[] argsCriacao = new object[]
                {
                    simAlvo != null ? simAlvo : simAtor,   // IGameObject target
                    simAtor,                               // IActor actor
                    prioridadJuego,                        // InteractionPriority (struct)
                    false,                                 // isAutonomous
                    true                                   // cancellableByPlayer
                };
                object instancia =
                    LeitorPorReflexaoUtil.InvocarMetodo(singleton, "CreateInstance", argsCriacao);
                if (instancia == null)
                    return false;

                // 4) push en la cola del actor. Firmas verificadas en
                //    Sims3.Gameplay.ActorSystems.InteractionQueue:
                //      bool AddNext(InteractionInstance entry)
                //      bool PushAsContinuation(InteractionInstance instance, bool mustRun)
                object queue = LeitorPorReflexaoUtil.LerPropriedade(simAtor, "InteractionQueue");
                if (queue == null)
                    return false;

                if (modo == ModoExecucaoAcao.Next)
                    return Convert.ToBoolean(
                        LeitorPorReflexaoUtil.InvocarMetodo(queue, "AddNext",
                            new object[] { instancia }));

                return Convert.ToBoolean(
                    LeitorPorReflexaoUtil.InvocarMetodo(queue, "PushAsContinuation",
                        new object[] { instancia, true }));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Niveles del enum InteractionPriorityLevel (verificado contra la 1.67):
        /// Zero=0, Autonomous=1, NonCriticalNPCBehavior=2, UserDirected=3, High=4, ...
        /// Mapeo del mod: baixa=NonCriticalNPCBehavior, normal=UserDirected, alta=High.
        /// </summary>
        private static object CrearInteractionPriority(Type tipoPrioridad, PrioridadeAcao prioridad)
        {
            int nivel;
            switch (prioridad)
            {
                case PrioridadeAcao.Baixa: nivel = 2; break;
                case PrioridadeAcao.Alta: nivel = 4; break;
                default: nivel = 3; break;
            }

            foreach (System.Reflection.ConstructorInfo ctor in tipoPrioridad.GetConstructors())
            {
                System.Reflection.ParameterInfo[] parametros = ctor.GetParameters();
                if (parametros.Length == 1 && parametros[0].ParameterType.IsEnum)
                {
                    object valorEnum = System.Enum.ToObject(parametros[0].ParameterType, nivel);
                    return Activator.CreateInstance(tipoPrioridad, new object[] { valorEnum });
                }
            }

            return null;
        }

        private static Type TipoInteractionPriority()
        {
            Type t = Type.GetType(
                "Sims3.Gameplay.Interactions.InteractionPriority, Sims3GameplaySystems", false);
            if (t != null)
                return t;
            return BuscarTipoCargado("Sims3.Gameplay.Interactions.InteractionPriority");
        }

        private static Type ResolverTipoJuego(string nombreCompleto)
        {
            string[] ensamblados = { "Sims3GameplaySystems", "Sims3GameplayObjects", "SimIFace" };
            foreach (string ensamblado in ensamblados)
            {
                Type t = Type.GetType(nombreCompleto + ", " + ensamblado, false);
                if (t != null)
                    return t;
            }
            return BuscarTipoCargado(nombreCompleto);
        }

        private static Type BuscarTipoCargado(string nomeCompleto)
        {
            System.Reflection.Assembly[] ensamblados = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < ensamblados.Length; i++)
            {
                Type t = ensamblados[i].GetType(nomeCompleto, false);
                if (t != null)
                    return t;
            }
            return null;
        }
    }
}
