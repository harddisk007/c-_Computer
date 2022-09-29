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
    public partial class Form5 : Form

    {
        public Form5()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            return conn;
        }
        private void show_total_price()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            

            cmd.CommandText = "SELECT SUM(price) FROM basket WHERE  username='" + Program.username + "'  ";
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

        private void Form5_Load(object sender, EventArgs e)
        {           
            label13.Text = Form6.userlogin;
            show_total_price();
            show_basket();
        }
        private void show_basket()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM basket WHERE username = '" + Program.username + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            dataEquipment_GridView.DataSource = ds.Tables[0].DefaultView;

        }

     
        string amount_basket;
        private void select_amount_basket()// ดึง amount จาก basket เพื่อใช้ในการตัดstock
        {
            String name1 = label_code1.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT amount FROM basket WHERE code = \"{name1}\"";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                amount_basket = dr.GetValue(0).ToString();
            }
        }


        string amount_stock;
        public void select_amount_stock()// ดึง amount จาก stock เพื่อใช้ในการตัดstock
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT amount FROM stock WHERE code =\"{label_code1.Text}\"  ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                amount_stock = dr.GetValue(0).ToString();
            }
        }   

        private void backmenu_Click(object sender, EventArgs e)
        {   
            this.Close();
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();         
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            select_amount_basket();
            select_amount_stock();

            if (MessageBox.Show("ยืนยันลบข้อมูล", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connection);
                String sql = "DELETE FROM basket WHERE code = '" + label_code1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0) //ตัดคืน stock
                {
                    show_basket();
                    show_total_price();
                    int all_amount_stock = int.Parse(amount_stock); 
                    int all_amount_basket = int.Parse(amount_basket);
                    int new_all_amount = all_amount_stock + all_amount_basket;
                    string amount = new_all_amount.ToString();
                    string connectionsn = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                    MySqlConnection connss = new MySqlConnection(connectionsn);
                    String sqlsn = "UPDATE stock SET amount ='" + amount + "' WHERE code ='" + label_code1.Text + "'";
                    MySqlCommand cmds = new MySqlCommand(sqlsn, connss);
                    connss.Open();
                    int row = cmds.ExecuteNonQuery();
                    if (row > 0)
                    {
                        show_basket();
                        show_total_price();
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void dataEquipment_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataEquipment_GridView.CurrentRow.Selected = true;
            int selectcode = dataEquipment_GridView.CurrentCell.RowIndex;
            var show_code = dataEquipment_GridView.Rows[selectcode].Cells["code"].Value;

            label_code1.Text = show_code.ToString();
        }

        private void dataEquipment_GridView_Click(object sender, EventArgs e)
        {

        }

        private void CashBtn_Click(object sender, EventArgs e)
        {
            if (total_price_txt.Text == "0")
            {
                MessageBox.Show("กรุณาเลือกสินค้าก่อน");
            }
            else if (total_price_txt.Text == "")
            {
                MessageBox.Show("กรุณาเลือกสินค้าก่อน");
            }
            else
            {
                int price_ = int.Parse(total_price_txt.Text);

                if (price_ < 0)
                {
                    MessageBox.Show("กรุณาใส่จำนวนเงินให้ถูกต้อง");
                }
                else
                {
                    Vat_txt.Text = (price_ * 0.07).ToString();
                    double vat = double.Parse(Vat_txt.Text);
                    Sum_total_txt.Text = (price_ + vat).ToString();
                }
            }
        }
        private void billBtn_Click(object sender, EventArgs e)
        {
            if (total_price_txt.Text != "")
            {
                show_basket();
                show_total_price();

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("บริษัท ฮาร์ดดิสก์ ไอที เซอร์วิส จำกัด", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(268, 40));
            e.Graphics.DrawString("วันที่   " + System.DateTime.Now.ToString("dd/MM/yyyy "), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(570, 128));
            e.Graphics.DrawString("เวลา   " + System.DateTime.Now.ToString("HH : mm : ss น."), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(571, 145));
            e.Graphics.DrawString("     ที่อยู่ร้าน : HARDDISK IT Service", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 80));
            e.Graphics.DrawString("     บ้านเลขที่ 37 หมู่ 1 ตำบลจันทร์เพ็ญ  ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 110));
            e.Graphics.DrawString("     อำเภอเต่างอย จังหวัดสกลนคร 47260", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 140));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 150));
            e.Graphics.DrawString("รหัสสินค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(30, 170));
            e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(155, 170));
            e.Graphics.DrawString("รุ่น", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(350, 170));
            e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(664, 170));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(740, 170));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 175));

            int y = 200;
            allbill.Clear();
            loadbill();
            foreach (var i in allbill)
            {
                e.Graphics.DrawString(i.code, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(30, y));
                e.Graphics.DrawString(i.types, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(155, y));
                e.Graphics.DrawString(i.model, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(350, y));
                e.Graphics.DrawString(i.amount, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(685, y));
                e.Graphics.DrawString(i.price, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(740, y));
                y = y + 20;
            }


            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, y + 20));
            e.Graphics.DrawString("รวมทั้งสิ้น    " + Sum_total_txt.Text + "   บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(312, (y) + 45));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, ((((y - 10) + 45) + 45) + 45) + 10));
            e.Graphics.DrawString(" ขอบคุณที่ใช้บริการครับผม ^_^ ^_^ ", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(275, ((((y + 10) + 45) + 45) + 45) + 10));
        }

        
        private void billvatBtn_Click(object sender, EventArgs e)
        {
            if (Sum_total_txt.Text == "")
            {
                MessageBox.Show("กรุณาคำนวณเงินก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Sum_total_txt.Text != "0")
            {
                show_basket();
                show_total_price();

                printPreviewDialog2.Document = printDocument2;
                printPreviewDialog2.ShowDialog();
            }
            else if (Sum_total_txt.Text == "0")
            {
                MessageBox.Show("ไม่มีข้อมูลให้ปริ้นใบเสร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clear_bill();
            }                     
        }
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("บริษัท ฮาร์ดดิสก์ ไอที เซอร์วิส จำกัด", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(30, 100));
            e.Graphics.DrawString("เลขประจำตัวผู้เสียภาษี 1212312121", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(30, 25));
            e.Graphics.DrawString("ใบกำกับภาษี", new Font("TH SarabunPSK", 22, FontStyle.Bold), Brushes.Black, new Point(620, 15));
            e.Graphics.DrawString("วันที่   " + System.DateTime.Now.ToString("dd/MM/yyyy "), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(620, 50));
            e.Graphics.DrawString("เวลา   " + System.DateTime.Now.ToString("HH : mm : ss น."), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(621, 70));
            e.Graphics.DrawString("ที่อยู่ร้าน : HARDDISK IT Service", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(30, 130));
            e.Graphics.DrawString("บ้านเลขที่ 37 หมู่ 1 ตำบลจันทร์เพ็ญ  ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(30, 155));
            e.Graphics.DrawString("อำเภอเต่างอย จังหวัดสกลนคร 47260", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(30, 180));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 205));
            e.Graphics.DrawString("รหัสสินค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(40, 225));
            e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(150, 225));
            e.Graphics.DrawString("รุ่น", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(360, 225));
            e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(640, 225));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(731, 225));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 235));

            int y = 255;
            allbill.Clear();
            loadbill();
            foreach (var i in allbill)
            { 
                e.Graphics.DrawString(i.code, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(40, y));
                e.Graphics.DrawString(i.types, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(150, y));
                e.Graphics.DrawString(i.model, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(360, y));
                e.Graphics.DrawString(i.amount, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(660, y));
                e.Graphics.DrawString(i.price, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(731, y));
                
                y = y + 23;
            } 

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, y + 20));
            e.Graphics.DrawString("ชื่อผู้ซื้อ  " + Program.username + " ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(460, 100));
            e.Graphics.DrawString("เบอร์โทร " + tel_txt.Text + " ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(460, 185));
            e.Graphics.DrawString("ที่อยู่ผู้ซื้อ  " + address_txt.Text + " ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(460, 130));
            e.Graphics.DrawString("มูลค่ารวมก่อนเสียภาษี     " + total_price_txt.Text + "   บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(480, (y) + 45));
            e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม 7 %    " + Vat_txt.Text + "   บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(505, ((y - 10) + 45) + 45));
            e.Graphics.DrawString("จำนวนเงินรวมทั้งสิ้น  " + Sum_total_txt.Text + "    บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(492, (((y - 20) + 45) + 45) + 45));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, ((((y - 10) + 45) + 45) + 45) + 10));
            e.Graphics.DrawString(" ขอบคุณที่ใช้บริการครับผม ^_^ ^_^ ", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(255, ((((y + 10) + 45) + 45) + 45) + 10));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 1010));
            e.Graphics.DrawString("(........................)", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(50, 1050));
            e.Graphics.DrawString("       ผู้รับของ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(50, 1075));
            e.Graphics.DrawString("(.....HARDDISK.....)", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(600, 1050));
            e.Graphics.DrawString("         ผู้ส่งของ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(600, 1075));
        }

        private List<print> allbill = new List<print>(); //เป็นฟังก์ชันสำหรับจัดเรียงรายการในclassนี้ได้

        private void loadbill()
        {
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=login;charset=utf8;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM basket ", conn);
            MySqlDataReader adapter = cmd.ExecuteReader();

            while (adapter.Read()) //แปรงค่า adapter แล้วดึงมาเก็บที่ item แล้วมาปริ้น
            {
                Program.id = adapter.GetString("id");
                Program.username = adapter.GetString("username");
                Program.brand = adapter.GetString("brand");
                Program.types = adapter.GetString("types");
                Program.model = adapter.GetString("model");
                Program.code = adapter.GetString("code");
                Program.price = adapter.GetString("price");
                Program.amount = adapter.GetString("amount");
                Program.date_time = adapter.GetString("date_time");

                print item = new print()
                {
                    id = Program.id,
                    username = Program.username,
                    brand = Program.brand,
                    types = Program.types,
                    model = Program.model,
                    code = Program.code,
                    price = Program.price,
                    amount = Program.amount,
                    date_time = Program.date_time
                };
                allbill.Add(item);
            }
        }
        private void Save_AND_Clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการทำรายการต่อหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connection);
                String sql = "INSERT INTO history SELECT * FROM basket";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                clear_bill();

                total_price_txt.Text = "0";
                Vat_txt.Text = "0";
                Sum_total_txt.Text = "0";
               
                //Form3 f3 = new Form3();
                //f3.ShowDialog();
            }

        }
        private void clear_bill()
        {
            MySqlConnection conn2 = new MySqlConnection("host=127.0.0.1;username=root;password=;database=login;charset=utf8;");
            String sql = "DELETE FROM basket ";
            MySqlCommand cmd2 = new MySqlCommand(sql, conn2);
            conn2.Open();
            cmd2.ExecuteNonQuery();
            conn2.Close();
            show_basket();
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            address_txt.Text = Form6.address;
            tel_txt.Text = Form6.tel;
        }

        
    }
}
