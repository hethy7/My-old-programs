using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace VehicleDetectionApplication
{
    public partial class RMSettingForm : Form
    {
        bool leftMouseButtonIsDown;
        Point leftMouseButtonDownLocation = Point.Empty;
        Point currentMouseLocation = Point.Empty;

        Rectangle roiRect;
        Rectangle motionRect;

        public RMSettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            try
            {
                string readText = File.ReadAllText(@"../../Settings/RM_settings.txt");
                string[] rectParameters = readText.Split(',');

                roiRect = new Rectangle(int.Parse(rectParameters[0]), int.Parse(rectParameters[1]),
                    int.Parse(rectParameters[2]), int.Parse(rectParameters[3]));

                motionRect = new Rectangle(int.Parse(rectParameters[4]), int.Parse(rectParameters[5]),
                    int.Parse(rectParameters[6]), int.Parse(rectParameters[7]));

                imageBox1.Image = CvInvoke.Imread(@"../../Resources/capture.jpg");
                CvInvoke.Rectangle(imageBox1.Image, roiRect, new Bgr(Color.Blue).MCvScalar, 2);
                CvInvoke.Rectangle(imageBox1.Image, motionRect, new Bgr(Color.Green).MCvScalar, 2);
                Graphics graph = Graphics.FromImage(imageBox1.Image.Bitmap);
                graph.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Green, Color.Transparent),
                    motionRect.X, motionRect.Y, motionRect.Width, motionRect.Height);
            }
            catch
            {
                MessageBox.Show("Error loading settings");
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            leftMouseButtonIsDown = true;
            leftMouseButtonDownLocation = currentMouseLocation = e.Location;
            imageBox1.Invalidate();

            imageBox1.Image = CvInvoke.Imread(@"../../Resources/capture.jpg");

            if (comboBox1.SelectedItem.Equals("ROI (blue)"))
            {
                CvInvoke.Rectangle(imageBox1.Image, motionRect, new Bgr(Color.Green).MCvScalar, 2);
            }
            else
            {
                CvInvoke.Rectangle(imageBox1.Image, roiRect, new Bgr(Color.Blue).MCvScalar, 2);
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            leftMouseButtonIsDown = false;
            imageBox1.Invalidate();

            double sWidth = 1920.0 / imageBox1.Width;
            double sHeight = 1080.0 / imageBox1.Height;

            int x = (int)(sWidth * Math.Min(leftMouseButtonDownLocation.X, currentMouseLocation.X));
            int y = (int)(sHeight * Math.Min(leftMouseButtonDownLocation.Y, currentMouseLocation.Y));
            int width = (int)(sWidth * Math.Abs(leftMouseButtonDownLocation.X - currentMouseLocation.X));
            int height = (int)(sHeight * Math.Abs(leftMouseButtonDownLocation.Y - currentMouseLocation.Y));

            Rectangle rect = new Rectangle(x, y, width, height);

            if (comboBox1.SelectedItem.Equals("ROI (blue)"))
            {
                roiRect = rect;
                CvInvoke.Rectangle(imageBox1.Image, roiRect, new Bgr(Color.Blue).MCvScalar, 2);
            }
            else
            {
                motionRect = rect;
                CvInvoke.Rectangle(imageBox1.Image, motionRect, new Bgr(Color.Green).MCvScalar, 2);
                Graphics graph = Graphics.FromImage(imageBox1.Image.Bitmap);
                graph.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Green, Color.Transparent),
                    motionRect.X, motionRect.Y, motionRect.Width, motionRect.Height);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftMouseButtonIsDown)
            {
                currentMouseLocation = e.Location;
                imageBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (leftMouseButtonIsDown)
            {
                Rectangle rect = new Rectangle(
                        Math.Min(leftMouseButtonDownLocation.X, currentMouseLocation.X),
                        Math.Min(leftMouseButtonDownLocation.Y, currentMouseLocation.Y),
                        Math.Abs(leftMouseButtonDownLocation.X - currentMouseLocation.X),
                        Math.Abs(leftMouseButtonDownLocation.Y - currentMouseLocation.Y));

                Graphics G = e.Graphics;
                Pen pen;
                if (comboBox1.SelectedItem.Equals("ROI (blue)")) pen = new Pen(Color.Blue, 2);
                else pen = new Pen(Color.Green, 2);
                G.DrawRectangle(pen, rect);
                pen.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string createText = roiRect.X + "," + roiRect.Y + "," + roiRect.Width + "," + roiRect.Height + 
                    "," + motionRect.X + "," + motionRect.Y + "," + motionRect.Width + "," + motionRect.Height;

                File.WriteAllText(@"../../Settings/RM_settings.txt", createText);

                this.Dispose();
            }
            catch
            {
                MessageBox.Show("Error saving settings");
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            try
            {
                imageBox1.Invalidate();

                string readText = File.ReadAllText(@"../../Settings/RM_default.txt");
                string[] rectParameters = readText.Split(',');

                roiRect = new Rectangle(int.Parse(rectParameters[0]), int.Parse(rectParameters[1]),
                    int.Parse(rectParameters[2]), int.Parse(rectParameters[3]));

                motionRect = new Rectangle(int.Parse(rectParameters[4]), int.Parse(rectParameters[5]),
                    int.Parse(rectParameters[6]), int.Parse(rectParameters[7]));

                imageBox1.Image = CvInvoke.Imread(@"../../Resources/capture.jpg");

                CvInvoke.Rectangle(imageBox1.Image, roiRect, new Bgr(Color.Blue).MCvScalar, 2);
                CvInvoke.Rectangle(imageBox1.Image, motionRect, new Bgr(Color.Green).MCvScalar, 2);
                Graphics graph = Graphics.FromImage(imageBox1.Image.Bitmap);
                graph.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Green, Color.Transparent),
                    motionRect.X, motionRect.Y, motionRect.Width, motionRect.Height);               
            }
            catch
            {
                MessageBox.Show("Error loading default settings");
            }
        }
    }
}
