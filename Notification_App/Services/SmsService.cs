using NotificationApp.Core;

namespace NotificationApp.Services
{
    public class SmsService : INotificationService
    {
        private readonly IAppLogger logger;
        public string ServiceName => "SMSService";

        public SmsService(IAppLogger logger)
        {
            this.logger = logger;
        }

        public void Send(string message)
        {
            logger.Info($"Отправка SMS: '{message}'.");
            // Имитация случайного исключения
            throw new Exception("Исключение сервиса.");
        }
    }
}