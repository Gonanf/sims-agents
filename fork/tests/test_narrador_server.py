"""Tests para narrador_server.py — sin LLM, sin TS3."""
from pathlib import Path
import sys
import pytest

ROOT = Path(__file__).resolve().parent.parent
sys.path.insert(0, str(ROOT / "build"))
import narrador_server  # noqa: E402

CfgPath = ROOT / "NarradorPorEventos.config.json"


def test_server_py_exists():
    assert (ROOT / "build/narrador_server.py").exists()


def test_server_maps_exists():
    assert (ROOT / "build/server_maps.json").exists()


def test_config_loads_valid():
    """Configuración del config real carga sin excepción."""
    cfg = narrador_server.Config(str(CfgPath))
    assert cfg.modelo == "Kateto", f"modelo={cfg.modelo}"
    assert cfg.poll_ms > 0
    assert cfg.timeout > 0
    assert cfg.get("ollama.url") == "http://127.0.0.1:11434/v1/chat/completions"


def test_interpolar_sustituye_variables():
    result = narrador_server.interpolar(
        "Hola {nombre}, tienes {edad} años", {"nombre": "Bella", "edad": "30"}
    )
    assert "Bella" in result
    assert "{edad}" not in result


def test_interpolar_colapsa_blancos_consecutivos():
    """interpolar colapsa líneas en blanco consecutivas."""
    result = narrador_server.interpolar("línea1\n\nlínea2\n\n\nlínea3", {})
    assert "línea1" in result and "línea3" in result


def test_crear_prompt_con_pedido_valido():
    cfg = narrador_server.Config(str(CfgPath))
    pedido = {"id": "t1", "tipo": "pensamiento", "sim_ativo": "Bella",
              "contexto": "humor=alto"}
    prompt = narrador_server.criar_prompt(pedido, cfg)
    assert isinstance(prompt, str)
    assert len(prompt) > 0
    assert "Bella" in prompt


def test_sanitizar_limpia_quebras_y_comillas():
    bruto = '  "Oi\r\n  bairro\t"  '
    assert narrador_server.sanitizar(bruto) == "Oi bairro"


def test_foco_emocional_por_defecto():
    assert (narrador_server.obter_foco_emocional("sin tokens")
            == "O tom deve ser condizente com o humor atual.")


def test_pedidos_vacio_regresa_cero():
    cfg = narrador_server.Config(str(CfgPath))
    count = narrador_server.procesar_una_vez(cfg)
    assert count == 0
