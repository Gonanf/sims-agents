using System;
using System.Collections.Generic;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public static class AdaptadorTextoNarrativo
    {
        private const string MarcadorPontoEVirgula = "__PV__";
        private const string MarcadorNovaLinha = "__NL__";

        public static bool TextoVazio(string texto)
        {
            return string.IsNullOrEmpty(texto);
        }

        public static bool TextoPreenchido(string texto)
        {
            return !TextoVazio(texto);
        }

        public static bool ObjetoNulo(object valor)
        {
            return valor == null;
        }

        public static bool DicionarioNuloOuChaveVazia<TValor>(IDictionary<string, TValor> valores, string chave)
        {
            return valores == null || TextoVazio(chave);
        }

        public static bool TentarObterValor<TValor>(IDictionary<string, TValor> valores, string chave, out TValor valor)
        {
            valor = default(TValor);
            if (DicionarioNuloOuChaveVazia(valores, chave))
                return false;

            return valores.TryGetValue(chave, out valor);
        }

        public static string SanitizarLinha(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            return texto.Replace("\r", " ").Replace("\n", " ").Replace("|", "/").Trim();
        }

        public static string NormalizarPilhaDeExcecao(string stackTrace)
        {
            if (string.IsNullOrEmpty(stackTrace))
                return string.Empty;

            return stackTrace.Replace("\r", " ").Replace("\n", " | ");
        }

        public static string MontarDetalheDeExcecao(Exception excecaoCapturada, string contexto)
        {
            if (excecaoCapturada == null)
                return string.Empty;

            Exception excecaoInterna = excecaoCapturada.InnerException;
            string metodo = excecaoCapturada.TargetSite != null ? excecaoCapturada.TargetSite.Name : string.Empty;

            return string.Format("tipo={0};mensagem={1};contexto={2};origem={3};metodo={4};pilha={5};inner_tipo={6};inner_mensagem={7};inner_pilha={8}",
                CodificarContexto(excecaoCapturada.GetType().FullName ?? excecaoCapturada.GetType().Name),
                CodificarContexto(excecaoCapturada.Message ?? string.Empty),
                CodificarContexto(contexto ?? string.Empty),
                CodificarContexto(excecaoCapturada.Source ?? string.Empty),
                CodificarContexto(metodo),
                CodificarContexto(NormalizarPilhaDeExcecao(excecaoCapturada.StackTrace)),
                CodificarContexto(excecaoInterna != null ? (excecaoInterna.GetType().FullName ?? excecaoInterna.GetType().Name) : string.Empty),
                CodificarContexto(excecaoInterna != null ? (excecaoInterna.Message ?? string.Empty) : string.Empty),
                CodificarContexto(excecaoInterna != null ? NormalizarPilhaDeExcecao(excecaoInterna.StackTrace) : string.Empty));
        }

        public static string CodificarContexto(string contexto)
        {
            if (string.IsNullOrEmpty(contexto))
                return string.Empty;

            return contexto
                .Replace("\\", "\\\\")
                .Replace(";", MarcadorPontoEVirgula)
                .Replace("\r", " ")
                .Replace("\n", MarcadorNovaLinha);
        }

        public static string DecodificarContexto(string contextoCodificado)
        {
            if (string.IsNullOrEmpty(contextoCodificado))
                return string.Empty;

            return contextoCodificado
                .Replace(MarcadorPontoEVirgula, ";")
                .Replace("\\\\", "\\")
                .Replace(MarcadorNovaLinha, " ");
        }

        public static Dictionary<string, string> ParsearPartesDetalhe(string detalhe)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(detalhe))
                return resultado;

            string[] partes = detalhe.Split(';');
            foreach (string parte in partes)
            {
                int separador = parte.IndexOf('=');
                if (separador <= 0)
                    continue;

                string chave = parte.Substring(0, separador).Trim();
                string valor = parte.Substring(separador + 1).Trim();
                resultado[chave] = valor;
            }

            return resultado;
        }

        public static string ResumirEventos(IList<string> eventos)
        {
            if (eventos == null || eventos.Count == 0)
                return "sem eventos";

            StringBuilder sb = new StringBuilder();
            foreach (string evento in eventos)
            {
                if (sb.Length > 0)
                    sb.Append(" || ");

                sb.Append(evento);
            }

            return sb.ToString();
        }

        public static bool TipoNarrativoCorresponde(string tipoNarrativo, string tipoEsperado)
        {
            return !string.IsNullOrEmpty(tipoNarrativo)
                && !string.IsNullOrEmpty(tipoEsperado)
                && tipoNarrativo.IndexOf(tipoEsperado, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static string LimitarContextoFinal(string contexto, int limiteCaracteres)
        {
            if (string.IsNullOrEmpty(contexto) || limiteCaracteres < 1 || contexto.Length <= limiteCaracteres)
                return contexto;

            return contexto.Substring(contexto.Length - limiteCaracteres);
        }

        public static string ResumirEventosNarrativos(IList<EventoNarrativoJsonContrato> eventos, int limiteResumo)
        {
            if (eventos == null || eventos.Count == 0)
                return "sem eventos";

            int limite = limiteResumo < 1 ? 1 : limiteResumo;
            int inicio = eventos.Count > limite ? eventos.Count - limite : 0;
            StringBuilder sb = new StringBuilder();

            int indiceAtual = 0;
            foreach (EventoNarrativoJsonContrato evento in eventos)
            {
                if (indiceAtual < inicio)
                {
                    indiceAtual++;
                    continue;
                }

                if (sb.Length > 0)
                    sb.Append(" || ");

                sb.Append(FormatarEventoNarrativoParaContexto(evento));
                indiceAtual++;
            }

            return sb.ToString();
        }

        public static string FormatarEventoNarrativoParaContexto(EventoNarrativoJsonContrato evento)
        {
            if (evento == null)
                return string.Empty;

            Dictionary<string, string> campos = new Dictionary<string, string>();
            campos["horario"] = evento.HorarioJogo ?? string.Empty;
            campos["ator"] = evento.Ator ?? string.Empty;
            campos["alvo"] = evento.Alvo ?? string.Empty;
            campos["descricao"] = evento.Descricao ?? string.Empty;
            return TradutorDeEventos.Traduzir(evento.Tipo, campos);
        }

        public static void AdicionarComSeparador(StringBuilder sb, string texto, string separador)
        {
            if (sb == null || string.IsNullOrEmpty(texto))
                return;

            if (sb.Length > 0 && !string.IsNullOrEmpty(separador))
                sb.Append(separador);

            sb.Append(texto);
        }

        public static string Juntar(string[] partes, string separador)
        {
            StringBuilder sb = new StringBuilder();
            if (partes == null)
                return string.Empty;

            foreach (string parte in partes)
                AdicionarComSeparador(sb, parte, separador);

            return sb.ToString();
        }

        public static string OuFallback(string valor, string fallback)
        {
            return string.IsNullOrEmpty(valor) ? fallback : valor;
        }

        public static string FormatarCampo(string rotulo, string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            return rotulo + ": " + valor;
        }

        public static void AdicionarCampo(StringBuilder sb, string rotulo, string valor, string separador)
        {
            string campo = FormatarCampo(rotulo, valor);
            if (!string.IsNullOrEmpty(campo))
                AdicionarComSeparador(sb, campo, separador);
        }

        public static string CapitalizarPrimeira(string texto)
        {
            return PrimeiraMaiuscula(texto);
        }

        public static string PronomeSubjetivo(bool feminino)
        {
            return feminino ? "ela" : "ele";
        }

        public static string PronomePossessivo(bool feminino)
        {
            return feminino ? "sua" : "seu";
        }

        public static string ArtigoDefinido(bool feminino)
        {
            return feminino ? "a" : "o";
        }

        public static string FormatarLista(string[] itens)
        {
            if (itens == null || itens.Length == 0)
                return string.Empty;

            if (itens.Length == 1)
                return itens[0];

            if (itens.Length == 2)
                return itens[0] + " e " + itens[1];

            StringBuilder sb = new StringBuilder();
            int indice = 0;
            while (indice < itens.Length - 1)
            {
                AdicionarComSeparador(sb, itens[indice], ", ");
                indice++;
            }

            sb.Append(" e ");
            sb.Append(itens[itens.Length - 1]);
            return sb.ToString();
        }

        public static string Truncar(string texto, int maxCaracteres)
        {
            if (string.IsNullOrEmpty(texto) || texto.Length <= maxCaracteres)
                return texto;

            if (maxCaracteres <= 3)
                return texto.Substring(0, maxCaracteres);

            return texto.Substring(0, maxCaracteres - 3) + "...";
        }

        public static string ParaLinhaUnica(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return texto.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");
        }

        public static string ExtrairUltimoSegmento(string texto, params char[] separadores)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            string resultado = texto.Trim();
            if (separadores == null || separadores.Length == 0)
                return resultado;

            foreach (char separador in separadores)
            {
                int indice = resultado.LastIndexOf(separador);
                if (indice >= 0 && indice < resultado.Length - 1)
                    resultado = resultado.Substring(indice + 1).Trim();
            }

            return resultado;
        }

        public static string ObterCampo(IDictionary<string, string> campos, params string[] chaves)
        {
            if (campos == null || chaves == null)
                return string.Empty;

            foreach (string chave in chaves)
            {
                string valor;
                if (!string.IsNullOrEmpty(chave) && campos.TryGetValue(chave, out valor) && !string.IsNullOrEmpty(valor))
                    return valor;
            }

            return string.Empty;
        }

        public static string FormatarHorario(string horario)
        {
            if (string.IsNullOrEmpty(horario))
                return string.Empty;

            string valor = horario.Trim();
            if (valor.Length >= 5 && valor[2] == ':')
                return valor.Substring(0, 2) + "h" + valor.Substring(3, 2);

            return valor;
        }

        public static string NormalizarPredicado(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "vivenciou um evento";

            string normalizado = texto.Trim();
            if (normalizado.Length == 1)
                return normalizado.ToLowerInvariant();

            return char.ToLowerInvariant(normalizado[0]) + normalizado.Substring(1);
        }

        public static string PrimeiraMaiuscula(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            if (texto.Length == 1)
                return texto.ToUpperInvariant();

            return char.ToUpperInvariant(texto[0]) + texto.Substring(1);
        }

        public static string LimparDescricaoInteracao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                return string.Empty;

            string limpa = descricao.Trim();
            limpa = limpa.Replace('_', ' ');
            return limpa;
        }

        public static string GerarLegendaEvento(string eventoId)
        {
            if (string.IsNullOrEmpty(eventoId))
                return "Evento";

            string id = eventoId[0] == 'k' && eventoId.Length > 1 ? eventoId.Substring(1) : eventoId;

            List<char> chars = new List<char>(id.Length + 16);
            char caractereAnterior = '\0';
            bool primeiroCaractere = true;
            foreach (char atual in id)
            {
                if (!primeiroCaractere && char.IsUpper(atual) && char.IsLower(caractereAnterior))
                    chars.Add(' ');

                if (atual == '_')
                    chars.Add(' ');
                else
                    chars.Add(atual);

                caractereAnterior = atual;
                primeiroCaractere = false;
            }

            string texto = new string(chars.ToArray()).Trim();
            if (texto.Length == 0)
                return "Evento";

            return char.ToUpper(texto[0]) + texto.Substring(1);
        }

        public static bool EventoIdEhValido(string eventoId)
        {
            return !string.IsNullOrEmpty(eventoId) && eventoId.Trim().Length > 0;
        }

        public static bool TextoIncluiParte(string texto, string parte)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(parte))
                return false;

            return texto.IndexOf(parte, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool TextoIncluiAlgumaParte(string texto, params string[] partes)
        {
            if (string.IsNullOrEmpty(texto) || partes == null || partes.Length == 0)
                return false;

            foreach (string parte in partes)
            {
                if (TextoIncluiParte(texto, parte))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Expande apenas variaveis conhecidas do usuario sem depender de APIs ausentes no runtime reduzido do TS3.
        /// </summary>
        /// <remarks>
        /// <para>O runtime legado usado pelo mod nao expoe <c>Environment.ExpandEnvironmentVariables</c>, entao a expansao precisa ser manual.</para>
        /// <para>Hoje o fluxo depende de <c>%USERPROFILE%</c> e <c>%USERNAME%</c> para resolver caminhos absolutos a partir do arquivo de configuracao.</para>
        /// </remarks>
        public static string ExpandirVariaveisDeUsuario(string valor, string userProfile, string userName)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            string resultado = valor;
            if (!string.IsNullOrEmpty(userProfile))
                resultado = SubstituirTokenIgnoreCase(resultado, "%USERPROFILE%", userProfile);

            if (!string.IsNullOrEmpty(userName))
                resultado = SubstituirTokenIgnoreCase(resultado, "%USERNAME%", userName);

            return resultado;
        }

        public static string ExtrairUserProfileDoDiretorioBase(string diretorioBase)
        {
            if (string.IsNullOrEmpty(diretorioBase))
                return string.Empty;

            string marcador = "\\Documents\\";
            int indice = diretorioBase.IndexOf(marcador, StringComparison.OrdinalIgnoreCase);
            if (indice <= 0)
                return string.Empty;

            return diretorioBase.Substring(0, indice);
        }

        public static bool EhCaminhoAbsolutoWindows(string caminho)
        {
            if (string.IsNullOrEmpty(caminho))
                return false;

            return caminho.Contains(":\\") || caminho.StartsWith("\\\\");
        }

        public static string CombinarCaminhoWindows(string pasta, string arquivo)
        {
            if (string.IsNullOrEmpty(pasta))
                return arquivo ?? string.Empty;

            if (string.IsNullOrEmpty(arquivo))
                return pasta;

            return pasta.TrimEnd('\\', '/') + "\\" + arquivo;
        }

        private static string SubstituirTokenIgnoreCase(string texto, string token, string novoValor)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(token))
                return texto ?? string.Empty;

            int indice = texto.IndexOf(token, StringComparison.OrdinalIgnoreCase);
            if (indice < 0)
                return texto;

            StringBuilder builder = new StringBuilder(texto.Length);
            int inicio = 0;

            while (indice >= 0)
            {
                builder.Append(texto.Substring(inicio, indice - inicio));
                builder.Append(novoValor ?? string.Empty);
                inicio = indice + token.Length;

                if (inicio >= texto.Length)
                    break;

                string restante = texto.Substring(inicio);
                int proximoIndice = restante.IndexOf(token, StringComparison.OrdinalIgnoreCase);
                indice = proximoIndice < 0 ? -1 : inicio + proximoIndice;
            }

            if (inicio < texto.Length)
                builder.Append(texto.Substring(inicio));

            return builder.ToString();
        }
    }
}
