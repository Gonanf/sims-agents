using NarradorPorEventos.Dominio;
using Sims3.Gameplay;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.UI;
using Sims3.SimIFace;
using Sims3.UI;
using UiResponder = Sims3.UI.Responder;
using HudPieMenu = Sims3.UI.Hud.PieMenu;
using GameplayOneShotFunctionTask = Sims3.Gameplay.OneShotFunctionTask;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Orquestra o overlay narrativo no HUD, delegando estado, cabeca, tooltip e layout
    /// para componentes especializados e menores.
    /// </summary>
    internal sealed class ControladorRecursosVisuaisNarrativos
    {
        private const uint ExportIdJanelaCabecaHud = 106666616u;

        private readonly ConfiguracaoCentral _config;
        private readonly EstadoNarrativaVisual _estadoNarrativa;
        private readonly ControladorCabecaSimFixa _controladorCabeca;
        private readonly ControladorTooltipNarrativoSobreCabeca _controladorTooltip;

        private EventListener _listenerSelecaoSim;
        private bool _inicializado;
        private bool _sincronizacaoPendente;
        private ulong _idSimAnteriorSync;

        public ControladorRecursosVisuaisNarrativos(ConfiguracaoCentral config)
        {
            _config = config;
            _estadoNarrativa = new EstadoNarrativaVisual();
            _controladorCabeca = new ControladorCabecaSimFixa(ExportIdJanelaCabecaHud, AgendarSincronizacao);
            _controladorTooltip = new ControladorTooltipNarrativoSobreCabeca(_estadoNarrativa);
        }

        public void Inicializar()
        {
            if (_inicializado)
                return;

            _listenerSelecaoSim = EventTracker.AddListener(EventTypeId.kEventSimSelected, AoSelecionarSim);
            if (UiResponder.Instance != null)
                UiResponder.Instance.GameStateChanging += AoAlterarSubEstado;

            _inicializado = true;
            AgendarSincronizacao();
        }

        public void Desativar()
        {
            if (_listenerSelecaoSim != null)
            {
                EventTracker.RemoveListener(_listenerSelecaoSim);
                _listenerSelecaoSim = null;
            }

            if (UiResponder.Instance != null)
                UiResponder.Instance.GameStateChanging -= AoAlterarSubEstado;

            _sincronizacaoPendente = false;
            _controladorTooltip.Desativar();
            _controladorCabeca.Desativar();
            _inicializado = false;
        }

        public void AtualizarRespostaNarrativa(RespostaNarrativa resposta)
        {
            if (resposta == null)
                return;

            _estadoNarrativa.Atualizar(resposta);
            AgendarSincronizacao();
        }

        private ListenerAction AoSelecionarSim(Event e)
        {
            AgendarSincronizacao();
            return ListenerAction.Keep;
        }

        private void AoAlterarSubEstado(UiResponder.GameSubState estadoAnterior, UiResponder.GameSubState novoEstado)
        {
            AgendarSincronizacao();
        }

        private void AgendarSincronizacao()
        {
            if (!_inicializado || _sincronizacaoPendente)
                return;

            _sincronizacaoPendente = true;
            Simulator.AddObject(new GameplayOneShotFunctionTask(AoSincronizarAgendado));
        }

        private void AoSincronizarAgendado()
        {
            _sincronizacaoPendente = false;

            try
            {
                SincronizarComContextoVisual();
            }
            catch
            {
                _controladorTooltip.Ocultar();
                _controladorCabeca.Desativar();
            }
        }

        private void SincronizarComContextoVisual()
        {
            ContextoVisualHud contextoVisual;
            if (!ContextoVisualHud.TentarCapturar(ExportIdJanelaCabecaHud, out contextoVisual))
            {
                OcultarRecursosVisuais();
                return;
            }

            Sim simSelecionado = ResolverSimSelecionado();
            if (!SimSelecionadoEstaValido(simSelecionado))
            {
                _idSimAnteriorSync = 0;
                OcultarRecursosVisuais();
                return;
            }

            AtualizarEstadoParaTrocaDeSim(simSelecionado);
            bool pieMenuVisivel = HudPieMenu.IsVisible;

            if (!SincronizarCabeca(contextoVisual, simSelecionado, pieMenuVisivel))
            {
                _controladorTooltip.Ocultar();
                return;
            }

            if (pieMenuVisivel)
            {
                _controladorTooltip.Ocultar();
                return;
            }

            SincronizarTooltip(contextoVisual, simSelecionado);
        }

        private void OcultarRecursosVisuais()
        {
            _controladorTooltip.Ocultar();
            _controladorCabeca.Desativar();
        }

        private void AtualizarEstadoParaTrocaDeSim(Sim simSelecionado)
        {
            if (_idSimAnteriorSync != 0 && _idSimAnteriorSync != simSelecionado.ObjectId.Value)
                _estadoNarrativa.PurgarPensamento();

            _idSimAnteriorSync = simSelecionado.ObjectId.Value;
        }

        private bool SincronizarCabeca(ContextoVisualHud contextoVisual, Sim simSelecionado, bool pieMenuVisivel)
        {
            if (!_config.RecursosVisuaisCabecaSimFixaAtivos)
            {
                _controladorCabeca.Desativar();
                return true;
            }

            return _controladorCabeca.TentarSincronizar(contextoVisual, simSelecionado, pieMenuVisivel);
        }

        private void SincronizarTooltip(ContextoVisualHud contextoVisual, Sim simSelecionado)
        {
            if (_config.RecursosVisuaisTextoNarrativoAtivos)
            {
                _controladorTooltip.TentarSincronizar(contextoVisual, _controladorCabeca, simSelecionado);
                return;
            }

            _controladorTooltip.Ocultar();
        }

        private static bool SimSelecionadoEstaValido(Sim simSelecionado)
        {
            return simSelecionado != null
                && !simSelecionado.HasBeenDestroyed
                && simSelecionado.LotCurrent != null;
        }

        private static Sim ResolverSimSelecionado()
        {
            Sim simAtivo = Sim.ActiveActor;
            if (simAtivo != null && !simAtivo.HasBeenDestroyed)
                return simAtivo;

            Sim simSelecionado = PlumbBob.SelectedActor;
            if (simSelecionado != null && !simSelecionado.HasBeenDestroyed)
                return simSelecionado;

            return null;
        }
    }
}
