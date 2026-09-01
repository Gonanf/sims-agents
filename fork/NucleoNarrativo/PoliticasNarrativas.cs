using Sims3.Gameplay.Actors;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using TipoNarrativaCompartilhada = NarradorPorEventos.Dominio.TipoNarrativa;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Política central para decidir quais eventos entram no ciclo, contam para o threshold e montam o contexto final.
    /// </summary>
    internal abstract class PoliticaCicloNarrativo
    {
        protected PoliticaCicloNarrativo(ConfiguracaoCentral config)
        {
            Configuracao = config;
        }

        protected ConfiguracaoCentral Configuracao { get; private set; }

        public abstract string TipoNarrativa { get; }

        public abstract int QuantidadeEventosParaDisparo { get; }

        public abstract int LimiteResumo { get; }

        public int LimiteCaracteresContexto
        {
            get { return Configuracao.LimiteCaracteresContexto; }
        }

        public abstract bool DeveAcumularEvento(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simAtivo);

        public virtual List<EventoNarrativoJsonContrato> FiltrarEventosParaContexto(Sim simBase, IList<EventoNarrativoJsonContrato> eventos)
        {
            return CriteriosEventosNarrativos.CopiarEventosValidos(eventos);
        }

        public abstract string MontarContexto(Sim simBase, IList<EventoNarrativoJsonContrato> eventos);

        internal static Sim ResolverSimBase(Sim simAtivo, EventoNarrativo eventoBase)
        {
            if (simAtivo != null)
                return simAtivo;

            if (eventoBase == null)
                return null;

            return eventoBase.Ator ?? eventoBase.Alvo;
        }
    }

    /// <summary>
    /// Política de pensamento: só contam eventos realmente relevantes para o sim ativo.
    /// </summary>
    internal sealed class PoliticaCicloNarrativoPensamento : PoliticaCicloNarrativo
    {
        public PoliticaCicloNarrativoPensamento(ConfiguracaoCentral config)
            : base(config)
        {
        }

        public override string TipoNarrativa
        {
            get { return TipoNarrativaCompartilhada.Pensamento; }
        }

        public override int QuantidadeEventosParaDisparo
        {
            get { return Configuracao.QuantidadeEventosPensamento; }
        }

        public override int LimiteResumo
        {
            get { return Configuracao.LimiteResumoPensamento; }
        }

        public override bool DeveAcumularEvento(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simAtivo)
        {
            return CriteriosEventosNarrativos.DeveAcumularPensamento(eventoBase, tipoEvento, simAtivo);
        }

        public override string MontarContexto(Sim simBase, IList<EventoNarrativoJsonContrato> eventos)
        {
            return CriteriosEventosNarrativos.MontarContextoPensamento(simBase, eventos, LimiteResumo);
        }
    }

    /// <summary>
    /// Política de conto: só contam eventos que realmente sustentam uma narrativa longa.
    /// </summary>
    internal sealed class PoliticaCicloNarrativoConto : PoliticaCicloNarrativo
    {
        public PoliticaCicloNarrativoConto(ConfiguracaoCentral config)
            : base(config)
        {
        }

        public override string TipoNarrativa
        {
            get { return TipoNarrativaCompartilhada.Conto; }
        }

        public override int QuantidadeEventosParaDisparo
        {
            get { return Configuracao.QuantidadeEventosConto; }
        }

        public override int LimiteResumo
        {
            get { return Configuracao.LimiteResumoConto; }
        }

        public override bool DeveAcumularEvento(EventoNarrativo eventoBase, EventoTheSims3 tipoEvento, Sim simAtivo)
        {
            Sim simBase = ResolverSimBase(simAtivo, eventoBase);
            return CriteriosEventosNarrativos.DeveAcumularConto(eventoBase, tipoEvento, simBase);
        }

        public override string MontarContexto(Sim simBase, IList<EventoNarrativoJsonContrato> eventos)
        {
            return CriteriosEventosNarrativos.MontarContextoConto(simBase, eventos, LimiteResumo);
        }
    }
}