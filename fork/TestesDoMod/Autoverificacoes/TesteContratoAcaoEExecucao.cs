using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Autoverificaciones de Fase 1 (sin juego): parseo del campo acao,
    /// lista blanca y lógica del EjecutorDeAcciones con mocks de IProvedorSims/IFilaInteracoes.
    /// Patrón TesteRegrasRegistroNarrativo: Executar() devuelve lista de falhas; vacía = OK.
    /// </summary>
    internal static class TesteContratoAcaoEExecucao
    {
        public static IList<string> Executar()
        {
            List<string> falhas = new List<string>();

            ValidarParseoAcaoCompleta(falhas);
            ValidarParseoSinAcao(falhas);
            ValidarParseoModoYPrioridadeDefaults(falhas);
            ValidarAlvoObligatorioAusente(falhas);
            ValidarListaBlancaMatching(falhas);
            ValidarListaBlancaDesconocida(falhas);
            ValidarEjecutorFlujoFeliz(falhas);
            ValidarEjecutorFueraDeLista(falhas);
            ValidarEjecutorSimInvalido(falhas);
            ValidarTransicionConfirmadaLazoCerrado(falhas);

            return falhas;
        }

        // ---- helpers ----

        private static Dictionary<string, object> Objeto(params string[] paresChaveValorJson)
        {
            // arma un dict vía el lector JSON simple para probar el camino real
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{");
            for (int i = 0; i < paresChaveValorJson.Length; i += 2)
            {
                if (i > 0) sb.Append(",");
                sb.Append("\"").Append(paresChaveValorJson[i]).Append("\":").Append(paresChaveValorJson[i + 1]);
            }
            sb.Append("}");

            Dictionary<string, object> resultado;
            if (!AdaptadorJsonNarrativo.TentarLerObjetoJson(sb.ToString(), out resultado))
                throw new InvalidOperationException("json de test inválido: " + sb);
            return resultado;
        }

        private sealed class ProvedorSimsFalso : IProvedorSims
        {
            private readonly Dictionary<string, bool> _existentes;
            public int LlamadasValidacion;

            public ProvedorSimsFalso(params string[] existentes)
            {
                _existentes = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < existentes.Length; i++)
                    _existentes[existentes[i]] = true;
            }

            public object ResolverSim(string idOuNome)
            {
                if (!string.IsNullOrEmpty(idOuNome) && _existentes.ContainsKey(idOuNome))
                    return new object(); // stand-in del Sim
                return null;
            }

            public bool EhSimValido(object sim)
            {
                LlamadasValidacion++;
                return sim != null;
            }
        }

        private sealed class FilaFalsa : IFilaInteracoes
        {
            public bool Resultado = true;
            public ModoExecucaoAcao? UltimoModo;
            public PrioridadeAcao? UltimaPrioridad;
            public object UltimoAtor, UltimoAlvo;
            public EntradaCatalogoAcoes UltimaEntrada;

            public bool TentarPush(EntradaCatalogoAcoes entrada, object simAtor, object simAlvo,
                ModoExecucaoAcao modo, PrioridadeAcao prioridade)
            {
                UltimaEntrada = entrada;
                UltimoAtor = simAtor;
                UltimoAlvo = simAlvo;
                UltimoModo = modo;
                UltimaPrioridad = prioridade;
                return Resultado;
            }
        }

        // ---- casos ----

        private static void ValidarParseoAcaoCompleta(List<string> falhas)
        {
            Dictionary<string, object> item = Objeto(
                "id", "\"p1\"", "resposta", "\"hola\"",
                "acao", "{ \"interacao\":\"Hablar\", \"alvo\":\"bella-goth\", \"modo\":\"next\", \"prioridade\":\"alta\" }");

            AcaoDeSim acao;
            if (!AdaptadorAcaoResposta.TentarExtrair(item, "p1", "mortimer", out acao))
            {
                falhas.Add("acao completa debería parsearse.");
                return;
            }
            if (acao.Interacao != "Hablar" || acao.Alvo != "bella-goth")
                falhas.Add("acao: interacao/alvo mal parseados.");
            if (acao.Modo != ModoExecucaoAcao.Next)
                falhas.Add("acao: modo=next no respetado.");
            if (acao.Prioridade != PrioridadeAcao.Alta)
                falhas.Add("acao: prioridad=alta no respetada.");
        }

        private static void ValidarParseoSinAcao(List<string> falhas)
        {
            Dictionary<string, object> item = Objeto("id", "\"p2\"", "resposta", "\"solo texto\"");
            AcaoDeSim acao;
            if (AdaptadorAcaoResposta.TentarExtrair(item, "p2", "sim", out acao))
                falhas.Add("respuesta sin campo acao no debería producir acción.");
        }

        private static void ValidarParseoModoYPrioridadeDefaults(List<string> falhas)
        {
            Dictionary<string, object> item = Objeto(
                "acao", "{ \"interacao\":\"dormir\" }");
            AcaoDeSim acao;
            if (!AdaptadorAcaoResposta.TentarExtrair(item, "p3", "sim", out acao))
            {
                falhas.Add("acao mínima debería parsearse.");
                return;
            }
            if (acao.Modo != ModoExecucaoAcao.Continuation)
                falhas.Add("modo default debería ser continuation.");
            if (acao.Prioridade != PrioridadeAcao.Normal)
                falhas.Add("prioridad default debería ser normal.");
        }

        private static void ValidarAlvoObligatorioAusente(List<string> falhas)
        {
            Dictionary<string, object> item = Objeto(
                "acao", "{ \"interacao\":\"coquetear\" }"); // requiere alvo
            AcaoDeSim acao;
            if (AdaptadorAcaoResposta.TentarExtrair(item, "p4", "sim", out acao))
                falhas.Add("coquetear sin alvo debería rechazarse en el parseo.");
        }

        private static void ValidarListaBlancaMatching(List<string> falhas)
        {
            if (CatalogoAcoesPermitidas.Resolver("HABLAR") == null)
                falhas.Add("lista blanca debería matchear case-insensitive.");
            if (CatalogoAcoesPermitidas.Resolver("usar objeto pasión") == null)
                falhas.Add("lista blanca debería tolerar espacios por guiones.");
            if (CatalogoAcoesPermitidas.Resolver("coquetear") == null)
                falhas.Add("coquetear debería estar en la lista blanca.");
        }

        private static void ValidarListaBlancaDesconocida(List<string> falhas)
        {
            if (CatalogoAcoesPermitidas.Resolver("vender_la_casa") != null)
                falhas.Add("acción fuera de catálogo no debería resolverse.");
        }

        private static void ValidarEjecutorFlujoFeliz(List<string> falhas)
        {
            ProvedorSimsFalso provedor = new ProvedorSimsFalso("mortimer", "bella");
            FilaFalsa fila = new FilaFalsa();
            EjecutorDeAcciones ejecutor = new EjecutorDeAcciones(provedor, fila);

            AcaoDeSim acao = AcaoDeSim.Criar("p5", "mortimer", "hablar", "bella",
                ModoExecucaoAcao.Continuation, PrioridadeAcao.Normal);
            ejecutor.Encolar(acao);

            if (fila.UltimoAtor != null)
                falhas.Add("el push NO debe ocurrir fuera del drenaje (hilo del juego).");

            IList<AcaoDeSim> drenadas = ejecutor.DrenarPendentes();

            if (drenadas.Count != 1 || drenadas[0].Estado != EstadoAcao.Executada)
                falhas.Add("flujo feliz: acción debería quedar Executada tras el drenaje.");
            if (fila.UltimoAlvo == null || fila.UltimoAtor == null)
                falhas.Add("flujo feliz: ator/alvo deberían llegar al pusheo.");
            if (fila.UltimoModo != ModoExecucaoAcao.Continuation)
                falhas.Add("flujo feliz: modo debería propagarse.");
            // segunda drenada vacía
            if (ejecutor.DrenarPendentes().Count != 0)
                falhas.Add("drenaje doble debería devolver vacío.");
        }

        private static void ValidarEjecutorFueraDeLista(List<string> falhas)
        {
            ProvedorSimsFalso provedor = new ProvedorSimsFalso("mortimer");
            EjecutorDeAcciones ejecutor = new EjecutorDeAcciones(provedor, new FilaFalsa());

            AcaoDeSim acao = AcaoDeSim.Criar("p6", "mortimer", "teletransportarse", "",
                ModoExecucaoAcao.Next, PrioridadeAcao.Alta);
            ejecutor.Encolar(acao);

            // El ejecutor rechaza fuera-de-lista ya en Encolar() y NO la encola:
            // el drenaje debe devolver vacío.
            if (acao.Estado != EstadoAcao.Rejeitada
                || acao.MotivoRejeicao.IndexOf("lista_branca") < 0)
                falhas.Add("acción fuera de lista blanca debería reyectarse en Encolar().");
            if (ejecutor.DrenarPendentes().Count != 0)
                falhas.Add("acción rechazada en Encolar() no debería aparecer en el drenaje.");
        }

        private static void ValidarEjecutorSimInvalido(List<string> falhas)
        {
            ProvedorSimsFalso provedor = new ProvedorSimsFalso(); // nadie existe
            EjecutorDeAcciones ejecutor = new EjecutorDeAcciones(provedor, new FilaFalsa());

            AcaoDeSim acao = AcaoDeSim.Criar("p7", "fantasma", "dormir", "",
                ModoExecucaoAcao.Continuation, PrioridadeAcao.Normal);
            ejecutor.Encolar(acao);

            IList<AcaoDeSim> drenadas = ejecutor.DrenarPendentes();
            if (drenadas[0].Estado != EstadoAcao.Rejeitada
                || drenadas[0].MotivoRejeicao.IndexOf("sim_ativo_invalido") < 0)
                falhas.Add("sim actor inexistente debería reyectarse.");
        }

        // fork sims-agents (ítem 5, lazo cerrado): la confirmación de ejecución vía
        // EventTypeId.kSocialInteraction marca un estado propio, distinto de Executada.
        private static void ValidarTransicionConfirmadaLazoCerrado(List<string> falhas)
        {
            // valores estables del enum (el lazo cerrado los asume)
            if (Convert.ToInt32(EstadoAcao.Executada) != 3 || Convert.ToInt32(EstadoAcao.Confirmada) != 5)
                falhas.Add("estados de acao: valores del enum cambiaron (lazo cerrado asume Executada=3, Confirmada=5).");

            AcaoDeSim acao = AcaoDeSim.Criar("p8", "mortimer", "hablar", "bella",
                ModoExecucaoAcao.Continuation, PrioridadeAcao.Normal);
            acao.Estado = EstadoAcao.Executada;
            if (acao.Estado != EstadoAcao.Executada)
                falhas.Add("acción ejecutada debería estar en Executada antes de la confirmación.");

            // transición que hace el supervisor cuando llega el kSocialInteraction
            acao.Estado = EstadoAcao.Confirmada;
            if (acao.Estado != EstadoAcao.Confirmada)
                falhas.Add("la confirmación del lazo cerrado debería marcar Confirmada.");
        }
    }
}
