namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public enum ClasseEconomica
    {
        Pobre,
        Media,
        Alta
    }

    public static class ConsultaClasseEconomica
    {
        public static int LimitePobre = 20000;
        public static int LimiteAlta = 100000;

        public static int CodigoClasseAtual
        {
            get { return CodigoClasse(ClasseDaFamiliaAtual); }
        }

        public static ClasseEconomica ClasseDaFamiliaAtual
        {
            get { return Classificar(ConsultaFamiliaAtiva.SimoloeosDaFamiliaAtual); }
        }

        public static ClasseEconomica Classificar(int fundos)
        {
            if (fundos < LimitePobre) return ClasseEconomica.Pobre;
            if (fundos >= LimiteAlta) return ClasseEconomica.Alta;
            return ClasseEconomica.Media;
        }

        public static bool EhClasseA(int fundos)
        {
            return Classificar(fundos) == ClasseEconomica.Alta;
        }

        public static bool EhClasseB(int fundos)
        {
            return Classificar(fundos) == ClasseEconomica.Media;
        }

        public static bool EhPobre(int fundos)
        {
            return Classificar(fundos) == ClasseEconomica.Pobre;
        }

        public static string EmTexto(ClasseEconomica classe)
        {
            switch (classe)
            {
                case ClasseEconomica.Alta: return "classe alta";
                case ClasseEconomica.Media: return "classe média";
                default: return "classe baixa";
            }
        }

        public static string SituacaoFinanceiraEmTexto(int fundos)
        {
            ClasseEconomica classe = Classificar(fundos);
            switch (classe)
            {
                case ClasseEconomica.Alta: return "rica";
                case ClasseEconomica.Media: return "média";
                default: return "pobre";
            }
        }

        public static int CodigoClasse(ClasseEconomica classe)
        {
            switch (classe)
            {
                case ClasseEconomica.Pobre: return 0;
                case ClasseEconomica.Media: return 1;
                case ClasseEconomica.Alta: return 2;
                default: return 1;
            }
        }

        public static string LimitesClasseParaLlm()
        {
            return "0:Pobre,1:Media,2:Alta";
        }

        public static string LimitesFundosParaLlm()
        {
            return "Pobre<" + LimitePobre + ",Media>= " + LimitePobre + " e <" + LimiteAlta + ",Alta>=" + LimiteAlta;
        }
    }
}
