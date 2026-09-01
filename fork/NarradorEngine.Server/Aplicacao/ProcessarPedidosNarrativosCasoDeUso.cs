using NarradorEngine.Server.Contratos;
using NarradorEngine.Server.Dominio;
using NarradorEngine.Server.Processamento;
using NarradorEngine.Server.Servicos;
using NarradorPorEventos.Dominio;

namespace NarradorEngine.Server.Aplicacao;

internal sealed class ProcessarPedidosNarrativosCasoDeUso
{
    private readonly ConfiguracaoServidor _configuracao;
    private readonly OllamaService _ollama;

    public ProcessarPedidosNarrativosCasoDeUso(ConfiguracaoServidor configuracao, OllamaService ollama)
    {
        _configuracao = configuracao;
        _ollama = ollama;
    }

    public async Task<ProcessarPedidosNarrativosSaidaDto> ExecutarAsync(ProcessarPedidosNarrativosEntradaDto entrada)
    {
        var cancellationToken = entrada?.CancellationToken ?? CancellationToken.None;
        var configuracaoDominio = ConfiguracaoServidorNarrativa.Criar(_configuracao);
        var saida = new ProcessarPedidosNarrativosSaidaDto();

        _ollama.AtualizarConexao(configuracaoDominio.Ollama.UrlEndpoint.Valor, configuracaoDominio.Ollama.TimeoutSegundos);

        var pedidosEnvelope = AdaptadorFilaNarrativaServidor.LerPedidos(configuracaoDominio.Arquivos.CaminhoPedidos.Valor);
        saida.QuantidadePedidosLidos = pedidosEnvelope.Pedidos.Count;
        if (pedidosEnvelope.Pedidos.Count == 0)
        {
            return saida;
        }

        var respostasEnvelope = AdaptadorFilaNarrativaServidor.LerRespostas(configuracaoDominio.Arquivos.CaminhoRespostas.Valor);
        var contextoPrevio = MapearContexto(AdaptadorContextoNarrativoPrevioServidor.Ler(configuracaoDominio.Arquivos.CaminhoContextoPrevio.Valor));

        foreach (var pedidoContrato in pedidosEnvelope.Pedidos)
        {
            var pedido = MapearPedido(pedidoContrato);
            if (!pedido.EhValido())
            {
                continue;
            }

            var pedidoEnriquecido = pedido.ComNarrativaAnterior(contextoPrevio, configuracaoDominio.IncluirContextoPrevio);
            var prompt = CriarPromptNarrativo(pedidoEnriquecido, configuracaoDominio);
            if (prompt == null || !prompt.EhValido())
            {
                continue;
            }

            var textoResposta = await _ollama.GerarTextoAsync(
                configuracaoDominio.Ollama.ModeloPrincipal.Valor,
                prompt.TextoFinal.Valor,
                configuracaoDominio.OllamaOpcoes,
                cancellationToken);
            if (string.IsNullOrWhiteSpace(textoResposta))
            {
                continue;
            }

            textoResposta = AdaptadorRespostaNarrativa.Sanitizar(textoResposta);

            if (string.IsNullOrWhiteSpace(textoResposta))
            {
                continue;
            }

            var resposta = RespostaNarrativa.Criar(
                pedido.Id.Valor,
                pedido.TipoNarrativa,
                pedido.SimAtivo.Valor,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                prompt,
                textoResposta);
            if (!resposta.EhValida())
            {
                continue;
            }

            respostasEnvelope.Respostas.Add(MapearRespostaContrato(resposta));
            saida.RespostasGeradas.Add(resposta);
            saida.QuantidadePedidosProcessados++;
        }

        AdaptadorFilaNarrativaServidor.SalvarRespostas(configuracaoDominio.Arquivos.CaminhoRespostas.Valor, respostasEnvelope);
        AdaptadorFilaNarrativaServidor.PurgarPedidos(configuracaoDominio.Arquivos.CaminhoPedidos.Valor);
        saida.QuantidadeRespostasGravadas = saida.RespostasGeradas.Count;
        return saida;
    }

    private PromptNarrativo CriarPromptNarrativo(PedidoNarrativo pedido, ConfiguracaoServidorNarrativa configuracaoDominio)
    {
        string diretrizPorTracos = AdaptadorTextoServidor.ApararOuVazio(DiretrizPorTracos.Obter(pedido.Contexto.Valor));
        string focoEmocional = AdaptadorTextoServidor.ApararOuVazio(ModificadoresDeTomNarrativo.ObterFocoEmocional(pedido.Contexto.Valor));
        return configuracaoDominio.Prompt.CriarPromptPrincipal(
            pedido,
            configuracaoDominio.PerfilUsuario,
            configuracaoDominio.DiretrizNarrativaPerfilAtiva.Valor,
            focoEmocional,
            diretrizPorTracos);
    }

    private static ContextoNarrativoPrevio MapearContexto(ContextoNarrativoPrevioServidor contextoPrevio)
    {
        return ContextoNarrativoPrevio.Criar(
            contextoPrevio?.PensamentoAnterior ?? string.Empty,
            contextoPrevio?.ContoAnterior ?? string.Empty);
    }

    private static PedidoNarrativo MapearPedido(PedidoNarrativoJsonContrato pedido)
    {
        return PedidoNarrativo.Criar(
            pedido?.Id ?? string.Empty,
            pedido?.Tipo ?? string.Empty,
            pedido?.SimAtivo ?? string.Empty,
            pedido?.HorarioReal ?? string.Empty,
            pedido?.Contexto ?? string.Empty);
    }

    private static RespostaNarrativaJsonContrato MapearRespostaContrato(RespostaNarrativa resposta)
    {
        return new RespostaNarrativaJsonContrato
        {
            Id = resposta.IdPedido.Valor,
            Tipo = resposta.TipoNarrativa,
            SimAtivo = resposta.SimAtivo.Valor,
            HorarioReal = resposta.HorarioReal.Valor,
            Prompt = resposta.PromptAplicado != null ? resposta.PromptAplicado.TextoFinal.Valor : string.Empty,
            Resposta = resposta.TextoResposta.Valor
        };
    }

}

internal sealed class ProcessarPedidosNarrativosEntradaDto
{
    public CancellationToken CancellationToken { get; set; }
}

internal sealed class ProcessarPedidosNarrativosSaidaDto
{
    public ProcessarPedidosNarrativosSaidaDto()
    {
        RespostasGeradas = new List<RespostaNarrativa>();
    }

    public int QuantidadePedidosLidos { get; set; }
    public int QuantidadePedidosProcessados { get; set; }
    public int QuantidadeRespostasGravadas { get; set; }
    public IList<RespostaNarrativa> RespostasGeradas { get; private set; }
}