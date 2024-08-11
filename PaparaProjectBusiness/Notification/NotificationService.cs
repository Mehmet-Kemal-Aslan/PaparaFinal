using Microsoft.Extensions.Options;
using PaparaProjectSchema.Notification;
using System.Net.Mail;

namespace PaparaProjectBussiness.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly SmtpSettings _smtpSettings;

        public NotificationService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public void SendEmail(string subject, string email, string content)
        {
            SmtpClient mySmtpClient = new SmtpClient(_smtpSettings.Host)
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_smtpSettings.Email, _smtpSettings.Password)
            };

            MailAddress from = new MailAddress(_smtpSettings.Email, _smtpSettings.SystemOwnerName);
            MailAddress to = new MailAddress(email);
            MailMessage myMail = new MailMessage(from, to)
            {
                Subject = subject,
                SubjectEncoding = System.Text.Encoding.UTF8,
                Body = content,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true
            };

            mySmtpClient.Send(myMail);
        }
    }
}
