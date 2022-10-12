using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace VehicleDetectionApplication
{
    public partial class MessageForm : Form
    {
        string email, expectedPassw512;

        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            try
            {
                string readText = File.ReadAllText(@"../../Settings/login.txt");
                string[] loginText = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                email = loginText[0];
                expectedPassw512 = loginText[1];

                textGmail.Text = email;
            }
            catch
            {
                MessageBox.Show("Error loading configuration");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textPassword.TextLength > 0)
            {
                string actualPassw512 = SHA512(textPassword.Text);

                if (expectedPassw512.Equals(actualPassw512))
                {
                    MainForm.to = textPhone.Text + "@txtlocal.co.uk";
                    MainForm.from = textGmail.Text;
                    MainForm.pass = textPassword.Text;
                    MainForm.mess = textMessage.Text;

                    MessageBox.Show("Login succesfully");

                    this.Dispose();
                }
                else MessageBox.Show("Wrong password");
            }
            else MessageBox.Show("Please enter the password");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.pass == null) MainForm.pass = "";
        }

        // SHA512 titkosítás
        private static string SHA512(string input)
        {
            var msgBytes = Encoding.ASCII.GetBytes(input);

            var sha = new SHA512Managed();
            var hash = sha.ComputeHash(msgBytes);

            string output = "";
            foreach (byte b in hash)
            {
                output += b.ToString("x2");
            }

            return output;
        }
    }
}
