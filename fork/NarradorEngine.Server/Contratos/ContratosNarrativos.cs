using System.Text.Json.Serialization;

namespace NarradorEngine.Server.Contratos;

public sealed class EnvelopePedidosJsonContrato
{
    [JsonPropertyName("versao_contrato")]
    public string VersaoContrato { get; set; } = "1.0";

    [JsonPropertyName("pedidos")]
    public List<PedidoNarrativoJsonContrato> Pedidos { get; set; } = new();
}

public sealed class EnvelopeRespostasJsonContrato
{
    [JsonPropertyName("versao_contrato")]
    public string VersaoContrato { get; set; } = "1.0";

    [JsonPropertyName("respostas")]
    public List<RespostaNarrativaJsonContrato> Respostas { get; set; } = new();
}

public sealed class PedidoNarrativoJsonContrato
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("sim_ativo")]
    public string SimAtivo { get; set; } = string.Empty;

    [JsonPropertyName("horario_real")]
    public string HorarioReal { get; set; } = string.Empty;

    [JsonPropertyName("contexto")]
    public string Contexto { get; set; } = string.Empty;
}

public sealed class RespostaNarrativaJsonContrato
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("sim_ativo")]
    public string SimAtivo { get; set; } = string.Empty;

    [JsonPropertyName("horario_real")]
    public string HorarioReal { get; set; } = string.Empty;

    [JsonPropertyName("prompt")]
    public string Prompt { get; set; } = string.Empty;

    [JsonPropertyName("resposta")]
    public string Resposta { get; set; } = string.Empty;
}
