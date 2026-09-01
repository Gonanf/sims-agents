using Sims3.Gameplay.Actors;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ConsultaHabilidadesDoSim
    {
        private const int NivelMinimoHabilidade = 0;
        private const int NivelMaximoHabilidade = 10;
        private const int NivelMinimoHabilidadeAvancadaPadrao = 5;

        public static List<Skill> ListaDeHabilidades(Sim sim)
        {
            List<Skill> habilidades = new List<Skill>();
            if (sim == null || sim.SkillManager == null)
                return habilidades;

            Array nomesDasHabilidades = Enum.GetValues(typeof(SkillNames));
            foreach (SkillNames nomeDaHabilidade in nomesDasHabilidades)
            {
                if (nomeDaHabilidade == SkillNames.None)
                    continue;

                Skill habilidade = sim.SkillManager.GetElement(nomeDaHabilidade);
                if (habilidade == null)
                    continue;

                if (!PertenceAoSim(habilidade, sim))
                    continue;

                habilidades.Add(habilidade);
            }

            return habilidades;
        }

        public static string HabilidadesEmTexto(Sim sim)
        {
            List<Skill> habilidades = ListaDeHabilidades(sim);
            if (habilidades.Count == 0)
                return "nenhuma habilidade";

            StringBuilder sb = new StringBuilder();
            foreach (Skill habilidade in habilidades)
            {
                if (habilidade.SkillLevel <= 0)
                    continue;

                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(habilidade.Name);
                sb.Append(" (");
                sb.Append(habilidade.SkillLevel);
                sb.Append("/");
                sb.Append(NivelMaximoHabilidade);
                sb.Append(")");
            }

            return sb.Length > 0 ? sb.ToString() : "nenhuma habilidade";
        }

        public static string HabilidadesAvancadasEmTexto(Sim sim, int nivelMinimo = NivelMinimoHabilidadeAvancadaPadrao)
        {
            int nivelMinimoNormalizado = NormalizarNivelMinimo(nivelMinimo);
            List<Skill> habilidades = ListaDeHabilidades(sim);

            StringBuilder sb = new StringBuilder();
            foreach (Skill habilidade in habilidades)
            {
                if (habilidade.SkillLevel < nivelMinimoNormalizado)
                    continue;

                if (sb.Length > 0)
                    sb.Append(", ");

                sb.Append(habilidade.Name);
                sb.Append(" (");
                sb.Append(habilidade.SkillLevel);
                sb.Append(")");
            }

            return sb.Length > 0 ? sb.ToString() : "nenhuma habilidade avançada";
        }

        public static string HabilidadePrincipalEmTexto(Sim sim)
        {
            Skill habilidadePrincipal = HabilidadeComMaiorNivel(sim);
            if (habilidadePrincipal == null || habilidadePrincipal.SkillLevel <= 0)
                return "nenhuma habilidade";

            return habilidadePrincipal.Name + " (" + habilidadePrincipal.SkillLevel + "/" + NivelMaximoHabilidade + ")";
        }

        public static int MaiorNivelDeHabilidade(Sim sim)
        {
            Skill habilidadePrincipal = HabilidadeComMaiorNivel(sim);
            return habilidadePrincipal != null ? habilidadePrincipal.SkillLevel : NivelMinimoHabilidade;
        }

        public static int QuantidadeDeHabilidadesComNivel(Sim sim, int nivelMinimo = 1)
        {
            int nivelMinimoNormalizado = NormalizarNivelMinimo(nivelMinimo);
            List<Skill> habilidades = ListaDeHabilidades(sim);

            int quantidade = 0;
            foreach (Skill habilidade in habilidades)
            {
                if (habilidade.SkillLevel >= nivelMinimoNormalizado)
                    quantidade++;
            }

            return quantidade;
        }

        public static string ResumoHabilidadesParaLlm(Sim sim)
        {
            return "principal: " + HabilidadePrincipalEmTexto(sim)
                + " | avançadas: " + HabilidadesAvancadasEmTexto(sim)
                + " | total(>=1): " + QuantidadeDeHabilidadesComNivel(sim, 1);
        }

        public static string HabilidadeMaximizadaRecentemente(Event e)
        {
            Skill habilidade = e != null ? e.TargetObject as Skill : null;
            if (habilidade != null)
                return habilidade.Name;

            return LeitorPorReflexaoUtil.LerTexto(e, "SkillName", "mSkillName", "Skill", "mSkill", "Guid");
        }

        public static string LimitesNivelHabilidadeParaLlm()
        {
            return NivelMinimoHabilidade + ".." + NivelMaximoHabilidade;
        }

        private static Skill HabilidadeComMaiorNivel(Sim sim)
        {
            List<Skill> habilidades = ListaDeHabilidades(sim);
            Skill habilidadePrincipal = null;

            foreach (Skill habilidade in habilidades)
            {
                if (habilidade == null)
                    continue;

                if (habilidadePrincipal == null || habilidade.SkillLevel > habilidadePrincipal.SkillLevel)
                    habilidadePrincipal = habilidade;
            }

            return habilidadePrincipal;
        }

        private static int NormalizarNivelMinimo(int nivelMinimo)
        {
            if (nivelMinimo < NivelMinimoHabilidade)
                return NivelMinimoHabilidade;

            if (nivelMinimo > NivelMaximoHabilidade)
                return NivelMaximoHabilidade;

            return nivelMinimo;
        }

        private static bool PertenceAoSim(Skill habilidade, Sim sim)
        {
            if (habilidade == null || sim == null)
                return false;

            if (habilidade.SkillOwner == null || sim.SimDescription == null)
                return true;

            return object.ReferenceEquals(habilidade.SkillOwner, sim.SimDescription);
        }
    }
}
