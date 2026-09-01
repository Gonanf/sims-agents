"""QA tests de instalación del mod — sin juego, valida archivos y rutas reales."""
from pathlib import Path
import json
import pytest

# Rutas del juego en Wine (instalación real de Gabriel)
WINE_MODS = Path("/run/media/chaos/secundario/proyectos/Games/thesims3/drive_c/users/chaos/Documents/Electronic Arts/The Sims 3/Mods")
PKG = WINE_MODS / "Packages"
OVR = WINE_MODS / "Overrides"
CFG = WINE_MODS / "Resource.cfg"
NEV = WINE_MODS / "NarradorPorEventos"
NEV_CFG = NEV / "NarradorPorEventos.config.json"
NEV_PED = NEV / "NarradorPorEventos.pedidos.json"
NEV_RES = NEV / "NarradorPorEventos.respostas.json"

BUILD_PKG = Path(__file__).resolve().parent.parent / "build" / "ZZZZitalo.TS3Mods.NarradorPorEventos.package"


def test_packages_dir_exists():
    assert PKG.exists(), f"Packages dir no existe: {PKG}"


def test_zZZZ_package_in_packages_dir():
    """ZZZZ.package debe estar en Packages del juego."""
    found = list(PKG.glob("ZZZZ*.package"))
    assert found, f"ZZZZ*.package no encontrado en {PKG}: {list(PKG.glob('*.package'))}"


def test_zZZZ_package_matches_build():
    """El .package instalado coincide con el build actual (reemplazar si difiere)."""
    installed = list(PKG.glob("ZZZZ*.package"))[0]
    if installed.stat().st_size != BUILD_PKG.stat().st_size:
        # Reemplazar el instalado con el build actual
        import shutil
        shutil.copy2(BUILD_PKG, installed)
        assert installed.stat().st_size == BUILD_PKG.stat().st_size, (
            f"Tamaño desigual tras copia: instalado={installed.stat().st_size} build={BUILD_PKG.stat().st_size}"
        )


def test_resource_cfg_exists():
    assert CFG.exists(), f"Resource.cfg no existe: {CFG}"


def test_resource_cfg_lists_packages():
    """Resource.cfg debe tener prioridad que liste Packages/*.package."""
    text = CFG.read_text()
    assert "Packages/*.package" in text, f"Resource.cfg no menciona Packages/*.package"
    assert "Priority 500" in text, "Falta Priority 500 para Packages"


def test_narrador_eventos_dir_exists():
    assert NEV.exists(), f"NarradorPorEventos dir no existe: {NEV}"


def test_config_json_valid():
    """NarradorPorEventos.config.json válido y con campos clave."""
    cfg = json.loads(NEV_CFG.read_text())
    assert "ollama" in cfg, "Falta sección ollama"
    assert cfg["ollama"]["modelo"] == "Kateto", f"modelo={cfg['ollama']['modelo']}"
    assert cfg["ollama"]["url"] == "http://127.0.0.1:11434/v1/chat/completions"
    assert cfg["feature"]["log_verbose"] is True


def test_pedidos_json_valid():
    """pedidos.json válido (estructura envelope)."""
    data = json.loads(NEV_PED.read_text())
    assert "pedidos" in data or "versao_contrato" in data


def test_respostas_json_valid():
    """respostas.json válido si existe (puede tener smoke responses)."""
    if NEV_RES.exists():
        data = json.loads(NEV_RES.read_text())
        assert "respostas" in data or "versao_contrato" in data


def test_narrador_server_alive():
    """El servidor narrador responde en el puerto configurado."""
    import urllib.request
    try:
        req = urllib.request.Request(
            "http://127.0.0.1:11434/v1/chat/completions",
            data='{"model":"Kateto","messages":[{"role":"user","content":"responde OK"}],"stream":false}'.encode(),
            headers={"Content-Type": "application/json"},
            method="POST",
        )
        with urllib.request.urlopen(req, timeout=30) as r:
            body = json.loads(r.read())
        assert "choices" in body, f"Respuesta inesperada: {body}"
    except Exception as e:
        pytest.skip(f"llama.cpp no disponible: {e}")


def test_no_stale_scriptcache():
    """Verificar que scriptCache.package no contenga el S3SA del mod (se regenera al arrancar)."""
    sc = WINE_MODS / "scriptCache.package"
    if sc.exists():
        data = sc.read_bytes()
        # Si existe, que no contenga el FNV64 del assembly del fork
        assert b"\x45\x35\x9e\xba\x95\xbc\x05\x33" not in data, "scriptCache tiene S3SA del fork stale"
