using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SmtpClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MailAddress from = new MailAddress(textBoxLogin.Text,"SM TP");
                // кому отправляем
                MailAddress to = new MailAddress(textBoxReceiver.Text);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);

                // тема письма
                m.Subject = textBoxTopic.Text;
                // текст письма
                m.Body = textBoxMessage.Text;

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential(textBoxLogin.Text, maskedTextBoxPassword.Text);
                client.EnableSsl = true;

                try
                {
                    client.Send(m);
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных!");
            }
        }
    }
}
