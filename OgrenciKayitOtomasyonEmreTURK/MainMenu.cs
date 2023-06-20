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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        


        

        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrenciKayit ogrencikayit = new OgrenciKayit();
            this.Hide();
            ogrencikayit.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadDataGridView2();
        }

        private void LoadDataGridView()
        {
            // Veritabanı bağlantı dizesini ayarla
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\turke\\source\\repos\\OgrenciKayitOtomasyonEmreTURK\\OgrenciKayitOtomasyonEmreTURK\\Database1.mdf;Integrated Security=True";

            // SQL sorgusu
            string query = "SELECT * FROM Student";

            // Veritabanı bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve bağlantıyı ilişkilendir
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Veri okuyucusunu oluştur
                    SqlDataReader reader = command.ExecuteReader();

                    // DataTable oluştur
                    DataTable dataTable = new DataTable();

                    // Veri okuyucusundan sütunları al ve DataTable'a ekle
                    dataTable.Load(reader);

                    // DataGridView'a verileri ata
                    dataGridView1.DataSource = dataTable;

                    // Veri okuyucusunu kapat
                    reader.Close();
                }

                // Veritabanı bağlantısını kapat
                connection.Close();
            }
        }


        private void LoadDataGridView2()
        {
            // Veritabanı bağlantı dizesini ayarla
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\turke\\source\\repos\\OgrenciKayitOtomasyonEmreTURK\\OgrenciKayitOtomasyonEmreTURK\\Database1.mdf;Integrated Security=True";

            // SQL sorgusu
            string query = "SELECT * FROM Teacher";

            // Veritabanı bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve bağlantıyı ilişkilendir
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Veri okuyucusunu oluştur
                    SqlDataReader reader = command.ExecuteReader();

                    // DataTable oluştur
                    DataTable dataTable = new DataTable();

                    // Veri okuyucusundan sütunları al ve DataTable'a ekle
                    dataTable.Load(reader);

                    // DataGridView'a verileri ata
                    dataGridView2.DataSource = dataTable;

                    // Veri okuyucusunu kapat
                    reader.Close();
                }

                // Veritabanı bağlantısını kapat
                connection.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static string constring = ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\turke\\source\\repos\\OgrenciKayitOtomasyonEmreTURK\\OgrenciKayitOtomasyonEmreTURK\\Database1.mdf;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string ogrenci_ad = textBox1.Text.Trim();

            string selectQuery = "SELECT * FROM Student WHERE ogrenci_ad LIKE '%' + @ogrenci_ad + '%'"; 

            using (SqlConnection connection = new SqlConnection(constring))
            {
                baglan.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ogrenci_ad", ogrenci_ad);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataTable'ı kullanarak sonuçları istediğiniz şekilde işleyebilirsiniz
                        if (string.IsNullOrEmpty(ogrenci_ad))
                        {
                            // TextBox boşsa, tüm liste gösterilir
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            // TextBox doluysa, filtrelenmiş sonuçlar gösterilir
                            DataView dataView = dataTable.DefaultView;
                            dataView.RowFilter = $"ogrenci_ad LIKE '%{ogrenci_ad}%'";
                            dataGridView1.DataSource = dataView;
                        }
                    }
                    baglan.Close();
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string ogretmen_ad = textBox2.Text.Trim();

            string selectQuery = "SELECT * FROM Teacher WHERE ogretmen_ad LIKE '%' + @ogretmen_ad + '%'";

            using (SqlConnection connection = new SqlConnection(constring))
            {
                baglan.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ogretmen_ad", ogretmen_ad);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataTable'ı kullanarak sonuçları istediğiniz şekilde işleyebilirsiniz
                        if (string.IsNullOrEmpty(ogretmen_ad))
                        {
                            // TextBox boşsa, tüm liste gösterilir
                            dataGridView2.DataSource = dataTable;
                        }
                        else
                        {
                            // TextBox doluysa, filtrelenmiş sonuçlar gösterilir
                            DataView dataView = dataTable.DefaultView;
                            dataView.RowFilter = $"ogretmen_ad LIKE '%{ogretmen_ad}%'";
                            dataGridView2.DataSource = dataView;
                        }
                    }
                    baglan.Close();
                }
            }
        }
    }
}
