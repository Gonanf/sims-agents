using Sims3.Gameplay.Actors;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaContextoNarrativoDoSim
    {
        public static string IdentidadeEmTexto(Sim sim)
        {
            string genero = ConsultaSim.ObterGeneroEmTexto(sim);
            string especie = ConsultaSim.EspecieDoSimEmTexto(sim);
            string occulto = ConsultaSim.OcultismoDoSimEmTexto(sim);

            return string.Format("IDENTIDADE: {0} | {1} | {2} ({3}){4} | traços: {5} | grupos sociais: {6}",
                ConsultaSim.ObterNomeSim(sim),
                ConsultaIdadeDoSim.IdadeEmTexto(sim),
                genero,
                especie,
                string.IsNullOrEmpty(occulto) ? string.Empty : " | " + occulto,
                ConsultaTracosDoSim.TracosDoSimEmTexto(sim),
                ConsultaGrupoSocialDoSim.GrupoDoSimEmTexto(sim));
        }

        public static string EstadoEmocionalEmTexto(Sim sim)
        {
            return string.Format("HUMOR: {0} ({1:F0}pt) | moodlets: {2}",
                ConsultaHumorDoSim.NivelEmTexto(ConsultaHumorDoSim.NivelAtual(sim)),
                ConsultaHumorDoSim.HumorAtual(sim),
                ConsultaHumorDoSim.ModificadoresDoSimEmTexto(sim));
        }

        public static string RelacoesPrincipaisEmTexto(Sim sim)
        {
            string amigos = ConsultaRelacionamentosDoSim.RelacionamentosEmTexto(
                ConsultaRelacionamentosDoSim.ListaDeAmigos(sim), sim);
            string desafetos = ConsultaRelacionamentosDoSim.RelacionamentosEmTexto(
                ConsultaRelacionamentosDoSim.ListaDeDesafetos(sim), sim);

            return string.Format("AMIGOS: {0} | DESAFETOS: {1}", amigos, desafetos);
        }

        public static string NecessidadesCriticasEmTexto(Sim sim)
        {
            string criticas = ConsultaNecessidadesDoSim.NecessidadesCriticasEmTexto(sim);
            return "NECESSIDADES CRÍTICAS: " + criticas;
        }

        public static string DesejosEmTexto(Sim sim)
        {
            string ativos = ConsultaDesejosDoSim.DesejosDoSimEmTexto(sim);
            // string disponiveis = ConsultaDesejosDoSim.DesejosAtivaveisDoSimEmTexto(sim);

            if (string.IsNullOrEmpty(ativos))
                ativos = "indisponível";

            return string.Format("DESEJOS ATIVOS: {0}", ativos);
        }

        public static string CicloDeVidaEmTexto(Sim sim)
        {
            return ConsultaIdadeDoSim.CicloDeVidaEmTexto(sim);
        }

        public static string AmbienteAtualEmTexto(Sim sim)
        {
            string lote = ConsultaAmbiente.LoteAtualEmTexto(sim);
            string mundo = ConsultaMundo.NomeMundoAtual();
            string simsProximos = sim != null ? ConsultaAmbiente.ContarSimsNoLote(sim.LotCurrent).ToString() : "0";
            string localidadesProximas = ConsultaAmbiente.LocalidadesProximasEmTexto(sim, 3);

            return string.Format("AMBIENTE: {0} | mundo: {1} | sims próximos: {2} | localidades próximas: {3}",
                lote, mundo, simsProximos, localidadesProximas);
        }
    }
}
