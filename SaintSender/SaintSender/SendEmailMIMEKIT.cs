using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace SaintSender
{
    class SendEmailMIMEKIT
    {
        public static MimeMessage SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("suhooooly", "suhoooooly@gmail.com"));
            message.To.Add(new MailboxAddress("suhooooly", "suhooooly@gmail.com"));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
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
                client.Authenticate("suhooooly", "Europesbiggestowl");

                client.Send(message);
                client.Disconnect(true);
            }

            return message;
        }
    }
}
