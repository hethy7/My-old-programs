using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Microsoft.Win32;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace VehicleDetectionApplication
{
    public partial class MainForm : Form
    {
        // -----Változók-----
        #region Variables

        VideoCapture capture; // videófelvétel
        string captureName, captureFormat; // videóinformációk (információs ablakhoz)
        double totalFrame, totalTime, fps; // videóinformációk (folyamatjelzőhöz, stb.)           
        bool ipCam; // ip kamera vagy videó?
        bool captureInProgress; // feldolgozás alatt-e?

        // videó kép feldolgozáshoz
        Mat frame = new Mat(); // videó kép
        Mat roiImg = new Mat(); // ROI kép
        Mat motionImg = new Mat(); // mozgásérzékelő kép
        Rectangle roiRect; // roi terület (téglalap)
        Rectangle motionRect; // mozgásérz. terület (téglalap)     

        // mozgásérzékeléshez (szürkeárnyalatos képek) 
        Mat firstImg = new Mat(); // első képkocka (háttér)
        Mat realTimeImg = new Mat(); // aktuális képkocka
        Mat motion = new Mat(); // mozgás (különbség => küszöbölés => erózió)
        bool background; // van-e háttérkép?
        int motionThres; // mozgásküszöb
        int isMotion = 0; // van-e mozgás? 0 - nincs, 1 - elölről, 2 - hátulról
        List<int> motionList = new List<int>(); // mozgásértékek 1 sec alatt     

        // gépjármű felismeréshez
        List<Rectangle> vehicles = new List<Rectangle>(); // gépjárművek listája
        Mat grayImg = new Mat(); // szürkeárnyalatos kép (előfeldolgozás)
        int vehicleFrame, noVehicleFrame; // egymás utáni detektálások és nem detektálások száma

        // üzenetküldéshez (globális változók)
        public static string to, from, pass, mess; // tel.szám, email, jelszó, üzenet

        // alkalmazás beállításához
        int videoResolution; // videófelbontás 
        string fileFormat, filePath; // rögzített fájl formátuma és helye 
        string motionDetLevel; // mozgásérzékelési szint 
        // detektor beállításai
        double scaleFactor; // skálafaktor
        int minNeghbours; // min.szomszédok
        Size minObject, maxObject; // min.objektum, max.objektum

        // teszteléshez -----
        /*Stopwatch watch = new Stopwatch();
        Stopwatch watch2 = new Stopwatch();
        int wc, wc2;*/
        // ------------------
        #endregion


        // -----Alkalmazás vezérlése-----
        #region Controls

        // Main Form
        public MainForm()
        {
            InitializeComponent();
            imageBox1.Controls.Add(imageBox4);
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            SetApplicationParameters();
        }

        //1. Lejátszás/Szünet (Start gomb + menüsáv)
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (ipCam)
            {
                try
                {
                    // ezt még külső ip-re rakni!!! (máskülönben lefagy a program nem otthoni hálózat esetén)
                    capture = new VideoCapture("rtsp://admin:Matyi514@192.168.0.254/user=admin_password=QuQ34dJE_channel=1_stream=0.sdp");

                    SetVideoProcessParameters();

                    Application.Idle += ProcessFrame;
                    captureInProgress = true;

                    checkBoxIPCam.Enabled = false;                
                    buttonVideo.Enabled = false;
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                    buttonFullScreen.Enabled = true;
                    buttonBackground.Visible = true;
                    buttonBackground2.Visible = true;
                    labelMotion.Visible = true;
                    panelActivation.Visible = true;

                    iPCameraToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    playPauseToolStripMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = true;
                    fullScreenToolStripMenuItem.Enabled = true;
                    backgroundToolStripMenuItem.Enabled = true;

                    //Futásidő teszteléséhez
                    //watch.Start();
                    // ----------

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else PlayPauseVideo();
        }


        //1. Lejátszás/Szünet metódus
        private void PlayPauseVideo()
        {
            if (captureInProgress)
            {
                Application.Idle -= ProcessFrame;
                buttonStart.Text = "START";
                imageBox4.BackgroundImage = imageBox4.InitialImage;
            }
            else
            {
                Application.Idle += ProcessFrame;
                buttonStart.Text = "PAUSE";
                imageBox4.BackgroundImage = imageBox4.ErrorImage;
            }

            captureInProgress = !captureInProgress;

            checkBoxIPCam.Enabled = false;
            buttonVideo.Enabled = false;
            buttonStop.Enabled = true;
            buttonBackground.Enabled = true;

            iPCameraToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;            
            closeToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            gotoStartToolStripMenuItem.Enabled = true;
            backgroundToolStripMenuItem.Enabled = true;

            //Futásidő teszteléséhez            
            //watch.Start();
            // ----------
        }

        //1. Lejátszás/Szünet (videó)
        private void imageBox4_Click(object sender, EventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero && !ipCam)
            {
                PlayPauseVideo();
            }
        }

        //1. Lejátszás/Szünet megjelenítése (vidón belül)
        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero && !ipCam &&
                imageBox4.Location.X <= e.X && e.X <= imageBox4.Location.X + imageBox4.Width
                && imageBox4.Location.Y <= e.Y && e.Y <= imageBox4.Location.Y + imageBox4.Height)
            {
                imageBox4.Visible = true;
                this.Cursor = Cursors.Hand;
            }
            else
            {
                if (buttonStop.Enabled) imageBox4.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }


        //2. Videófelvétel leállítása (videó + ip cam - Stop gomb + menüsáv)
        private void buttonStop_Click(object sender, EventArgs e)
        {
            CaptureStop();

            imageBox1.Image = null;
            imageBox2.Image = null;
            imageBox3.Image = null;
        }

        //2. Leállítás metódus
        private void CaptureStop()
        {
            //Futási idő leállítása és teszteredmények kiírása
            /*if (watch.IsRunning)
            {
                watch2.Stop();
                watch.Stop();

                int mvidTime = (int)Math.Round(watch.Elapsed.TotalMilliseconds);
                int mdetTime = (int)Math.Round(watch2.Elapsed.TotalMilliseconds);
                int vidLength = (int)(wc * 1000 / fps);
                int detLength = (int)(wc2 * 1000 / fps);
                double vidFrame = Math.Round((double)mvidTime / wc, 2);
                double detFrame;
                if (detLength != 0) detFrame = Math.Round((double)mdetTime / wc2, 2);
                else detFrame = 0;
                double vidX = Math.Round((double)mvidTime / vidLength, 2);
                double detX;
                if (detLength != 0) detX = Math.Round((double)mdetTime / detLength, 2);
                else detX = 0;
                

                MessageBox.Show("Teljes futási idő:" + mvidTime + "ms, Videó hossza: " + vidLength + 
                    "ms, \r\n1 framehez szükséges idő: " + vidFrame + "ms, Futási idő / videó hossza: " + vidX +
                                "\r\nDetektálási futási idő:" + mdetTime + "ms, Detektálás hossza: " + detLength + 
                     "ms, \r\n1 frame szükséges idő: " + detFrame + "ms, Futási idő / videó hossza: " + detX);

                watch2.Reset();
                watch.Reset();

                wc = 0;
                wc2 = 0;
            }*/
            // ----------

            if (captureInProgress) Application.Idle -= ProcessFrame;

            if (capture != null) capture.Dispose();

            captureInProgress = false;
            NoMotion();

            checkBoxIPCam.Enabled = true;
            checkBoxIPCam.Checked = false;
            buttonVideo.Enabled = true;
            buttonStart.Enabled = false;
            buttonStart.Text = "START";
            buttonStop.Enabled = false;
            buttonFullScreen.Enabled = false;
            buttonBackground.Visible = false;
            buttonBackground2.Visible = false;
            labelMotion.Visible = false;
            panelActivation.Visible = false;
            panelVideoProgress.Visible = false;
            trackBarVideo.Value = 0;
            imageBox4.BackgroundImage = imageBox4.InitialImage;
            imageBox4.Visible = false;

            iPCameraToolStripMenuItem.Enabled = true;
            iPCameraToolStripMenuItem.Checked = false;
            openToolStripMenuItem.Enabled = true;
            playPauseToolStripMenuItem.Enabled = false;
            gotoStartToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            fullScreenToolStripMenuItem.Enabled = false;
            backgroundToolStripMenuItem.Enabled = false;
            informationToolStripMenuItem.Enabled = false;
        }


        //3. IP kamera beállítása (checkBox)
        private void checkBoxIPCam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIPCam.Checked)
            {
                ipCam = true;
                buttonStart.Enabled = true;
                buttonStart.Select();
                iPCameraToolStripMenuItem.Checked = true;
                playPauseToolStripMenuItem.Enabled = true;
            }
            else
            {
                ipCam = false;
                buttonStart.Enabled = false;
                iPCameraToolStripMenuItem.Checked = false;
                playPauseToolStripMenuItem.Enabled = false;
            }
        }

        //3. IP kamera beállítása (menüsáv)
        private void iPCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkBoxIPCam.Checked)
            {
                ipCam = true;
                buttonStart.Enabled = true;
                buttonStart.Select();              
                checkBoxIPCam.Checked = true;
                iPCameraToolStripMenuItem.Checked = true;
                playPauseToolStripMenuItem.Enabled = true;
            }
            else
            {
                ipCam = false;
                buttonStart.Enabled = false;
                checkBoxIPCam.Checked = false;
                iPCameraToolStripMenuItem.Checked = false;
                playPauseToolStripMenuItem.Enabled = false;
            }
        }


        //4. Videó beolvasás (Video gomb + menüsáv)
        private void buttonVideo_Click(object sender, EventArgs e)
        {
            if (ipCam)
            {
                ipCam = false;
                checkBoxIPCam.Checked = false;
                iPCameraToolStripMenuItem.Checked = false;
            }

            LoadVideo();
        }

        //4. Beolvasás metódus (//5. Folyamatjelző)
        private void LoadVideo()
        {
            OpenFileDialog ofdVideo = new OpenFileDialog();
            ofdVideo.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../videok"));
            ofdVideo.Filter = "All files (*.*)|*.*|mp4 files(*.mp4)|*.mp4|avi files(*.avi)|*.avi";
            ofdVideo.FilterIndex = 1;
            ofdVideo.RestoreDirectory = true;

            if (ofdVideo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    capture = new VideoCapture(ofdVideo.FileName);

                    SetVideoProcessParameters();

                    imageBox1.Image = capture.QueryFrame();

                    captureName = ofdVideo.SafeFileName;
                    captureFormat = Path.GetExtension(ofdVideo.FileName);
                    totalFrame = capture.GetCaptureProperty(CapProp.FrameCount);
                    fps = capture.GetCaptureProperty(CapProp.Fps);
                    totalTime = totalFrame / fps;

                    buttonStart.Enabled = true;
                    buttonStart.Select();
                    buttonFullScreen.Enabled = true;
                    buttonBackground.Visible = true;
                    buttonBackground2.Visible = true;
                    labelMotion.Visible = true;
                    panelActivation.Visible = true;
                    checkBoxIPCam.Enabled = false;

                    trackBarVideo.Minimum = 0;
                    trackBarVideo.Maximum = (int)totalFrame;
                    labelTime.Text = "0:00 / " + ConvertDoubleToTime(totalTime);
                    panelVideoProgress.Visible = true;
                    imageBox4.Visible = true;

                    playPauseToolStripMenuItem.Enabled = true;
                    closeToolStripMenuItem.Enabled = true;
                    fullScreenToolStripMenuItem.Enabled = true;
                    backgroundToolStripMenuItem.Enabled = true;
                    informationToolStripMenuItem.Enabled = true;
                    iPCameraToolStripMenuItem.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //5. Idő formátumra alakítás
        public static string ConvertDoubleToTime(double times)
        {
            if (times >= 3600) return TimeSpan.FromSeconds(times).ToString(@"h\:mm\:ss");
            else return TimeSpan.FromSeconds(times).ToString(@"m\:ss");
        }

        //5. Folyamatjelző átméretezése (idő formátumhoz igazodva)
        private void labelTime_SizeChanged(object sender, EventArgs e)
        {
            panelVideoProgress.Size = new Size(0, 0);
            panelVideoProgress.AutoSize = true;

            panelVideoProgress.Dock = DockStyle.Fill;
            Point location = new Point(panelVideoProgress.Location.X, panelVideoProgress.Location.Y);
            panelVideoProgress.Dock = DockStyle.None;
            if (panelVideoProgress.Location.X < 0 || panelVideoProgress.Location.Y < 0) panelVideoProgress.Location = location;
            panelVideoProgress.Anchor = AnchorStyles.Bottom;
        }

        //5. Folyamatjelző érték módosítása (egér lenyom)
        private void trackBarVideo_MouseDown(object sender, MouseEventArgs e)
        {
            if (captureInProgress) Application.Idle -= ProcessFrame;
        }

        //5. Folyamatjelző érték módosítása (egér felenged)
        private void trackBarVideo_MouseUp(object sender, MouseEventArgs e)
        {
            if (!buttonStop.Enabled) trackBarVideo.Value = 0;
            else
            {
                capture.SetCaptureProperty(CapProp.PosFrames, trackBarVideo.Value);
                ProcessFrame(sender, e);
                imageBox1.Focus();

                if (captureInProgress) Application.Idle += ProcessFrame;
            }
        }

        //5. Folyamatjelző érték módosítása (videó újraindítása - menüsáv)
        private void gotoStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBarVideo.Value = 0;
            capture.SetCaptureProperty(CapProp.PosFrames, trackBarVideo.Value);
        }


        //6. Teljes képernyő megnyitása (FullScreen gomb + menüsáv)
        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            FullScreenEnter();
        }

        //6. Belépés a teljes képernyőbe metódus
        private void FullScreenEnter()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Padding = new Padding(0, 0, 0, 0);

            menuStrip1.Visible = false;
            panel1.Dock = DockStyle.Fill;
            imageBox1.Dock = DockStyle.Fill;
            panel1.BringToFront();
            imageBox1.BringToFront();
            panelActivation.BringToFront();
            imageBox1.Focus();

            if (!ipCam)
            {
                panelVideoProgress.Location = new Point(
                    imageBox1.Width / 2 - panelVideoProgress.Size.Width / 2,
                    imageBox1.Height - panelVideoProgress.Size.Height);

                panelVideoProgress.BringToFront();
                imageBox4.BringToFront();
            }
        }

        //6. Kilépés a teljes képernyőből metódus
        private void FullScreenExit()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.Padding = new Padding(9, 3, 9, 10);
            this.Size = new Size(1442, 664);

            menuStrip1.Visible = true;
            panel1.Dock = DockStyle.None;
            panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            imageBox1.Dock = DockStyle.None;
            imageBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);

            FormResize();
            if (!panel2.Visible) this.Width = this.Width - panel2.Width;

            if (!ipCam)
            {
                panelVideoProgress.Location = new Point(imageBox1.Width / 2 - panelVideoProgress.Size.Width / 2,
                      imageBox1.Height - panelVideoProgress.Size.Height);

                buttonStart.Select();
            }
        }

        //6. Teljes képernyő (egér) - Belépés/Kilépés
        private void imageBox1_DoubleClick(object sender, EventArgs e)
        {
            if (imageBox1.Dock == DockStyle.None) FullScreenEnter();
            else FullScreenExit();
        }

        //6. Teljes képernyő (billentyű) - Kilépés, Lejátszás/Szünet
        private void imageBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FullScreenExit();
            }
            else if (e.KeyCode == Keys.Space && !ipCam)
            {
                PlayPauseVideo();
            }
        }


        //7. Reszponzív felhasználói felület (különböző képernyő felbontáshoz, méretezéshez)
        private void MainForm_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        //7. Panel2 hiányában a form megfelelő méretűvé alakítása
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (!panel2.Visible) this.Width = this.Width - panel2.Width;
        }

        //7. Alkalmazás méretezése képernyő felbontás változáskor
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1442, 664);

            panel1.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.None;
            panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);

            FormResize();
            if (!panel2.Visible) this.Width = this.Width - panel2.Width;
        }

        //7. Alkalmazás átméretezése (felbontás alapján)
        private void FormResize()
        {
            if (this.Width > 200 && this.Width < 1394)
            {
                if (this.Width > 1200)
                {
                    panel2.Location = new Point(panel1.Width + 15, panel1.Location.Y);
                    panel2.Width = this.Width - panel1.Width - 40;
                    if (!panel2.Visible)
                    {
                        panel2.Visible = true;
                        panel3.Visible = false;
                    }

                }
                else
                {
                    panel2.Visible = false;
                    panel3.Visible = true;
                }
            }
            else if (panel2.Width != 604)
            {
                panel2.Location = new Point(panel1.Width + 15, panel1.Location.Y);
                panel2.Width = this.Width - panel1.Width - 40;
                panel2.Visible = true;
                panel3.Visible = false;

            }
            else if (!panel2.Visible)
            {
                panel2.Visible = true;
                panel3.Visible = false;
            }
        }


        //8. Értesítési funkció beállítása (egyik gomb)
        private void checkBoxNotice_CheckedChanged(object sender, EventArgs e)
        {
            if (pass == null && (!checkBoxNotice2.Checked && !notificationToolStripMenuItem.Checked))
                new MessageForm().ShowDialog();
            else if (!checkBoxNotice.Checked) pass = null;

            if (pass != null && pass.Equals(""))
            {
                checkBoxNotice.Checked = false;
                pass = null;
            }

            checkBoxNotice2.Checked = checkBoxNotice.Checked;
            notificationToolStripMenuItem.Checked = checkBoxNotice.Checked;

        }

        //8. Értesítési funkció beállítása (másik gomb)
        private void checkBoxNotice2_CheckedChanged(object sender, EventArgs e)
        {
            if (pass == null && (!checkBoxNotice.Checked && !notificationToolStripMenuItem.Checked))
                new MessageForm().ShowDialog();
            else if (!checkBoxNotice2.Checked) pass = null;

            if (pass != null && pass.Equals(""))
            {
                checkBoxNotice2.Checked = false;
                pass = null;
            }

            checkBoxNotice.Checked = checkBoxNotice2.Checked;
            notificationToolStripMenuItem.Checked = checkBoxNotice2.Checked;
        }

        //8. Értesítési funkció beállítása (menüsáv)
        private void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pass == null && !notificationToolStripMenuItem.Checked)
            {
                new MessageForm().ShowDialog();
                notificationToolStripMenuItem.Checked = true;
            }
            else pass = null;

            if (pass != null && pass.Equals(""))
            {
                notificationToolStripMenuItem.Checked = false;
                pass = null;
            }

            if (pass == null)
            {
                checkBoxNotice.Checked = false;
                checkBoxNotice2.Checked = false;
                notificationToolStripMenuItem.Checked = false;
            }
            else
            {
                checkBoxNotice.Checked = true;
                checkBoxNotice2.Checked = true;
            }
        }


        //9. Háttérkép beállítása manuálisan (Background gomb + menüsáv)
        private void buttonBackground_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null && capture.Ptr != IntPtr.Zero)
                {
                    CvInvoke.CvtColor(motionImg, firstImg, ColorConversion.Rgb2Gray);
                    imageBox2.Image = roiImg;
                }
            }
            catch { }
        }


        //10. ROI és mozgás terület beállítása (ROI/Motion gomb + menüsáv)
        private void buttonSetRoiMotion_Click(object sender, EventArgs e)
        {
            if (!ipCam && captureInProgress)
            {
                PlayPauseVideo();
                captureInProgress = !captureInProgress;
            }

            new RMSettingForm().ShowDialog();

            if (capture != null && capture.Ptr != IntPtr.Zero) SetVideoProcessParameters();

            if (!ipCam && captureInProgress)
            {
                captureInProgress = !captureInProgress;
                PlayPauseVideo();
            }
        }


        //11. Alkalmazás további beállításai (menüsáv)
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ipCam && captureInProgress)
            {
                PlayPauseVideo();
                captureInProgress = !captureInProgress;
            }

            new SettingForm().ShowDialog();
            SetApplicationParameters();

            if (capture != null && capture.Ptr != IntPtr.Zero) SetVideoProcessParameters();

            if (!ipCam && captureInProgress)
            {
                captureInProgress = !captureInProgress;
                PlayPauseVideo();
            }           
        }


        //12. Videó információk (menüsáv)
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string time = ConvertDoubleToTime(totalTime);

            if (time.Length > 5) time += " hrs";
            else time += " min";

            MessageBox.Show("Name: " + captureName + "\nFormat: " + captureFormat.Replace(".", String.Empty) +
                "\nResolution: " + capture.Width + "x" + capture.Height +
                "\nFrame rates: " + fps + " fps" + "\nTime: " + time,
                "Video information");
        }


        //13. Program névjegye (menüsáv)
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vehicle Detection Application" + "\n\n" + "Made by Héthy Zoltán", "About");
        }


        //14. Alkalmazás bezárása (menüsáv)
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #endregion


        // -----Alkalmazás és videó beállításai-----
        #region Settings

        // Alkalmazás beállításai
        private void SetApplicationParameters()
        {
            try
            {
                string readText = File.ReadAllText(@"../../Settings/P_settings.txt");
                string[] settingText = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // videófelbontás
                switch (settingText[0])
                {
                    case "1920,1080": videoResolution = 1; break;
                    case "1280,960": videoResolution = 2; break;
                    case "1280,720": videoResolution =3; break;
                    default: videoResolution = 0; break;
                }

                fileFormat = settingText[1]; // rögzített fájl formátuma
                filePath = settingText[2]; // rögzített fájl helye (relatív útvonal)

                motionDetLevel = settingText[3]; // mozgásérzékelési szint

                settingText[4] = settingText[4].Replace(".", ",");
                scaleFactor = double.Parse(settingText[4]); // skálafaktor
                minNeghbours = int.Parse(settingText[5]); // min.szomszédok
                string[] points = settingText[6].Split(',');
                minObject = new Size(int.Parse(points[0]), int.Parse(points[1])); // min. objektum
                points = settingText[7].Split(',');
                maxObject = new Size(int.Parse(points[0]), int.Parse(points[1])); // max. objektum
            }
            catch
            {
                MessageBox.Show("Error loading settings");
            }
        }

        // Paraméterek beállítása a videó feldolgozáshoz (felbontás alapján)
        private void SetVideoProcessParameters()
        {
            // Videófelbontás beállítása
            int frameWidth, frameHeight;
            switch (videoResolution)
            {
                // FHD felbontás (1920x1080 16:9 képarány)
                case 1: frameWidth = 1920; frameHeight = 1080; break;
                // SXGA felbontás (1280x960 4:3 képarány)
                case 2: frameWidth = 1280; frameHeight = 960; break;
                // WXGA/HD felbontás (1280x720 16:9 képarány)
                case 3: frameWidth = 1280; frameHeight = 720; break;
                // eredeti képfelbontás (kamera esetén 1920x1080)
                default: frameWidth = (int)capture.GetCaptureProperty(CapProp.FrameWidth);
                    frameHeight = (int)capture.GetCaptureProperty(CapProp.FrameHeight); break;
            }

            // (full hd képernyőre számítva)
            double sWidth = frameWidth / 1920.0;
            double sHeight = frameHeight / 1080.0;

            // ROI és mozgásérzékelő terület beállítása
            string readText = File.ReadAllText(@"../../Settings/RM_settings.txt");
            string[] rectParameters = readText.Split(',');

            // ROI terület kiszámítása
            int x = (int)(sWidth * int.Parse(rectParameters[0]));
            int y = (int)(sHeight * int.Parse(rectParameters[1]));
            int width = (int)(sWidth * int.Parse(rectParameters[2]));
            int height = (int)(sHeight * int.Parse(rectParameters[3]));
            roiRect = new Rectangle(x, y, width, height);

            // mozgásterület kiszámítása
            x = (int)(sWidth * int.Parse(rectParameters[4]));
            y = (int)(sHeight * int.Parse(rectParameters[5]));
            width = (int)(sWidth * int.Parse(rectParameters[6]));
            height = (int)(sHeight * int.Parse(rectParameters[7]));
            motionRect = new Rectangle(x, y, width, height);

            // a küszöbérték beállítása (a mozgásterület 1/3, 1/4 vagy 1/5 része)
            switch (motionDetLevel)
            {
                case "Low": motionThres = (width * height) / 3; break;
                case "Medium": motionThres = (width * height) / 4; break;
                case "High": motionThres = (width * height) / 5; break;
            }
                                 
            background = false; // háttérkép nincs
        }

        #endregion


        // -----Kamerakép feldolgozása-----
        #region Process Camera Frame

        // Videó kép feldolgozása
        private void ProcessFrame(object sender, EventArgs e)
        {
            // tesztekhez
            //wc++;
            // ----------

            if (capture != null && capture.Ptr != IntPtr.Zero)
            {
                // aktuális frame beolvasása
                capture.Read(frame);

                try
                {
                    // Képfelbontás átalakítása a teljesítmény miatt
                    switch (videoResolution)
                    {
                        // FHD felbontás (1920x1080 16:9 képarány)
                        case 1: CvInvoke.Resize(frame, frame, new Size(1920, 1080), 0, 0, Inter.Linear); break;
                        // SXGA felbontás (1280x960 4:3 képarány)
                        case 2: CvInvoke.Resize(frame, frame, new Size(1280, 960), 0, 0, Inter.Linear); break;
                        // WXGA/HD felbontás (1280x720 16:9 képarány)
                        case 3: CvInvoke.Resize(frame, frame, new Size(1280, 720), 0, 0, Inter.Linear); break;
                    }
                }
                catch { }

                if (!frame.Size.IsEmpty)
                {
                    // Roi kép
                    Mat _frame = new Mat(frame, roiRect);
                    _frame.CopyTo(roiImg);
                    _frame.Dispose();

                    // mozgásérzékelő kép
                    _frame = new Mat(frame, motionRect);
                    _frame.CopyTo(motionImg);
                    _frame.Dispose();

                    // ROI és mozgásterület megjelölése
                    CvInvoke.Rectangle(frame, roiRect, new Bgr(Color.Blue).MCvScalar, 2);
                    CvInvoke.Rectangle(frame, motionRect, new Bgr(Color.Green).MCvScalar, 2);
                    Graphics graph = Graphics.FromImage(frame.Bitmap);
                    graph.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Green, Color.Transparent),
                        motionRect.X, motionRect.Y, motionRect.Width, motionRect.Height);

                    imageBox1.Image = frame; // kép kirajzolása

                    // folyamatjelző
                    if (!ipCam)
                    {
                        double framenumber = capture.GetCaptureProperty(CapProp.PosFrames);
                        if (framenumber < trackBarVideo.Maximum) trackBarVideo.Value = (int)framenumber;
                        labelTime.Text = ConvertDoubleToTime(framenumber / fps) + " / " + ConvertDoubleToTime(totalTime);
                    }

                    Motion(motionImg); // mozgásérzékelés + mozgásirány 

                    // mozgás esetén gépjármű detektálás (megfelelő xml betöltésével)
                    if (isMotion != 0)
                    {
                        //Futásidő teszteléséhez
                        /*wc2++;
                        if (watch2.IsRunning == false) watch2.Start();*/
                        // ----------

                        if (isMotion == 1) VehicleDetection(roiImg, @"../../Cascades/frontveh_LBP17.xml"); // elölnézetből
                        else VehicleDetection(roiImg, @"../../Cascades/rearveh_LBP19.xml"); // hátulnézetből
                    }

                    // mozgás + 1 sec gépjármű érzékelés esetén üzenetküldés + képmentés
                    if (isMotion !=0 && vehicleFrame == (int)fps)
                    {
                        // kép mentése az alkalmazásban + a számítógépen
                        imageBox2.Image = roiImg;
                        SaveImage(fileFormat, filePath);

                        // értesítés küldése, ha van jelszó beállítva
                        if (isMotion == 1 && pass != null) SendMessage();
                    }

                }
                else
                {
                    // videó vége
                    CaptureStop();

                    imageBox1.Image = CvInvoke.Imread(@"../../Resources/novideo.jpg");
                    imageBox2.Image = CvInvoke.Imread(@"../../Resources/noimage1.jpg");
                    imageBox3.Image = CvInvoke.Imread(@"../../Resources/noimage2.jpg");
                }
            }
        }

        #endregion


        // -----Mozgásérzékelés-----
        #region Motion Detection

        // Háttér beállítása
        private void Background(Mat motFrame1)
        {
            try
            {
                CvInvoke.CvtColor(motFrame1, firstImg, ColorConversion.Rgb2Gray);
                background = true;
            }
            catch
            {
                background = false;
            }
        }

        // Mozgásérzékelés / mozgásirány számítása
        private void Motion(Mat motFrame)
        {
            // van háttér beállítva?
            if (background == true)
            {
                CvInvoke.CvtColor(motFrame, realTimeImg, ColorConversion.Rgb2Gray); // szürkeárnyalatos kép

                // mozgás kiszámítása (különbség, binarizálás, erózió)
                CvInvoke.AbsDiff(firstImg, realTimeImg, motion);
                CvInvoke.Threshold(motion, motion, 20, 255, ThresholdType.Binary);
                var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(3, 3), new Point(-1, -1));
                CvInvoke.Erode(motion, motion, element, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));

                imageBox3.Image = motion; // mozgás kirajzolása

                int motionVal = CvInvoke.CountNonZero(motion); // mozgásérték számolása
                labelMotion.Text = "Motion value: " + motionVal.ToString() + " : " + motionThres.ToString() + " ( thresold )";

                // mozgáslista (1 sec alatti átlagmozgás)
                motionList.Add(motionVal);
                if (motionList.Count > (int)fps) motionList.RemoveAt(0);

                motionVal = 0;
                foreach (var motion in motionList) motionVal += motion;

                // ha az átlagmozgás > mozgásküszöb v gépjárműérzékelés => van mozgás
                if ((motionVal != 0 && ((motionVal / motionList.Count) > motionThres)) || vehicleFrame != 0)
                {
                    // mozgásirány meghatározása
                    if (isMotion == 0)
                    {
                        panelActivation.BackColor = Color.Lime;
                        imageBox2.Image = roiImg; // kép kirajzolása

                        int firstRow = CvInvoke.CountNonZero(motion.Row(0)); // mozgásterület 1. sora
                        int lastRow = CvInvoke.CountNonZero(motion.Row(motion.Height - 1)); // utolsó sora

                        // mozágs előlről vagy hátulról?
                        if (firstRow < lastRow) isMotion = 2; // hátulról
                        else isMotion = 1; // elölről
                    }
                }
                else NoMotion(); // nincs mozgás
            }
            else
            {
                // nincs háttér
                Background(motFrame);
                imageBox2.Image = roiImg;
            }
        }

        // Nincs mozgás beállítása
        private void NoMotion()
        {
            // teszteléshez
            //if (watch2.IsRunning == true) watch2.Stop();
            // ----------

            panelActivation.BackColor = Color.Red;
            motionList.Clear();
            isMotion = 0;

            vehicleFrame = 0;
            noVehicleFrame = 0;
        }

        #endregion


        // -----Gépjármű felismerés-----
        #region Vehicle Detection
        private void VehicleDetection(Mat roiFrame, string xmlPath)
        {
            // kaszkád fájl beolvasása
            CascadeClassifier vehicle = new CascadeClassifier(xmlPath);

            // szürkeárnyalatos kép és hisztogram kiegyenlítés
            CvInvoke.CvtColor(roiFrame, grayImg, ColorConversion.Rgb2Gray);
            CvInvoke.EqualizeHist(grayImg, grayImg);

            // gépjármű detektálás
            Rectangle[] vehiclesDetected =
                vehicle.DetectMultiScale(roiFrame, scaleFactor, minNeghbours, minObject, maxObject);
            vehicles.AddRange(vehiclesDetected);            

            if (vehicles.Count != 0)
            {
                // gépjármű megjelölése
                foreach (Rectangle veh in vehicles)
                    CvInvoke.Rectangle(frame, new Rectangle(new Point(veh.X + roiRect.X, veh.Y + roiRect.Y),
                        new Size(veh.Width, veh.Height)), new Bgr(Color.Red).MCvScalar, 2);

                vehicleFrame++; // gépjárművet tartalmazó frame
                noVehicleFrame = 0;
            }
            else noVehicleFrame++; // ha nem talál gépjárművet

            if (noVehicleFrame == 10)
            {
                vehicleFrame = 0;
                noVehicleFrame = 0;
            }

            vehicle.Dispose();
            vehicles.Clear();
        }

        #endregion


        // -----Kép mentése-----
        #region Save Image

        private void SaveImage(string imgFormat, string imgPath)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("hhmmss");
            ImageFormat imgf;
            if (imgFormat.Equals("JPEG")) imgf = ImageFormat.Jpeg;
            else imgf = ImageFormat.Png;

            try
            {
                if (Directory.Exists(imgPath))
                    capture.QueryFrame().Bitmap.Save(Path.Combine(imgPath, fileName + "." + imgFormat), imgf);
                else
                {
                    Directory.CreateDirectory(imgPath);
                    capture.QueryFrame().Bitmap.Save(Path.Combine(imgPath, fileName + "." + imgFormat), imgf);
                }
            }
            catch (Exception) { };
        }

        #endregion


        // -----Értesítés küldése-----
        #region Send Notification        

        /* küldés előtt be kell állítani ezt a google fiókban! (le van tiltva)
        //https://myaccount.google.com/lesssecureapps                       */

            // Üzenet küldés (email to sms)
        private void SendMessage()
        {
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mess;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                //smtp.Send(message); // korlátozott lehetőség van az SMS küldésre!!!
                MessageBox.Show("Send succesfully");
            }
            catch (Exception) { }
        }

        #endregion
    }
}