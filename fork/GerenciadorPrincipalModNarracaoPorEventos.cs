using Sims3.Gameplay.Actors;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using System.Collections.Generic;
using NarradorPorEventos.Dominio;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Ponto de entrada do mod no carregamento do mundo e orquestrador do fluxo narrativo.
    /// </summary>
    /// <remarks>
    /// <para>Este gerenciador tem duas responsabilidades complementares, não duas filas:</para>
    /// <list type="number">
    /// <item>
    /// <description><c>RegistrarOuvintesNarrativos()</c> conecta callbacks no <c>EventTracker</c> para cada <c>EventTypeId</c> mapeado.</description>
    /// </item>
    /// <item>
    /// <description><c>IniciarConsumidorDaFilaNarrativa()</c> inicia um alarme periódico que consome a <b>mesma fila</b> de eventos no <c>ControladorFilaEventosNarrativos</c>.</description>
    /// </item>
    /// </list>
    /// <para>Benefício prático: os listeners recebem os eventos imediatamente, mas o processamento narrativo é drenado em lotes por uma política interna da fila para evitar picos de custo quando há muitos eventos catalogados.</para>
    /// </remarks>
    public class GerenciadorPrincipalModNarracaoPorEventos
    {



        [Tunable] protected static bool kInstantiator = false;

        private static ConfiguracaoCentral _config;
        private static IAdaptadorExcecoesMod _adaptadorExcecoes;
        private static MotorNarrativo _motorNarrativo;
        private static ControladorFilaEventosNarrativos _controladorFilaEventosNarrativos;
        private static ControladorRecursosVisuaisNarrativos _controladorRecursosVisuaisNarrativos;
        private static AlarmHandle _cicloProgramadoHandle = AlarmHandle.kInvalidHandle;
        private static AlarmHandle _hotReloadConfiguracaoHandle = AlarmHandle.kInvalidHandle;
        private static AlarmHandle _drenajeAccionesHandle = AlarmHandle.kInvalidHandle;

        // fork sims-agents: ejecutor de acciones tipadas del LLM (ítems 3-5 del checklist)
        private static EjecutorDeAcciones _ejecutorAcciones;

        private static readonly Dictionary<string, bool> _idsEventosDisponiveis = CriarMapaIdsEventosDisponiveis();

        static GerenciadorPrincipalModNarracaoPorEventos()
                {
                    // Solo suscribir al evento world-load. NO tocar IO aquí: EA mscorlib recortado no tiene
                    // System.IO.Path/File/Directory/Environment.SpecialFolder. El boot.log se escribe en
                    // AoCarregarMundo usando ContextoMod.Arquivos (adapter dual S3SE + fallback System.IO).
                    World.sOnWorldLoadFinishedEventHandler += AoCarregarMundo;
                }

        private static void AoCarregarMundo(object sender, EventArgs e)
        {
            try
            {
                string docsRaw = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                string baseEA = System.IO.Path.Combine(docsRaw, "Electronic Arts");
                string rawMsg = "AoCarregarMundo " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                try { string p = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(baseEA, "Los Sims 3"), "Mods"), "NarradorPorEventos"); System.IO.Directory.CreateDirectory(p); System.IO.File.WriteAllText(System.IO.Path.Combine(p, "boot_raw.log"), rawMsg); } catch { }
                try { string p = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(baseEA, "The Sims 3"), "Mods"), "NarradorPorEventos"); System.IO.Directory.CreateDirectory(p); System.IO.File.WriteAllText(System.IO.Path.Combine(p, "boot_raw.log"), rawMsg); } catch { }
            }
            catch { }

            try
            {
                InicializarDependencias();
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoCarregarMundo", ex, "falha ao inicializar dependências");
                NotificadorDoMod.Notificar("[NarradorPorEventos] ERRO na inicialização:\n" + ex.GetType().Name + ": " + ex.Message, StyledNotification.NotificationStyle.kGameMessageNegative);
                return;
            }

            try
            {
                string msg = "suscripto a OnWorldLoadFinished " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                ContextoMod.Arquivos.EscreverTexto(
                    ContextoMod.Arquivos.ObterDiretorioDoMod() + "/boot.log",
                    msg);
            }
            catch
            {
            }

            try
            {
                NotificadorDoMod.NotificarSucessoCarregamentoMod();
                RegistrarOuvintesNarrativos();
                IniciarConsumidorDaFilaNarrativa();
                RegistrarCicloProgramado();
                RegistrarCicloHotReloadConfiguracao();
                RegistrarAlarmeDrenajeAcciones();
                RegistrarOuvinteConfirmacionAcciones();
                SincronizarRecursosVisuais();
                NotificadorDoMod.NotificarSucessoInicializacao();
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoCarregarMundo", ex, "falha na inicialização do mod");
                NotificadorDoMod.Notificar("[NarradorPorEventos] ERRO na inicialização:\n" + ex.GetType().Name + ": " + ex.Message, StyledNotification.NotificationStyle.kGameMessageNegative);
            }
        }

        /// <summary>
        /// Inicia o consumidor periódico da fila narrativa compartilhada.
        /// </summary>
        /// <remarks>
        /// <para>Não cria uma nova fila. Apenas ativa o alarme que consome a fila já usada por <c>AoEventoNarrativo</c>.</para>
        /// </remarks>
        private static void IniciarConsumidorDaFilaNarrativa()
        {
            if (_controladorFilaEventosNarrativos != null)
                _controladorFilaEventosNarrativos.IniciarProcessamento();
        }

        private static bool EventoEhRuido(Event e)
        {
            if (e == null)
                return true;

            EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver(e.Id.ToString());
            return tipo != null && tipo.EhRuido;
        }

        private static void InicializarDependencias()
        {
            ContextoMod.RecarregarConfiguracao();
            _config = ContextoMod.Configuracao;
            _adaptadorExcecoes = new AdaptadorExcecoesArquivo(ContextoMod.Arquivos, _config);

            // fork sims-agents (ítem 3): ejecutor real de acciones + wiring al consumidor
            // de respuestas del MotorNarrativo. Encolar() ocurre en el hilo lógico del juego
            // (LidarComRespostasDoServidor corre desde listeners/alarmes) y el push real se
            // drena en AoDrenarAccionesPendentes vía alarme (mismo patrón del drain existente).
            if (_ejecutorAcciones == null)
                _ejecutorAcciones = new EjecutorDeAcciones(
                    new AdaptadorProvedorSimsJogo(),
                    new AdaptadorFilaInteracoesJogo());

            _motorNarrativo = new MotorNarrativo(_config, ContextoMod.Arquivos, _adaptadorExcecoes,
                AoRespostaNarrativaRecebida, AoAcaoNarrativaRecebida);
            _controladorFilaEventosNarrativos = new ControladorFilaEventosNarrativos(
                _motorNarrativo,
                _adaptadorExcecoes);
        }

        /// <summary>
        /// fork sims-agents: callback del MotorNarrativo para acciones tipadas del LLM.
        /// Solo encola; el push ocurre después, en el callback del alarme (hilo del juego).
        /// </summary>
        private static void AoAcaoNarrativaRecebida(AcaoDeSim acao)
        {
            try
            {
                if (_ejecutorAcciones != null && acao != null)
                    _ejecutorAcciones.Encolar(acao);
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoAcaoNarrativaRecebida", ex,
                    acao != null ? acao.Interacao : "acao_nula");
            }
        }

        /// <summary>
        /// fork sims-agents (ítem 3): alarme periódico que drena las acciones pendientes y
        /// pushea las interacciones — SIEMPRE en el hilo lógico del juego.
        /// </summary>
        private static void RegistrarAlarmeDrenajeAcciones()
        {
            if (_drenajeAccionesHandle != AlarmHandle.kInvalidHandle)
                AlarmManager.Global.RemoveAlarm(_drenajeAccionesHandle);

            const float intervaloMinutos = 1f;
            _drenajeAccionesHandle = AlarmManager.Global.AddAlarmRepeating(
                intervaloMinutos,
                TimeUnit.Minutes,
                AoDrenarAccionesPendentes,
                intervaloMinutos,
                TimeUnit.Minutes,
                "NarradorPorEventos.DrenajeAcciones",
                AlarmType.AlwaysPersisted,
                null);
        }

        private static void AoDrenarAccionesPendentes()
        {
            try
            {
                if (_ejecutorAcciones == null)
                    return;

                IList<AcaoDeSim> lote = _ejecutorAcciones.DrenarPendentes();
                foreach (AcaoDeSim acao in lote)
                {
                    // ítem 5 (lazo cerrado): las sociales ejecutadas quedan pendientes de
                    // confirmación por EventTypeId.kSocialInteraction
                    EntradaCatalogoAcoes entrada = CatalogoAcoesPermitidas.Resolver(acao.Interacao);
                    if (acao.Estado == EstadoAcao.Executada && entrada != null && entrada.RequiereAlvoSim)
                        SupervisorConfirmacionesAcciones.RegistrarPendiente(acao);
                }
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoDrenarAccionesPendentes", ex, "drenaje de acciones");
            }
        }

        /// <summary>
        /// fork sims-agents (ítem 5): listener del EventTypeId.kSocialInteraction que confirma
        /// la ejecución de una acción social pusheada y realimenta al LLM vía log narrativo.
        /// </summary>
        private static void RegistrarOuvinteConfirmacionAcciones()
        {
            try
            {
                EventTracker.AddListener(EventTypeId.kSocialInteraction, AoEventoConfirmacionAcao);
            }
            catch (Exception ex)
            {
                RegistrarExcecao("RegistrarOuvinteConfirmacionAcciones", ex, "kSocialInteraction");
            }
        }

        private static ListenerAction AoEventoConfirmacionAcao(Event e)
        {
            try
            {
                if (e == null || _motorNarrativo == null)
                    return ListenerAction.Keep;

                AcaoDeSim confirmada = SupervisorConfirmacionesAcciones.ConfirmarSiCorresponde(e.Actor);
                if (confirmada != null)
                    _motorNarrativo.RegistrarConfirmacionAcao(confirmada);
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoEventoConfirmacionAcao", ex,
                    e != null ? e.Id.ToString() : "evento_nulo");
            }

            return ListenerAction.Keep;
        }

        /// <summary>
        /// Registra listeners no <c>EventTracker</c> para todos os eventos narrativos mapeados.
        /// </summary>
        /// <remarks>
        /// <para>Listener não processa narrativa pesada; ele apenas recebe o evento e delega o enfileiramento.</para>
        /// </remarks>
        private static void RegistrarOuvintesNarrativos()
        {
            int totalRegistrados = 0;
            Dictionary<string, bool> eventosJaRegistrados = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (EventoTheSims3 tipo in RepositorioEventosTheSims3.Todos())
            {
                if (tipo == null || string.IsNullOrEmpty(tipo.EventoId))
                    continue;

                if (eventosJaRegistrados.ContainsKey(tipo.EventoId))
                    continue;

                if (RegistrarOuvintePorIdJogo(tipo.EventoId))
                {
                    eventosJaRegistrados[tipo.EventoId] = true;
                    totalRegistrados++;
                }
            }

            if (totalRegistrados == 0)
                NotificadorDoMod.Notificar("[NarradorPorEventos] Aviso: nenhum ouvinte narrativo foi registrado.", StyledNotification.NotificationStyle.kGameMessageNegative);
        }

        private static bool RegistrarOuvintePorIdJogo(string eventoId)
        {
            if (string.IsNullOrEmpty(eventoId))
                return false;

            if (!_idsEventosDisponiveis.ContainsKey(eventoId.Trim()))
                return false;

            try
            {
                EventTypeId id = (EventTypeId)Enum.Parse(typeof(EventTypeId), eventoId.Trim(), true);
                EventTracker.AddListener(id, AoEventoNarrativo);
                return true;
            }
            catch (Exception ex)
            {
                RegistrarExcecao("RegistrarOuvintePorIdJogo", ex, eventoId);
                return false;
            }
        }

        private static void RegistrarCicloProgramado()
        {
            if (_cicloProgramadoHandle != AlarmHandle.kInvalidHandle)
                AlarmManager.Global.RemoveAlarm(_cicloProgramadoHandle);

            float intervaloHoras = _config != null ? _config.IntervaloPersistenciaHoras : 1f;
            if (intervaloHoras <= 0f)
                intervaloHoras = 1f;

            _cicloProgramadoHandle = AlarmManager.Global.AddAlarmRepeating(
                intervaloHoras,
                TimeUnit.Hours,
                AoCicloProgramado,
                intervaloHoras,
                TimeUnit.Hours,
                "NarradorPorEventos.CicloProgramado",
                AlarmType.AlwaysPersisted,
                null);
        }

        private static void RegistrarCicloHotReloadConfiguracao()
        {
            if (_hotReloadConfiguracaoHandle != AlarmHandle.kInvalidHandle)
                AlarmManager.Global.RemoveAlarm(_hotReloadConfiguracaoHandle);

            float intervaloMinutos = ObterIntervaloHotReloadMinutos();
            _hotReloadConfiguracaoHandle = AlarmManager.Global.AddAlarmRepeating(
                intervaloMinutos,
                TimeUnit.Minutes,
                AoVerificarHotReloadConfiguracao,
                intervaloMinutos,
                TimeUnit.Minutes,
                "NarradorPorEventos.HotReloadConfiguracao",
                AlarmType.AlwaysPersisted,
                null);
        }

        private static float ObterIntervaloHotReloadMinutos()
        {
            float intervaloMs = _config != null ? _config.IntervaloHotReloadMs : 10000f;
            float intervaloMinutos = intervaloMs / 60000f;
            if (intervaloMinutos < 0.1f)
                intervaloMinutos = 0.1f;

            return intervaloMinutos;
        }

        private static void AoCicloProgramado()
        {
            try
            {
                if (_motorNarrativo != null)
                    _motorNarrativo.ExecutarCicloProgramado();
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoCicloProgramado", ex, "falha no ciclo de persistência/configuração de contexto");
            }
        }

        private static void AoVerificarHotReloadConfiguracao()
        {
            try
            {
                AplicarHotReloadSeNecessario();
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoVerificarHotReloadConfiguracao", ex, "falha no hot reload da configuração");
            }
        }

        private static void AplicarHotReloadSeNecessario()
        {
            if (!ContextoMod.RecarregarConfiguracaoSeNecessario())
                return;

            _config = ContextoMod.Configuracao;

            if (_motorNarrativo != null)
                _motorNarrativo.AtualizarConfiguracao(_config);

            if (_controladorFilaEventosNarrativos != null)
                _controladorFilaEventosNarrativos.ReaplicarPoliticaDaFila();

            RegistrarCicloProgramado();
            RegistrarCicloHotReloadConfiguracao();
            RegistrarAlarmeDrenajeAcciones();
            SincronizarRecursosVisuais();

            if (_config != null && _config.LogarHotReload)
                NotificadorDoMod.Notificar("[NarradorPorEventos] Configuração recarregada.", StyledNotification.NotificationStyle.kGameMessagePositive);
        }

        private static void SincronizarRecursosVisuais()
        {
            // HARD DISABLE: desactivado por seguridad hasta confirmar estabilidad.
            // El flag config ya está en false, pero por las dudas cortamos acá.
            if (_controladorRecursosVisuaisNarrativos != null)
                _controladorRecursosVisuaisNarrativos.Desativar();
            _controladorRecursosVisuaisNarrativos = null;
            return;

            try
            {
                if (_controladorRecursosVisuaisNarrativos != null)
                    _controladorRecursosVisuaisNarrativos.Desativar();

                _controladorRecursosVisuaisNarrativos = new ControladorRecursosVisuaisNarrativos(_config);
                _controladorRecursosVisuaisNarrativos.Inicializar();
            }
            catch (Exception ex)
            {
                RegistrarExcecao("SincronizarRecursosVisuais", ex, "falha ao inicializar recursos visuais");

                if (_controladorRecursosVisuaisNarrativos != null)
                    _controladorRecursosVisuaisNarrativos.Desativar();

                _controladorRecursosVisuaisNarrativos = null;
            }
        }

        private static void AoRespostaNarrativaRecebida(RespostaNarrativa resposta)
        {
            try
            {
                if (_controladorRecursosVisuaisNarrativos != null)
                    _controladorRecursosVisuaisNarrativos.AtualizarRespostaNarrativa(resposta);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Callback de listener do TS3: filtra ruído e enfileira o evento para processamento assíncrono por alarme.
        /// </summary>
        /// <remarks>
        /// <para>Esse desenho reduz overload de listeners com catálogo grande, porque o callback evita trabalho pesado no momento do disparo do evento.</para>
        /// </remarks>
        private static ListenerAction AoEventoNarrativo(Event e)
        {
            try
            {
                if (EventoEhRuido(e))
                    return ListenerAction.Keep;

                if (_controladorFilaEventosNarrativos != null)
                    _controladorFilaEventosNarrativos.Enfileirar(e);
            }
            catch (Exception ex)
            {
                RegistrarExcecao("AoEventoNarrativo", ex, e != null ? e.Id.ToString() : "evento_nulo");
            }

            return ListenerAction.Keep;
        }

        private static void RegistrarExcecao(string origem, Exception ex, string contexto)
        {
            try
            {
                if (_adaptadorExcecoes != null)
                    _adaptadorExcecoes.RegistrarExcecao(origem, ex, contexto);
            }
            catch
            {
            }
        }

        private static Dictionary<string, bool> CriarMapaIdsEventosDisponiveis()
        {
            Dictionary<string, bool> mapa = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
            string[] nomes = Enum.GetNames(typeof(EventTypeId));
            foreach (string nome in nomes)
                mapa[nome] = true;

            return mapa;
        }
    }
}
