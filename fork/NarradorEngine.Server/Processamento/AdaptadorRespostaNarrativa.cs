using NarradorEngine.Server.Servicos;

namespace NarradorEngine.Server.Processamento;

/// <summary>
/// Normaliza a resposta textual retornada pelo modelo antes de gravar no envelope final.
/// </summary>
/// <remarks>
/// <para>Esta etapa remove ruído comum de serializacao sem introduzir uma rodada extra de reescrita.</para>
/// </remarks>
internal static class AdaptadorRespostaNarrativa
{
    /// <summary>
    /// Compacta a resposta para uma unica linha e remove artefatos simples de aspas e borda.
    /// </summary>
    public static string Sanitizar(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return string.Empty;
        }

        var saida = AdaptadorTextoServidor.CompactarParaLinhaUnica(texto, removerAspasExternas: true);
        saida = saida.Replace("_\"", string.Empty, StringComparison.Ordinal)
            .Replace("\"_", string.Empty, StringComparison.Ordinal);
        return saida;
    }
}