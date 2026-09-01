#!/usr/bin/env bash
# run-tests.sh — suite completo de QA sin intervención.
# Componentes:
#   1) pytest          — tests unitarios (build, package_mod, narrador_server, QA instalación)
#   2) dotnet test     — NarradorEngine xunit (28 tests .NET)
#   3) mcs build       — compila el mod, valida 0 errores
#   4) package_mod     — genera + valida .package DBPF
#   5) QA instalación  — verifica archivos reales del juego en Wine, config, servidor vivo
set -euo pipefail
ROOT="$(cd "$(dirname "$0")" && pwd)"
FORK="$ROOT/fork"
PASSED=0
FAILED=0

run() {
  local label="$1"; shift
  echo ""
  echo "══════════════════════════════════════════════"
  echo "▶ $label"
  echo "══════════════════════════════════════════════"
  if "$@"; then
    echo "✅ $label OK"
    PASSED=$((PASSED+1))
  else
    echo "❌ $label FALLÓ (exit=$?)"
    FAILED=$((FAILED+1))
  fi
}

cd "$ROOT"

run "1) Tests Python (pytest — unitarios + QA instalación)" \
    python3 -m pytest "$FORK/tests/" -v --tb=short
run "2) Tests NarradorEngine (xunit)" \
    dotnet test "$FORK/NarradorEngine.Server.Tests" --verbosity normal --no-restore
run "3) Build mod (mcs)" \
    python3 "$FORK/build_mod_real.py"
run "4) Validate .package (DBPF + S3SA byte-identical)" \
    python3 "$FORK/build/package_mod.py"
run "5) QA instalación (archivos del juego en Wine)" \
    python3 -m pytest "$FORK/tests/test_qa_install.py" -v --tb=short

echo ""
echo "══════════════════════════════════════════════"
echo "Resultado: $PASSED pasaron, $FAILED fallaron"
echo "══════════════════════════════════════════════"
if [ "$FAILED" -gt 0 ]; then exit 1; fi
