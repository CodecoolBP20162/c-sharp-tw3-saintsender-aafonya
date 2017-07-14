using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAGetMail;
using System.IO;

namespace SaintSender
{
    class RecieveEmail
    {
        public static List<String> RecieveEmailsPop3()
        {
            List<string> infosGot = new List<string>();

            // Create a folder named "inbox" under current directory
            // to save the email retrieved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inbox", curpath);

            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            MailServer oServer = new MailServer("pop.gmail.com",
                        "suhooooly@gmail.com", "Europesbiggestowl", ServerProtocol.Pop3);
            MailClient oClient = new MailClient("TryIt");

            // If your POP3 server requires SSL connection,
            // Please add the following codes:
            oServer.SSLConnection = true;
            oServer.Port = 995;

            try
            {
                

                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];

                    infosGot.Add(info.Index.ToString());
                    infosGot.Add(info.Size.ToString());
                    infosGot.Add(info.UIDL.ToString());
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    // Receive email from POP3 server
                    Mail oMail = oClient.GetMail(info);

                    infosGot.Add(oMail.From.ToString());
                    infosGot.Add(oMail.Subject);
                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);

                    // Mark email as deleted from POP3 server.
                    oClient.Delete(info);
                }

                // Quit and purge emails marked as deleted from POP3 server.
                oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }

            return infosGot;
        }

        public static List<string> RecieveEmailsIMAP4()
        {
            List<string> infosGot = new List<string>();

            
            // Create a folder named "inbox" under current directory
            // to save the email retrieved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inboxIMAP4", curpath);

            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            // Gmail IMAP4 server is "imap.gmail.com"
            MailServer oServer = new MailServer("imap.gmail.com",
                        "suhooooly@gmail.com", "Europesbiggestowl", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");

            // Set SSL connection,
            oServer.SSLConnection = true;

            // Set 993 IMAP4 port
            oServer.Port = 993;

            try
            {
                // Lookup folder based name.
                Imap4Folder[] folders = oClient.Imap4Folders;
                Imap4Folder folder = SearchFolder(oClient.Imap4Folders, "[Gmail]/Trash");
                if (folder == null)
                {
                    throw new Exception("Folder was not found");
                }

                // Select this folder
                oClient.SelectFolder(folder);


                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {

                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    infosGot.Add(info.Index.ToString());
                    infosGot.Add(info.Size.ToString());
                    infosGot.Add(info.UIDL.ToString());

                    // Download email from GMail IMAP4 server
                    Mail oMail = oClient.GetMail(info);

                    infosGot.Add(oMail.From.ToString());
                    infosGot.Add(oMail.Subject);

                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);

                    // Mark email as deleted in GMail account.
                    //oClient.Delete(info);
                }

                // Quit and purge emails marked as deleted from Gmail IMAP4 server.
                oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
            return infosGot;
        }

        static Imap4Folder SearchFolder(Imap4Folder[] folders, string name)
        {
            int count = folders.Length;
            for (int i = 0; i < count; i++)
            {
                Imap4Folder folder = folders[i];
                Console.WriteLine(folder.FullPath);
                // Folder was found.
                if (String.Compare(folder.Name, name) == 0)
                    return folder;

                folder = SearchFolder(folder.SubFolders, name);
                if (folder != null)
                    return folder;
            }
            // No folder found
            return null;
        }

        public static List<string> RecieveEmailsIMAP4ByFolder()
        {
            List<string> infosGot = new List<string>();

            // Create a folder named "inbox" under current directory
            // to store the email file retrieved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inbox", curpath);

            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            MailServer oServer = new MailServer("imap4.emailarchitect.net",
                        "test@emailarchitect.net", "testpassword", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");

            // Set IMAP4 server port
            oServer.Port = 143;

            // If your IMAP4 server requires SSL connection,
            // Please add the following codes:
            // oServer.SSLConnection = true;
            // oServer.Port = 993;

            try
            {
                oClient.Connect(oServer);

                // Lookup folder based name.
                Imap4Folder folder = SearchFolder(oClient.Imap4Folders, "Deleted Items");
                if (folder == null)
                {
                    throw new Exception("Folder was not found");
                }

                // Select this folder
                oClient.SelectFolder(folder);

                // Retrieve emails from selected folder instead of default folder.
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    infosGot.Add(info.Index.ToString());
                    infosGot.Add(info.Size.ToString());
                    infosGot.Add(info.UIDL.ToString());

                    // Receive email from IMAP4 server
                    Mail oMail = oClient.GetMail(info);

                    infosGot.Add(oMail.From.ToString());
                    infosGot.Add(oMail.Subject);

                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);

                    // Mark email as deleted from IMAP4 server.
                    //oClient.Delete(info);
                }

                // Quit and purge emails marked as deleted from IMAP4 server.
                oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
            return infosGot;
        }
    }
}
