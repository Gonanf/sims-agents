using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    public static class ConsultaConfiguracaoDoMod
    {
        public static bool LerBool(Dictionary<string, string> valores, string chave, bool padrao)
        {
            if (AdaptadorTextoNarrativo.DicionarioNuloOuChaveVazia(valores, chave))
                return padrao;

            string bruto;
            if (!AdaptadorTextoNarrativo.TentarObterValor(valores, chave, out bruto))
                return padrao;
            bool convertido;
            if (AdaptadorConversaoDeValores.TentarConverterParaBooleano(bruto, out convertido))
                return convertido;

            return padrao;
        }

        public static int LerInt(Dictionary<string, string> valores, string chave, int padrao)
        {
            if (AdaptadorTextoNarrativo.DicionarioNuloOuChaveVazia(valores, chave))
                return padrao;

            string bruto;
            if (!AdaptadorTextoNarrativo.TentarObterValor(valores, chave, out bruto))
                return padrao;

            int convertido;
            if (AdaptadorConversaoDeValores.TentarConverterParaInt(bruto, out convertido))
                return convertido;

            return padrao;
        }

        public static float LerFloat(Dictionary<string, string> valores, string chave, float padrao)
        {
            if (AdaptadorTextoNarrativo.DicionarioNuloOuChaveVazia(valores, chave))
                return padrao;

            string bruto;
            if (!AdaptadorTextoNarrativo.TentarObterValor(valores, chave, out bruto))
                return padrao;

            float convertido;
            if (AdaptadorConversaoDeValores.TentarConverterParaFloat(bruto, out convertido))
                return convertido;

            return padrao;
        }

        public static string LerTexto(Dictionary<string, string> valores, string chave, string padrao)
        {
            if (AdaptadorTextoNarrativo.DicionarioNuloOuChaveVazia(valores, chave))
                return padrao;

            string bruto;
            if (!AdaptadorTextoNarrativo.TentarObterValor(valores, chave, out bruto))
                return padrao;
            if (AdaptadorTextoNarrativo.TextoVazio(bruto))
                return padrao;

            return bruto;
        }
    }
}
