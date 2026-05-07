using NotificationApp.Services;

namespace NotificationApp.Core
{
    public class NotificationSender
    {
        private readonly INotificationService service;
        private readonly IAppLogger logger;

        public NotificationSender(INotificationService service, IAppLogger logger)
        {
            this.service = service;
            this.logger = logger;
        }

        public void Send(string message)
        {
            service.Send(message);
        }
    }
}