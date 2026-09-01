using NarradorEngine.Server.Servicos;
using System.Text.Json;

namespace NarradorEngine.Server.Processamento;

/// <summary>
/// Mantem atualizada a diretriz narrativa derivada do perfil do usuario.
/// </summary>
/// <remarks>
/// <para>A ordem de prioridade eh simples: resposta do Ollama -&gt; fallback local.</para>
/// <para>Quando o arquivo de configuracao muda, o servidor refaz o prompt de perfil no proximo poll e recalibra a diretriz ativa.</para>
/// <example>
/// <code>
/// var processador = new ProcessadorPerfilNarrativoUsuario(configuracao, ollama);
/// await processador.GarantirDiretrizAtualizadaAsync(ct);
/// </code>
/// </example>
/// </remarks>
internal sealed class ProcessadorPerfilNarrativoUsuario
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    private readonly ConfiguracaoServidor _configuracao;
    private readonly OllamaService _ollama;
    private long _ultimaVersaoAplicada;

    public ProcessadorPerfilNarrativoUsuario(ConfiguracaoServidor configuracao, OllamaService ollama)
    {
        _configuracao = configuracao;
        _ollama = ollama;
        _ultimaVersaoAplicada = 0;
    }

    /// <summary>
    /// Inicializa a diretriz narrativa no boot do servidor reutilizando a mesma rotina de atualizacao incremental.
    /// </summary>
    public async Task InicializarDiretrizAsync(CancellationToken cancellationToken)
    {
        await GarantirDiretrizAtualizadaAsync(cancellationToken);
    }

    /// <summary>
    /// Garante que a diretriz ativa reflita o estado atual da configuracao e do perfil do usuario.
    /// </summary>
    public async Task GarantirDiretrizAtualizadaAsync(CancellationToken cancellationToken)
    {
        if (_configuracao.VersaoRuntime == _ultimaVersaoAplicada
            && !string.IsNullOrWhiteSpace(_configuracao.DiretrizNarrativaPerfil))
        {
            return;
        }

        string promptPerfil = PromptsNarrativos.CriarPromptPerfilNarrador(_configuracao);
        string diretriz = string.Empty;

        try
        {
            _ollama.AtualizarConexao(_configuracao.UrlOllama, _configuracao.TimeoutSegundos);
            string resposta = await _ollama.GerarTextoAsync(_configuracao.ModeloOllamaPerfilAtivo, promptPerfil, _configuracao.OllamaOpcoes, cancellationToken);
            diretriz = AdaptadorTextoServidor.CompactarParaLinhaUnica(resposta, removerAspasExternas: true);
        }
        catch
        {
            diretriz = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(diretriz))
        {
            diretriz = AdaptadorTextoServidor.CompactarParaLinhaUnica(
                PromptsNarrativos.CriarDiretrizFallbackPerfilNarrador(_configuracao),
                removerAspasExternas: true);
        }

        _configuracao.DefinirDiretrizNarrativaPerfil(diretriz);
        SalvarArquivoPerfil(promptPerfil, diretriz);
        _ultimaVersaoAplicada = _configuracao.VersaoRuntime;

        if (_configuracao.LogarHotReload)
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} - perfil narrativo atualizado: arquivo={_configuracao.CaminhoPerfilUsuario}");
    }

    private void SalvarArquivoPerfil(string promptPerfil, string diretriz)
    {
        var diretorio = Path.GetDirectoryName(_configuracao.CaminhoPerfilUsuario);
        if (!string.IsNullOrWhiteSpace(diretorio))
        {
            Directory.CreateDirectory(diretorio);
        }

        var perfil = _configuracao.PerfilNarrativo;
        var envelope = new PerfilNarrativoUsuarioJsonContrato
        {
            GeradoEm = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            PromptPerfil = promptPerfil,
            DiretrizNarrativa = diretriz,
            PerfilUsuario = new PerfilNarrativoUsuarioDadosJsonContrato
            {
                FaixaEtaria = perfil.FaixaEtaria,
                PersonalidadesNarrador = perfil.PersonalidadesNarrador.Select(p => p.ToString()).ToList(),
                EstilosCriativos = perfil.EstilosCriativos.Select(p => p.ToString()).ToList(),
                ConteudosPermitidos = perfil.ConteudosPermitidos.Select(p => p.ToString()).ToList(),
                ConteudosBloqueados = perfil.ConteudosBloqueados.Select(p => p.ToString()).ToList()
            }
        };

        File.WriteAllText(_configuracao.CaminhoPerfilUsuario, JsonSerializer.Serialize(envelope, JsonOptions));
    }
}
