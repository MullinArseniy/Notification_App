namespace NotificationApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox rtbLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpSettings = new GroupBox();
            lblChannel = new Label();
            cmbChannel = new ComboBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            grpLog = new GroupBox();
            rtbLog = new RichTextBox();

            grpSettings.SuspendLayout();
            grpLog.SuspendLayout();
            SuspendLayout();

            // Цвета
            var clrDarkBlue = Color.FromArgb(30, 50, 80);
            var clrAccent = Color.FromArgb(30, 144, 255);
            var clrLightBg = Color.FromArgb(240, 244, 250);
            var clrLogBg = Color.FromArgb(22, 38, 60);
            var clrGroupBorder = Color.FromArgb(180, 200, 225);
            var clrLabelGray = Color.FromArgb(90, 110, 140);

            // Форма
            BackColor = clrLightBg;
            ClientSize = new Size(800, 515);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отправка уведомлений (Notification App)";
            Font = new Font("Segoe UI", 9F);

            // grpSettings
            grpSettings.Controls.Add(lblChannel);
            grpSettings.Controls.Add(cmbChannel);
            grpSettings.Controls.Add(lblMessage);
            grpSettings.Controls.Add(txtMessage);
            grpSettings.Location = new Point(12, 12);
            grpSettings.Size = new Size(776, 200);
            grpSettings.Text = "Настройки уведомления";
            grpSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpSettings.ForeColor = clrDarkBlue;
            grpSettings.BackColor = Color.White;
            grpSettings.Paint += (s, e) =>
            {
                var rc = new Rectangle(0, 0, grpSettings.Width - 1, grpSettings.Height - 1);
                using var pen = new Pen(clrGroupBorder, 1);
                e.Graphics.DrawRectangle(pen, rc);
            };

            // lblChannel
            lblChannel.Text = "Выбор канала связи:";
            lblChannel.Font = new Font("Segoe UI", 9F);
            lblChannel.ForeColor = clrLabelGray;
            lblChannel.Location = new Point(10, 30);
            lblChannel.Size = new Size(160, 20);

            // cmbChannel
            cmbChannel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChannel.Location = new Point(10, 52);
            cmbChannel.Size = new Size(750, 26);
            cmbChannel.Font = new Font("Segoe UI", 9.5F);
            cmbChannel.BackColor = Color.White;
            cmbChannel.ForeColor = Color.FromArgb(30, 40, 60);
            cmbChannel.FlatStyle = FlatStyle.System;
            cmbChannel.SelectedIndexChanged += cmbChannel_SelectedIndexChanged;

            // lblMessage
            lblMessage.Text = "Текст уведомления:";
            lblMessage.Font = new Font("Segoe UI", 9F);
            lblMessage.ForeColor = clrLabelGray;
            lblMessage.Location = new Point(10, 95);
            lblMessage.Size = new Size(160, 20);

            // txtMessage
            txtMessage.Location = new Point(170, 92);
            txtMessage.Size = new Size(590, 80);
            txtMessage.Multiline = true;
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Font = new Font("Segoe UI", 9.5F);
            txtMessage.BackColor = Color.FromArgb(248, 250, 253);
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.ForeColor = Color.FromArgb(30, 40, 60);

            // btnSend 
            btnSend.Text = "Отправить уведомление";
            btnSend.Location = new Point(530, 225);
            btnSend.Size = new Size(258, 40);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.BackColor = clrDarkBlue;
            btnSend.ForeColor = Color.White;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatAppearance.MouseOverBackColor = clrAccent;
            btnSend.Click += btnSend_Click;

            // grpLog 
            grpLog.Controls.Add(rtbLog);
            grpLog.Location = new Point(12, 278);
            grpLog.Size = new Size(776, 220);
            grpLog.Text = "Журнал событий (Лог в реальном времени):";
            grpLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpLog.ForeColor = clrDarkBlue;
            grpLog.BackColor = Color.White;
            grpLog.Paint += (s, e) =>
            {
                var rc = new Rectangle(0, 0, grpLog.Width - 1, grpLog.Height - 1);
                using var pen = new Pen(clrGroupBorder, 1);
                e.Graphics.DrawRectangle(pen, rc);
            };

            // rtbLog
            rtbLog.Location = new Point(10, 25);
            rtbLog.Size = new Size(750, 180);
            rtbLog.ReadOnly = true;
            rtbLog.BackColor = clrLogBg;
            rtbLog.ForeColor = Color.FromArgb(180, 220, 255);
            rtbLog.Font = new Font("Consolas", 9F);
            rtbLog.BorderStyle = BorderStyle.None;

            //Сборка
            Controls.Add(grpSettings);
            Controls.Add(btnSend);
            Controls.Add(grpLog);

            grpSettings.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}