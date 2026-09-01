using Sims3.SimIFace;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Centraliza os calculos de layout do overlay narrativo para facilitar manutencao e leitura.
    /// </summary>
    internal static class PosicionamentoOverlayNarrativo
    {
        public const float TamanhoCabecaPx = 192f;
        public const float ProporcaoCentroHorizontal = 0.5f;
        public const float ProporcaoLinhaDeCorteDaCabeca = 0.18f;
        public const float DeslocamentoVerticalTooltipPx = 6f;
        public const float SobreposicaoTooltipCabecaPx = 10f;

        private const float MargemDireitaCabecaPx = 52f;
        private const float MargemInferiorCabecaPx = 88f;
        private const float MargemMinimaHorizontalPx = 24f;
        private const float MargemMinimaVerticalPx = 12f;
        private const float Unidade = 1f;

        /// <summary>
        /// Posiciona a cabeca no canto inferior-direito do HUD, respeitando margens minimas.
        /// </summary>
        public static Rect CriarAreaCabeca(Rect areaPai)
        {
            float limiteEsquerdo = areaPai.TopLeft.x + MargemMinimaHorizontalPx;
            float limiteDireito = areaPai.TopLeft.x + areaPai.Width - TamanhoCabecaPx - MargemMinimaHorizontalPx;
            float limiteSuperior = areaPai.TopLeft.y + MargemMinimaVerticalPx;
            float limiteInferior = areaPai.TopLeft.y + areaPai.Height - TamanhoCabecaPx - MargemMinimaVerticalPx;

            float posicaoX = areaPai.TopLeft.x + areaPai.Width - TamanhoCabecaPx - MargemDireitaCabecaPx;
            float posicaoY = areaPai.TopLeft.y + areaPai.Height - TamanhoCabecaPx - MargemInferiorCabecaPx;

            posicaoX = LimitarEntre(posicaoX, limiteEsquerdo, limiteDireito);
            posicaoY = LimitarEntre(posicaoY, limiteSuperior, limiteInferior);

            return new Rect(
                new Vector2(posicaoX, posicaoY),
                new Vector2(posicaoX + TamanhoCabecaPx, posicaoY + TamanhoCabecaPx));
        }

        /// <summary>
        /// Retorna o ponto visual de corte da cabeca usado para ancorar a tooltip.
        /// </summary>
        public static Vector2 CriarPontoDeCorteDaCabeca(Rect areaCabeca)
        {
            return new Vector2(
                areaCabeca.TopLeft.x + (areaCabeca.Width * ProporcaoCentroHorizontal),
                areaCabeca.TopLeft.y + (areaCabeca.Height * ProporcaoLinhaDeCorteDaCabeca));
        }

        /// <summary>
        /// Calcula a posicao da tooltip acima da cabeca, com fallback para abaixo quando necessario.
        /// </summary>
        public static Vector2 CalcularPosicaoTooltip(Vector2 pontoDeCorteLocal, Vector2 tamanhoTooltip, Rect limites)
        {
            Vector2 posicaoAcima = CalcularPosicaoTooltipAcima(pontoDeCorteLocal, tamanhoTooltip);
            if (posicaoAcima.y >= limites.TopLeft.y)
                return LimitarPosicao(posicaoAcima, tamanhoTooltip, limites);

            Vector2 posicaoAbaixo = CalcularPosicaoTooltipAbaixo(pontoDeCorteLocal, tamanhoTooltip);
            return LimitarPosicao(posicaoAbaixo, tamanhoTooltip, limites);
        }

        private static Vector2 CalcularPosicaoTooltipAcima(Vector2 pontoDeCorteLocal, Vector2 tamanhoTooltip)
        {
            return new Vector2(
                pontoDeCorteLocal.x - (tamanhoTooltip.x * ProporcaoCentroHorizontal),
                pontoDeCorteLocal.y - tamanhoTooltip.y + SobreposicaoTooltipCabecaPx + DeslocamentoVerticalTooltipPx);
        }

        private static Vector2 CalcularPosicaoTooltipAbaixo(Vector2 pontoDeCorteLocal, Vector2 tamanhoTooltip)
        {
            return new Vector2(
                pontoDeCorteLocal.x - (tamanhoTooltip.x * ProporcaoCentroHorizontal),
                pontoDeCorteLocal.y + (TamanhoCabecaPx * (Unidade - ProporcaoLinhaDeCorteDaCabeca)) - SobreposicaoTooltipCabecaPx + DeslocamentoVerticalTooltipPx);
        }

        private static Vector2 LimitarPosicao(Vector2 canto, Vector2 tamanho, Rect limites)
        {
            float x = canto.x;
            float y = canto.y;
            float limiteDireito = limites.TopLeft.x + limites.Width;
            float limiteInferior = limites.TopLeft.y + limites.Height;

            if (x < limites.TopLeft.x) x = limites.TopLeft.x;
            if (x + tamanho.x > limiteDireito) x = limiteDireito - tamanho.x;
            if (y < limites.TopLeft.y) y = limites.TopLeft.y;
            if (y + tamanho.y > limiteInferior) y = limiteInferior - tamanho.y;
            if (x < limites.TopLeft.x) x = limites.TopLeft.x;
            if (y < limites.TopLeft.y) y = limites.TopLeft.y;

            return new Vector2(x, y);
        }

        private static float LimitarEntre(float valor, float minimo, float maximo)
        {
            if (valor < minimo)
                return minimo;

            if (valor > maximo)
                return maximo;

            return valor;
        }
    }
}
