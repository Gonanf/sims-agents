using NarradorEngine.Server.Processamento;
using NarradorEngine.Server.Servicos;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NarradorEngine.Server.Tests.Processamento;

public sealed class ProcessadorPedidosNarrativosIntegracaoTests
{
    [Fact]
    public async Task ProcessarUmaVezAsync_DeveGerarRespostaEPurgarPedidos()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);

        var caminhoPedidos = Path.Combine(diretorio, "pedidos.json");
        var caminhoRespostas = Path.Combine(diretorio, "respostas.json");
        var caminhoConfig = Path.Combine(diretorio, "config.json");

        File.WriteAllText(caminhoPedidos, """
        {
          "versao_contrato": "1.0",
          "pedidos": [
            {
              "id": "p1",
              "tipo": "pensamento",
              "sim_ativo": "Helen",
              "horario_real": "2026-01-01 10:00:00",
              "contexto": "humor=alto"
            }
          ]
        }
        """);

        var porta = ObterPortaLivre();
        var url = "http://127.0.0.1:" + porta + "/api/generate";

        File.WriteAllText(caminhoConfig, """
        {
          "arquivo": {
            "pedidos": "__PEDIDOS__",
            "respostas": "__RESPOSTAS__"
          },
          "ollama": {
            "url": "__URL__",
            "modelo": "deepseek-r1",
            "timeout_segundos": "10"
          },
          "servidor": {
            "intervalo_poll_ms": "500"
          }
        }
        """
        .Replace("__PEDIDOS__", caminhoPedidos.Replace("\\", "\\\\"))
        .Replace("__RESPOSTAS__", caminhoRespostas.Replace("\\", "\\\\"))
        .Replace("__URL__", url));

        using var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:" + porta + "/");
        listener.Start();

        var servidorMock = Task.Run(async () =>
        {
            var contexto = await listener.GetContextAsync();
            using var resposta = contexto.Response;
            var bytes = Encoding.UTF8.GetBytes("{\"response\":\"Texto narrativo limpo\"}");
            resposta.ContentType = "application/json";
            resposta.ContentLength64 = bytes.Length;
            await resposta.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        });

        var config = ConfiguracaoServidor.Carregar(caminhoConfig);
        using var ollama = new OllamaService(config.UrlOllama, config.TimeoutSegundos);
        var processador = new ProcessadorPedidosNarrativos(config, ollama);

        var processados = await processador.ProcessarUmaVezAsync(CancellationToken.None);
        await servidorMock;

        Assert.Equal(1, processados);

        var respostasJson = JsonDocument.Parse(File.ReadAllText(caminhoRespostas));
        var respostas = respostasJson.RootElement.GetProperty("respostas");
        Assert.Equal(1, respostas.GetArrayLength());
        Assert.Equal("Texto narrativo limpo", respostas[0].GetProperty("resposta").GetString());

        var pedidosPos = JsonDocument.Parse(File.ReadAllText(caminhoPedidos));
        var pedidos = pedidosPos.RootElement.GetProperty("pedidos");
        Assert.Equal(0, pedidos.GetArrayLength());
    }

    [Fact]
    public async Task ProcessarUmaVezAsync_QuandoContextoPrevioExiste_DeveAnexarNarrativaAnteriorAoPrompt()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);

        var caminhoPedidos = Path.Combine(diretorio, "pedidos.json");
        var caminhoRespostas = Path.Combine(diretorio, "respostas.json");
        var caminhoPrevio = Path.Combine(diretorio, "contexto.previo.json");
        var caminhoConfig = Path.Combine(diretorio, "config.json");

        File.WriteAllText(caminhoPedidos, """
        {
          "versao_contrato": "1.0",
          "pedidos": [
            {
              "id": "p2",
              "tipo": "pensamento",
              "sim_ativo": "Helen",
              "horario_real": "2026-01-01 10:00:00",
              "contexto": "humor=alto"
            }
          ]
        }
        """);

        File.WriteAllText(caminhoPrevio, """
        {
          "versao_contrato": "1.0",
          "pensamento_anterior": "Helen já estava desconfiada do bairro.",
          "conto_anterior": ""
        }
        """);

        var porta = ObterPortaLivre();
        var url = "http://127.0.0.1:" + porta + "/api/generate";
        var corpoRecebido = string.Empty;

        File.WriteAllText(caminhoConfig, """
        {
          "arquivo": {
            "pedidos": "__PEDIDOS__",
            "respostas": "__RESPOSTAS__",
            "contexto_previo": "__PREVIO__"
          },
          "feature": {
            "incluir_contexto_previo": true
          },
          "ollama": {
            "url": "__URL__",
            "modelo": "deepseek-r1",
            "timeout_segundos": "10"
          }
        }
        """
        .Replace("__PEDIDOS__", caminhoPedidos.Replace("\\", "\\\\"))
        .Replace("__RESPOSTAS__", caminhoRespostas.Replace("\\", "\\\\"))
        .Replace("__PREVIO__", caminhoPrevio.Replace("\\", "\\\\"))
        .Replace("__URL__", url));

        using var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:" + porta + "/");
        listener.Start();

        var servidorMock = Task.Run(async () =>
        {
            var contexto = await listener.GetContextAsync();
            using var leitor = new StreamReader(contexto.Request.InputStream, Encoding.UTF8);
            corpoRecebido = await leitor.ReadToEndAsync();

            var bytes = Encoding.UTF8.GetBytes("{\"response\":\"Texto narrativo limpo\"}");
            contexto.Response.ContentType = "application/json";
            contexto.Response.ContentLength64 = bytes.Length;
            await contexto.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
            contexto.Response.Close();
        });

        var config = ConfiguracaoServidor.Carregar(caminhoConfig);
        using var ollama = new OllamaService(config.UrlOllama, config.TimeoutSegundos);
        var processador = new ProcessadorPedidosNarrativos(config, ollama);

        var processados = await processador.ProcessarUmaVezAsync(CancellationToken.None);
        await servidorMock;

        var payload = JsonDocument.Parse(corpoRecebido);
        var prompt = payload.RootElement.GetProperty("prompt").GetString();

        Assert.Equal(1, processados);
        Assert.Contains("pensamento_anterior=Helen já estava desconfiada do bairro.", prompt);
    }

    private static int ObterPortaLivre()
    {
        var listener = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var porta = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return porta;
    }
}
