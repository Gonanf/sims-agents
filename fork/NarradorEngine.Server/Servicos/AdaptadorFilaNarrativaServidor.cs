using NarradorEngine.Server.Contratos;
using System.Text.Json;

namespace NarradorEngine.Server.Servicos;

/// <summary>
/// Centraliza a leitura e escrita dos envelopes JSON de pedidos e respostas do servidor.
/// </summary>
/// <remarks>
/// <para>Esta classe encapsula o contrato fisico dos arquivos para que o restante do pipeline trabalhe apenas com DTOs.</para>
/// </remarks>
internal static class AdaptadorFilaNarrativaServidor
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    /// <summary>
    /// Lê o envelope de pedidos do disco ou retorna um envelope vazio quando o arquivo ainda não existe.
    /// </summary>
    public static EnvelopePedidosJsonContrato LerPedidos(string caminho)
    {
        return LerEnvelope<EnvelopePedidosJsonContrato>(caminho);
    }

    /// <summary>
    /// Lê o envelope de respostas do disco ou retorna um envelope vazio quando o arquivo ainda não existe.
    /// </summary>
    public static EnvelopeRespostasJsonContrato LerRespostas(string caminho)
    {
        return LerEnvelope<EnvelopeRespostasJsonContrato>(caminho);
    }

    /// <summary>
    /// Persiste o envelope de respostas formatado em JSON identado.
    /// </summary>
    public static void SalvarRespostas(string caminho, EnvelopeRespostasJsonContrato envelope)
    {
        SalvarEnvelope(caminho, envelope);
    }

    /// <summary>
    /// Substitui o arquivo de pedidos por um envelope vazio, evitando reprocessamento no ciclo seguinte.
    /// </summary>
    public static void PurgarPedidos(string caminho)
    {
        SalvarEnvelope(caminho, new EnvelopePedidosJsonContrato());
    }

    private static T LerEnvelope<T>(string caminho)
        where T : new()
    {
        if (!File.Exists(caminho))
        {
            return new T();
        }

        var conteudo = File.ReadAllText(caminho);
        if (string.IsNullOrWhiteSpace(conteudo))
        {
            return new T();
        }

        return JsonSerializer.Deserialize<T>(conteudo, JsonOptions) ?? new T();
    }

    private static void SalvarEnvelope<T>(string caminho, T envelope)
    {
        var diretorio = Path.GetDirectoryName(caminho);
        if (!string.IsNullOrWhiteSpace(diretorio))
        {
            Directory.CreateDirectory(diretorio);
        }

        File.WriteAllText(caminho, JsonSerializer.Serialize(envelope, JsonOptions));
    }
}