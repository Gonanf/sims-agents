#!/usr/bin/env bash
# run-tests.sh — ejecuta TODO el suite automatizado sin intervención.
# Dependencias: bun, dotnet, python3, pytest, mcs, mono
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
git init -q 2>/dev/null || true

run "1) Tests Python pytest"        python3 -m pytest "$FORK/tests/" -v --tb=short
run "2) Tests NarradorEngine xunit" dotnet test "$FORK/NarradorEngine.Server.Tests" --verbosity normal --no-restore
run "3) Build mod mcs"             python3 "$FORK/build_mod_real.py"
run "4) Validate .package"         python3 "$FORK/build/package_mod.py"

echo ""
echo "══════════════════════════════════════════════"
echo "Resultado: $PASSED pasaron, $FAILED fallaron"
echo "══════════════════════════════════════════════"
if [ "$FAILED" -gt 0 ]; then exit 1; fi
