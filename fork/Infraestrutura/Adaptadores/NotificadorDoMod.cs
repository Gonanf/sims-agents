using Sims3.UI;

namespace ZZZZitalo.TS3Mods.NarradorPorEventos.Adaptadores
{
    public static class NotificadorDoMod
    {
        public static void NotificarSucessoInicializacao()
        {
            Notificar("NarradorPorEventos ativado!\nProcessador narrativo local inicializado.", StyledNotification.NotificationStyle.kGameMessagePositive);
        }

        public static void NotificarSucessoCarregamentoMod()
        {
            Notificar("NarradorPorEventos carregado!\nProcessador narrativo em C# pronto.", StyledNotification.NotificationStyle.kGameMessagePositive);
        }

        public static void Notificar(string msg, StyledNotification.NotificationStyle estilo)
        {
            StyledNotification.Show(new StyledNotification.Format(msg, estilo));
        }
    }
}
