using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWordLearner
{
    public partial class testForm : Form
    {
        private bool typeEngHun2 = mainForm.typeEngHun;
        private bool levelEasy2 = mainForm.levelEasy;

        private DataTable tbl = new DataTable();
        private List<DataRow> generatedAndSimilarWords = new List<DataRow>();
        private List<int> numGenSimWords = new List<int>();
        private int numWrong, numCorrect = 0;
        private bool resetOn = false, langChange = false;

        #region Forms
        //-------------------------------- < region:Forms > ---------------------------
        public testForm()
        {
            InitializeComponent();

            if (typeEngHun2)
            {
                labelType.Text = "Eng/Hun";
                labelQuestion.Text = "How is this word in Hungarian?";
                radioButtonEng.Checked = true;
            }
            else
            {
                labelType.Text = "Hun/Eng";
                labelQuestion.Text = "How is this word in English?";
                radioButtonHun.Checked = true;
            }

            if (levelEasy2)
            {
                labelLevel.Text = "Easy";
                radioButtonEasy.Checked = true;
            }
            else
            {
                labelLevel.Text = "Difficult";
                radioButtonDifficult.Checked = true;
            }

            load_Database();
            generate_Random_Word();
        }

        private void labelSettings_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Visible)
            {
                splitContainer1.Visible = false;
                labelReset.Visible = false;
            }
            else
            {
                splitContainer1.Visible = true;
                labelReset.Visible = true;
            }
        }

        private void labelReset_Click(object sender, EventArgs e)
        {
            if (labelReset.BorderStyle == BorderStyle.FixedSingle)
            {
                labelReset.BorderStyle = BorderStyle.Fixed3D;
                labelReset.Cursor = Cursors.Default;

                if (buttonAnswer.Enabled) resetOn = true;
                else
                {
                    tbl.Clear();
                    load_Database();
                }
            }
        }

        private void radioButtonEng_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonAnswer.Enabled) langChange = true;
            else typeEngHun2 = true;
        }

        private void radioButtonHun_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonAnswer.Enabled) langChange = true;
            else typeEngHun2 = false;
        }

        private void radioButtonEasy_CheckedChanged(object sender, EventArgs e)
        {
            levelEasy2 = true;
        }

        private void radioButtonDifficult_CheckedChanged(object sender, EventArgs e)
        {
            levelEasy2 = false;
        }
        //-------------------------------- </ region:Forms > ---------------------------
        #endregion /Form

        #region Buttons
        //-------------------------------- < region:Buttons > ---------------------------
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            checking_Word();
            buttonNext.Enabled = true;
            buttonAnswer.Enabled = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            generate_Random_Word();
            buttonNext.Enabled = false;
            buttonAnswer.Enabled = true;
            textBoxAnswer.Text = "";
            labelAnswer.Text = "";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //-------------------------------- </ region:Buttons > ---------------------------
        #endregion /Buttons

        #region Methods
        //-------------------------------- < region:Methods > ---------------------------
        private void load_Database()
        {
            string cn_string = Properties.Settings.Default.dbEnglishWordsConnectionString;

            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT * FROM table_Words";

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);
        }

        private void generate_Random_Word()
        {
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Congratulation, that was all the words!");
                this.Dispose();
                return;
            }

            Random random = new Random();
            DataRow randomWord1 = tbl.Rows[random.Next(0, tbl.Rows.Count)];
            DataRow randomWord2 = tbl.Rows[random.Next(0, tbl.Rows.Count)];

            if (tbl.Rows.Count > 1)
                while (randomWord1["IdWords"].Equals(randomWord2["IdWords"]))
                    randomWord2 = tbl.Rows[random.Next(0, tbl.Rows.Count)];

            int dif1 = Convert.ToInt16(randomWord1["Difficulty"]);
            int dif2 = Convert.ToInt16(randomWord2["Difficulty"]);

            if (levelEasy2)
            {
                if (dif1 > dif2) randomWord1 = randomWord2;
                labelLevel.Text = "Easy";
            }
            else labelLevel.Text = "Difficult";

            string type;

            if (typeEngHun2)
            {
                type = "English";
                labelType.Text = "Eng/Hun";
                labelQuestion.Text = "How is this word in Hungarian?";
            }
            else
            {
                type = "Hungarian";
                labelType.Text = "Hun/Eng";
                labelQuestion.Text = "How is this word in English?";
            }

            textBoxQuestion.Text = randomWord1[type].ToString();

            int i = 0;

            foreach (DataRow row in tbl.Rows)
            {
                if (randomWord1[type].Equals(row[type]))
                {
                    generatedAndSimilarWords.Add(row);
                    numGenSimWords.Add(i);
                }
                i++;
            }
        }

        private void checking_Word()
        {
            string cn_string = Properties.Settings.Default.dbEnglishWordsConnectionString;
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            bool correct = false;
            string IDWord, sql_Text;
            string type;

            if (typeEngHun2) type = "Hungarian";
            else type = "English";

            foreach (var word in generatedAndSimilarWords)
            {
                string answerWord = textBoxAnswer.Text.ToUpper();
                string vocabWord = word[type].ToString().Trim(' ').ToUpper();
                if (answerWord.Equals(vocabWord)) correct = true;
            }

            if (correct)
            {
                numCorrect++;
                labelCorrect.Text = numCorrect.ToString();
                labelAnswer.Text = "Your answer is correct!";
                foreach (var word in generatedAndSimilarWords)
                {
                    if (Convert.ToInt16(word["Difficulty"]) > 1)
                    {
                        IDWord = word["IdWords"].ToString();
                        sql_Text = "UPDATE table_Words SET Difficulty = Difficulty - 1 WHERE IdWords = " + IDWord;

                        SqlCommand cmd_Command = new SqlCommand(sql_Text, cn_connection);
                        cmd_Command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                numWrong++;
                labelWrong.Text = numWrong.ToString();

                string s = "", sWords = "";
                foreach (var word in generatedAndSimilarWords)
                {
                    sWords = sWords + word[type].ToString().Trim(' ') + ", ";
                }

                sWords = sWords.Substring(0, sWords.Length - 2);
                if (generatedAndSimilarWords.Count == 1) s = " is: " + sWords;
                else s = "s are: " + sWords;

                labelAnswer.Text = "Your answer is wrong! The correct word" + s;

                foreach (var word in generatedAndSimilarWords)
                {
                    if (Convert.ToInt16(word["Difficulty"]) < 10)
                    {
                        IDWord = word["IdWords"].ToString();
                        sql_Text = "UPDATE table_Words SET Difficulty = Difficulty + 1 WHERE IdWords = " + IDWord;

                        SqlCommand cmd_Command = new SqlCommand(sql_Text, cn_connection);
                        cmd_Command.ExecuteNonQuery();
                    }
                }
            }

            DataTable tbl2 = new DataTable();
            string sql_Text2 = "SELECT * FROM table_Words";

            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text2, cn_connection);
            adapter.Fill(tbl2);

            foreach (var num in numGenSimWords)
            {
                tbl.Rows[num].Delete();
            }

            tbl.AcceptChanges();

            generatedAndSimilarWords.Clear();
            numGenSimWords.Clear();

            if (labelReset.BorderStyle == BorderStyle.Fixed3D)
            {
                labelReset.BorderStyle = BorderStyle.FixedSingle;
                labelReset.Cursor = Cursors.Hand;
            }

            if (resetOn)
            {
                tbl.Clear();
                load_Database();
                resetOn = false;
            }

            if (langChange)
            {
                if (radioButtonEng.Checked) typeEngHun2 = true;
                else typeEngHun2 = false;
                langChange = false;
            }
        }
        //-------------------------------- </ region:Methods > ---------------------------
        #endregion /Methods
    }
}
