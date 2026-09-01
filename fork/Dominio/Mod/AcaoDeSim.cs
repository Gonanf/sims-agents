using System;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod
{
    /// <summary>
    /// Modo de inserción de la interacción en la fila del Sim objetivo.
    /// continuation = PushAsContinuation (menos disruptivo, default para agentes autónomos).
    /// next = AddNext (prioridad alta, corta lo actual).
    /// </summary>
    public enum ModoExecucaoAcao
    {
        Continuation = 0,
        Next = 1
    }

    public enum PrioridadeAcao
    {
        Baixa = 0,
        Normal = 1,
        Alta = 2
    }

    public enum EstadoAcao
    {
        Pendente = 0,
        Aceita = 1,
        Rejeitada = 2,
        Executada = 3,
        Falhou = 4,
        Confirmada = 5
    }

    /// <summary>
    /// Acción tipada pedida por el LLM (cerebro externo) para un sim.
    /// Contrato JSON: acao:{ interacao, alvo, modo, prioridade } dentro de la respuesta narrativa.
    /// </summary>
    public sealed class AcaoDeSim
    {
        public string IdPedido { get; private set; }
        public string SimAtivo { get; private set; }
        public string Interacao { get; private set; }
        public string Alvo { get; private set; }
        public ModoExecucaoAcao Modo { get; private set; }
        public PrioridadeAcao Prioridade { get; private set; }
        public EstadoAcao Estado { get; set; }
        public string MotivoRejeicao { get; set; }

        private AcaoDeSim()
        {
        }

        public static AcaoDeSim Criar(string idPedido, string simAtivo, string interacao, string alvo,
            ModoExecucaoAcao modo, PrioridadeAcao prioridade)
        {
            return new AcaoDeSim
            {
                IdPedido = idPedido ?? string.Empty,
                SimAtivo = simAtivo ?? string.Empty,
                Interacao = interacao ?? string.Empty,
                Alvo = alvo ?? string.Empty,
                Modo = modo,
                Prioridade = prioridade,
                Estado = EstadoAcao.Pendente
            };
        }

        public bool EhValida()
        {
            return !string.IsNullOrEmpty(IdPedido)
                && !string.IsNullOrEmpty(SimAtivo)
                && !string.IsNullOrEmpty(Interacao);
        }
    }
}
