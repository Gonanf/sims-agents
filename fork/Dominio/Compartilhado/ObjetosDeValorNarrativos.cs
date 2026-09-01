using System;

namespace NarradorPorEventos.Dominio
{
    /// <summary>
    /// Catálogo mínimo dos tipos narrativos aceitos pelo fluxo compartilhado entre mod e servidor.
    /// </summary>
    public static class TipoNarrativa
    {
        public const string Pensamento = "pensamento";
        public const string Conto = "conto";

        public static bool Corresponde(string tipoAtual, string tipoEsperado)
        {
            return !string.IsNullOrEmpty(tipoAtual)
                && !string.IsNullOrEmpty(tipoEsperado)
                && tipoAtual.IndexOf(tipoEsperado, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool EhConhecido(string tipoAtual)
        {
            return Corresponde(tipoAtual, Pensamento) || Corresponde(tipoAtual, Conto);
        }

        public static string ResolverChaveContextoPrevio(string tipoAtual)
        {
            if (Corresponde(tipoAtual, Pensamento))
                return "pensamento_anterior";

            if (Corresponde(tipoAtual, Conto))
                return "conto_anterior";

            return string.Empty;
        }
    }

    /// <summary>
    /// Objeto de valor para textos narrativos simples.
    /// </summary>
    public sealed class TextoNarrativo
    {
        private readonly string _valor;

        private TextoNarrativo(string valor)
        {
            _valor = valor ?? string.Empty;
        }

        public string Valor
        {
            get { return _valor; }
        }

        public bool EstaVazio
        {
            get { return string.IsNullOrEmpty(_valor); }
        }

        public bool EstaPreenchido
        {
            get { return !EstaVazio; }
        }

        public static TextoNarrativo Criar(string valor)
        {
            return new TextoNarrativo((valor ?? string.Empty).Trim());
        }

        public static TextoNarrativo CriarCompactado(string valor)
        {
            return new TextoNarrativo(Compactar(valor));
        }

        public bool ContemIgnorandoMaiusculas(string trecho)
        {
            return !string.IsNullOrEmpty(trecho)
                && _valor.IndexOf(trecho, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public override string ToString()
        {
            return _valor;
        }

        private static string Compactar(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            string texto = valor
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Replace("\t", " ")
                .Trim();

            while (texto.IndexOf("  ", StringComparison.Ordinal) >= 0)
                texto = texto.Replace("  ", " ");

            return texto;
        }
    }

    /// <summary>
    /// Objeto de valor para caminhos de arquivos narrativos.
    /// </summary>
    public sealed class CaminhoArquivoNarrativo
    {
        private readonly string _valor;

        private CaminhoArquivoNarrativo(string valor)
        {
            _valor = valor ?? string.Empty;
        }

        public string Valor
        {
            get { return _valor; }
        }

        public bool EstaDefinido
        {
            get { return !string.IsNullOrEmpty(_valor); }
        }

        public static CaminhoArquivoNarrativo Criar(string valor)
        {
            return new CaminhoArquivoNarrativo((valor ?? string.Empty).Trim());
        }

        public override string ToString()
        {
            return _valor;
        }
    }

    /// <summary>
    /// Objeto de valor para templates narrativos configuráveis.
    /// </summary>
    public sealed class TemplateNarrativo
    {
        private readonly string _conteudo;

        private TemplateNarrativo(string conteudo)
        {
            _conteudo = conteudo ?? string.Empty;
        }

        public string Conteudo
        {
            get { return _conteudo; }
        }

        public bool EstaDefinido
        {
            get { return !string.IsNullOrEmpty(_conteudo); }
        }

        public static TemplateNarrativo Criar(string conteudo)
        {
            return new TemplateNarrativo(conteudo);
        }

        public override string ToString()
        {
            return _conteudo;
        }
    }
}