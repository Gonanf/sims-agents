namespace ZZZZitalo.TS3Mods.NarradorPorEventos
{
    /// <summary>
    /// Ciclo fino de pensamento que consulta a política central de pensamento.
    /// </summary>
    internal sealed class CicloNarrativoPensamento : CicloNarrativoBase
    {
        public CicloNarrativoPensamento(ConfiguracaoCentral config)
            : base(new PoliticaCicloNarrativoPensamento(config))
        {
        }
    }
}