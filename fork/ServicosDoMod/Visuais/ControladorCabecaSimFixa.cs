using Sims3.Gameplay;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.UI;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System.Collections;
using HudPieMenu = Sims3.UI.Hud.PieMenu;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Controla a cabeca-mod fixa usando a janela compartilhada do PieMenu sem competir com a cabeca-padrao.
    /// </summary>
    internal sealed class ControladorCabecaSimFixa
    {
        private static readonly Vector2 VetorOlharNeutro = new Vector2(0f, 0f);

        private readonly uint _exportId;
        private readonly SolicitacaoSincronizacao _solicitarSincronizacao;
        private ObjectGuid _guidCabecaClonada = ObjectGuid.InvalidObjectGuid;
        private ObjectGuid _guidTarefaAtualizacao;
        private ulong _idSimSelecionado;
        private bool _cabecaAnexada;
        private bool _cenaInicializada;

        public ControladorCabecaSimFixa(uint exportId, SolicitacaoSincronizacao solicitarSincronizacao)
        {
            _exportId = exportId;
            _solicitarSincronizacao = solicitarSincronizacao;
        }

        public bool TentarSincronizar(ContextoVisualHud contexto, Sim simSelecionado, bool pieMenuVisivel)
        {
            BabyMakerSceneWindow janelaCompartilhada = contexto != null ? contexto.JanelaCabeca as BabyMakerSceneWindow : null;
            if (!PodeSincronizar(janelaCompartilhada, simSelecionado))
            {
                Desativar();
                return false;
            }

            if (TrocaDeSimExigeLimpeza(simSelecionado))
                DestruirCabecaAtual(janelaCompartilhada);

            if (pieMenuVisivel)
                return SuspenderDurantePieMenu(janelaCompartilhada);

            if (!GarantirCabecaClonada(janelaCompartilhada, simSelecionado))
                return false;

            ReposicionarJanelaCompartilhada(janelaCompartilhada, contexto.JanelaHudRaiz);
            return GarantirCabecaAnexada(janelaCompartilhada);
        }

        public bool TentarObterAncora(WindowBase janelaCompartilhada, out Rect areaCabeca)
        {
            areaCabeca = new Rect(new Vector2(0f, 0f), new Vector2(0f, 0f));
            if (janelaCompartilhada == null || !_guidCabecaClonada.IsValid || !_cabecaAnexada)
                return false;

            areaCabeca = janelaCompartilhada.Area;
            return true;
        }

        public void Desativar()
        {
            DestruirCabecaAtual(ObterJanelaCompartilhada());
            _cenaInicializada = false;
        }

        private static bool PodeSincronizar(BabyMakerSceneWindow janelaCompartilhada, Sim simSelecionado)
        {
            return janelaCompartilhada != null
                && simSelecionado != null
                && !simSelecionado.HasBeenDestroyed;
        }

        private bool TrocaDeSimExigeLimpeza(Sim simSelecionado)
        {
            return _idSimSelecionado != 0 && _idSimSelecionado != simSelecionado.ObjectId.Value;
        }

        private bool SuspenderDurantePieMenu(BabyMakerSceneWindow janelaCompartilhada)
        {
            if (!_guidCabecaClonada.IsValid)
                return true;

            TentarRemoverObjetoDaJanela(janelaCompartilhada, _guidCabecaClonada);
            _cabecaAnexada = false;
            Simulator.DestroyObject(_guidCabecaClonada);
            _guidCabecaClonada = ObjectGuid.InvalidObjectGuid;
            _idSimSelecionado = 0uL;
            return true;
        }

        private bool GarantirCabecaClonada(BabyMakerSceneWindow janelaCompartilhada, Sim simSelecionado)
        {
            if (_guidCabecaClonada.IsValid)
                return true;

            ObjectGuid guidCabeca = CriarCabecaClonada(simSelecionado);
            if (!guidCabeca.IsValid)
                return false;

            _guidCabecaClonada = guidCabeca;
            _idSimSelecionado = simSelecionado.ObjectId.Value;
            BabyMakerSceneWindow.SetupSimHeadAnimation(guidCabeca);
            return InicializarCenaSeNecessario(janelaCompartilhada, guidCabeca);
        }

        private bool InicializarCenaSeNecessario(BabyMakerSceneWindow janelaCompartilhada, ObjectGuid guidCabeca)
        {
            if (_cenaInicializada)
                return true;

            if (!janelaCompartilhada.InitScene())
            {
                Simulator.DestroyObject(guidCabeca);
                _guidCabecaClonada = ObjectGuid.InvalidObjectGuid;
                return false;
            }

            janelaCompartilhada.SetupSimHeadScene(VetorOlharNeutro);
            _cenaInicializada = true;
            return true;
        }

        private static void ReposicionarJanelaCompartilhada(BabyMakerSceneWindow janelaCompartilhada, WindowBase janelaHudRaiz)
        {
            if (janelaCompartilhada == null || janelaHudRaiz == null)
                return;

            janelaCompartilhada.Area = PosicionamentoOverlayNarrativo.CriarAreaCabeca(janelaHudRaiz.Area);
            janelaCompartilhada.IgnoreMouse = true;
        }

        private bool GarantirCabecaAnexada(BabyMakerSceneWindow janelaCompartilhada)
        {
            if (_cabecaAnexada)
            {
                janelaCompartilhada.Visible = true;
                return true;
            }

            return TentarAnexarCabecaNaJanela(janelaCompartilhada);
        }

        private bool TentarAnexarCabecaNaJanela(BabyMakerSceneWindow janelaCompartilhada)
        {
            try
            {
                janelaCompartilhada.AddObject(_guidCabecaClonada);
                janelaCompartilhada.SetupSimHeadScene(VetorOlharNeutro);
                janelaCompartilhada.Visible = true;
                _cabecaAnexada = true;
                ReiniciarTaskAtualizacao(janelaCompartilhada);
                return true;
            }
            catch
            {
                _cabecaAnexada = false;
                return false;
            }
        }

        private void ReiniciarTaskAtualizacao(BabyMakerSceneWindow janelaCompartilhada)
        {
            PararTaskAtualizacao();
            _guidTarefaAtualizacao = Simulator.AddObject(new AtualizadorMouseCabecaSim(janelaCompartilhada, _solicitarSincronizacao));
        }

        private BabyMakerSceneWindow ObterJanelaCompartilhada()
        {
            if (HudPieMenu.Instance == null || HudPieMenu.Instance.Parent == null)
                return null;

            return HudPieMenu.Instance.Parent.GetChildByID(_exportId, true) as BabyMakerSceneWindow;
        }

        private void DestruirCabecaAtual(BabyMakerSceneWindow janelaCompartilhada)
        {
            PararTaskAtualizacao();
            OcultarJanelaCompartilhada(janelaCompartilhada);
            DestruirObjetoDaCabecaAtual();
            _idSimSelecionado = 0uL;
            _cabecaAnexada = false;
        }

        private void OcultarJanelaCompartilhada(BabyMakerSceneWindow janelaCompartilhada)
        {
            if (janelaCompartilhada == null)
                return;

            janelaCompartilhada.Visible = false;
            janelaCompartilhada.IgnoreMouse = true;

            if (_guidCabecaClonada.IsValid && _cabecaAnexada)
                TentarRemoverObjetoDaJanela(janelaCompartilhada, _guidCabecaClonada);
        }

        private void DestruirObjetoDaCabecaAtual()
        {
            if (!_guidCabecaClonada.IsValid)
                return;

            Simulator.DestroyObject(_guidCabecaClonada);
            _guidCabecaClonada = ObjectGuid.InvalidObjectGuid;
        }

        private void PararTaskAtualizacao()
        {
            if (!_guidTarefaAtualizacao.IsValid)
                return;

            Simulator.DestroyObject(_guidTarefaAtualizacao);
            _guidTarefaAtualizacao = new ObjectGuid(0uL);
        }

        private static void TentarRemoverObjetoDaJanela(BabyMakerSceneWindow janelaCompartilhada, ObjectGuid guidCabeca)
        {
            try
            {
                janelaCompartilhada.RemoveObject(guidCabeca);
            }
            catch
            {
            }
        }

        private static ObjectGuid CriarCabecaClonada(Sim simSelecionado)
        {
            if (simSelecionado.SimDescription == null || simSelecionado.SimDescription.Age == CASAgeGenderFlags.Baby)
                return ObjectGuid.InvalidObjectGuid;

            SimOutfit outfitValido = ResolverOutfitValido(simSelecionado);
            if (outfitValido == null || !outfitValido.IsValid)
                return ObjectGuid.InvalidObjectGuid;

            SimDescription descricaoClonada = new SimDescription(simSelecionado.SimDescription);
            descricaoClonada.AgingEnabled = false;

            PieMenuSimHead cabeca = GlobalFunctions.CreateObjectWithOverrides(
                "GameSim",
                Vector3.Zero,
                0,
                Vector3.UnitZ,
                CriarOverridesCabeca(outfitValido),
                CriarParametrosCabeca(descricaoClonada)) as PieMenuSimHead;

            if (cabeca == null)
            {
                descricaoClonada.Dispose();
                return ObjectGuid.InvalidObjectGuid;
            }

            cabeca.SetCreationData(simSelecionado, descricaoClonada);
            cabeca.SetIdle();
            CASUtils.SetOutfitInGameObject(outfitValido.Key, cabeca.ObjectId);
            AplicarOverridesVisuaisEspeciais(cabeca, simSelecionado);
            return cabeca.ObjectId;
        }

        private static SimOutfit ResolverOutfitValido(Sim simSelecionado)
        {
            SimOutfit outfitAtual = simSelecionado.CurrentOutfit;
            if (outfitAtual != null && outfitAtual.IsValid)
                return outfitAtual;

            return simSelecionado.SimDescription.GetOutfit(simSelecionado.CurrentOutfitCategory, simSelecionado.CurrentOutfitIndex);
        }

        private static Hashtable CriarOverridesCabeca(SimOutfit outfitValido)
        {
            Hashtable overrides = new Hashtable(4);
            overrides["simOutfitKey"] = outfitValido.Key;
            overrides["scriptClass"] = "Sims3.Gameplay.UI.PieMenuSimHead";
            overrides["animationRunsInRealtime"] = 1u;
            overrides["enableSimPoseProcessing"] = 1u;
            return overrides;
        }

        private static SimInitParameters CriarParametrosCabeca(SimDescription descricaoClonada)
        {
            SimInitParameters parametros = new SimInitParameters(descricaoClonada);
            parametros.AddToObjectManager = false;
            return parametros;
        }

        private static void AplicarOverridesVisuaisEspeciais(PieMenuSimHead cabeca, Sim simSelecionado)
        {
            if (simSelecionado.SimDescription.IsGhost)
            {
                AplicarEstadoFantasma(cabeca, simSelecionado);
                return;
            }

            if (simSelecionado.CurrentSkinColoration != eSkinDiscolorations.None)
            {
                float[] skinConfig = SimTemperature.GetTuningForSkinColoration(simSelecionado.CurrentSkinColoration, simSelecionado.SimDescription.IsAlien);
                World.ObjectSetVisualOverride(cabeca.ObjectId, simSelecionado.IsFemale ? eVisualOverrideTypes.FemaleTan : eVisualOverrideTypes.Tan, skinConfig);
            }
            else if (simSelecionado.SimDescription.IsVampire)
            {
                World.ObjectSetVisualOverride(cabeca.ObjectId, eVisualOverrideTypes.Vampire, null);
            }

            if (simSelecionado.SimDescription.IsAlien)
                World.ObjectSetVisualOverride(cabeca.ObjectId, eVisualOverrideTypes.Alien, null);
        }

        private static void AplicarEstadoFantasma(PieMenuSimHead cabeca, Sim simSelecionado)
        {
            if (!simSelecionado.SimDescription.IsEP11Bot)
            {
                World.ObjectSetGhostState(
                    cabeca.ObjectId,
                    (uint)simSelecionado.SimDescription.DeathStyle,
                    (uint)simSelecionado.SimDescription.AgeGenderSpecies);
                return;
            }

            World.ObjectSetGhostState(cabeca.ObjectId, 23u, (uint)simSelecionado.SimDescription.AgeGenderSpecies);
        }
    }

    /// <summary>
    /// Atualiza o olhar da cabeca fixa e detecta mudancas de visibilidade do PieMenu.
    /// </summary>
    internal sealed class AtualizadorMouseCabecaSim : Task
    {
        private const float ProporcaoCentro = 0.5f;
        private const float DistanciaMaximaOlharPx = 128f;

        private readonly BabyMakerSceneWindow _janela;
        private readonly SolicitacaoSincronizacao _solicitarSincronizacao;
        private bool _eraPieMenuVisivel;

        public AtualizadorMouseCabecaSim(BabyMakerSceneWindow janela, SolicitacaoSincronizacao solicitarSincronizacao)
        {
            _janela = janela;
            _solicitarSincronizacao = solicitarSincronizacao;
        }

        public override void Simulate()
        {
            if (_janela == null)
                return;

            bool pieMenuVisivel = HudPieMenu.IsVisible;
            if (DetectouMudancaDeVisibilidadeDoPieMenu(pieMenuVisivel))
                return;

            if (pieMenuVisivel)
                return;

            GarantirJanelaVisivel();
            AtualizarOlharDaCabeca();
        }

        private bool DetectouMudancaDeVisibilidadeDoPieMenu(bool pieMenuVisivel)
        {
            if (_eraPieMenuVisivel == pieMenuVisivel)
                return false;

            _eraPieMenuVisivel = pieMenuVisivel;
            if (_solicitarSincronizacao != null)
                _solicitarSincronizacao();

            return true;
        }

        private void GarantirJanelaVisivel()
        {
            if (!_janela.Visible)
                _janela.Visible = true;
        }

        private void AtualizarOlharDaCabeca()
        {
            Vector2 cursorNaTela = UIManager.GetCursorPosition();
            Vector2 centroLocal = ObterCentroLocal(_janela.Area);
            Vector2 centroNaTela = _janela.Parent != null
                ? _janela.Parent.WindowToScreen(centroLocal)
                : centroLocal;

            Vector2 deltaCursor = CalcularDeltaLimitado(centroNaTela, cursorNaTela);
            _janela.SetupSimHeadScene(deltaCursor);
        }

        private static Vector2 ObterCentroLocal(Rect area)
        {
            return new Vector2(
                area.TopLeft.x + (area.Width * ProporcaoCentro),
                area.TopLeft.y + (area.Height * ProporcaoCentro));
        }

        private static Vector2 CalcularDeltaLimitado(Vector2 centroNaTela, Vector2 cursorNaTela)
        {
            Vector2 deltaCursor = centroNaTela - cursorNaTela;
            float distanciaMaximaQuadrada = DistanciaMaximaOlharPx * DistanciaMaximaOlharPx;
            if (deltaCursor.LengthSqr() <= distanciaMaximaQuadrada)
                return deltaCursor;

            deltaCursor.Normalize();
            deltaCursor *= DistanciaMaximaOlharPx;
            return deltaCursor;
        }
    }
}
