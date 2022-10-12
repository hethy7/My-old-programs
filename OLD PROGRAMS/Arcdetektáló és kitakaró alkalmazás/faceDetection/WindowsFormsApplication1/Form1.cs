using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap eredetiKep;
        List<Rectangle> arcok;

        private void Button1_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.png) | *.bmp; *.jpg; *.jpeg; *.png; | All files (*.*) | *.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            TextBox1.Text = openFileDialog1.FileName;
                            Image kep = Image.FromFile(openFileDialog1.FileName);
                            pictureBox1.Image = kep;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            eredetiKep = (Bitmap)kep;
                            arcok = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (eredetiKep == null) return;

            Image<Bgr, Byte> image = new Image<Bgr, byte>(eredetiKep);
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
            foreach (Rectangle face in faces)
                image.Draw(face, new Bgr(Color.Red), 2);
            foreach (Rectangle eye in eyes)
                image.Draw(eye, new Bgr(Color.Blue), 2);

            pictureBox1.Image = image.Bitmap;
            arcok = faces;

            toolStripStatusLabel2.Text = detectionTime + " milliseconds";

            if (faces.Count == 0) MessageBox.Show("Nem található arc a képen!");
            else MessageBox.Show(faces.Count + " darab arc található a képen!");
        }

        private static Bitmap cropImage(Bitmap bmpImage, Rectangle cropArea)
        {
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (arcok == null || comboBox1.SelectedItem == null) return;

            switch (comboBox1.SelectedIndex)
            {
                case 0: Elmosas(); break;
                case 1: Negalas(); break;
                case 2: Arccsere(); break;
                default: break;
            }
        }

        private void Elmosas()
        {
            Bitmap aktualisKep = new Bitmap(eredetiKep);
            Bitmap kep;

            Stopwatch watch;
            long detectionTime;
            watch = Stopwatch.StartNew();

            foreach (Rectangle arc in arcok)
            {
                kep = cropImage(eredetiKep, arc);
                GaussianBlur gauss = new GaussianBlur(kep);
                kep = gauss.Process(10);
                Graphics g = Graphics.FromImage(aktualisKep);
                g.DrawImage(kep, arc.X, arc.Y, arc.Width, arc.Height);
            }

            pictureBox1.Image = aktualisKep;

            watch.Stop();
            detectionTime = watch.ElapsedMilliseconds;
            toolStripStatusLabel2.Text = detectionTime + " milliseconds";
        }

        private void Negalas()
        {
            Bitmap aktualisKep = new Bitmap(eredetiKep);
            Bitmap kep;

            Stopwatch watch;
            long detectionTime;

            watch = Stopwatch.StartNew();

            foreach (Rectangle arc in arcok)
            {
                kep = cropImage(eredetiKep, arc);
                kep = Invert(kep);
                Graphics g = Graphics.FromImage(aktualisKep);
                g.DrawImage(kep, arc.X, arc.Y, arc.Width, arc.Height);
            }

            pictureBox1.Image = aktualisKep;

            watch.Stop();
            detectionTime = watch.ElapsedMilliseconds;
            toolStripStatusLabel2.Text = detectionTime + " milliseconds";
        }

        private void Arccsere()
        {
            Bitmap aktualisKep = new Bitmap(eredetiKep);
            Bitmap kep;

            Stopwatch watch;
            long detectionTime;

            watch = Stopwatch.StartNew();

            foreach (Rectangle arc in arcok)
            {
                kep = (Bitmap)Image.FromFile(@"../../anonymous.jpeg", true);
                Graphics g = Graphics.FromImage(aktualisKep);
                g.DrawImage(kep, arc.X, arc.Y, arc.Width, arc.Height);
            }

            pictureBox1.Image = aktualisKep;

            watch.Stop();
            detectionTime = watch.ElapsedMilliseconds;
            toolStripStatusLabel2.Text = detectionTime + " milliseconds";
        }

        public static Bitmap Invert(Bitmap b)
        {
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return b;
        }

    }
}
