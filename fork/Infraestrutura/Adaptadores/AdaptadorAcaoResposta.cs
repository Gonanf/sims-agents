using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    /// <summary>
    /// Parseo puro del campo opcional `acao` de la respuesta narrativa JSON:
    ///   { tipo, resposta, acao: { interacao, alvo, modo: "continuation"|"next", prioridade } }
    /// No toca APIs del juego — 100% testeable sin The Sims 3.
    /// </summary>
    public static class AdaptadorAcaoResposta
    {
        public const string ChaveAcao = "acao";

        public static bool TentarExtrair(Dictionary<string, object> itemResposta, string idPedido,
            string simAtivo, out AcaoDeSim acao)
        {
            acao = null;
            if (itemResposta == null || !itemResposta.ContainsKey(ChaveAcao))
                return false;

            Dictionary<string, object> bruto = itemResposta[ChaveAcao] as Dictionary<string, object>;
            if (bruto == null)
                return false;

            string interacao = AdaptadorJsonNarrativo.LerTexto(bruto, "interacao").Trim();
            if (string.IsNullOrEmpty(interacao))
                return false;

            ModoExecucaoAcao modo = LerModo(bruto);
            PrioridadeAcao prioridade = LerPrioridade(bruto);
            string alvo = AdaptadorJsonNarrativo.LerTexto(bruto, "alvo").Trim();

            acao = AcaoDeSim.Criar(idPedido, simAtivo, interacao, alvo, modo, prioridade);

            // validación básica: acciones con alvo requerido deben traerlo
            EntradaCatalogoAcoes entrada = CatalogoAcoesPermitidas.Resolver(interacao);
            if (entrada != null && entrada.RequiereAlvoSim && string.IsNullOrEmpty(alvo))
            {
                acao.Estado = EstadoAcao.Rejeitada;
                acao.MotivoRejeicao = "alvo_obrigatorio_ausente";
                return false;
            }

            return true;
        }

        public static ModoExecucaoAcao LerModo(Dictionary<string, object> bruto)
        {
            string texto = AdaptadorJsonNarrativo.LerTexto(bruto, "modo");
            if (CatalogoAcoesPermitidas.Normalizar(texto) == "next")
                return ModoExecucaoAcao.Next;
            // default y valor explícito "continuation"
            return ModoExecucaoAcao.Continuation;
        }

        public static PrioridadeAcao LerPrioridade(Dictionary<string, object> bruto)
        {
            string texto = CatalogoAcoesPermitidas.Normalizar(
                AdaptadorJsonNarrativo.LerTexto(bruto, "prioridade"));
            if (texto == "alta") return PrioridadeAcao.Alta;
            if (texto == "baixa") return PrioridadeAcao.Baixa;
            return PrioridadeAcao.Normal;
        }
    }
}
