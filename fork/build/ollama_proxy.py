#!/usr/bin/env python3
"""Proxy Ollama-compatible para el mod NarradorPorEventos (Sims 3).

Traduce POST /api/generate {model, prompt, stream:false} -> /v1/chat/completions
del gateway llama.cpp en 127.0.0.1:11434, y devuelve {"response": "..."}.
Puerto local: 11500. Sin deps externas.
"""
import json
import urllib.request
from http.server import BaseHTTPRequestHandler, ThreadingHTTPServer

UPSTREAM = "http://127.0.0.1:11434"
DEFAULT_MODEL = "Kateto"


class Handler(BaseHTTPRequestHandler):
    def log_message(self, fmt, *args):  # silencioso
        pass

    def _cors(self):
        self.send_header("Access-Control-Allow-Origin", "*")
        self.send_header("Access-Control-Allow-Headers", "*")

    def do_GET(self):
        if self.path.startswith("/api/tags"):
            body = json.dumps({"models": [{"name": DEFAULT_MODEL}]}).encode()
            self.send_response(200)
            self._cors()
            self.send_header("Content-Type", "application/json")
            self.send_header("Content-Length", str(len(body)))
            self.end_headers()
            self.wfile.write(body)
        else:
            self.send_response(404)
            self.end_headers()

    def do_POST(self):
        if not self.path.startswith("/api/generate"):
            self.send_response(404)
            self.end_headers()
            return

        try:
            length = int(self.headers.get("Content-Length", 0))
            req = json.loads(self.rfile.read(length) or b"{}")
        except Exception:
            self.send_response(400)
            self.end_headers()
            return

        prompt = req.get("prompt", "")
        model = req.get("model") or DEFAULT_MODEL
        # El gateway no conoce "gemma3:12b" -> usar el alias del modelo agéntico de Kateto.
        if model in ("gemma3:12b", "", None):
            model = DEFAULT_MODEL

        payload = json.dumps({
            "model": model,
            "messages": [{"role": "user", "content": prompt}],
            "stream": False,
        }).encode()

        upstream_req = urllib.request.Request(
            UPSTREAM + "/v1/chat/completions",
            data=payload,
            headers={"Content-Type": "application/json"},
            method="POST",
        )
        try:
            with urllib.request.urlopen(upstream_req, timeout=300) as resp:
                data = json.loads(resp.read())
            text = (data.get("choices") or [{}])[0].get("message", {}).get("content", "")
        except Exception as e:
            text = ""
            error = str(e)
        else:
            error = None

        out = json.dumps({"response": text, "done": True}).encode()
        self.send_response(200 if error is None else 502)
        self._cors()
        self.send_header("Content-Type", "application/json")
        self.send_header("Content-Length", str(len(out)))
        self.end_headers()
        self.wfile.write(out)


if __name__ == "__main__":
    server = ThreadingHTTPServer(("127.0.0.1", 11500), Handler)
    print("Ollama proxy on http://127.0.0.1:11500 -> ", UPSTREAM)
    server.serve_forever()
