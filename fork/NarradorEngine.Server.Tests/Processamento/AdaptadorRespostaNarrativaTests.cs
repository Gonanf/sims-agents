using NarradorEngine.Server.Processamento;

namespace NarradorEngine.Server.Tests.Processamento;

public sealed class AdaptadorRespostaNarrativaTests
{
    [Fact]
    public void Sanitizar_QuandoTextoTemAspasQuebrasEArtefatos_DeveCompactarSaida()
    {
        var texto = AdaptadorRespostaNarrativa.Sanitizar("  \"Oi\r\n bairro\"_  ");

        Assert.Equal("Oi bairro", texto);
    }
}