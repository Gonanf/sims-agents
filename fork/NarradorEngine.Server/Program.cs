using NarradorEngine.Server.Processamento;
using NarradorEngine.Server.Servicos;

namespace NarradorEngine.Server;

internal static class Program
{
    private const string ArgumentoServidor = "--server";
    private const string ArgumentoSimulacao = "--simulate";
    private const string ArgumentoConfig = "--config=";

    public static async Task<int> Main(string[] args)
    {
        var configuracao = ConfiguracaoServidor.Carregar(ResolverCaminhoConfig(args));
        var servicoOllama = new OllamaService(configuracao.UrlOllama, configuracao.TimeoutSegundos);
        var processadorPerfil = new ProcessadorPerfilNarrativoUsuario(configuracao, servicoOllama);
        await processadorPerfil.InicializarDiretrizAsync(CancellationToken.None);
        var processador = new ProcessadorPedidosNarrativos(configuracao, servicoOllama);

        if (args.Any(a => string.Equals(a, ArgumentoSimulacao, StringComparison.OrdinalIgnoreCase)))
        {
            await SimuladorServidor.ExecutarAsync(configuracao, processador);
            return 0;
        }

        if (args.Any(a => string.Equals(a, ArgumentoServidor, StringComparison.OrdinalIgnoreCase)))
        {
            await LoopServidor.ExecutarAsync(configuracao, processadorPerfil, processador);
            return 0;
        }

        Console.WriteLine("Use --server para iniciar o processamento contínuo ou --simulate para teste rápido.");
        return 1;
    }

    private static string ResolverCaminhoConfig(string[] args)
    {
        var argumentoConfig = args.FirstOrDefault(a => a.StartsWith(ArgumentoConfig, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(argumentoConfig))
        {
            return argumentoConfig.Substring(ArgumentoConfig.Length).Trim('"');
        }

        var local = Path.Combine(AppContext.BaseDirectory, ConfiguracaoServidor.NomeArquivoConfigPadrao);
        if (File.Exists(local))
        {
            return local;
        }

        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ConfiguracaoServidor.NomeArquivoConfigPadrao));
    }
}
