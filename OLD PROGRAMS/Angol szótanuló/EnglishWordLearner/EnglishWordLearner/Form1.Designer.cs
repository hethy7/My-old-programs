namespace EnglishWordLearner
{
    partial class mainForm
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxEnglish = new System.Windows.Forms.TextBox();
            this.labelWords = new System.Windows.Forms.Label();
            this.textBoxHungarian = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listWords2 = new System.Windows.Forms.ListView();
            this.idWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.English = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hungarian = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Difficulty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonTest = new System.Windows.Forms.Button();
            this.radioButtonEng = new System.Windows.Forms.RadioButton();
            this.radioButtonHun = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonDifficult = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdd.Location = new System.Drawing.Point(528, 164);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(210, 56);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDelete.Location = new System.Drawing.Point(528, 228);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(210, 56);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdate.Location = new System.Drawing.Point(528, 292);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(210, 56);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxEnglish
            // 
            this.textBoxEnglish.Location = new System.Drawing.Point(527, 65);
            this.textBoxEnglish.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEnglish.Name = "textBoxEnglish";
            this.textBoxEnglish.Size = new System.Drawing.Size(210, 26);
            this.textBoxEnglish.TabIndex = 4;
            // 
            // labelWords
            // 
            this.labelWords.AutoSize = true;
            this.labelWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWords.Location = new System.Drawing.Point(185, 12);
            this.labelWords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWords.Name = "labelWords";
            this.labelWords.Size = new System.Drawing.Size(221, 25);
            this.labelWords.TabIndex = 5;
            this.labelWords.Text = "English Word Learner";
            // 
            // textBoxHungarian
            // 
            this.textBoxHungarian.Location = new System.Drawing.Point(527, 122);
            this.textBoxHungarian.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHungarian.Name = "textBoxHungarian";
            this.textBoxHungarian.Size = new System.Drawing.Size(210, 26);
            this.textBoxHungarian.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "English";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hungarian";
            // 
            // listWords2
            // 
            this.listWords2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idWord,
            this.English,
            this.Hungarian,
            this.Difficulty});
            this.listWords2.FullRowSelect = true;
            this.listWords2.HideSelection = false;
            this.listWords2.Location = new System.Drawing.Point(16, 41);
            this.listWords2.MultiSelect = false;
            this.listWords2.Name = "listWords2";
            this.listWords2.Size = new System.Drawing.Size(504, 580);
            this.listWords2.TabIndex = 11;
            this.listWords2.UseCompatibleStateImageBehavior = false;
            this.listWords2.View = System.Windows.Forms.View.Details;
            this.listWords2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listWords2_ColumnClick);
            // 
            // idWord
            // 
            this.idWord.DisplayIndex = 2;
            this.idWord.Text = "";
            this.idWord.Width = 0;
            // 
            // English
            // 
            this.English.DisplayIndex = 0;
            this.English.Text = "English";
            this.English.Width = 250;
            // 
            // Hungarian
            // 
            this.Hungarian.DisplayIndex = 1;
            this.Hungarian.Text = "Hungarian";
            this.Hungarian.Width = 250;
            // 
            // Difficulty
            // 
            this.Difficulty.Text = "";
            this.Difficulty.Width = 0;
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTest.Location = new System.Drawing.Point(528, 454);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(210, 68);
            this.buttonTest.TabIndex = 12;
            this.buttonTest.Text = "TEST";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // radioButtonEng
            // 
            this.radioButtonEng.AutoSize = true;
            this.radioButtonEng.Checked = true;
            this.radioButtonEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonEng.Location = new System.Drawing.Point(52, 17);
            this.radioButtonEng.Name = "radioButtonEng";
            this.radioButtonEng.Size = new System.Drawing.Size(86, 22);
            this.radioButtonEng.TabIndex = 13;
            this.radioButtonEng.TabStop = true;
            this.radioButtonEng.Text = "Eng/Hun";
            this.radioButtonEng.UseVisualStyleBackColor = true;
            this.radioButtonEng.CheckedChanged += new System.EventHandler(this.radioButtonEng_CheckedChanged);
            // 
            // radioButtonHun
            // 
            this.radioButtonHun.AutoSize = true;
            this.radioButtonHun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonHun.Location = new System.Drawing.Point(129, 17);
            this.radioButtonHun.Name = "radioButtonHun";
            this.radioButtonHun.Size = new System.Drawing.Size(86, 22);
            this.radioButtonHun.TabIndex = 14;
            this.radioButtonHun.Text = "Hun/Eng";
            this.radioButtonHun.UseVisualStyleBackColor = true;
            this.radioButtonHun.CheckedChanged += new System.EventHandler(this.radioButtonHun_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(528, 521);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.radioButtonHun);
            this.splitContainer1.Panel1.Controls.Add(this.radioButtonEng);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonDifficult);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonEasy);
            this.splitContainer1.Size = new System.Drawing.Size(209, 100);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // radioButtonDifficult
            // 
            this.radioButtonDifficult.AutoSize = true;
            this.radioButtonDifficult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonDifficult.Location = new System.Drawing.Point(129, 0);
            this.radioButtonDifficult.Name = "radioButtonDifficult";
            this.radioButtonDifficult.Size = new System.Drawing.Size(77, 22);
            this.radioButtonDifficult.TabIndex = 16;
            this.radioButtonDifficult.Text = "Difficult";
            this.radioButtonDifficult.UseVisualStyleBackColor = true;
            this.radioButtonDifficult.CheckedChanged += new System.EventHandler(this.radioButtonDifficult_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Level:";
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Checked = true;
            this.radioButtonEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonEasy.Location = new System.Drawing.Point(61, 0);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(62, 22);
            this.radioButtonEasy.TabIndex = 15;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "Easy";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            this.radioButtonEasy.CheckedChanged += new System.EventHandler(this.radioButtonEasy_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 633);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.listWords2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxHungarian);
            this.Controls.Add(this.labelWords);
            this.Controls.Add(this.textBoxEnglish);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.Text = "Main Page";
            this.Activated += new System.EventHandler(this.mainForm_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxEnglish;
        private System.Windows.Forms.Label labelWords;
        private System.Windows.Forms.TextBox textBoxHungarian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listWords2;
        private System.Windows.Forms.ColumnHeader English;
        private System.Windows.Forms.ColumnHeader Hungarian;
        private System.Windows.Forms.ColumnHeader idWord;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.RadioButton radioButtonEng;
        private System.Windows.Forms.RadioButton radioButtonHun;
        private System.Windows.Forms.ColumnHeader Difficulty;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonDifficult;
        private System.Windows.Forms.RadioButton radioButtonEasy;
    }
}

