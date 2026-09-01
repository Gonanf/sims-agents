using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public static class AdaptadorColecoesPorReflexaoUtil
    {
        private const BindingFlags FlagsMetodoEstatico =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        public static object LerMembroOuCampo(object origem, string nome)
        {
            if (origem == null || string.IsNullOrEmpty(nome))
                return null;

            object valor = LeitorPorReflexaoUtil.LerPropriedade(origem, nome);
            if (valor != null)
                return valor;

            FieldInfo campo = origem.GetType().GetField(nome,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (campo == null)
                return null;

            try
            {
                return campo.GetValue(origem);
            }
            catch
            {
                return null;
            }
        }

        public static List<T> ExtrairListaTipada<T>(object colecaoObj) where T : class
        {
            List<object> valores = ExtrairValoresDeColecao(colecaoObj);
            List<T> resultado = new List<T>();
            foreach (object valor in valores)
            {
                T item = valor as T;
                if (item != null)
                    resultado.Add(item);
            }

            return resultado;
        }

        public static List<object> ExtrairValoresDeColecao(object colecaoObj)
        {
            List<object> resultado = new List<object>();
            if (colecaoObj == null)
                return resultado;

            IDictionary dicionario = colecaoObj as IDictionary;
            if (dicionario != null)
            {
                foreach (DictionaryEntry par in dicionario)
                    if (par.Value != null)
                        resultado.Add(par.Value);

                return resultado;
            }

            IEnumerable lista = colecaoObj as IEnumerable;
            if (lista == null)
                return resultado;

            foreach (object item in lista)
            {
                if (item == null)
                    continue;

                DictionaryEntry? entrada = TentarExtrairEntradaDeDicionario(item);
                if (entrada.HasValue)
                {
                    if (entrada.Value.Value != null)
                        resultado.Add(entrada.Value.Value);
                    continue;
                }

                resultado.Add(item);
            }

            return resultado;
        }

        public static DictionaryEntry? TentarExtrairEntradaDeDicionario(object item)
        {
            if (item is DictionaryEntry)
                return (DictionaryEntry)item;

            object chave = LeitorPorReflexaoUtil.LerPropriedade(item, "Key");
            object valor = LeitorPorReflexaoUtil.LerPropriedade(item, "Value");
            if (chave != null)
                return new DictionaryEntry(chave, valor);

            return null;
        }

        public static object InvocarMetodoEstaticoSemParametros(string tipoCompleto, string nomeMetodo)
        {
            if (string.IsNullOrEmpty(tipoCompleto) || string.IsNullOrEmpty(nomeMetodo))
                return null;

            Type tipo = Type.GetType(tipoCompleto);
            if (tipo == null)
                return null;

            MethodInfo metodo = tipo.GetMethod(
                nomeMetodo,
                FlagsMetodoEstatico,
                null,
                Type.EmptyTypes,
                null);

            if (metodo == null)
                return null;

            try
            {
                return metodo.Invoke(null, null);
            }
            catch
            {
                return null;
            }
        }

        public static string LerPrimeiroTextoDePropriedadesEstaticas(string[] tiposCompletos, string[] nomesPropriedade)
        {
            if (tiposCompletos == null || nomesPropriedade == null)
                return string.Empty;

            foreach (string tipoCompleto in tiposCompletos)
            {
                Type tipo = Type.GetType(tipoCompleto);
                if (tipo == null)
                    continue;

                foreach (string nomePropriedade in nomesPropriedade)
                {
                    object valor = LeitorPorReflexaoUtil.LerPropriedade(tipo, nomePropriedade);
                    if (valor == null)
                        continue;

                    string texto = valor.ToString();
                    if (!string.IsNullOrEmpty(texto))
                        return texto;
                }
            }

            return string.Empty;
        }

        public static bool? LerPrimeiroBooleanoDePropriedadesEstaticas(string[] tiposCompletos, string[] nomesPropriedade)
        {
            if (tiposCompletos == null || nomesPropriedade == null)
                return null;

            foreach (string tipoCompleto in tiposCompletos)
            {
                Type tipo = Type.GetType(tipoCompleto);
                if (tipo == null)
                    continue;

                foreach (string nomePropriedade in nomesPropriedade)
                {
                    object valor = LeitorPorReflexaoUtil.LerPropriedade(tipo, nomePropriedade);
                    if (valor is bool)
                        return (bool)valor;
                }
            }

            return null;
        }

        public static string ListarItensEmTexto(IEnumerable itens, params string[] nomesPropriedade)
        {
            if (itens == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (object item in itens)
            {
                if (item == null)
                    continue;

                string nome = LeitorPorReflexaoUtil.LerTexto(item, nomesPropriedade);
                if (string.IsNullOrEmpty(nome))
                    continue;

                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(nome);
            }

            return sb.ToString();
        }
    }
}
