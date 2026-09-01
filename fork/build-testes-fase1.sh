#!/bin/sh
# Compila y corre las autoverificaciones de Fase 1 con mono (sin juego, sin stubs).
# El código de Fase 1 no referencia APIs de Sims3: solo mscorlib/System.
set -e
cd "$(dirname "$0")"
mkdir -p build
mcs -target:exe -langversion:3 -out:build/testes-fase1.exe \
  Dominio/Mod/AcaoDeSim.cs \
  Dominio/Mod/CatalogoAcoesPermitidas.cs \
  Infraestrutura/Adaptadores/AdaptadorJsonNarrativo.cs \
  Infraestrutura/Adaptadores/AdaptadorAcaoResposta.cs \
  Infraestrutura/Adaptadores/AdaptadorConversaoDeValores.cs \
  Infraestrutura/Adaptadores/LeitorPorReflexaoUtil.cs \
  Aplicacao/Mod/EjecutorDeAcciones.cs \
  TestesDoMod/Autoverificacoes/TesteContratoAcaoEExecucao.cs \
  TestesDoMod/TestRunnerFase1.cs
mono build/testes-fase1.exe
