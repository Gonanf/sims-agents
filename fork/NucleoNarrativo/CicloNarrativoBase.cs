using NarradorPorEventos.Dominio;
using Sims3.Gameplay.Actors;
using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Contrato comum para ciclos narrativos especializados, como pensamento e conto.
    /// </summary>
    internal interface ICicloNarrativo
    {
        string TipoNarrativa { get; }
        int QuantidadeEventosParaDisparo { get; }
        int LimiteResumo { get; }
        int LimiteCaracteresContexto { get; }

        PedidoNarrativo ProcessarEvento(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simAtivo);
        bool ReconheceTipo(string tipoNarrativo);
    }

    /// <summary>
    /// Implementa o ciclo de vida comum de uma narrativa: acumular eventos, filtrar,
    /// montar contexto e gerar o pedido quando o threshold configurado for atingido.
    /// </summary>
    internal class CicloNarrativoBase : ICicloNarrativo
    {
        private readonly PoliticaCicloNarrativo _politica;
        private readonly CriarPedidoNarrativoCasoDeUso _criarPedidoNarrativoCasoDeUso;
        private readonly List<EventoNarrativoJsonContrato> _eventosAcumulados = new List<EventoNarrativoJsonContrato>();

        protected CicloNarrativoBase(PoliticaCicloNarrativo politica)
        {
            _politica = politica;
            _criarPedidoNarrativoCasoDeUso = new CriarPedidoNarrativoCasoDeUso();
        }

        public string TipoNarrativa
        {
            get { return _politica.TipoNarrativa; }
        }

        public int QuantidadeEventosParaDisparo
        {
            get { return _politica.QuantidadeEventosParaDisparo; }
        }

        public int LimiteResumo
        {
            get { return _politica.LimiteResumo; }
        }

        public int LimiteCaracteresContexto
        {
            get { return _politica.LimiteCaracteresContexto; }
        }

        public PedidoNarrativo ProcessarEvento(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simAtivo)
        {
            if (eventoBase == null || !_politica.DeveAcumularEvento(eventoBase, tipoEvento, simAtivo))
                return null;

            _eventosAcumulados.Add(eventoBase.ParaContratoJson());

            Sim simBase = PoliticaCicloNarrativo.ResolverSimBase(simAtivo, eventoBase);
            if (simBase == null || _eventosAcumulados.Count < QuantidadeEventosParaDisparo)
                return null;

            List<EventoNarrativoJsonContrato> eventosFiltrados = _politica.FiltrarEventosParaContexto(simBase, _eventosAcumulados);
            string contexto = LimitarContexto(_politica.MontarContexto(simBase, eventosFiltrados ?? new List<EventoNarrativoJsonContrato>()));
            PedidoNarrativo pedido = CriarPedido(simAtivo, contexto);
            _eventosAcumulados.Clear();
            return pedido;
        }

        public bool ReconheceTipo(string tipoNarrativo)
        {
            return AdaptadorTextoNarrativo.TipoNarrativoCorresponde(tipoNarrativo, TipoNarrativa);
        }

        private string LimitarContexto(string contexto)
        {
            return AdaptadorTextoNarrativo.LimitarContextoFinal(contexto, LimiteCaracteresContexto);
        }

        private PedidoNarrativo CriarPedido(Sim simAtivo, string contexto)
        {
            CriarPedidoNarrativoSaidaDto saida = _criarPedidoNarrativoCasoDeUso.Executar(new CriarPedidoNarrativoEntradaDto
            {
                TipoNarrativa = TipoNarrativa,
                SimAtivo = AdaptadorTextoNarrativo.SanitizarLinha(RepoConsulta.ConsultaSim.ObterNomeSim(simAtivo)),
                ContextoNarrativo = contexto ?? string.Empty,
                HorarioAtual = DateTime.Now
            });

            return saida.Pedido;
        }
    }
}