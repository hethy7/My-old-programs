namespace VehicleDetectionApplication
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonBackground = new System.Windows.Forms.Button();
            this.labelMotion = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxIPCam = new System.Windows.Forms.CheckBox();
            this.buttonVideo = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.trackBarVideo = new System.Windows.Forms.TrackBar();
            this.panelVideoProgress = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelActivation = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxNotice2 = new System.Windows.Forms.CheckBox();
            this.buttonSetRoiMotion2 = new System.Windows.Forms.Button();
            this.buttonBackground2 = new System.Windows.Forms.Button();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.checkBoxNotice = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSetRoiMotion = new System.Windows.Forms.Button();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roiMotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideo)).BeginInit();
            this.panelVideoProgress.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBackground
            // 
            this.buttonBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBackground.Location = new System.Drawing.Point(3, 708);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(130, 27);
            this.buttonBackground.TabIndex = 9;
            this.buttonBackground.Text = "Set Background";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Visible = false;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // labelMotion
            // 
            this.labelMotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMotion.AutoSize = true;
            this.labelMotion.Location = new System.Drawing.Point(139, 713);
            this.labelMotion.Name = "labelMotion";
            this.labelMotion.Size = new System.Drawing.Size(92, 17);
            this.labelMotion.TabIndex = 10;
            this.labelMotion.Text = "Motion value:";
            this.labelMotion.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(454, 708);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 27);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxIPCam
            // 
            this.checkBoxIPCam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxIPCam.AutoSize = true;
            this.checkBoxIPCam.Location = new System.Drawing.Point(84, 712);
            this.checkBoxIPCam.Name = "checkBoxIPCam";
            this.checkBoxIPCam.Size = new System.Drawing.Size(95, 21);
            this.checkBoxIPCam.TabIndex = 2;
            this.checkBoxIPCam.Text = "IP Camera";
            this.checkBoxIPCam.UseVisualStyleBackColor = true;
            this.checkBoxIPCam.CheckedChanged += new System.EventHandler(this.checkBoxIPCam_CheckedChanged);
            // 
            // buttonVideo
            // 
            this.buttonVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonVideo.Location = new System.Drawing.Point(3, 708);
            this.buttonVideo.Name = "buttonVideo";
            this.buttonVideo.Size = new System.Drawing.Size(75, 27);
            this.buttonVideo.TabIndex = 1;
            this.buttonVideo.Text = "VIDEO";
            this.buttonVideo.UseVisualStyleBackColor = true;
            this.buttonVideo.Click += new System.EventHandler(this.buttonVideo_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(535, 708);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 27);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // trackBarVideo
            // 
            this.trackBarVideo.AutoSize = false;
            this.trackBarVideo.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarVideo.Location = new System.Drawing.Point(2, 3);
            this.trackBarVideo.Name = "trackBarVideo";
            this.trackBarVideo.Size = new System.Drawing.Size(759, 20);
            this.trackBarVideo.TabIndex = 6;
            this.trackBarVideo.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarVideo_MouseDown);
            this.trackBarVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarVideo_MouseUp);
            // 
            // panelVideoProgress
            // 
            this.panelVideoProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelVideoProgress.AutoSize = true;
            this.panelVideoProgress.Controls.Add(this.labelTime);
            this.panelVideoProgress.Controls.Add(this.trackBarVideo);
            this.panelVideoProgress.Location = new System.Drawing.Point(111, 674);
            this.panelVideoProgress.Name = "panelVideoProgress";
            this.panelVideoProgress.Size = new System.Drawing.Size(840, 26);
            this.panelVideoProgress.TabIndex = 8;
            this.panelVideoProgress.Visible = false;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(760, 4);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(76, 17);
            this.labelTime.TabIndex = 7;
            this.labelTime.Text = "0:00 / 0:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTime.SizeChanged += new System.EventHandler(this.labelTime_SizeChanged);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFullScreen.Enabled = false;
            this.buttonFullScreen.Location = new System.Drawing.Point(961, 708);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(100, 27);
            this.buttonFullScreen.TabIndex = 5;
            this.buttonFullScreen.Text = "Full Screen";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panelActivation);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panelVideoProgress);
            this.panel1.Controls.Add(this.buttonVideo);
            this.panel1.Controls.Add(this.checkBoxIPCam);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonFullScreen);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.imageBox4);
            this.panel1.Controls.Add(this.imageBox1);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.MinimumSize = new System.Drawing.Size(1000, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 738);
            this.panel1.TabIndex = 11;
            // 
            // panelActivation
            // 
            this.panelActivation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActivation.BackColor = System.Drawing.Color.Red;
            this.panelActivation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActivation.Location = new System.Drawing.Point(1035, 13);
            this.panelActivation.Name = "panelActivation";
            this.panelActivation.Size = new System.Drawing.Size(16, 16);
            this.panelActivation.TabIndex = 10;
            this.panelActivation.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.checkBoxNotice2);
            this.panel3.Controls.Add(this.buttonSetRoiMotion2);
            this.panel3.Controls.Add(this.buttonBackground2);
            this.panel3.Location = new System.Drawing.Point(761, 706);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 28);
            this.panel3.TabIndex = 9;
            this.panel3.Visible = false;
            // 
            // checkBoxNotice2
            // 
            this.checkBoxNotice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxNotice2.Location = new System.Drawing.Point(129, 7);
            this.checkBoxNotice2.Name = "checkBoxNotice2";
            this.checkBoxNotice2.Size = new System.Drawing.Size(64, 18);
            this.checkBoxNotice2.TabIndex = 2;
            this.checkBoxNotice2.Text = "Notice";
            this.checkBoxNotice2.UseVisualStyleBackColor = true;
            this.checkBoxNotice2.CheckedChanged += new System.EventHandler(this.checkBoxNotice2_CheckedChanged);
            // 
            // buttonSetRoiMotion2
            // 
            this.buttonSetRoiMotion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSetRoiMotion2.Location = new System.Drawing.Point(66, 2);
            this.buttonSetRoiMotion2.Name = "buttonSetRoiMotion2";
            this.buttonSetRoiMotion2.Size = new System.Drawing.Size(60, 24);
            this.buttonSetRoiMotion2.TabIndex = 1;
            this.buttonSetRoiMotion2.Text = "ROI/Mot";
            this.buttonSetRoiMotion2.UseVisualStyleBackColor = true;
            this.buttonSetRoiMotion2.Click += new System.EventHandler(this.buttonSetRoiMotion_Click);
            // 
            // buttonBackground2
            // 
            this.buttonBackground2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBackground2.Location = new System.Drawing.Point(3, 2);
            this.buttonBackground2.Name = "buttonBackground2";
            this.buttonBackground2.Size = new System.Drawing.Size(60, 24);
            this.buttonBackground2.TabIndex = 0;
            this.buttonBackground2.Text = "BGround";
            this.buttonBackground2.UseVisualStyleBackColor = true;
            this.buttonBackground2.Visible = false;
            this.buttonBackground2.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // imageBox4
            // 
            this.imageBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox4.BackColor = System.Drawing.Color.Transparent;
            this.imageBox4.BackgroundImage = global::VehicleDetectionApplication.Properties.Resources.play;
            this.imageBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBox4.ErrorImage = global::VehicleDetectionApplication.Properties.Resources.pause;
            this.imageBox4.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox4.InitialImage = global::VehicleDetectionApplication.Properties.Resources.play;
            this.imageBox4.Location = new System.Drawing.Point(481, 301);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(100, 100);
            this.imageBox4.TabIndex = 2;
            this.imageBox4.TabStop = false;
            this.imageBox4.Visible = false;
            this.imageBox4.Click += new System.EventHandler(this.imageBox4_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.imageBox1.BackgroundImage = global::VehicleDetectionApplication.Properties.Resources.videocam;
            this.imageBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBox1.ErrorImage = global::VehicleDetectionApplication.Properties.Resources.novideo;
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.InitialImage = global::VehicleDetectionApplication.Properties.Resources.videocam;
            this.imageBox1.Location = new System.Drawing.Point(3, 2);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(1058, 700);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.DoubleClick += new System.EventHandler(this.imageBox1_DoubleClick);
            this.imageBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            this.imageBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.imageBox1_PreviewKeyDown);
            // 
            // checkBoxNotice
            // 
            this.checkBoxNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNotice.AutoSize = true;
            this.checkBoxNotice.Location = new System.Drawing.Point(566, 712);
            this.checkBoxNotice.Name = "checkBoxNotice";
            this.checkBoxNotice.Size = new System.Drawing.Size(70, 21);
            this.checkBoxNotice.TabIndex = 9;
            this.checkBoxNotice.Text = "Notice";
            this.checkBoxNotice.UseVisualStyleBackColor = true;
            this.checkBoxNotice.CheckedChanged += new System.EventHandler(this.checkBoxNotice_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.checkBoxNotice);
            this.panel2.Controls.Add(this.buttonSetRoiMotion);
            this.panel2.Controls.Add(this.imageBox3);
            this.panel2.Controls.Add(this.imageBox2);
            this.panel2.Controls.Add(this.buttonBackground);
            this.panel2.Controls.Add(this.labelMotion);
            this.panel2.Location = new System.Drawing.Point(1086, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 738);
            this.panel2.TabIndex = 12;
            // 
            // buttonSetRoiMotion
            // 
            this.buttonSetRoiMotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetRoiMotion.Location = new System.Drawing.Point(642, 708);
            this.buttonSetRoiMotion.Name = "buttonSetRoiMotion";
            this.buttonSetRoiMotion.Size = new System.Drawing.Size(162, 27);
            this.buttonSetRoiMotion.TabIndex = 11;
            this.buttonSetRoiMotion.Text = "Set ROI / Motion Area";
            this.buttonSetRoiMotion.UseVisualStyleBackColor = true;
            this.buttonSetRoiMotion.Click += new System.EventHandler(this.buttonSetRoiMotion_Click);
            // 
            // imageBox3
            // 
            this.imageBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.imageBox3.BackgroundImage = global::VehicleDetectionApplication.Properties.Resources.noimage2;
            this.imageBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBox3.ErrorImage = global::VehicleDetectionApplication.Properties.Resources.noimage2;
            this.imageBox3.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox3.InitialImage = global::VehicleDetectionApplication.Properties.Resources.noimage2;
            this.imageBox3.Location = new System.Drawing.Point(3, 522);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(800, 180);
            this.imageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox3.TabIndex = 7;
            this.imageBox3.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.imageBox2.BackgroundImage = global::VehicleDetectionApplication.Properties.Resources.image;
            this.imageBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBox2.ErrorImage = global::VehicleDetectionApplication.Properties.Resources.noimage1;
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.InitialImage = global::VehicleDetectionApplication.Properties.Resources.image;
            this.imageBox2.Location = new System.Drawing.Point(3, 2);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(800, 500);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 4;
            this.imageBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(12, 4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1878, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.buttonVideo_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.closeToolStripMenuItem.Text = "Close...";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.informationToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Enabled = false;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.fullScreenToolStripMenuItem.Text = "FullScreen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 6);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Enabled = false;
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.informationToolStripMenuItem.Text = "Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.gotoStartToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Enabled = false;
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.playPauseToolStripMenuItem.Text = "Play/Pause";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // gotoStartToolStripMenuItem
            // 
            this.gotoStartToolStripMenuItem.Enabled = false;
            this.gotoStartToolStripMenuItem.Name = "gotoStartToolStripMenuItem";
            this.gotoStartToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.gotoStartToolStripMenuItem.Text = "Goto Start";
            this.gotoStartToolStripMenuItem.Click += new System.EventHandler(this.gotoStartToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPCameraToolStripMenuItem,
            this.notificationToolStripMenuItem,
            this.backgroundToolStripMenuItem,
            this.roiMotionToolStripMenuItem,
            this.toolStripMenuItem3,
            this.settingsToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // iPCameraToolStripMenuItem
            // 
            this.iPCameraToolStripMenuItem.Name = "iPCameraToolStripMenuItem";
            this.iPCameraToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.iPCameraToolStripMenuItem.Text = "IPCamera";
            this.iPCameraToolStripMenuItem.Click += new System.EventHandler(this.iPCameraToolStripMenuItem_Click);
            // 
            // notificationToolStripMenuItem
            // 
            this.notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
            this.notificationToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.notificationToolStripMenuItem.Text = "Notification";
            this.notificationToolStripMenuItem.Click += new System.EventHandler(this.notificationToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Enabled = false;
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // roiMotionToolStripMenuItem
            // 
            this.roiMotionToolStripMenuItem.Name = "roiMotionToolStripMenuItem";
            this.roiMotionToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.roiMotionToolStripMenuItem.Text = "ROI/Motion";
            this.roiMotionToolStripMenuItem.Click += new System.EventHandler(this.buttonSetRoiMotion_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1902, 769);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1040, 640);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12, 4, 12, 12);
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vechicle Detection Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideo)).EndInit();
            this.panelVideoProgress.ResumeLayout(false);
            this.panelVideoProgress.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button buttonBackground;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.Label labelMotion;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.CheckBox checkBoxIPCam;
        private System.Windows.Forms.Button buttonVideo;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TrackBar trackBarVideo;
        private System.Windows.Forms.Panel panelVideoProgress;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonFullScreen;
        private Emgu.CV.UI.ImageBox imageBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSetRoiMotion;
        private System.Windows.Forms.CheckBox checkBoxNotice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxNotice2;
        private System.Windows.Forms.Button buttonSetRoiMotion2;
        private System.Windows.Forms.Button buttonBackground2;
        private System.Windows.Forms.Panel panelActivation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roiMotionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
    }
}

