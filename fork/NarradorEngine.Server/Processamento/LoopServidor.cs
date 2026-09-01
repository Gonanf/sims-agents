using NarradorEngine.Server.Servicos;

namespace NarradorEngine.Server.Processamento;

internal static class LoopServidor
{
    public static async Task ExecutarAsync(ConfiguracaoServidor configuracao, ProcessadorPerfilNarrativoUsuario processadorPerfil, ProcessadorPedidosNarrativos processador)
    {
        Console.WriteLine("NarradorEngine.Server em execução. Pressione Ctrl+C para encerrar.");
        Console.WriteLine($"Config: {configuracao.CaminhoConfigOrigem}");
        Console.WriteLine($"Pedidos: {configuracao.CaminhoPedidos}");
        Console.WriteLine($"Respostas: {configuracao.CaminhoRespostas}");

        using var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_, eventArgs) =>
        {
            eventArgs.Cancel = true;
            cts.Cancel();
        };

        while (!cts.IsCancellationRequested)
        {
            try
            {
                if (configuracao.RecarregarSeNecessario() && configuracao.LogarHotReload)
                {
                    Console.WriteLine($"{DateTime.Now:HH:mm:ss} - configuração recarregada: {configuracao.CriarResumoHotReload()}");
                }

                await processadorPerfil.GarantirDiretrizAtualizadaAsync(cts.Token);
                var processados = await processador.ProcessarUmaVezAsync(cts.Token);
                if (processados > 0)
                {
                    Console.WriteLine($"{DateTime.Now:HH:mm:ss} - pedidos processados: {processados}");
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha no ciclo do servidor: {ex.Message}");
            }

            await Task.Delay(configuracao.IntervaloPollMs, cts.Token);
        }
    }
}
