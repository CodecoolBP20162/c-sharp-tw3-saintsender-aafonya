using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using MailKit;
using MailKit.Net.Imap;

namespace SaintSender
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            FillMyTreeView();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SendEmailMIMEKIT.SendEmail();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dogCsv = string.Join(@"\s", RetrieveEmails.ShowFolder().ToArray());

            EmailShowTextBox.Text = dogCsv;
            EmailShowTextBox.Multiline = true;
            
        }

        private void FillMyTreeView()
        {
            // Suppress repainting the TreeView until all the objects have been created.
            treeView2.BeginUpdate();

            // Clear the TreeView each time the method is called.
            treeView2.Nodes.Clear();

            using (var client = new ImapClient())
            {

                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("suhooooly", "Europesbiggestowl");

                // Get the first personal namespace and list the toplevel folders under it.
                // Add a root TreeNode for each Folder object in the ArrayList.
                var personal = client.GetFolder(client.PersonalNamespaces[0]);
                foreach (var folder in personal.GetSubfolders(false))
                {
                    TreeNode tempNode = new TreeNode(folder.Name);
                    tempNode.Name = folder.Name;
                    treeView2.Nodes.Add(tempNode);
                    int i = 0;
                    // Add a child treenode for each SubFolder object in the current Folder object.
                    foreach (var foldery in folder.GetSubfolders(false))
                    {
                        TreeNode tempNode2 = new TreeNode(foldery.Name);
                        tempNode2.Name = foldery.Name;
                        treeView2.Nodes[i].Nodes.Add(
                       tempNode2);
                        
                    }
                    i++;
                }

                client.Disconnect(true);
            }
            // Begin repainting the TreeView.
            treeView2.EndUpdate();
        }

        private void treeView2_Click(object sender, EventArgs e)
        {
            //string folderName = treeView2.SelectedNode.Name;
            //RetrieveEmails.ShowEmailsByFolder(folderName);
            //CreateEmailListingForm(folderName);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string folderName = treeView2.SelectedNode.Name;
            RetrieveEmails.ShowEmailsByFolder(folderName);
            CreateEmailListingForm(folderName);
        }

        public void CreateEmailListingForm(string folderName)
        {
            // Create a new instance of the form.
            Form DialogForm = new Form();
            DialogForm.Name = folderName;
            // Create two buttons to use as the accept and cancel buttons.
            Button AcceptButton = new Button();
            AcceptButton.Text = "Accept";
            AcceptButton.Location = new Point(10, 240);
           
            

            // Define the border style of the form to a dialog box.
            DialogForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the accept button of the form to RenameButton.
            DialogForm.AcceptButton = AcceptButton;
            // Set the start position of the form to the center of the screen.
            DialogForm.StartPosition = FormStartPosition.CenterScreen;

            // Add RenameButton to the form.
            DialogForm.Controls.Add(AcceptButton);
       
            

            // Create a new ListView control.
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;

            foreach(Email emaily in DataManager.emailList.Keys)
            {
                ListViewItem temp = new ListViewItem();
                // Place a check mark next to the item.
                temp.Checked = true;
                temp.SubItems.Add(emaily.from);
                temp.SubItems.Add(emaily.to);
                temp.SubItems.Add(emaily.subject);
                temp.SubItems.Add(emaily.body);
                temp.SubItems.Add(emaily.date);

                //Add the items to the ListView.
                listView1.Items.Add(temp);
            }
            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Check", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("From", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("To", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Subject", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("Body", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Date", -2, HorizontalAlignment.Center);

            // Add the ListView to the control collection.
            DialogForm.Controls.Add(listView1);

            // Display the form as a modal dialog box.
            DialogForm.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (DialogForm.DialogResult == DialogResult.OK)
            {
                DialogForm.Dispose();
            }
        }

        


        //public void CreateDialogForm(FileInfo file)
        //{
        //    // Create a new instance of the form.
        //    Form DialogForm = new Form();
        //    // Create two buttons to use as the accept and cancel buttons.
        //    Button RenameButton = new Button();
        //    Button CancelButton = new Button();

        //    Label OldFileNameLabel = new Label();
        //    OldFileNameLabel.Text = "Old File Name";
        //    OldFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        //    OldFileNameLabel.Location = new Point(10, 10);
        //    Label OldFileNameText = new Label();
        //    OldFileNameText.Text = file.Name;
        //    OldFileNameText.Location = new Point(10, 40);
        //    Label NewFileNameLabel = new Label();
        //    NewFileNameLabel.Text = "New File Name";
        //    NewFileNameLabel.Location = new Point(10, 70);
        //    NewFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        //    TextBox NewFileNameTextBox = new TextBox();
        //    NewFileNameTextBox.Location = new Point(10, 100);

        //    // Set the text of RenameButton.
        //    RenameButton.Text = "Rename";
        //    // Set the position of the button on the form.
        //    RenameButton.Location = new Point(10, 140);
        //    // Set the text of CancelButton to "Cancel".
        //    CancelButton.Text = "Cancel";
        //    // Set the position of the button based on the location of button1.
        //    CancelButton.Location
        //       = new Point(RenameButton.Left, RenameButton.Height + RenameButton.Top + 10);
        //    // Make RenameButton's dialog result OK.
        //    RenameButton.DialogResult = DialogResult.OK;
        //    // Make button2's dialog result Cancel.
        //    CancelButton.DialogResult = DialogResult.Cancel;
        //    // Set the caption bar text of the form.   
        //    DialogForm.Text = "Rename Dialog Box";

        //    // Define the border style of the form to a dialog box.
        //    DialogForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    // Set the accept button of the form to RenameButton.
        //    DialogForm.AcceptButton = RenameButton;
        //    // Set the cancel button of the form to CancelButton.
        //    DialogForm.CancelButton = CancelButton;
        //    // Set the start position of the form to the center of the screen.
        //    DialogForm.StartPosition = FormStartPosition.CenterScreen;

        //    // Add RenameButton to the form.
        //    DialogForm.Controls.Add(RenameButton);
        //    // Add CancelButton to the form.
        //    DialogForm.Controls.Add(CancelButton);
        //    DialogForm.Controls.Add(OldFileNameLabel);
        //    DialogForm.Controls.Add(OldFileNameText);
        //    DialogForm.Controls.Add(NewFileNameLabel);
        //    DialogForm.Controls.Add(NewFileNameTextBox);

        //    // Display the form as a modal dialog box.
        //    DialogForm.ShowDialog();

        //    // Determine if the OK button was clicked on the dialog box.
        //    if (DialogForm.DialogResult == DialogResult.OK)
        //    {
        //        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(file.FullName, NewFileNameTextBox.Text);
        //        UpdateDirectoryInfos();
        //        // Display a message box indicating that the OK button was clicked.
        //        MessageBox.Show("The OK button on the form was clicked.");
        //        // Optional: Call the Dispose method when you are finished with the dialog box.
        //        DialogForm.Dispose();
        //    }
        //    else
        //    {
        //        // Display a message box indicating that the Cancel button was clicked.
        //        MessageBox.Show("The Cancel button on the form was clicked.");
        //        // Optional: Call the Dispose method when you are finished with the dialog box.
        //        DialogForm.Dispose();
        //    }
        //}

    }
}
