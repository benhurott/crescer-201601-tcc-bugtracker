using BugTracker.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Service
{
    public class MailService : IMailService
    {
        private const string MAIL_FROM = "crescer.bugtracker@gmail.com";
        private const string PASSWORD = "Crescer$5";

        private SmtpClient smtpServer;

        public MailService()
        {
            this.smtpServer = new SmtpClient("smtp.gmail.com");
            this.smtpServer.Port = 587;
            this.smtpServer.Credentials = new System.Net.NetworkCredential(MAIL_FROM, PASSWORD);
            this.smtpServer.EnableSsl = true;
        }

        public void Send(string mailTo, string subject, string body, bool isHtml, string filePath = null)
        {
            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = isHtml;
            mail.From = new MailAddress(MAIL_FROM);
            mail.To.Add(mailTo);
            mail.Subject = subject;
            mail.Body = body;

            if (filePath != null)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filePath);
                mail.Attachments.Add(attachment);
            }

            smtpServer.Send(mail);
        }
    }
}
