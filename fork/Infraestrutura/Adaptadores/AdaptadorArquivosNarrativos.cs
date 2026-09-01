using System;
using System.Collections.Generic;
using System.Text;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public static class AdaptadorArquivosNarrativos
    {
        private const string MarcadorSimNome = "{sim_nome}";
        private const string MarcadorSimId = "{sim_id}";
        private const string MarcadorFamiliaNome = "{familia_nome}";
        private const string MarcadorLoteNome = "{lote_nome}";
        private const string MarcadorLoteId = "{lote_id}";

        public static string LerTextoSeguro(IAdaptadorArquivos arquivos, string caminho)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return string.Empty;

            if (!arquivos.VerificarCaminhoExiste(caminho))
                return string.Empty;

            try
            {
                return arquivos.LerTexto(caminho);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void AnexarTextoSeguro(IAdaptadorArquivos arquivos, string caminho, string conteudo)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho) || string.IsNullOrEmpty(conteudo))
                return;

            try
            {
                string textoAtual = LerTextoSeguro(arquivos, caminho);
                StringBuilder textoFinal = new StringBuilder();

                if (!string.IsNullOrEmpty(textoAtual))
                {
                    textoFinal.Append(textoAtual);
                    if (!textoAtual.EndsWith("\n"))
                        textoFinal.AppendLine();
                }

                textoFinal.Append(conteudo);
                arquivos.EscreverTexto(caminho, textoFinal.ToString());
            }
            catch
            {
            }
        }

        public static string ResolverCaminhoEstadoDoSim(string template, string nomeSimSanitizado, string idSim)
        {
            if (AdaptadorTextoNarrativo.TextoVazio(template))
                return string.Empty;

            string referenciaSim = AdaptadorTextoNarrativo.TextoVazio(nomeSimSanitizado)
                ? idSim
                : nomeSimSanitizado;

            if (AdaptadorTextoNarrativo.TextoVazio(referenciaSim))
                referenciaSim = "sim";

            string caminho = template;
            caminho = SubstituirMarcadorSePresente(caminho, MarcadorSimNome, referenciaSim);
            caminho = SubstituirMarcadorSePresente(caminho, MarcadorSimId, referenciaSim);
            return caminho;
        }

        public static string ResolverCaminhoEstadoDaFamilia(string template, string nomeFamiliaSanitizado)
        {
            if (AdaptadorTextoNarrativo.TextoVazio(template))
                return string.Empty;

            string referenciaFamilia = AdaptadorTextoNarrativo.TextoVazio(nomeFamiliaSanitizado)
                ? "familia"
                : nomeFamiliaSanitizado;

            return SubstituirMarcadorSePresente(template, MarcadorFamiliaNome, referenciaFamilia);
        }

        public static string ResolverCaminhoEstadoDoLote(string template, string nomeLoteSanitizado, string idLote)
        {
            if (AdaptadorTextoNarrativo.TextoVazio(template))
                return string.Empty;

            string nomeLote = AdaptadorTextoNarrativo.TextoVazio(nomeLoteSanitizado)
                ? "lote"
                : nomeLoteSanitizado;

            string caminho = template;
            caminho = SubstituirMarcadorSePresente(caminho, MarcadorLoteNome, nomeLote);
            caminho = SubstituirMarcadorSePresente(caminho, MarcadorLoteId, idLote ?? string.Empty);
            return caminho;
        }

        private static string SubstituirMarcadorSePresente(string template, string marcador, string valor)
        {
            if (template.IndexOf(marcador, StringComparison.Ordinal) >= 0)
                return template.Replace(marcador, valor ?? string.Empty);

            return template;
        }
    }

    public static class AdaptadorContratosJsonNarrativos
    {
        private const string SufixoLimites = "_limites";
        private const string EnvelopePedidosVazio = "{\n  \"versao_contrato\": \"1.0\",\n  \"pedidos\": []\n}";
        private const string EnvelopeRespostasVazio = "{\n  \"versao_contrato\": \"1.0\",\n  \"respostas\": []\n}";

        public static void RegistrarEventoNoEstado(IAdaptadorArquivos arquivos, string caminho, string escopo, string referencia, string cabecalho, Dictionary<string, string> cabecalhoItens, EventoNarrativoJsonContrato evento)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho) || evento == null)
                return;

            EstadoNarrativoJsonContrato estado = LerEstadoNarrativo(arquivos, caminho, escopo, referencia, cabecalho);
            estado.Escopo = escopo ?? string.Empty;
            estado.Referencia = referencia ?? string.Empty;
            estado.Cabecalho = cabecalho ?? string.Empty;
            estado.CabecalhoItens = cabecalhoItens ?? estado.CabecalhoItens;
            estado.AtualizadoEmUtc = AdaptadorJsonNarrativo.GerarHorarioUtc();
            estado.Eventos.Add(evento);
            arquivos.EscreverTexto(caminho, SerializarEstadoNarrativo(estado));
        }

        public static void AtualizarCabecalhoDoEstado(IAdaptadorArquivos arquivos, string caminho, string escopo, string referencia, string cabecalho, Dictionary<string, string> cabecalhoItens)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return;

            EstadoNarrativoJsonContrato estado = LerEstadoNarrativo(arquivos, caminho, escopo, referencia, cabecalho);
            estado.Escopo = escopo ?? string.Empty;
            estado.Referencia = referencia ?? string.Empty;
            estado.Cabecalho = cabecalho ?? string.Empty;
            estado.CabecalhoItens = cabecalhoItens ?? estado.CabecalhoItens;
            estado.AtualizadoEmUtc = AdaptadorJsonNarrativo.GerarHorarioUtc();
            arquivos.EscreverTexto(caminho, SerializarEstadoNarrativo(estado));
        }

        public static void AnexarPedido(IAdaptadorArquivos arquivos, string caminho, PedidoNarrativoJsonContrato pedido)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho) || pedido == null)
                return;

            List<PedidoNarrativoJsonContrato> pedidos = LerPedidos(arquivos, caminho);
            pedidos.Add(pedido);
            arquivos.EscreverTexto(caminho, SerializarEnvelopePedidos(pedidos));
        }

        public static void LimparPedidos(IAdaptadorArquivos arquivos, string caminho)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return;

            arquivos.EscreverTexto(caminho, EnvelopePedidosVazio);
        }

        public static List<RespostaNarrativaJsonContrato> LerRespostas(IAdaptadorArquivos arquivos, string caminho)
        {
            List<RespostaNarrativaJsonContrato> respostas = new List<RespostaNarrativaJsonContrato>();
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return respostas;

            string conteudo = AdaptadorArquivosNarrativos.LerTextoSeguro(arquivos, caminho);
            if (string.IsNullOrEmpty(conteudo))
                return respostas;

            Dictionary<string, object> raiz;
            if (!TentarLerObjetoJson(conteudo, out raiz))
                return respostas;

            object bruto;
            if (!raiz.TryGetValue("respostas", out bruto))
                return respostas;

            List<object> listaBruta = bruto as List<object>;
            if (listaBruta == null)
                return respostas;

            foreach (object itemBruto in listaBruta)
            {
                Dictionary<string, object> item = itemBruto as Dictionary<string, object>;
                if (item == null)
                    continue;

                RespostaNarrativaJsonContrato contrato = new RespostaNarrativaJsonContrato
                {
                    Id = AdaptadorJsonNarrativo.LerTexto(item, "id"),
                    Tipo = AdaptadorJsonNarrativo.LerTexto(item, "tipo"),
                    SimAtivo = AdaptadorJsonNarrativo.LerTexto(item, "sim_ativo"),
                    HorarioReal = AdaptadorJsonNarrativo.LerTexto(item, "horario_real"),
                    Prompt = AdaptadorJsonNarrativo.LerTexto(item, "prompt"),
                    Resposta = AdaptadorJsonNarrativo.LerTexto(item, "resposta")
                };

                // fork sims-agents: propagar el campo opcional acao si viene
                object acaoBruta;
                if (item.TryGetValue(AdaptadorAcaoResposta.ChaveAcao, out acaoBruta))
                    contrato.AcaoBruta = acaoBruta as Dictionary<string, object>;

                respostas.Add(contrato);
            }

            return respostas;
        }

        public static void LimparRespostas(IAdaptadorArquivos arquivos, string caminho)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return;

            arquivos.EscreverTexto(caminho, EnvelopeRespostasVazio);
        }

        public static void ReiniciarPerfilUsuario(IAdaptadorArquivos arquivos, string caminho, string promptPerfil)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return;

            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.Append("  \"versao_contrato\": \"").Append(AdaptadorJsonNarrativo.VersaoContratoAtual).Append("\",\n");
            builder.Append("  \"gerado_em\": \"").Append(AdaptadorJsonNarrativo.Escapar(AdaptadorJsonNarrativo.GerarHorarioUtc())).Append("\",\n");
            builder.Append("  \"prompt_perfil\": \"").Append(AdaptadorJsonNarrativo.Escapar(promptPerfil ?? string.Empty)).Append("\",\n");
            builder.Append("  \"diretriz_narrativa\": \"\",\n");
            builder.Append("  \"perfil_usuario\": {\n");
            builder.Append("    \"faixa_etaria\": \"\",\n");
            builder.Append("    \"personalidades_narrador\": [],\n");
            builder.Append("    \"estilos_criativos\": [],\n");
            builder.Append("    \"conteudos_permitidos\": [],\n");
            builder.Append("    \"conteudos_bloqueados\": []\n");
            builder.Append("  }\n");
            builder.Append("}");
            arquivos.EscreverTexto(caminho, builder.ToString());
        }

        public static ContextoNarrativoPrevioJsonContrato LerContextoNarrativoPrevio(IAdaptadorArquivos arquivos, string caminho)
        {
            ContextoNarrativoPrevioJsonContrato contextoVazio = CriarContextoNarrativoPrevioVazio();
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return contextoVazio;

            string conteudo = AdaptadorArquivosNarrativos.LerTextoSeguro(arquivos, caminho);
            if (string.IsNullOrEmpty(conteudo))
                return contextoVazio;

            Dictionary<string, object> raiz;
            if (!TentarLerObjetoJson(conteudo, out raiz))
                return contextoVazio;

            return new ContextoNarrativoPrevioJsonContrato
            {
                VersaoContrato = AdaptadorTextoNarrativo.OuFallback(AdaptadorJsonNarrativo.LerTexto(raiz, "versao_contrato"), AdaptadorJsonNarrativo.VersaoContratoAtual),
                AtualizadoEmUtc = AdaptadorJsonNarrativo.LerTexto(raiz, "atualizado_em_utc"),
                PensamentoAnterior = AdaptadorJsonNarrativo.LerTexto(raiz, "pensamento_anterior"),
                ContoAnterior = AdaptadorJsonNarrativo.LerTexto(raiz, "conto_anterior")
            };
        }

        public static void AtualizarContextoNarrativoPrevio(IAdaptadorArquivos arquivos, string caminho, string tipoNarrativo, string resposta)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho) || string.IsNullOrEmpty(tipoNarrativo) || string.IsNullOrEmpty(resposta))
                return;

            ContextoNarrativoPrevioJsonContrato contexto = LerContextoNarrativoPrevio(arquivos, caminho);
            string respostaSanitizada = AdaptadorTextoNarrativo.ParaLinhaUnica(resposta).Trim();
            if (AdaptadorTextoNarrativo.TipoNarrativoCorresponde(tipoNarrativo, "pensamento"))
                contexto.PensamentoAnterior = respostaSanitizada;
            else if (AdaptadorTextoNarrativo.TipoNarrativoCorresponde(tipoNarrativo, "conto"))
                contexto.ContoAnterior = respostaSanitizada;
            else
                return;

            contexto.AtualizadoEmUtc = AdaptadorJsonNarrativo.GerarHorarioUtc();
            arquivos.EscreverTexto(caminho, SerializarContextoNarrativoPrevio(contexto));
        }

        public static void LimparContextoNarrativoPrevio(IAdaptadorArquivos arquivos, string caminho)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho))
                return;

            arquivos.EscreverTexto(caminho, SerializarContextoNarrativoPrevio(CriarContextoNarrativoPrevioVazio()));
        }

        public static void AnexarLogNarrativo(IAdaptadorArquivos arquivos, string caminho, RegistroLogNarrativoJsonContrato registro)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho) || registro == null)
                return;

            List<RegistroLogNarrativoJsonContrato> logs = LerLogs(arquivos, caminho);
            logs.Add(registro);
            arquivos.EscreverTexto(caminho, SerializarEnvelopeLogs(logs));
        }

        public static bool TentarLerObjetoJson(string json, out Dictionary<string, object> objeto)
        {
            return AdaptadorJsonNarrativo.TentarLerObjetoJson(json, out objeto);
        }

        private static EstadoNarrativoJsonContrato LerEstadoNarrativo(IAdaptadorArquivos arquivos, string caminho, string escopo, string referencia, string cabecalho)
        {
            string conteudo = AdaptadorArquivosNarrativos.LerTextoSeguro(arquivos, caminho);
            if (string.IsNullOrEmpty(conteudo))
                return CriarEstadoVazio(escopo, referencia, cabecalho);

            Dictionary<string, object> raiz;
            if (!TentarLerObjetoJson(conteudo, out raiz))
                return CriarEstadoVazio(escopo, referencia, cabecalho);

            EstadoNarrativoJsonContrato estado = new EstadoNarrativoJsonContrato();
            estado.VersaoContrato = AdaptadorJsonNarrativo.LerTexto(raiz, "versao_contrato");
            if (string.IsNullOrEmpty(estado.VersaoContrato))
                estado.VersaoContrato = AdaptadorJsonNarrativo.VersaoContratoAtual;

            estado.Escopo = AdaptadorJsonNarrativo.LerTexto(raiz, "escopo");
            estado.Referencia = AdaptadorJsonNarrativo.LerTexto(raiz, "referencia");
            estado.Cabecalho = LerCabecalhoTexto(raiz);
            estado.CabecalhoItens = LerCabecalhoItens(raiz);
            estado.AtualizadoEmUtc = AdaptadorJsonNarrativo.LerTexto(raiz, "atualizado_em_utc");
            estado.Eventos = LerEventos(raiz);
            if (estado.Eventos == null)
                estado.Eventos = new List<EventoNarrativoJsonContrato>();

            return estado;
        }

        private static List<PedidoNarrativoJsonContrato> LerPedidos(IAdaptadorArquivos arquivos, string caminho)
        {
            List<PedidoNarrativoJsonContrato> pedidos = new List<PedidoNarrativoJsonContrato>();
            string conteudo = AdaptadorArquivosNarrativos.LerTextoSeguro(arquivos, caminho);
            if (string.IsNullOrEmpty(conteudo))
                return pedidos;

            Dictionary<string, object> raiz;
            if (!TentarLerObjetoJson(conteudo, out raiz))
                return pedidos;

            object bruto;
            if (!raiz.TryGetValue("pedidos", out bruto))
                return pedidos;

            List<object> lista = bruto as List<object>;
            if (lista == null)
                return pedidos;

            foreach (object pedidoBruto in lista)
            {
                Dictionary<string, object> pedido = pedidoBruto as Dictionary<string, object>;
                if (pedido == null)
                    continue;

                pedidos.Add(new PedidoNarrativoJsonContrato
                {
                    Id = AdaptadorJsonNarrativo.LerTexto(pedido, "id"),
                    Tipo = AdaptadorJsonNarrativo.LerTexto(pedido, "tipo"),
                    SimAtivo = AdaptadorJsonNarrativo.LerTexto(pedido, "sim_ativo"),
                    HorarioReal = AdaptadorJsonNarrativo.LerTexto(pedido, "horario_real"),
                    Contexto = AdaptadorJsonNarrativo.LerTexto(pedido, "contexto")
                });
            }

            return pedidos;
        }

        private static List<RegistroLogNarrativoJsonContrato> LerLogs(IAdaptadorArquivos arquivos, string caminho)
        {
            List<RegistroLogNarrativoJsonContrato> logs = new List<RegistroLogNarrativoJsonContrato>();
            string conteudo = AdaptadorArquivosNarrativos.LerTextoSeguro(arquivos, caminho);
            if (string.IsNullOrEmpty(conteudo))
                return logs;

            Dictionary<string, object> raiz;
            if (!TentarLerObjetoJson(conteudo, out raiz))
                return logs;

            object bruto;
            if (!raiz.TryGetValue("logs", out bruto))
                return logs;

            List<object> lista = bruto as List<object>;
            if (lista == null)
                return logs;

            foreach (object itemBruto in lista)
            {
                Dictionary<string, object> item = itemBruto as Dictionary<string, object>;
                if (item == null)
                    continue;

                logs.Add(new RegistroLogNarrativoJsonContrato
                {
                    HorarioReal = AdaptadorJsonNarrativo.LerTexto(item, "horario_real"),
                    Categoria = AdaptadorJsonNarrativo.LerTexto(item, "categoria"),
                    Detalhe = AdaptadorJsonNarrativo.LerTexto(item, "detalhe")
                });
            }

            return logs;
        }

        private static ContextoNarrativoPrevioJsonContrato CriarContextoNarrativoPrevioVazio()
        {
            return new ContextoNarrativoPrevioJsonContrato
            {
                VersaoContrato = AdaptadorJsonNarrativo.VersaoContratoAtual,
                AtualizadoEmUtc = AdaptadorJsonNarrativo.GerarHorarioUtc(),
                PensamentoAnterior = string.Empty,
                ContoAnterior = string.Empty
            };
        }

        private static string SerializarContextoNarrativoPrevio(ContextoNarrativoPrevioJsonContrato contexto)
        {
            ContextoNarrativoPrevioJsonContrato contextoSeguro = contexto ?? CriarContextoNarrativoPrevioVazio();
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            builder.Append("  \"versao_contrato\": \"").Append(AdaptadorJsonNarrativo.Escapar(contextoSeguro.VersaoContrato ?? AdaptadorJsonNarrativo.VersaoContratoAtual)).Append("\",\n");
            builder.Append("  \"atualizado_em_utc\": \"").Append(AdaptadorJsonNarrativo.Escapar(contextoSeguro.AtualizadoEmUtc ?? AdaptadorJsonNarrativo.GerarHorarioUtc())).Append("\",\n");
            builder.Append("  \"pensamento_anterior\": \"").Append(AdaptadorJsonNarrativo.Escapar(contextoSeguro.PensamentoAnterior ?? string.Empty)).Append("\",\n");
            builder.Append("  \"conto_anterior\": \"").Append(AdaptadorJsonNarrativo.Escapar(contextoSeguro.ContoAnterior ?? string.Empty)).Append("\"\n");
            builder.Append("}");
            return builder.ToString();
        }

        private static EstadoNarrativoJsonContrato CriarEstadoVazio(string escopo, string referencia, string cabecalho)
        {
            return new EstadoNarrativoJsonContrato
            {
                VersaoContrato = AdaptadorJsonNarrativo.VersaoContratoAtual,
                Escopo = escopo ?? string.Empty,
                Referencia = referencia ?? string.Empty,
                Cabecalho = cabecalho ?? string.Empty,
                CabecalhoItens = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase),
                AtualizadoEmUtc = AdaptadorJsonNarrativo.GerarHorarioUtc(),
                Eventos = new List<EventoNarrativoJsonContrato>()
            };
        }

        private static Dictionary<string, string> LerCabecalhoItens(Dictionary<string, object> raiz)
        {
            Dictionary<string, string> itens = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (raiz == null)
                return itens;

            object cabecalhoBruto;
            if (raiz.TryGetValue("cabecalho", out cabecalhoBruto))
            {
                Dictionary<string, object> cabecalhoObjeto = cabecalhoBruto as Dictionary<string, object>;
                if (cabecalhoObjeto != null)
                {
                    LerItensCabecalhoAgrupado(cabecalhoObjeto, "valores", false, itens);
                    LerItensCabecalhoAgrupado(cabecalhoObjeto, "limites", true, itens);
                }
            }

            return itens;
        }

        private static string LerCabecalhoTexto(Dictionary<string, object> raiz)
        {
            if (raiz == null)
                return string.Empty;

            object cabecalhoBruto;
            if (!raiz.TryGetValue("cabecalho", out cabecalhoBruto) || cabecalhoBruto == null)
                return string.Empty;

            Dictionary<string, object> cabecalhoObjeto = cabecalhoBruto as Dictionary<string, object>;
            if (cabecalhoObjeto == null)
                return string.Empty;

            return AdaptadorJsonNarrativo.LerTexto(cabecalhoObjeto, "texto");
        }

        private static void LerItensCabecalhoAgrupado(Dictionary<string, object> cabecalhoObjeto, string secao, bool chaveEhLimite, Dictionary<string, string> destino)
        {
            object secaoBruta;
            if (!cabecalhoObjeto.TryGetValue(secao, out secaoBruta))
                return;

            Dictionary<string, object> itens = secaoBruta as Dictionary<string, object>;
            if (itens == null)
                return;

            foreach (KeyValuePair<string, object> par in itens)
            {
                if (string.IsNullOrEmpty(par.Key))
                    continue;

                string chave = par.Key;
                if (chaveEhLimite && !chave.EndsWith(SufixoLimites, StringComparison.OrdinalIgnoreCase))
                    chave += SufixoLimites;

                destino[chave] = AdaptadorJsonNarrativo.LerTexto(itens, par.Key);
            }
        }

        private static List<EventoNarrativoJsonContrato> LerEventos(Dictionary<string, object> raiz)
        {
            List<EventoNarrativoJsonContrato> eventos = new List<EventoNarrativoJsonContrato>();
            object bruto;
            if (!raiz.TryGetValue("eventos", out bruto))
                return eventos;

            List<object> lista = bruto as List<object>;
            if (lista == null)
                return eventos;

            foreach (object eventoBruto in lista)
            {
                Dictionary<string, object> evento = eventoBruto as Dictionary<string, object>;
                if (evento == null)
                    continue;

                eventos.Add(new EventoNarrativoJsonContrato
                {
                    HorarioJogo = AdaptadorJsonNarrativo.LerTexto(evento, "horario_jogo"),
                    Tipo = AdaptadorJsonNarrativo.LerTexto(evento, "tipo"),
                    Ator = AdaptadorJsonNarrativo.LerTexto(evento, "ator"),
                    Alvo = AdaptadorJsonNarrativo.LerTexto(evento, "alvo"),
                    Descricao = AdaptadorJsonNarrativo.LerTexto(evento, "descricao")
                });
            }

            return eventos;
        }

        private static string SerializarEstadoNarrativo(EstadoNarrativoJsonContrato estado)
        {
            StringBuilder sb = new StringBuilder();
            List<EventoNarrativoJsonContrato> eventos = estado.Eventos ?? new List<EventoNarrativoJsonContrato>();

            sb.Append("{\n");
            sb.Append("  \"versao_contrato\": \"").Append(AdaptadorJsonNarrativo.Escapar(estado.VersaoContrato ?? AdaptadorJsonNarrativo.VersaoContratoAtual)).Append("\",\n");
            sb.Append("  \"escopo\": \"").Append(AdaptadorJsonNarrativo.Escapar(estado.Escopo ?? string.Empty)).Append("\",\n");
            sb.Append("  \"referencia\": \"").Append(AdaptadorJsonNarrativo.Escapar(estado.Referencia ?? string.Empty)).Append("\",");

            if (!string.IsNullOrEmpty(estado.Cabecalho) || (estado.CabecalhoItens != null && estado.CabecalhoItens.Count > 0))
                sb.Append(SerializarCabecalho(estado.Cabecalho, estado.CabecalhoItens));

            sb.Append("\n  \"atualizado_em_utc\": \"").Append(AdaptadorJsonNarrativo.Escapar(estado.AtualizadoEmUtc ?? AdaptadorJsonNarrativo.GerarHorarioUtc())).Append("\",\n");
            sb.Append("  \"eventos\": [");

            bool primeiroEvento = true;
            foreach (EventoNarrativoJsonContrato evento in eventos)
            {
                if (evento == null)
                    continue;

                if (!primeiroEvento)
                    sb.Append(",");

                sb.Append("\n    {");
                sb.Append("\n      \"horario_jogo\": \"").Append(AdaptadorJsonNarrativo.Escapar(evento.HorarioJogo)).Append("\",");
                sb.Append("\n      \"tipo\": \"").Append(AdaptadorJsonNarrativo.Escapar(evento.Tipo)).Append("\",");
                sb.Append("\n      \"ator\": \"").Append(AdaptadorJsonNarrativo.Escapar(evento.Ator)).Append("\",");
                sb.Append("\n      \"alvo\": \"").Append(AdaptadorJsonNarrativo.Escapar(evento.Alvo)).Append("\",");
                sb.Append("\n      \"descricao\": \"").Append(AdaptadorJsonNarrativo.Escapar(evento.Descricao)).Append("\"");
                sb.Append("\n    }");
                primeiroEvento = false;
            }

            if (!primeiroEvento)
                sb.Append("\n  ");

            sb.Append("]\n}");
            return sb.ToString();
        }

        private static string SerializarCabecalho(string cabecalhoTexto, Dictionary<string, string> cabecalhoItens)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n  \"cabecalho\": {");

            if (!string.IsNullOrEmpty(cabecalhoTexto))
                sb.Append("\n    \"texto\": \"").Append(AdaptadorJsonNarrativo.Escapar(cabecalhoTexto)).Append("\",");

            List<KeyValuePair<string, string>> limites;
            List<KeyValuePair<string, string>> valores;
            SepararCabecalhoPorCategoria(cabecalhoItens, out limites, out valores);

            sb.Append("\n    \"limites\": {");
            AppendItensCabecalho(sb, limites);
            sb.Append("\n    },");

            sb.Append("\n    \"valores\": {");
            AppendItensCabecalho(sb, valores);
            sb.Append("\n    }");
            sb.Append("\n  },");
            return sb.ToString();
        }

        private static void SepararCabecalhoPorCategoria(Dictionary<string, string> cabecalhoItens, out List<KeyValuePair<string, string>> limites, out List<KeyValuePair<string, string>> valores)
        {
            limites = new List<KeyValuePair<string, string>>();
            valores = new List<KeyValuePair<string, string>>();

            if (cabecalhoItens == null || cabecalhoItens.Count == 0)
                return;

            foreach (KeyValuePair<string, string> par in cabecalhoItens)
            {
                if (string.IsNullOrEmpty(par.Key))
                    continue;

                if (par.Key.EndsWith(SufixoLimites, StringComparison.OrdinalIgnoreCase))
                    limites.Add(new KeyValuePair<string, string>(RemoverSufixoLimites(par.Key), par.Value));
                else
                    valores.Add(par);
            }

            OrdenarCabecalho(limites);
            OrdenarCabecalho(valores);
        }

        private static void OrdenarCabecalho(List<KeyValuePair<string, string>> itens)
        {
            itens.Sort(delegate (KeyValuePair<string, string> a, KeyValuePair<string, string> b)
            {
                return string.Compare(a.Key, b.Key, StringComparison.OrdinalIgnoreCase);
            });
        }

        private static void AppendItensCabecalho(StringBuilder sb, List<KeyValuePair<string, string>> itens)
        {
            if (itens == null || itens.Count == 0)
                return;

            bool primeiroItem = true;
            foreach (KeyValuePair<string, string> item in itens)
            {
                if (primeiroItem)
                    sb.Append("\n");
                else
                    sb.Append(",\n");

                sb.Append("      ");
                sb.Append("\"").Append(AdaptadorJsonNarrativo.Escapar(item.Key)).Append("\": \"").Append(AdaptadorJsonNarrativo.Escapar(item.Value)).Append("\"");
                primeiroItem = false;
            }
        }

        private static string RemoverSufixoLimites(string chave)
        {
            if (string.IsNullOrEmpty(chave))
                return string.Empty;

            if (!chave.EndsWith(SufixoLimites, StringComparison.OrdinalIgnoreCase))
                return chave;

            return chave.Substring(0, chave.Length - SufixoLimites.Length);
        }

        private static string SerializarEnvelopePedidos(List<PedidoNarrativoJsonContrato> pedidos)
        {
            StringBuilder sb = new StringBuilder();
            List<PedidoNarrativoJsonContrato> pedidosSeguros = pedidos ?? new List<PedidoNarrativoJsonContrato>();

            sb.Append("{\n  \"versao_contrato\": \"").Append(AdaptadorJsonNarrativo.VersaoContratoAtual).Append("\",\n  \"pedidos\": [");
            bool primeiroPedido = true;
            foreach (PedidoNarrativoJsonContrato pedido in pedidosSeguros)
            {
                if (pedido == null)
                    continue;

                if (!primeiroPedido)
                    sb.Append(",");

                sb.Append("\n    {");
                sb.Append("\n      \"id\": \"").Append(AdaptadorJsonNarrativo.Escapar(pedido.Id)).Append("\",");
                sb.Append("\n      \"tipo\": \"").Append(AdaptadorJsonNarrativo.Escapar(pedido.Tipo)).Append("\",");
                sb.Append("\n      \"sim_ativo\": \"").Append(AdaptadorJsonNarrativo.Escapar(pedido.SimAtivo)).Append("\",");
                sb.Append("\n      \"horario_real\": \"").Append(AdaptadorJsonNarrativo.Escapar(pedido.HorarioReal)).Append("\",");
                sb.Append("\n      \"contexto\": \"").Append(AdaptadorJsonNarrativo.Escapar(pedido.Contexto)).Append("\"");
                sb.Append("\n    }");
                primeiroPedido = false;
            }

            if (!primeiroPedido)
                sb.Append("\n  ");

            sb.Append("]\n}");
            return sb.ToString();
        }

        private static string SerializarEnvelopeLogs(List<RegistroLogNarrativoJsonContrato> logs)
        {
            StringBuilder sb = new StringBuilder();
            List<RegistroLogNarrativoJsonContrato> logsSeguros = logs ?? new List<RegistroLogNarrativoJsonContrato>();

            sb.Append("{\n  \"versao_contrato\": \"").Append(AdaptadorJsonNarrativo.VersaoContratoAtual).Append("\",\n  \"logs\": [");
            bool primeiroLog = true;
            foreach (RegistroLogNarrativoJsonContrato log in logsSeguros)
            {
                if (log == null)
                    continue;

                if (!primeiroLog)
                    sb.Append(",");

                sb.Append("\n    {");
                sb.Append("\n      \"horario_real\": \"").Append(AdaptadorJsonNarrativo.Escapar(log.HorarioReal)).Append("\",");
                sb.Append("\n      \"categoria\": \"").Append(AdaptadorJsonNarrativo.Escapar(log.Categoria)).Append("\",");
                sb.Append("\n      \"detalhe\": \"").Append(AdaptadorJsonNarrativo.Escapar(log.Detalhe)).Append("\"");
                sb.Append("\n    }");
                primeiroLog = false;
            }

            if (!primeiroLog)
                sb.Append("\n  ");

            sb.Append("]\n}");
            return sb.ToString();
        }
    }
}