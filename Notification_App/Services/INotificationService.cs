namespace NotificationApp.Services
{
    public interface INotificationService
    {
        string ServiceName { get; }
        void Send(string message);
    }
}