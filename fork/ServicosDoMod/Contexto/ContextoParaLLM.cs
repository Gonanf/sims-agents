using Sims3.Gameplay.Actors;
using System.Collections.Generic;
using System.Text;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta
{
    public static class ContextoParaLLM
    {
        private delegate string LeitorCampoTexto();
        private delegate int LeitorCampoInteiro();

        public static string SnapshotDoSimAtivo()
        {
            Sim sim = ConsultaSim.SimAtivo;
            if (sim == null) return "[sem sim ativo]";
            return SnapshotDoSim(sim);
        }

        public static string SnapshotDoSim(Sim sim)
        {
            if (sim == null) return "[sim nulo]";

            Dictionary<string, string> cabecalho = SnapshotDoSimEmCampos(sim);
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> par in cabecalho)
                sb.Append(par.Key).Append("=").Append(par.Value).Append(" | ");

            if (sb.Length >= 3)
                sb.Length -= 3;

            return sb.ToString();
        }

        public static Dictionary<string, string> SnapshotDoSimEmCampos(Sim sim)
        {
            Dictionary<string, string> campos = new Dictionary<string, string>();
            if (sim == null)
                return campos;

            DefinirCampoTexto(campos, "identidade", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.IdentidadeEmTexto(sim); });
            DefinirCampoInteiroComoTexto(campos, "idade_codigo", 0, delegate { return ConsultaIdadeDoSim.CodigoFaixaEtaria(sim); });
            DefinirCampoTexto(campos, "idade_limites", string.Empty, delegate { return ConsultaIdadeDoSim.LimitesFaixaEtariaParaLlm(); });
            DefinirCampoInteiroComoTexto(campos, "humor_codigo", 2, delegate { return ConsultaHumorDoSim.CodigoNivelAtual(sim); });
            DefinirCampoTexto(campos, "humor_limites", string.Empty, delegate { return ConsultaHumorDoSim.LimitesNivelHumorParaLlm(); });
            DefinirCampoTexto(campos, "humor_pontuacao_limites", string.Empty, delegate { return ConsultaHumorDoSim.LimitesPontuacaoHumorParaLlm(); });
            DefinirCampoInteiroComoTexto(campos, "classe_economica_codigo", 1, delegate { return ConsultaClasseEconomica.CodigoClasseAtual; });
            DefinirCampoTexto(campos, "classe_economica_limites", string.Empty, delegate { return ConsultaClasseEconomica.LimitesClasseParaLlm(); });
            DefinirCampoTexto(campos, "classe_economica_fundos_limites", string.Empty, delegate { return ConsultaClasseEconomica.LimitesFundosParaLlm(); });
            DefinirCampoInteiroComoTexto(campos, "carreira_codigo", 0, delegate { return ConsultaCarreiraDoSim.CodigoSituacaoCarreira(sim); });
            DefinirCampoTexto(campos, "carreira_limites", string.Empty, delegate { return ConsultaCarreiraDoSim.LimitesSituacaoCarreiraParaLlm(); });
            DefinirCampoTexto(campos, "carreira_nivel_limites", string.Empty, delegate { return ConsultaCarreiraDoSim.LimitesNivelCarreiraParaLlm(); });
            DefinirCampoInteiroComoTexto(campos, "carreira_nivel", 0, delegate { return ConsultaCarreiraDoSim.NivelNaCarreira(sim); });
            DefinirCampoTexto(campos, "habilidade_nivel_limites", string.Empty, delegate { return ConsultaHabilidadesDoSim.LimitesNivelHabilidadeParaLlm(); });
            DefinirCampoTexto(campos, "necessidades_limites", string.Empty, delegate { return ConsultaNecessidadesDoSim.LimitesNecessidadesParaLlm(); });
            DefinirCampoTexto(campos, "necessidades_criticas_limites", string.Empty, delegate { return ConsultaNecessidadesDoSim.LimitesNecessidadesCriticasParaLlm(); });
            DefinirCampoTexto(campos, "estado_emocional", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.EstadoEmocionalEmTexto(sim); });
            DefinirCampoTexto(campos, "vida_pessoal", string.Empty, delegate { return ConsultaSim.ContextoDeVidaPessoal(sim); });
            DefinirCampoTexto(campos, "estado_civil", string.Empty, delegate { return ConsultaSim.EstadoCivilEmTexto(sim); });
            DefinirCampoTexto(campos, "signo", string.Empty, delegate { return ConsultaSim.SignoDoSimEmTexto(sim); });
            DefinirCampoTexto(campos, "preferencia_sexual", string.Empty, delegate { return ConsultaSim.PreferenciaSexualEmTexto(sim); });
            DefinirCampoTexto(campos, "favoritos", string.Empty, delegate { return ConsultaSim.FavoritosEmTexto(sim); });
            DefinirCampoTexto(campos, "cor_favorita", string.Empty, delegate { return ConsultaSim.CorFavoritaEmTexto(sim); });
            DefinirCampoTexto(campos, "peso", string.Empty, delegate { return ConsultaSim.CorpoDoSimEmTexto(sim); });
            DefinirCampoTexto(campos, "tom_de_pele", string.Empty, delegate { return ConsultaSim.TomDePeleDoSimEmTexto(sim); });
            DefinirCampoTexto(campos, "bio_sim", string.Empty, delegate { return ConsultaSim.BioDoSim(sim); });
            DefinirCampoTexto(campos, "particularidades", string.Empty, delegate { return ConsultaSim.ParticularidadesEmTexto(sim); });
            DefinirCampoTexto(campos, "pontos_de_recompensas_duradouras", string.Empty, delegate { return ConsultaSim.PontosDeRecompensasDuradourasEmTexto(sim); });
            DefinirCampoTexto(campos, "relacoes_principais", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.RelacoesPrincipaisEmTexto(sim); });
            DefinirCampoTexto(campos, "necessidades_criticas", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.NecessidadesCriticasEmTexto(sim); });
            DefinirCampoTexto(campos, "necessidades", string.Empty, delegate { return ConsultaNecessidadesDoSim.NecessidadesDoSimEmTexto(sim); });
            DefinirCampoTexto(campos, "habilidades", string.Empty, delegate { return ConsultaHabilidadesDoSim.HabilidadesEmTexto(sim); });
            DefinirCampoTexto(campos, "habilidades_avancadas", string.Empty, delegate { return ConsultaHabilidadesDoSim.HabilidadesAvancadasEmTexto(sim); });
            DefinirCampoTexto(campos, "habilidade_principal", string.Empty, delegate { return ConsultaHabilidadesDoSim.HabilidadePrincipalEmTexto(sim); });
            DefinirCampoInteiroComoTexto(campos, "habilidade_maior_nivel", 0, delegate { return ConsultaHabilidadesDoSim.MaiorNivelDeHabilidade(sim); });
            DefinirCampoInteiroComoTexto(campos, "habilidade_total_nivel_1", 0, delegate { return ConsultaHabilidadesDoSim.QuantidadeDeHabilidadesComNivel(sim, 1); });
            DefinirCampoTexto(campos, "habilidades_resumo", string.Empty, delegate { return ConsultaHabilidadesDoSim.ResumoHabilidadesParaLlm(sim); });
            DefinirCampoTexto(campos, "desejos", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.DesejosEmTexto(sim); });
            DefinirCampoTexto(campos, "ciclo_de_vida", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.CicloDeVidaEmTexto(sim); });
            DefinirCampoTexto(campos, "ambiente_atual", string.Empty, delegate { return ConsultaContextoNarrativoDoSim.AmbienteAtualEmTexto(sim); });

            return campos;
        }

        public static Dictionary<string, string> SnapshotDaFamiliaEmCampos(Sim sim)
        {
            Dictionary<string, string> campos = new Dictionary<string, string>();
            if (sim == null)
                return campos;

            DefinirCampoTexto(campos, "nome", string.Empty, delegate { return ConsultaFamiliaAtiva.NomeDaFamilia(sim); });
            DefinirCampoTexto(campos, "classe", string.Empty, delegate { return ConsultaClasseEconomica.EmTexto(ConsultaClasseEconomica.ClasseDaFamiliaAtual); });
            DefinirCampoInteiroComoTexto(campos, "fundos", 0, delegate { return ConsultaFamiliaAtiva.SimoloeosDaFamiliaAtual; });
            DefinirCampoTexto(campos, "membros", string.Empty, delegate { return ConsultaFamiliaAtiva.MembrosDaFamiliaEmTexto(sim); });
            DefinirCampoInteiroComoTexto(campos, "custo_casa", 0, delegate { return ConsultaFamiliaAtiva.ConsultarValorDoLotePorSim(sim); });
            DefinirCampoTexto(campos, "idades_membros", string.Empty, delegate { return ConsultaFamiliaAtiva.IdadesDosMembrosEmTexto(sim); });
            DefinirCampoTexto(campos, "tracos_membros", string.Empty, delegate { return ConsultaFamiliaAtiva.TracosDosMembrosSeparadosPorBarra(sim); });
            DefinirCampoTexto(campos, "bio_familia", string.Empty, delegate { return ConsultaFamiliaAtiva.BioDaFamilia(sim); });
            DefinirCampoTexto(campos, "resumo", string.Empty, delegate { return ConsultaFamiliaAtiva.ResumoNarrativoDaFamilia(sim); });
            return campos;
        }

        public static string SnapshotDaFamilia(Sim sim)
        {
            if (sim == null) return "[família indisponível]";

            StringBuilder sb = new StringBuilder();
            sb.Append("família=").Append(ConsultaFamiliaAtiva.NomeDaFamilia(sim));
            sb.Append(" | classe=").Append(ConsultaClasseEconomica.EmTexto(ConsultaClasseEconomica.ClasseDaFamiliaAtual));
            sb.Append(" | fundos=").Append(ConsultaFamiliaAtiva.SimoloeosDaFamiliaAtual);
            sb.Append(" | membros=").Append(ConsultaFamiliaAtiva.MembrosDaFamiliaEmTexto(sim));
            return sb.ToString();
        }

        public static string SnapshotDoMundo()
        {
            Sim simAtivo = ConsultaSim.SimAtivo;
            StringBuilder sb = new StringBuilder();
            sb.Append("mundo=").Append(ConsultaMundo.NomeMundoAtual());
            sb.Append(" | tipo_mundo=").Append(ConsultaMundo.TipoMundoAtual());
            sb.Append(" | lotes_comunitários=").Append(ConsultaMundo.ContarLotesComunitarios());
            sb.Append(" | lotes_residenciais=").Append(ConsultaMundo.ContarLotesResidenciais());
            sb.Append(" | população=").Append(ConsultaMundo.ContarSimsResidentes());
            sb.Append(" | sim_ativo_em_viagem=").Append(simAtivo != null && ConsultaMundo.SimEstaEmViagem(simAtivo) ? "true" : "false");
            return sb.ToString();
        }

        public static Dictionary<string, string> SnapshotDoMundoEmCampos()
        {
            Dictionary<string, string> campos = new Dictionary<string, string>();
            DefinirCampoTexto(campos, "nome", string.Empty, delegate { return ConsultaMundo.NomeMundoAtual(); });
            DefinirCampoTexto(campos, "tipo", string.Empty, delegate { return ConsultaMundo.TipoMundoAtual(); });
            DefinirCampoInteiroComoTexto(campos, "lotes_comunitarios", 0, delegate { return ConsultaMundo.ContarLotesComunitarios(); });
            DefinirCampoInteiroComoTexto(campos, "lotes_residenciais", 0, delegate { return ConsultaMundo.ContarLotesResidenciais(); });
            DefinirCampoInteiroComoTexto(campos, "populacao", 0, delegate { return ConsultaMundo.ContarSimsResidentes(); });
            DefinirCampoTexto(campos, "sim_ativo_em_viagem", "false", delegate
            {
                Sim simAtivo = ConsultaSim.SimAtivo;
                return simAtivo != null && ConsultaMundo.SimEstaEmViagem(simAtivo) ? "true" : "false";
            });
            DefinirCampoTexto(campos, "sim_ativo_lote", string.Empty, delegate
            {
                Sim simAtivo = ConsultaSim.SimAtivo;
                return simAtivo == null ? string.Empty : ConsultaAmbiente.LoteAtualEmTexto(simAtivo);
            });
            DefinirCampoTexto(campos, "sim_ativo_subtipo_lote", string.Empty, delegate
            {
                Sim simAtivo = ConsultaSim.SimAtivo;
                return simAtivo == null ? string.Empty : ConsultaAmbiente.SubtipoDoLoteAtualEmTexto(simAtivo);
            });
            DefinirCampoTexto(campos, "familia_ativa", string.Empty, delegate
            {
                Sim simAtivo = ConsultaSim.SimAtivo;
                return simAtivo == null ? string.Empty : ConsultaFamiliaAtiva.ResumoNarrativoDaFamilia(simAtivo);
            });
            DefinirCampoTexto(campos, "sim_ativo_vida_pessoal", string.Empty, delegate
            {
                Sim simAtivo = ConsultaSim.SimAtivo;
                return simAtivo == null ? string.Empty : ConsultaSim.ContextoDeVidaPessoal(simAtivo);
            });
            return campos;
        }

        public static string SnapshotDoLote(Sim sim)
        {
            if (sim == null) return "[lote indisponível]";

            Dictionary<string, string> cabecalho = SnapshotDoLoteEmCampos(sim);
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> par in cabecalho)
                sb.Append(par.Key).Append("=").Append(par.Value).Append(" | ");

            if (sb.Length >= 3)
                sb.Length -= 3;

            return sb.ToString();
        }

        public static Dictionary<string, string> SnapshotDoLoteEmCampos(Sim sim)
        {
            Dictionary<string, string> campos = new Dictionary<string, string>();
            if (sim == null)
                return campos;

            DefinirCampoTexto(campos, "nome_lote", string.Empty, delegate { return ConsultaAmbiente.NomeLoteAtual(sim); });
            DefinirCampoTexto(campos, "descricao_lote", string.Empty, delegate { return ConsultaAmbiente.DescricaoLoteAtual(sim); });
            DefinirCampoTexto(campos, "tipo_lote", string.Empty, delegate { return ConsultaAmbiente.TipoDoLoteEmTexto(ConsultaAmbiente.TipoDoLoteAtual(sim)); });
            DefinirCampoTexto(campos, "subtipo_lote", string.Empty, delegate { return ConsultaAmbiente.SubtipoDoLoteAtualEmTexto(sim); });
            DefinirCampoInteiroComoTexto(campos, "sims_no_lote", 0, delegate { return ConsultaAmbiente.ContarSimsNoLote(sim.LotCurrent); });
            DefinirCampoTexto(campos, "sims_no_lote_nomes", string.Empty, delegate { return ConsultaAmbiente.SimsDoLoteEmTexto(sim, 8); });
            DefinirCampoInteiroComoTexto(campos, "objetos_no_lote", 0, delegate { return ConsultaAmbiente.ContarObjetosNoLoteAtual(sim); });
            DefinirCampoTexto(campos, "limpeza_lote", string.Empty, delegate { return ConsultaAmbiente.EstadoLimpezaLoteEmTexto(sim); });
            DefinirCampoInteiroComoTexto(campos, "camas_no_lote", 0, delegate { return ConsultaAmbiente.ContarCamasNoLoteAtual(sim); });
            DefinirCampoInteiroComoTexto(campos, "geladeiras_no_lote", 0, delegate { return ConsultaAmbiente.ContarGeladeirasNoLoteAtual(sim); });
            DefinirCampoInteiroComoTexto(campos, "tvs_no_lote", 0, delegate { return ConsultaAmbiente.ContarTvsNoLoteAtual(sim); });
            DefinirCampoInteiroComoTexto(campos, "animais_no_lote", 0, delegate { return ConsultaAmbiente.ContarAnimaisNoLoteAtual(sim); });
            DefinirCampoInteiroComoTexto(campos, "zumbis_no_lote", 0, delegate { return ConsultaAmbiente.ContarZumbisNoLoteAtual(sim); });
            DefinirCampoTexto(campos, "ha_ladrao_no_lote", string.Empty, delegate { return ConsultaAmbiente.HaLadraoNoLoteAtual(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "ha_policia_no_lote", string.Empty, delegate { return ConsultaAmbiente.HaPoliciaNoLoteAtual(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "ha_fogo_no_lote", string.Empty, delegate { return ConsultaAmbiente.HaFogoNoLoteAtual(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "tem_estacionamento_valido", string.Empty, delegate { return ConsultaAmbiente.LoteTemEstacionamentoValido(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "lote_em_horario_funcionamento", string.Empty, delegate { return ConsultaAmbiente.LoteEstaEmHorarioDeFuncionamento(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "lote_eh_apartamento", string.Empty, delegate { return ConsultaAmbiente.LoteEhApartamento(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "lote_eh_casa_flutuante", string.Empty, delegate { return ConsultaAmbiente.LoteEhCasaFlutuante(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "sim_em_quarto_publico", string.Empty, delegate { return ConsultaAmbiente.SimEmQuartoPublico(sim) ? "true" : "false"; });
            DefinirCampoTexto(campos, "localidades_proximas", string.Empty, delegate { return ConsultaAmbiente.LocalidadesProximasEmTexto(sim, 3); });
            DefinirCampoTexto(campos, "mundo", string.Empty, delegate { return ConsultaMundo.NomeMundoAtual(); });
            DefinirCampoTexto(campos, "resumo_ambiente", string.Empty, delegate { return ConsultaAmbiente.AmbienteEmTexto(sim); });
            return campos;
        }

        private static void DefinirCampoTexto(Dictionary<string, string> campos, string chave, string padrao, LeitorCampoTexto leitor)
        {
            if (AdaptadorTextoNarrativo.DicionarioNuloOuChaveVazia(campos, chave))
                return;

            string valor = padrao ?? string.Empty;
            try
            {
                if (leitor != null)
                    valor = leitor() ?? string.Empty;
            }
            catch
            {
                valor = padrao ?? string.Empty;
            }

            campos[chave] = valor;
        }

        private static void DefinirCampoInteiroComoTexto(Dictionary<string, string> campos, string chave, int padrao, LeitorCampoInteiro leitor)
        {
            if (AdaptadorTextoNarrativo.DicionarioNuloOuChaveVazia(campos, chave))
                return;

            int valor = padrao;
            try
            {
                if (leitor != null)
                    valor = leitor();
            }
            catch
            {
                valor = padrao;
            }

            campos[chave] = valor.ToString();
        }

        public static string IdentidadeEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.IdentidadeEmTexto(sim);
        }

        public static string EstadoEmocionalEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.EstadoEmocionalEmTexto(sim);
        }

        public static string RelacoesPrincipaísEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.RelacoesPrincipaisEmTexto(sim);
        }

        public static string NecessidadesCriticasEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.NecessidadesCriticasEmTexto(sim);
        }

        public static string DesejosEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.DesejosEmTexto(sim);
        }

        public static string CicloDeVidaEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.CicloDeVidaEmTexto(sim);
        }

        public static string AmbienteAtualEmTexto(Sim sim)
        {
            return ConsultaContextoNarrativoDoSim.AmbienteAtualEmTexto(sim);
        }
    }
}
