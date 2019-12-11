using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Doktor_Modulu
{
    public partial class Doktor : System.Web.UI.Page
    {
        int i=0;
        SqlConnection Hastane = new SqlConnection("Data Source=HOGKNZPC\\HASBILSIS520673;Initial Catalog=Hastane Database;Persist Security Info=True;User ID=sa;Password=123");
        bool yetkikontrolu = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            yetkikontrolu = DoktorGiris.kullanici_yetkili_mi;
            if (yetkikontrolu == false)
            {
                Response.Redirect("DoktorGiris.aspx");
            }
        }
        private void hastalarin_hepsini_cek()
        {
            Hastane.Open();
            SqlCommand Klinik_Tanimi = new SqlCommand("Select *From Randevular", Hastane);
            SqlDataReader oku = Klinik_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                ListBox_1.Items.Add(oku["Randevu_Id"].ToString());
                ListBox_2.Items.Add(oku["Hasta_Tc_Kimlik_No"].ToString());
                ListBox_3.Items.Add(oku["Klinik_Id"].ToString());
                ListBox_4.Items.Add(oku["Doktor_Id"].ToString());
                ListBox_5.Items.Add(oku["Randevu_Gun"].ToString());
                ListBox_6.Items.Add(oku["Randevu_Ay"].ToString());
                ListBox_7.Items.Add(oku["Randevu_Yil"].ToString());
                ListBox_8.Items.Add(oku["Randevu_Saat"].ToString());
                ListBox_9.Items.Add(oku["Randevu_Dakika"].ToString());
            }
            Hastane.Close();
        }

        protected void btn_tarih_sorgu_Click(object sender, EventArgs e)
        {
            ListBox_Hasta_Liste.Items.Clear();
            i = 0;
            for (i=0;i<ListBox_1.Items.Count;i++)
            {
                if (ListBox_5.Items[i].ToString() == DropDownList_Gun.SelectedItem.Value)
                {
                    if (ListBox_6.Items[i].ToString() == DropDownList_Ay.SelectedItem.Value)
                    {
                        if (ListBox_7.Items[i].ToString() == DropDownList_Yil.SelectedItem.Value)
                        {
                            Hastane.Open();
                            SqlCommand tc_nosu_belli_hasta = new SqlCommand("SELECT * FROM Hasta_Tanim WHERE Hasta_Tc_Kimlik_No="+ListBox_2.Items[i].ToString()+"",Hastane);
                            SqlDataReader oku = tc_nosu_belli_hasta.ExecuteReader();
                            while (oku.Read())
                            {
                                //ListBox_Hasta_Liste.Items.Add(oku["Hasta_Ad"].ToString());
                                ListBox_10.Items.Add(oku["Hasta_Tc_Kimlik_No"].ToString());
                                ListBox_Hasta_Liste.Items.Add( oku["Hasta_Ad"].ToString() +" "+ oku["Hasta_Soyad"].ToString());
                            }
                            Hastane.Close();
                        }
                        //else
                        {

                        }
                    }
                    //else
                    {

                    }
                }
                //else
                {

                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox_Hasta_Liste.Items.Clear();
        }

        protected void btn_veri_cek_Click(object sender, EventArgs e)
        {
            hastalarin_hepsini_cek();
            btn_veri_cek.Visible = false;
            btn_tarih_sorgu.Visible = true;
            ListBox_Hasta_Liste.Visible = true;
            CheckBoxList_tahlil.Visible = true;
            CheckBoxList_hastalik.Visible = true;
            DropDownList_ilac.Visible = true;
            Label11.Visible = true;
            tb_adet.Visible = true;
            btn_recete_yaz.Visible = true;
        }

        protected void ListBox_Hasta_Liste_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}