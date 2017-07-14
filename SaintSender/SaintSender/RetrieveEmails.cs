using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace SaintSender
{
    class RetrieveEmails
    {
        public static List<string> GetInboxMessages()
        {
            List<string> Messages = new List<string>();

            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(SendEmailMIMEKIT.selfUserName, SendEmailMIMEKIT.selfKeyWord);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);

                Messages.Add(inbox.Count.ToString());
                Messages.Add(inbox.Recent.ToString());

                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    //Serialize.serialize(message);
                    Console.WriteLine("Subject: {0}", message.Subject);
                    Messages.Add(message.Subject);
                }

                client.Disconnect(true);

                return Messages;
            }
        }

        public static List<string> SearchInInbox()
        {
            List<string> Messages = new List<string>();

            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(SendEmailMIMEKIT.selfUserName, SendEmailMIMEKIT.selfKeyWord);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);
                string temp = String.Format("Total messages: {0}", inbox.Count);
                string temp2 = String.Format("Recent messages: {0}", inbox.Recent);

                Messages.Add(inbox.Count.ToString());
                Messages.Add(inbox.Recent.ToString());

                // let's search for all messages received after Jan 12, 2013 with "MailKit" in the subject...
                var query = SearchQuery.DeliveredAfter(DateTime.Parse("2013-01-12"))
                    .And(SearchQuery.SubjectContains("Google")).And(SearchQuery.Seen);

                foreach (var uid in inbox.Search(query))
                {
                    var message = inbox.GetMessage(uid);
                    Console.WriteLine("[match] {0}: {1}", uid, message.Subject);
                    string temp3 = String.Format("[match] {0}: {1}", uid, message.Subject);
                    Messages.Add(temp3);
                }

                client.Disconnect(true);

                return Messages;
            }


        }

        public static void ShowEmailsByFolder(string folderName)
        {
            using (var client = new ImapClient())
            {

                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(SendEmailMIMEKIT.selfUserName, SendEmailMIMEKIT.selfKeyWord);

                // Get the first personal namespace and list the toplevel folders under it.
                var personal = client.GetFolder(client.PersonalNamespaces[0]);
                IMailFolder searchedFolder;
                DataManager.emailList.Clear();
                foreach (var folder in personal.GetSubfolders(false))
                {
                    if (folder.Name.Equals(folderName))
                    {
                        searchedFolder = folder;
                        searchedFolder.Open(FolderAccess.ReadOnly);
                        
                        for (int i = 0; i < searchedFolder.Count; i++)
                        {
                            var message = searchedFolder.GetMessage(i);
                            //Serialize.serialize(message);
                            Email tempEmail = new Email(message);
                            DataManager.emailList.Add(tempEmail, null);
                        }
                        break;
                    }
                    foreach (var foldery in folder.GetSubfolders(false))
                    {
                        if (foldery.Name.Equals(folderName))
                        {
                            searchedFolder = foldery;
                            searchedFolder.Open(FolderAccess.ReadOnly);
                            
                            for (int i = 0; i < searchedFolder.Count; i++)
                            {
                                var message = searchedFolder.GetMessage(i);
                                //Serialize.serialize(message);
                                Email tempEmail = new Email(message);
                                DataManager.emailList.Add(tempEmail, null);
                            }
                            break;
                        }
                    }                   
                }
                client.Disconnect(true);
            }
        }

        public static void ShowEmailsByFolderByDate(string folderName, string searchedString)
        {
            using (var client = new ImapClient())
            {

                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(SendEmailMIMEKIT.selfUserName, SendEmailMIMEKIT.selfKeyWord);

                // Get the first personal namespace and list the toplevel folders under it.
                var personal = client.GetFolder(client.PersonalNamespaces[0]);
                IMailFolder searchedFolder;
                DataManager.emailList.Clear();
                foreach (var folder in personal.GetSubfolders(false))
                {
                    if (folder.Name.Equals(folderName))
                    {
                        searchedFolder = folder;
                        searchedFolder.Open(FolderAccess.ReadOnly);

                        // let's search for all messages received after Jan 12, 2013 with "MailKit" in the subject...
                        var query = SearchQuery.DeliveredAfter(DateTime.Parse("2013-01-12"))
                            .And(SearchQuery.SubjectContains(searchedString)).And(SearchQuery.Seen)
                            .And(SearchQuery.BodyContains(searchedString)).And(SearchQuery.Seen);

                        foreach (var uid in searchedFolder.Search(query))
                        {
                            var message = searchedFolder.GetMessage(uid);
                            Console.WriteLine("[match] {0}: {1}", uid, message.Subject);
                            Email tempEmail = new Email(message);
                            DataManager.emailList.Add(tempEmail, null);
                        }

                      
                    }
                    foreach (var foldery in folder.GetSubfolders(false))
                    {
                        if (foldery.Name.Equals(folderName))
                        {
                            searchedFolder = foldery;
                            searchedFolder.Open(FolderAccess.ReadOnly);

                            // let's search for all messages received after Jan 12, 2013 with "MailKit" in the subject...
                            var query = SearchQuery.DeliveredAfter(DateTime.Parse("2013-01-12"))
                                .And(SearchQuery.SubjectContains(searchedString)).And(SearchQuery.Seen);

                            foreach (var uid in searchedFolder.Search(query))
                            {
                                var message = searchedFolder.GetMessage(uid);
                                Console.WriteLine("[match] {0}: {1}", uid, message.Subject);
                                Email tempEmail = new Email(message);
                                DataManager.emailList.Add(tempEmail, null);
                            }
                        }
                    }
                }
                client.Disconnect(true);
            }
        }

        public static List<string> ShowFolder()
        {
            List<string> Messages = new List<string>();

            using (var client = new ImapClient())
            {
                
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(SendEmailMIMEKIT.selfUserName, SendEmailMIMEKIT.selfKeyWord);

                // Get the first personal namespace and list the toplevel folders under it.
                var personal = client.GetFolder(client.PersonalNamespaces[0]);
                foreach (var folder in personal.GetSubfolders(false))
                {
                    Console.WriteLine("[folder] {0}", folder.Name);
                    foreach (var foldery in folder.GetSubfolders(false))
                    {
                        Console.WriteLine("[folder] {0}", foldery.Name);
                    }
                    Console.WriteLine("endOfFolder");
                }
                    
                
                    


                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.GetFolder(SpecialFolder.Drafts);
                inbox.Open(FolderAccess.ReadOnly);

                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);
                string temp = String.Format("Total messages: {0}", inbox.Count);
                string temp2 = String.Format("Recent messages: {0}", inbox.Recent);

                Messages.Add(temp);
                Messages.Add(temp2);

                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);

                    

                    Console.WriteLine("Subject: {0}", message.Subject);
                    string temp4 = string.Format("Subject: {0}", message.Subject);
                    Messages.Add(temp4);
                }

                client.Disconnect(true);

                return Messages;
            }
        }

        
    }
}
