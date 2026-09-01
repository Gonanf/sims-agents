using NarradorEngine.Server.Contratos;
using System.Reflection;

namespace NarradorEngine.Server.Tests.Processamento;

public sealed class ProcessadorPedidosNarrativosTests
{
    private static readonly Type TipoProcessador = Type.GetType("NarradorEngine.Server.Processamento.ProcessadorPedidosNarrativos, NarradorEngine.Server", throwOnError: true)!;

    [Fact]
    public void SanitizarResposta_DeveLimparQuebrasEAspas()
    {
        var metodo = TipoProcessador.GetMethod("SanitizarResposta", BindingFlags.NonPublic | BindingFlags.Static)!;

        var bruto = "  \"Oi\r\n  bairro\t\"  ";
        var texto = (string)metodo.Invoke(null, new object[] { bruto })!;

        Assert.DoesNotContain("\r", texto);
        Assert.DoesNotContain("\n", texto);
        Assert.DoesNotContain("\t", texto);
        Assert.DoesNotContain("\"", texto);
        Assert.Equal("Oi bairro", texto.Trim());
    }

    [Fact]
    public void PedidoValido_QuandoTemCamposObrigatorios_DeveRetornarTrue()
    {
        var metodo = TipoProcessador.GetMethod("PedidoValido", BindingFlags.NonPublic | BindingFlags.Static)!;
        var pedido = new PedidoNarrativoJsonContrato
        {
            Id = "abc",
            Tipo = "pensamento",
            Contexto = "humor=alto"
        };

        var valido = (bool)metodo.Invoke(null, new object[] { pedido })!;

        Assert.True(valido);
    }
}
