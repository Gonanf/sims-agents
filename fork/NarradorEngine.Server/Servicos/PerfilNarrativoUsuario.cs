using System.Text.Json.Serialization;

namespace NarradorEngine.Server.Servicos;

public enum PersonalidadeNarrador
{
    ObservadorIronico,
    MaternalAcolhedor,
    ProfessorSabio,
    CaoticoDivertido,
    DistanteClinico,
    Cumplice,
    Invisivel,
    Dramatico,
    Ranzinza,
    Sonhador,
    Cinico,
    Otimista,
    Pessimista,
    Humilde,
    OniscienteModesto
}

public enum EstiloCriativoNarrativo
{
    DramaSocial,
    Comico,
    Romantico,
    Melancolico,
    Satirico,
    Poetico,
    Sensivel,
    Leve,
    Epico
}

public enum ConteudoNarrativo
{
    Palavroes,
    Sexo,
    Violencia,
    DrogasAlcool,
    TemasSensiveis
}

public sealed class PerfilNarrativoEscolhas
{
    public string FaixaEtaria { get; private set; } = "Adulto";
    public IReadOnlyList<PersonalidadeNarrador> PersonalidadesNarrador { get; private set; } = Array.Empty<PersonalidadeNarrador>();
    public IReadOnlyList<EstiloCriativoNarrativo> EstilosCriativos { get; private set; } = Array.Empty<EstiloCriativoNarrativo>();
    public IReadOnlyList<ConteudoNarrativo> ConteudosPermitidos { get; private set; } = Array.Empty<ConteudoNarrativo>();
    public IReadOnlyList<ConteudoNarrativo> ConteudosBloqueados { get; private set; } = Array.Empty<ConteudoNarrativo>();

    public static PerfilNarrativoEscolhas CriarPadrao()
    {
        return Criar(
            "Adulto",
            [PersonalidadeNarrador.Dramatico],
            [EstiloCriativoNarrativo.DramaSocial],
            [ConteudoNarrativo.Palavroes],
            [ConteudoNarrativo.Sexo, ConteudoNarrativo.Violencia]);
    }

    public static PerfilNarrativoEscolhas Criar(
        string faixaEtaria,
        IReadOnlyList<PersonalidadeNarrador> personalidadesNarrador,
        IReadOnlyList<EstiloCriativoNarrativo> estilosCriativos,
        IReadOnlyList<ConteudoNarrativo> conteudosPermitidos,
        IReadOnlyList<ConteudoNarrativo> conteudosBloqueados)
    {
        return new PerfilNarrativoEscolhas
        {
            FaixaEtaria = string.IsNullOrWhiteSpace(faixaEtaria) ? "Adulto" : AdaptadorTextoServidor.ApararOuVazio(faixaEtaria),
            PersonalidadesNarrador = personalidadesNarrador?.Count > 0 ? personalidadesNarrador : [PersonalidadeNarrador.Dramatico],
            EstilosCriativos = estilosCriativos?.Count > 0 ? estilosCriativos : [EstiloCriativoNarrativo.DramaSocial],
            ConteudosPermitidos = conteudosPermitidos ?? Array.Empty<ConteudoNarrativo>(),
            ConteudosBloqueados = conteudosBloqueados ?? Array.Empty<ConteudoNarrativo>()
        };
    }
}

public sealed class PerfilNarrativoUsuarioJsonContrato
{
    [JsonPropertyName("versao_contrato")]
    public string VersaoContrato { get; set; } = "1.0";

    [JsonPropertyName("gerado_em")]
    public string GeradoEm { get; set; } = string.Empty;

    [JsonPropertyName("prompt_perfil")]
    public string PromptPerfil { get; set; } = string.Empty;

    [JsonPropertyName("diretriz_narrativa")]
    public string DiretrizNarrativa { get; set; } = string.Empty;

    [JsonPropertyName("perfil_usuario")]
    public PerfilNarrativoUsuarioDadosJsonContrato PerfilUsuario { get; set; } = new();
}

public sealed class PerfilNarrativoUsuarioDadosJsonContrato
{
    [JsonPropertyName("faixa_etaria")]
    public string FaixaEtaria { get; set; } = "Adulto";

    [JsonPropertyName("personalidades_narrador")]
    public List<string> PersonalidadesNarrador { get; set; } = new();

    [JsonPropertyName("estilos_criativos")]
    public List<string> EstilosCriativos { get; set; } = new();

    [JsonPropertyName("conteudos_permitidos")]
    public List<string> ConteudosPermitidos { get; set; } = new();

    [JsonPropertyName("conteudos_bloqueados")]
    public List<string> ConteudosBloqueados { get; set; } = new();
}

public static class ConversorPerfilNarrativo
{
    public static IReadOnlyList<TEnum> ConverterListaEnums<TEnum>(IReadOnlyList<string> valores, params TEnum[] valoresPadrao)
        where TEnum : struct, Enum
    {
        if (valores == null || valores.Count == 0)
        {
            return valoresPadrao is { Length: > 0 } ? valoresPadrao : Array.Empty<TEnum>();
        }

        var itens = new List<TEnum>();
        foreach (var valor in valores)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                continue;
            }

            if (TentarConverter(valor, out TEnum convertido) && !itens.Contains(convertido))
            {
                itens.Add(convertido);
            }
        }

        if (itens.Count > 0)
        {
            return itens;
        }

        return valoresPadrao is { Length: > 0 } ? valoresPadrao : Array.Empty<TEnum>();
    }

    private static bool TentarConverter<TEnum>(string valor, out TEnum convertido)
        where TEnum : struct, Enum
    {
        if (Enum.TryParse(valor, true, out convertido))
        {
            return true;
        }

        var normalizado = Normalizar(valor);
        var opcoes = Enum.GetNames(typeof(TEnum));
        foreach (var opcao in opcoes)
        {
            if (string.Equals(Normalizar(opcao), normalizado, StringComparison.OrdinalIgnoreCase)
                && Enum.TryParse(opcao, out convertido))
            {
                return true;
            }
        }

        convertido = default;
        return false;
    }

    private static string Normalizar(string valor)
    {
        return AdaptadorTextoServidor.NormalizarIdentificador(valor);
    }
}
