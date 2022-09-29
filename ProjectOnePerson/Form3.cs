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
    public partial class Form3 : Form
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
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label13.Text = Form6.userlogin;
            showEquipment();         
            show_total_price();

        }

        private void backmenu_Click(object sender, EventArgs e) //logout
        {
            this.Close();
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void show_total_price()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT SUM(price) FROM basket WHERE  username = '" + Program.username + "' ";
            object sum = cmd.ExecuteScalar();
            if (Convert.ToString(sum) == "")
            {
                total_price_txt.Text = "0";

            }
            else
            {
                total_price_txt.Text = Convert.ToString(sum);

            }

        }
        
        public static string label_amount = "-";
        private void dataEquipment_1_CellCllick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataEquipment_1.CurrentRow.Selected = true;
                int selected_row = dataEquipment_1.CurrentCell.RowIndex;
                int show_price = Convert.ToInt32(dataEquipment_1.Rows[selected_row].Cells["id"].Value);
                label_id.Text = dataEquipment_1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                label_brand.Text = dataEquipment_1.Rows[e.RowIndex].Cells["brand"].FormattedValue.ToString();
                label_types.Text = dataEquipment_1.Rows[e.RowIndex].Cells["types"].FormattedValue.ToString();
                label_model.Text = dataEquipment_1.Rows[e.RowIndex].Cells["model"].FormattedValue.ToString();
                label_code.Text = dataEquipment_1.Rows[e.RowIndex].Cells["code"].FormattedValue.ToString();              
                
                price_txt.Text = dataEquipment_1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                
                nu_updown_amount.Maximum = int.Parse(price_txt.Text);

                label_check_amount.Text = dataEquipment_1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
                if (price_txt.Text == "" || label_check_amount.Text == "0")
                {
                    select_btn.Enabled = false;
                    MessageBox.Show("สินค้านี้หมดแล้ว กรุณาเลือกสินค้าอื่น", "PARTS COMPUTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    select_btn.Enabled = true;

                }

                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT picture FROM stock WHERE id = \"{show_price}\"", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["picture"]);
                    pictureBox5.Image = new Bitmap(ms);
                }

            }
            catch (Exception)
            { }
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

                    pictureBox5.Image = null;
                }
                else if (search_txt.Text != "")
                {
                    pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
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
            pictureBox5.Image = null;
        }

        private void cbox_select_search_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_select_search_main.Text == "CPU")
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
                pictureBox5.Image = null;

            }
            else if (cbox_select_search_main.Text == "MAINBOARD")
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
                pictureBox5.Image = null;

            }
            else if (cbox_select_search_main.Text == "RAM")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "POWERSUPPLY")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "FANCASE")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "SSD")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "HDD")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "MONITOR")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "MOUSE")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "KEYBOARD")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "SPEAKER")
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
                pictureBox5.Image = null;
            }
            else if (cbox_select_search_main.Text == "CASE")
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
                pictureBox5.Image = null;
            }
            else
            {
                showEquipment();
                pictureBox5.Image = null;
            }
        }

        private void select_btn_Click(object sender, EventArgs e)//btn เลือกสินค้า
        {
            int nu_amount = int.Parse(nu_updown_amount.Text);
            int check_amount = int.Parse(label_check_amount.Text);
            

            if (nu_amount > check_amount && price_txt.Text != "" && total_price_txt.Text == "0")
            {
                MessageBox.Show("ไม่สามารถเลือกสินค้าเกินจำนวนที่มีได้", "PARTS COMPUTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nu_amount < check_amount && price_txt.Text == "" && total_price_txt.Text == "0")
            {
                MessageBox.Show("กรุณา Click ที่รูปภาพ", "PARTS COMPUTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price_txt.Text != "" && nu_amount.Equals(0) && total_price_txt.Text == "0")
            {
                MessageBox.Show("กรุณาระบุจำนวนสินค้าก่อน", "PARTS COMPUTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price_txt.Text != "" && nu_amount.Equals(0) && total_price_txt.Text != "0")
            {
                MessageBox.Show("กรุณาระบุจำนวนสินค้าก่อน", "PARTS COMPUTER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string connectionStingl = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection connl = new MySqlConnection(connectionStingl);
                connl.Open();
                using (MySqlCommand cmdl = new MySqlCommand("SELECT code FROM basket WHERE code ='" + label_code.Text + "' ", connl)) // Check สินค้าในตะกร้าว่ามีซ้ำไหม
                {
                    MySqlDataReader dr = cmdl.ExecuteReader();
                    if (dr.Read())
                    {                               // กรณีที่เลือกสินค้าซ้ำ
                        select_amount_stocks(); //คัดลอกจำนวนสินค้าใน stock
                        select_amount_basket();  //คัดลอกสินค้าใน ตะกร้า
                        int A_BASKET = int.Parse(amount_basket); //  สินค้าในตะกร้า
                        int A_NU_UPDOWN_SELECT = int.Parse(nu_updown_amount.Text); //สินค้าที่เลือกใน NU_UPDOWN
                        if (A_NU_UPDOWN_SELECT < 0) 
                        {
                            MessageBox.Show("กรุณาระบุจำนวนสินค้าให้ถูกต้อง");

                        }
                        else
                        {
                            int ALL_AMOUNT = A_BASKET + A_NU_UPDOWN_SELECT; //จำนวนทั้งหมด
                            string ALL_PRICE = (int.Parse(price_txt.Text) * ALL_AMOUNT).ToString(); //ราคาทั้งหมด
                            string ALL_AMOUNT_NEW = ALL_AMOUNT.ToString();
                            string connectionsn = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8"; // UPDATE ตะกร้า
                            MySqlConnection connss = new MySqlConnection(connectionsn);
                            String sqlsn = "UPDATE basket SET amount ='" + ALL_AMOUNT_NEW + "' ,price = '" + ALL_PRICE + "' WHERE code ='" + label_code.Text + "'";   // UPDATE ตะกร้าสินค้า
                            MySqlCommand cmds = new MySqlCommand(sqlsn, connss);
                            connss.Open();
                            int row = cmds.ExecuteNonQuery();//ตัดstock
                            if (row > 0)//ตัดstock
                            {
                                select_a_stock(); //คัดลอกจำนวนจาก stock
                                // สินค้าที่จะเหลืออยู่ในstock
                                int amount_stock = int.Parse(a_stock); // จำนวนจาก stock
                                int nu_updown = int.Parse(nu_updown_amount.Text); // จำนวนที่เลือก
                                string amount_update = (amount_stock - nu_updown).ToString();  //ตัดstock

                                string connection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                                MySqlConnection conn2 = new MySqlConnection(connection2);
                                String sql2 = "UPDATE stock SET amount = '" + amount_update + "' WHERE code = '" + label_code.Text + "' "; // UPDATE สินค้าใน stock
                                MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                                conn2.Open();
                                int rows2 = cmd2.ExecuteNonQuery();
                                if (rows2 > 0)
                                {
                                    showEquipment();
                                    show_total_price();
                                }
                            }
                        }

                    }
                    else     //     กรณีที่เลือกสินค้าไม่ซ้ำ
                    {
                        select_amount_stocks();  //คัดลอกจำนวนสินค้าใน stock
                        select_amount_basket();    //คัดลอกสินค้าใน ตะกร้าสินค้า
                        int A_STOCK = int.Parse(amount_stocks); // a สินค้าใน stock
                        int A_NU_UPDOWN_SELECT = int.Parse(nu_updown_amount.Text); // จำนวนที่เลือก
                        if (A_NU_UPDOWN_SELECT > A_STOCK)
                        {
                            MessageBox.Show("สินค้าใน stock มีไม่เพียงพอ");

                        }
                        else
                        {
                            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                            MySqlConnection conn = new MySqlConnection(connection);
                            conn.Open();
                            string pri = (int.Parse(price_txt.Text) * int.Parse(nu_updown_amount.Text)).ToString();
                            string time = System.DateTime.Now.ToString("dd / MM / yyyy");
                            String sql = $"INSERT INTO basket (brand, code, price, amount, types, model, date_time, username) VALUES(\"{label_brand.Text}\",\"{label_code.Text}\",\"{pri}\",\"{nu_updown_amount.Text}\",\"{label_types.Text}\",\"{label_model.Text}\",\"{time}\",\"{Program.username}\")";

                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            try
                            {
                                int rows = cmd.ExecuteNonQuery();//ตัดstock

                                if (rows > 0)
                                {
                                    select_a_stock(); //คัดลอกจำนวนจาก stock
                                    // สินค้าที่จะเหลืออยู่ในstock
                                    int amount_stock = int.Parse(a_stock);     // จำนวนสินค้าจาก stock
                                    int nu_updown = int.Parse(nu_updown_amount.Text); // จำนวนที่เลือก
                                    string amount_update = (amount_stock - nu_updown).ToString(); // สินค้าคงเหลือ 

                                    string connection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                                    MySqlConnection conn2 = new MySqlConnection(connection2);
                                    String sql2 = "UPDATE stock SET amount = '" + amount_update + "' WHERE code = '" + label_code.Text + "' ";  // UPDATE จำนวนสินค้าเข้า stock
                                    MySqlCommand cmds = new MySqlCommand(sql2, conn2);  // อัพเดตจำนวนในstock
                                    conn2.Open();
                                    int rows2 = cmds.ExecuteNonQuery();
                                    if (rows2 > 0)
                                    {
                                        showEquipment();
                                        show_total_price();
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                            }
                        }


                    }


                }
            }
            nu_updown_amount.Text = "1";
        }

        
        string a_stock;

        private void select_a_stock() //คัดลอกจำนวนจาก stock เพื่อใช้ในการตัดstock
        {
            String name1 = label_brand.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT amount FROM stock WHERE brand =\"{name1}\" AND code  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a_stock = dr.GetValue(0).ToString();
            }
        }      

        string amount_stocks;
        private void select_amount_stocks() // ดึงค่า amount จาก stock 
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT amount FROM stock WHERE code  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                amount_stocks = dr.GetValue(0).ToString();
            }

        }
        string amount_basket;
        private void select_amount_basket() // ดึง amount จาก basket 
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT amount FROM basket WHERE code  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                amount_basket = dr.GetValue(0).ToString();
            }

        }

        private void basket_picture_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void history_picture_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void price_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void total_price_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataEquipment_Click(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void search_user_Click(object sender, EventArgs e)
        {
            search_txt.Clear();
        }

        private void checkcom_Btn_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "CPU A8-9600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "CPU Ryzen 5 3600")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "CPU Ryzen 3 PRO 4350G")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "CPU Ryzen 5 2600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "CPU Ryzen 5 3500X")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "RAM DDR2(800) 2GB.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "RAM DDR3(1333) 4GB 16 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "RAM DDR4(2400) 4GB. 8 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "RAM DDR4(3200) 16GB. 16 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "RAM DDR4 16GB/4000MHz.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "POWERSUPPLY 550W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "POWERSUPPLY 650W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "POWERSUPPLY 750W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "POWERSUPPLY Lux RGB")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD A520M-A PRO" & comboBox2.Text == "POWERSUPPLY GIGAMAX ZM750-GVII")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "CPU A8-9600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "CPU Ryzen 5 3600")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "CPU Ryzen 3 PRO 4350G")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "CPU Ryzen 5 2600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "CPU Ryzen 5 3500X")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "RAM DDR2(800) 2GB.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "RAM DDR3(1333) 4GB 16 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "RAM DDR4(2400) 4GB. 8 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "RAM DDR4(3200) 16GB. 16 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "RAM DDR4 16GB/4000MHz.")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "POWERSUPPLY 550W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "POWERSUPPLY 650W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "POWERSUPPLY 750W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "POWERSUPPLY Lux RGB")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-K" & comboBox2.Text == "POWERSUPPLY GIGAMAX ZM750-GVII")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "CPU A8-9600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "CPU Ryzen 5 3600")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "CPU Ryzen 3 PRO 4350G")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "CPU Ryzen 5 2600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "CPU Ryzen 5 3500X")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "RAM DDR2(800) 2GB.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "RAM DDR3(1333) 4GB 16 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "RAM DDR4(2400) 4GB. 8 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "RAM DDR4(3200) 16GB. 16 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "RAM DDR4 16GB/4000MHz.")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "POWERSUPPLY 550W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "POWERSUPPLY 650W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "POWERSUPPLY 750W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "POWERSUPPLY Lux RGB")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-E" & comboBox2.Text == "POWERSUPPLY GIGAMAX ZM750-GVII")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "CPU A8-9600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "CPU Ryzen 5 3600")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "CPU Ryzen 3 PRO 4350G")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "CPU Ryzen 5 2600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "CPU Ryzen 5 3500X")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "RAM DDR2(800) 2GB.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "RAM DDR3(1333) 4GB 16 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "RAM DDR4(2400) 4GB. 8 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "RAM DDR4(3200) 16GB. 16 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "RAM DDR4 16GB/4000MHz.")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "POWERSUPPLY 550W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "POWERSUPPLY 650W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "POWERSUPPLY 750W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "POWERSUPPLY Lux RGB")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD PRIME A520M-A/CSM" & comboBox2.Text == "POWERSUPPLY GIGAMAX ZM750-GVII")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "CPU A8-9600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "CPU Ryzen 5 3600")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "CPU Ryzen 3 PRO 4350G")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "CPU Ryzen 5 2600")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "CPU Ryzen 5 3500X")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "RAM DDR2(800) 2GB.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "RAM DDR3(1333) 4GB 16 Chip")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "RAM DDR4(2400) 4GB. 8 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "RAM DDR4(3200) 16GB. 16 Chip")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "RAM DDR4 16GB/4000MHz.")
            {
                MessageBox.Show("ไม่รองรับ", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "POWERSUPPLY 550W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "POWERSUPPLY 650W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "POWERSUPPLY 750W ITSONAS WINNER")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "POWERSUPPLY Lux RGB")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "MAINBOARD TUF GAMING A520M-PLUS" & comboBox2.Text == "POWERSUPPLY GIGAMAX ZM750-GVII")
            {
                MessageBox.Show("รองรับได้", "คำแนะนำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
