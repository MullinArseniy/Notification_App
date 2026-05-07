using Microsoft.Extensions.DependencyInjection;
using NotificationApp.Core;
using NotificationApp.Services;

namespace NotificationApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddSingleton<IAppLogger, AppLogger>();

            services.AddTransient<EmailService>();
            services.AddTransient<SmsService>();
            services.AddTransient<PushNotificationService>();

            services.AddTransient<IEnumerable<INotificationService>>(provider =>
            {
                return new List<INotificationService>
                {
                    provider.GetRequiredService<EmailService>(),
                    provider.GetRequiredService<SmsService>(),
                    provider.GetRequiredService<PushNotificationService>()
                };
            });

            services.AddTransient<MainForm>();

            var serviceProvider = services.BuildServiceProvider();

            var form = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(form);
        }
    }
}