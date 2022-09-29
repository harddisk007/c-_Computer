namespace ProjectOnePerson
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameText2 = new System.Windows.Forms.TextBox();
            this.PassText2 = new System.Windows.Forms.TextBox();
            this.tel_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.closeBtn_Click = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Fpassword_txt = new System.Windows.Forms.TextBox();
            this.address_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(356, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Account";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NameText2
            // 
            this.NameText2.BackColor = System.Drawing.SystemColors.Window;
            this.NameText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.NameText2.Location = new System.Drawing.Point(184, 247);
            this.NameText2.Margin = new System.Windows.Forms.Padding(4);
            this.NameText2.Multiline = true;
            this.NameText2.Name = "NameText2";
            this.NameText2.Size = new System.Drawing.Size(237, 34);
            this.NameText2.TabIndex = 1;
            this.NameText2.TextChanged += new System.EventHandler(this.NameText2_TextChanged);
            // 
            // PassText2
            // 
            this.PassText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PassText2.Location = new System.Drawing.Point(184, 314);
            this.PassText2.Margin = new System.Windows.Forms.Padding(4);
            this.PassText2.Multiline = true;
            this.PassText2.Name = "PassText2";
            this.PassText2.Size = new System.Drawing.Size(237, 34);
            this.PassText2.TabIndex = 2;
            // 
            // tel_txt
            // 
            this.tel_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel_txt.Location = new System.Drawing.Point(496, 246);
            this.tel_txt.Margin = new System.Windows.Forms.Padding(4);
            this.tel_txt.Multiline = true;
            this.tel_txt.Name = "tel_txt";
            this.tel_txt.Size = new System.Drawing.Size(237, 34);
            this.tel_txt.TabIndex = 4;
            this.tel_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tel_txt_keyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(393, 510);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sign up";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // closeBtn_Click
            // 
            this.closeBtn_Click.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.closeBtn_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.closeBtn_Click.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeBtn_Click.Location = new System.Drawing.Point(805, 587);
            this.closeBtn_Click.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn_Click.Name = "closeBtn_Click";
            this.closeBtn_Click.Size = new System.Drawing.Size(121, 42);
            this.closeBtn_Click.TabIndex = 7;
            this.closeBtn_Click.Text = "Close";
            this.closeBtn_Click.UseVisualStyleBackColor = false;
            this.closeBtn_Click.Click += new System.EventHandler(this.closeBtn_Click_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(180, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "password (>6)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(179, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "username (>6)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(492, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "tel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(180, 352);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "confirmpassword";
            // 
            // Fpassword_txt
            // 
            this.Fpassword_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Fpassword_txt.Location = new System.Drawing.Point(184, 380);
            this.Fpassword_txt.Margin = new System.Windows.Forms.Padding(4);
            this.Fpassword_txt.Multiline = true;
            this.Fpassword_txt.Name = "Fpassword_txt";
            this.Fpassword_txt.Size = new System.Drawing.Size(237, 34);
            this.Fpassword_txt.TabIndex = 12;
            // 
            // address_txt
            // 
            this.address_txt.BackColor = System.Drawing.SystemColors.Window;
            this.address_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.address_txt.Location = new System.Drawing.Point(496, 309);
            this.address_txt.Margin = new System.Windows.Forms.Padding(4);
            this.address_txt.Multiline = true;
            this.address_txt.Name = "address_txt";
            this.address_txt.Size = new System.Drawing.Size(237, 117);
            this.address_txt.TabIndex = 13;
            this.address_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.address_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(492, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Calligraphy", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label8.Location = new System.Drawing.Point(87, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(744, 70);
            this.label8.TabIndex = 16;
            this.label8.Text = "HARDDISK  IT Service";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::ProjectOnePerson.Properties.Resources.computer_hd_wallpaper_computer_background_computer_background_backgrounds_265608080;
            this.ClientSize = new System.Drawing.Size(943, 644);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.address_txt);
            this.Controls.Add(this.Fpassword_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn_Click);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tel_txt);
            this.Controls.Add(this.PassText2);
            this.Controls.Add(this.NameText2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameText2;
        private System.Windows.Forms.TextBox PassText2;
        private System.Windows.Forms.TextBox tel_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button closeBtn_Click;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Fpassword_txt;
        private System.Windows.Forms.TextBox address_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}