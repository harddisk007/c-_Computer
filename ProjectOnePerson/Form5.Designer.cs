namespace ProjectOnePerson
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.button3 = new System.Windows.Forms.Button();
            this.billBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.total_price_txt = new System.Windows.Forms.TextBox();
            this.dataEquipment_GridView = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.label_code = new System.Windows.Forms.Label();
            this.CashBtn = new System.Windows.Forms.Button();
            this.billvatBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Sum_total_txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Vat_txt = new System.Windows.Forms.TextBox();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            this.label_amount = new System.Windows.Forms.Label();
            this.address_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_code1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tel_txt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipment_GridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::ProjectOnePerson.Properties.Resources.istockphoto_1133856693_170667a;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(165, 504);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 57);
            this.button3.TabIndex = 24;
            this.button3.Text = "ลบสินค้า";
            this.button3.UseMnemonic = false;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // billBtn
            // 
            this.billBtn.BackColor = System.Drawing.Color.Transparent;
            this.billBtn.BackgroundImage = global::ProjectOnePerson.Properties.Resources.istockphoto_1133856693_170667a;
            this.billBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.billBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.billBtn.Location = new System.Drawing.Point(4, 572);
            this.billBtn.Margin = new System.Windows.Forms.Padding(4);
            this.billBtn.Name = "billBtn";
            this.billBtn.Size = new System.Drawing.Size(155, 57);
            this.billBtn.TabIndex = 23;
            this.billBtn.Text = "ใบเสร็จแบบย่อ";
            this.billBtn.UseVisualStyleBackColor = false;
            this.billBtn.Click += new System.EventHandler(this.billBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(15, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "จำนวนเงิน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(263, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "บาท";
            // 
            // total_price_txt
            // 
            this.total_price_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.total_price_txt.Location = new System.Drawing.Point(129, 131);
            this.total_price_txt.Margin = new System.Windows.Forms.Padding(4);
            this.total_price_txt.Multiline = true;
            this.total_price_txt.Name = "total_price_txt";
            this.total_price_txt.ReadOnly = true;
            this.total_price_txt.Size = new System.Drawing.Size(125, 32);
            this.total_price_txt.TabIndex = 14;
            // 
            // dataEquipment_GridView
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.dataEquipment_GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataEquipment_GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataEquipment_GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataEquipment_GridView.ColumnHeadersHeight = 30;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataEquipment_GridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataEquipment_GridView.EnableHeadersVisualStyles = false;
            this.dataEquipment_GridView.Location = new System.Drawing.Point(340, 93);
            this.dataEquipment_GridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataEquipment_GridView.Name = "dataEquipment_GridView";
            this.dataEquipment_GridView.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            this.dataEquipment_GridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataEquipment_GridView.Size = new System.Drawing.Size(1226, 537);
            this.dataEquipment_GridView.TabIndex = 26;
            this.dataEquipment_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEquipment_GridView_CellClick);
            this.dataEquipment_GridView.Click += new System.EventHandler(this.dataEquipment_GridView_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backmenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1703, 31);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backmenu
            // 
            this.backmenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.backmenu.Name = "backmenu";
            this.backmenu.Size = new System.Drawing.Size(210, 27);
            this.backmenu.Text = "กลับไปหน้า MAIN MENU";
            this.backmenu.Click += new System.EventHandler(this.backmenu_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(715, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 31);
            this.label7.TabIndex = 28;
            this.label7.Text = "รายการสินค้า";
            // 
            // label_code
            // 
            this.label_code.AutoSize = true;
            this.label_code.BackColor = System.Drawing.Color.Transparent;
            this.label_code.Location = new System.Drawing.Point(296, 650);
            this.label_code.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_code.Name = "label_code";
            this.label_code.Size = new System.Drawing.Size(10, 16);
            this.label_code.TabIndex = 30;
            this.label_code.Text = ".";
            // 
            // CashBtn
            // 
            this.CashBtn.BackColor = System.Drawing.Color.Transparent;
            this.CashBtn.BackgroundImage = global::ProjectOnePerson.Properties.Resources.istockphoto_1133856693_170667a;
            this.CashBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CashBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CashBtn.Location = new System.Drawing.Point(4, 504);
            this.CashBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CashBtn.Name = "CashBtn";
            this.CashBtn.Size = new System.Drawing.Size(155, 57);
            this.CashBtn.TabIndex = 31;
            this.CashBtn.Text = "คำนวณราคา";
            this.CashBtn.UseVisualStyleBackColor = false;
            this.CashBtn.Click += new System.EventHandler(this.CashBtn_Click);
            // 
            // billvatBtn
            // 
            this.billvatBtn.BackColor = System.Drawing.Color.Transparent;
            this.billvatBtn.BackgroundImage = global::ProjectOnePerson.Properties.Resources.istockphoto_1133856693_170667a;
            this.billvatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.billvatBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.billvatBtn.Location = new System.Drawing.Point(165, 572);
            this.billvatBtn.Margin = new System.Windows.Forms.Padding(4);
            this.billvatBtn.Name = "billvatBtn";
            this.billvatBtn.Size = new System.Drawing.Size(155, 57);
            this.billvatBtn.TabIndex = 32;
            this.billvatBtn.Text = "ใบเสร็จแบบเต็ม";
            this.billvatBtn.UseMnemonic = false;
            this.billvatBtn.UseVisualStyleBackColor = true;
            this.billvatBtn.Click += new System.EventHandler(this.billvatBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(22, 221);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "รวมทั้งสิ้น";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(263, 221);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 25);
            this.label9.TabIndex = 34;
            this.label9.Text = "บาท";
            // 
            // Sum_total_txt
            // 
            this.Sum_total_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Sum_total_txt.Location = new System.Drawing.Point(129, 213);
            this.Sum_total_txt.Margin = new System.Windows.Forms.Padding(4);
            this.Sum_total_txt.Multiline = true;
            this.Sum_total_txt.Name = "Sum_total_txt";
            this.Sum_total_txt.ReadOnly = true;
            this.Sum_total_txt.Size = new System.Drawing.Size(125, 32);
            this.Sum_total_txt.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(25, 181);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 25);
            this.label10.TabIndex = 38;
            this.label10.Text = "Vat 7 %";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(263, 181);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 25);
            this.label11.TabIndex = 37;
            this.label11.Text = "บาท";
            // 
            // Vat_txt
            // 
            this.Vat_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Vat_txt.Location = new System.Drawing.Point(129, 172);
            this.Vat_txt.Margin = new System.Windows.Forms.Padding(4);
            this.Vat_txt.Multiline = true;
            this.Vat_txt.Name = "Vat_txt";
            this.Vat_txt.ReadOnly = true;
            this.Vat_txt.Size = new System.Drawing.Size(125, 32);
            this.Vat_txt.TabIndex = 36;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // printPreviewDialog2
            // 
            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog2.Document = this.printDocument2;
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
            this.printPreviewDialog2.Name = "printPreviewDialog2";
            this.printPreviewDialog2.Visible = false;
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.Location = new System.Drawing.Point(207, 583);
            this.label_amount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(88, 16);
            this.label_amount.TabIndex = 39;
            this.label_amount.Text = "label_amount";
            // 
            // address_txt
            // 
            this.address_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.address_txt.Location = new System.Drawing.Point(103, 40);
            this.address_txt.Margin = new System.Windows.Forms.Padding(4);
            this.address_txt.Multiline = true;
            this.address_txt.Name = "address_txt";
            this.address_txt.Size = new System.Drawing.Size(224, 81);
            this.address_txt.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(18, 40);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 48);
            this.label12.TabIndex = 41;
            this.label12.Text = "ที่อยู่ที่\r\nกรอกไว้";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(1412, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 25);
            this.label13.TabIndex = 42;
            this.label13.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(1341, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 25);
            this.label14.TabIndex = 43;
            this.label14.Text = "ชื่อผู้ใช้";
            // 
            // label_code1
            // 
            this.label_code1.AutoSize = true;
            this.label_code1.Location = new System.Drawing.Point(213, 599);
            this.label_code1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_code1.Name = "label_code1";
            this.label_code1.Size = new System.Drawing.Size(82, 16);
            this.label_code1.TabIndex = 44;
            this.label_code1.Text = "label_code1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(350, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 48);
            this.button1.TabIndex = 45;
            this.button1.Text = "Save AND Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Save_AND_Clear_Click);
            // 
            // tel_txt
            // 
            this.tel_txt.Location = new System.Drawing.Point(187, 523);
            this.tel_txt.Margin = new System.Windows.Forms.Padding(4);
            this.tel_txt.Name = "tel_txt";
            this.tel_txt.Size = new System.Drawing.Size(112, 22);
            this.tel_txt.TabIndex = 46;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjectOnePerson.Properties.Resources._262990706_428654828926179_1330686656366201793_n;
            this.pictureBox1.Location = new System.Drawing.Point(27, 252);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::ProjectOnePerson.Properties.Resources.istockphoto_1133856693_170667a;
            this.ClientSize = new System.Drawing.Size(1703, 643);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tel_txt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.billvatBtn);
            this.Controls.Add(this.label_code1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.address_txt);
            this.Controls.Add(this.label_amount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Vat_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Sum_total_txt);
            this.Controls.Add(this.CashBtn);
            this.Controls.Add(this.label_code);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataEquipment_GridView);
            this.Controls.Add(this.billBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.total_price_txt);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายการสินค้าที่เลือก";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.Shown += new System.EventHandler(this.Form5_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipment_GridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button billBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox total_price_txt;
        private System.Windows.Forms.DataGridView dataEquipment_GridView;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backmenu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_code;
        private System.Windows.Forms.Button CashBtn;
        private System.Windows.Forms.Button billvatBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Sum_total_txt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Vat_txt;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
        private System.Windows.Forms.Label label_amount;
        private System.Windows.Forms.TextBox address_txt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_code1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tel_txt;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}