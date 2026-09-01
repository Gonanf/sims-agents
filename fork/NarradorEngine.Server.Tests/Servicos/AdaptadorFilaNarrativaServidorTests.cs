using NarradorEngine.Server.Contratos;
using NarradorEngine.Server.Servicos;

namespace NarradorEngine.Server.Tests.Servicos;

public sealed class AdaptadorFilaNarrativaServidorTests
{
    [Fact]
    public void LerPedidos_QuandoArquivoNaoExiste_DeveRetornarEnvelopeVazio()
    {
        var caminho = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".json");

        var envelope = AdaptadorFilaNarrativaServidor.LerPedidos(caminho);

        Assert.Empty(envelope.Pedidos);
    }

    [Fact]
    public void SalvarRespostasEPurgarPedidos_QuandoExecutados_DevePersistirEnvelopesEsperados()
    {
        var diretorio = Path.Combine(Path.GetTempPath(), "narrador-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorio);

        var caminhoPedidos = Path.Combine(diretorio, "pedidos.json");
        var caminhoRespostas = Path.Combine(diretorio, "respostas.json");

        File.WriteAllText(caminhoPedidos, """
        {
          "versao_contrato": "1.0",
          "pedidos": [
            {
              "id": "p1",
              "tipo": "pensamento",
              "sim_ativo": "Bella",
              "horario_real": "2026-01-01 10:00:00",
              "contexto": "humor=alto"
            }
          ]
        }
        """);

        AdaptadorFilaNarrativaServidor.SalvarRespostas(caminhoRespostas, new EnvelopeRespostasJsonContrato
        {
            Respostas =
            {
                new RespostaNarrativaJsonContrato
                {
                    Id = "r1",
                    Tipo = "conto",
                    SimAtivo = "Bella",
                    HorarioReal = "2026-01-01 10:05:00",
                    Prompt = "prompt",
                    Resposta = "resposta"
                }
            }
        });

        AdaptadorFilaNarrativaServidor.PurgarPedidos(caminhoPedidos);

        var pedidos = AdaptadorFilaNarrativaServidor.LerPedidos(caminhoPedidos);
        var respostas = AdaptadorFilaNarrativaServidor.LerRespostas(caminhoRespostas);

        Assert.Empty(pedidos.Pedidos);
        Assert.Single(respostas.Respostas);
        Assert.Equal("resposta", respostas.Respostas[0].Resposta);
    }
}