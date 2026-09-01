// Stub SOLO DE COMPILACIÓN para Battery.Utility (S3SE).
//
// La DLL real se distribuye con el loader S3SE y se carga en runtime dentro del
// juego; NO forma parte de las 10 DLLs de referencia de TS3 1.67 (NRaas Compiler)
// porque es un agregado del ecosistema de modding. Este stub declara únicamente
// la superficie que el mod usa (Infraestrutura/InfraestruturaMod.cs) para poder
// compilar contra las referencias reales del juego sin tocar el código fuente,
// respetando la regla del upstream: el IO del mod debe seguir pasando por
// S3SE/BatteryUtils, nunca por System.IO.
//
// En runtime NUNCA se usa este ensamblado: el juego resuelve `Battery.Utility`
// contra la DLL real del loader. Ver README.md §"Estado de compilación".

namespace Battery.Utility
{
    public static class S3SE
    {
        public static bool IsInitialized
        {
            get { return false; }
        }

        public static class IO
        {
            public static class File
            {
                public static bool Exists(string caminho) { return false; }

                public static string ReadAllText(string caminho) { return null; }

                public static void WriteAllText(string caminho, string conteudo) { }
            }

            public static class Directory
            {
                public static string UserModDirectory
                {
                    get { return null; }
                }
            }
        }
    }
}
