using NarradorEngine.Server.Contratos;
using NarradorEngine.Server.Dominio;
using NarradorEngine.Server.Servicos;
using NarradorPorEventos.Dominio;

namespace NarradorEngine.Server.Processamento;

internal static class PromptsNarrativos
{
    public static string CriarPrompt(PedidoNarrativoJsonContrato pedido, ConfiguracaoServidor configuracao)
    {
        ConfiguracaoServidorNarrativa configuracaoDominio = ConfiguracaoServidorNarrativa.Criar(configuracao);
        PedidoNarrativo pedidoDominio = PedidoNarrativo.Criar(
            pedido != null ? pedido.Id : string.Empty,
            pedido != null ? pedido.Tipo : string.Empty,
            pedido != null ? pedido.SimAtivo : string.Empty,
            pedido != null ? pedido.HorarioReal : string.Empty,
            pedido != null ? pedido.Contexto : string.Empty);
        string diretrizPorTracos = AdaptadorTextoServidor.ApararOuVazio(DiretrizPorTracos.Obter(pedidoDominio.Contexto.Valor));
        string focoEmocional = AdaptadorTextoServidor.ApararOuVazio(ModificadoresDeTomNarrativo.ObterFocoEmocional(pedidoDominio.Contexto.Valor));

        return configuracaoDominio.Prompt.CriarPromptPrincipal(
            pedidoDominio,
            configuracaoDominio.PerfilUsuario,
            configuracaoDominio.DiretrizNarrativaPerfilAtiva.Valor,
            focoEmocional,
            diretrizPorTracos).TextoFinal.Valor;
    }

    public static string CriarPromptPerfilNarrador(ConfiguracaoServidor configuracao)
    {
        ConfiguracaoServidorNarrativa configuracaoDominio = ConfiguracaoServidorNarrativa.Criar(configuracao);
        return configuracaoDominio.Prompt.CriarPromptPerfilNarrador(configuracaoDominio.PerfilUsuario);
    }

    public static string CriarDiretrizFallbackPerfilNarrador(ConfiguracaoServidor configuracao)
    {
        ConfiguracaoServidorNarrativa configuracaoDominio = ConfiguracaoServidorNarrativa.Criar(configuracao);
        return configuracaoDominio.Prompt.CriarDiretrizFallbackPerfilNarrador(configuracaoDominio.PerfilUsuario);
    }
}
