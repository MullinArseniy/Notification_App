using NotificationApp.Core;

namespace NotificationApp.Services
{
    public class PushNotificationService : INotificationService
    {
        private readonly IAppLogger logger;
        public string ServiceName => "PushNotificationService";

        public PushNotificationService(IAppLogger logger)
        {
            this.logger = logger;
        }

        public void Send(string message)
        {
            logger.Info($"Отправка Push: '{message}'.");
            logger.Info("Push уведомление доставлено.");
        }
    }
}