using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public sealed class EventoNarrativoJsonContrato
    {
        public string HorarioJogo { get; set; }
        public string Tipo { get; set; }
        public string Ator { get; set; }
        public string Alvo { get; set; }
        public string Descricao { get; set; }
    }

    public sealed class EstadoNarrativoJsonContrato
    {
        public string VersaoContrato { get; set; }
        public string Escopo { get; set; }
        public string Referencia { get; set; }
        public string Cabecalho { get; set; }
        public Dictionary<string, string> CabecalhoItens { get; set; }
        public string AtualizadoEmUtc { get; set; }
        public List<EventoNarrativoJsonContrato> Eventos { get; set; }
    }

    public sealed class PedidoNarrativoJsonContrato
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string SimAtivo { get; set; }
        public string HorarioReal { get; set; }
        public string Contexto { get; set; }
    }

    public sealed class RespostaNarrativaJsonContrato
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string SimAtivo { get; set; }
        public string HorarioReal { get; set; }
        public string Prompt { get; set; }
        public string Resposta { get; set; }

        /// <summary>
        /// Fork sims-agents: campo opcional acao:{interacao, alvo, modo, prioridade}.
        /// Crudo (dict) para que AdaptadorAcaoResposta lo tipifique después.
        /// </summary>
        public Dictionary<string, object> AcaoBruta { get; set; }
    }

    public sealed class RegistroLogNarrativoJsonContrato
    {
        public string HorarioReal { get; set; }
        public string Categoria { get; set; }
        public string Detalhe { get; set; }
    }

    public sealed class ContextoNarrativoPrevioJsonContrato
    {
        public string VersaoContrato { get; set; }
        public string AtualizadoEmUtc { get; set; }
        public string PensamentoAnterior { get; set; }
        public string ContoAnterior { get; set; }
    }
}