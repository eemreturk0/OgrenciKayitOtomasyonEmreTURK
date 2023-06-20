using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.Data.SqlClient;



namespace OgrenciKayitOtomasyonEmreTURK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        
        private bool isValid()
        {
            if(textBox1.Text.TrimStart() ==  string.Empty)
            {
                MessageBox.Show("enter valid user name", "error");
                return false;
            }
            else if(textBox2.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("enter valid user name", "error");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\turke\source\repos\OgrenciKayitOtomasyonEmreTURK\OgrenciKayitOtomasyonEmreTURK\Database1.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM LOGIN WHERE username = '" + textBox1.Text.Trim() + "'AND  password = '" + textBox2.Text.Trim()+ "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if(dta.Rows.Count == 1)
                    {
                        OgrenciKayit ogrencikayit = new OgrenciKayit();
                        this.Hide();
                        ogrencikayit.Show();


                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
