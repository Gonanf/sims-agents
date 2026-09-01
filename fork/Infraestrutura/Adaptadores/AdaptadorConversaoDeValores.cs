using System;
using System.Globalization;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public static class AdaptadorConversaoDeValores
    {
        public static string ParaTextoNaoVazio(object valor)
        {
            if (valor == null)
                return string.Empty;

            string texto = valor.ToString();
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            return texto;
        }

        public static bool TentarConverterParaBooleano(object valor, out bool convertido)
        {
            convertido = false;
            if (valor == null)
                return false;

            if (valor is bool)
            {
                convertido = (bool)valor;
                return true;
            }

            string texto = valor.ToString();
            if (string.Equals(texto, "1", StringComparison.OrdinalIgnoreCase))
            {
                convertido = true;
                return true;
            }

            if (string.Equals(texto, "0", StringComparison.OrdinalIgnoreCase))
            {
                convertido = false;
                return true;
            }

            return bool.TryParse(texto, out convertido);
        }

        public static bool TentarConverterParaFloat(object valor, out float convertido)
        {
            convertido = 0f;
            if (valor == null)
                return false;

            string texto = valor.ToString();
            if (float.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out convertido))
                return true;

            return float.TryParse(texto, out convertido);
        }

        public static bool TentarConverterParaInt(object valor, out int convertido)
        {
            convertido = 0;
            if (valor == null)
                return false;

            string texto = valor.ToString();
            if (int.TryParse(texto, out convertido))
                return true;

            float convertidoFloat;
            if (TentarConverterParaFloat(valor, out convertidoFloat))
            {
                convertido = (int)convertidoFloat;
                return true;
            }

            return false;
        }
    }
}
