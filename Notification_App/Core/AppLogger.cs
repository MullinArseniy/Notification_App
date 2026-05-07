using NLog;

namespace NotificationApp.Core
{
    public class AppLogger : IAppLogger
    {
        private static readonly NLog.Logger fileLogger = LogManager.GetCurrentClassLogger();

        public event Action<string, bool>? OnLog;

        public void Info(string message)
        {
            fileLogger.Info(message);
            OnLog?.Invoke($"[{DateTime.Now:HH:mm:ss}][INFO] {message}", false);
        }

        public void Warn(string message)
        {
            fileLogger.Warn(message);
            OnLog?.Invoke($"[{DateTime.Now:HH:mm:ss}][WARN] {message}", false);
        }

        public void Error(string message)
        {
            fileLogger.Error(message);
            OnLog?.Invoke($"[{DateTime.Now:HH:mm:ss}][ERROR] {message}", true);
        }

        public void Fatal(string message)
        {
            fileLogger.Fatal(message);
            OnLog?.Invoke($"[{DateTime.Now:HH:mm:ss}][FATAL] {message}", true);
        }
    }
}