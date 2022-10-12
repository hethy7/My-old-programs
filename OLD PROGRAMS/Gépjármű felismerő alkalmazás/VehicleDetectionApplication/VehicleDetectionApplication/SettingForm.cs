using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VehicleDetectionApplication
{
    public partial class SettingForm : Form
    {
        string relativeFilePath;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            fillingForm("P_settings.txt");
        }

        private void fillingForm(String settingFile)
        {
            try
            {
                ArrayList settingArray = new ArrayList();

                string readText = File.ReadAllText(@"../../Settings/" + settingFile);
                string[] settingText = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                settingArray.Add(settingText[0]);
                settingArray.Add(settingText[1]);
                settingArray.Add(settingText[2]);
                settingArray.Add(settingText[3]);
                string[] points = settingText[4].Split('.');
                settingArray.Add(new Size(int.Parse(points[0]), int.Parse(points[1])));
                settingArray.Add(int.Parse(settingText[5]));
                points = settingText[6].Split(',');
                settingArray.Add(new Size(int.Parse(points[0]), int.Parse(points[1])));
                points = settingText[7].Split(',');
                settingArray.Add(new Size(int.Parse(points[0]), int.Parse(points[1])));

                switch (settingArray[0].ToString())
                {
                    case "1920,1080": comboBox1.SelectedIndex = 1; break;
                    case "1280,960": comboBox1.SelectedIndex = 2; break;
                    case "1280,720": comboBox1.SelectedIndex = 3; break;
                    default: comboBox1.SelectedIndex = 0; break;
                }

                if (settingArray[1].Equals("JPEG")) radioButton1.Checked = true;
                else radioButton2.Checked = true;

                relativeFilePath = settingArray[2].ToString();
                textBox1.Text = Path.GetFullPath(settingArray[2].ToString());

                switch (settingArray[3].ToString())
                {
                    case "Low": comboBox2.SelectedIndex = 0; break;
                    case "Medium": comboBox2.SelectedIndex = 1; break;
                    case "High": comboBox2.SelectedIndex = 2; break;
                }

                Size p = (Size)settingArray[4];
                numericUpDown1.Value = p.Width;
                numericUpDown2.Value = p.Height;
                label13.Text = p.Width + "." + p.Height;

                numericUpDown3.Value = (int)settingArray[5];

                p = (Size)settingArray[6];
                numericUpDown4.Value = p.Width;
                numericUpDown5.Value = p.Height;

                p = (Size)settingArray[7];
                numericUpDown7.Value = p.Width;
                numericUpDown6.Value = p.Height;
            }
            catch
            {
                MessageBox.Show("Error loading settings");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "1920 x 1080 (16:9)": numericUpDown4.Text = "204"; numericUpDown5.Text = "264";
                                            numericUpDown7.Text = "510"; numericUpDown6.Text = "660"; break;
                case "1280 x 960 (4:3)": numericUpDown4.Text = "136"; numericUpDown5.Text = "235";
                                            numericUpDown7.Text = "340"; numericUpDown6.Text = "587"; break;
                case "1280 x 720 (16:9)": numericUpDown4.Text = "136"; numericUpDown5.Text = "176";
                                            numericUpDown7.Text = "340"; numericUpDown6.Text = "440"; break;
                default: numericUpDown4.Text = "204"; numericUpDown5.Text = "264";
                            numericUpDown7.Text = "510"; numericUpDown6.Text = "660"; break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.Description = "Select a folder to record files";
                fbd.SelectedPath = Path.GetFullPath("../../Record files");

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // abszolút útvonalak
                    string absolutePath = Application.StartupPath;
                    string filename = fbd.SelectedPath;
                    // relatív útvonal
                    relativeFilePath = Uri.UnescapeDataString(new Uri(absolutePath + "\\").MakeRelativeUri(new Uri(filename)).ToString());

                    textBox1.Text = Path.GetFullPath(relativeFilePath);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label13.Text = numericUpDown1.Value + "." + numericUpDown2.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label13.Text = numericUpDown1.Value + "." + numericUpDown2.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(numericUpDown4.Text) > int.Parse(numericUpDown7.Text)
                || int.Parse(numericUpDown5.Text) > int.Parse(numericUpDown6.Text))
                MessageBox.Show("Minimum object cannot be greater than maximum object");
            else
            {
                try
                {
                    string[] lines = new string[8];

                    switch (comboBox1.SelectedIndex)
                    {
                        case 1: lines[0] = "1920,1080"; break;
                        case 2: lines[0] = "1280,960"; break;
                        case 3: lines[0] = "1280,720"; break;
                        default: lines[0] = "Original"; break;
                    }

                    if (radioButton1.Checked) lines[1] = radioButton1.Text;
                    else lines[1] = radioButton2.Text;

                    lines[2] = relativeFilePath;
                    lines[3] = comboBox2.Text;
                    lines[4] = label13.Text;
                    lines[5] = numericUpDown3.Text;
                    lines[6] = numericUpDown4.Text + "," + numericUpDown5.Text;
                    lines[7] = numericUpDown7.Text + "," + numericUpDown6.Text;

                    File.WriteAllLines(@"../../Settings/P_settings.txt", lines);

                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("Error saving settings");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fillingForm("P_default.txt");
        }

    }
}
