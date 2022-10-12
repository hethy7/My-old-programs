namespace VehicleDetectionApplication
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Video resolution";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Original resolution",
            "1920 x 1080 (16:9)",
            "1280 x 960 (4:3)",
            "1280 x 720 (16:9)"});
            this.comboBox1.Location = new System.Drawing.Point(160, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(550, 2);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Image format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(25, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Record file settings";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(160, 160);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 21);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "JPEG";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(260, 160);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 21);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "BMP";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Save record files to";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(160, 197);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(300, 22);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(12, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(550, 2);
            this.label7.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(25, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "Motion settings";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboBox2.Location = new System.Drawing.Point(160, 297);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Motion sensitivity";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(12, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(550, 2);
            this.label10.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(25, 365);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 18);
            this.label11.TabIndex = 16;
            this.label11.Text = "Vehicle detector settings";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 400);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Scale factor";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(210, 398);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 22);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "1.1";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(270, 398);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(50, 22);
            this.numericUpDown2.TabIndex = 21;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 440);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "Neighbors";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(163, 438);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(50, 22);
            this.numericUpDown3.TabIndex = 23;
            this.numericUpDown3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numericUpDown6);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.numericUpDown7);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.numericUpDown5);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.numericUpDown4);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(28, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 170);
            this.panel1.TabIndex = 24;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(255, 120);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown6.TabIndex = 31;
            this.numericUpDown6.Value = new decimal(new int[] {
            440,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(200, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 17);
            this.label18.TabIndex = 30;
            this.label18.Text = "Height";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(110, 120);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown7.TabIndex = 29;
            this.numericUpDown7.Value = new decimal(new int[] {
            340,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 122);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 17);
            this.label19.TabIndex = 28;
            this.label19.Text = "Width";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(12, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(156, 17);
            this.label20.TabIndex = 27;
            this.label20.Text = "Maximum object size";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(255, 40);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown5.TabIndex = 26;
            this.numericUpDown5.Value = new decimal(new int[] {
            176,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(200, 42);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 17);
            this.label17.TabIndex = 25;
            this.label17.Text = "Height";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(110, 40);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown4.TabIndex = 24;
            this.numericUpDown4.Value = new decimal(new int[] {
            136,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(60, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 17);
            this.label16.TabIndex = 19;
            this.label16.Text = "Width";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(12, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(153, 17);
            this.label15.TabIndex = 18;
            this.label15.Text = "Minimum object size";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 27);
            this.button3.TabIndex = 27;
            this.button3.Text = "Default settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 664);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 26;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(216, 664);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 27);
            this.button4.TabIndex = 25;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(582, 703);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 750);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "SettingForm";
            this.Text = "Program Settings";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}