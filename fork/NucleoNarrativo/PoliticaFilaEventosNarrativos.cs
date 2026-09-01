using Sims3.Gameplay.EventSystem;
using System;
using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Política interna da fila narrativa.
    /// </summary>
    /// <remarks>
    /// <para>Centraliza em um único ponto o ritmo de drenagem da fila e o corte de recorrência.</para>
    /// <para>Esses limites deixam de ser expostos no JSON para reduzir a validação de knobs de baixo nível.</para>
    /// </remarks>
    internal sealed class PoliticaFilaEventosNarrativos
    {
        private const float IntervaloProcessamentoMinutosPadrao = 5f;
        private const int MaxEventosPorCicloPadrao = 25;
        private const int JanelaEventosAceitosPadrao = 50;
        private const int OcorrenciasParaCortePadrao = 3;

        private readonly Queue<string> _ultimosTiposAceitos;
        private readonly Dictionary<string, int> _frequenciasPorTipo;

        public PoliticaFilaEventosNarrativos()
        {
            _ultimosTiposAceitos = new Queue<string>(JanelaEventosAceitosPadrao);
            _frequenciasPorTipo = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }

        public float IntervaloProcessamentoMinutos
        {
            get { return IntervaloProcessamentoMinutosPadrao; }
        }

        public int MaxEventosPorCiclo
        {
            get { return MaxEventosPorCicloPadrao; }
        }

        public bool DeveEnfileirar(Event evento)
        {
            string tipoEvento = NormalizarTipo(evento);
            if (tipoEvento.Length == 0)
                return false;

            if (ObterFrequenciaAtual(tipoEvento) >= OcorrenciasParaCortePadrao)
                return false;

            RegistrarEventoAceito(tipoEvento);
            return true;
        }

        private void RegistrarEventoAceito(string tipoEvento)
        {
            _ultimosTiposAceitos.Enqueue(tipoEvento);
            IncrementarFrequencia(tipoEvento);
            RemoverEventoMaisAntigoSeNecessario();
        }

        private void RemoverEventoMaisAntigoSeNecessario()
        {
            if (_ultimosTiposAceitos.Count <= JanelaEventosAceitosPadrao)
                return;

            string tipoMaisAntigo = _ultimosTiposAceitos.Dequeue();
            DecrementarFrequencia(tipoMaisAntigo);
        }

        private void IncrementarFrequencia(string tipoEvento)
        {
            int frequenciaAtual;
            if (_frequenciasPorTipo.TryGetValue(tipoEvento, out frequenciaAtual))
            {
                _frequenciasPorTipo[tipoEvento] = frequenciaAtual + 1;
                return;
            }

            _frequenciasPorTipo[tipoEvento] = 1;
        }

        private void DecrementarFrequencia(string tipoEvento)
        {
            int frequenciaAtual;
            if (!_frequenciasPorTipo.TryGetValue(tipoEvento, out frequenciaAtual))
                return;

            if (frequenciaAtual <= 1)
            {
                _frequenciasPorTipo.Remove(tipoEvento);
                return;
            }

            _frequenciasPorTipo[tipoEvento] = frequenciaAtual - 1;
        }

        private int ObterFrequenciaAtual(string tipoEvento)
        {
            int frequenciaAtual;
            return _frequenciasPorTipo.TryGetValue(tipoEvento, out frequenciaAtual) ? frequenciaAtual : 0;
        }

        private static string NormalizarTipo(Event evento)
        {
            if (evento == null)
                return string.Empty;

            string tipoEvento = evento.Id.ToString();
            return string.IsNullOrEmpty(tipoEvento) ? string.Empty : tipoEvento.Trim();
        }
    }
}