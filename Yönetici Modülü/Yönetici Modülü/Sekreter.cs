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

    public partial class Sekreter : Form
    {
        bool oto_guncelleme = false;
        string sorgulanacak_hasta_tc_no = "BOS";
        string doktorID = "BOS";
        string klinikID = "BOS";
        int id_randevu = 0;

        string kullanici_adi;
        SqlConnection Hastane = new SqlConnection("Data Source=HOGKNZPC\\HASBILSIS520673;Initial Catalog=Hastane Database;Persist Security Info=True;User ID=sa;Password=123");
        public Sekreter(string girisyapan)
        {
            kullanici_adi = girisyapan;
            InitializeComponent();
        }

        private void Sekreter_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 BasaDön = new Form1();
            BasaDön.Show();
        }

        private void Sekreter_Load(object sender, EventArgs e)
        {
            lb_karsilama.Text = "İyi Günler " + kullanici_adi + " :)";

            //Klinik Doldurma
            combo_klinikler.Items.Clear();
            Hastane.Open();
            SqlCommand Doktor_Tanimi = new SqlCommand("Select *From Klinik_Tanim", Hastane);
            SqlDataReader oku = Doktor_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                List<string> tanimli_klinikler_listesi = new List<string>();
                tanimli_klinikler_listesi.Add(oku["Klinik_Ad"].ToString());
                for (int i = 0; i<tanimli_klinikler_listesi.Count; i++)
                {
                    combo_klinikler.Items.Add(tanimli_klinikler_listesi[i]);
                }
            }
            Hastane.Close();
        }

        private void btn_hasta_sorgula_Click(object sender, EventArgs e)
        {
            sorgulanacak_hasta_tc_no = tb_genel_tc_no.Text;

            Hastane.Open();
            SqlCommand Hasta_Adi_Soyadi_Cek = new SqlCommand("Select *From Hasta_Tanim where Hasta_Tc_Kimlik_No='" + sorgulanacak_hasta_tc_no + "'",Hastane);
            SqlDataReader cek = Hasta_Adi_Soyadi_Cek.ExecuteReader();

            while(cek.Read())
            {
                tb_hasta_ad.Text = cek["Hasta_Ad"].ToString();
                tb_hasta_soyad.Text = cek["Hasta_Soyad"].ToString();
            }
            Hastane.Close();

            yenile_randevu_tanim_HASTA();
        }
        
        private void yenile_randevu_tanim ()
        {

            List<string> Klinik_Id = new List<string>();
            List<string> Doktor_Id = new List<string>();

            List<string> _Randevu_Id = new List<string>();
            List<string> _Hasta_Tc_Kimlik_No = new List<string>();
            List<string> _Randevu_Yil = new List<string>();
            List<string> _Randevu_Ay = new List<string>();
            List<string> _Randevu_Gun = new List<string>();
            List<string> _Randevu_Saat = new List<string>();
            List<string> _Randevu_Dakika = new List<string>();
            List<string> _Klinik_Ad = new List<string>();
            List<string> _Doktor_Ad_Soyad = new List<string>();


            listView_randevu_tanim.Items.Clear();

            Hastane.Open();
            SqlCommand Randevu_Tanimi = new SqlCommand("Select *From Randevular", Hastane);
            SqlDataReader oku = Randevu_Tanimi.ExecuteReader();

            while (oku.Read())
            {

                _Randevu_Id.Add(oku["Randevu_Id"].ToString());
                _Hasta_Tc_Kimlik_No.Add(oku["Hasta_Tc_Kimlik_No"].ToString());
                _Randevu_Yil.Add(oku["Randevu_Yil"].ToString());
                _Randevu_Ay.Add(oku["Randevu_Ay"].ToString());
                _Randevu_Gun.Add(oku["Randevu_Gun"].ToString());
                _Randevu_Saat.Add(oku["Randevu_Saat"].ToString());
                _Randevu_Dakika.Add(oku["Randevu_Dakika"].ToString());
                Klinik_Id.Add(oku["Klinik_Id"].ToString());
                Doktor_Id.Add(oku["Doktor_Id"].ToString());
            }
            Hastane.Close();

            //Klinik Id Yerine Klinik Adı Yazması için
            for (int sayac_A=0; sayac_A<Klinik_Id.Count ; sayac_A++)
            {
                Hastane.Open();
                SqlCommand Randevu_Tanimi_Klinik_Doldur = new SqlCommand("Select *From Klinik_Tanim where Klinik_Id='" + Klinik_Id[sayac_A] + "'",Hastane);
                SqlDataReader ıd_klinik_oku = Randevu_Tanimi_Klinik_Doldur.ExecuteReader();

                while (ıd_klinik_oku.Read())
                {
                    _Klinik_Ad.Add(ıd_klinik_oku["Klinik_Ad"].ToString());
                }
                Hastane.Close();
            }

            //Doktor Id Yerine Doktor Adı&Soyadı Yazması için
            for (int sayac_B=0; sayac_B<Doktor_Id.Count; sayac_B++)
            {
                Hastane.Open();
                SqlCommand Randevu_Tanimi_Doktor_Doldur = new SqlCommand("Select *From Doktor_Tanim where Doktor_Id='" + Doktor_Id[sayac_B] + "'",Hastane);
                SqlDataReader ıd_doktor_oku = Randevu_Tanimi_Doktor_Doldur.ExecuteReader();

                while (ıd_doktor_oku.Read())
                {
                    _Doktor_Ad_Soyad.Add(ıd_doktor_oku["Doktor_Ad_Soyad"].ToString());
                }
                Hastane.Close();
            }
            for (int sayac_C=0; sayac_C<_Randevu_Id.Count; sayac_C++)
            {
                ListViewItem listten_listview = new ListViewItem();
                listten_listview.Text = _Randevu_Id[sayac_C];
                listten_listview.SubItems.Add(_Hasta_Tc_Kimlik_No[sayac_C]);
                listten_listview.SubItems.Add(_Randevu_Yil[sayac_C]);
                listten_listview.SubItems.Add(_Randevu_Ay[sayac_C]);
                listten_listview.SubItems.Add(_Randevu_Gun[sayac_C]);
                listten_listview.SubItems.Add(_Randevu_Saat[sayac_C]);
                listten_listview.SubItems.Add(_Randevu_Dakika[sayac_C]);
                listten_listview.SubItems.Add(_Klinik_Ad[sayac_C]);
                listten_listview.SubItems.Add(_Doktor_Ad_Soyad[sayac_C]);
                listView_randevu_tanim.Items.Add(listten_listview);

            }
        }

        private void yenile_randevu_tanim_HASTA ()
        {
            if (sorgulanacak_hasta_tc_no == "BOS")
            {

            }
            else
            {
                /*
                listView_randevu_tanim_HASTA.Items.Clear();
                Hastane.Open();
                SqlCommand Randevu_Tanimi_HASTA = new SqlCommand("Select *From Randevular where Hasta_Tc_Kimlik_No='" + sorgulanacak_hasta_tc_no + "'", Hastane);
                SqlDataReader oku = Randevu_Tanimi_HASTA.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ListeNesnesi = new ListViewItem();
                    ListeNesnesi.Text = oku["Randevu_Id"].ToString();
                    ListeNesnesi.SubItems.Add(oku["Klinik_Id"].ToString());
                    ListeNesnesi.SubItems.Add(oku["Doktor_Id"].ToString());
                    ListeNesnesi.SubItems.Add(oku["Randevu_Yil"].ToString());
                    ListeNesnesi.SubItems.Add(oku["Randevu_Ay"].ToString());
                    ListeNesnesi.SubItems.Add(oku["Randevu_Gun"].ToString());
                    ListeNesnesi.SubItems.Add(oku["Randevu_Saat"].ToString());
                    ListeNesnesi.SubItems.Add(oku["Randevu_Dakika"].ToString());
                    listView_randevu_tanim_HASTA.Items.Add(ListeNesnesi);
                }
                Hastane.Close();
                */

                List<string> Klinik_Id = new List<string>();
                List<string> Doktor_Id = new List<string>();

                List<string> _Randevu_Id = new List<string>();
                List<string> _Klinik_Ad = new List<string>();
                List<string> _Doktor_Ad_Soyad = new List<string>();
                List<string> _Randevu_Yil = new List<string>();
                List<string> _Randevu_Ay = new List<string>();
                List<string> _Randevu_Gun = new List<string>();
                List<string> _Randevu_Saat = new List<string>();
                List<string> _Randevu_Dakika = new List<string>();


                listView_randevu_tanim_HASTA.Items.Clear();

                Hastane.Open();
                SqlCommand Randevu_Tanimi_Hasta = new SqlCommand("Select *From Randevular where Hasta_Tc_Kimlik_No='" + sorgulanacak_hasta_tc_no + "'", Hastane);
                SqlDataReader oku = Randevu_Tanimi_Hasta.ExecuteReader();

                while (oku.Read())
                {
                    _Randevu_Id.Add(oku["Randevu_Id"].ToString());
                    Klinik_Id.Add(oku["Klinik_Id"].ToString());
                    Doktor_Id.Add(oku["Doktor_Id"].ToString());
                    _Randevu_Yil.Add(oku["Randevu_Yil"].ToString());
                    _Randevu_Ay.Add(oku["Randevu_Ay"].ToString());
                    _Randevu_Gun.Add(oku["Randevu_Gun"].ToString());
                    _Randevu_Saat.Add(oku["Randevu_Saat"].ToString());
                    _Randevu_Dakika.Add(oku["Randevu_Dakika"].ToString());
                }
                Hastane.Close();

                //Klinik Id Yerine Klinik Adı Yazması için
                for (int sayac_A = 0; sayac_A < Klinik_Id.Count; sayac_A++)
                {
                    Hastane.Open();
                    SqlCommand Randevu_Tanimi_Klinik_Doldur = new SqlCommand("Select *From Klinik_Tanim where Klinik_Id='" + Klinik_Id[sayac_A] + "'", Hastane);
                    SqlDataReader ıd_klinik_oku = Randevu_Tanimi_Klinik_Doldur.ExecuteReader();

                    while (ıd_klinik_oku.Read())
                    {
                        _Klinik_Ad.Add(ıd_klinik_oku["Klinik_Ad"].ToString());
                    }
                    Hastane.Close();
                }

                //Doktor Id Yerine Doktor Adı&Soyadı Yazması için
                for (int sayac_B = 0; sayac_B < Doktor_Id.Count; sayac_B++)
                {
                    Hastane.Open();
                    SqlCommand Randevu_Tanimi_Doktor_Doldur = new SqlCommand("Select *From Doktor_Tanim where Doktor_Id='" + Doktor_Id[sayac_B] + "'", Hastane);
                    SqlDataReader ıd_doktor_oku = Randevu_Tanimi_Doktor_Doldur.ExecuteReader();

                    while (ıd_doktor_oku.Read())
                    {
                        _Doktor_Ad_Soyad.Add(ıd_doktor_oku["Doktor_Ad_Soyad"].ToString());
                    }
                    Hastane.Close();
                }
                //Tabloya Doğru Şeklide Yazdırma..
                for (int sayac_C = 0; sayac_C < _Randevu_Id.Count; sayac_C++)
                {
                    ListViewItem listten_listview = new ListViewItem();
                    listten_listview.Text = _Randevu_Id[sayac_C];
                    listten_listview.SubItems.Add(_Klinik_Ad[sayac_C]);
                    listten_listview.SubItems.Add(_Doktor_Ad_Soyad[sayac_C]);
                    listten_listview.SubItems.Add(_Randevu_Yil[sayac_C]);
                    listten_listview.SubItems.Add(_Randevu_Ay[sayac_C]);
                    listten_listview.SubItems.Add(_Randevu_Gun[sayac_C]);
                    listten_listview.SubItems.Add(_Randevu_Saat[sayac_C]);
                    listten_listview.SubItems.Add(_Randevu_Dakika[sayac_C]);
                    listView_randevu_tanim_HASTA.Items.Add(listten_listview);
                }
            }
        }

        private void yenile_randevu_tanim_DOKTOR()
        {

            if (combo_doktorlar.Text == "Seciniz")
            {

            }
            else
            {
                //Doktor ID Bulma
                Hastane.Open();
                SqlCommand Doktor_isminden_ID_bul = new SqlCommand("Select *From Doktor_Tanim Where Doktor_Ad_Soyad='" + combo_doktorlar.SelectedItem.ToString() + "'",Hastane);
                SqlDataReader tek_satira_yaz = Doktor_isminden_ID_bul.ExecuteReader();

                while (tek_satira_yaz.Read())
                {
                    doktorID = tek_satira_yaz["Doktor_Id"].ToString();
                }
                Hastane.Close();
                
                if (doktorID == "BOS")
                {

                }
                else
                {
                    listView_randevu_tanim_DOKTOR.Items.Clear();
                    Hastane.Open();
                    SqlCommand Randevu_Tanimi_DOKTOR = new SqlCommand("Select *From Randevular where Doktor_Id='" + doktorID + "'", Hastane);
                    SqlDataReader oku = Randevu_Tanimi_DOKTOR.ExecuteReader();

                    while (oku.Read())
                    {
                        ListViewItem ListeNesnesi = new ListViewItem();
                        ListeNesnesi.Text = oku["Randevu_Id"].ToString();
                        ListeNesnesi.SubItems.Add(oku["Hasta_Tc_Kimlik_No"].ToString());
                        ListeNesnesi.SubItems.Add(oku["Randevu_Yil"].ToString());
                        ListeNesnesi.SubItems.Add(oku["Randevu_Ay"].ToString());
                        ListeNesnesi.SubItems.Add(oku["Randevu_Gun"].ToString());
                        ListeNesnesi.SubItems.Add(oku["Randevu_Saat"].ToString());
                        ListeNesnesi.SubItems.Add(oku["Randevu_Dakika"].ToString());
                        listView_randevu_tanim_DOKTOR.Items.Add(ListeNesnesi);
                    }
                    Hastane.Close();
                }
            }
        }

        private void yenile_hasta_tanim ()
        {
            listView_hasta_tanim.Items.Clear();
            Hastane.Open();
            SqlCommand Hasta_Tanimi = new SqlCommand("Select *From Hasta_Tanim", Hastane);
            SqlDataReader oku = Hasta_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ListeNesnesi = new ListViewItem();
                ListeNesnesi.Text = oku["Hasta_Tc_Kimlik_No"].ToString();
                ListeNesnesi.SubItems.Add(oku["Hasta_Ad"].ToString());
                ListeNesnesi.SubItems.Add(oku["Hasta_Soyad"].ToString());
                listView_hasta_tanim.Items.Add(ListeNesnesi);
            }
            Hastane.Close();
        }

        private void btn_Tabloyu_Yenile_Click(object sender, EventArgs e)
        {
            yenile_randevu_tanim();
            yenile_randevu_tanim_HASTA();
            yenile_randevu_tanim_DOKTOR();
            yenile_hasta_tanim();
        }

        private void combo_klinikler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Klinik ID bulma
            Hastane.Open();
            SqlCommand Klinik_isminden_ID_bul = new SqlCommand("Select *From Klinik_Tanim Where Klinik_Ad='" + combo_klinikler.SelectedItem.ToString() + "'", Hastane);
            SqlDataReader tek_satira_yaz = Klinik_isminden_ID_bul.ExecuteReader();

            while (tek_satira_yaz.Read())
            {
                klinikID = tek_satira_yaz["Klinik_Id"].ToString();
            }
            Hastane.Close();

            //Doktor Doldurma
            combo_doktorlar.Items.Clear();
            combo_doktorlar.ResetText();
            Hastane.Open();
            SqlCommand Doktor_Tanimi = new SqlCommand("Select *From Doktor_Tanim where Klinik_Id='" + klinikID + "'", Hastane);
            SqlDataReader oku = Doktor_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                List<string> tanimli_doktorlar_listesi = new List<string>();
                tanimli_doktorlar_listesi.Add(oku["Doktor_Ad_Soyad"].ToString());

                for (int i = 0; i < tanimli_doktorlar_listesi.Count; i++)
                {
                    combo_doktorlar.Items.Add(tanimli_doktorlar_listesi[i]);
                }
            }
            Hastane.Close();

            tb_KLİNİK.Text = klinikID;
        }

        private void combo_doktorlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            yenile_randevu_tanim_DOKTOR();
            tb_DOKTOR.Text = doktorID;
        }

        private void btn_oto_guncelleme_Click(object sender, EventArgs e)
        {
            if (oto_guncelleme == false)
            {
                tmr_oto_yenile.Enabled = true;
                btn_oto_guncelleme.Text = "Otomatik Yenileme (AÇIK)";
                btn_oto_guncelleme.BackColor = Color.Green;
                oto_guncelleme = true;
            }
            else
            {
                tmr_oto_yenile.Enabled = false;
                btn_oto_guncelleme.Text = "Otomatik Yenileme (KAPALI)";
                btn_oto_guncelleme.BackColor = Color.Red;
                oto_guncelleme = false;
            }
        }

        private void tmr_oto_yenile_Tick(object sender, EventArgs e)
        {
            yenile_randevu_tanim();
            yenile_randevu_tanim_HASTA();
            yenile_randevu_tanim_DOKTOR();
            yenile_hasta_tanim();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            string tc_no = tb_genel_tc_no.Text;
            string klinikler=klinikID;
            string doktorlar=doktorID;
            int tarih_yıl  = Convert.ToInt32(comboBox_yıl.SelectedItem);
            int tarih_ay = Convert.ToInt32(comboBox_ay.SelectedItem);
            int tarih_gun = Convert.ToInt32(comboBox_gun.SelectedItem);
            int tarih_saat = Convert.ToInt32(combo_Saat.SelectedItem);
            int tarih_dakika = Convert.ToInt32(combo_Dakika.SelectedItem);

            string kontrol_tc = "BOS";
            string kontrol_tc2 = "BOS";

            //Aynı Saate Aynı Doktordan Randevu var mı kontrol
            Hastane.Open();
            SqlCommand Saat_Kontrol = new SqlCommand("Select *From Randevular where Klinik_Id='" + klinikler + "' and Doktor_Id='" + doktorlar + "' and Randevu_Gun='" + tarih_gun + "' and Randevu_Ay='" + tarih_ay + "' and Randevu_Yil='" + tarih_yıl + "' and Randevu_Saat='" + tarih_saat + "' and Randevu_Dakika='" + tarih_dakika + "'", Hastane);
            SqlDataReader oku = Saat_Kontrol.ExecuteReader();

            while (oku.Read())
            {
                kontrol_tc = oku["Hasta_Tc_Kimlik_No"].ToString();
            }
            Hastane.Close();
            

            if (kontrol_tc=="BOS")
            {

                Hastane.Open();
                SqlCommand Tc_Kontrol = new SqlCommand("Select *From Hasta_Tanim where Hasta_Tc_Kimlik_No='" + tb_genel_tc_no.Text + "'",Hastane);
                SqlDataReader tcoku = Tc_Kontrol.ExecuteReader();

                while (tcoku.Read())
                {
                    kontrol_tc2 = tcoku["Hasta_Tc_Kimlik_No"].ToString();
                }
                Hastane.Close();

                if (kontrol_tc2 =="BOS")
                {
                    MessageBox.Show("TC NO Kayıtlı degil.");
                }
                else
                {
                    Hastane.Open();
                    SqlCommand Randevu_Ekle = new SqlCommand("Insert Into Randevular (Hasta_Tc_Kimlik_No,Klinik_Id,Doktor_Id,Randevu_Gun,Randevu_Ay,Randevu_Yil,Randevu_Saat,Randevu_Dakika) Values ('" + tc_no + "','" + klinikler + "','" + doktorlar + "','" + tarih_gun + "','" + tarih_ay + "','" + tarih_yıl + "','" + tarih_saat + "','" + tarih_dakika + "')", Hastane);
                    Randevu_Ekle.ExecuteNonQuery();
                    Hastane.Close();

                    yenile_randevu_tanim();
                    yenile_randevu_tanim_HASTA();
                    yenile_randevu_tanim_DOKTOR();
                    yenile_hasta_tanim();
                }
//
//
//TC NO KAYITLI MI DİYE BAKACAK... (YAPILMADI)
//
//

            }
            else
            {
                MessageBox.Show("Seçilen tarihte seçilen doktorun başka bir randavusu vardır. \n Lütfen başka bir doktor veya başka bir tarih seçiniz.");
            }
        }

        private void btn_Düzenle_Click(object sender, EventArgs e)
        {
            string tc_no = sorgulanacak_hasta_tc_no;
            string klinikler_a = klinikID;
            string doktorlar_a = doktorID;
            int tarih_yıl = Convert.ToInt32(comboBox_yıl.SelectedItem);
            int tarih_ay = Convert.ToInt32(comboBox_ay.SelectedItem);
            int tarih_gun = Convert.ToInt32(comboBox_gun.SelectedItem);
            int tarih_saat = Convert.ToInt32(combo_Saat.SelectedItem);
            int tarih_dakika = Convert.ToInt32(combo_Dakika.SelectedItem);

            string kontrol_tc = "BOS";

            //Aynı Saate Aynı Doktordan Randevu var mı kontrol
            Hastane.Open();
            SqlCommand Saat_Kontrol = new SqlCommand("Select *From Randevular where Klinik_Id='" + Convert.ToInt32(klinikler_a) + "' and Doktor_Id='" + Convert.ToInt32(doktorlar_a) + "' and Randevu_Gun='" + tarih_gun + "' and Randevu_Ay='" + tarih_ay + "' and Randevu_Yil='" + tarih_yıl + "' and Randevu_Saat='" + tarih_saat + "' and Randevu_Dakika='" + tarih_dakika + "'", Hastane);
            SqlDataReader oku = Saat_Kontrol.ExecuteReader();

            while (oku.Read())
            {
                kontrol_tc = oku["Hasta_Tc_Kimlik_No"].ToString();
            }
            Hastane.Close();


            if (kontrol_tc == "BOS")
            {
                Hastane.Open();
                SqlCommand düzenle = new SqlCommand("Update Randevular set Doktor_Id='" + doktorlar_a.ToString() + "',Randevu_Gun='" + tarih_gun.ToString() + "',Randevu_Ay='" + tarih_ay.ToString() + "',Randevu_Yil='" + tarih_yıl.ToString() + "',Randevu_Saat='" + tarih_saat.ToString() + "',Randevu_Dakika='" + tarih_dakika.ToString() + "'where Randevu_Id=" + id_randevu + "", Hastane);
                //
                düzenle.ExecuteNonQuery();
                Hastane.Close();

                yenile_randevu_tanim();
                yenile_randevu_tanim_HASTA();
                yenile_randevu_tanim_DOKTOR();
                yenile_hasta_tanim();
            }
            else
            {
                MessageBox.Show("Seçilen tarihte seçilen doktorun başka bir randavusu vardır. \n Lütfen başka bir doktor veya başka bir tarih seçiniz.");
            }
        }

        private void listView_randevu_tanim_HASTA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tb_genel_tc_no.Text = sorgulanacak_hasta_tc_no;
            id_randevu = int.Parse(listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[0].Text);
            combo_klinikler.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[1].Text;
            combo_doktorlar.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[2].Text;
            comboBox_yıl.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[3].Text;
            comboBox_ay.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[4].Text;
            comboBox_gun.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[5].Text;
            combo_Saat.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[6].Text;
            combo_Dakika.SelectedItem = listView_randevu_tanim_HASTA.SelectedItems[0].SubItems[7].Text;
        }
    }
}
