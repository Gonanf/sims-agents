using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using System.Collections.Generic;
using System.Text;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public enum NivelHumor
    {
        MuitoRuim,
        Ruim,
        Neutro,
        Bom,
        Excelente
    }

    public class MoodletInfo
    {
        public string Nome;
        public float Valor;
    }

    public static class ConsultaHumorDoSim
    {
        private const string LimitesNivelHumor = "0:MuitoRuim,1:Ruim,2:Neutro,3:Bom,4:Excelente";
        private const string LimitesPontuacaoHumor = "MuitoRuim<=-40,Ruim<-0,Neutro<20,Bom<50,Excelente>=50";

        public static float HumorAtual(Sim sim)
        {
            if (sim == null || sim.MoodManager == null) return 0f;
            return sim.MoodManager.MoodValue;
        }

        public static int CodigoNivelAtual(Sim sim)
        {
            switch (NivelAtual(sim))
            {
                case NivelHumor.MuitoRuim: return 0;
                case NivelHumor.Ruim: return 1;
                case NivelHumor.Neutro: return 2;
                case NivelHumor.Bom: return 3;
                case NivelHumor.Excelente: return 4;
                default: return 2;
            }
        }

        public static string LimitesNivelHumorParaLlm()
        {
            return LimitesNivelHumor;
        }

        public static string LimitesPontuacaoHumorParaLlm()
        {
            return LimitesPontuacaoHumor;
        }

        public static NivelHumor NivelAtual(Sim sim)
        {
            float valor = HumorAtual(sim);
            if (valor <= -40f) return NivelHumor.MuitoRuim;
            if (valor < 0f) return NivelHumor.Ruim;
            if (valor < 20f) return NivelHumor.Neutro;
            if (valor < 50f) return NivelHumor.Bom;
            return NivelHumor.Excelente;
        }

        public static string NivelEmTexto(NivelHumor nivel)
        {
            switch (nivel)
            {
                case NivelHumor.MuitoRuim: return "muito ruim";
                case NivelHumor.Ruim: return "ruim";
                case NivelHumor.Bom: return "bom";
                case NivelHumor.Excelente: return "excelente";
                default: return "neutro";
            }
        }

        public static List<MoodletInfo> ModificadoresDeHumor(Sim sim)
        {
            var lista = new List<MoodletInfo>();
            if (sim == null || sim.BuffManager == null) return lista;

            foreach (BuffInstance buff in sim.BuffManager.List)
            {
                if (buff == null) continue;
                var item = new MoodletInfo();
                item.Nome = ResolverNomeMoodlet(buff);
                float? valor = LeitorPorReflexaoUtil.LerNumero(buff, "MoodValue", "mMoodValue");
                item.Valor = valor ?? 0f;
                lista.Add(item);
            }
            return lista;
        }

        private static string ResolverNomeMoodlet(BuffInstance buff)
        {
            string nome = LeitorPorReflexaoUtil.LerTexto(buff,
                "BuffName",
                "DisplayName",
                "BuffLocalizedName",
                "mBuffName");

            if (!string.IsNullOrEmpty(nome))
                return AdaptadorTextoNarrativo.ExtrairUltimoSegmento(nome, ':', '/');

            return AdaptadorTextoNarrativo.ExtrairUltimoSegmento(buff.BuffGuid.ToString(), ':', '/');
        }

        public static string ModificadoresDoSimEmTexto(Sim sim)
        {
            List<MoodletInfo> moodlets = ModificadoresDeHumor(sim);
            if (moodlets.Count == 0) return "nenhum moodlet";

            StringBuilder sb = new StringBuilder();
            foreach (MoodletInfo moodlet in moodlets)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(moodlet.Nome);

                float valor = moodlet.Valor;
                if (valor >= 1f || valor <= -1f)
                {
                    sb.Append(" (");
                    sb.Append(valor.ToString("F0"));
                    sb.Append(")");
                }
            }
            return sb.ToString();
        }
    }
}
