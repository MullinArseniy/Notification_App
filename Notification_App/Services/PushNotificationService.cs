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
            if (message.Length > 500)
            {
                logger.Warn($"Сообщение слишком длинное ({message.Length} символов). Возможны проблемы с доставкой.");
            }
            else
            {
                logger.Info($"Отправка Push: '{message}'.");
                logger.Info("Push уведомление доставлено.");
            }
        }
    }
}