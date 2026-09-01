"""Tests para package_mod.py — validación idempotente del .package."""
import sys
import subprocess
from pathlib import Path
import pytest

ROOT = Path(__file__).resolve().parent.parent
Dll = ROOT / "build/ZZZZitalo.TS3Mods.NarradorPorEventos.dll"
Pkg = ROOT / "build/ZZZZitalo.TS3Mods.NarradorPorEventos.package"
Script = ROOT / "build/package_mod.py"


def test_package_mod_py_exists():
    assert Script.exists()


def test_dll_exists_for_packaging():
    assert Dll.exists(), "La DLL debe existir antes de empaquetar"
    assert Dll.stat().st_size > 0


def test_build_package_succeeds():
    result = subprocess.run(
        [sys.executable, str(Script)], cwd=str(ROOT), capture_output=True, text=True, timeout=60
    )
    assert result.returncode == 0, f"package_mod.py falló: {result.stdout}\\n{result.stderr}"
    assert Pkg.exists(), "El .package no se generó"


def test_validate_function_exists():
    ns = {}
    exec(Script.read_text(), ns)
    assert "validate" in ns, "Falta la función validate()"


def test_package_file_is_dbpf():
    data = Pkg.read_bytes()
    assert data[:4] == b"DBPF", f"No es DBPF: {data[:4]!r}"


def test_validate_passes():
    ns = {}
    exec(Script.read_text(), ns)
    ns["validate"](Pkg)


def test_package_idempotent():
    """Re-correr package_mod.py produce el mismo tamaño (determinista)."""
    import hashlib
    original = Pkg.read_bytes()
    subprocess.run(
        [sys.executable, str(Script)], cwd=str(ROOT), capture_output=True, text=True, timeout=60
    )
    recreated = Pkg.read_bytes()
    assert hashlib.sha256(original).hexdigest() == hashlib.sha256(recreated).hexdigest(), "package no determinista"


def test_s3sa_byte_identical():
    """El recurso S3SA dentro del .package debe ser byte-identical a la DLL."""
    data = Pkg.read_bytes()
    import struct
    idx_pos = struct.unpack_from("<I", data, 64)[0]
    count = struct.unpack_from("<I", data, 36)[0]
    t, g, ih, il, pos, size, mem, comp = struct.unpack_from("<8I", data, idx_pos + 4)
    assert t == 0x40E1FA25, "Tipo de recurso incorrecto"
    s3sa = data[pos:pos + mem]
    assert s3sa[:4] == b"S3SA"
    inner = s3sa[4:8]
    inner_len = int.from_bytes(inner, "little")
    dll_bytes = Dll.read_bytes()
    assert inner_len == len(dll_bytes), f"Largo interno {inner_len} != DLL {len(dll_bytes)}"
    assert s3sa[8:8 + len(dll_bytes)] == dll_bytes, "S3SA contenido no byte-identical a DLL"
