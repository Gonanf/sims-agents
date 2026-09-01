using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Core;
using Sims3.SimIFace;
using System;
using System.Reflection;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaMundo
    {
        private const string NomeMundoDesconhecido = "mundo desconhecido";
        private const string ExtensaoArquivoMundo = ".world";
        private static readonly string[] TiposDeLocalizacao = new string[]
        {
            "Sims3.UI.Localization, Sims3UI",
            "Sims3.Gameplay.Utilities.Localization, Sims3GameplaySystems",
            "Sims3.SimIFace.Localization, SimIFace"
        };

        public static string NomeMundoAtual()
        {
            string nomeLocalizado = TentarLerNomeDoMundoPorLocalizacao();
            if (TemValor(nomeLocalizado)) return nomeLocalizado;

            string nomeArquivo = TentarLerNomeDoMundoPorArquivo();
            if (TemValor(nomeArquivo)) return nomeArquivo;

            string nomeEnum = TentarLerNomeDoMundoPorEnumAtual();
            if (TemValor(nomeEnum)) return nomeEnum;

            return NomeMundoDesconhecido;
        }

        public static string TipoMundoAtual()
        {
            return GameUtils.GetCurrentWorldType().ToString();
        }

        public static bool SimEstaEmViagem(Sim sim)
        {
            if (GameUtils.IsUniversityWorld() || GameUtils.IsFutureWorld())
                return true;

            string tipoMundo = TipoMundoAtual().ToLowerInvariant();
            return tipoMundo.Contains("travel") || tipoMundo.Contains("vacation");
        }

        public static int ContarLotesComunitarios()
        {
            int total = 0;
            Lot[] lotes = Sims3.Gameplay.Queries.GetObjects<Lot>();
            if (lotes == null) return total;

            foreach (Lot lote in lotes)
            {
                if (lote == null) continue;
                if (!lote.IsCommunityLot) continue;
                total++;
            }

            return total;
        }

        public static int ContarLotesResidenciais()
        {
            int total = 0;
            Lot[] lotes = Sims3.Gameplay.Queries.GetObjects<Lot>();
            if (lotes == null) return total;

            foreach (Lot lote in lotes)
            {
                if (lote == null) continue;
                if (!lote.IsResidentialLot) continue;
                total++;
            }

            return total;
        }

        public static int ContarSimsResidentes()
        {
            Sim[] sims = Sims3.Gameplay.Queries.GetObjects<Sim>();
            return sims != null ? sims.Length : 0;
        }

        private static string TentarLerNomeDoMundoPorEnumAtual()
        {
            WorldName mundoAtual = GameUtils.GetCurrentWorld();
            if (mundoAtual == WorldName.Undefined || mundoAtual == WorldName.UserCreated)
                return string.Empty;

            return mundoAtual.ToString();
        }

        private static string TentarLerNomeDoMundoPorLocalizacao()
        {
            string chaveLocalizacao = World.GetWorldNameKey();
            if (!TemValor(chaveLocalizacao)) return string.Empty;

            string nomeTraduzido = TraduzirChaveDeLocalizacao(chaveLocalizacao);
            if (!TemValor(nomeTraduzido)) return string.Empty;

            return string.Equals(nomeTraduzido, chaveLocalizacao, StringComparison.OrdinalIgnoreCase)
                ? string.Empty
                : nomeTraduzido;
        }

        private static string TentarLerNomeDoMundoPorArquivo()
        {
            string nomeArquivo = World.GetWorldFileName();
            if (!TemValor(nomeArquivo)) return string.Empty;

            int indiceExtensao = nomeArquivo.LastIndexOf(ExtensaoArquivoMundo, StringComparison.OrdinalIgnoreCase);
            if (indiceExtensao >= 0)
                nomeArquivo = nomeArquivo.Substring(0, indiceExtensao);

            int ultimoSeparador = nomeArquivo.LastIndexOfAny(new char[] { '\\', '/' });
            if (ultimoSeparador >= 0 && ultimoSeparador + 1 < nomeArquivo.Length)
                nomeArquivo = nomeArquivo.Substring(ultimoSeparador + 1);

            return TemValor(nomeArquivo) ? nomeArquivo : string.Empty;
        }

        private static bool TemValor(string texto)
        {
            return !string.IsNullOrEmpty(texto);
        }

        private static string TraduzirChaveDeLocalizacao(string chaveLocalizacao)
        {
            foreach (string tipoLocalizacao in TiposDeLocalizacao)
            {
                Type tipo = Type.GetType(tipoLocalizacao);
                if (tipo == null)
                    continue;

                MethodInfo metodo = tipo.GetMethod(
                    "LocalizeString",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static,
                    null,
                    new Type[] { typeof(string) },
                    null);

                if (metodo == null)
                    continue;

                try
                {
                    object traduzido = metodo.Invoke(null, new object[] { chaveLocalizacao });
                    string nomeTraduzido = traduzido != null ? traduzido.ToString() : string.Empty;
                    if (TemValor(nomeTraduzido))
                        return nomeTraduzido;
                }
                catch
                {
                }
            }

            return string.Empty;
        }
    }
}
