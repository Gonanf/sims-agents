using NarradorPorEventos.Dominio;
using System;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod
{
    internal sealed class CriarPedidoNarrativoCasoDeUso
    {
        public CriarPedidoNarrativoSaidaDto Executar(CriarPedidoNarrativoEntradaDto entrada)
        {
            if (entrada == null)
                return new CriarPedidoNarrativoSaidaDto();

            PedidoNarrativo pedido = PedidoNarrativo.CriarNovo(
                entrada.TipoNarrativa,
                entrada.SimAtivo,
                entrada.ContextoNarrativo,
                entrada.HorarioAtual);

            return new CriarPedidoNarrativoSaidaDto
            {
                Pedido = pedido
            };
        }
    }

    internal sealed class CriarPedidoNarrativoEntradaDto
    {
        public string TipoNarrativa { get; set; }
        public string SimAtivo { get; set; }
        public string ContextoNarrativo { get; set; }
        public DateTime HorarioAtual { get; set; }
    }

    internal sealed class CriarPedidoNarrativoSaidaDto
    {
        public PedidoNarrativo Pedido { get; set; }
    }
}