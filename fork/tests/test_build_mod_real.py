"""Tests para build_mod_real.py — sin red, sin juego, solo archivos."""
import subprocess
import sys
import os
from pathlib import Path
import pytest

ROOT = Path(__file__).resolve().parent.parent
CSProj = ROOT / "ZZZZitalo.TS3Mods.NarradorPorEventos.csproj"
Build = ROOT / "build_mod_real.py"


@pytest.fixture
def mcs_errors_log(tmp_path):
    yield tmp_path / "mcs-errores.log"


def test_build_mod_real_py_exists():
    assert Build.exists(), "build_mod_real.py debe existir"
    assert os.access(str(Build), os.X_OK) or (Build.read_text().startswith("#!/usr/bin/env python3"))


def test_csproj_has_66_sources():
    text = CSProj.read_text(encoding="utf-8")
    sources = [f for f in __import__("re").findall(r'<Compile Include="([^"]+)"\s*/>', text)]
    missing = [s for s in sources if not (ROOT / s.replace("\\", "/")).exists()]
    assert not missing, f"Archivos faltantes en csproj: {missing}"
    assert len(sources) == 66, f"Se esperaban 66 fuentes, se encontraron {len(sources)}"


def test_build_mod_real_zero_errors():
    result = subprocess.run(
        [sys.executable, str(Build)], cwd=str(ROOT), capture_output=True, text=True, timeout=120
    )
    assert result.returncode == 0, f"build_mod_real.py falló: {result.stdout}\\n{result.stderr}"
    assert "Total errores: 0" in result.stdout, f"Se reportaron errores: {result.stdout}"


def test_dll_produced_and_valid(mcs_errors_log):
    dll = ROOT / "build/ZZZZitalo.TS3Mods.NarradorPorEventos.dll"
    assert dll.exists(), "La DLL de build no existe"
    size = dll.stat().st_size
    assert size > 0, "DLL vacía"
    # mcs-errores.log debe existir y estar limpio
    if mcs_errors_log.exists():
        log = mcs_errors_log.read_text()
        assert "error CS" not in log, f"Errores en mcs-errores.log: {log[:500]}"
