using Battery.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Chaves aceitas no arquivo <c>NarradorPorEventos.config.json</c>.
    /// </summary>
    public static class ChavesConfiguracao
    {
        public const string FeatureProcessamentoNarrativo = "feature.processamento_narrativo";
        public const string FeatureRecursosVisuaisCabecaSimFixa = "feature.recursos_visuais.cabeca_sim_fixa";
        public const string FeatureRecursosVisuaisTextoNarrativo = "feature.recursos_visuais.texto_narrativo_sobre_cabeca";

        public const string IntervaloPersistenciaHoras = "intervalo.persistencia_horas";
        public const string IntervaloHotReloadMs = "servidor.intervalo_poll_ms";
        public const string LogarHotReload = "servidor.logar_hotreload";
        public const string QuantidadeEventosPensamento = "narrativa.quantidade_eventos_pensamento";
        public const string QuantidadeEventosConto = "narrativa.quantidade_eventos_conto";
        public const string LimiteResumoPensamento = "narrativa.limite_resumo_pensamento";
        public const string LimiteResumoConto = "narrativa.limite_resumo_conto";
        public const string LimiteCaracteresContexto = "narrativa.limite_caracteres_contexto";

        public const string ArquivoEstadoMundo = "arquivo.estado_mundo";
        public const string ArquivoEstadoLoteTemplate = "arquivo.estado_lote_template";
        public const string ArquivoEstadoFamiliaTemplate = "arquivo.estado_familia_template";
        public const string ArquivoEstadoSimTemplate = "arquivo.estado_sim_template";
        public const string ArquivoPedidos = "arquivo.pedidos";
        public const string ArquivoRespostas = "arquivo.respostas";
        public const string ArquivoPerfilUsuario = "arquivo.perfil_usuario";
        public const string ArquivoContextoPrevio = "arquivo.contexto_previo";
        public const string ArquivoLogNarrativo = "arquivo.log_narrativo";
        public const string ArquivoLogExcecoes = "arquivo.log_excecoes";
        public const string ArquivoLogVerbose = "arquivo.log_verbose";

        public const string FeatureLogVerbose = "feature.log_verbose";

        public const string OllamaUrl = "ollama.url";
        public const string OllamaModelo = "ollama.modelo";
        public const string OllamaTimeoutSegundos = "ollama.timeout_segundos";

        public const string DiretorioDocumentosMod = "diretorio.documentos_mod";
    }

    public interface IAdaptadorArquivos
    {
        bool VerificarCaminhoExiste(string caminho);
        string LerTexto(string caminho);
        void EscreverTexto(string caminho, string conteudo);
        string ObterDiretorioDoMod();
    }

    /// <summary>
    /// Adaptador IO dual: usa S3SE (Battery.Utility) por reflexión cuando el loader
    /// está instalado, y si no, fallback System.IO con rutas absolutas (patrón NRaas).
    /// Así el mod funciona standalone sin dependencia dura de S3SE.
    /// </summary>
    public sealed class AdaptadorArquivosS3SE : IAdaptadorArquivos
    {
        private static bool _modoS3SEDeterminado;
        private static bool _usarS3SE;
        private static string _diretorioBaseFallback;

        private static bool UsarS3SE()
        {
            if (!_modoS3SEDeterminado)
            {
                Type tipo = Type.GetType("Battery.Utility.S3SE, Battery.Utility");
                if (tipo == null)
                    tipo = BuscarTipoCargado("Battery.Utility.S3SE");

                object inicializado = null;
                if (tipo != null)
                    inicializado = LeitorPorReflexaoUtil.LerEstatico(tipo, "IsInitialized");

                _usarS3SE = tipo != null && inicializado is bool && (bool)inicializado;
                _modoS3SEDeterminado = true;

                // Fallback: Documents/Electronic Arts/{The,Los} Sims 3/Mods/NarradorPorEventos
                // ponytail: detecta locale ES (Los) vs EN (The); prefiere el que ya existe en disco.
                if (!_usarS3SE && string.IsNullOrEmpty(_diretorioBaseFallback))
                {
                    try
                    {
                        string documentos = Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments);
                        string baseEA = System.IO.Path.Combine(documentos, "Electronic Arts");
                        string pathThe = System.IO.Path.Combine(
                            System.IO.Path.Combine(System.IO.Path.Combine(baseEA, "The Sims 3"), "Mods"), "NarradorPorEventos");
                        string pathLos = System.IO.Path.Combine(
                            System.IO.Path.Combine(System.IO.Path.Combine(baseEA, "Los Sims 3"), "Mods"), "NarradorPorEventos");
                        bool existsThe = System.IO.Directory.Exists(pathThe);
                        bool existsLos = System.IO.Directory.Exists(pathLos);
                        // Preferir el que ya existe; si ambos existen, Los (instalación ES activa)
                        if (existsLos && !existsThe) _diretorioBaseFallback = pathLos;
                        else if (existsLos && existsThe) _diretorioBaseFallback = pathLos;
                        else if (existsThe) _diretorioBaseFallback = pathThe;
                        else _diretorioBaseFallback = pathLos; // crear Los por defecto en Wine ES
                        if (!System.IO.Directory.Exists(_diretorioBaseFallback))
                            System.IO.Directory.CreateDirectory(_diretorioBaseFallback);
                    }
                    catch
                    {
                        _diretorioBaseFallback = ".";
                    }
                }
            }

            return _usarS3SE;
        }

        private static Type BuscarTipoCargado(string nomeCompleto)
        {
            System.Reflection.Assembly[] ensamblados = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < ensamblados.Length; i++)
            {
                Type t = ensamblados[i].GetType(nomeCompleto, false);
                if (t != null)
                    return t;
            }
            return null;
        }

        private static string CaminhoAbsoluto(string caminho)
        {
            if (System.IO.Path.IsPathRooted(caminho))
                return caminho;
            return System.IO.Path.Combine(ObterBase(), caminho);
        }

        private static string ObterBase()
        {
            return UsarS3SE() ? "." : (_diretorioBaseFallback ?? ".");
        }

        public bool VerificarCaminhoExiste(string caminho)
        {
            try
            {
                if (!UsarS3SE())
                    return System.IO.File.Exists(CaminhoAbsoluto(caminho));

                Type tipo = Type.GetType("Battery.Utility.S3SE, Battery.Utility")
                    ?? BuscarTipoCargado("Battery.Utility.S3SE");
                if (tipo == null)
                    return false;

                Type tipoFile = tipo.GetNestedType("IO").GetNestedType("File");
                object resultado = LeitorPorReflexaoUtil.InvocarMetodoEstatico(tipoFile, "Exists",
                    new object[] { CaminhoAbsoluto(caminho) });
                return resultado is bool && (bool)resultado;
            }
            catch
            {
                return false;
            }
        }

        public string LerTexto(string caminho)
        {
            if (!UsarS3SE())
                return System.IO.File.ReadAllText(CaminhoAbsoluto(caminho));

            Type tipo = Type.GetType("Battery.Utility.S3SE, Battery.Utility")
                ?? BuscarTipoCargado("Battery.Utility.S3SE");
            Type tipoFile = tipo.GetNestedType("IO").GetNestedType("File");
            return (string)LeitorPorReflexaoUtil.InvocarMetodoEstatico(tipoFile, "ReadAllText",
                new object[] { CaminhoAbsoluto(caminho) });
        }

        public void EscreverTexto(string caminho, string conteudo)
        {
            if (!UsarS3SE())
            {
                string absoluto = CaminhoAbsoluto(caminho);
                string pasta = System.IO.Path.GetDirectoryName(absoluto);
                if (!string.IsNullOrEmpty(pasta) && !System.IO.Directory.Exists(pasta))
                    System.IO.Directory.CreateDirectory(pasta);
                System.IO.File.WriteAllText(absoluto, conteudo);
                return;
            }

            Type tipo = Type.GetType("Battery.Utility.S3SE, Battery.Utility")
                ?? BuscarTipoCargado("Battery.Utility.S3SE");
            Type tipoFile = tipo.GetNestedType("IO").GetNestedType("File");
            LeitorPorReflexaoUtil.InvocarMetodoEstatico(tipoFile, "WriteAllText",
                new object[] { CaminhoAbsoluto(caminho), conteudo });
        }

        public string ObterDiretorioDoMod()
        {
            if (!UsarS3SE())
                return _diretorioBaseFallback ?? ".";

            Type tipo = Type.GetType("Battery.Utility.S3SE, Battery.Utility")
                ?? BuscarTipoCargado("Battery.Utility.S3SE");
            Type tipoDir = tipo.GetNestedType("IO").GetNestedType("Directory");
            object pasta = LeitorPorReflexaoUtil.LerEstatico(tipoDir, "UserModDirectory");
            return pasta as string ?? _diretorioBaseFallback ?? ".";
        }
    }

    public sealed class LeitorArquivoConfiguracao
    {
        public Dictionary<string, string> LerChaves(IAdaptadorArquivos arquivos, string caminhoConfig)
        {
            Dictionary<string, string> valores = CriarDicionarioVazio();
            if (!arquivos.VerificarCaminhoExiste(caminhoConfig))
                return valores;

            string conteudo = TentarLerConteudo(arquivos, caminhoConfig);
            if (string.IsNullOrEmpty(conteudo))
                return valores;

            return ConverterParaDicionario(conteudo);
        }

        private string TentarLerConteudo(IAdaptadorArquivos arquivos, string caminho)
        {
            try
            {
                return arquivos.LerTexto(caminho);
            }
            catch
            {
                return string.Empty;
            }
        }

        private Dictionary<string, string> ConverterParaDicionario(string conteudo)
        {
            Dictionary<string, string> valores = CriarDicionarioVazio();
            Dictionary<string, object> raiz;
            if (!AdaptadorJsonNarrativo.TentarLerObjetoJson(conteudo, out raiz))
                return valores;

            AchatarObjetoJson(string.Empty, raiz, valores);

            return valores;
        }

        private static void AchatarObjetoJson(string prefixo, Dictionary<string, object> objeto, Dictionary<string, string> destino)
        {
            IDictionaryEnumerator enumerador = objeto.GetEnumerator();
            while (enumerador.MoveNext())
            {
                string chave = enumerador.Key as string;
                if (string.IsNullOrEmpty(chave))
                    continue;

                string chaveCompleta = string.IsNullOrEmpty(prefixo) ? chave : prefixo + "." + chave;
                object valor = enumerador.Value;

                Dictionary<string, object> valorObjeto = valor as Dictionary<string, object>;
                if (valorObjeto != null)
                {
                    AchatarObjetoJson(chaveCompleta, valorObjeto, destino);
                    continue;
                }

                destino[chaveCompleta] = ConverterParaTexto(valor);
            }
        }

        private static string ConverterParaTexto(object valor)
        {
            if (valor == null)
                return string.Empty;

            if (valor is string)
                return (string)valor;

            if (valor is bool)
                return ((bool)valor) ? "true" : "false";

            IFormattable formatavel = valor as IFormattable;
            if (formatavel != null)
                return formatavel.ToString(null, CultureInfo.InvariantCulture);

            return valor.ToString();
        }

        private static Dictionary<string, string> CriarDicionarioVazio()
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Fonte única de configuração para motor narrativo, escrita de estado e simulador.
    /// </summary>
    public sealed class ConfiguracaoCentral
    {
        private const string NomeArquivoConfig = "NarradorPorEventos.config.json";

        public bool AtivarProcessamentoNarrativo { get; private set; }
        public bool RecursosVisuaisCabecaSimFixaAtivos { get; private set; }
        public bool RecursosVisuaisTextoNarrativoAtivos { get; private set; }
        public float IntervaloPersistenciaHoras { get; private set; }
        public int IntervaloHotReloadMs { get; private set; }
        public bool LogarHotReload { get; private set; }
        public bool LogarVerbose { get; private set; }
        public int QuantidadeEventosPensamento { get; private set; }
        public int QuantidadeEventosConto { get; private set; }
        public int LimiteResumoPensamento { get; private set; }
        public int LimiteResumoConto { get; private set; }
        public int LimiteCaracteresContexto { get; private set; }

        public string CaminhoEstadoMundo { get; private set; }
        public string CaminhoEstadoLoteTemplate { get; private set; }
        public string CaminhoEstadoFamiliaTemplate { get; private set; }
        public string CaminhoEstadoSimTemplate { get; private set; }
        public string CaminhoPedidos { get; private set; }
        public string CaminhoRespostas { get; private set; }
        public string CaminhoPerfilUsuario { get; private set; }
        public string CaminhoContextoPrevio { get; private set; }
        public string CaminhoLogNarrativo { get; private set; }
        public string CaminhoLogExcecoes { get; private set; }
        public string CaminhoLogVerbose { get; private set; }

        public string OllamaUrl { get; private set; }
        public string OllamaModelo { get; private set; }
        public int OllamaTimeoutSegundos { get; private set; }

        public string DiretorioDocumentosMod { get; private set; }
        public string CaminhoConfig { get; private set; }

        private ConfiguracaoCentral() { }

        public static ConfiguracaoCentral Carregar(IAdaptadorArquivos arquivos)
        {
            string diretorioBaseMod = arquivos.ObterDiretorioDoMod();
            string caminhoConfig = CombinarCaminho(diretorioBaseMod, NomeArquivoConfig);

            LeitorArquivoConfiguracao leitor = new LeitorArquivoConfiguracao();
            Dictionary<string, string> valores = leitor.LerChaves(arquivos, caminhoConfig);

            ConfiguracaoCentral config = new ConfiguracaoCentral();
            config.CaminhoConfig = caminhoConfig;
            config.CarregarParametrosNarrativos(valores);
            config.CarregarDiretorioBase(diretorioBaseMod, valores);
            config.CarregarCaminhosDeEstado(valores);
            return config;
        }

        private void CarregarParametrosNarrativos(Dictionary<string, string> valores)
        {
            AtivarProcessamentoNarrativo = ConsultaConfiguracaoDoMod.LerBool(valores, ChavesConfiguracao.FeatureProcessamentoNarrativo, true);
            RecursosVisuaisCabecaSimFixaAtivos = ConsultaConfiguracaoDoMod.LerBool(valores, ChavesConfiguracao.FeatureRecursosVisuaisCabecaSimFixa, false);
            RecursosVisuaisTextoNarrativoAtivos = ConsultaConfiguracaoDoMod.LerBool(valores, ChavesConfiguracao.FeatureRecursosVisuaisTextoNarrativo, false);
            IntervaloPersistenciaHoras = ConsultaConfiguracaoDoMod.LerFloat(valores, ChavesConfiguracao.IntervaloPersistenciaHoras, 1f);
            IntervaloHotReloadMs = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.IntervaloHotReloadMs, 10000);
            LogarHotReload = ConsultaConfiguracaoDoMod.LerBool(valores, ChavesConfiguracao.LogarHotReload, true);
            LogarVerbose = ConsultaConfiguracaoDoMod.LerBool(valores, ChavesConfiguracao.FeatureLogVerbose, false);
            QuantidadeEventosPensamento = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.QuantidadeEventosPensamento, 10);
            QuantidadeEventosConto = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.QuantidadeEventosConto, 30);
            LimiteResumoPensamento = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.LimiteResumoPensamento, 12);
            LimiteResumoConto = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.LimiteResumoConto, 30);
            LimiteCaracteresContexto = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.LimiteCaracteresContexto, 8000);

            OllamaUrl = ConsultaConfiguracaoDoMod.LerTexto(valores, ChavesConfiguracao.OllamaUrl, "http://127.0.0.1:11434/api/generate");
            OllamaModelo = ConsultaConfiguracaoDoMod.LerTexto(valores, ChavesConfiguracao.OllamaModelo, "deepseek-r1:7b");
            OllamaTimeoutSegundos = ConsultaConfiguracaoDoMod.LerInt(valores, ChavesConfiguracao.OllamaTimeoutSegundos, 45);

            if (IntervaloPersistenciaHoras <= 0f) IntervaloPersistenciaHoras = 1f;
            if (IntervaloHotReloadMs < 1000) IntervaloHotReloadMs = 1000;
            if (QuantidadeEventosPensamento < 1) QuantidadeEventosPensamento = 1;
            if (QuantidadeEventosConto < 1) QuantidadeEventosConto = 1;
            if (LimiteResumoPensamento < 1) LimiteResumoPensamento = 1;
            if (LimiteResumoConto < 1) LimiteResumoConto = 1;
            if (LimiteCaracteresContexto < 500) LimiteCaracteresContexto = 500;
            if (OllamaTimeoutSegundos < 5) OllamaTimeoutSegundos = 5;
        }

        private void CarregarDiretorioBase(string diretorioBaseMod, Dictionary<string, string> valores)
        {
            string diretorioConfigurado = ConsultaConfiguracaoDoMod.LerTexto(valores, ChavesConfiguracao.DiretorioDocumentosMod, diretorioBaseMod);
            string diretorioExpandido = ExpandirVariaveisConhecidas(diretorioConfigurado, diretorioBaseMod);

            if (string.IsNullOrEmpty(diretorioExpandido))
            {
                DiretorioDocumentosMod = diretorioBaseMod;
                return;
            }

            if (EhCaminhoAbsoluto(diretorioExpandido))
            {
                DiretorioDocumentosMod = diretorioExpandido;
                return;
            }

            DiretorioDocumentosMod = CombinarCaminho(diretorioBaseMod, diretorioExpandido);
        }

        private void CarregarCaminhosDeEstado(Dictionary<string, string> valores)
        {
            CaminhoEstadoMundo = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoEstadoMundo, "NarradorPorEventos.estado.mundo.json");
            CaminhoEstadoLoteTemplate = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoEstadoLoteTemplate, "NarradorPorEventos.estado.lote.{lote_id}.json");
            CaminhoEstadoFamiliaTemplate = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoEstadoFamiliaTemplate, "NarradorPorEventos.estado.familia.{familia_nome}.json");
            CaminhoEstadoSimTemplate = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoEstadoSimTemplate, "NarradorPorEventos.estado.sim.{sim_id}.json");
            CaminhoPedidos = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoPedidos, "NarradorPorEventos.pedidos.json");
            CaminhoRespostas = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoRespostas, "NarradorPorEventos.respostas.json");
            CaminhoPerfilUsuario = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoPerfilUsuario, "NarradorPorEventos.perfil.usuario.json");
            CaminhoContextoPrevio = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoContextoPrevio, "NarradorPorEventos.contexto.previo.json");
            CaminhoLogNarrativo = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoLogNarrativo, "NarradorPorEventos.narrativa.log.json");
            CaminhoLogExcecoes = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoLogExcecoes, "NarradorPorEventos.excecoes.log.json");
            CaminhoLogVerbose = ResolverCaminhoArquivo(valores, ChavesConfiguracao.ArquivoLogVerbose, "NarradorPorEventos.verbose.log.txt");
        }

        private string ResolverCaminhoArquivo(Dictionary<string, string> valores, string chave, string padrao)
        {
            string caminhoConfigurado = ConsultaConfiguracaoDoMod.LerTexto(valores, chave, padrao);
            string caminhoExpandido = ExpandirVariaveisConhecidas(caminhoConfigurado, DiretorioDocumentosMod);

            if (string.IsNullOrEmpty(caminhoExpandido))
                return string.Empty;

            if (EhCaminhoAbsoluto(caminhoExpandido))
                return caminhoExpandido;

            return CombinarCaminho(DiretorioDocumentosMod, caminhoExpandido);
        }

        private static string ExpandirVariaveisConhecidas(string valor, string diretorioBase)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            string userProfile = ObterUserProfile(diretorioBase);
            string userName = ExtrairUserNameDoUserProfile(userProfile);
            return AdaptadorTextoNarrativo.ExpandirVariaveisDeUsuario(valor, userProfile, userName);
        }

        private static string ObterUserProfile(string diretorioBase)
        {
            return ExtrairUserProfileDoDiretorioBase(diretorioBase);
        }

        private static string ExtrairUserProfileDoDiretorioBase(string diretorioBase)
        {
            return AdaptadorTextoNarrativo.ExtrairUserProfileDoDiretorioBase(diretorioBase);
        }

        private static string ExtrairUserNameDoUserProfile(string userProfile)
        {
            return AdaptadorTextoNarrativo.ExtrairUltimoSegmento(userProfile, '\\');
        }

        private static bool EhCaminhoAbsoluto(string caminho)
        {
            return AdaptadorTextoNarrativo.EhCaminhoAbsolutoWindows(caminho);
        }

        public static string CombinarCaminho(string pasta, string arquivo)
        {
            return AdaptadorTextoNarrativo.CombinarCaminhoWindows(pasta, arquivo);
        }
    }

    public static class ContextoMod
    {
        private static IAdaptadorArquivos _adaptadorArquivos;
        private static ConfiguracaoCentral _configuracao;
        private static string _conteudoConfiguracaoAtual;

        public static IAdaptadorArquivos Arquivos
        {
            get
            {
                if (_adaptadorArquivos == null)
                    Inicializar();

                return _adaptadorArquivos;
            }
        }

        public static ConfiguracaoCentral Configuracao
        {
            get
            {
                if (_configuracao == null)
                    Inicializar();

                return _configuracao;
            }
        }

        public static void RecarregarConfiguracao()
        {
            Inicializar();
        }

        public static bool RecarregarConfiguracaoSeNecessario()
        {
            if (_adaptadorArquivos == null || _configuracao == null)
            {
                Inicializar();
                return true;
            }

            string caminhoConfig = _configuracao.CaminhoConfig;
            string conteudoAtual = LerConteudoConfiguracao(_adaptadorArquivos, caminhoConfig);
            if (string.IsNullOrEmpty(caminhoConfig)
                || string.Equals(conteudoAtual, _conteudoConfiguracaoAtual, StringComparison.Ordinal))
                return false;

            _configuracao = ConfiguracaoCentral.Carregar(_adaptadorArquivos);
            _conteudoConfiguracaoAtual = LerConteudoConfiguracao(_adaptadorArquivos, _configuracao.CaminhoConfig);
            return true;
        }

        private static void Inicializar()
        {
            if (_adaptadorArquivos == null)
                _adaptadorArquivos = new AdaptadorArquivosS3SE();

            _configuracao = ConfiguracaoCentral.Carregar(_adaptadorArquivos);
            _conteudoConfiguracaoAtual = LerConteudoConfiguracao(_adaptadorArquivos, _configuracao.CaminhoConfig);
        }

        private static string LerConteudoConfiguracao(IAdaptadorArquivos arquivos, string caminho)
        {
            if (arquivos == null || string.IsNullOrEmpty(caminho) || !arquivos.VerificarCaminhoExiste(caminho))
                return string.Empty;

            try
            {
                return arquivos.LerTexto(caminho) ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
