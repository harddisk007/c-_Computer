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
    public partial class Form6 : Form
    {
        public static string userlogin,address,tel;
        private MySqlConnection databaseConnection()
        {           
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void loginBtn_Click(object sender, EventArgs e)
        {        
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM user WHERE username = '" + textuser.Text + "' AND password = '" + textpass.Text + "'";

            MySqlDataReader row = cmd.ExecuteReader();

            if (row.Read())
            {
                Program.username = textuser.Text;
                MessageBox.Show("เข้าสู่ระบบสำเร็จ", "Customer Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userlogin = textuser.Text;
                address=row.GetString(5);
                tel = row.GetString(4);
                textuser.Clear();
                textpass.Clear();        
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือรหัสผ่านไม่ถูกต้อง", "Customer Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textuser.Clear();
                textpass.Clear();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            textuser.Clear();
            textpass.Clear();
            this.Close();
            this.Hide();
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string x = checkBox1.Text;
                textpass.PasswordChar = '\0';
            }
            else
            {
                textpass.PasswordChar = '•';
            }
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (textuser.Text == "") MessageBox.Show("กรุณาใส่รหัสผ่านของท่าน", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else this.loginBtn_Click(sender, e);
            }
        }
        private void textuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textuser.Text == "") MessageBox.Show("กรุณาใส่ชื่อของท่าน", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else textpass.Focus();
            }
        }
        private void label_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
