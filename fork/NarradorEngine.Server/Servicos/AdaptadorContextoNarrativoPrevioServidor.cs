using System.Text.Json;

namespace NarradorEngine.Server.Servicos;

/// <summary>
/// Representa o pequeno recorte de narrativa anterior que o servidor pode anexar ao prompt atual.
/// </summary>
internal sealed class ContextoNarrativoPrevioServidor
{
    public string PensamentoAnterior { get; set; } = string.Empty;
    public string ContoAnterior { get; set; } = string.Empty;
}

/// <summary>
/// Lê o arquivo de contexto narrativo prévio de forma tolerante a ausência ou JSON inválido.
/// </summary>
/// <remarks>
/// <para>Quando o arquivo não existe ou falha no parse, o servidor recebe um contexto vazio e segue o processamento sem derrubar o ciclo.</para>
/// </remarks>
internal static class AdaptadorContextoNarrativoPrevioServidor
{
    /// <summary>
    /// Carrega o contexto prévio disponível para pensamento e conto.
    /// </summary>
    public static ContextoNarrativoPrevioServidor Ler(string caminho)
    {
        if (string.IsNullOrWhiteSpace(caminho) || !File.Exists(caminho))
        {
            return new ContextoNarrativoPrevioServidor();
        }

        try
        {
            var conteudo = File.ReadAllText(caminho);
            if (string.IsNullOrWhiteSpace(conteudo))
            {
                return new ContextoNarrativoPrevioServidor();
            }

            using var documento = JsonDocument.Parse(conteudo);
            var raiz = documento.RootElement;
            return new ContextoNarrativoPrevioServidor
            {
                PensamentoAnterior = LerTexto(raiz, "pensamento_anterior"),
                ContoAnterior = LerTexto(raiz, "conto_anterior")
            };
        }
        catch
        {
            return new ContextoNarrativoPrevioServidor();
        }
    }

    private static string LerTexto(JsonElement raiz, string chave)
    {
        if (!raiz.TryGetProperty(chave, out var valor))
        {
            return string.Empty;
        }

        return valor.ValueKind == JsonValueKind.String
            ? valor.GetString() ?? string.Empty
            : valor.ToString();
    }
}