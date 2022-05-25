using ActiveUp.Net.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using TrabbleDemo.Data;

namespace TrabbleDemo.Utils
{
    class MailUtils
    {
        private Imap4Client client;
        public MailUtils(string mailServer, int port, bool ssl, string login, string password)
        {
            if (ssl)
                Client.ConnectSsl(mailServer, port);
            else
                Client.Connect(mailServer, port);
            Client.Login(login, password);
        }

        public IEnumerable<Message> GetAllMails(string mailBox)
        {
            return GetMails(mailBox, "ALL").Cast<Message>();
        }

        public IEnumerable<Message> GetUnreadMails(string mailBox)
        {
            return GetMails(mailBox, "UNSEEN").Cast<Message>();
        }

        protected Imap4Client Client
        {
            get { return client ?? (client = new Imap4Client()); }
        }

        private MessageCollection GetMails(string mailBox, string searchPhrase)
        {
            Mailbox mails = Client.SelectMailbox(mailBox);
            MessageCollection messages = mails.SearchParse(searchPhrase);
            return messages;
        }

        public string GetFilteredMessageBody(string from, string subject)
        {
            var mailList = GetAllMails("inbox");
            List<Message> listFilterMail = new List<Message>();
            foreach (Message email in mailList)
            {
                if (email.From.Email.Equals(from) && email.Subject.Equals(subject))
                {
                    listFilterMail.Add(email);
                }
            }
            return listFilterMail[listFilterMail.Count - 1].BodyHtml.Text;
        }

        public List<Message> GetListFilteredMessageBody(string from, string subject)
        {
            var mailList = GetAllMails(ConfigurationData.MAIL_CATEGORY);
            List<Message> listFilterMail = new List<Message>();
            foreach (Message email in mailList)
            {
                if (email.From.Email.Equals(from) && email.Subject.Equals(subject))
                {
                    listFilterMail.Add(email);
                }
            }
            return listFilterMail;
        }
    }
}
