using System.Reflection;

namespace NarradorEngine.Server.Tests.Processamento;

public sealed class SimuladorServidorTests
{
    private static readonly Type TipoSimulador = Type.GetType("NarradorEngine.Server.Processamento.SimuladorServidor, NarradorEngine.Server", throwOnError: true)!;

    [Fact]
    public void LerResumoEstado_QuandoTemCamposPrioritarios_DeveMontarResumo()
    {
        var arquivo = CriarArquivoTemporarioJson("""
        {
          "cabecalho": {
            "valores": {
              "identidade": "IDENTIDADE: Helen | adulto",
              "estado_emocional": "HUMOR: bom",
              "necessidades_criticas": "nenhuma"
            },
            "limites": {}
          }
        }
        """);

        var metodo = TipoSimulador.GetMethod("LerResumoEstado", BindingFlags.NonPublic | BindingFlags.Static)!;
        var resumo = (string)metodo.Invoke(null, new object[]
        {
            arquivo,
            new[] { "identidade", "estado_emocional", "necessidades_criticas" },
            500
        })!;

        Assert.Contains("identidade=IDENTIDADE: Helen | adulto", resumo);
        Assert.Contains("estado_emocional=HUMOR: bom", resumo);
        Assert.Contains("necessidades_criticas=nenhuma", resumo);
    }

    [Fact]
    public void LerResumoEstado_QuandoNaoTemCamposPrioritarios_DeveRetornarIndisponivel()
    {
        var arquivo = CriarArquivoTemporarioJson("""
        {
          "cabecalho": "LEGADO: resumo principal"
        }
        """);

        var metodo = TipoSimulador.GetMethod("LerResumoEstado", BindingFlags.NonPublic | BindingFlags.Static)!;
        var resumo = (string)metodo.Invoke(null, new object[]
        {
            arquivo,
            new[] { "cabecalho_identidade" },
            500
        })!;

        Assert.Equal("indisponível", resumo);
    }

    [Fact]
    public void LerResumoEventos_DeveLimitarQuantidadeFinal()
    {
        var arquivo = CriarArquivoTemporarioJson("""
        {
          "eventos": [
            { "horario_jogo": "08:00", "tipo": "A", "ator": "s1", "alvo": "x", "descricao": "d1" },
            { "horario_jogo": "09:00", "tipo": "B", "ator": "s2", "alvo": "y", "descricao": "d2" },
            { "horario_jogo": "10:00", "tipo": "C", "ator": "s3", "alvo": "z", "descricao": "d3" }
          ]
        }
        """);

        var metodo = TipoSimulador.GetMethod("LerResumoEventos", BindingFlags.NonPublic | BindingFlags.Static)!;
        var resumo = (string)metodo.Invoke(null, new object[] { arquivo, 2 })!;

        Assert.DoesNotContain("tipo=A", resumo);
        Assert.Contains("tipo=B", resumo);
        Assert.Contains("tipo=C", resumo);
    }

    [Fact]
    public void ResolverNomeSimAtivo_QuandoArquivoEstadoTemNome_DevePriorizarNomeDoArquivo()
    {
        var diretorio = CriarDiretorioTemporario();
        var caminhoEstado = Path.Combine(diretorio, "NarradorPorEventos.estado.sim.Helen Caixão.json");
        File.WriteAllText(caminhoEstado, "{}");

        var caminhoPedidos = Path.Combine(diretorio, "pedidos.json");
        File.WriteAllText(caminhoPedidos, "{\"pedidos\":[]}");

        var metodo = TipoSimulador.GetMethod("ResolverNomeSimAtivo", BindingFlags.NonPublic | BindingFlags.Static)!;
        var nome = (string)metodo.Invoke(null, new object[] { caminhoPedidos, caminhoEstado })!;

        Assert.Equal("Helen Caixão", nome);
    }

    [Fact]
    public void ResolverNomeSimAtivo_QuandoNaoTemNomeNoArquivo_DeveUsarCabecalhoIdentidade()
    {
        var diretorio = CriarDiretorioTemporario();
        var caminhoEstado = Path.Combine(diretorio, "estado-sim.json");
        File.WriteAllText(caminhoEstado, """
        {
          "cabecalho": {
            "valores": {
              "identidade": "IDENTIDADE: Morgana Wolff | adulto"
            },
            "limites": {}
          }
        }
        """);

        var caminhoPedidos = Path.Combine(diretorio, "pedidos.json");
        File.WriteAllText(caminhoPedidos, "{\"pedidos\":[]}");

        var metodo = TipoSimulador.GetMethod("ResolverNomeSimAtivo", BindingFlags.NonPublic | BindingFlags.Static)!;
        var nome = (string)metodo.Invoke(null, new object[] { caminhoPedidos, caminhoEstado })!;

        Assert.Equal("Morgana Wolff", nome);
    }

    [Fact]
    public void ResolverNomeSimAtivo_QuandoNaoTemEstadoValido_DeveUsarUltimoPedido()
    {
        var diretorio = CriarDiretorioTemporario();
        var caminhoPedidos = Path.Combine(diretorio, "pedidos.json");
        File.WriteAllText(caminhoPedidos, """
        {
          "pedidos": [
            { "id": "1", "tipo": "pensamento", "sim_ativo": "Bella", "contexto": "x" },
            { "id": "2", "tipo": "conto", "sim_ativo": "Cornélia", "contexto": "y" }
          ]
        }
        """);

        var metodo = TipoSimulador.GetMethod("ResolverNomeSimAtivo", BindingFlags.NonPublic | BindingFlags.Static)!;
        var nome = (string)metodo.Invoke(null, new object[] { caminhoPedidos, string.Empty })!;

        Assert.Equal("Cornélia", nome);
    }

    private static string CriarArquivoTemporarioJson(string conteudo)
    {
        var diretorio = CriarDiretorioTemporario();
        var caminho = Path.Combine(diretorio, Guid.NewGuid().ToString("N") + ".json");
        File.WriteAllText(caminho, conteudo);
        return caminho;
    }

    private static string CriarDiretorioTemporario()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        return diretorio;
    }
}
