using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using System.Collections.Specialized;

namespace SaintSender
{
    [Serializable]
    class Email
    {
        public string messageId { get; protected set; }
        public string from { get; protected set; }
        public string to { get; protected set; }
        public string subject { get; protected set; }
        public string body { get; protected set; }
        public string bodytext { get; protected set; }
        public string date { get; protected set; }


        public Email(MimeMessage mmsg)
        {
            messageId = mmsg.MessageId;
            from = mmsg.From.ToString();
            to = mmsg.To.ToString();
            subject = mmsg.Subject;
            body = mmsg.Body.ToString();
            bodytext = mmsg.Body.ToString();
            date = mmsg.Date.ToString();
        }
    }
}
