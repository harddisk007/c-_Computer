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
    public partial class Form1 : Form
    {
        public static string adminlogin;
        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void adminBtn_Click(object sender, EventArgs e) //login
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM admin WHERE username1 = '" + get_user.Text + "' AND password1 = '" + get_pass.Text + "'";

            MySqlDataReader row = cmd.ExecuteReader();

            if (row.Read())
            {
                Program.username = get_user.Text;
                MessageBox.Show("เข้าสู่ระบบสำเร็จ", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adminlogin = get_user.Text;
                get_user.Clear();
                get_pass.Clear();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือรหัสผ่านไม่ถูกต้อง", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                get_user.Clear();
                get_pass.Clear();
            }      
        }

       
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerPicture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ไปหน้า login ลูกค้า", "Customer Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string x = checkBox1.Text;
                get_pass.PasswordChar = '\0';
            }
            else
            {
                get_pass.PasswordChar = '•';
            }
        }
    

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (get_pass.Text == "") MessageBox.Show("กรุณาใส่รหัสผ่านของท่าน", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else this.adminBtn_Click(sender, e);
            }
        }

    }
}



/*
namespace WindowsForm10
{
    public partial class Form1 : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=work5;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd;
            conn.Open();

            DataSet ds = new DataSet();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM login";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showEquipment();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("host=localhost;user=root;password=;database=work5;charset=utf8");
            conn.Open();
            string sql = "SELECT * FROM login";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (get_user.Text.Trim() == dr.GetString("user") && get_pass.Text.Trim() == dr.GetString("password"))
                {
                    MessageBox.Show("Wellcome");
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    this.Close();
                }

            }

        }
        private void dataEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataEquipment_1.CurrentRow.Selected = true;
            get_user.Text = dataEquipment_1.Rows[e.RowIndex].Cells["user"].FormattedValue.ToString();
            get_pass.Text = dataEquipment_1.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();

        }


    }
}
///
/* 
{
    public partial class Form2 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }

        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd;
            conn.Open();

            DataSet ds = new DataSet();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM sport_equipment";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataEquipment.DataSource = ds.Tables[0].DefaultView;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            String sql = "INSERT INTO sport_equipment (name, amount) VALUES('" + NameText.Text + "' , '" + AmountText.Text + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int row = cmd.ExecuteNonQuery();

            conn.Close();

            if (row > 0)
            {
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");

                showEquipment();
            }
        }

        private void dataEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataEquipment.CurrentRow.Selected = true;
            NameText.Text = dataEquipment.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            AmountText.Text = dataEquipment.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = dataEquipment.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(dataEquipment.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = "DELETE FROM sport_equipment WHERE id = '" + deleteId + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("ลบข้อมูลสำเร็จ");
                //เรียก showEquipment(); เพื่ออัพเดตข้อมูล
                showEquipment();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = dataEquipment.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataEquipment.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = "UPDATE sport_equipment SET name = '" + NameText.Text + "',amount = '" + AmountText.Text + "' WHERE id = '" + editId + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                //เรียก showEquipment(); เพื่ออัพเดตข้อมูลในตาราง
                showEquipment();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearBtn1_Click(object sender, EventArgs e)
        {
            this.NameText.Clear();
            this.AmountText.Clear();
        }
        
    }
}


*/
