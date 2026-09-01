using System.Globalization;
using System.Text;

namespace NarradorEngine.Server.Servicos;

internal static class AdaptadorTextoServidor
{
    public static string ApararOuVazio(string texto)
    {
        return string.IsNullOrWhiteSpace(texto) ? string.Empty : texto.Trim();
    }

    public static string CompactarParaLinhaUnica(string texto, bool removerAspasExternas = false)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return string.Empty;
        }

        var saida = texto
            .Replace("\r", " ")
            .Replace("\n", " ")
            .Replace("\t", " ")
            .Trim();

        if (removerAspasExternas)
        {
            saida = saida.Trim('"');
        }

        while (saida.Contains("  ", StringComparison.Ordinal))
        {
            saida = saida.Replace("  ", " ", StringComparison.Ordinal);
        }

        return saida;
    }

    public static string NormalizarIdentificador(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            return string.Empty;
        }

        var semDiacriticos = RemoverDiacriticos(valor);
        return semDiacriticos
            .Replace("_", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("-", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Trim();
    }

    private static string RemoverDiacriticos(string texto)
    {
        var normalizado = texto.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder(normalizado.Length);

        foreach (var caractere in normalizado)
        {
            var categoria = CharUnicodeInfo.GetUnicodeCategory(caractere);
            if (categoria != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(caractere);
            }
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}
