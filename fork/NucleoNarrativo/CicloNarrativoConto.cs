namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Ciclo de conto que consulta a política central de conto.
    /// </summary>
    internal sealed class CicloNarrativoConto : CicloNarrativoBase
    {
        public CicloNarrativoConto(ConfiguracaoCentral config)
            : base(new PoliticaCicloNarrativoConto(config))
        {
        }
    }
}