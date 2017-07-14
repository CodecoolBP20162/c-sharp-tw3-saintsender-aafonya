namespace SaintSender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendButton = new System.Windows.Forms.Button();
            this.EmailShowTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.EmailGroupBox = new System.Windows.Forms.GroupBox();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.SenderTextBox = new System.Windows.Forms.TextBox();
            this.BodyLabel = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.EmailSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.TextSearchTextBox = new System.Windows.Forms.TextBox();
            this.TextLabel = new System.Windows.Forms.Label();
            this.EmailSearchDateGroupBox = new System.Windows.Forms.GroupBox();
            this.DateSearchTextBox = new System.Windows.Forms.TextBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.EmailGroupBox.SuspendLayout();
            this.EmailSearchGroupBox.SuspendLayout();
            this.EmailSearchDateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(6, 302);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(40, 23);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmailShowTextBox
            // 
            this.EmailShowTextBox.Location = new System.Drawing.Point(454, 78);
            this.EmailShowTextBox.Multiline = true;
            this.EmailShowTextBox.Name = "EmailShowTextBox";
            this.EmailShowTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EmailShowTextBox.Size = new System.Drawing.Size(146, 124);
            this.EmailShowTextBox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(12, 12);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(150, 173);
            this.treeView2.TabIndex = 4;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.Click += new System.EventHandler(this.treeView2_Click);
            // 
            // EmailGroupBox
            // 
            this.EmailGroupBox.Controls.Add(this.richTextBox1);
            this.EmailGroupBox.Controls.Add(this.SubjectTextBox);
            this.EmailGroupBox.Controls.Add(this.SenderTextBox);
            this.EmailGroupBox.Controls.Add(this.BodyLabel);
            this.EmailGroupBox.Controls.Add(this.SubjectLabel);
            this.EmailGroupBox.Controls.Add(this.AddressLabel);
            this.EmailGroupBox.Controls.Add(this.SendButton);
            this.EmailGroupBox.Location = new System.Drawing.Point(223, 15);
            this.EmailGroupBox.Name = "EmailGroupBox";
            this.EmailGroupBox.Size = new System.Drawing.Size(202, 331);
            this.EmailGroupBox.TabIndex = 5;
            this.EmailGroupBox.TabStop = false;
            this.EmailGroupBox.Text = "Email Editor";
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(58, 66);
            this.SubjectTextBox.Multiline = true;
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(133, 20);
            this.SubjectTextBox.TabIndex = 5;
            // 
            // SenderTextBox
            // 
            this.SenderTextBox.Location = new System.Drawing.Point(58, 29);
            this.SenderTextBox.Name = "SenderTextBox";
            this.SenderTextBox.Size = new System.Drawing.Size(133, 20);
            this.SenderTextBox.TabIndex = 4;
            // 
            // BodyLabel
            // 
            this.BodyLabel.AutoSize = true;
            this.BodyLabel.Location = new System.Drawing.Point(6, 113);
            this.BodyLabel.Name = "BodyLabel";
            this.BodyLabel.Size = new System.Drawing.Size(31, 13);
            this.BodyLabel.TabIndex = 2;
            this.BodyLabel.Text = "Body";
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(3, 66);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(43, 13);
            this.SubjectLabel.TabIndex = 1;
            this.SubjectLabel.Text = "Subject";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(3, 29);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(45, 13);
            this.AddressLabel.TabIndex = 0;
            this.AddressLabel.Text = "Address";
            // 
            // EmailSearchGroupBox
            // 
            this.EmailSearchGroupBox.Controls.Add(this.TextSearchTextBox);
            this.EmailSearchGroupBox.Controls.Add(this.TextLabel);
            this.EmailSearchGroupBox.Location = new System.Drawing.Point(6, 290);
            this.EmailSearchGroupBox.Name = "EmailSearchGroupBox";
            this.EmailSearchGroupBox.Size = new System.Drawing.Size(200, 61);
            this.EmailSearchGroupBox.TabIndex = 6;
            this.EmailSearchGroupBox.TabStop = false;
            this.EmailSearchGroupBox.Text = "EmailSearch";
            // 
            // TextSearchTextBox
            // 
            this.TextSearchTextBox.Location = new System.Drawing.Point(56, 36);
            this.TextSearchTextBox.Name = "TextSearchTextBox";
            this.TextSearchTextBox.Size = new System.Drawing.Size(100, 20);
            this.TextSearchTextBox.TabIndex = 2;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(9, 39);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(28, 13);
            this.TextLabel.TabIndex = 1;
            this.TextLabel.Text = "Text";
            // 
            // EmailSearchDateGroupBox
            // 
            this.EmailSearchDateGroupBox.Controls.Add(this.DateSearchTextBox);
            this.EmailSearchDateGroupBox.Controls.Add(this.DateLabel);
            this.EmailSearchDateGroupBox.Location = new System.Drawing.Point(6, 216);
            this.EmailSearchDateGroupBox.Name = "EmailSearchDateGroupBox";
            this.EmailSearchDateGroupBox.Size = new System.Drawing.Size(200, 68);
            this.EmailSearchDateGroupBox.TabIndex = 0;
            this.EmailSearchDateGroupBox.TabStop = false;
            this.EmailSearchDateGroupBox.Text = "EmailSearch by Date";
            // 
            // DateSearchTextBox
            // 
            this.DateSearchTextBox.Location = new System.Drawing.Point(56, 30);
            this.DateSearchTextBox.Name = "DateSearchTextBox";
            this.DateSearchTextBox.Size = new System.Drawing.Size(100, 20);
            this.DateSearchTextBox.TabIndex = 1;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(9, 33);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(30, 13);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(58, 125);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(133, 200);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 361);
            this.Controls.Add(this.EmailSearchDateGroupBox);
            this.Controls.Add(this.EmailSearchGroupBox);
            this.Controls.Add(this.EmailGroupBox);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EmailShowTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.EmailGroupBox.ResumeLayout(false);
            this.EmailGroupBox.PerformLayout();
            this.EmailSearchGroupBox.ResumeLayout(false);
            this.EmailSearchGroupBox.PerformLayout();
            this.EmailSearchDateGroupBox.ResumeLayout(false);
            this.EmailSearchDateGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox EmailShowTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.GroupBox EmailGroupBox;
        private System.Windows.Forms.TextBox SubjectTextBox;
        private System.Windows.Forms.TextBox SenderTextBox;
        private System.Windows.Forms.Label BodyLabel;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.GroupBox EmailSearchGroupBox;
        private System.Windows.Forms.TextBox TextSearchTextBox;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.GroupBox EmailSearchDateGroupBox;
        private System.Windows.Forms.TextBox DateSearchTextBox;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

