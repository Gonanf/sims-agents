using NarradorPorEventos.Dominio;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.EventSystem;
using Sims3.UI;
using System;
using System.Collections.Generic;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Aplicacao.Mod;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Dominio.Mod;
using ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Orquestra o fluxo narrativo: converte eventos do jogo, persiste estados,
    /// delega pensamento e conto aos ciclos especializados e processa respostas do servidor externo.
    /// </summary>
    /// <remarks>
    /// <para><b>Fluxo principal:</b></para>
    /// <list type="number">
    /// <item><description>Recebe evento bruto do jogo.</description></item>
    /// <item><description>Converte para <c>EventoNarrativo</c>.</description></item>
    /// <item><description>Resolve tipagem em <c>RepositorioEventosTheSims3</c>.</description></item>
    /// <item><description>Escreve estados por escopo usando <c>EscritorEstadosNarrativos</c>.</description></item>
    /// <item><description>Despacha eventos para ciclos especializados de pensamento e conto.</description></item>
    /// <item><description>Lê respostas externas e notifica no jogo quando aplicável.</description></item>
    /// </list>
    /// </remarks>
    internal sealed class MotorNarrativo
    {
        private const int LimiteCacheNotificacoes = 200;
        private const int LimiteCacheEventosRecentes = 500;

        private ConfiguracaoCentral _config;
        private readonly IAdaptadorArquivos _arquivos;
        private readonly IAdaptadorExcecoesMod _adaptadorExcecoes;
        private readonly Action<RespostaNarrativa> _aoReceberRespostaNarrativa;
        private readonly Action<AcaoDeSim> _aoReceberAcao;
        private EscritorEstadosNarrativos _escritorEstados;
        private RepositorioContextoNarrativoPrevio _repositorioContextoNarrativoPrevio;
        private AnexarPedidoNarrativoCasoDeUso _anexarPedidoNarrativoCasoDeUso;
        private ConsumirRespostasNarrativasCasoDeUso _consumirRespostasNarrativasCasoDeUso;
        private string _caminhoLogNarrativo;
        private ICicloNarrativo[] _ciclosNarrativos;
        private readonly Dictionary<string, DateTime> _chavesNotificadas = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, DateTime> _eventosRecentes = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, DateTime> _interacoesSociaisComAlvoRecentes = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

        public MotorNarrativo(ConfiguracaoCentral config, IAdaptadorArquivos arquivos, IAdaptadorExcecoesMod adaptadorExcecoes, Action<RespostaNarrativa> aoReceberRespostaNarrativa)
            : this(config, arquivos, adaptadorExcecoes, aoReceberRespostaNarrativa, null)
        {
        }

        /// <summary>
        /// fork sims-agents: aoReceberAcao recibe las acciones tipadas (campo `acao` de la
        /// respuesta del LLM) para que el GerenciadorPrincipal las encole en EjecutorDeAcciones.
        /// Se invoca SIEMPRE desde el hilo lógico del juego (LidarComRespostasDoServidor).
        /// </summary>
        public MotorNarrativo(ConfiguracaoCentral config, IAdaptadorArquivos arquivos, IAdaptadorExcecoesMod adaptadorExcecoes, Action<RespostaNarrativa> aoReceberRespostaNarrativa, Action<AcaoDeSim> aoReceberAcao)
        {
            _arquivos = arquivos;
            _adaptadorExcecoes = adaptadorExcecoes;
            _aoReceberRespostaNarrativa = aoReceberRespostaNarrativa;
            _aoReceberAcao = aoReceberAcao;
            AtualizarConfiguracao(config);
        }

        public void AtualizarConfiguracao(ConfiguracaoCentral config)
        {
            if (config == null)
                return;

            _config = config;
            _escritorEstados = new EscritorEstadosNarrativos(_arquivos, _config);
            _repositorioContextoNarrativoPrevio = new RepositorioContextoNarrativoPrevio(_arquivos, _config);
            _anexarPedidoNarrativoCasoDeUso = new AnexarPedidoNarrativoCasoDeUso(_arquivos, _config);
            _consumirRespostasNarrativasCasoDeUso = new ConsumirRespostasNarrativasCasoDeUso(_arquivos, _config);
            _caminhoLogNarrativo = _config.CaminhoLogNarrativo;
            _ciclosNarrativos = new ICicloNarrativo[]
            {
                new CicloNarrativoPensamento(_config),
                new CicloNarrativoConto(_config)
            };
        }

        public void RegistrarEvento(Event e)
        {
            if (!_config.AtivarProcessamentoNarrativo)
                return;

            try
            {
                EventoNarrativo evento = Converter(e);
                if (evento == null)
                    return;

                EventoTheSims3 tipo = RepositorioEventosTheSims3.Resolver(evento.Tipo);
                evento.Descricao = DescreverEvento(e, evento.Ator, evento.Alvo, evento.Tipo, tipo);

                if (string.IsNullOrEmpty(evento.Descricao))
                    return;

                if (DeveIgnorarDuplicidade(evento, e))
                    return;

                _escritorEstados.RegistrarEvento(evento, tipo);
                TentarEnfileirarPedidosNarrativos(evento, tipo);
                LidarComRespostasDoServidor();
            }
            catch (Exception ex)
            {
                _adaptadorExcecoes.RegistrarExcecao("MotorNarrativo.RegistrarEvento", ex, e != null ? e.Id.ToString() : "evento_nulo");
            }
        }

        public void ExecutarCicloProgramado()
        {
            _escritorEstados.RegistrarAtualizacoesDeCabecalhosArquivosEstado();
            LidarComRespostasDoServidor();
        }

        private void LidarComRespostasDoServidor()
        {
            try
            {
                ConsumirRespostasNarrativasSaidaDto saida = _consumirRespostasNarrativasCasoDeUso.Executar(new ConsumirRespostasNarrativasEntradaDto
                {
                    LimparArquivoAposLeitura = true
                });

                if (saida == null || saida.QuantidadeRespostas == 0)
                {
                    EncaminharAccoes(saida);
                    return;
                }

                foreach (RespostaNarrativa resposta in saida.Respostas)
                    ExibirRespostaNoJogo(resposta);

                // fork sims-agents: encaminhar acciones tipadas al EjecutorDeAcciones (hilo del juego)
                EncaminharAccoes(saida);
            }
            catch (Exception ex)
            {
                _adaptadorExcecoes.RegistrarExcecao("MotorNarrativo.LidarComRespostasDoServidor", ex, _config.CaminhoRespostas);
            }
        }

        private void ExibirRespostaNoJogo(RespostaNarrativa resposta)
        {
            if (resposta == null)
                return;

            _repositorioContextoNarrativoPrevio.RegistrarRespostaAnterior(resposta);
            RegistrarLogPromptEResposta(resposta);
            PublicarRespostaParaRecursosVisuais(resposta);

            if (TipoNarrativa.Corresponde(resposta.TipoNarrativa, TipoNarrativa.Pensamento))
            {
                RegistrarLogNarrativo("resposta_pensamento_visual", "tipo=" + (resposta.TipoNarrativa ?? string.Empty) + " | id=" + resposta.IdPedido.Valor);
                return;
            }

            if (!resposta.PodeSerExibidaNoJogo())
            {
                RegistrarLogNarrativo("resposta_suprimida", "tipo=" + (resposta.TipoNarrativa ?? string.Empty) + " | id=" + resposta.IdPedido.Valor + " | resposta=" + resposta.TextoResposta.Valor);
                return;
            }

            string chaveNotificacao = resposta.CriarChaveNotificacao();
            if (JaFoiExibida(chaveNotificacao))
            {
                RegistrarLogNarrativo("resposta_duplicada", "tipo=" + (resposta.TipoNarrativa ?? string.Empty) + " | id=" + resposta.IdPedido.Valor);
                return;
            }

            string mensagem = resposta.CriarMensagemExibicao();

            NotificadorDoMod.Notificar(mensagem, StyledNotification.NotificationStyle.kGameMessagePositive);
            RegistrarNotificacao(chaveNotificacao);
            RegistrarLogNarrativo("resposta_exibida", "tipo=" + (resposta.TipoNarrativa ?? string.Empty) + " | id=" + resposta.IdPedido.Valor + " | mensagem=" + mensagem);
        }

        private void PublicarRespostaParaRecursosVisuais(RespostaNarrativa resposta)
        {
            try
            {
                if (_aoReceberRespostaNarrativa != null)
                    _aoReceberRespostaNarrativa(resposta);
            }
            catch
            {
            }
        }

        /// <summary>
        /// fork sims-agents: entrega al callback las acciones tipadas extraídas de la
        /// respuesta (EjecutorDeAcciones.Encolar vía GerenciadorPrincipal).
        /// </summary>
        private void EncaminharAccoes(ConsumirRespostasNarrativasSaidaDto saida)
        {
            if (saida == null || _aoReceberAcao == null)
                return;

            foreach (AcaoDeSim acao in saida.Acoes)
            {
                try
                {
                    _aoReceberAcao(acao);
                }
                catch (Exception ex)
                {
                    _adaptadorExcecoes.RegistrarExcecao("MotorNarrativo.EncaminharAccoes", ex,
                        acao != null ? acao.Interacao : "acao_nula");
                }
            }
        }

        /// <summary>
        /// fork sims-agents (lazo cerrado): registra la confirmación de ejecución de una
        /// acción social en el log narrativo — es el canal de realimentación al LLM.
        /// </summary>
        public void RegistrarConfirmacionAcao(AcaoDeSim acao)
        {
            if (acao == null)
                return;

            string detalhe = "id=" + acao.IdPedido
                + " | sim_ativo=" + acao.SimAtivo
                + " | interacao=" + acao.Interacao
                + " | alvo=" + acao.Alvo;

            RegistrarLogNarrativo("acao_confirmada", detalhe);
        }

        private bool JaFoiExibida(string chave)
        {
            if (string.IsNullOrEmpty(chave))
                return false;

            DateTime horario;
            return _chavesNotificadas.TryGetValue(chave, out horario);
        }

        private void RegistrarNotificacao(string chave)
        {
            if (string.IsNullOrEmpty(chave))
                return;

            if (_chavesNotificadas.Count >= LimiteCacheNotificacoes)
                _chavesNotificadas.Clear();

            _chavesNotificadas[chave] = DateTime.Now;
        }

        private void RegistrarLogNarrativo(string categoria, string conteudo)
        {
            if (string.IsNullOrEmpty(_caminhoLogNarrativo) || _arquivos == null)
                return;

            AdaptadorContratosJsonNarrativos.AnexarLogNarrativo(_arquivos, _caminhoLogNarrativo, new RegistroLogNarrativoJsonContrato
            {
                HorarioReal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Categoria = categoria ?? string.Empty,
                Detalhe = conteudo ?? string.Empty
            });
        }

        private void RegistrarLogPromptEResposta(RespostaNarrativa resposta)
        {
            if (resposta == null)
                return;

            string prompt = AdaptadorTextoNarrativo.ParaLinhaUnica(resposta.PromptAplicado != null ? resposta.PromptAplicado.TextoFinal.Valor : string.Empty);
            string textoResposta = AdaptadorTextoNarrativo.ParaLinhaUnica(resposta.TextoResposta.Valor);
            string detalhe = "tipo=" + (resposta.TipoNarrativa ?? string.Empty)
                + " | id=" + resposta.IdPedido.Valor
                + " | prompt=" + prompt
                + " | resposta=" + textoResposta;

            RegistrarLogNarrativo("prompt_e_resposta", detalhe);
        }

        private void TentarEnfileirarPedidosNarrativos(EventoNarrativo eventoBase, EventoTheSims3 tipo)
        {
            Sim simAtivo = ConsultaSim.SimAtivo;
            foreach (ICicloNarrativo cicloNarrativo in _ciclosNarrativos)
            {
                PedidoNarrativo pedido = cicloNarrativo.ProcessarEvento(eventoBase, tipo, simAtivo);
                AnexarPedido(pedido);
            }
        }

        private void AnexarPedido(PedidoNarrativo pedido)
        {
            if (pedido == null)
                return;

            _anexarPedidoNarrativoCasoDeUso.Executar(new AnexarPedidoNarrativoEntradaDto
            {
                Pedido = pedido
            });
        }

        private EventoNarrativo Converter(Event e)
        {
            if (e == null)
                return null;

            Sim ator = e.Actor as Sim;
            Sim alvo = e.TargetObject as Sim;
            if (alvo == null)
                alvo = ResolverAlvoDoEvento(e);

            EventoNarrativo evento = new EventoNarrativo();
            evento.Tipo = e.Id.ToString();
            evento.Descricao = string.Empty;
            evento.HorarioJogo = ConsultaDeHorario.HorarioDoJogo;
            evento.Ator = ator;
            evento.Alvo = alvo;
            return evento;
        }

        private static Sim ResolverAlvoDoEvento(Event e)
        {
            object alvo = LeitorPorReflexaoUtil.LerPropriedade(e, "TargetSim")
                       ?? LeitorPorReflexaoUtil.LerPropriedade(e, "mTargetSim")
                       ?? LeitorPorReflexaoUtil.LerPropriedade(e, "OtherSim")
                       ?? LeitorPorReflexaoUtil.LerPropriedade(e, "mOtherSim")
                       ?? LeitorPorReflexaoUtil.LerPropriedade(e, "Target")
                       ?? LeitorPorReflexaoUtil.LerPropriedade(e, "mTarget");

            return alvo as Sim;
        }

        private static string DescreverEvento(Event e, Sim ator, Sim alvo, string tipo, EventoTheSims3 tipoNarrativo)
        {
            string nomeAtor = ConsultaSim.ObterNomeSim(ator);
            string nomeAlvo = ConsultaSim.ObterNomeSim(alvo);

            if (tipo == "kSkillLearnedSkill" || tipo == "kSkillLevelUp")
                return DescreverEventoDeHabilidades(e, nomeAtor, tipo, tipoNarrativo);

            if (tipo == "kSocialInteraction")
            {
                string nomeInteracao = LeitorPorReflexaoUtil.LerTexto(e,
                    "InteractionName", "SocialName", "Interaction", "mInteractionName", "mSocialName");

                if (string.IsNullOrEmpty(nomeAlvo) && string.IsNullOrEmpty(nomeInteracao))
                    return string.Empty;

                if (string.IsNullOrEmpty(nomeInteracao))
                    return string.Format("{0} interagiu com {1}.", nomeAtor, nomeAlvo);

                if (string.IsNullOrEmpty(nomeAlvo))
                    return string.Format("{0} fez interação social: {1}.", nomeAtor, nomeInteracao);

                return string.Format("{0} interagiu com {1}: {2}.", nomeAtor, nomeAlvo, nomeInteracao);
            }

            if (tipoNarrativo != null && !string.IsNullOrEmpty(tipoNarrativo.LegendaPtBr))
            {
                if (!string.IsNullOrEmpty(nomeAtor))
                    return string.Format("{0}: {1}.", nomeAtor, tipoNarrativo.LegendaPtBr);

                return tipoNarrativo.LegendaPtBr + ".";
            }

            if (!string.IsNullOrEmpty(nomeAtor))
                return string.Format("{0} executou {1}.", nomeAtor, tipo);

            return string.Format("evento detectado: {0}.", tipo);
        }

        private static string DescreverEventoDeHabilidades(Event e, string nomeAtor, string tipo, EventoTheSims3 tipoNarrativo)
        {
            string nomeSkill = LeitorPorReflexaoUtil.LerTexto(e,
                "SkillName", "mSkillName", "Skill", "mSkill", "SkillGuid", "mSkillGuid", "Guid");

            float? nivel = LeitorPorReflexaoUtil.LerNumero(e,
                "SkillLevel", "mSkillLevel", "Level", "mLevel", "NewLevel", "mNewLevel");

            string legenda = tipoNarrativo != null ? tipoNarrativo.LegendaPtBr : "evento de habilidade";
            if (string.IsNullOrEmpty(nomeSkill) && !nivel.HasValue)
                return string.Format("{0}: {1}.", nomeAtor, legenda);

            if (tipo == "kSkillLevelUp")
            {
                if (!string.IsNullOrEmpty(nomeSkill) && nivel.HasValue)
                    return string.Format("{0}: {1} no nível {2:F0}.", nomeAtor, nomeSkill, nivel.Value);

                if (!string.IsNullOrEmpty(nomeSkill))
                    return string.Format("{0}: {1} subiu de nível.", nomeAtor, nomeSkill);
            }

            if (!string.IsNullOrEmpty(nomeSkill) && nivel.HasValue)
                return string.Format("{0}: Aprendeu {1} no nível {2:F0}.", nomeAtor, nomeSkill, nivel.Value);

            if (!string.IsNullOrEmpty(nomeSkill))
                return string.Format("{0}: Aprendeu habilidade {1}.", nomeAtor, nomeSkill);

            return string.Format("{0}: {1} (nível {2:F0}).", nomeAtor, legenda, nivel.Value);
        }

        private bool DeveIgnorarDuplicidade(EventoNarrativo evento, Event e)
        {
            if (evento == null)
                return true;

            string chave = CriarChaveEvento(evento);
            if (string.IsNullOrEmpty(chave))
                return false;

            DateTime horario;
            if (_eventosRecentes.TryGetValue(chave, out horario))
                return true;

            _eventosRecentes[chave] = DateTime.Now;
            if (_eventosRecentes.Count > LimiteCacheEventosRecentes)
                _eventosRecentes.Clear();

            if (evento.Tipo != "kSocialInteraction")
                return false;

            string nomeAtor = ConsultaSim.ObterNomeSim(evento.Ator);
            string nomeAlvo = ConsultaSim.ObterNomeSim(evento.Alvo);
            string nomeInteracao = LeitorPorReflexaoUtil.LerTexto(e,
                "InteractionName", "SocialName", "Interaction", "mInteractionName", "mSocialName");

            string chaveSocial = (evento.HorarioJogo ?? string.Empty) + "|" + (nomeAtor ?? string.Empty) + "|" + (nomeInteracao ?? string.Empty);
            if (!string.IsNullOrEmpty(nomeAlvo))
            {
                _interacoesSociaisComAlvoRecentes[chaveSocial] = DateTime.Now;
                if (_interacoesSociaisComAlvoRecentes.Count > LimiteCacheEventosRecentes)
                    _interacoesSociaisComAlvoRecentes.Clear();
                return false;
            }

            return _interacoesSociaisComAlvoRecentes.ContainsKey(chaveSocial);
        }

        private static string CriarChaveEvento(EventoNarrativo evento)
        {
            return (evento.Tipo ?? string.Empty)
                + "|" + (evento.HorarioJogo ?? string.Empty)
                + "|" + ConsultaSim.ObterNomeSim(evento.Ator)
                + "|" + ConsultaSim.ObterNomeSim(evento.Alvo)
                + "|" + (evento.Descricao ?? string.Empty);
        }

    }
}
