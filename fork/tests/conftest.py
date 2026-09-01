"""pytest configuración — no toca archivos del juego real."""
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
sys.path.insert(0, str(ROOT / "build"))

# Evitar importación accidental de narrador_server con el config real del juego
# durante la recolección general. Los tests de narrador_server importan explícitamente
# el módulo y usan REAL_CFG directamente.
