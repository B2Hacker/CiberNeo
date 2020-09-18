using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CiberNeo.Models
{
    public static class Mail
    {
        public static void SendMail(string To, string Subject, string Message)
        {
            string username = "david.moraless@uttn.mx";
            string password = "........";

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.TargetName = "STARTTLS/smtp.office365.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            MailAddress from = new MailAddress(username, String.Empty, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(To);
            MailMessage message = new MailMessage(from, to);
            message.Body = Message;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = Subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            client.Send(message);
        }
    }
}