using NarradorPorEventos.Dominio;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod
{
    internal sealed class AnexarPedidoNarrativoCasoDeUso
    {
        private readonly IAdaptadorArquivos _arquivos;
        private readonly ConfiguracaoModNarrativa _configuracao;

        public AnexarPedidoNarrativoCasoDeUso(IAdaptadorArquivos arquivos, ConfiguracaoCentral configuracao)
        {
            _arquivos = arquivos;
            _configuracao = ConfiguracaoModNarrativa.Criar(configuracao);
        }

        public AnexarPedidoNarrativoSaidaDto Executar(AnexarPedidoNarrativoEntradaDto entrada)
        {
            AnexarPedidoNarrativoSaidaDto saida = new AnexarPedidoNarrativoSaidaDto();
            if (entrada == null || entrada.Pedido == null || !entrada.Pedido.EhValido() || !_configuracao.Arquivos.CaminhoPedidos.EstaDefinido)
                return saida;

            PedidoNarrativoJsonContrato contrato = new PedidoNarrativoJsonContrato
            {
                Id = entrada.Pedido.Id.Valor,
                Tipo = entrada.Pedido.TipoNarrativa,
                SimAtivo = entrada.Pedido.SimAtivo.Valor,
                HorarioReal = entrada.Pedido.HorarioReal.Valor,
                Contexto = entrada.Pedido.Contexto.Valor
            };

            AdaptadorContratosJsonNarrativos.AnexarPedido(_arquivos, _configuracao.Arquivos.CaminhoPedidos.Valor, contrato);
            saida.Anexou = true;
            saida.PedidoSerializado = contrato;
            return saida;
        }
    }

    internal sealed class AnexarPedidoNarrativoEntradaDto
    {
        public PedidoNarrativo Pedido { get; set; }
    }

    internal sealed class AnexarPedidoNarrativoSaidaDto
    {
        public bool Anexou { get; set; }
        public PedidoNarrativoJsonContrato PedidoSerializado { get; set; }
    }
}