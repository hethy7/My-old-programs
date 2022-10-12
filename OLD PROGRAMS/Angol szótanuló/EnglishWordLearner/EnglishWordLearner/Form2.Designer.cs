namespace EnglishWordLearner
{
    partial class testForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonHun = new System.Windows.Forms.RadioButton();
            this.radioButtonEng = new System.Windows.Forms.RadioButton();
            this.radioButtonDifficult = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.labelSettings = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.buttonAnswer = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelCorrect = new System.Windows.Forms.Label();
            this.labelWrong = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelType = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelReset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "English Word Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(472, 84);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.radioButtonHun);
            this.splitContainer1.Panel1.Controls.Add(this.radioButtonEng);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonDifficult);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonEasy);
            this.splitContainer1.Size = new System.Drawing.Size(219, 111);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 16;
            this.splitContainer1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(10, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Type:";
            // 
            // radioButtonHun
            // 
            this.radioButtonHun.AutoSize = true;
            this.radioButtonHun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonHun.Location = new System.Drawing.Point(111, 30);
            this.radioButtonHun.Name = "radioButtonHun";
            this.radioButtonHun.Size = new System.Drawing.Size(86, 22);
            this.radioButtonHun.TabIndex = 14;
            this.radioButtonHun.Text = "Hun/Eng";
            this.radioButtonHun.UseVisualStyleBackColor = true;
            this.radioButtonHun.CheckedChanged += new System.EventHandler(this.radioButtonHun_CheckedChanged);
            // 
            // radioButtonEng
            // 
            this.radioButtonEng.AutoSize = true;
            this.radioButtonEng.Checked = true;
            this.radioButtonEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonEng.Location = new System.Drawing.Point(16, 28);
            this.radioButtonEng.Name = "radioButtonEng";
            this.radioButtonEng.Size = new System.Drawing.Size(86, 22);
            this.radioButtonEng.TabIndex = 13;
            this.radioButtonEng.TabStop = true;
            this.radioButtonEng.Text = "Eng/Hun";
            this.radioButtonEng.UseVisualStyleBackColor = true;
            this.radioButtonEng.CheckedChanged += new System.EventHandler(this.radioButtonEng_CheckedChanged);
            // 
            // radioButtonDifficult
            // 
            this.radioButtonDifficult.AutoSize = true;
            this.radioButtonDifficult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonDifficult.Location = new System.Drawing.Point(93, 25);
            this.radioButtonDifficult.Name = "radioButtonDifficult";
            this.radioButtonDifficult.Size = new System.Drawing.Size(77, 22);
            this.radioButtonDifficult.TabIndex = 16;
            this.radioButtonDifficult.Text = "Difficult";
            this.radioButtonDifficult.UseVisualStyleBackColor = true;
            this.radioButtonDifficult.CheckedChanged += new System.EventHandler(this.radioButtonDifficult_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(14, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Level:";
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Checked = true;
            this.radioButtonEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonEasy.Location = new System.Drawing.Point(19, 25);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(62, 22);
            this.radioButtonEasy.TabIndex = 15;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "Easy";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            this.radioButtonEasy.CheckedChanged += new System.EventHandler(this.radioButtonEasy_CheckedChanged);
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSettings.Location = new System.Drawing.Point(483, 62);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(165, 20);
            this.labelSettings.TabIndex = 17;
            this.labelSettings.Text = "+ English test settings";
            this.labelSettings.Click += new System.EventHandler(this.labelSettings_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(487, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Correct answer:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(494, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Wrong answer:";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelQuestion.Location = new System.Drawing.Point(13, 135);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(417, 31);
            this.labelQuestion.TabIndex = 20;
            this.labelQuestion.Text = "How is this word in Hungarian?";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxQuestion.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxQuestion.Enabled = false;
            this.textBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxQuestion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxQuestion.Location = new System.Drawing.Point(19, 182);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.Size = new System.Drawing.Size(399, 28);
            this.textBoxQuestion.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(14, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 29);
            this.label10.TabIndex = 22;
            this.label10.Text = "Answer:";
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAnswer.Location = new System.Drawing.Point(19, 276);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(399, 28);
            this.textBoxAnswer.TabIndex = 21;
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAnswer.Location = new System.Drawing.Point(119, 237);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(0, 20);
            this.labelAnswer.TabIndex = 24;
            // 
            // buttonAnswer
            // 
            this.buttonAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAnswer.Location = new System.Drawing.Point(19, 320);
            this.buttonAnswer.Name = "buttonAnswer";
            this.buttonAnswer.Size = new System.Drawing.Size(88, 32);
            this.buttonAnswer.TabIndex = 25;
            this.buttonAnswer.Text = "Answer";
            this.buttonAnswer.UseVisualStyleBackColor = true;
            this.buttonAnswer.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Enabled = false;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNext.Location = new System.Drawing.Point(236, 320);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(88, 32);
            this.buttonNext.TabIndex = 26;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelCorrect
            // 
            this.labelCorrect.AutoSize = true;
            this.labelCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCorrect.Location = new System.Drawing.Point(623, 272);
            this.labelCorrect.Name = "labelCorrect";
            this.labelCorrect.Size = new System.Drawing.Size(18, 20);
            this.labelCorrect.TabIndex = 27;
            this.labelCorrect.Text = "0";
            // 
            // labelWrong
            // 
            this.labelWrong.AutoSize = true;
            this.labelWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWrong.Location = new System.Drawing.Point(623, 299);
            this.labelWrong.Name = "labelWrong";
            this.labelWrong.Size = new System.Drawing.Size(18, 20);
            this.labelWrong.TabIndex = 28;
            this.labelWrong.Text = "0";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.Location = new System.Drawing.Point(330, 320);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(88, 32);
            this.buttonExit.TabIndex = 29;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelType.Location = new System.Drawing.Point(65, 62);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(74, 20);
            this.labelType.TabIndex = 30;
            this.labelType.Text = "Eng/Hun";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLevel.Location = new System.Drawing.Point(66, 91);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(46, 20);
            this.labelLevel.TabIndex = 31;
            this.labelLevel.Text = "Easy";
            // 
            // labelReset
            // 
            this.labelReset.AutoSize = true;
            this.labelReset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelReset.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelReset.Location = new System.Drawing.Point(531, 201);
            this.labelReset.Name = "labelReset";
            this.labelReset.Size = new System.Drawing.Size(77, 20);
            this.labelReset.TabIndex = 32;
            this.labelReset.Text = "Reset test";
            this.labelReset.Visible = false;
            this.labelReset.Click += new System.EventHandler(this.labelReset_Click);
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 368);
            this.Controls.Add(this.labelReset);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelWrong);
            this.Controls.Add(this.labelCorrect);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonAnswer);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "testForm";
            this.Text = "Testing Page";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonHun;
        private System.Windows.Forms.RadioButton radioButtonEng;
        private System.Windows.Forms.RadioButton radioButtonDifficult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelCorrect;
        private System.Windows.Forms.Label labelWrong;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelReset;
    }
}