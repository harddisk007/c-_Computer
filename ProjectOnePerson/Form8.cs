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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showsale_admin()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
            
        }
        private void showprice(string sql)
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
            MySqlDataReader reader = cmd.ExecuteReader();
            int maxcolumnsum = 0;
            while (reader.Read())
            {
                maxcolumnsum += reader.GetInt32("price");
            }
            textBox1.Text = maxcolumnsum.ToString();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label8.Text = Form1.adminlogin;
            showsale_admin();
            showprice("SELECT * FROM history");
        }
        
        private void search_user_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM history WHERE  username like '%{search_user_txt.Text}%' OR code = \"{search_user_txt.Text}\" OR types = \"{search_user_txt.Text}\" OR model = \"{search_user_txt.Text}\" OR id = \"{search_user_txt.Text}\"";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
        }

        private void search_user_Click(object sender, EventArgs e)
        {
            search_user_txt.Clear();
            showsale_admin();
        }

        private void search_user_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.search_user_Click(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
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
            if (search_user_txt.Text == "")
            {
                showprice("SELECT * FROM history WHERE date_time LIKE '" + ch + "'");
            }
            else if (search_user_txt.Text != "") 
            {
                showprice("SELECT * FROM history WHERE date_time LIKE '" + ch + "' AND username LIKE '" + search_user_txt.Text + "'");

            }
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

    //public partial class Form8 : Form
    //{
    //    public Form8()
    //    {
    //        InitializeComponent();
    //    }
    //    private MySqlConnection databaseConnection()
    //    {
    //        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
    //        MySqlConnection conn = new MySqlConnection(connectionString);
    //        return conn;
    //    }
    //    private void showsale_admin()
    //    {
    //        MySqlConnection conn = databaseConnection();
    //        DataSet ds = new DataSet();
    //        conn.Open();
    //        MySqlCommand cmd;
    //        cmd = conn.CreateCommand();
    //        cmd.CommandText = "SELECT * FROM history";
    //        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
    //        adapter.Fill(ds);
    //        conn.Close();
    //        dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
    //    }
    //    private void Form8_Load(object sender, EventArgs e)
    //    {
    //        label8.Text = Form1.adminlogin;
    //        showsale_admin();
    //    }

    //    private void printPicture_Click_(object sender, EventArgs e)
    //    {
    //        printPreviewDialog1.Document = printDocument1;
    //        printPreviewDialog1.ShowDialog();
    //        showsale_admin();
    //    }

    //    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    //    {
    //        e.Graphics.DrawString("เช็คยอดขาย", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(350, 40));
    //        e.Graphics.DrawString("HARDDISK IT Service", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(285, 80));
    //        e.Graphics.DrawString(" วัน   " + System.DateTime.Now.ToString("dd/MM/yyyy "), new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(525, 185));
    //        e.Graphics.DrawString("เวลา  " + System.DateTime.Now.ToString("HH : mm : ss น."), new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(525, 220));
    //        e.Graphics.DrawString("     ที่อยู่ร้าน : HARDDISK IT Service", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(75, 150));
    //        e.Graphics.DrawString("     บ้านเลขที่  37  หมู่ 1 ตำบลจันทร์เพ็ญ  ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(75, 185));
    //        e.Graphics.DrawString("     อำเภอเต่างอย จังหวัดสกลนคร 47260", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(75, 220));

    //        e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 240));
    //        e.Graphics.DrawString("ชื่อลูกค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(40, 260));
    //        e.Graphics.DrawString("รหัสสินค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 260));
    //        e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(285, 260));
    //        e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(450, 260));
    //        e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(530, 260));
    //        e.Graphics.DrawString("เวลา", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(693, 260));

    //        e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 268));
    //        int y = 290;
    //        salehistory.Clear();
    //        datahistory();
    //        foreach (var i in salehistory)
    //        {
    //            e.Graphics.DrawString(i.username, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(40, y));
    //            e.Graphics.DrawString(i.code, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(170, y));
    //            e.Graphics.DrawString(i.types, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(285, y));
    //            e.Graphics.DrawString(i.price, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(450, y));
    //            e.Graphics.DrawString(i.amount, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(547, y));
    //            e.Graphics.DrawString(i.date_time, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(654, y));
    //            y = y + 20;
    //        }
    //        e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, y + 20));
    //    }

    //    private List<Bill> salehistory = new List<Bill>();

    //    private void datahistory()
    //    {
    //        if (search_user_txt.Text != "")
    //        {
    //            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=login;charset=utf8;");
    //            conn.Open();

    //            MySqlCommand cmd;

    //            cmd = conn.CreateCommand();
    //            cmd.CommandText = $"SELECT * FROM history WHERE date_time between @daystart and @dayend and username=@data ";

    //            MySqlDataAdapter date = new MySqlDataAdapter(cmd);
    //            date.SelectCommand.Parameters.AddWithValue("@daystart", date_1.Value.ToString("dd / MM / yyyy h:mm tt"));
    //            date.SelectCommand.Parameters.AddWithValue("@dayend", date_2.Value.ToString("dd / MM / yyyy  h:mm tt"));
    //            date.SelectCommand.Parameters.AddWithValue("@data", search_user_txt.Text);

    //            MySqlDataReader adapter = cmd.ExecuteReader();

    //            while (adapter.Read())
    //            {
    //                Program.id = adapter.GetString("id");
    //                Program.username = adapter.GetString("username");
    //                Program.brand = adapter.GetString("brand");
    //                Program.types = adapter.GetString("types");
    //                Program.model = adapter.GetString("model");
    //                Program.code = adapter.GetString("code");
    //                Program.price = adapter.GetString("price");
    //                Program.amount = adapter.GetString("amount");
    //                Program.date_time = adapter.GetString("date_time");
    //                Bill item = new Bill()
    //                {
    //                    id = Program.id,
    //                    username = Program.username,
    //                    brand = Program.brand,
    //                    types = Program.types,
    //                    model = Program.model,
    //                    code = Program.code,
    //                    price = Program.price,
    //                    amount = Program.amount,
    //                    date_time = Program.date_time

    //                };
    //                salehistory.Add(item);
    //            }
    //        }
    //        else
    //        {

    //            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=login;charset=utf8;");
    //            conn.Open();

    //            MySqlCommand cmd;

    //            cmd = conn.CreateCommand();
    //            cmd.CommandText = $"SELECT * FROM history WHERE date_time between @daystart and @dayend";

    //            MySqlDataAdapter date = new MySqlDataAdapter(cmd);
    //            date.SelectCommand.Parameters.AddWithValue("@daystart", date_1.Value.ToString("dd / MM / yyyy  h:mm tt"));
    //            date.SelectCommand.Parameters.AddWithValue("@dayend", date_2.Value.ToString("dd / MM / yyyy  h:mm tt"));

    //            MySqlDataReader adapter = cmd.ExecuteReader();

    //            while (adapter.Read())
    //            {
    //                Program.id = adapter.GetString("id");
    //                Program.username = adapter.GetString("username");
    //                Program.brand = adapter.GetString("brand");
    //                Program.types = adapter.GetString("types");
    //                Program.model = adapter.GetString("model");
    //                Program.code = adapter.GetString("code");
    //                Program.price = adapter.GetString("price");
    //                Program.amount = adapter.GetString("amount");
    //                Program.date_time = adapter.GetString("date_time");
    //                Bill item = new Bill()
    //                {
    //                    id = Program.id,
    //                    username = Program.username,
    //                    brand = Program.brand,
    //                    types = Program.types,
    //                    model = Program.model,
    //                    code = Program.code,
    //                    price = Program.price,
    //                    amount = Program.amount,
    //                    date_time = Program.date_time

    //                };
    //                salehistory.Add(item);
    //            }
    //        }

    //    }
    //    private void search_user_TextChanged(object sender, EventArgs e)
    //    {
    //        MySqlConnection conn = databaseConnection();
    //        DataSet ds = new DataSet();
    //        conn.Open();
    //        MySqlCommand cmd;
    //        cmd = conn.CreateCommand();
    //        cmd.CommandText = $"SELECT * FROM history WHERE  username = \"{search_user_txt.Text}\" OR code = \"{search_user_txt.Text}\" OR price = \"{search_user_txt.Text}\" OR types = \"{search_user_txt.Text}\" OR model = \"{search_user_txt.Text}\" OR id = \"{search_user_txt.Text}\"";
    //        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
    //        adap.Fill(ds);
    //        conn.Close();
    //        dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
    //    }

    //    private void search_user_Click(object sender, EventArgs e)
    //    {
    //        search_user_txt.Clear();
    //        showsale_admin();
    //    }

    //    private void search_user_txt_KeyDown(object sender, KeyEventArgs e)
    //    {
    //        if (e.KeyCode == Keys.Enter) this.search_user_Click(sender, e);
    //    }


    //    private void label4_Click(object sender, EventArgs e)
    //    {
    //        this.Close();
    //        this.Hide();
    //        Form2 f2 = new Form2();
    //        f2.ShowDialog();
    //    }

        //private void picture_search_Click(object sender, EventArgs e)
        //{
        //    if (search_user_txt.Text == "CPU" || search_user_txt.Text == "MAINBOARD" || search_user_txt.Text == "LAM" || search_user_txt.Text == "POWERSUPPLY" || search_user_txt.Text == "FANCASE" || search_user_txt.Text == "SSD" || search_user_txt.Text == "HDD" || search_user_txt.Text == "MONITOR" || search_user_txt.Text == "MOUSE" || search_user_txt.Text == "KEYBOARD" || search_user_txt.Text == "SPEAKER" || search_user_txt.Text == "CASE")
        //    {
        //        MySqlConnection conn = databaseConnection();

        //        DataSet ds = new DataSet();

        //        conn.Open();
        //        MySqlCommand cmd;

        //        cmd = conn.CreateCommand();
        //        cmd.CommandText = $"SELECT * FROM history WHERE brand = @data AND username = @user";

        //        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        //        adapter.SelectCommand.Parameters.AddWithValue("@data", search_user_txt.Text);
        //        adapter.SelectCommand.Parameters.AddWithValue("@user", Program.username);

        //        adapter.Fill(ds);
        //        conn.Close();
        //        dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
        //    }

        //    else if (search_user_txt.Text != "")
        //    {
        //        MySqlConnection conn = databaseConnection();

        //        DataSet ds = new DataSet();

        //        conn.Open();
        //        MySqlCommand cmd;

        //        cmd = conn.CreateCommand();
        //        cmd.CommandText = $"SELECT * FROM history WHERE code = @Code  AND username = @user ";

        //        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        //        adapter.SelectCommand.Parameters.AddWithValue("@Code", search_user_txt.Text);
        //        adapter.SelectCommand.Parameters.AddWithValue("@user", Program.username);

        //        adapter.Fill(ds);
        //        conn.Close();
        //        dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;
        //    }
        //}




