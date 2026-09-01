using System.Text;
using System.Text.Json;

namespace NarradorEngine.Server.Servicos;

public sealed class OllamaService : IDisposable
{
    private HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public OllamaService(string urlBase, int timeoutSegundos)
    {
        AtualizarConexao(urlBase, timeoutSegundos);
    }

    public string UrlEndpoint { get; private set; } = string.Empty;

    public int TimeoutSegundos { get; private set; }

    public void AtualizarConexao(string urlBase, int timeoutSegundos)
    {
        var endpointNormalizado = NormalizarEndpoint(urlBase);
        var timeoutNormalizado = timeoutSegundos < 5 ? 5 : timeoutSegundos;
        if (_httpClient != null
            && string.Equals(UrlEndpoint, endpointNormalizado, StringComparison.OrdinalIgnoreCase)
            && TimeoutSegundos == timeoutNormalizado)
        {
            return;
        }

        _httpClient?.Dispose();

        var handler = new HttpClientHandler { UseProxy = false };
        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(timeoutNormalizado)
        };

        UrlEndpoint = endpointNormalizado;
        TimeoutSegundos = timeoutNormalizado;
    }

    public async Task<string> GerarTextoAsync(string modelo, string prompt, CancellationToken cancellationToken)
    {
        return await GerarTextoAsync(modelo, prompt, null, cancellationToken);
    }

    public async Task<string> GerarTextoAsync(string modelo, string prompt, IReadOnlyDictionary<string, object> opcoes, CancellationToken cancellationToken)
    {
        var carga = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
        {
            ["model"] = string.IsNullOrWhiteSpace(modelo) ? "deepseek-r1:7b" : modelo,
            ["prompt"] = prompt ?? string.Empty,
            ["stream"] = false
        };

        if (opcoes != null && opcoes.Count > 0)
        {
            carga["options"] = opcoes;
        }

        using var conteudo = new StringContent(JsonSerializer.Serialize(carga), Encoding.UTF8, "application/json");
        using var resposta = await _httpClient.PostAsync(UrlEndpoint, conteudo, cancellationToken);
        resposta.EnsureSuccessStatusCode();

        var json = await resposta.Content.ReadAsStringAsync(cancellationToken);
        var envelope = JsonSerializer.Deserialize<EnvelopeOllama>(json, _jsonOptions);
        return envelope?.Response?.Trim() ?? string.Empty;
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }

    private static string NormalizarEndpoint(string urlBase)
    {
        if (string.IsNullOrWhiteSpace(urlBase))
        {
            return "http://127.0.0.1:11434/api/generate";
        }

        return urlBase.Replace("localhost", "127.0.0.1");
    }

    private sealed class EnvelopeOllama
    {
        public string Response { get; set; } = string.Empty;
    }
}
