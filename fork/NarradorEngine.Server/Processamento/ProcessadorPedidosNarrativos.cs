using NarradorEngine.Server.Aplicacao;
using NarradorEngine.Server.Contratos;
using NarradorEngine.Server.Servicos;

namespace NarradorEngine.Server.Processamento;

public sealed class ProcessadorPedidosNarrativos
{
    private readonly ConfiguracaoServidor _configuracao;
    private readonly OllamaService _ollama;
    private readonly ProcessarPedidosNarrativosCasoDeUso _casoDeUso;

    public ProcessadorPedidosNarrativos(ConfiguracaoServidor configuracao, OllamaService ollama)
    {
        _configuracao = configuracao;
        _ollama = ollama;
        _casoDeUso = new ProcessarPedidosNarrativosCasoDeUso(configuracao, ollama);
    }

    public async Task<int> ProcessarUmaVezAsync(CancellationToken cancellationToken)
    {
        ProcessarPedidosNarrativosSaidaDto saida = await _casoDeUso.ExecutarAsync(new ProcessarPedidosNarrativosEntradaDto
        {
            CancellationToken = cancellationToken
        });

        return saida.QuantidadePedidosProcessados;
    }

    private static string SanitizarResposta(string texto)
    {
        return AdaptadorRespostaNarrativa.Sanitizar(texto);
    }

    private static bool PedidoValido(PedidoNarrativoJsonContrato pedido)
    {
        return pedido != null
               && !string.IsNullOrWhiteSpace(pedido.Id)
               && !string.IsNullOrWhiteSpace(pedido.Tipo)
               && !string.IsNullOrWhiteSpace(pedido.Contexto);
    }
}
