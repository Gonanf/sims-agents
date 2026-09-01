using System;
using System.Collections.Generic;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    // Runner standalone de las autoverificaciones de Fase 1 (mono, sin juego).
    // No forma parte del mod: se compila solo por build-testes-fase1.sh.
    public static class TestRunnerFase1
    {
        public static int Main()
        {
            IList<string> falhas = TesteContratoAcaoEExecucao.Executar();
            if (falhas.Count == 0)
            {
                Console.WriteLine("OK: TesteContratoAcaoEExecucao — 0 falhas");
                return 0;
            }
            Console.WriteLine("FALHAS ({0}):", falhas.Count);
            for (int i = 0; i < falhas.Count; i++)
                Console.WriteLine("  - " + falhas[i]);
            return 1;
        }
    }
}
