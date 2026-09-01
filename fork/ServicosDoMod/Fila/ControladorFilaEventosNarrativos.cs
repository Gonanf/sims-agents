using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Controla a fila única de eventos narrativos: enfileira no callback de listener e processa em lotes por alarme.
    /// </summary>
    /// <remarks>
    /// <para>Integração com o arquivo de entrada:</para>
    /// <list type="bullet">
    /// <item><description><c>GerenciadorPrincipalModNarracaoPorEventos.AoEventoNarrativo</c> chama <c>Enfileirar</c>.</description></item>
    /// <item><description><c>GerenciadorPrincipalModNarracaoPorEventos.IniciarConsumidorDaFilaNarrativa</c> chama <c>IniciarProcessamento</c>.</description></item>
    /// </list>
    /// <para>Não existe segunda fila: existe um único buffer em memória consumido periodicamente para limitar carga por ciclo.</para>
    /// <para>O ritmo de drenagem e o corte de recorrência ficam centralizados em <c>PoliticaFilaEventosNarrativos</c>.</para>
    /// </remarks>
    internal sealed class ControladorFilaEventosNarrativos
    {
        private readonly MotorNarrativo _motorNarrativo;
        private readonly IAdaptadorExcecoesMod _adaptadorExcecoes;
        private PoliticaFilaEventosNarrativos _politicaFilaEventos;
        private readonly Queue<Event> _filaEventosNarrativos;
        private readonly object _travaFilaEventosNarrativos;

        /// <summary>
        /// Handle do alarme periódico que drena a fila em lotes.
        /// </summary>
        private AlarmHandle _processamentoFilaEventosHandle;

        public ControladorFilaEventosNarrativos(
            MotorNarrativo motorNarrativo,
            IAdaptadorExcecoesMod adaptadorExcecoes)
        {
            _motorNarrativo = motorNarrativo;
            _adaptadorExcecoes = adaptadorExcecoes;
            _filaEventosNarrativos = new Queue<Event>();
            _travaFilaEventosNarrativos = new object();
            _processamentoFilaEventosHandle = AlarmHandle.kInvalidHandle;
            ReaplicarPoliticaDaFila();
        }

        public void ReaplicarPoliticaDaFila()
        {
            lock (_travaFilaEventosNarrativos)
            {
                _politicaFilaEventos = new PoliticaFilaEventosNarrativos();
            }

            if (_processamentoFilaEventosHandle != AlarmHandle.kInvalidHandle)
                IniciarProcessamento();
        }

        /// <summary>
        /// Inicia (ou reinicia) o alarme consumidor da fila.
        /// </summary>
        public void IniciarProcessamento()
        {
            if (_processamentoFilaEventosHandle != AlarmHandle.kInvalidHandle)
                AlarmManager.Global.RemoveAlarm(_processamentoFilaEventosHandle);

            if (_politicaFilaEventos == null)
                _politicaFilaEventos = new PoliticaFilaEventosNarrativos();

            _processamentoFilaEventosHandle = AlarmManager.Global.AddAlarmRepeating(
                _politicaFilaEventos.IntervaloProcessamentoMinutos,
                TimeUnit.Minutes,
                ProcessarFilaDeEventosNarrativos,
                _politicaFilaEventos.IntervaloProcessamentoMinutos,
                TimeUnit.Minutes,
                "NarradorPorEventos.ProcessadorFilaEventos",
                AlarmType.AlwaysPersisted,
                null);
        }

        /// <summary>
        /// Adiciona um evento à fila para processamento posterior.
        /// </summary>
        public void Enfileirar(Event evento)
        {
            if (evento == null)
                return;

            lock (_travaFilaEventosNarrativos)
            {
                if (_politicaFilaEventos == null)
                    _politicaFilaEventos = new PoliticaFilaEventosNarrativos();

                if (!_politicaFilaEventos.DeveEnfileirar(evento))
                    return;

                _filaEventosNarrativos.Enqueue(evento);
            }
        }

        private void ProcessarFilaDeEventosNarrativos()
        {
            if (_motorNarrativo == null || _politicaFilaEventos == null)
                return;

            int eventosProcessados = 0;
            while (eventosProcessados < _politicaFilaEventos.MaxEventosPorCiclo)
            {
                Event evento = DesenfileirarEventoNarrativo();
                if (evento == null)
                    return;

                try
                {
                    _motorNarrativo.RegistrarEvento(evento);
                    eventosProcessados++;
                }
                catch (Exception ex)
                {
                    RegistrarExcecao("ProcessarFilaDeEventosNarrativos", ex, evento.Id.ToString());
                    eventosProcessados++;
                }
            }
        }

        private Event DesenfileirarEventoNarrativo()
        {
            lock (_travaFilaEventosNarrativos)
            {
                if (_filaEventosNarrativos.Count == 0)
                    return null;

                return _filaEventosNarrativos.Dequeue();
            }
        }

        private void RegistrarExcecao(string origem, Exception ex, string contexto)
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
    }
}
