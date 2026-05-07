using NotificationApp.Core;

namespace NotificationApp.Services
{
    public class EmailService : INotificationService
    {
        private readonly IAppLogger logger;
        public string ServiceName => "EmailService";

        public EmailService(IAppLogger logger)
        {
            this.logger = logger;
        }

        public void Send(string message)
        {
            logger.Info($"Отправка сообщения: '{message}' через Email.");
            // Имитация работы сервиса
            logger.Info("Успешно отправлено.");
        }
    }
}