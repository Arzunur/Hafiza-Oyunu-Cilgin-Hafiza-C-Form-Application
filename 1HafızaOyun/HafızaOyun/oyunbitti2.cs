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
    public partial class oyunbitti2 : Form
    {
        public oyunbitti2()
        {
            InitializeComponent();
            close.Parent = pictureBox1;
            close.BackColor = Color.Transparent;
            minimized.Parent = pictureBox1;
            minimized.BackColor = Color.Transparent;
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

        private void sonraki_seviye_Click(object sender, EventArgs e)
        {
            zor yeni = new zor();
            yeni.Show();
            this.Close();
        }

        private void anasayfa_Click(object sender, EventArgs e)
        {
            giris yeni = new giris();
            yeni.Show();
            this.Close();
        }
    }
}
