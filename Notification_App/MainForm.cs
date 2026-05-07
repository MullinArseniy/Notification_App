using NotificationApp.Core;
using NotificationApp.Services;

namespace NotificationApp
{
    public partial class MainForm : Form
    {
        private readonly IEnumerable<INotificationService> services;
        private readonly IAppLogger logger;
        private readonly Dictionary<string, INotificationService> serviceMap;

        public MainForm(IEnumerable<INotificationService> services, IAppLogger logger)
        {
            InitializeComponent();
            this.services = services;
            this.logger = logger;
            this.logger.OnLog += OnLogReceived;

            var list = services.ToList();
            serviceMap = new Dictionary<string, INotificationService>
            {
                { "Email", list.First(serv => serv is EmailService) },
                { "SMS",   list.First(serv => serv is SmsService) },
                { "Push",  list.First(serv => serv is PushNotificationService) }
            };

            cmbChannel.Items.AddRange(serviceMap.Keys.ToArray<object>());
            cmbChannel.SelectedIndex = 0;

            this.logger.Info("Приложение запущено.");
        }

        private void OnLogReceived(string message, bool isError)
        {
            if (rtbLog.InvokeRequired)
                rtbLog.Invoke(() => AppendLog(message, isError));
            else
                AppendLog(message, isError);
        }

        private void AppendLog(string message, bool isError)
        {
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;

            if (message.Contains("[FATAL]"))
                rtbLog.SelectionColor = Color.FromArgb(180, 0, 0);
            else if (message.Contains("[ERROR]"))
                rtbLog.SelectionColor = Color.FromArgb(200, 30, 30);
            else if (message.Contains("[WARN]"))
                rtbLog.SelectionColor = Color.FromArgb(200, 120, 0);
            else
                rtbLog.SelectionColor = Color.FromArgb(30, 40, 60);

            rtbLog.AppendText(message + Environment.NewLine);
            rtbLog.SelectionColor = rtbLog.ForeColor;
            rtbLog.ScrollToCaret();
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmbChannel.SelectedItem?.ToString();
            if (selected != null)
                logger.Info($"Выбран сервис: {selected}.");
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text.Trim();

            // Пасхалка 404 
            if (message == "404")
            {
                btnSend.Visible = false;
                logger.Error("[404] Кнопка \"Отправить\" не найдена. Мы честно искали, но её тут нет.");

                await Task.Delay(3000);

                btnSend.Visible = true;
                logger.Info("Кнопка вернулась из отпуска. Попробуйте ещё раз.");
                return;
            }
    

            if (string.IsNullOrEmpty(message))
            {
                logger.Warn("Попытка отправить пустое сообщение.");
                MessageBox.Show("Сообщение не может быть пустым!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedKey = cmbChannel.SelectedItem?.ToString();
            if (selectedKey == null || !serviceMap.TryGetValue(selectedKey, out var service))
            {
                logger.Error("Сервис не выбран.");
                return;
            }

            var sender1 = new NotificationSender(service, logger);

            try
            {
                sender1.Send(message);
            }
            catch (Exception ex)
            {
                logger.Error($"Ошибка при отправке {selectedKey}: {ex.Message}");

                if (ex is InvalidOperationException)
                    logger.Fatal($"Сервис {selectedKey} недоступен. Требуется вмешательство.");

                MessageBox.Show($"Ошибка отправки:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            logger.Info("Приложение закрыто.");
            base.OnFormClosing(e);
        }
    }
}