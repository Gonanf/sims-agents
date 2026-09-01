using NarradorEngine.Server.Servicos;
using System.Text;

namespace NarradorEngine.Server.Tests.Infra;

public sealed class ConfiguracaoServidorTests
{
    [Fact]
    public void Carregar_QuandoArquivoNaoExiste_DeveUsarPadrao()
    {
        var caminhoInvalido = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");

        var config = ConfiguracaoServidor.Carregar(caminhoInvalido);

        Assert.Contains("NarradorPorEventos.pedidos.json", config.CaminhoPedidos);
        Assert.Contains("NarradorPorEventos.respostas.json", config.CaminhoRespostas);
        Assert.Equal(45, config.TimeoutSegundos);
        Assert.Equal(1500, config.IntervaloPollMs);
    }

    [Fact]
    public void Carregar_QuandoValoresMenoresQueMinimo_DeveAplicarClamp()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        var arquivo = Path.Combine(diretorio, "config.json");

        var json = """
        {
          "arquivo": {
            "pedidos": "pedidos.custom.json",
            "respostas": "respostas.custom.json"
          },
          "ollama": {
            "url": "http://127.0.0.1:11434/api/generate",
            "modelo": "deepseek-r1",
            "timeout_segundos": "1"
          },
          "servidor": {
            "intervalo_poll_ms": "10"
          }
        }
        """;

        File.WriteAllText(arquivo, json, Encoding.UTF8);

        var config = ConfiguracaoServidor.Carregar(arquivo);

        Assert.Contains("pedidos.custom.json", config.CaminhoPedidos);
        Assert.Contains("respostas.custom.json", config.CaminhoRespostas);
        Assert.Equal("deepseek-r1", config.ModeloOllama);
        Assert.Equal(5, config.TimeoutSegundos);
        Assert.Equal(250, config.IntervaloPollMs);
    }

    [Fact]
    public void Carregar_QuandoConfigContemDiretrizPerfilEOpcoesOllama_DeveMapearCamposRuntime()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        var arquivo = Path.Combine(diretorio, "config.json");

        var json = """
        {
          "arquivo": {
            "contexto_previo": "previo.custom.json"
          },
          "feature": {
            "incluir_contexto_previo": false
          },
          "servidor": {
            "logar_hotreload": false
          },
          "perfil_usuario": {
            "faixa_etaria": "Adulto",
            "personalidades_narrador": ["Dramatico"],
            "estilos_criativos": ["Comico"],
            "conteudos_permitidos": [],
            "conteudos_bloqueados": ["Violencia"],
            "diretriz": "Tom manual."
          },
          "ollama": {
            "modelo": "deepseek-r1",
            "modelo_perfil": "qwen2.5:14b",
            "opcoes": {
              "temperature": 0.55,
              "top_p": 0.91
            }
          },
          "prompt": {
            "variaveis": {
              "tom_pensamento": "Mais seco."
            },
            "contexto": {
              "template": ["Linha A", "Linha B"]
            }
          }
        }
        """;

        File.WriteAllText(arquivo, json, Encoding.UTF8);

        var config = ConfiguracaoServidor.Carregar(arquivo);

        Assert.False(config.IncluirContextoPrevio);
        Assert.False(config.LogarHotReload);
        Assert.Equal("Tom manual.", config.DiretrizPerfilUsuario);
        Assert.Equal("qwen2.5:14b", config.ModeloOllamaPerfil);
        Assert.Equal("previo.custom.json", Path.GetFileName(config.CaminhoContextoPrevio));
        Assert.Equal("Mais seco.", config.ObterVariavelPrompt("tom_pensamento"));
        Assert.Equal("Linha A" + Environment.NewLine + "Linha B", config.TemplateBlocoContextual);
        Assert.Equal(0.55d, Convert.ToDouble(config.OllamaOpcoes["temperature"]));
        Assert.Equal(0.91d, Convert.ToDouble(config.OllamaOpcoes["top_p"]));
    }

    [Fact]
    public void RecarregarSeNecessario_QuandoArquivoMuda_DeveAtualizarCamposRuntime()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        var arquivo = Path.Combine(diretorio, "config.json");

        File.WriteAllText(arquivo, """
        {
          "ollama": {
            "modelo": "modelo-antigo"
          },
          "perfil_usuario": {
            "diretriz": "Tom antigo"
          },
          "servidor": {
            "intervalo_poll_ms": 500
          }
        }
        """, Encoding.UTF8);

        var config = ConfiguracaoServidor.Carregar(arquivo);

        File.WriteAllText(arquivo, """
        {
          "ollama": {
            "modelo": "modelo-novo"
          },
          "perfil_usuario": {
            "diretriz": "Tom novo"
          },
          "servidor": {
            "intervalo_poll_ms": 900
          }
        }
        """, Encoding.UTF8);
        File.SetLastWriteTimeUtc(arquivo, DateTime.UtcNow.AddSeconds(2));

        var alterou = config.RecarregarSeNecessario();

        Assert.True(alterou);
        Assert.Equal("modelo-novo", config.ModeloOllama);
    Assert.Equal("Tom novo", config.DiretrizPerfilUsuario);
        Assert.Equal(900, config.IntervaloPollMs);
        Assert.Equal(2, config.VersaoRuntime);
    }
}
