using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yönetici_Modülü
{
    //  ERCİYES ÜNİVERSİTESİ
    //  MÜHENDİSLİK FAKÜLTESİ
    //  BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
    //  2016-2017 PROGRAMLAMA 2 DERSİ
    //  VİZE 2 ÖDEVİ
    //  HAZIRLAYAN:
    //  MUHAMMED SADUN ÇAKMAKLI
    //  2.ÖĞRETİM A GRUBU
    //  1030520673
    public partial class Form1 : Form
    {
        bool enterkullanici = true, entersifre = true;
        string kullanici_adi = "";
        SqlConnection Hastane = new SqlConnection("Data Source=HOGKNZPC\\HASBILSIS520673;Initial Catalog=Hastane Database;Persist Security Info=True;User ID=sa;Password=123");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tb_kullaniciadi_MouseEnter_1(object sender, EventArgs e)
        {
            if (enterkullanici)
            {
                tb_kullaniciadi.Text = "";
                enterkullanici = false;
            }
        }

        private void tb_sifre_MouseEnter(object sender, EventArgs e)
        {
            if (entersifre)
            {
                tb_sifre.Text = "";
                entersifre = false;
            }
        }

        private void btn_yöneticigirisi_Click(object sender, EventArgs e)
        {
            
            if(giris()==1)
            {
                tb_giriskontrol.Text = "Hoşgeldiniz.";
                Yonetici YoneticiGiris = new Yonetici(kullanici_adi);
                YoneticiGiris.Show();
                System.Threading.Thread.Sleep(500);
                this.Hide();

            }
            else if(giris()==2)
            {
                tb_giriskontrol.Text = "Kullanıcı Adı ile Şifre Eşleşmiyor.";
            }
            else if(giris()==3)
            {
                tb_giriskontrol.Text = "Kullanıcı Adı Bulunamadı.";
            }
            else if(giris()==4)
            {
                tb_giriskontrol.Text = "Okuma Hatası.";
            }
        }

        private int giris()
        {
            Hastane.Open();
            SqlCommand Yönetici_Kullanici_Adi = new SqlCommand("Select Yonetici_Kullanici_Adi from Yönetici_Tanim", Hastane);
            SqlDataReader Kullanici_Adi_Oku = Yönetici_Kullanici_Adi.ExecuteReader();
            List<string> kullaniciadi = new List<string>();

            if (Kullanici_Adi_Oku.HasRows)
            {
                while (Kullanici_Adi_Oku.Read())
                {
                    kullaniciadi.Add(Convert.ToString(Kullanici_Adi_Oku[0]));
                }
            }
            Hastane.Close();
            Kullanici_Adi_Oku.Close();
            Hastane.Open();
            SqlCommand Yönetici_Sifre = new SqlCommand("Select Yonetici_Sifre from Yönetici_Tanim", Hastane);
            SqlDataReader Sifre_Oku = Yönetici_Sifre.ExecuteReader();
            List<string> sifre = new List<string>();

            if (Sifre_Oku.HasRows)
            {
                while (Sifre_Oku.Read())
                {
                    sifre.Add(Convert.ToString(Sifre_Oku[0]));
                }
            }
            Hastane.Close();
            Sifre_Oku.Close();
            bool kullaniciadikontrol = false;
            int s = 0;
            for (s = 0; s < kullaniciadi.Count; s++)
            {
                if (kullaniciadi[s] == tb_kullaniciadi.Text)
                {
                    kullaniciadikontrol = true;
                }
            }

            int sayac=0;
            for (sayac=0; sayac < kullaniciadi.Count; sayac++)
            {
                if(kullaniciadi[sayac]==tb_kullaniciadi.Text && sifre[sayac]==tb_sifre.Text)
                {
                    kullanici_adi = tb_kullaniciadi.Text;
                    return 1;
                }
            }
            if (kullaniciadikontrol == true)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sekretergiris() == 1)
            {
                tb_giriskontrol.Text = "Hoşgeldiniz.";
                Sekreter SekreterGiris = new Sekreter(kullanici_adi);
                SekreterGiris.Show();
                System.Threading.Thread.Sleep(500);
                this.Hide();
            }
            else if (sekretergiris() == 2)
            {
                tb_giriskontrol.Text = "Kullanıcı Adı ile Şifre Eşleşmiyor.";
            }
            else if (sekretergiris() == 3)
            {
                tb_giriskontrol.Text = "Kullanıcı Adı Bulunamadı.";
            }
            else if (sekretergiris() == 4)
            {
                tb_giriskontrol.Text = "Okuma Hatası.";
            }
        }

        private int sekretergiris()
        {
            Hastane.Open();
            SqlCommand Sekreter_Kullanici_Adi = new SqlCommand("Select Sekreter_Kullanici_Adi from Sekreter_Tanim", Hastane);
            SqlDataReader Kullanici_Adi_Oku = Sekreter_Kullanici_Adi.ExecuteReader();
            List<string> kullaniciadi = new List<string>();

            if (Kullanici_Adi_Oku.HasRows)
            {
                while (Kullanici_Adi_Oku.Read())
                {
                    kullaniciadi.Add(Convert.ToString(Kullanici_Adi_Oku[0]));
                }
            }
            Hastane.Close();
            Kullanici_Adi_Oku.Close();
            Hastane.Open();
            SqlCommand Sekreter_Sifre = new SqlCommand("Select Sekreter_Sifre from Sekreter_Tanim", Hastane);
            SqlDataReader Sifre_Oku = Sekreter_Sifre.ExecuteReader();
            List<string> sifre = new List<string>();

            if (Sifre_Oku.HasRows)
            {
                while (Sifre_Oku.Read())
                {
                    sifre.Add(Convert.ToString(Sifre_Oku[0]));
                }
            }
            Hastane.Close();
            Sifre_Oku.Close();
            bool kullaniciadikontrol = false;
            int s = 0;
            for (s = 0; s < kullaniciadi.Count; s++)
            {
                if (kullaniciadi[s] == tb_kullaniciadi.Text)
                {
                    kullaniciadikontrol = true;
                }
            }

            int sayac = 0;
            for (sayac = 0; sayac < kullaniciadi.Count; sayac++)
            {
                if (kullaniciadi[sayac] == tb_kullaniciadi.Text && sifre[sayac] == tb_sifre.Text)
                {
                    kullanici_adi = tb_kullaniciadi.Text;
                    return 1;
                }
            }
            if (kullaniciadikontrol == true)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
