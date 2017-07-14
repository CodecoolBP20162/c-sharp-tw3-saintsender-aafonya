using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;

namespace SaintSender
{
    class SendEmailMIMEKIT
    {
        public static string username;

        public static string selfUserName;
        public static string selfAddress;
        public static string selfKeyWord;

        public static MimeMessage SendEmail(string address, string subject, string body)
        {
            
            for (int i = 0; i < address.Length; i++)
            {
                if(address[i] == '@')
                {
                    username = address.Substring(0, i);
                    break;
                }
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(selfUserName, selfAddress));
            message.To.Add(new MailboxAddress(username, address));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(selfUserName, selfKeyWord);

                client.Send(message);
                MessageBox.Show("Email Send");
                client.Disconnect(true);
            }

            return message;
        }
    }
}
