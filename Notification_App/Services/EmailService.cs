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
            if (message.Length > 500)
            {
                logger.Warn($"Сообщение слишком длинное ({message.Length} символов). Возможны проблемы с доставкой.");
            }
            else
            {
                logger.Info($"Отправка сообщения: '{message}' через Email.");
                // Имитация работы сервиса
                logger.Info("Успешно отправлено.");
            }
        }
    }
}