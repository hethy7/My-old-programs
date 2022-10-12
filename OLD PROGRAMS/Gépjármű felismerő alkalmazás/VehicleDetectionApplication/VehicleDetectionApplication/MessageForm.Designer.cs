namespace VehicleDetectionApplication
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.textGmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone number";
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(145, 22);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(236, 22);
            this.textPhone.TabIndex = 1;
            this.textPhone.Text = "421917614651";
            // 
            // textGmail
            // 
            this.textGmail.Location = new System.Drawing.Point(145, 72);
            this.textGmail.Name = "textGmail";
            this.textGmail.ReadOnly = true;
            this.textGmail.Size = new System.Drawing.Size(236, 22);
            this.textGmail.TabIndex = 3;
            this.textGmail.Text = "hethy7@gmail.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gmail account";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(145, 122);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(236, 22);
            this.textPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(145, 172);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textMessage.Size = new System.Drawing.Size(236, 65);
            this.textMessage.TabIndex = 7;
            this.textMessage.Text = "Gepjarmu erkezett!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 293);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textGmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 340);
            this.Name = "MessageForm";
            this.Text = "Notification Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageForm_FormClosing);
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.TextBox textGmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}