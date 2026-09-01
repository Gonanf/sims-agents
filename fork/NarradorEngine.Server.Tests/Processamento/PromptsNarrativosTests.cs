using NarradorEngine.Server.Contratos;
using NarradorEngine.Server.Servicos;
using System.Reflection;

namespace NarradorEngine.Server.Tests.Processamento;

public sealed class PromptsNarrativosTests
{
    private static readonly MethodInfo MetodoCriarPrompt = ObterMetodoCriarPrompt();

    [Fact]
    public void CriarPrompt_QuandoTipoPensamento_DeveConterAssinaturaDePensamento()
    {
        var pedido = new PedidoNarrativoJsonContrato
        {
            Id = "1",
            Tipo = "pensamento",
            SimAtivo = "Helen Caixão",
            Contexto = "identidade=..."
        };
        var configuracao = new ConfiguracaoServidor();

        var texto = (string)MetodoCriarPrompt.Invoke(null, new object[] { pedido, configuracao });

        Assert.Contains("Pensamento de Helen Caixão:", texto);
        Assert.Contains("Uma única frase", texto);
    }

    [Fact]
    public void CriarPrompt_QuandoTipoConto_DeveConterAssinaturaDeNarrativa()
    {
        var pedido = new PedidoNarrativoJsonContrato
        {
            Id = "2",
            Tipo = "conto",
            SimAtivo = "Helen Caixão",
            Contexto = "identidade=..."
        };
        var configuracao = new ConfiguracaoServidor();

        var texto = (string)MetodoCriarPrompt.Invoke(null, new object[] { pedido, configuracao });

        Assert.Contains("Narrativa:", texto);
        Assert.Contains("Escreva de 3 a 5 frases", texto);
    }

        [Fact]
        public void CriarPrompt_QuandoTemplateConfiguravelDePensamento_DeveInterpolarVariaveisDoJson()
        {
                var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(diretorio);
                var arquivo = Path.Combine(diretorio, "config.json");

                File.WriteAllText(arquivo, """
                {
                    "prompt": {
                        "variaveis": {
                            "tom_pensamento": "modo-debug"
                        },
                        "contexto": {
                            "template": ["CTX={contexto}"]
                        },
                        "pensamento": {
                            "template": ["Tom={tom_pensamento}", "{bloco_contextual}", "Pensamento de {sim_ativo}:"]
                        }
                    }
                }
                """, System.Text.Encoding.UTF8);

                var pedido = new PedidoNarrativoJsonContrato
                {
                        Id = "3",
                        Tipo = "pensamento",
                        SimAtivo = "Bella",
                        Contexto = "identidade=..."
                };

                var configuracao = ConfiguracaoServidor.Carregar(arquivo);
                configuracao.DefinirDiretrizNarrativaPerfil("leve e observadora");

                var texto = (string)MetodoCriarPrompt.Invoke(null, new object[] { pedido, configuracao });

                Assert.Contains("Tom=modo-debug", texto);
                Assert.Contains("CTX=identidade=...", texto);
                Assert.Contains("Pensamento de Bella:", texto);
        }

    private static MethodInfo ObterMetodoCriarPrompt()
    {
        var tipo = Type.GetType("NarradorEngine.Server.Processamento.PromptsNarrativos, NarradorEngine.Server", throwOnError: true);
        return tipo.GetMethod(
            "CriarPrompt",
            BindingFlags.Public | BindingFlags.Static,
            null,
            new[] { typeof(PedidoNarrativoJsonContrato), typeof(ConfiguracaoServidor) },
            null)!;
    }
}
