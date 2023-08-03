using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyun
{
    public partial class cankalmadi : Form
    {
        private DataSet ds = new DataSet(); // Yeni bir DataSet nesnesi oluşturun


        public cankalmadi()
        {
            InitializeComponent();
            close.Parent = pictureBox1;
            close.BackColor = Color.Transparent;
            minimized.Parent = pictureBox1;
            minimized.BackColor = Color.Transparent;
        }
        SqlConnection baglantı = new SqlConnection("Data Source=");
       
        private void verigoster(string veriler)
        {
            ds.Clear(); // DataSet'i temizle

           
                baglantı.Open();
                SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
                da.Fill(ds);
                baglantı.Close();
           

            if (veriler == "Select * from skortablo")
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (veriler == string.Format("SELECT * FROM skortablo WHERE CONVERT(date, tarih) = '{0}'", DateTime.Today.ToString("yyyy-MM-dd")))
            {
                
                    dataGridView4.DataSource = ds.Tables[0];
            }
            else if (veriler == string.Format("SELECT * FROM skortablo WHERE MONTH(tarih) = {0} AND YEAR(tarih) = {1}", DateTime.Today.Month, DateTime.Today.Year))
            {
                
                    dataGridView3.DataSource = ds.Tables[0];
            }
            else if (veriler == string.Format("SELECT * FROM skortablo WHERE YEAR(tarih) = {0}", DateTime.Today.Year))
            {
             
                    dataGridView2.DataSource = ds.Tables[0];
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

        private void anasayfa_Click(object sender, EventArgs e)
        {
            giris yeni = new giris();
            yeni.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            string tarih = bugun.ToString("yyyy-MM-dd");
            string sorgu = string.Format("SELECT * FROM skortablo WHERE CONVERT(date, tarih) = '{0}'", tarih);
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            if (ds.Tables.Count > 0)
            {
                dataGridView4.DataSource = ds.Tables[0]; // Verileri tabloya doldur
                dataGridView4.Refresh(); // DataGridView'i yenile
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string tarih = DateTime.Today.ToString("yyyy-MM-dd");
            string sorgu = string.Format("SELECT * FROM skortablo WHERE CONVERT(date, tarih) = '{0}'", tarih);
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            if (ds.Tables.Count > 0)
            {
                dataGridView3.DataSource = ds.Tables[0]; // Verileri tabloya doldur
                dataGridView3.Refresh(); // DataGridView'i yenile
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string yil = DateTime.Today.Year.ToString();
            string sorgu = string.Format("SELECT * FROM skortablo WHERE YEAR(tarih) = {0}", yil);
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            if (ds.Tables.Count > 0)
            {
                dataGridView2.DataSource = ds.Tables[0]; // Verileri tabloya doldur
                dataGridView2.Refresh(); // DataGridView'i yenile
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string sorgu = "SELECT TOP 5 * FROM skortablo ORDER BY skor DESC";
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0]; // Verileri tabloya doldur
                dataGridView1.Refresh(); // DataGridView'i yenile
            }
        }

        private void sonraki_seviye_Click(object sender, EventArgs e)
        {
            orta yeni = new orta();
            yeni.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.png;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                pictureBox2.Image = Image.FromFile(dosyaYolu);
            }
        }
    }
}
