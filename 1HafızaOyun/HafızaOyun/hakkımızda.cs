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
    public partial class hakkımızda : Form
    {
        public hakkımızda()
        {
            InitializeComponent();
            close.Parent = pictureBox1;
            close.BackColor = Color.Transparent;
            minimized.Parent = pictureBox1;
            minimized.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            giris yeni = new giris();
            yeni.Show();
            this.Close();
            this.Hide();

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
    }
}
