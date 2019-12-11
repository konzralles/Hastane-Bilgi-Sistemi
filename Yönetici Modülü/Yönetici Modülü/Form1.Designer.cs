namespace Yönetici_Modülü
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_yöneticigirisi = new System.Windows.Forms.Button();
            this.tb_kullaniciadi = new System.Windows.Forms.TextBox();
            this.tb_sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_giriskontrol = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_yöneticigirisi
            // 
            this.btn_yöneticigirisi.BackColor = System.Drawing.Color.Transparent;
            this.btn_yöneticigirisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yöneticigirisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yöneticigirisi.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_yöneticigirisi.Location = new System.Drawing.Point(76, 188);
            this.btn_yöneticigirisi.Name = "btn_yöneticigirisi";
            this.btn_yöneticigirisi.Size = new System.Drawing.Size(174, 34);
            this.btn_yöneticigirisi.TabIndex = 0;
            this.btn_yöneticigirisi.Text = "Yönetici Girişi";
            this.btn_yöneticigirisi.UseVisualStyleBackColor = false;
            this.btn_yöneticigirisi.Click += new System.EventHandler(this.btn_yöneticigirisi_Click);
            // 
            // tb_kullaniciadi
            // 
            this.tb_kullaniciadi.Location = new System.Drawing.Point(76, 87);
            this.tb_kullaniciadi.Name = "tb_kullaniciadi";
            this.tb_kullaniciadi.Size = new System.Drawing.Size(174, 20);
            this.tb_kullaniciadi.TabIndex = 1;
            this.tb_kullaniciadi.Text = "Kullanıcı Adı";
            this.tb_kullaniciadi.MouseEnter += new System.EventHandler(this.tb_kullaniciadi_MouseEnter_1);
            // 
            // tb_sifre
            // 
            this.tb_sifre.Location = new System.Drawing.Point(76, 130);
            this.tb_sifre.Name = "tb_sifre";
            this.tb_sifre.Size = new System.Drawing.Size(174, 20);
            this.tb_sifre.TabIndex = 2;
            this.tb_sifre.Text = "Sifre";
            this.tb_sifre.UseSystemPasswordChar = true;
            this.tb_sifre.MouseEnter += new System.EventHandler(this.tb_sifre_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pristina", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(1, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hastane Yönetim Sistemi";
            // 
            // tb_giriskontrol
            // 
            this.tb_giriskontrol.AutoSize = true;
            this.tb_giriskontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_giriskontrol.Location = new System.Drawing.Point(44, 258);
            this.tb_giriskontrol.Name = "tb_giriskontrol";
            this.tb_giriskontrol.Size = new System.Drawing.Size(0, 15);
            this.tb_giriskontrol.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(73, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kullancı Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(73, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Şifre :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button1.Location = new System.Drawing.Point(76, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sekreter Girişi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(320, 308);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_giriskontrol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_sifre);
            this.Controls.Add(this.tb_kullaniciadi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_yöneticigirisi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Text = "Yönetici ve Sekreter Girişi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_yöneticigirisi;
        private System.Windows.Forms.TextBox tb_kullaniciadi;
        private System.Windows.Forms.TextBox tb_sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tb_giriskontrol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

