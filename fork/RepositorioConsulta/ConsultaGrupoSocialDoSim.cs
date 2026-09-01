using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Skills;
namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public enum GrupoSocial
    {
        Nenhum,
        Rebelde,
        Nerd,
        Popular
    }

    public static class ConsultaGrupoSocialDoSim
    {
        private const int NivelMaximoGrupoSocial = 10;

        public static GrupoSocial GrupoDoSim(Sim sim)
        {
            int nivelRebelde = ObterNivelGrupoSocial(sim, TraitNames.InfluenceRebel, SkillNames.InfluenceRebel);
            int nivelNerd = ObterNivelGrupoSocial(sim, TraitNames.InfluenceNerd, SkillNames.InfluenceNerd);
            int nivelPopular = ObterNivelGrupoSocial(sim, TraitNames.InfluenceSocialite, SkillNames.InfluenceSocialite);

            return GrupoComMaiorNivel(nivelRebelde, nivelNerd, nivelPopular);
        }

        public static string GrupoDoSimEmTexto(Sim sim)
        {
            int nivelRebelde = ObterNivelGrupoSocial(sim, TraitNames.InfluenceRebel, SkillNames.InfluenceRebel);
            int nivelNerd = ObterNivelGrupoSocial(sim, TraitNames.InfluenceNerd, SkillNames.InfluenceNerd);
            int nivelPopular = ObterNivelGrupoSocial(sim, TraitNames.InfluenceSocialite, SkillNames.InfluenceSocialite);

            GrupoSocial grupoDominante = GrupoComMaiorNivel(nivelRebelde, nivelNerd, nivelPopular);
            string grupoDominanteEmTexto = GrupoEmTexto(grupoDominante);

            return string.Format("{0} | 3 grupos: rebelde {1}/{4}, nerd {2}/{4}, popular {3}/{4}",
                grupoDominanteEmTexto,
                nivelRebelde,
                nivelNerd,
                nivelPopular,
                NivelMaximoGrupoSocial);
        }

        private static int ObterNivelGrupoSocial(Sim sim, TraitNames tracoGrupo, SkillNames skillGrupo)
        {
            if (sim == null || sim.SimDescription == null)
                return 0;

            TraitManager traitManager = sim.SimDescription.TraitManager;
            SkillManager skillManager = sim.SimDescription.SkillManager;

            if (traitManager == null || skillManager == null)
                return 0;

            if (!traitManager.HasElement(tracoGrupo))
                return 0;

            InfluenceSkill skill = skillManager.GetSkill<InfluenceSkill>(skillGrupo);
            if (skill == null || skill.SkillLevel <= 0)
                return 0;

            if (skill.SkillLevel > NivelMaximoGrupoSocial)
                return NivelMaximoGrupoSocial;

            return skill.SkillLevel;
        }

        private static GrupoSocial GrupoComMaiorNivel(int nivelRebelde, int nivelNerd, int nivelPopular)
        {
            GrupoSocial grupo = GrupoSocial.Nenhum;
            int maiorNivel = 0;

            if (nivelRebelde > maiorNivel)
            {
                maiorNivel = nivelRebelde;
                grupo = GrupoSocial.Rebelde;
            }

            if (nivelNerd > maiorNivel)
            {
                maiorNivel = nivelNerd;
                grupo = GrupoSocial.Nerd;
            }

            if (nivelPopular > maiorNivel)
                grupo = GrupoSocial.Popular;

            return grupo;
        }

        private static string GrupoEmTexto(GrupoSocial grupo)
        {
            switch (grupo)
            {
                case GrupoSocial.Rebelde: return "dominante rebelde";
                case GrupoSocial.Nerd: return "dominante nerd";
                case GrupoSocial.Popular: return "dominante popular";
                default: return "sem grupo dominante";
            }
        }
    }
}
