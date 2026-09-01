using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.DreamsAndPromises;
using Sims3.Gameplay.Socializing;
using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    // Fachada única — importe só essa classe nos módulos narrativos.
    public static class RepoConsulta
    {
        // ------------------------------------------------------------------ sim ativo

        public static Sim SimAtivo
            => ConsultaSim.SimAtivo;

        public static bool HaSimAtivo
            => ConsultaSim.HaSimAtivo;

        public static List<Sim> ConjuntoDeSimsDaCasaAtual
            => ConsultaFamiliaAtiva.ConjuntoDeSimsDaCasaAtual;

        public static List<Sim> ConjuntoDeSimsNoLote(Lot lote)
            => ConsultaAmbiente.ConjuntoDeSimsNoLote(lote);

        public static List<Sim> ConjuntoDeSimsNoLoteAtual
            => ConsultaAmbiente.ConjuntoDeSimsNoLoteAtual;

        // ------------------------------------------------------------------ economia

        public static int SimoloeosDaFamiliaAtual
            => ConsultaFamiliaAtiva.SimoloeosDaFamiliaAtual;

        public static ClasseEconomica ClasseDaFamiliaAtual
            => ConsultaClasseEconomica.ClasseDaFamiliaAtual;

        public static bool SimEhClasseA => ConsultaClasseEconomica.EhClasseA(SimoloeosDaFamiliaAtual);
        public static bool SimEhClasseB => ConsultaClasseEconomica.EhClasseB(SimoloeosDaFamiliaAtual);
        public static bool SimEhPobre => ConsultaClasseEconomica.EhPobre(SimoloeosDaFamiliaAtual);

        public static string ClasseEconomicaEmTexto
            => ConsultaClasseEconomica.EmTexto(ClasseDaFamiliaAtual);

        public static int CustoCasaDaFamilia(Sim sim)
            => ConsultaFamiliaAtiva.ConsultarValorDoLotePorSim(sim);

        // ------------------------------------------------------------------ traços

        public static List<TraitNames> ListaDeTracos(Sim sim)
            => ConsultaTracosDoSim.ListaDeTracos(sim);

        public static string TracosEmTexto(Sim sim)
            => ConsultaTracosDoSim.TracosDoSimEmTexto(sim);

        public static bool PossuiTraco(Sim sim, TraitNames traco)
            => ConsultaTracosDoSim.PossuiTraco(sim, traco);

        // ------------------------------------------------------------------ humor

        public static float HumorAtual(Sim sim)
            => ConsultaHumorDoSim.HumorAtual(sim);

        public static string HumorEmTexto(Sim sim)
            => ConsultaHumorDoSim.NivelEmTexto(ConsultaHumorDoSim.NivelAtual(sim));

        public static List<MoodletInfo> ModificadoresDeHumor(Sim sim)
            => ConsultaHumorDoSim.ModificadoresDeHumor(sim);

        public static string ModificadoresDeHumorEmTexto(Sim sim)
            => ConsultaHumorDoSim.ModificadoresDoSimEmTexto(sim);

        // ------------------------------------------------------------------ necessidades

        public static List<NecessidadeInfo> ListaDeNecessidades(Sim sim)
            => ConsultaNecessidadesDoSim.ListaDeNecessidades(sim);

        public static string NecessidadesEmTexto(Sim sim)
            => ConsultaNecessidadesDoSim.NecessidadesDoSimEmTexto(sim);

        public static string NecessidadesCriticasEmTexto(Sim sim)
            => ConsultaNecessidadesDoSim.NecessidadesCriticasEmTexto(sim);

        // ------------------------------------------------------------------ desejos

        public static List<ActiveDreamNode> DesejosAtivos(Sim sim)
            => ConsultaDesejosDoSim.DesejosAtivos(sim);

        public static string DesejosAtivosEmTexto(Sim sim)
            => ConsultaDesejosDoSim.DesejosDoSimEmTexto(sim);

        // public static string DesejosAtivaveisEmTexto(Sim sim)
        //     => ConsultaDesejosDoSim.DesejosAtivaveisDoSimEmTexto(sim);

        // ------------------------------------------------------------------ grupo social

        public static GrupoSocial GrupoSocial(Sim sim)
            => ConsultaGrupoSocialDoSim.GrupoDoSim(sim);

        public static string GrupoSocialEmTexto(Sim sim)
            => ConsultaGrupoSocialDoSim.GrupoDoSimEmTexto(sim);

        // ------------------------------------------------------------------ relacionamentos

        public static List<Relationship> ListaDeRelacionamentos(Sim sim)
            => ConsultaRelacionamentosDoSim.ListaDeRelacionamentos(sim);

        public static List<Relationship> ListaDeAmigos(Sim sim)
            => ConsultaRelacionamentosDoSim.ListaDeAmigos(sim);

        public static List<Relationship> ListaDeDesafetos(Sim sim)
            => ConsultaRelacionamentosDoSim.ListaDeDesafetos(sim);

        public static List<Sim> AmigosNoLote(Sim sim, Lot lote)
            => ConsultaRelacionamentosDoSim.AmigosNoLote(sim, lote);

        public static List<Sim> DesafetosNoLote(Sim sim, Lot lote)
            => ConsultaRelacionamentosDoSim.DesafetosNoLote(sim, lote);

        public static string AmigosEmTexto(Sim sim)
            => ConsultaRelacionamentosDoSim.RelacionamentosEmTexto(ListaDeAmigos(sim), sim);

        public static string DesafetosEmTexto(Sim sim)
            => ConsultaRelacionamentosDoSim.RelacionamentosEmTexto(ListaDeDesafetos(sim), sim);

        // ------------------------------------------------------------------ idade

        public static string IdadeEmTexto(Sim sim)
            => ConsultaIdadeDoSim.IdadeEmTexto(sim);

        public static float DiasDeVidaRestantes(Sim sim)
            => ConsultaIdadeDoSim.DiasDeVidaRestantes(sim);

        public static bool EstaProximoDoAniversario(Sim sim)
            => ConsultaIdadeDoSim.EstaProximoDoAniversario(sim);

        public static bool EstaProximoDeMorrer(Sim sim)
            => ConsultaIdadeDoSim.EstaProximoDeMorrer(sim);

        // ------------------------------------------------------------------ carreira

        public static string CarreiraEmTexto(Sim sim)
            => ConsultaCarreiraDoSim.CarreiraEmTexto(sim);

        public static bool EstaNoTrabalhoAgora(Sim sim)
            => ConsultaCarreiraDoSim.EstaNoTrabalhoAgora(sim);

        public static bool EstaEmpregado(Sim sim)
            => ConsultaCarreiraDoSim.EstaEmpregado(sim);

        // ------------------------------------------------------------------ habilidades

        public static string HabilidadesEmTexto(Sim sim)
            => ConsultaHabilidadesDoSim.HabilidadesEmTexto(sim);

        public static string HabilidadesAvancadasEmTexto(Sim sim, int nivelMinimo = 5)
            => ConsultaHabilidadesDoSim.HabilidadesAvancadasEmTexto(sim, nivelMinimo);

        public static string HabilidadePrincipalEmTexto(Sim sim)
            => ConsultaHabilidadesDoSim.HabilidadePrincipalEmTexto(sim);

        public static string ResumoHabilidadesParaLlm(Sim sim)
            => ConsultaHabilidadesDoSim.ResumoHabilidadesParaLlm(sim);

        // ------------------------------------------------------------------ status especial

        public static bool EstaGravida(Sim sim)
            => ConsultaSim.EstaGravida(sim);

        public static string OcultismoEmTexto(Sim sim)
            => ConsultaSim.OcultismoDoSimEmTexto(sim);

        public static string FlagsNarrativasEmTexto(Sim sim)
            => ConsultaSim.FlagsNarrativasEmTexto(sim);

        public static string ParticularidadesEmTexto(Sim sim)
            => ConsultaSim.ParticularidadesEmTexto(sim);

        // ------------------------------------------------------------------ vida pessoal

        public static string EstadoCivilEmTexto(Sim sim)
            => ConsultaSim.EstadoCivilEmTexto(sim);

        public static string ContextoVidaPessoalEmTexto(Sim sim)
            => ConsultaSim.ContextoDeVidaPessoal(sim);

        public static string PreferenciaSexualEmTexto(Sim sim)
            => ConsultaSim.PreferenciaSexualEmTexto(sim);

        public static string FavoritosEmTexto(Sim sim)
            => ConsultaSim.FavoritosEmTexto(sim);

        public static string DadosParaFofoca(Sim sim)
            => ConsultaSim.ResumoNarrativoPessoalDoSim(sim);

        // ------------------------------------------------------------------ ambiente

        public static string AmbienteEmTexto(Sim sim)
            => ConsultaAmbiente.AmbienteEmTexto(sim);

        public static bool SimEstaEmViagem(Sim sim)
            => ConsultaMundo.SimEstaEmViagem(sim);

        public static string MundoAtualEmTexto
            => ConsultaMundo.NomeMundoAtual();

        // ------------------------------------------------------------------ horário

        public static string HorarioDoJogo
            => ConsultaDeHorario.HorarioDoJogo;

        public static string HorarioDoMundoReal
            => ConsultaDeHorario.HorarioDoMundoReal;

        public static string PeriodoDoDia
            => ConsultaDeHorario.PeriodoDoDia;

        // ------------------------------------------------------------------ LLM

        public static string SnapshotParaLLM(Sim sim)
            => ContextoParaLLM.SnapshotDoSim(sim);

        public static string SnapshotDoSimAtivoParaLLM()
            => ContextoParaLLM.SnapshotDoSimAtivo();

        public static string PromptDePensamento(Sim sim, string eventosRecentes)
            => MontarPromptNarrativo("pensamento", sim, eventosRecentes);

        public static string PromptDeConto(Sim sim, string eventosRecentes)
            => MontarPromptNarrativo("conto", sim, eventosRecentes);

        private static string MontarPromptNarrativo(string tipoNarrativa, Sim sim, string eventosRecentes)
            => "tipo=" + tipoNarrativa + "\n" + SnapshotParaLLM(sim) + "\nEVENTOS RECENTES:\n" + (eventosRecentes ?? string.Empty);
    }
}
