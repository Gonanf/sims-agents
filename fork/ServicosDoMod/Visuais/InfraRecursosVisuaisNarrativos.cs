using NarradorPorEventos.Dominio;
using Sims3.Gameplay;
using Sims3.UI;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using HudPieMenu = Sims3.UI.Hud.PieMenu;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Delegate usado pelos componentes visuais para pedir uma nova sincronizacao do HUD.
    /// </summary>
    internal delegate void SolicitacaoSincronizacao();

    /// <summary>
    /// Mantem o ultimo pensamento valido recebido para exibicao no overlay visual.
    /// </summary>
    internal sealed class EstadoNarrativaVisual
    {
        private string _pensamentoAtual = string.Empty;

        public void Atualizar(RespostaNarrativa resposta)
        {
            if (!EhPensamentoValido(resposta))
                return;

            string textoPensamento = AdaptadorTextoNarrativo.ParaLinhaUnica(resposta.TextoResposta.Valor);
            if (string.IsNullOrEmpty(textoPensamento))
                return;

            _pensamentoAtual = textoPensamento;
        }

        public void PurgarPensamento()
        {
            _pensamentoAtual = string.Empty;
        }

        public string ObterPensamentoAtual()
        {
            return _pensamentoAtual;
        }

        private static bool EhPensamentoValido(RespostaNarrativa resposta)
        {
            return resposta != null
                && !string.IsNullOrEmpty(resposta.TipoNarrativa)
                && resposta.TextoResposta != null
                && TipoNarrativa.Corresponde(resposta.TipoNarrativa, TipoNarrativa.Pensamento);
        }
    }

    /// <summary>
    /// Representa as janelas minimas do HUD necessarias para desenhar os recursos visuais narrativos.
    /// </summary>
    internal sealed class ContextoVisualHud
    {
        private ContextoVisualHud(WindowBase janelaHudRaiz, WindowBase janelaCabeca)
        {
            JanelaHudRaiz = janelaHudRaiz;
            JanelaCabeca = janelaCabeca;
        }

        public WindowBase JanelaHudRaiz { get; private set; }

        public WindowBase JanelaCabeca { get; private set; }

        public static bool TentarCapturar(uint exportIdJanelaCabeca, out ContextoVisualHud contexto)
        {
            contexto = null;
            if (!HudEstaDisponivel())
                return false;

            WindowBase janelaHudRaiz = HudPieMenu.Instance.Parent;
            WindowBase janelaCabeca = janelaHudRaiz.GetChildByID(exportIdJanelaCabeca, true);
            if (janelaCabeca == null)
                return false;

            contexto = new ContextoVisualHud(janelaHudRaiz, janelaCabeca);
            return true;
        }

        private static bool HudEstaDisponivel()
        {
            return GameStates.IsLiveState
                && LoadingScreenController.Instance == null
                && UIManager.GetUITopWindow() != null
                && HudPieMenu.Instance != null
                && HudPieMenu.Instance.Parent != null;
        }
    }
}
