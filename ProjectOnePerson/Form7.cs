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
    public partial class Form7 : Form
    {
        
        public Form7()
        {
            InitializeComponent();
        }

        public Boolean check_user()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string usn = NameText2.Text;
            DataTable tb = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE username = @user", conn);

            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = usn;
            adap.SelectCommand = cmd;
            adap.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            if (NameText2.Text == "" || PassText2.Text == "" || Fpassword_txt.Text == "" || tel_txt.Text == "" || address_txt.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tel_txt.TextLength < 10 || tel_txt.TextLength > 10)
            {
                MessageBox.Show("กรุณากรอกเบอร์โทรให้ถูกต้อง", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_user())
            {
                MessageBox.Show("บัญชีผู้ใช้มีอยู่แล้ว", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PassText2.Text != Fpassword_txt.Text)
            {
                MessageBox.Show("กรุณากรอกรหัสผ่านให้ตรงกัน", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NameText2.TextLength < 6)
            {
                MessageBox.Show(" username ควรมีความยาวอย่างน้อย 6 ตัวอักษรขึ้นไป", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PassText2.TextLength < 6)
            {
                MessageBox.Show(" password ควรมีความยาวอย่างน้อย 6 ตัวอักษรขึ้นไป", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string c = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(c);
                conn.Open();
                string sql = $" INSERT INTO user (username, password, tel, address) VALUES(\"{NameText2.Text}\",\"{PassText2.Text}\",\"{tel_txt.Text}\",\"{address_txt.Text}\")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("ลงทะเบียนสำเร็จ", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form6 f6 = new Form6();
                    this.Hide();
                    f6.Show();
                }
            }
        }


        private void closeBtn_Click_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void NameText2_TextChanged(object sender, EventArgs e)
        {

        }
        private void tel_txt_keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("ใช้ได้้เฉพาะตัวเลขเท่านั้น", "Customer Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.SignUp_Click(sender, e);
        }
        
    }
}
