using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{

    public static class TradutorDeEventos
    {
        public static string Traduzir(string tipoEvento, IDictionary<string, string> campos)
        {
            string horario = AdaptadorTextoNarrativo.ObterCampo(campos, "horario", "horario_jogo", "horarioJogo");
            string ator = AdaptadorTextoNarrativo.ObterCampo(campos, "ator", "sim", "sim_ativo", "simAtivo");
            string alvo = AdaptadorTextoNarrativo.ObterCampo(campos, "alvo", "target", "destino");
            string descricao = AdaptadorTextoNarrativo.ObterCampo(campos, "descricao", "descrição", "detalhe");

            return Traduzir(tipoEvento, horario, ator, alvo, descricao);
        }

        public static string Traduzir(string tipoEvento, string horarioJogo, string ator, string alvo, string descricao)
        {
            string frase = MontarFraseBase(tipoEvento, ator, alvo, descricao);
            if (string.IsNullOrEmpty(frase))
                return string.Empty;

            string horarioFormatado = AdaptadorTextoNarrativo.FormatarHorario(horarioJogo);
            if (!string.IsNullOrEmpty(horarioFormatado))
                frase = frase + " às " + horarioFormatado;

            if (!frase.EndsWith("."))
                frase += ".";

            return frase;
        }

        private static string MontarFraseBase(string tipoEvento, string ator, string alvo, string descricao)
        {
            if (tipoEvento == "kSocialInteraction")
                return FraseInteracaoSocial(ator, alvo, descricao);

            EventoTheSims3 evento_ts3 = RepositorioEventosTheSims3.Resolver(tipoEvento);
            if (evento_ts3 != null)
            {
                string predicado = AdaptadorTextoNarrativo.NormalizarPredicado(evento_ts3.LegendaPtBr);
                if (!string.IsNullOrEmpty(ator))
                {
                    if (!string.IsNullOrEmpty(alvo) && evento_ts3.IncluirAlvoNaTraducao)
                        return ator + " " + predicado + " com " + alvo;

                    return ator + " " + predicado;
                }

                return AdaptadorTextoNarrativo.PrimeiraMaiuscula(predicado);
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                if (!string.IsNullOrEmpty(ator))
                    return ator + " " + AdaptadorTextoNarrativo.NormalizarPredicado(descricao);

                return AdaptadorTextoNarrativo.PrimeiraMaiuscula(descricao);
            }

            if (!string.IsNullOrEmpty(ator))
                return ator + " vivenciou o evento " + (string.IsNullOrEmpty(tipoEvento) ? "desconhecido" : tipoEvento);

            return "Evento detectado";
        }

        private static string FraseInteracaoSocial(string ator, string alvo, string descricao)
        {
            string detalhe = AdaptadorTextoNarrativo.LimparDescricaoInteracao(descricao);

            if (!string.IsNullOrEmpty(ator) && !string.IsNullOrEmpty(alvo) && !string.IsNullOrEmpty(detalhe))
                return ator + " interagiu com " + alvo + ": " + detalhe;

            if (!string.IsNullOrEmpty(ator) && !string.IsNullOrEmpty(alvo))
                return ator + " interagiu com " + alvo;

            if (!string.IsNullOrEmpty(ator) && !string.IsNullOrEmpty(detalhe))
                return ator + " fez uma interação social: " + detalhe;

            if (!string.IsNullOrEmpty(ator))
                return ator + " fez uma interação social";

            if (!string.IsNullOrEmpty(detalhe))
                return "Interação social: " + detalhe;

            return "Interação social";
        }

    }
}
