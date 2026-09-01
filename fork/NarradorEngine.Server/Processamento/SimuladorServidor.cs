using NarradorEngine.Server.Contratos;
using NarradorEngine.Server.Servicos;
using System.Text.Json;

namespace NarradorEngine.Server.Processamento;

internal static class SimuladorServidor
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    private const string NomeArquivoPedidosSimulacao = "NarradorPorEventos.pedidos.simulacao.json";

    public static async Task ExecutarAsync(ConfiguracaoServidor configuracao, ProcessadorPedidosNarrativos processador)
    {
        var diretorioPedidos = Path.GetDirectoryName(configuracao.CaminhoPedidos) ?? AppContext.BaseDirectory;
        Directory.CreateDirectory(diretorioPedidos);

        var arquivosEstado = DescobrirArquivosEstado(diretorioPedidos);
        var simAtivo = ResolverNomeSimAtivo(configuracao.CaminhoPedidos, arquivosEstado.CaminhoSim);
        var contextoProjetoReal = ConstruirContextoProjetoReal(arquivosEstado, simAtivo);

        var pedidoPensamento = new PedidoNarrativoJsonContrato
        {
            Id = CriarId("pensamento"),
            Tipo = "pensamento",
            SimAtivo = simAtivo,
            HorarioReal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Contexto = contextoProjetoReal.ContextoPensamento
        };

        var pedidoConto = new PedidoNarrativoJsonContrato
        {
            Id = CriarId("conto"),
            Tipo = "conto",
            SimAtivo = simAtivo,
            HorarioReal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Contexto = contextoProjetoReal.ContextoConto
        };

        var envelope = new EnvelopePedidosJsonContrato();
        envelope.Pedidos.Add(pedidoPensamento);
        envelope.Pedidos.Add(pedidoConto);

        var caminhoPedidosSimulacao = Path.Combine(diretorioPedidos, NomeArquivoPedidosSimulacao);
        File.WriteAllText(caminhoPedidosSimulacao, JsonSerializer.Serialize(envelope, JsonOptions));

        File.WriteAllText(configuracao.CaminhoPedidos, JsonSerializer.Serialize(envelope, JsonOptions));
        var processados = 0;
        var erroProcessamento = string.Empty;
        try
        {
            processados = await processador.ProcessarUmaVezAsync(CancellationToken.None);
        }
        catch (Exception ex)
        {
            erroProcessamento = ex.Message;
        }

        var respostasGeradas = File.Exists(configuracao.CaminhoRespostas);
        var tamanhoRespostas = respostasGeradas ? new FileInfo(configuracao.CaminhoRespostas).Length : 0L;

        Console.WriteLine($"Simulação concluída. Pedidos processados: {processados}");
        Console.WriteLine($"Sim ativo da simulação: {simAtivo}");
        Console.WriteLine($"Arquivo de pedidos: {configuracao.CaminhoPedidos}");
        Console.WriteLine($"Snapshot dos pedidos da simulação: {caminhoPedidosSimulacao}");
        Console.WriteLine($"Arquivo de respostas: {configuracao.CaminhoRespostas}");
        Console.WriteLine($"Respostas geradas: {(respostasGeradas ? "sim" : "não")} | tamanho_bytes={tamanhoRespostas}");
        Console.WriteLine($"Arquivo de perfil narrativo: {configuracao.CaminhoPerfilUsuario}");
        Console.WriteLine($"Diretriz de perfil ativa: {configuracao.DiretrizNarrativaPerfil}");
        if (!string.IsNullOrWhiteSpace(erroProcessamento))
        {
            Console.WriteLine($"Falha ao gerar respostas narrativas nesta simulação: {erroProcessamento}");
        }
        Console.WriteLine($"Estado sim: {arquivosEstado.CaminhoSim}");
        Console.WriteLine($"Estado família: {arquivosEstado.CaminhoFamilia}");
        Console.WriteLine($"Estado mundo: {arquivosEstado.CaminhoMundo}");
    }

    private static (string ContextoPensamento, string ContextoConto) ConstruirContextoProjetoReal((string CaminhoSim, string CaminhoFamilia, string CaminhoMundo) arquivos, string simAtivo)
    {
        var caminhoSim = arquivos.CaminhoSim;
        var caminhoFamilia = arquivos.CaminhoFamilia;
        var caminhoMundo = arquivos.CaminhoMundo;

        var estadoSimResumo = LerResumoEstado(caminhoSim, new[]
        {
            "identidade", "estado_emocional", "necessidades_criticas", "ambiente_atual"
        }, 1800);
        var estadoFamiliaResumo = LerResumoEstado(caminhoFamilia, new[]
        {
            "nome", "membros", "fundos", "classe"
        }, 1200);
        var estadoMundoResumo = LerResumoEstado(caminhoMundo, new[]
        {
            "nome", "tipo", "populacao", "lotes_residenciais", "lotes_comunitarios"
        }, 1200);

        var eventosSim = LerResumoEventos(caminhoSim, 10);
        var eventosFamilia = LerResumoEventos(caminhoFamilia, 10);
        var eventosMundo = LerResumoEventos(caminhoMundo, 20);

        var pensamento =
            "tipo=pensamento | sim=" + simAtivo +
            " | estado_sim=" + estadoSimResumo +
            " | estado_familia=" + estadoFamiliaResumo +
            " | estado_mundo=" + estadoMundoResumo +
            " | eventos_sim=" + eventosSim +
            " | eventos_familia=" + eventosFamilia;

        var conto =
            "tipo=conto | sim=" + simAtivo +
            " | estado_sim=" + estadoSimResumo +
            " | estado_familia=" + estadoFamiliaResumo +
            " | estado_mundo=" + estadoMundoResumo +
            " | eventos_sim=" + eventosSim +
            " | eventos_familia=" + eventosFamilia +
            " | eventos_mundo=" + eventosMundo;

        return (pensamento, conto);
    }

    private static string LerResumoEventos(string caminho, int maxEventos)
    {
        if (string.IsNullOrWhiteSpace(caminho) || !File.Exists(caminho))
            return "sem eventos";

        try
        {
            using var documento = JsonDocument.Parse(File.ReadAllText(caminho));
            if (!documento.RootElement.TryGetProperty("eventos", out var eventos) || eventos.ValueKind != JsonValueKind.Array)
                return "sem eventos";

            var itens = eventos.EnumerateArray().ToList();
            if (itens.Count == 0)
                return "sem eventos";

            var inicio = Math.Max(0, itens.Count - maxEventos);
            var saida = new List<string>();

            var indiceAtual = 0;
            foreach (var item in itens)
            {
                if (indiceAtual < inicio)
                {
                    indiceAtual++;
                    continue;
                }

                var horario = LerTexto(item, "horario_jogo");
                var tipo = LerTexto(item, "tipo");
                var ator = LerTexto(item, "ator");
                var alvo = LerTexto(item, "alvo");
                var descricao = LerTexto(item, "descricao");

                saida.Add($"[{horario}] tipo={tipo};ator={ator};alvo={alvo};descricao={descricao}");
                indiceAtual++;
            }

            return Limitar(AdaptadorTextoServidor.CompactarParaLinhaUnica(string.Join(" || ", saida)), 2400);
        }
        catch
        {
            return "sem eventos";
        }
    }

    private static string LerResumoEstado(string caminho, string[] chavesCabecalho, int limite)
    {
        if (string.IsNullOrWhiteSpace(caminho) || !File.Exists(caminho))
            return "indisponível";

        try
        {
            using var documento = JsonDocument.Parse(File.ReadAllText(caminho));
            var raiz = documento.RootElement;
            var partes = new List<string>();

            foreach (var chave in chavesCabecalho)
            {
                var texto = LerValorCabecalho(raiz, chave);
                if (string.IsNullOrWhiteSpace(texto))
                {
                    continue;
                }

                partes.Add(chave + "=" + texto);
            }

            if (partes.Count == 0)
                return "indisponível";

            return Limitar(AdaptadorTextoServidor.CompactarParaLinhaUnica(string.Join(" | ", partes)), limite);
        }
        catch
        {
            return "indisponível";
        }
    }

    private static string ResolverNomeSimAtivo(string caminhoPedidos, string caminhoEstadoSim)
    {
        var nomeDoArquivo = ExtrairNomeSimDoArquivoEstado(caminhoEstadoSim);
        if (!string.IsNullOrWhiteSpace(nomeDoArquivo))
        {
            return nomeDoArquivo;
        }

        if (!string.IsNullOrWhiteSpace(caminhoEstadoSim) && File.Exists(caminhoEstadoSim))
        {
            try
            {
                using var documento = JsonDocument.Parse(File.ReadAllText(caminhoEstadoSim));
                var raiz = documento.RootElement;
                var identidade = LerValorCabecalho(raiz, "identidade");
                if (!string.IsNullOrWhiteSpace(identidade))
                {
                    var marcador = "IDENTIDADE:";
                    var inicio = identidade.IndexOf(marcador, StringComparison.OrdinalIgnoreCase);
                    if (inicio >= 0)
                    {
                        var resto = AdaptadorTextoServidor.ApararOuVazio(identidade.Substring(inicio + marcador.Length));
                        var fim = resto.IndexOf('|');
                        return AdaptadorTextoServidor.ApararOuVazio(fim >= 0 ? resto.Substring(0, fim) : resto);
                    }
                }

                var referencia = LerTexto(raiz, "referencia");
                if (!string.IsNullOrWhiteSpace(referencia))
                {
                    return AdaptadorTextoServidor.ApararOuVazio(referencia);
                }
            }
            catch
            {
            }
        }

        if (File.Exists(caminhoPedidos))
        {
            try
            {
                var envelope = JsonSerializer.Deserialize<EnvelopePedidosJsonContrato>(File.ReadAllText(caminhoPedidos));
                var ultimo = envelope?.Pedidos?.LastOrDefault();
                if (ultimo != null && !string.IsNullOrWhiteSpace(ultimo.SimAtivo))
                    return AdaptadorTextoServidor.ApararOuVazio(ultimo.SimAtivo);
            }
            catch
            {
            }
        }

        return "Sim Ativo";
    }

    private static string ExtrairNomeSimDoArquivoEstado(string caminhoArquivoEstado)
    {
        if (string.IsNullOrWhiteSpace(caminhoArquivoEstado))
        {
            return string.Empty;
        }

        var nomeArquivo = Path.GetFileNameWithoutExtension(caminhoArquivoEstado);
        if (string.IsNullOrWhiteSpace(nomeArquivo))
        {
            return string.Empty;
        }

        const string prefixo = "NarradorPorEventos.estado.sim.";
        if (!nomeArquivo.StartsWith(prefixo, StringComparison.OrdinalIgnoreCase))
        {
            return string.Empty;
        }

        return AdaptadorTextoServidor.ApararOuVazio(nomeArquivo.Substring(prefixo.Length));
    }

    private static (string CaminhoSim, string CaminhoFamilia, string CaminhoMundo) DescobrirArquivosEstado(string diretorioBase)
    {
        var candidatos = new List<string>();
        if (!string.IsNullOrWhiteSpace(diretorioBase))
        {
            candidatos.Add(diretorioBase);
        }

        var caminhoSim = EncontrarArquivoRecente(candidatos, "NarradorPorEventos.estado.sim.*.json");
        var caminhoFamilia = EncontrarArquivoRecente(candidatos, "NarradorPorEventos.estado.familia.*.json");
        var caminhoMundo = EncontrarArquivoRecente(candidatos, "NarradorPorEventos.estado.mundo.json");

        return (caminhoSim, caminhoFamilia, caminhoMundo);
    }

    private static string EncontrarArquivoRecente(IEnumerable<string> diretorios, string padrao)
    {
        var melhores = new List<FileInfo>();
        foreach (var dir in diretorios)
        {
            if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir))
            {
                continue;
            }

            var arquivos = Directory.GetFiles(dir, padrao);
            foreach (var arquivo in arquivos)
            {
                melhores.Add(new FileInfo(arquivo));
            }
        }

        return melhores
            .OrderByDescending(a => a.LastWriteTimeUtc)
            .Select(a => a.FullName)
            .FirstOrDefault() ?? string.Empty;
    }

    private static string LerTexto(JsonElement elemento, string chave)
    {
        if (!elemento.TryGetProperty(chave, out var propriedade))
            return string.Empty;

        return propriedade.ValueKind == JsonValueKind.String
            ? propriedade.GetString() ?? string.Empty
            : propriedade.ToString();
    }

    private static string LerValorCabecalho(JsonElement raiz, string chave)
    {
        if (string.IsNullOrWhiteSpace(chave))
            return string.Empty;

        if (raiz.TryGetProperty("cabecalho", out var cabecalho) && cabecalho.ValueKind == JsonValueKind.Object)
        {
            var valorAtual = LerValorCabecalhoDaSecao(cabecalho, "valores", chave);
            if (!string.IsNullOrWhiteSpace(valorAtual))
                return valorAtual;

            var limiteAtual = LerValorCabecalhoDaSecao(cabecalho, "limites", chave);
            if (!string.IsNullOrWhiteSpace(limiteAtual))
                return limiteAtual;

            var limiteComSufixo = LerValorCabecalhoDaSecao(cabecalho, "limites", chave + "_limites");
            if (!string.IsNullOrWhiteSpace(limiteComSufixo))
                return limiteComSufixo;

            if (cabecalho.TryGetProperty("texto", out var textoCabecalho) && string.Equals(chave, "texto", StringComparison.OrdinalIgnoreCase))
                return textoCabecalho.ValueKind == JsonValueKind.String ? textoCabecalho.GetString() ?? string.Empty : textoCabecalho.ToString();
        }

        return string.Empty;
    }

    private static string LerValorCabecalhoDaSecao(JsonElement cabecalho, string secao, string chave)
    {
        if (!cabecalho.TryGetProperty(secao, out var secaoElemento) || secaoElemento.ValueKind != JsonValueKind.Object)
            return string.Empty;

        if (!secaoElemento.TryGetProperty(chave, out var valor))
            return string.Empty;

        return valor.ValueKind == JsonValueKind.String
            ? valor.GetString() ?? string.Empty
            : valor.ToString();
    }

    private static string Limitar(string texto, int limite)
    {
        if (string.IsNullOrEmpty(texto) || texto.Length <= limite)
            return texto;

        return texto.Substring(texto.Length - limite);
    }

    private static string CriarId(string tipo)
    {
        return DateTime.Now.Ticks + "_" + tipo;
    }
}
