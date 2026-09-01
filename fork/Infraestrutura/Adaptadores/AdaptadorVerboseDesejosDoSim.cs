using Sims3.Gameplay.Actors;
using Sims3.Gameplay.DreamsAndPromises;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ZZZZitalo.TS3Mods.NarradorPorEventos.RepoConsulta;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    /// <summary>
    /// Centraliza o diagnostico verbose da leitura de desejos do HUD.
    /// </summary>
    public static class AdaptadorVerboseDesejosDoSim
    {
        private const int IndiceDesejoDeVida = 0;
        private const string NomeCampoDesejosDaStagingArea = "mDisplayedDreamNodes";

        private const BindingFlags FlagsMembrosDeclarados =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        public static void RegistrarEstadoAtual(Sim sim, DreamsAndPromisesManager gerenciador, IList<ActiveDreamNode> desejosNosSlots, string desejosNosSlotsEmTexto)
        {
            ConfiguracaoCentral configuracao = ContextoMod.Configuracao;
            if (configuracao == null || !configuracao.LogarVerbose)
                return;

            IAdaptadorArquivos arquivos = ContextoMod.Arquivos;
            if (arquivos == null || AdaptadorTextoNarrativo.TextoVazio(configuracao.CaminhoLogVerbose))
                return;

            try
            {
                string bloco = MontarBlocoVerbose(sim, gerenciador, desejosNosSlots, desejosNosSlotsEmTexto);
                AdaptadorArquivosNarrativos.AnexarTextoSeguro(arquivos, configuracao.CaminhoLogVerbose, bloco);
            }
            catch (Exception excecao)
            {
                RegistrarFalha(arquivos, configuracao.CaminhoLogVerbose, sim, "registrar_verbose", excecao);
            }
        }

        private static string MontarBlocoVerbose(Sim sim, DreamsAndPromisesManager gerenciador, IList<ActiveDreamNode> desejosNosSlots, string desejosNosSlotsEmTexto)
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("============================================================");
            texto.Append("timestamp=").Append(ConsultaDeHorario.HorarioDoMundoReal).AppendLine();
            texto.Append("sim=").Append(FormatarValorParaVerbose(ObterNomeDoSimParaVerbose(sim))).AppendLine();
            texto.Append("desejos_hud=").Append(FormatarTextoResumo(desejosNosSlotsEmTexto)).AppendLine();
            texto.AppendLine();

            AdicionarResumoDosSlotsDoHud(texto, gerenciador);
            AdicionarResumoDaStagingArea(texto, gerenciador);
            AdicionarResumoDosActiveNodes(texto, gerenciador);
            texto.AppendLine();

            AdicionarDumpDeMembros(texto, "DreamsAndPromisesManager", gerenciador);

            List<ActiveDreamNode> nos = new List<ActiveDreamNode>();
            List<string> origens = new List<string>();
            ColetarNosParaVerbose(gerenciador, desejosNosSlots, nos, origens);

            for (int indice = 0; indice < nos.Count; indice++)
            {
                texto.AppendLine();
                texto.Append("ActiveDreamNode[").Append(indice.ToString()).Append("] origens=").Append(origens[indice]).AppendLine();
                AdicionarDumpDeMembros(texto, "ActiveDreamNode", nos[indice]);
            }

            return texto.ToString();
        }

        private static void AdicionarResumoDosSlotsDoHud(StringBuilder texto, DreamsAndPromisesManager gerenciador)
        {
            texto.AppendLine("slots_hud:");
            if (gerenciador == null)
            {
                texto.AppendLine("  gerenciador=null");
                return;
            }

            ActiveDreamNode[] promessas = gerenciador.GetPromisedNodes();
            if (promessas == null)
            {
                texto.AppendLine("  promessas=null");
                return;
            }

            for (int indice = 0; indice < promessas.Length; indice++)
            {
                string rotulo = indice == IndiceDesejoDeVida
                    ? "  lifetime_slot"
                    : "  slot_hud_" + indice.ToString();

                texto.Append(rotulo).Append("=").Append(DescreverDesejoCurto(promessas[indice])).AppendLine();
            }
        }

        private static void AdicionarResumoDaStagingArea(StringBuilder texto, DreamsAndPromisesManager gerenciador)
        {
            texto.AppendLine("staging_area:");
            List<ActiveDreamNode> desejosDaStagingArea = ObterDesejosDaStagingArea(gerenciador);
            if (desejosDaStagingArea.Count == 0)
            {
                texto.AppendLine("  vazio");
                return;
            }

            for (int indice = 0; indice < desejosDaStagingArea.Count; indice++)
            {
                texto.Append("  dream_").Append(indice.ToString()).Append("=")
                    .Append(DescreverDesejoCurto(desejosDaStagingArea[indice])).AppendLine();
            }
        }

        private static void AdicionarResumoDosActiveNodes(StringBuilder texto, DreamsAndPromisesManager gerenciador)
        {
            texto.AppendLine("active_nodes:");
            if (gerenciador == null || gerenciador.ActiveNodes == null)
            {
                texto.AppendLine("  vazio");
                return;
            }

            int indice = 0;
            foreach (ActiveNodeBase item in gerenciador.ActiveNodes)
            {
                ActiveDreamNode desejo = item as ActiveDreamNode;
                if (desejo == null)
                    continue;

                texto.Append("  active_").Append(indice.ToString()).Append("=")
                    .Append(DescreverDesejoCurto(desejo)).AppendLine();
                indice++;
            }

            if (indice == 0)
                texto.AppendLine("  nenhum ActiveDreamNode");
        }

        private static void ColetarNosParaVerbose(DreamsAndPromisesManager gerenciador, IList<ActiveDreamNode> desejosNosSlots, List<ActiveDreamNode> nos, List<string> origens)
        {
            if (desejosNosSlots != null)
            {
                for (int indice = 0; indice < desejosNosSlots.Count; indice++)
                    AdicionarNoVerbose(nos, origens, desejosNosSlots[indice], "consulta_hud_" + indice.ToString());
            }

            if (gerenciador == null)
                return;

            ActiveDreamNode[] promessas = gerenciador.GetPromisedNodes();
            if (promessas != null)
            {
                for (int indice = 0; indice < promessas.Length; indice++)
                {
                    string origem = indice == IndiceDesejoDeVida
                        ? "lifetime_slot"
                        : "slot_hud_" + indice.ToString();

                    AdicionarNoVerbose(nos, origens, promessas[indice], origem);
                }
            }

            List<ActiveDreamNode> desejosDaStagingArea = ObterDesejosDaStagingArea(gerenciador);
            for (int indice = 0; indice < desejosDaStagingArea.Count; indice++)
                AdicionarNoVerbose(nos, origens, desejosDaStagingArea[indice], "staging_" + indice.ToString());

            if (gerenciador.ActiveNodes == null)
                return;

            int indiceActiveNode = 0;
            foreach (ActiveNodeBase item in gerenciador.ActiveNodes)
            {
                ActiveDreamNode desejo = item as ActiveDreamNode;
                if (desejo == null)
                    continue;

                AdicionarNoVerbose(nos, origens, desejo, "active_" + indiceActiveNode.ToString());
                indiceActiveNode++;
            }
        }

        private static void AdicionarNoVerbose(List<ActiveDreamNode> nos, List<string> origens, ActiveDreamNode node, string origem)
        {
            if (node == null || nos == null || origens == null)
                return;

            for (int indice = 0; indice < nos.Count; indice++)
            {
                if (!SaoMesmoDesejo(nos[indice], node))
                    continue;

                if (origens[indice].IndexOf(origem, StringComparison.Ordinal) < 0)
                    origens[indice] = origens[indice] + ", " + origem;

                return;
            }

            nos.Add(node);
            origens.Add(origem);
        }

        private static List<ActiveDreamNode> ObterDesejosDaStagingArea(DreamsAndPromisesManager gerenciador)
        {
            List<ActiveDreamNode> desejos = new List<ActiveDreamNode>();
            if (gerenciador == null)
                return desejos;

            object campo = AdaptadorColecoesPorReflexaoUtil.LerMembroOuCampo(gerenciador, NomeCampoDesejosDaStagingArea);
            List<ActiveDreamNode> extraidos = AdaptadorColecoesPorReflexaoUtil.ExtrairListaTipada<ActiveDreamNode>(campo);
            foreach (ActiveDreamNode desejo in extraidos)
                AdicionarUnico(desejos, desejo);

            return desejos;
        }

        private static void AdicionarDumpDeMembros(StringBuilder texto, string rotulo, object origem)
        {
            texto.Append(rotulo).Append(" tipo=").Append(ObterNomeDoTipo(origem)).AppendLine();
            if (origem == null)
                return;

            Type tipoAtual = origem.GetType();
            while (tipoAtual != null && tipoAtual != typeof(object))
            {
                texto.Append("  [").Append(ObterNomeDoTipo(tipoAtual)).AppendLine("]");
                AdicionarPropriedades(texto, origem, tipoAtual);
                AdicionarCampos(texto, origem, tipoAtual);
                tipoAtual = tipoAtual.BaseType;
            }
        }

        private static void AdicionarPropriedades(StringBuilder texto, object origem, Type tipo)
        {
            PropertyInfo[] propriedades = tipo.GetProperties(FlagsMembrosDeclarados);
            if (propriedades == null)
                return;

            foreach (PropertyInfo propriedade in propriedades)
            {
                if (propriedade == null || propriedade.GetIndexParameters().Length > 0)
                    continue;

                string valor = TentarLerValorDaPropriedade(origem, propriedade);
                texto.Append("    propriedade ").Append(propriedade.Name)
                    .Append(" : ").Append(ObterNomeDoTipo(propriedade.PropertyType))
                    .Append(" = ").Append(valor).AppendLine();
            }
        }

        private static void AdicionarCampos(StringBuilder texto, object origem, Type tipo)
        {
            FieldInfo[] campos = tipo.GetFields(FlagsMembrosDeclarados);
            if (campos == null)
                return;

            foreach (FieldInfo campo in campos)
            {
                if (campo == null)
                    continue;

                string valor = TentarLerValorDoCampo(origem, campo);
                texto.Append("    campo ").Append(campo.Name)
                    .Append(" : ").Append(ObterNomeDoTipo(campo.FieldType))
                    .Append(" = ").Append(valor).AppendLine();
            }
        }

        private static string TentarLerValorDaPropriedade(object origem, PropertyInfo propriedade)
        {
            try
            {
                object valor = propriedade.GetValue(origem, null);
                return FormatarValorParaVerbose(valor);
            }
            catch (Exception excecao)
            {
                return "[erro: " + AdaptadorTextoNarrativo.ParaLinhaUnica(excecao.Message) + "]";
            }
        }

        private static string TentarLerValorDoCampo(object origem, FieldInfo campo)
        {
            try
            {
                object valor = campo.GetValue(origem);
                return FormatarValorParaVerbose(valor);
            }
            catch (Exception excecao)
            {
                return "[erro: " + AdaptadorTextoNarrativo.ParaLinhaUnica(excecao.Message) + "]";
            }
        }

        private static string FormatarValorParaVerbose(object valor)
        {
            if (valor == null)
                return "null";

            string texto = valor as string;
            if (texto != null)
                return '"' + AdaptadorTextoNarrativo.ParaLinhaUnica(texto) + '"';

            if (valor is bool)
                return (bool)valor ? "true" : "false";

            if (valor is DateTime)
                return ((DateTime)valor).ToString("yyyy-MM-dd HH:mm:ss");

            if (valor is ActiveDreamNode)
                return DescreverDesejoCurto((ActiveDreamNode)valor);

            if (valor is DreamNodeInstance)
                return DescreverNodeInstance((DreamNodeInstance)valor);

            if (valor is Sim)
                return FormatarValorParaVerbose(ObterNomeDoSimParaVerbose((Sim)valor));

            Type tipo = valor.GetType();
            if (tipo.IsEnum || tipo.IsPrimitive || valor is decimal)
                return AdaptadorTextoNarrativo.ParaLinhaUnica(valor.ToString());

            ICollection colecao = valor as ICollection;
            if (colecao != null)
                return ObterNomeDoTipo(tipo) + "(Count=" + colecao.Count.ToString() + ")";

            return AdaptadorTextoNarrativo.ParaLinhaUnica(valor.ToString());
        }

        private static string DescreverDesejoCurto(ActiveDreamNode desejo)
        {
            if (desejo == null)
                return "null";

            DreamNodeInstance nodeInstance = desejo.NodeInstance;
            StringBuilder texto = new StringBuilder();
            texto.Append(ObterNomeDoDesejo(desejo));
            texto.Append(" {primitiveId=");
            texto.Append(nodeInstance != null ? nodeInstance.PrimitiveId.ToString() : "null");
            texto.Append(", nodeId=");
            texto.Append(nodeInstance != null ? nodeInstance.NodeId.ToString() : "null");
            texto.Append(", promised=").Append(desejo.IsPromised ? "true" : "false");
            texto.Append(", complete=").Append(desejo.IsComplete ? "true" : "false");
            texto.Append(", visible=").Append(nodeInstance != null && desejo.IsVisible ? "true" : "false");
            texto.Append("}");
            return AdaptadorTextoNarrativo.ParaLinhaUnica(texto.ToString());
        }

        private static string DescreverNodeInstance(DreamNodeInstance node)
        {
            if (node == null)
                return "null";

            StringBuilder texto = new StringBuilder();
            texto.Append("DreamNodeInstance {");
            texto.Append("primitiveId=").Append(node.PrimitiveId.ToString());
            texto.Append(", nodeId=").Append(node.NodeId.ToString());
            texto.Append(", parentId=").Append(node.ParentInstanceId.ToString());
            texto.Append(", ownerTreeId=").Append(node.OwnerTreeId.ToString());
            texto.Append(", visible=").Append(node.IsVisible ? "true" : "false");
            texto.Append("}");
            return texto.ToString();
        }

        private static string ObterNomeDoDesejo(ActiveDreamNode desejo)
        {
            if (desejo == null || desejo.NodeInstance == null)
                return string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(desejo.Name))
                    return desejo.Name;
            }
            catch
            {
            }

            DreamNodePrimitive primitive = desejo.NodeInstance.Primitive;
            string nome = primitive == null ? string.Empty : primitive.Name;
            if (string.IsNullOrEmpty(nome))
                nome = desejo.NodeInstance.PrimitiveId.ToString();

            return nome;
        }

        private static string FormatarTextoResumo(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "nenhum";

            return AdaptadorTextoNarrativo.ParaLinhaUnica(texto);
        }

        private static string ObterNomeDoTipo(object origem)
        {
            if (origem == null)
                return "null";

            return ObterNomeDoTipo(origem.GetType());
        }

        private static string ObterNomeDoTipo(Type tipo)
        {
            if (tipo == null)
                return "null";

            if (!string.IsNullOrEmpty(tipo.FullName))
                return tipo.FullName;

            return tipo.Name;
        }

        private static string ObterNomeDoSimParaVerbose(Sim sim)
        {
            string nome = ConsultaSim.ObterNomeSim(sim);
            if (!string.IsNullOrEmpty(nome))
                return nome;

            if (sim == null)
                return string.Empty;

            return AdaptadorTextoNarrativo.ParaLinhaUnica(sim.ToString());
        }

        private static bool SaoMesmoDesejo(ActiveDreamNode primeiro, ActiveDreamNode segundo)
        {
            if (primeiro == null || segundo == null)
                return false;

            if (primeiro == segundo)
                return true;

            DreamNodeInstance nodeA = primeiro.NodeInstance;
            DreamNodeInstance nodeB = segundo.NodeInstance;
            if (nodeA == null || nodeB == null)
                return false;

            return nodeA.OwnerTreeId == nodeB.OwnerTreeId && nodeA.NodeId == nodeB.NodeId;
        }

        private static void AdicionarUnico(List<ActiveDreamNode> destino, ActiveDreamNode desejo)
        {
            if (destino == null || desejo == null)
                return;

            foreach (ActiveDreamNode item in destino)
            {
                if (SaoMesmoDesejo(item, desejo))
                    return;
            }

            destino.Add(desejo);
        }

        private static void RegistrarFalha(IAdaptadorArquivos arquivos, string caminho, Sim sim, string origem, Exception excecao)
        {
            try
            {
                StringBuilder texto = new StringBuilder();
                texto.AppendLine("============================================================");
                texto.Append("timestamp=").Append(ConsultaDeHorario.HorarioDoMundoReal).AppendLine();
                texto.Append("sim=").Append(FormatarValorParaVerbose(ObterNomeDoSimParaVerbose(sim))).AppendLine();
                texto.Append("falha_verbose=").Append(origem ?? string.Empty).AppendLine();
                texto.Append("detalhe=").Append(AdaptadorTextoNarrativo.MontarDetalheDeExcecao(excecao, "AdaptadorVerboseDesejosDoSim." + (origem ?? string.Empty))).AppendLine();
                AdaptadorArquivosNarrativos.AnexarTextoSeguro(arquivos, caminho, texto.ToString());
            }
            catch
            {
            }
        }
    }
}