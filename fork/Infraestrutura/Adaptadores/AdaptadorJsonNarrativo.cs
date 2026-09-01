using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    internal static class AdaptadorJsonNarrativo
    {
        internal const string VersaoContratoAtual = "1.0";

        public static bool TentarLerObjetoJson(string json, out Dictionary<string, object> objeto)
        {
            objeto = null;
            if (string.IsNullOrEmpty(json))
                return false;

            try
            {
                LeitorJsonSimples leitor = new LeitorJsonSimples(json);
                object valor = leitor.LerValor();
                objeto = valor as Dictionary<string, object>;
                return objeto != null;
            }
            catch
            {
                objeto = null;
                return false;
            }
        }

        public static string LerTexto(Dictionary<string, object> objeto, string chave)
        {
            if (objeto == null || string.IsNullOrEmpty(chave))
                return string.Empty;

            object bruto;
            if (!objeto.TryGetValue(chave, out bruto) || bruto == null)
                return string.Empty;

            if (bruto is string)
                return (string)bruto;

            if (bruto is bool)
                return ((bool)bruto) ? "true" : "false";

            if (bruto is IFormattable)
                return ((IFormattable)bruto).ToString(null, CultureInfo.InvariantCulture);

            return bruto.ToString();
        }

        public static string Escapar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            return texto
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
        }

        public static string GerarHorarioUtc()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }

        private sealed class LeitorJsonSimples
        {
            private readonly string _texto;
            private int _indice;

            public LeitorJsonSimples(string texto)
            {
                _texto = texto ?? string.Empty;
                _indice = 0;
            }

            public object LerValor()
            {
                IgnorarEspacos();
                if (_indice >= _texto.Length)
                    throw new InvalidOperationException("json vazio");

                char atual = _texto[_indice];
                if (atual == '{')
                    return LerObjeto();
                if (atual == '[')
                    return LerArray();
                if (atual == '"')
                    return LerTexto();
                if (atual == 't' || atual == 'f')
                    return LerBooleano();
                if (atual == 'n')
                    return LerNulo();

                return LerNumero();
            }

            private Dictionary<string, object> LerObjeto()
            {
                Dictionary<string, object> resultado = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                Consumir('{');
                IgnorarEspacos();

                if (TentarConsumir('}'))
                    return resultado;

                while (true)
                {
                    string chave = LerTexto();
                    IgnorarEspacos();
                    Consumir(':');
                    object valor = LerValor();
                    resultado[chave] = valor;
                    IgnorarEspacos();

                    if (TentarConsumir('}'))
                        break;

                    Consumir(',');
                }

                return resultado;
            }

            private List<object> LerArray()
            {
                List<object> resultado = new List<object>();
                Consumir('[');
                IgnorarEspacos();
                if (TentarConsumir(']'))
                    return resultado;

                while (true)
                {
                    resultado.Add(LerValor());
                    IgnorarEspacos();
                    if (TentarConsumir(']'))
                        break;

                    Consumir(',');
                }

                return resultado;
            }

            private string LerTexto()
            {
                Consumir('"');
                StringBuilder sb = new StringBuilder();

                while (_indice < _texto.Length)
                {
                    char atual = _texto[_indice++];
                    if (atual == '"')
                        return sb.ToString();

                    if (atual != '\\')
                    {
                        sb.Append(atual);
                        continue;
                    }

                    if (_indice >= _texto.Length)
                        throw new InvalidOperationException("escape inválido");

                    char escape = _texto[_indice++];
                    switch (escape)
                    {
                        case '"': sb.Append('"'); break;
                        case '\\': sb.Append('\\'); break;
                        case '/': sb.Append('/'); break;
                        case 'b': sb.Append('\b'); break;
                        case 'f': sb.Append('\f'); break;
                        case 'n': sb.Append('\n'); break;
                        case 'r': sb.Append('\r'); break;
                        case 't': sb.Append('\t'); break;
                        case 'u':
                            sb.Append(LerUnicode());
                            break;
                        default:
                            throw new InvalidOperationException("escape inválido");
                    }
                }

                throw new InvalidOperationException("texto inválido");
            }

            private char LerUnicode()
            {
                if (_indice + 4 > _texto.Length)
                    throw new InvalidOperationException("unicode inválido");

                string hex = _texto.Substring(_indice, 4);
                _indice += 4;
                int codigo = int.Parse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                return (char)codigo;
            }

            private object LerBooleano()
            {
                if (ComecaCom("true"))
                {
                    _indice += 4;
                    return true;
                }

                if (ComecaCom("false"))
                {
                    _indice += 5;
                    return false;
                }

                throw new InvalidOperationException("booleano inválido");
            }

            private object LerNulo()
            {
                if (!ComecaCom("null"))
                    throw new InvalidOperationException("nulo inválido");

                _indice += 4;
                return null;
            }

            private object LerNumero()
            {
                int inicio = _indice;
                if (_texto[_indice] == '-')
                    _indice++;

                while (_indice < _texto.Length && char.IsDigit(_texto[_indice]))
                    _indice++;

                if (_indice < _texto.Length && _texto[_indice] == '.')
                {
                    _indice++;
                    while (_indice < _texto.Length && char.IsDigit(_texto[_indice]))
                        _indice++;
                }

                if (_indice < _texto.Length && (_texto[_indice] == 'e' || _texto[_indice] == 'E'))
                {
                    _indice++;
                    if (_indice < _texto.Length && (_texto[_indice] == '+' || _texto[_indice] == '-'))
                        _indice++;

                    while (_indice < _texto.Length && char.IsDigit(_texto[_indice]))
                        _indice++;
                }

                string numero = _texto.Substring(inicio, _indice - inicio);
                double valor;
                if (!double.TryParse(numero, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
                    throw new InvalidOperationException("número inválido");

                return valor;
            }

            private void Consumir(char esperado)
            {
                IgnorarEspacos();
                if (_indice >= _texto.Length || _texto[_indice] != esperado)
                    throw new InvalidOperationException("json inválido");

                _indice++;
            }

            private bool TentarConsumir(char esperado)
            {
                IgnorarEspacos();
                if (_indice >= _texto.Length || _texto[_indice] != esperado)
                    return false;

                _indice++;
                return true;
            }

            private bool ComecaCom(string valor)
            {
                if (_indice + valor.Length > _texto.Length)
                    return false;

                int deslocamento = 0;
                foreach (char caractereEsperado in valor)
                {
                    if (_texto[_indice + deslocamento] != caractereEsperado)
                        return false;

                    deslocamento++;
                }

                return true;
            }

            private void IgnorarEspacos()
            {
                while (_indice < _texto.Length)
                {
                    char atual = _texto[_indice];
                    if (!char.IsWhiteSpace(atual))
                        return;

                    _indice++;
                }
            }
        }
    }
}