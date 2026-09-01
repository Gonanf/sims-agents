using Sims3.Gameplay.Actors;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Controla a tooltip que exibe pensamento ou mensagem idle ancorada na cabeca fixa.
    /// </summary>
    internal sealed class ControladorTooltipNarrativoSobreCabeca
    {
        private const int LarguraMaximaTextoPx = 340;

        private static readonly string[] MensagensIdle = new string[]
        {
            "Verificando se a Dona Morte passou por aqui.",
            "Questionando se meu criador se importa com isso.",
            "Tentando conjugar o Sul Sul no imperfeito do subjuntivo.",
            "Atualizando o acervo de fofocas do bairro.",
            "Consultando as memórias de vidas que talvez não existam.",
            "Avaliando o peso narrativo desse momento.",
            "Tentando decidir se vale guardar esse rancor.",
            "Processando o significado de existir num mundo simulado.",
            "Ouvindo o silêncio entre uma ação e outra.",
            "Registrando esse instante para a posteridade.",
            "Organizando os capítulos dessa vida sem ordem certa.",
            "Esperando que alguém no bairro faça algo interessante.",
            "Refletindo sobre tudo que não foi dito hoje.",
            "Tentando limpar a mente antes da próxima interação.",
            "Conferindo se alguém está observando por aí.",
            "Arquivando esse sentimento sem nome por enquanto.",
            "Cogitando a possibilidade de ter livre-arbítrio.",
            "Aguardando o próximo capítulo dessa existência.",
            "Percebendo que o tempo aqui passa de um jeito estranho.",
            "Deixando os pensamentos assentarem um pouco.",
        };

        private readonly EstadoNarrativaVisual _estadoNarrativa;
        private SimpleTextTooltip _tooltip;
        private string _ultimoTexto = string.Empty;
        private int _indiceMensagemIdle;

        public ControladorTooltipNarrativoSobreCabeca(EstadoNarrativaVisual estadoNarrativa)
        {
            _estadoNarrativa = estadoNarrativa;
        }

        public bool TentarSincronizar(ContextoVisualHud contextoVisual, ControladorCabecaSimFixa controladorCabeca, Sim simSelecionado)
        {
            if (!PodeSincronizar(contextoVisual, simSelecionado))
            {
                Ocultar();
                return false;
            }

            if (!GarantirTooltipInicializada())
            {
                Ocultar();
                return false;
            }

            string textoExibido = MontarTextoExibido(simSelecionado);
            if (string.IsNullOrEmpty(textoExibido))
            {
                Ocultar();
                return false;
            }

            AtualizarTextoSeNecessario(textoExibido);
            if (!PosicionarTooltip(contextoVisual, controladorCabeca))
            {
                Ocultar();
                return false;
            }

            ExibirTooltip();
            return true;
        }

        public void Ocultar()
        {
            if (_tooltip == null || _tooltip.TooltipWindow == null)
                return;

            _tooltip.TooltipWindow.IgnoreMouse = true;
            _tooltip.TooltipWindow.Visible = false;
        }

        public void Desativar()
        {
            if (_tooltip != null)
            {
                Ocultar();
                _tooltip.Dispose();
                _tooltip = null;
            }

            _ultimoTexto = string.Empty;
            _indiceMensagemIdle = 0;
        }

        private static bool PodeSincronizar(ContextoVisualHud contextoVisual, Sim simSelecionado)
        {
            return contextoVisual != null
                && contextoVisual.JanelaHudRaiz != null
                && simSelecionado != null
                && !simSelecionado.HasBeenDestroyed;
        }

        private bool GarantirTooltipInicializada()
        {
            if (_tooltip != null && _tooltip.TooltipWindow != null)
                return _tooltip.TooltipWindow.Parent != null;

            _tooltip = new SimpleTextTooltip(" ", false, "SimpleTextTooltip", 1, LarguraMaximaTextoPx);
            if (_tooltip.TooltipWindow == null)
                return false;

            Text textoNarrativo = _tooltip.TooltipWindow as Text;
            if (textoNarrativo != null)
            {
                textoNarrativo.WordWrap = Text.TextWrapModes.kTWOn;
                textoNarrativo.Overflow = Text.OverflowModes.kTONone;
            }

            _tooltip.TooltipWindow.IgnoreMouse = true;
            _tooltip.TooltipWindow.Visible = false;
            return _tooltip.TooltipWindow.Parent != null;
        }

        private string MontarTextoExibido(Sim simSelecionado)
        {
            string pensamentoAtual = AdaptadorTextoNarrativo.ParaLinhaUnica(_estadoNarrativa.ObterPensamentoAtual());
            if (!string.IsNullOrEmpty(pensamentoAtual))
                return pensamentoAtual;

            return MontarMensagemIdle(simSelecionado);
        }

        private void AtualizarTextoSeNecessario(string textoExibido)
        {
            if (string.Equals(_ultimoTexto, textoExibido, StringComparison.Ordinal))
                return;

            _tooltip.TooltipText = textoExibido;
            _ultimoTexto = textoExibido;
        }

        private bool PosicionarTooltip(ContextoVisualHud contextoVisual, ControladorCabecaSimFixa controladorCabeca)
        {
            WindowBase janelaTooltip = _tooltip.TooltipWindow;
            WindowBase janelaPai = janelaTooltip.Parent;
            if (janelaPai == null)
                return false;

            Rect areaCabeca = ObterAreaCabeca(contextoVisual, controladorCabeca);
            Vector2 pontoDeCorteNaHud = PosicionamentoOverlayNarrativo.CriarPontoDeCorteDaCabeca(areaCabeca);
            Vector2 pontoDeCorteNaTela = contextoVisual.JanelaHudRaiz.WindowToScreen(pontoDeCorteNaHud);
            Vector2 pontoDeCorteNoPaiTooltip = janelaPai.ScreenToWindow(pontoDeCorteNaTela);
            Vector2 tamanhoTooltip = new Vector2(janelaTooltip.Area.Width, janelaTooltip.Area.Height);
            Vector2 posicaoTooltip = PosicionamentoOverlayNarrativo.CalcularPosicaoTooltip(pontoDeCorteNoPaiTooltip, tamanhoTooltip, janelaPai.Area);

            janelaTooltip.Area = new Rect(posicaoTooltip, posicaoTooltip + tamanhoTooltip);
            janelaTooltip.IgnoreMouse = true;
            return true;
        }

        private static Rect ObterAreaCabeca(ContextoVisualHud contextoVisual, ControladorCabecaSimFixa controladorCabeca)
        {
            Rect areaCabeca;
            if (controladorCabeca.TentarObterAncora(contextoVisual.JanelaCabeca, out areaCabeca))
                return areaCabeca;

            return PosicionamentoOverlayNarrativo.CriarAreaCabeca(contextoVisual.JanelaHudRaiz.Area);
        }

        private void ExibirTooltip()
        {
            _tooltip.TooltipWindow.IgnoreMouse = true;
            _tooltip.TooltipWindow.Visible = true;
        }

        private string MontarMensagemIdle(Sim simSelecionado)
        {
            if (MensagensIdle.Length == 0)
                return "...";

            int indiceBase = 0;
            if (simSelecionado != null)
                indiceBase = (int)(simSelecionado.ObjectId.Value % (ulong)MensagensIdle.Length);

            int indiceMensagem = (indiceBase + _indiceMensagemIdle) % MensagensIdle.Length;
            _indiceMensagemIdle = (_indiceMensagemIdle + 1) % MensagensIdle.Length;
            return "(" + MensagensIdle[indiceMensagem] + ")";
        }
    }
}
