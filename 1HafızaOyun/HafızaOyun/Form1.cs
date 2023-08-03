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
    public partial class Form1 : Form
    {
        int countDown = 6;
        public Form1()
        {
            InitializeComponent();
            this.AutoScroll = true;

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // her saniyede bir tetiklenecek
            timer1.Enabled = true;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            countDown--;
            if (countDown == 0)
            {
                timer1.Enabled = false;
                timer1.Stop();
                giris yeni = new giris();
                yeni.Show();
                this.Hide();
            }
            else
            {
                this.Text = "Sayfaya geçmek için " + countDown.ToString() + " saniye kaldı.";
            }
        }
    }

}
