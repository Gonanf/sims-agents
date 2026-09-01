using System;
using System.Reflection;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public static class LeitorPorReflexaoUtil
    {
        private const BindingFlags FlagsInstancia =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        private const BindingFlags FlagsEstatica =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        public static object LerPropriedade(object origem, string nome)
        {
            if (origem == null)
                return null;

            PropertyInfo prop = origem.GetType().GetProperty(nome, FlagsInstancia);
            if (prop == null)
                return null;

            try
            {
                return prop.GetValue(origem, null);
            }
            catch
            {
                return null;
            }
        }

        public static object LerPropriedade(Type tipo, string nome)
        {
            if (tipo == null)
                return null;

            PropertyInfo prop = tipo.GetProperty(nome, FlagsEstatica);
            if (prop == null)
                return null;

            try
            {
                return prop.GetValue(null, null);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lee un miembro estático por nombre: prueba property y luego field.
        /// (InteractionDefinition.Singleton es un FIELD estático, no una property.)
        /// </summary>
        public static object LerEstatico(Type tipo, string nome)
        {
            if (tipo == null)
                return null;

            PropertyInfo prop = tipo.GetProperty(nome, FlagsEstatica);
            if (prop != null)
            {
                try { return prop.GetValue(null, null); }
                catch { }
            }

            FieldInfo campo = tipo.GetField(nome, FlagsEstatica);
            if (campo != null)
            {
                try { return campo.GetValue(null); }
                catch { }
            }

            return null;
        }

        public static string LerTexto(object origem, params string[] candidatos)
        {
            foreach (string candidato in candidatos)
            {
                object valor = LerPropriedade(origem, candidato);
                string texto = AdaptadorConversaoDeValores.ParaTextoNaoVazio(valor);
                if (!string.IsNullOrEmpty(texto))
                    return texto;
            }

            return string.Empty;
        }

        /// <summary>
        /// Nuevo en el fork sims-agents: invoca un método (público o privado, instancia o estático)
        /// por reflexión. Devuelve null si el método no existe o falla.
        /// Si hay sobrecargas, elige la que matchee los tipos de los argumentos
        /// (GetMethod(nombre) lanza AmbiguousMatchException cuando hay overloads — p.ej.
        /// InteractionQueue.PushAsContinuation tiene 4).
        /// </summary>
        /// <summary>
        /// Variante estática: invoca un método estático de un tipo por reflexión.
        /// </summary>
        public static object InvocarMetodoEstatico(Type tipo, string nomeMetodo, object[] argumentos)
        {
            if (tipo == null || string.IsNullOrEmpty(nomeMetodo))
                return null;

            MethodInfo elegido = ResolverMetodo(tipo.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static),
                nomeMetodo, argumentos);
            if (elegido == null)
                return null;

            try
            {
                return elegido.Invoke(null, argumentos);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Matchea nombre y tipos de argumentos contra la lista de métodos
        /// (GetMethod(nombre) lanza AmbiguousMatchException cuando hay overloads).
        /// </summary>
        private static MethodInfo ResolverMetodo(MethodInfo[] metodos, string nomeMetodo, object[] argumentos)
        {
            MethodInfo elegido = null;
            foreach (MethodInfo candidato in metodos)
            {
                if (candidato.Name != nomeMetodo)
                    continue;

                ParameterInfo[] parametros = candidato.GetParameters();

                // match exacto por cantidad y tipos (con nulls permitidos contra tipos de ref)
                if (parametros.Length != (argumentos != null ? argumentos.Length : 0))
                    continue;

                bool matchea = true;
                for (int i = 0; i < parametros.Length; i++)
                {
                    object valor = argumentos[i];
                    if (valor == null)
                    {
                        if (parametros[i].ParameterType.IsValueType)
                        {
                            matchea = false;
                            break;
                        }
                        continue;
                    }
                    if (!parametros[i].ParameterType.IsAssignableFrom(valor.GetType()))
                    {
                        matchea = false;
                        break;
                    }
                }

                if (!matchea)
                    continue;

                elegido = candidato;
                break;
            }

            return elegido;
        }

        public static object InvocarMetodo(object origem, string nomeMetodo, object[] argumentos)
        {
            if (origem == null || string.IsNullOrEmpty(nomeMetodo))
                return null;

            MethodInfo elegido = ResolverMetodo(origem.GetType().GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance),
                nomeMetodo, argumentos);
            if (elegido == null)
                return null;

            try
            {
                return elegido.Invoke(origem, argumentos);
            }
            catch
            {
                return null;
            }
        }

        public static bool? LerBooleano(object origem, params string[] candidatos)
        {
            foreach (string candidato in candidatos)
            {
                object valor = LerPropriedade(origem, candidato);
                bool convertido;
                if (AdaptadorConversaoDeValores.TentarConverterParaBooleano(valor, out convertido))
                    return convertido;
            }

            return null;
        }

        public static float? LerNumero(object origem, params string[] candidatos)
        {
            foreach (string candidato in candidatos)
            {
                object valor = LerPropriedade(origem, candidato);
                float convertido;
                if (AdaptadorConversaoDeValores.TentarConverterParaFloat(valor, out convertido))
                    return convertido;
            }

            return null;
        }
    }
}
