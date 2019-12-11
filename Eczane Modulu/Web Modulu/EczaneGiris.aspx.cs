using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web_Modulu
{
    public partial class EczaneGiris : System.Web.UI.Page
    {
       string kullanici_adi = "";
       public static bool kullanici_yetkili_mi = false;
       SqlConnection Hastane = new SqlConnection("Data Source=HOGKNZPC\\HASBILSIS520673;Initial Catalog=Hastane Database;Persist Security Info=True;User ID=sa;Password=123");

        private int giris()
        {
            Hastane.Open();
            SqlCommand Eczane_Kullanici_Adi = new SqlCommand("Select Eczane_Kullanici_Adi from Eczane_Tanim", Hastane);
            SqlDataReader Kullanici_Adi_Oku = Eczane_Kullanici_Adi.ExecuteReader();
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
            SqlCommand Eczane_Sifre = new SqlCommand("Select Eczane_Sifre from Eczane_Tanim", Hastane);
            SqlDataReader Sifre_Oku = Eczane_Sifre.ExecuteReader();
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

        protected void login_Click(object sender, EventArgs e)
        {
            if (giris() == 1)
            {
                //"Hoşgeldiniz."
                kullanici_yetkili_mi = true;
                giriskontrol.Text = "Hoşgeldiniz.";
                Response.Redirect("Eczane.aspx");

            }
            else if (giris() == 2)
            {
                //"Kullanıcı Adı ile Şifre Eşleşmiyor."
                giriskontrol.Text = "Kullanıcı Adı ile Şifre Eşleşmiyor.";
            }
            else if (giris() == 3)
            {
                //"Kullanıcı Adı Bulunamadı."
                giriskontrol.Text = "Kullanıcı Adı Bulunamadı.";
            }
            else if (giris() == 4)
            {
                //"Okuma Hatası."
                giriskontrol.Text = "Okuma Hatası.";
            }
        }
    }
}