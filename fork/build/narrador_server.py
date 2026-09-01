#!/usr/bin/env python3
"""NarradorEngine.Server reimplentado en Python.

Lee NarradorPorEventos.pedidos.json (escrito por el mod TS3), arma el prompt con
los templates del config, llama al gateway llama.cpp (OpenAI-compatible) y escribe
NarradorPorEventos.respostas.json para que el mod los consuma y muestre globos.

Uso: python3 narrador_server.py <ruta_config_json>
"""
import json
import re
import sys
import time
import urllib.request
from datetime import datetime
from pathlib import Path

MAPS_DIR = Path(__file__).parent
UPSTREAM = "http://127.0.0.1:11434/v1/chat/completions"
DEFAULT_MODEL = "Kateto"

# ── mapas extraídos del C# ─────────────────────────────────────────────
_foco = json.load(open(MAPS_DIR / "server_maps.json", encoding="utf-8"))["foco_emocional"]
_diretrizes_tracos = json.load(open(MAPS_DIR / "diretriz_tracos.json", encoding="utf-8"))

FOCO_DEFAULT = "O tom deve ser condizente com o humor atual."


def obter_foco_emocional(contexto: str) -> str:
    for chave, texto in _foco.items():
        if chave in contexto:
            return texto
    return FOCO_DEFAULT


def obter_diretriz_tracos(contexto: str) -> str:
    partes = [d["text"] for d in _diretrizes_tracos
              if any(k in contexto for k in d["keys"])]
    return " ".join(partes).strip()


# ── config ────────────────────────────────────────────────────────────
class Config:
    def __init__(self, path: str):
        self.path = Path(path)
        self.mtime = 0.0
        self.reload()

    def reload(self):
        mtime = self.path.stat().st_mtime
        if mtime == self.mtime:
            return False
        self.mtime = mtime
        c = json.loads(self.path.read_text(encoding="utf-8-sig"))
        self.raw = c
        self.dir_base = self.path.parent

        def expand(p):
            return Path(p.replace("%USERPROFILE%", str(self.path.parents[3])))

        docs_mod = expand(c.get("diretorio.documentos_mod",
                                str(self.dir_base))) if isinstance(c.get("diretorio.documentos_mod"), str) else self.dir_base
        # documentos_mod apunta a Documents\...\Mods\NarradorPorEventos — usar la MISMA carpeta del config
        self.docs_mod = self.dir_base
        arq = c.get("arquivo", {})
        self.pedidos = self.dir_base / arq.get("arquivo.pedidos", "NarradorPorEventos.pedidos.json") if False else self.dir_base / arq.get("pedidos", "NarradorPorEventos.pedidos.json")
        self.respostas = self.dir_base / arq.get("respostas", "NarradorPorEventos.respostas.json")
        self.perfil = self.dir_base / arq.get("perfil_usuario", "NarradorPorEventos.perfil.usuario.json")
        self.contexto_previo_path = self.dir_base / arq.get("contexto_previo", "NarradorPorEventos.contexto.previo.json")
        self.poll_ms = int(c.get("servidor.intervalo_poll_ms", 10000))
        self.timeout = int(c.get("ollama.timeout_segundos", 45))
        self.modelo = c.get("ollama.modelo", DEFAULT_MODEL)
        if self.modelo in ("gemma3:12b", ""):
            self.modelo = DEFAULT_MODEL
        self.opcoes = c.get("ollama.opcoes", {})
        self.incluir_contexto_previo = bool(c.get("feature.incluir_contexto_previo", False))
        self.templates = c.get("prompt", {})
        self.vars_prompt = {k: str(v) for k, v in c.get("prompt.variaveis", {}).items()}
        self.perfil_usuario = c.get("perfil_usuario", {})
        return True

    def get(self, dotted, default=None):
        node = self.raw
        for part in dotted.split("."):
            if not isinstance(node, dict) or part not in node:
                return default
            node = node[part]
        return node


def interpolar(template: str, vars_: dict) -> str:
    def sub(m):
        return str(vars_.get(m.group(1), m.group(0)))
    out = re.sub(r"\{([a-z_]+)\}", sub, template)
    # colapsar líneas vacías dobles
    linhas = [l for l in out.splitlines()]
    res, prev_blank = [], False
    for l in linhas:
        blank = not l.strip()
        if blank and prev_blank:
            continue
        res.append(l)
        prev_blank = blank
    return "\n".join(res).strip()


def criar_prompt(pedido: dict, cfg: Config) -> str:
    tipo = pedido.get("tipo", "")
    eh_pensamento = "pensamento" in tipo.lower()
    template_key = "prompt.pensamento.template" if eh_pensamento else "prompt.conto.template"
    template_lines = cfg.get(template_key, [])
    template = "\n".join(template_lines)

    contexto = pedido.get("contexto", "")
    diretriz_perfil = ler_diretriz_ativa(cfg)
    foco = obter_foco_emocional(contexto)
    tracos = obter_diretriz_tracos(contexto)

    vars_ = dict(cfg.vars_prompt)
    vars_["sim_ativo"] = pedido.get("sim_ativo", "")
    vars_["contexto"] = contexto
    vars_["diretriz_perfil_formatada"] = f"{cfg.vars_prompt.get('rotulo_diretriz_perfil','Directriz')}: {diretriz_perfil}" if diretriz_perfil else ""
    vars_["foco_emocional_formatada"] = f"{cfg.vars_prompt.get('rotulo_foco_emocional','Foco')}: {foco}" if foco else ""
    vars_["diretriz_por_tracos"] = tracos
    vars_["bloco_contextual"] = "\n".join(x for x in [
        vars_["diretriz_perfil_formatada"], "", vars_["foco_emocional_formatada"],
        ("Diretrices de personalidad: " + tracos) if tracos else "", "", contexto,
    ] if x.strip() != "" or x == "")

    return interpolar(template, vars_)


def ler_diretriz_ativa(cfg: Config) -> str:
    """La diretriz generada vive en el perfil.usuario.json (campo diretriz)."""
    try:
        p = json.loads(cfg.perfil.read_text(encoding="utf-8-sig"))
        return (p.get("diretriz_narrativa") or p.get("diretriz") or "").strip()
    except Exception:
        pass
    # fallback: template fallback del config
    fb = cfg.get("prompt.perfil.template_fallback", [])
    if fb:
        v = dict(cfg.vars_prompt)
        pu = cfg.perfil_usuario
        v.setdefault("faixa_etaria", str(pu.get("faixa_etaria", "")))
        v.setdefault("personalidades_narrador", ",".join(pu.get("personalidades_narrador", [])))
        v.setdefault("estilos_criativos", ",".join(pu.get("estilos_criativos", [])))
        v.setdefault("conteudos_permitidos", ",".join(pu.get("conteudos_permitidos", [])))
        v.setdefault("conteudos_bloqueados", ",".join(pu.get("conteudos_bloqueados", [])))
        return interpolar("\n".join(fb), v).replace("\n", " ")
    return ""


def llamar_llm(prompt: str, cfg: Config) -> str:
    payload = json.dumps({
        "model": cfg.modelo,
        "messages": [{"role": "user", "content": prompt}],
        "stream": False,
        "temperature": cfg.opcoes.get("temperature", 0.8),
        "top_p": cfg.opcoes.get("top_p", 0.9),
    }).encode()
    req = urllib.request.Request(UPSTREAM, data=payload,
                                 headers={"Content-Type": "application/json"}, method="POST")
    with urllib.request.urlopen(req, timeout=600) as r:
        data = json.loads(r.read())
    return ((data.get("choices") or [{}])[0].get("message", {}).get("content", "") or "").strip()


def sanitizar(texto: str) -> str:
    t = re.sub(r"\s*\n\s*", " ", texto.strip())
    t = t.strip('"').strip()
    return t[:600]


def main():
    cfg_path = sys.argv[1] if len(sys.argv) > 1 else "/run/media/chaos/secundario/proyectos/Games/thesims3/drive_c/users/chaos/Documents/Electronic Arts/The Sims 3/Mods/NarradorPorEventos/NarradorPorEventos.config.json"
    cfg = Config(cfg_path)
    print(f"[narrador-server] config={cfg.path}")
    print(f"[narrador-server] pedidos={cfg.pedidos}")
    print(f"[narrador-server] respostas={cfg.respostas}")
    print(f"[narrador-server] modelo={cfg.modelo} upstream={UPSTREAM}")

    while True:
        try:
            if cfg.reload():
                print(f"[narrador-server] config recargado")
            procesados = procesar_una_vez(cfg)
            if procesados:
                print(f"[{datetime.now():%H:%M:%S}] respuestas escritas: {procesados}")
        except Exception as e:
            print(f"[narrador-server] error ciclo: {e}")
        time.sleep(cfg.poll_ms / 1000)


def procesar_una_vez(cfg: Config) -> int:
    try:
        env_pedidos = json.loads(cfg.pedidos.read_text(encoding="utf-8-sig"))
    except FileNotFoundError:
        return 0
    except json.JSONDecodeError:
        return 0
    pedidos = env_pedidos.get("pedidos") or []
    if not pedidos:
        return 0

    respostas = []
    for pedido in pedidos:
        if not pedido.get("id") or not pedido.get("tipo") or not pedido.get("contexto"):
            continue
        prompt = criar_prompt(pedido, cfg)
        texto = llamar_llm(prompt, cfg)
        texto = sanitizar(texto)
        if not texto:
            continue
        respostas.append({
            "id": pedido["id"],
            "tipo": pedido["tipo"],
            "sim_ativo": pedido.get("sim_ativo", ""),
            "horario_real": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
            "prompt": prompt,
            "resposta": texto,
        })

    envelope = {
        "versao_contrato": "1.0",
        "gerado_em": datetime.utcnow().strftime("%Y-%m-%dT%H:%M:%SZ"),
        "respostas": respostas,
    }
    cfg.respostas.write_text(json.dumps(envelope, ensure_ascii=False, indent=2), encoding="utf-8")
    # purgar pedidos
    cfg.pedidos.write_text('{\n  "versao_contrato": "1.0",\n  "pedidos": []\n}', encoding="utf-8")
    return len(respostas)


if __name__ == "__main__":
    main()
