using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    //SQL Server local DB

namespace EnglishWordLearner
{
    public partial class mainForm : Form
    {
        public static bool typeEngHun = true;
        public static bool levelEasy = true;

        private ListViewColumnSorter lvwColumnSorter;

        #region Forms
        //-------------------------------- < region:Forms > ---------------------------
        public mainForm()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listWords2.ListViewItemSorter = lvwColumnSorter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_List();
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            listWords2.Visible = true;
        }
        //-------------------------------- </ region:Forms > ---------------------------
        #endregion /Form

        #region Buttons
        //-------------------------------- < region:Buttons > ---------------------------
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            add_Words_to_Database();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            delete_Words_from_Database();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            update_Words_in_Database();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            listWords2.Visible = false;
            new testForm().ShowDialog();            
        }

        private void radioButtonEng_CheckedChanged(object sender, EventArgs e)
        {
            typeEngHun = true;
        }

        private void radioButtonHun_CheckedChanged(object sender, EventArgs e)
        {
            typeEngHun = false;
        }

        private void radioButtonEasy_CheckedChanged(object sender, EventArgs e)
        {
            levelEasy = true;
        }

        private void radioButtonDifficult_CheckedChanged(object sender, EventArgs e)
        {
            levelEasy = false;
        }
        //-------------------------------- </ region:Buttons > ---------------------------
        #endregion /Buttons

        #region Methods
        //-------------------------------- < region:Methods > ---------------------------
        private void load_List()
        {
            //--------------- < load_List() > -----------------
            string cn_string = Properties.Settings.Default.dbEnglishWordsConnectionString;

            //-< Database >
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string sql_Text = "SELECT * FROM table_Words";

            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);
            //-</ Database >

            //< show >              
            listWords2.Items.Clear();

            foreach (DataRow row in tbl.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < tbl.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());

                }
                listWords2.Items.Add(item);
            }       
            //</ show >          

            //--------------- </ load_List() > -----------------
        }

        private void add_Words_to_Database()
        {
            //--------------- < add_Words_to_Database() > -----------------
            string cn_string = Properties.Settings.Default.dbEnglishWordsConnectionString;

            //-< Database >
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string englishWord = textBoxEnglish.Text;
            string hungarianWord = textBoxHungarian.Text;

            string sql_Text = "INSERT INTO table_Words (English, Hungarian) VALUES ('"
                + englishWord + "' , '" + hungarianWord + "')";

            SqlCommand cmd_Command = new SqlCommand(sql_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();
            //-</ Database >

            //-< reload >
            load_List();
            //-</ reload >
            //--------------- </ add_Words_to_Database() > -----------------
        }

        private void delete_Words_from_Database()
        {
            //--------------- < delete_Words_from_Database() > -----------------
            string cn_string = Properties.Settings.Default.dbEnglishWordsConnectionString;

            //-< Database >
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string IDWord = listWords2.SelectedItems[0].Text;
            string sql_Text = "DELETE FROM table_Words WHERE (IdWords = " + IDWord + ")";

            SqlCommand cmd_Command = new SqlCommand(sql_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();
            //-</ Database >

            //-< reload >
            load_List();
            //-</ reload >
            //--------------- </ delete_Words_from_Database() > -----------------
        }

        private void update_Words_in_Database()
        {
            //--------------- < update_Words_in_Database() > -----------------
            string cn_string = Properties.Settings.Default.dbEnglishWordsConnectionString;

            //-< Database >
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            string IDWord = listWords2.SelectedItems[0].Text;
            string sql_Text = "UPDATE table_Words SET English = '" + textBoxEnglish.Text
                + "' , Hungarian = '" + textBoxHungarian.Text + "' WHERE IdWords = " + IDWord;

            SqlCommand cmd_Command = new SqlCommand(sql_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();
            //-</ Database >

            //-< reload >
            load_List();
            //-</ reload >
            //--------------- </ update_Words_in_Database() > -----------------
        }

        private void listWords2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //--------------- < Sorting_Words > -----------------
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            this.listWords2.Sort();
            //--------------- < /Sorting_Words > -----------------
        }
        //-------------------------------- </ region:Methods > ---------------------------
        #endregion /Methods

    }
}
