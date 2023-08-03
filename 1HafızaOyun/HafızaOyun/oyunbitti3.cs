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
    public partial class oyunbitti3 : Form
    {
        public oyunbitti3()
        {
            InitializeComponent();
         

        }

        private void anasayfa_Click(object sender, EventArgs e)
        {

            giris yeni = new giris();
            yeni.Show();
            this.Close();
        }
    
    }
}
