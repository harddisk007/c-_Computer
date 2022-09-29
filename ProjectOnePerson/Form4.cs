using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectOnePerson
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        
        private void showsale_user()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id,username,brand,types,model,code,price,amount,date_time FROM history WHERE username = '" + Program.username + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
        }
        private void showday(string sql)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
        }
        private void backmenuToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            search_txt.Text = Program.username; // textbox ลูกค้าที่ login
            showsale_user();
            showday("SELECT id,username,brand,types,model,code,price,amount,date_time FROM history WHERE username = '" + Program.username + "'");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string ch;
        private void dmy()
        {
            if (comboBox1.Text != "")
            {
                ch = "%" + comboBox1.Text + "%";
            }
            if (comboBox2.Text != "")
            {
                ch = "%" + comboBox2.Text + "   " + comboBox1.Text + "%";
            }
            if (comboBox3.Text != "")
            {
                ch = "%" + comboBox3.Text + "   " + comboBox2.Text + "   " + comboBox1.Text + "%";
            }
            showday("SELECT * FROM history WHERE date_time LIKE '" + ch + "' AND username LIKE '" + Program.username + "'");

        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            int day_ = 0;
            if (comboBox2.Text == "01" || comboBox2.Text == "03" || comboBox2.Text == "05" || comboBox2.Text == "07" || comboBox2.Text == "08" || comboBox2.Text == "10" || comboBox2.Text == "12")
            {
                day_ = 31;
            }
            else if (comboBox2.Text == "04" || comboBox2.Text == "06" || comboBox2.Text == "09" || comboBox2.Text == "11")
            {
                day_ = 30;
            }
            else if (comboBox2.Text == "02")
            {
                day_ = 28;
            }
            comboBox3.Items.Add("");

            for (int i = 1; i <= day_; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }
            dmy();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dmy();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dmy();
        }
    }
}
