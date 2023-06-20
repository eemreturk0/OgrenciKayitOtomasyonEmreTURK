using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciKayitOtomasyonEmreTURK
{
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = new MainMenu();
            this.Hide();
            mainmenu.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentMenu student = new StudentMenu();
            this.Hide();
            student.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeacherMenu teacher = new TeacherMenu();
            this.Hide();
            teacher.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
