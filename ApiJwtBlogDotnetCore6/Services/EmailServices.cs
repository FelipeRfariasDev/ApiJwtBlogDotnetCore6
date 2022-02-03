using ApiJwtBlogDotnetCore6.Models;
using MailKit.Security;
using MimeKit;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
namespace ApiJwtBlogDotnetCore6.Services
{
    public class EmailServices
    {
        public void SendEmail(Email email, string subject, string emailBody)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("190190f@gmail.com", "dprnss01");
                client.Send(GetEmailMessage(email, subject, emailBody));
                client.Disconnect(true);
            }
        }

        private MimeMessage GetEmailMessage(Email email, string subject, string emailBody)
        {
            var message = new MimeMessage();
            message = GetEmailFrom(message);
            message = GetEmailsToBeSend(message, email);
            message = FillEmailContent(message, subject, emailBody);
            return message;
        }

        private MimeMessage FillEmailContent(MimeMessage message, string subject, string body)
        {
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            message.Body = builder.ToMessageBody();
            return message;
        }

        private MimeMessage GetEmailFrom(MimeMessage message)
        {
            message.From.Add(new MailboxAddress("API Blog", "190190f@gmail.com"));
            return message;
        }

        private MimeMessage GetEmailsToBeSend(MimeMessage message, Email email)
        {
            foreach (var to in email.To)
                message.To.Add(new MailboxAddress(to.Name, to.Address));

            return message;
        }

        public string GetEmailBody()
        {
            string body = "<h1>Titulo</h1>";
            body += $"corpo do email";

            return body;
        }
    }
}
