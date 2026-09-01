using NarradorEngine.Server.Processamento;
using NarradorEngine.Server.Servicos;
using System.Text;
using System.Text.Json;

namespace NarradorEngine.Server.Tests.Processamento;

public sealed class ProcessadorPerfilNarrativoUsuarioTests
{
    [Fact]
  public async Task GarantirDiretrizAtualizadaAsync_QuandoHaDiretrizConfigurada_DeveIncluirNoPromptDePerfil()
    {
        var configuracao = CriarConfiguracao(
            """
            {
              "arquivo": {
                "perfil_usuario": "perfil.usuario.json"
              },
              "perfil_usuario": {
                "faixa_etaria": "Adulto",
                "personalidades_narrador": ["Dramatico"],
                "estilos_criativos": ["Comico"],
                "conteudos_permitidos": ["Romance"],
                "conteudos_bloqueados": ["Violencia"],
                "diretriz": "\"Tom direto e seco.\""
              }
            }
            """);

        using var ollama = new OllamaService("http://127.0.0.1:9/api/generate", 5);
        var processador = new ProcessadorPerfilNarrativoUsuario(configuracao, ollama);

        await processador.GarantirDiretrizAtualizadaAsync(CancellationToken.None);

    Assert.False(string.IsNullOrWhiteSpace(configuracao.DiretrizNarrativaPerfil));

        using var documento = JsonDocument.Parse(File.ReadAllText(configuracao.CaminhoPerfilUsuario));
    Assert.Contains("Tom direto e seco.", documento.RootElement.GetProperty("prompt_perfil").GetString());
    Assert.Equal(configuracao.DiretrizNarrativaPerfil, documento.RootElement.GetProperty("diretriz_narrativa").GetString());
    }

    [Fact]
    public async Task GarantirDiretrizAtualizadaAsync_QuandoOllamaFalha_DeveSalvarFallbackLocal()
    {
        var configuracao = CriarConfiguracao(
            """
            {
              "arquivo": {
                "perfil_usuario": "perfil.usuario.json"
              },
              "ollama": {
                "url": "http://127.0.0.1:9/api/generate",
                "modelo": "modelo-principal",
                "modelo_perfil": "modelo-perfil"
              },
              "perfil_usuario": {
                "faixa_etaria": "Adulto",
                "personalidades_narrador": ["Dramatico"],
                "estilos_criativos": ["Comico"],
                "conteudos_permitidos": [],
                "conteudos_bloqueados": ["Violencia"]
              }
            }
            """);

        using var ollama = new OllamaService(configuracao.UrlOllama, configuracao.TimeoutSegundos);
        var processador = new ProcessadorPerfilNarrativoUsuario(configuracao, ollama);

        await processador.GarantirDiretrizAtualizadaAsync(CancellationToken.None);

        Assert.False(string.IsNullOrWhiteSpace(configuracao.DiretrizNarrativaPerfil));

        using var documento = JsonDocument.Parse(File.ReadAllText(configuracao.CaminhoPerfilUsuario));
        Assert.Equal(configuracao.DiretrizNarrativaPerfil, documento.RootElement.GetProperty("diretriz_narrativa").GetString());
        Assert.False(string.IsNullOrWhiteSpace(documento.RootElement.GetProperty("prompt_perfil").GetString()));
    }

    private static ConfiguracaoServidor CriarConfiguracao(string json)
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);
        var arquivo = Path.Combine(diretorio, "config.json");
        File.WriteAllText(arquivo, json, Encoding.UTF8);
        return ConfiguracaoServidor.Carregar(arquivo);
    }
}