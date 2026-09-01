"""Configuración pytest compartida."""
import sys
import os
sys.path.insert(0, str(__import__("pathlib").Path(__file__).resolve().parent.parent / "build"))
sys.path.insert(0, str(__import__("pathlib").Path(__file__).resolve().parent.parent))
