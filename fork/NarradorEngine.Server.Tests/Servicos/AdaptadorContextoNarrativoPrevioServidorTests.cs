using NarradorEngine.Server.Servicos;

namespace NarradorEngine.Server.Tests.Servicos;

public sealed class AdaptadorContextoNarrativoPrevioServidorTests
{
    [Fact]
    public void Ler_QuandoArquivoNaoExiste_DeveRetornarContextoVazio()
    {
        var caminho = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".json");

        var contexto = AdaptadorContextoNarrativoPrevioServidor.Ler(caminho);

        Assert.Equal(string.Empty, contexto.PensamentoAnterior);
        Assert.Equal(string.Empty, contexto.ContoAnterior);
    }

    [Fact]
    public void Ler_QuandoJsonInvalido_DeveRetornarContextoVazio()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        var arquivo = Path.Combine(diretorio, "contexto.json");
        File.WriteAllText(arquivo, "{invalido}");

        var contexto = AdaptadorContextoNarrativoPrevioServidor.Ler(arquivo);

        Assert.Equal(string.Empty, contexto.PensamentoAnterior);
        Assert.Equal(string.Empty, contexto.ContoAnterior);
    }

    [Fact]
    public void Ler_QuandoJsonValido_DeveMapearCamposNarrativos()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        var arquivo = Path.Combine(diretorio, "contexto.json");
        File.WriteAllText(arquivo, """
        {
          "pensamento_anterior": "bairro quieto",
          "conto_anterior": "fofoca longa"
        }
        """);

        var contexto = AdaptadorContextoNarrativoPrevioServidor.Ler(arquivo);

        Assert.Equal("bairro quieto", contexto.PensamentoAnterior);
        Assert.Equal("fofoca longa", contexto.ContoAnterior);
    }
}