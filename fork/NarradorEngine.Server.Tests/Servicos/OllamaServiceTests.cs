using NarradorEngine.Server.Servicos;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NarradorEngine.Server.Tests.Servicos;

public sealed class OllamaServiceTests
{
    [Fact]
    public void Construtor_QuandoUrlVazia_DeveUsarEndpointPadrao()
    {
        using var service = new OllamaService(string.Empty, 10);

        Assert.Equal("http://127.0.0.1:11434/api/generate", service.UrlEndpoint);
    }

    [Fact]
    public async Task GerarTextoAsync_DeveEnviarPayloadECapturarResponse()
    {
        var porta = ObterPortaLivre();
        var endpoint = "http://127.0.0.1:" + porta + "/api/generate";

        string corpoRecebido = string.Empty;
        using var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:" + porta + "/");
        listener.Start();

        var servidorMock = Task.Run(async () =>
        {
            var contexto = await listener.GetContextAsync();
            using var leitor = new StreamReader(contexto.Request.InputStream, Encoding.UTF8);
            corpoRecebido = await leitor.ReadToEndAsync();

            var respostaBytes = Encoding.UTF8.GetBytes("{\"response\":\"  Olá TS3  \"}");
            contexto.Response.ContentType = "application/json";
            contexto.Response.ContentLength64 = respostaBytes.Length;
            await contexto.Response.OutputStream.WriteAsync(respostaBytes, 0, respostaBytes.Length);
            contexto.Response.Close();
        });

        using var service = new OllamaService(endpoint, 10);
        var texto = await service.GerarTextoAsync("deepseek-r1", "contexto de teste", CancellationToken.None);
        await servidorMock;

        var payload = JsonDocument.Parse(corpoRecebido);
        Assert.Equal("deepseek-r1", payload.RootElement.GetProperty("model").GetString());
        Assert.Equal("contexto de teste", payload.RootElement.GetProperty("prompt").GetString());
        Assert.False(payload.RootElement.GetProperty("stream").GetBoolean());
        Assert.Equal("Olá TS3", texto);
    }

    [Fact]
    public async Task GerarTextoAsync_QuandoRecebeOpcoes_DeveEnviarCampoOptions()
    {
        var porta = ObterPortaLivre();
        var endpoint = "http://127.0.0.1:" + porta + "/api/generate";

        string corpoRecebido = string.Empty;
        using var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:" + porta + "/");
        listener.Start();

        var servidorMock = Task.Run(async () =>
        {
            var contexto = await listener.GetContextAsync();
            using var leitor = new StreamReader(contexto.Request.InputStream, Encoding.UTF8);
            corpoRecebido = await leitor.ReadToEndAsync();

            var respostaBytes = Encoding.UTF8.GetBytes("{\"response\":\"ok\"}");
            contexto.Response.ContentType = "application/json";
            contexto.Response.ContentLength64 = respostaBytes.Length;
            await contexto.Response.OutputStream.WriteAsync(respostaBytes, 0, respostaBytes.Length);
            contexto.Response.Close();
        });

        using var service = new OllamaService(endpoint, 10);
        var opcoes = new Dictionary<string, object>
        {
            ["temperature"] = 0.4d,
            ["top_p"] = 0.85d
        };

        _ = await service.GerarTextoAsync("deepseek-r1", "contexto de teste", opcoes, CancellationToken.None);
        await servidorMock;

        var payload = JsonDocument.Parse(corpoRecebido);
        Assert.Equal(0.4d, payload.RootElement.GetProperty("options").GetProperty("temperature").GetDouble());
        Assert.Equal(0.85d, payload.RootElement.GetProperty("options").GetProperty("top_p").GetDouble());
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
