using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOnePerson
{
    public partial class Probation : Form
    {
        public Probation()
        {
            InitializeComponent();
        }

        private void total_price_txt_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Vat_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sum_total_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void get_monney_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void change_txt_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (get_monney_txt.Text == "")
            {
                MessageBox.Show("กรุณาใส่จำนวนเงิน");
            }
            else
            {
                double get_money = double.Parse(get_monney_txt.Text);
                int price_ = int.Parse(total_price_txt.Text);
                double sum = double.Parse(Sum_total_txt.Text);

                if (get_money < price_)
                {
                    MessageBox.Show("กรุณาใส่จำนวนเงินให้ถูกต้อง");
                }
                else
                {
                    change_txt.Text = (get_money - sum).ToString();

                    //string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=login;charset=utf8;";
                    //MySqlConnection conn = new MySqlConnection(connection);


                    //String sql = "INSERT INTO history SELECT * FROM basket";
                    //MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //conn.Open();
                    //int rows = cmd.ExecuteNonQuery();
                    //conn.Close();
                    //if (rows > 0)
                    //{

                    //    show_payment();
                    //    show_total_price();


                    //    printPreviewDialog1.Document = printDocument1;
                    //    printPreviewDialog1.ShowDialog();


                    //}
                    //else
                    //{
                    //    clear_data();
                    //    loaddata();
                    //}

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            total_price_txt.Clear();
            get_monney_txt.Clear();
            change_txt.Clear();
            Sum_total_txt.Clear();
            Vat_txt.Clear();
        }

        private void total_price_txt_Click(object sender, EventArgs e)
        {
            //if (get_monney_txt.Text == "")
            //{
            //    MessageBox.Show("กรุณาใส่จำนวนเงิน");
            //}
            //else
            //{
            //    int get_money = int.Parse(get_monney_txt.Text);
            //    int price_ = int.Parse(total_price_txt.Text);

            //    double vat = double.Parse(Vat_txt.Text);

            //    if (get_money < price_)
            //    {
            //        MessageBox.Show("กรุณาใส่จำนวนเงินให้ถูกต้อง");
            //    }
            //    else
            //    {
            //        change_txt.Text = (get_money - price_).ToString();
            //        Vat_txt.Text = (price_ * 0.07).ToString();
            //        Sum_total_txt.Text = (vat).ToString();
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price_ = int.Parse(total_price_txt.Text);
            //int get_money = int.Parse(get_monney_txt.Text);
            //int vat = int.Parse(Vat_txt.Text);
            //change_txt.Text = (get_money - price_).ToString();
            Vat_txt.Text = (price_ * 0.07).ToString();
            double vat = double.Parse(Vat_txt.Text);
            Sum_total_txt.Text = (price_ + vat).ToString();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
