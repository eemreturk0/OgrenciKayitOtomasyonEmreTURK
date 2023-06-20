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

namespace OgrenciKayitOtomasyonEmreTURK
{
    public partial class TeacherMenu : Form
    {
        public TeacherMenu()
        {
            InitializeComponent();
        }


        static string constring = ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\turke\\source\\repos\\OgrenciKayitOtomasyonEmreTURK\\OgrenciKayitOtomasyonEmreTURK\\Database1.mdf;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    int ogretmen_no;
                    if (int.TryParse(textBox1.Text, out ogretmen_no))
                    {
                        baglan.Open();
                        string kayit = "insert into Teacher (ogretmen_no, ogretmen_ad, ogretmen_soyad, ogretmen_adress) values (@ogretmen_no, @ogretmen_ad, @ogretmen_soyad, @ogretmen_adress)";
                        SqlCommand komut = new SqlCommand(kayit, baglan);
                        komut.Parameters.AddWithValue("ogretmen_no", ogretmen_no);
                        komut.Parameters.AddWithValue("ogretmen_ad", textBox2.Text);
                        komut.Parameters.AddWithValue("ogretmen_soyad", textBox3.Text);
                        komut.Parameters.AddWithValue("ogretmen_adress", textBox4.Text);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt ekleme başarılı !");
                    }
                    else
                    {
                        MessageBox.Show("Öğretmen no geçersiz!");
                    }

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata var !!" + hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ogretmen_no;
            if (int.TryParse(textBox1.Text, out ogretmen_no))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Teacher WHERE ogretmen_no=@ogretmen_no", baglan);
                komut.Parameters.AddWithValue("@ogretmen_no", ogretmen_no);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt silme başarılı!");
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Öğretmen no geçersiz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ogretmen_no;
            if (int.TryParse(textBox1.Text, out ogretmen_no))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("UPDATE Teacher SET ogretmen_ad=@ogretmen_ad, ogretmen_soyad=@ogretmen_soyad, ogretmen_adress=@ogretmen_adress WHERE ogretmen_no=@ogretmen_no", baglan);
                komut.Parameters.AddWithValue("@ogretmen_no", ogretmen_no);
                komut.Parameters.AddWithValue("@ogretmen_ad", textBox2.Text);
                komut.Parameters.AddWithValue("@ogretmen_soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@ogretmen_adress", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt güncelleme başarılı !");
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Öğretmen no geçersiz!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrenciKayit ogrenci = new OgrenciKayit();
            this.Hide();
            ogrenci.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
