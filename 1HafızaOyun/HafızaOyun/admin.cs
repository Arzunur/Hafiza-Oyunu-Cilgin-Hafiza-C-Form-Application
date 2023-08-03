using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyun
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(close); //pictureBox17 arkaplan olan
            close.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(minimized); 
            minimized.BackColor = Color.Transparent;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                // Kullanıcı doğru bilgileri girdiyse
                // adminskor sayfasına geçiş yapılabilir
                adminskor adminskorSayfasi = new adminskor();
                adminskorSayfasi.Show();
                this.Hide();
            }
            else
            {
                // Kullanıcı hatalı giriş yaptıysa
                // Hatalı giriş mesajı gösterilir
                MessageBox.Show("Hatalı giriş! Lütfen doğru bilgileri girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
        }
    }
}
