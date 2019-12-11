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
    public partial class Yonetici : Form
    {
        SqlConnection Hastane = new SqlConnection("Data Source=HOGKNZPC\\HASBILSIS520673;Initial Catalog=Hastane Database;Persist Security Info=True;User ID=sa;Password=123");
        string kullanici_adi;
        bool klinik_oto_guncelleme = false, doktor_oto_guncelleme = false, ilac_oto_guncelleme = false, hastalik_oto_guncelleme = false, tahlil_oto_guncelleme = false;
        public Yonetici(string girisyapan)
        {
            kullanici_adi = girisyapan;
            InitializeComponent();
        }

        private void Yonetici_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 BasaDön = new Form1();
            BasaDön.Show();
        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
            lb_karsilama.Text = "İyi Günler " + kullanici_adi + " :)";
        }

        private void verileri_göster_klinik()
        {
            listView_Klinik_Tanimlari.Items.Clear();
            Hastane.Open();
            SqlCommand Klinik_Tanimi = new SqlCommand("Select *From Klinik_Tanim",Hastane);
            SqlDataReader oku = Klinik_Tanimi.ExecuteReader();

            while(oku.Read())
            {
                ListViewItem ListeNesnesi = new ListViewItem();
                ListeNesnesi.Text = oku["Klinik_Id"].ToString();
                ListeNesnesi.SubItems.Add(oku["Klinik_Ad"].ToString());
                listView_Klinik_Tanimlari.Items.Add(ListeNesnesi);
            }
            Hastane.Close();
        }

        private void btn_Tabloyu_Yenile_Click(object sender, EventArgs e)
        {
            verileri_göster_klinik();
        }

        private void tmr_klinik_Otomatik_Tablo_Guncelleyici_Tick(object sender, EventArgs e)
        {
            verileri_göster_klinik();
        }

        private void btn_klinik_oto_guncelleme_Click(object sender, EventArgs e)
        {
            if (klinik_oto_guncelleme == false)
            {
                tmr_klinik_Otomatik_Tablo_Guncelleyici.Enabled = true;
                btn_klinik_oto_guncelleme.Text = "Otomatik Yenileme (AÇIK)";
                btn_klinik_oto_guncelleme.BackColor = Color.Green;
                klinik_oto_guncelleme = true;
            }
            else
            {
                tmr_klinik_Otomatik_Tablo_Guncelleyici.Enabled = false;
                btn_klinik_oto_guncelleme.Text = "Otomatik Yenileme (KAPALI)";
                btn_klinik_oto_guncelleme.BackColor = Color.Red;
                klinik_oto_guncelleme = false;
            }
        }

        private void tmr_doktor_Otomatik_Tablo_Guncelleyici_Tick(object sender, EventArgs e)
        {
            verileri_göster_doktor();
        }

        private void btn_doktor_Ekle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand Doktor_Ekle = new SqlCommand("Insert Into Doktor_Tanim (Doktor_Ad_Soyad,Klinik_Id,Doktor_Kullanici_Adi,Doktor_Sifre) Values ('" + tb_doktor_Doktor_Adi_Soyadi.Text.ToString() + "','" + tb_doktor_Klinik_Id.Text.ToString() + "','" + tb_doktor_Kullanıcı_Adi.Text.ToString() + "','" + tb_doktor_Sifre.Text.ToString() + "')", Hastane);
            Doktor_Ekle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_doktor();
        }

        private void btn_klinik_Ekle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand Klinik_Ekle = new SqlCommand("Insert Into Klinik_Tanim (Klinik_Ad) Values ('"+tb_klinik_Klinik_Adi.Text.ToString()+"')",Hastane);
            Klinik_Ekle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_klinik();
        }

        private void btn_ilac_Tabloyu_Yenile_Click(object sender, EventArgs e)
        {
            verileri_göster_ilac();
        }

        private void btn_ilac_oto_guncelleme_Click(object sender, EventArgs e)
        {
            if (ilac_oto_guncelleme == false)
            {
                tmr_ilac_Otomatik_Tablo_Guncelleyici.Enabled = true;
                btn_ilac_oto_guncelleme.Text = "Otomatik Yenileme (AÇIK)";
                btn_ilac_oto_guncelleme.BackColor = Color.Green;
                ilac_oto_guncelleme = true;
            }
            else
            {
                tmr_ilac_Otomatik_Tablo_Guncelleyici.Enabled = false;
                btn_ilac_oto_guncelleme.Text = "Otomatik Yenileme (KAPALI)";
                btn_ilac_oto_guncelleme.BackColor = Color.Red;
                ilac_oto_guncelleme = false;
            }
        }

        private void tmr_ilac_Otomatik_Tablo_Guncelleyici_Tick(object sender, EventArgs e)
        {
            verileri_göster_ilac();
        }

        private void btn_hastalik_Tabloyu_Yenile_Click(object sender, EventArgs e)
        {
            verileri_göster_hastalik();
        }

        private void btn_hastalik_oto_guncelleme_Click(object sender, EventArgs e)
        {
            if (hastalik_oto_guncelleme == false)
            {
                tmr_hastalik_Otomatik_Tablo_Guncelleyici.Enabled = true;
                btn_hastalik_oto_guncelleme.Text = "Otomatik Yenileme (AÇIK)";
                btn_hastalik_oto_guncelleme.BackColor = Color.Green;
                hastalik_oto_guncelleme = true;
            }
            else
            {
                tmr_hastalik_Otomatik_Tablo_Guncelleyici.Enabled = false;
                btn_hastalik_oto_guncelleme.Text = "Otomatik Yenileme (KAPALI)";
                btn_hastalik_oto_guncelleme.BackColor = Color.Red;
                hastalik_oto_guncelleme = false;
            }
        }

        private void btn_hastalik_Ekle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand Hastalik_Ekle = new SqlCommand("Insert Into Hastalik_Tanim (Hastalik_Adi) Values ('" + tb_hastalik_Hastalik_Adi.Text.ToString() + "')", Hastane);
            Hastalik_Ekle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_hastalik();
        }

        private void btn_ilac_Ekle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand Ilac_Ekle = new SqlCommand("Insert Into Ilac_Tanim (Ilac_Adi,Hastalik_Id,Ilac_Birim_Fiyat) Values ('" + tb_ilac_Ilac_Adı.Text.ToString() + "','" + tb_ilac_Hastalık_Id.Text.ToString() + "','" + tb_ilac_Birim_Fiyat.Text.ToString() + "')", Hastane);
            Ilac_Ekle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_ilac();
        }

        private void verileri_göster_doktor()
        {
            listView_Doktor_Tanimlari.Items.Clear();
            Hastane.Open();
            SqlCommand Doktor_Tanimi = new SqlCommand("Select *From Doktor_Tanim", Hastane);
            SqlDataReader oku = Doktor_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ListeNesnesi = new ListViewItem();
                ListeNesnesi.Text = oku["Doktor_Id"].ToString();
                ListeNesnesi.SubItems.Add(oku["Doktor_Ad_Soyad"].ToString());
                ListeNesnesi.SubItems.Add(oku["Klinik_Id"].ToString());
                ListeNesnesi.SubItems.Add(oku["Doktor_Kullanici_Adi"].ToString());
                ListeNesnesi.SubItems.Add(oku["Doktor_Sifre"].ToString());
                listView_Doktor_Tanimlari.Items.Add(ListeNesnesi);
            }
            Hastane.Close();
        }

        private void tmr_hastalik_Otomatik_Tablo_Guncelleyici_Tick(object sender, EventArgs e)
        {
            verileri_göster_hastalik();
        }

        private void btn_Doktor_Tabloyu_Yenile_Click(object sender, EventArgs e)
        {
            verileri_göster_doktor();
        }

        private void btn_tahlil_Tabloyu_Yenile_Click(object sender, EventArgs e)
        {
            verileri_göster_tahlil();
        }

        private void btn_tahlil_oto_guncelleme_Click(object sender, EventArgs e)
        {
            if (tahlil_oto_guncelleme == false)
            {
                tmr_tahlil_Otomatik_Tablo_Guncelleyici.Enabled = true;
                btn_tahlil_oto_guncelleme.Text = "Otomatik Yenileme (AÇIK)";
                btn_tahlil_oto_guncelleme.BackColor = Color.Green;
                tahlil_oto_guncelleme = true;
            }
            else
            {
                tmr_tahlil_Otomatik_Tablo_Guncelleyici.Enabled = false;
                btn_tahlil_oto_guncelleme.Text = "Otomatik Yenileme (KAPALI)";
                btn_tahlil_oto_guncelleme.BackColor = Color.Red;
                tahlil_oto_guncelleme = false;
            }
        }

        private void tmr_tahlil_Otomatik_Tablo_Guncelleyici_Tick(object sender, EventArgs e)
        {
            verileri_göster_tahlil();
        }

        private void btn_tahlil_Ekle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand Tahlil_Ekle = new SqlCommand("Insert Into Tahlil_Tanim (Tahlil_Adi) Values ('" + tb_tahlil_Tahlil_Adı.Text.ToString() + "')", Hastane);
            Tahlil_Ekle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_tahlil();
        }
        int id_klinik = 0;
        private void btn_klinik_Sil_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand klinik_bos_mu = new SqlCommand("Select* From Doktor_Tanim where Klinik_Id =(" + id_klinik + ")", Hastane);
            SqlDataReader oku = klinik_bos_mu.ExecuteReader();
            if (!(oku.Read()))
            {
                Hastane.Close();

                Hastane.Open();
                SqlCommand klinik_sil = new SqlCommand("Delete From Klinik_Tanim where Klinik_Id =(" + id_klinik + ")", Hastane);
                klinik_sil.ExecuteNonQuery();
                Hastane.Close();
                verileri_göster_klinik();
            }
            else
            {
                Hastane.Close();

                MessageBox.Show("İçerisinde doktor bulunan bir klinik silinemez. \nLütfen kliniği silmek için önce içerisindeki doktorları siliniz.");
            }
        }

        private void listView_Klinik_Tanimlari_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id_klinik = int.Parse(listView_Klinik_Tanimlari.SelectedItems[0].SubItems[0].Text);
            tb_klinik_Klinik_Adi.Text = listView_Klinik_Tanimlari.SelectedItems[0].SubItems[1].Text;
        }

        private void listView_Doktor_Tanimlari_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id_doktor = int.Parse(listView_Doktor_Tanimlari.SelectedItems[0].SubItems[0].Text);
            tb_doktor_Doktor_Adi_Soyadi.Text = listView_Doktor_Tanimlari.SelectedItems[0].SubItems[1].Text;
            tb_doktor_Klinik_Id.Text = listView_Doktor_Tanimlari.SelectedItems[0].SubItems[2].Text;
            tb_doktor_Kullanıcı_Adi.Text = listView_Doktor_Tanimlari.SelectedItems[0].SubItems[3].Text;
            tb_doktor_Sifre.Text = listView_Doktor_Tanimlari.SelectedItems[0].SubItems[4].Text;
        }
        int id_doktor = 0;
        private void btn_doktor_Sil_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand doktor_sil = new SqlCommand("Delete From Doktor_Tanim where Doktor_Id =(" + id_doktor + ")", Hastane);
            doktor_sil.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_doktor();
        }
        int id_ilac = 0;
        private void btn_ilac_Sil_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand ilac_sil = new SqlCommand("Delete From Ilac_Tanim where Ilac_Id =(" + id_ilac + ")", Hastane);
            ilac_sil.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_ilac();
        }

        private void listView_Ilac_Tanimlari_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id_ilac = int.Parse(listView_Ilac_Tanimlari.SelectedItems[0].SubItems[0].Text);
            tb_ilac_Ilac_Adı.Text = listView_Ilac_Tanimlari.SelectedItems[0].SubItems[1].Text;
            tb_ilac_Hastalık_Id.Text = listView_Ilac_Tanimlari.SelectedItems[0].SubItems[2].Text;
            tb_ilac_Birim_Fiyat.Text = listView_Ilac_Tanimlari.SelectedItems[0].SubItems[3].Text;
        }
        int id_hastalik = 0;
        private void btn_hastalik_Sil_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand hastalik_bos_mu = new SqlCommand("Select* From Ilac_Tanim where Hastalik_Id =(" + id_hastalik + ")", Hastane);
            SqlDataReader oku = hastalik_bos_mu.ExecuteReader();
            if (!(oku.Read()))
            {
                Hastane.Close();

                Hastane.Open();
                SqlCommand hastalik_sil = new SqlCommand("Delete From Hastalik_Tanim where Hastalik_Id =(" + id_hastalik + ")", Hastane);
                hastalik_sil.ExecuteNonQuery();
                Hastane.Close();
                verileri_göster_hastalik();
            }
            else
            {
                Hastane.Close();

                MessageBox.Show("Herhangi bir ilaç tanımlanmış olan hastalık silinemez.\nLütfen hastalığı silmek için önce o hastalığa tanımlanmış olan ilaçları siliniz.");
            }
        }

        private void listView_Hastalik_Tanimlari_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id_hastalik = int.Parse(listView_Hastalik_Tanimlari.SelectedItems[0].SubItems[0].Text);
            tb_hastalik_Hastalik_Adi.Text = listView_Hastalik_Tanimlari.SelectedItems[0].SubItems[1].Text;
        }
        int id_tahlil = 0;
        private void btn_tahlil_Sil_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand tahlil_bos_mu = new SqlCommand("Select* From Hasta_Tahlil where Tahlil_Id =(" + id_tahlil + ")", Hastane);
            SqlDataReader oku = tahlil_bos_mu.ExecuteReader();
            if (!(oku.Read()))
            {
                Hastane.Close();

                Hastane.Open();
                SqlCommand tahlil_sil = new SqlCommand("Delete From Tahlil_Tanim where Tahlil_Id =(" + id_tahlil + ")", Hastane);
                tahlil_sil.ExecuteNonQuery();
                Hastane.Close();
                verileri_göster_tahlil();
            }
            else
            {
                Hastane.Close();

                MessageBox.Show("Silmek istediğiniz tahlil daha önceden sistemde kayıtlı hastalara yazılmıştır. \nTahlili silmek için önce tahlili yazan doktorun hastalardan tahlili silmesi gerekmektedir.");
            }
        }

        private void listView_Tahlil_Tanimlari_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id_tahlil = int.Parse(listView_Tahlil_Tanimlari.SelectedItems[0].SubItems[0].Text);
            tb_tahlil_Tahlil_Adı.Text = listView_Tahlil_Tanimlari.SelectedItems[0].SubItems[1].Text;
        }

        private void btn_klinik_Düzenle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand klinik_düzenle = new SqlCommand("Update Klinik_Tanim set Klinik_Ad='" + tb_klinik_Klinik_Adi.Text.ToString() + "'where Klinik_Id=" + id_klinik + "", Hastane);
            klinik_düzenle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_klinik();
        }

        private void btn_doktor_Düzenle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand klinik_var_mı = new SqlCommand("Select* From Klinik_Tanim where Klinik_Id =(" + tb_doktor_Klinik_Id.Text + ")", Hastane);
            SqlDataReader oku = klinik_var_mı.ExecuteReader();
            if (!(oku.Read()))
            {
                Hastane.Close();

                MessageBox.Show("Lütfen Geçerli Bir Klinik ID giriniz!");
            }
            else
            {
                Hastane.Close();

                Hastane.Open();
                SqlCommand doktor_düzenle = new SqlCommand("Update Doktor_Tanim set Doktor_Ad_Soyad='" + tb_doktor_Doktor_Adi_Soyadi.Text.ToString() + "',Klinik_Id='" + tb_doktor_Klinik_Id.Text.ToString() + "',Doktor_Kullanici_Adi='" + tb_doktor_Kullanıcı_Adi.Text.ToString() + "',Doktor_Sifre='" + tb_doktor_Sifre.Text.ToString() + "'where Doktor_Id=" + id_doktor + "", Hastane);
                doktor_düzenle.ExecuteNonQuery();
                Hastane.Close();
                verileri_göster_doktor();
            }
        }

        private void btn_ilac_Düzenle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand hastalik_var_mı = new SqlCommand("Select* From Hastalik_Tanim where Hastalik_Id =(" + tb_ilac_Hastalık_Id.Text + ")", Hastane);
            SqlDataReader oku = hastalik_var_mı.ExecuteReader();
            if (!(oku.Read()))
            {
                Hastane.Close();

                MessageBox.Show("Lütfen Geçerli Bir Hastalık ID giriniz!");
            }
            else
            {
                Hastane.Close();

                Hastane.Open();
                SqlCommand ilac_düzenle = new SqlCommand("Update Ilac_Tanim set Ilac_Adi='" + tb_ilac_Ilac_Adı.Text.ToString() + "',Hastalik_Id='" + tb_ilac_Hastalık_Id.Text.ToString() + "',Ilac_Birim_Fiyat='" + tb_ilac_Birim_Fiyat.Text.ToString() + "'where Ilac_Id=" + id_ilac + "", Hastane);
                ilac_düzenle.ExecuteNonQuery();
                Hastane.Close();
                verileri_göster_ilac();
            }
        }

        private void btn_hastalik_Düzenle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand hastalik_düzenle = new SqlCommand("Update Hastalik_Tanim set Hastalik_Adi='" + tb_hastalik_Hastalik_Adi.Text.ToString() + "'where Hastalik_Id=" + id_hastalik + "", Hastane);
            hastalik_düzenle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_tahlil();
        }

        private void btn_Tahlil_Düzenle_Click(object sender, EventArgs e)
        {
            Hastane.Open();
            SqlCommand tahlil_düzenle = new SqlCommand("Update Tahlil_Tanim set Tahlil_Adi='" + tb_tahlil_Tahlil_Adı.Text.ToString() + "'where Tahlil_Id=" + id_tahlil + "", Hastane);
            tahlil_düzenle.ExecuteNonQuery();
            Hastane.Close();
            verileri_göster_tahlil();
        }

        private void btn_doktor_oto_guncelleme_Click(object sender, EventArgs e)
        {
            if (doktor_oto_guncelleme == false)
            {
                tmr_doktor_Otomatik_Tablo_Guncelleyici.Enabled = true;
                btn_doktor_oto_guncelleme.Text = "Otomatik Yenileme (AÇIK)";
                btn_doktor_oto_guncelleme.BackColor = Color.Green;
                doktor_oto_guncelleme = true;
            }
            else
            {
                tmr_doktor_Otomatik_Tablo_Guncelleyici.Enabled = false;
                btn_doktor_oto_guncelleme.Text = "Otomatik Yenileme (KAPALI)";
                btn_doktor_oto_guncelleme.BackColor = Color.Red;
                doktor_oto_guncelleme = false;
            }
        }
        private void verileri_göster_ilac()
        {
            listView_Ilac_Tanimlari.Items.Clear();
            Hastane.Open();
            SqlCommand Ilac_Tanimi = new SqlCommand("Select *From Ilac_Tanim", Hastane);
            SqlDataReader oku = Ilac_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ListeNesnesi = new ListViewItem();
                ListeNesnesi.Text = oku["Ilac_Id"].ToString();
                ListeNesnesi.SubItems.Add(oku["Ilac_Adi"].ToString());
                ListeNesnesi.SubItems.Add(oku["Hastalik_Id"].ToString());
                ListeNesnesi.SubItems.Add(oku["Ilac_Birim_Fiyat"].ToString());
                listView_Ilac_Tanimlari.Items.Add(ListeNesnesi);
            }
            Hastane.Close();
        }
        private void verileri_göster_hastalik()
        {
            listView_Hastalik_Tanimlari.Items.Clear();
            Hastane.Open();
            SqlCommand Hastalik_Tanimi = new SqlCommand("Select *From Hastalik_Tanim", Hastane);
            SqlDataReader oku = Hastalik_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ListeNesnesi = new ListViewItem();
                ListeNesnesi.Text = oku["Hastalik_Id"].ToString();
                ListeNesnesi.SubItems.Add(oku["Hastalik_Adi"].ToString());
                listView_Hastalik_Tanimlari.Items.Add(ListeNesnesi);
            }
            Hastane.Close();
        }
        private void verileri_göster_tahlil()
        {
            listView_Tahlil_Tanimlari.Items.Clear();
            Hastane.Open();
            SqlCommand Tahlil_Tanimi = new SqlCommand("Select *From Tahlil_Tanim", Hastane);
            SqlDataReader oku = Tahlil_Tanimi.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ListeNesnesi = new ListViewItem();
                ListeNesnesi.Text = oku["Tahlil_Id"].ToString();
                ListeNesnesi.SubItems.Add(oku["Tahlil_Adi"].ToString());
                listView_Tahlil_Tanimlari.Items.Add(ListeNesnesi);
            }
            Hastane.Close();
        }

    }
}
