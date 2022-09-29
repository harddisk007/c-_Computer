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
using System.IO;


namespace ProjectOnePerson

{
    public partial class Form2 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
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
            cmd.CommandText = "SELECT * FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label8.Text = Form1.adminlogin;
            showEquipment();          
            total_amount_stock();
        }
        public Boolean check_code() 
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string usn = codetext.Text;
            DataTable tb = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM stock WHERE code = @code", conn);

            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = usn;
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
        private void submitBtn_Click(object sender, EventArgs e) // เพิ่มข้อมูล
        {
            if (pricetext.Text == "")
            {
                MessageBox.Show("กรุณาเพิ่มข้อมูลก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check_code())
            {
                MessageBox.Show("ข้อมูลซ้ำ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                try
                {
                    string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                    MySqlConnection conn = new MySqlConnection(connection);
                    byte[] image = null;
                    pictureBox1.ImageLocation = location_txt.Text;
                    string filepath = location_txt.Text;
                    FileStream files = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    BinaryReader binary = new BinaryReader(files);
                    image = binary.ReadBytes((int)files.Length);
                    string sql = $" INSERT INTO stock (brand, code, types, model, price, amount, picture) VALUES(\"{brandtext.Text}\",\"{codetext.Text}\",\"{typestext.Text}\",\"{modeltext.Text}\",\"{pricetext.Text}\",\"{amounttext.Text}\",@Imgg)";
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                        int x = cmd.ExecuteNonQuery();
                        conn.Close();
                        showEquipment();

                    }
                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    total_amount_stock();
                }
                catch (Exception)
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("กรุณา Browse รูปภาพก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            
        }
        private void total_amount_stock()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COALESCE(sum(amount),0) FROM stock WHERE types = '" + cbox_select.Text + "' "; // SUM จำนวนสินค้าจาก combobox เลือกรายการเดียว
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Program.test = dr.GetString("COALESCE(sum(amount),0)"); // ดักerror sum
            total_amount_stock_txt.Text = Program.test;
        }
        private void sum_stock()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COALESCE(sum(amount),0) FROM stock";  //  SUM จำนวนสินค้าทั้งหมด
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Program.test = dr.GetString("COALESCE(sum(amount),0)");
            total_amount_stock_txt.Text = Program.test;
        }

        private void dataEquipment_Click(object sender, DataGridViewCellEventArgs e)
        {
            dataEquipment_1.CurrentRow.Selected = true;
            brandtext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["brand"].FormattedValue.ToString();
            typestext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["types"].FormattedValue.ToString();
            modeltext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["model"].FormattedValue.ToString();
            codetext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["code"].FormattedValue.ToString();
            pricetext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            amounttext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
            pictureBox1.Text = dataEquipment_1.Rows[e.RowIndex].Cells["picture"].FormattedValue.ToString();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataEquipment_1.CurrentRow.Selected = true;
                int selectedRows = dataEquipment_1.CurrentCell.RowIndex;
                int cellid = Convert.ToInt32(dataEquipment_1.Rows[selectedRows].Cells["id"].Value);

                brandtext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["brand"].FormattedValue.ToString();
                codetext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["code"].FormattedValue.ToString();
                typestext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["types"].FormattedValue.ToString();
                modeltext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["model"].FormattedValue.ToString();
                pricetext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                amounttext.Text = dataEquipment_1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();

                label_id.Text = dataEquipment_1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();

                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT picture FROM stock WHERE id =\"{cellid}\"", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["picture"]);
                    pictureBox1.Image = new Bitmap(ms);
                }
            }
            catch (Exception) { }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (pricetext.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("ยืนยันลบข้อมูล", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int selectedRow = dataEquipment_1.CurrentCell.RowIndex;
                int deleteId = Convert.ToInt32(dataEquipment_1.Rows[selectedRow].Cells["id"].Value);
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connection);
                String sql = "DELETE FROM stock WHERE id = '" + deleteId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("ลบข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pictureBox1.Image = null;
                    brandtext.Text = "";
                    codetext.Text = "";
                    typestext.Text = "";
                    modeltext.Text = "";
                    pricetext.Text = "";
                    amounttext.Text = "";
                    showEquipment();
                    total_amount_stock();
                }
            }
            else
            {
                return;               
            }
            
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (pricetext.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไขก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int selectedRows = dataEquipment_1.CurrentCell.RowIndex;
                    int editid = Convert.ToInt32(dataEquipment_1.Rows[selectedRows].Cells["id"].Value);
                    MySqlConnection conn = databaseConnection();
                    byte[] image = null;
                    string filepath = location_txt.Text;
                    FileStream files = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    BinaryReader binary = new BinaryReader(files);
                    image = binary.ReadBytes((int)files.Length);
                    String sql = "UPDATE  stock SET brand = '" + brandtext.Text + "',code = '" + codetext.Text + "',types ='" + typestext.Text + "',model = '" + modeltext.Text + "',price= '" + pricetext.Text + "',amount= '" + amounttext.Text + "',picture= @Imgg WHERE id = '" + editid + "'";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showEquipment();
                        pictureBox1.Visible = true;
                        total_amount_stock();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("กรุณา Browse รูปภาพก่อนแก้ไขข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            brandtext.Clear();
            typestext.Clear();
            modeltext.Clear();
            codetext.Clear();
            pricetext.Clear();
            amounttext.Clear();
        }
        private void typestext_TextChanged(object sender, EventArgs e)
        {

        }


        private void historySell_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

     
        private void backAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                location_txt.Text = open.FileName;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void search_txt_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM stock WHERE brand like '%{search_txt.Text}%' OR code like '%{search_txt.Text}%' OR types like '%{search_txt.Text}%' OR model like '%{search_txt.Text}%' ";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            try
            {
                if (search_txt.Text == "")
                {
                    if (search_txt.Text == "CPU")
                    {
                        show_CPU();
                    }
                    else if (search_txt.Text == "MAINBOARD")
                    {
                        show_MAINBOARD();
                    }
                    else if (search_txt.Text == "RAM")
                    {
                        show_RAM();
                    }
                    else if (search_txt.Text == "POWERSUPPLY")
                    {
                        show_POWERSUPPLY();
                    }
                    else if (search_txt.Text == "FANCASE")
                    {
                        show_FANCASE();
                    }
                    else if (search_txt.Text == "SSD")
                    {
                        show_SSD();
                    }
                    else if (search_txt.Text == "HDD")
                    {
                        show_HDD();
                    }
                    else if (search_txt.Text == "MONITOR")
                    {
                        show_MONITOR();
                    }
                    else if (search_txt.Text == "MOUSE")
                    {
                        show_MOUSE();
                    }
                    else if (search_txt.Text == "KEYBOARD")
                    {
                        show_KEYBOARD();
                    }
                    else if (search_txt.Text == "SPEAKER")
                    {
                        show_SPEAKER();
                    }
                    else if (search_txt.Text == "CASE")
                    {
                        show_CASE();
                    }
                    else
                    {
                        showEquipment();
                    }
                }

            }
            catch (Exception) { }
        }
        private void show_CPU()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "CPU";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_MAINBOARD()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "MAINBOARD";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_RAM()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "RAM";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_POWERSUPPLY()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "POWERSUPPLY";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_FANCASE()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "FANCASE";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_SSD()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "SSD";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_HDD()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "HDD";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_MONITOR()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "MONITOR";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_MOUSE()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "MOUSE";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_KEYBOARD()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "KEYBOARD";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_SPEAKER()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "SPEAKER";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void show_CASE()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string name = "CASE";
            cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            dataEquipment_1.DataSource = ds.Tables[0].DefaultView;

            search_txt.Text = "";
            total_amount_stock();
        }
        private void Search_Clear_Click(object sender, EventArgs e)
        {
            search_txt.Clear();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_select.Text == "CPU")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "CPU";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();               
            }
            else if (cbox_select.Text == "MAINBOARD")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "MAINBOARD";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
              
            }
            else if (cbox_select.Text == "RAM")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "RAM";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;               
                total_amount_stock();
            }
            else if (cbox_select.Text == "POWERSUPPLY")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "POWERSUPPLY";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "FANCASE")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "FANCASE";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "SSD")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "SSD";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "HDD")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "HDD";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "MONITOR")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "MONITOR";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "MOUSE")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "MOUSE";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "KEYBOARD")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "KEYBOARD";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "SPEAKER")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "SPEAKER";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else if (cbox_select.Text == "CASE")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                string name = "CASE";
                cmd.CommandText = $"SELECT * FROM stock WHERE types = \"{name}\"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);


                dataEquipment_1.DataSource = ds.Tables[0].DefaultView;
                total_amount_stock();
            }
            else
            {
                showEquipment();
                sum_stock();
            }

        }

        private void bg_Click(object sender, EventArgs e)
        {

        }

        private void dataEquipment_1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void brandtext_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pricetext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("ใช้ได้เฉพาะตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void amounttext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("ใช้ได้เฉพาะตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
    
}
