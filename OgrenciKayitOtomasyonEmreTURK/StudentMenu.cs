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
    public partial class StudentMenu : Form
    {
        public StudentMenu()
        {
            InitializeComponent();
        }

        static string constring = ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\turke\\source\\repos\\OgrenciKayitOtomasyonEmreTURK\\OgrenciKayitOtomasyonEmreTURK\\Database1.mdf;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);


        private void StudentMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrenciKayit ogrenci = new OgrenciKayit();
            this.Hide();
            ogrenci.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ogrenci_no;
            if (int.TryParse(textBox1.Text, out ogrenci_no))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Student WHERE ogrenci_no=@ogrenci_no", baglan);
                komut.Parameters.AddWithValue("@ogrenci_no", ogrenci_no);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt silme başarılı!");
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Öğrenci no geçersiz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ogrenci_no;
            if (int.TryParse(textBox1.Text, out ogrenci_no))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("UPDATE Student SET ogrenci_ad=@ogrenci_ad, ogrenci_soyad=@ogrenci_soyad, ogrenci_adress=@ogrenci_adress WHERE ogrenci_no=@ogrenci_no", baglan);
                komut.Parameters.AddWithValue("@ogrenci_no", ogrenci_no);
                komut.Parameters.AddWithValue("@ogrenci_ad", textBox2.Text);
                komut.Parameters.AddWithValue("@ogrenci_soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@ogrenci_adress", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt güncelleme başarılı !");
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Öğrenci no geçersiz!");
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
