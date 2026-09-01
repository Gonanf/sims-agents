"""Tests para narrador_server.py — ciclo completo sin LLM.

Usa el config real del juego en Wine (NarradorPorEventos.config.json)
para validar el pipeline completo: carga de config, creación de prompt,
inyección de pedido, escritura de respuesta, limpieza de pedidos.
"""
from pathlib import Path
import json
import sys
import pytest

ROOT = Path(__file__).resolve().parent.parent
sys.path.insert(0, str(ROOT / "build"))
import narrador_server  # noqa: E402

# Config real del juego en Wine (ES, documento activo según DeviceConfig.log)
REAL_CFG = Path(
    "/run/media/chaos/secundario/proyectos/Games/thesims3/drive_c/users/chaos/"
    "Documents/Electronic Arts/The Sims 3/Mods/NarradorPorEventos/"
    "NarradorPorEventos.config.json"
)
REAL_PEDIDOS = REAL_CFG.parent / "NarradorPorEventos.pedidos.json"
REAL_RESPOSTAS = REAL_CFG.parent / "NarradorPorEventos.respostas.json"
REAL_PERFIL = REAL_CFG.parent / "NarradorPorEventos.perfil.usuario.json"


def test_real_config_exists():
    assert REAL_CFG.exists(), f"Config real no existe: {REAL_CFG}"


def test_real_pedidos_exists():
    assert REAL_PEDIDOS.exists(), f"pedidos.json no existe: {REAL_PEDIDOS}"


def test_real_respostas_exists():
    assert REAL_RESPOSTAS.exists(), f"respostas.json no existe: {REAL_RESPOSTAS}"


def test_real_perfil_exists():
    assert REAL_PERFIL.exists(), f"perfil.usuario.json no existe: {REAL_PERFIL}"


def test_config_loads_from_real_path():
    """Config carga desde la ruta real del juego."""
    cfg = narrador_server.Config(str(REAL_CFG))
    assert cfg.modelo == "Kateto", f"modelo={cfg.modelo}"
    assert cfg.poll_ms == 10000
    assert cfg.timeout == 45
    assert cfg.get("ollama.url") == "http://127.0.0.1:11434/v1/chat/completions"


def test_config_resolves_docs_mod_to_game_dir():
    """docs_mod debe resolver a la carpeta real del mod en Wine."""
    cfg = narrador_server.Config(str(REAL_CFG))
    assert str(cfg.docs_mod) == str(REAL_CFG.parent), (
        f"docs_mod={cfg.docs_mod} esperado={REAL_CFG.parent}"
    )


def test_config_pedidos_resolves_to_real_pedidos():
    """pedidos debe apuntar al archivo real del juego."""
    cfg = narrador_server.Config(str(REAL_CFG))
    assert cfg.pedidos == REAL_PEDIDOS, f"pedidos={cfg.pedidos} esperado={REAL_PEDIDOS}"


def test_config_respostas_resolves_to_real_respostas():
    """respostas debe apuntar al archivo real del juego."""
    cfg = narrador_server.Config(str(REAL_CFG))
    assert cfg.respostas == REAL_RESPOSTAS, f"respostas={cfg.respostas} esperado={REAL_RESPOSTAS}"


def test_config_perfil_resolves_to_real_perfil():
    """perfil debe apuntar al archivo real del juego."""
    cfg = narrador_server.Config(str(REAL_CFG))
    assert cfg.perfil == REAL_PERFIL, f"perfil={cfg.perfil} esperado={REAL_PERFIL}"


def test_real_pedidos_json_valid():
    """pedidos.json es JSON válido con estructura envelope."""
    data = json.loads(REAL_PEDIDOS.read_text(encoding="utf-8-sig"))
    assert "pedidos" in data
    assert isinstance(data["pedidos"], list)


def test_real_respostas_json_valid():
    """respostas.json es JSON válido con estructura envelope."""
    data = json.loads(REAL_RESPOSTAS.read_text(encoding="utf-8-sig"))
    assert "respostas" in data or "versao_contrato" in data


def test_real_perfil_json_valid():
    """perfil.usuario.json es JSON válido con diretriz_narrativa."""
    data = json.loads(REAL_PERFIL.read_text(encoding="utf-8-sig"))
    assert "diretriz_narrativa" in data or "faixa_etaria" in data


def test_config_does_not_use_fork_config():
    """El Config NO debe usar el config del fork (evitar ruta relativa)."""
    cfg = narrador_server.Config(str(REAL_CFG))
    assert str(cfg.dir_base).startswith(
        "/run/media/chaos/secundario"
    ), f"dir_base={cfg.dir_base} — está usando fork en vez del juego real"


def test_interpolar_sustituye_variables():
    result = narrador_server.interpolar(
        "Hola {nombre}, tienes {edad} años", {"nombre": "Bella", "edad": "30"}
    )
    assert "Bella" in result
    assert "{edad}" not in result


def test_interpolar_colapsa_blancos_consecutivos():
    result = narrador_server.interpolar("línea1\n\nlínea2\n\n\nlínea3", {})
    assert "línea1" in result and "línea3" in result


def test_crear_prompt_con_pedido_valido():
    cfg = narrador_server.Config(str(REAL_CFG))
    pedido = {"id": "qa-test", "tipo": "pensamiento", "sim_ativo": "Bella Goth",
              "contexto": "humor=alto"}
    prompt = narrador_server.criar_prompt(pedido, cfg)
    assert isinstance(prompt, str)
    assert len(prompt) > 0
    assert "Bella" in prompt


def test_sanitizar_limpia_quebras_y_comillas():
    bruto = '  "Oi\r\n  bairro\t"  '
    assert narrador_server.sanitizar(bruto) == "Oi bairro"


def test_foco_emocional_por_defecto():
    assert narrador_server.obter_foco_emocional("sin tokens") == "O tom deve ser condizente com o humor atual."


def test_procesar_una_vez_sin_pedidos_regresa_cero():
    """Con pedidos vacío, procesar_una_vez devuelve 0 sin escribir nada."""
    cfg = narrador_server.Config(str(REAL_CFG))
    count = narrador_server.procesar_una_vez(cfg)
    assert count == 0


def test_procesar_una_vez_injecta_y_limpia_pedido():
    """Inyectar un pedido en pedidos.json → procesar → respuesta escrita → pedidos vaciado."""
    cfg = narrador_server.Config(str(REAL_CFG))

    # Guardar estado original
    original_pedidos = json.loads(REAL_PEDIDOS.read_text(encoding="utf-8-sig"))

    try:
        # Inyectar pedido de test
        pedido_test = {
            "id": "qa-automated-pedido",
            "tipo": "pensamiento",
            "sim_ativo": "Bella Goth",
            "contexto": "humor=alto, prueba_automática_sin_intervención"
        }
        data = json.loads(REAL_PEDIDOS.read_text(encoding="utf-8-sig"))
        data["pedidos"].append(pedido_test)
        REAL_PEDIDOS.write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")

        # Ejecutar ciclo
        count = narrador_server.procesar_una_vez(cfg)
        assert count == 1, f"Se esperaba 1 procesado, se obtuvo {count}"

        # Verificar pedidos limpiado
        pedidos_after = json.loads(REAL_PEDIDOS.read_text(encoding="utf-8-sig"))
        assert pedidos_after["pedidos"] == [], f"pedidos no vaciado: {pedidos_after['pedidos']}"

        # Verificar resposta escrita
        respostas = json.loads(REAL_RESPOSTAS.read_text(encoding="utf-8-sig"))
        ultima = respostas["respostas"][-1]
        assert ultima["id"] == "qa-automated-pedido"
        assert ultima["tipo"] == "pensamiento"
        assert ultima["sim_ativo"] == "Bella Goth"
        assert "prompt" in ultima
        assert "resposta" in ultima
        assert len(ultima["resposta"]) > 0
        assert "\n" not in ultima["resposta"][:50], "respuesta con saltos de línea"

    finally:
        # Restaurar estado original
        REAL_PEDIDOS.write_text(json.dumps(original_pedidos, ensure_ascii=False, indent=2), encoding="utf-8")
