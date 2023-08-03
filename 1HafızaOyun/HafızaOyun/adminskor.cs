using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HafızaOyun;

namespace HafızaOyun
{
   
    public partial class adminskor : Form
    {
        private resimC resim;
        public adminskor()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(close); //pictureBox17 arkaplan olan
            close.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(minimized); 
            minimized.BackColor = Color.Transparent;
          
       


            resim = new resimC(pictureBox2, 200, 200,40, 40);

        }
        SqlConnection baglantı = new SqlConnection("Data Source=");
        private DataSet ds = new DataSet(); // verileri tut
        private void verigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            da.Fill(ds); // dataset verilerini doldurur

            // Verileri doğru DataGridView kontrolüne atama
            if (veriler == "Select * from skortablo")
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (veriler == "SELECT * FROM skortablo WHERE CONVERT(date, tarih) = '{0}'")
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
            else if (veriler == "SELECT * FROM skortablo WHERE MONTH(tarih) = {0} AND YEAR(tarih) = {1}")
            {
                dataGridView3.DataSource = ds.Tables[0];
            }
            else if (veriler == "SELECT * FROM skortablo WHERE YEAR(tarih) = {0}")
            {
                dataGridView4.DataSource = ds.Tables[0];
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

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)//GÖRÜNTÜLE
        {
            verigoster("Select * from skortablo");
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=";
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("DELETE FROM skortablo WHERE tarih = @tarih", baglanti);
                komut.Parameters.AddWithValue("@tarih", dataGridView1.SelectedRows[0].Cells["tarih"].Value);
                komut.ExecuteNonQuery();

                baglanti.Close();

                // Veriyi güncellemek için verigoster metodunu yeniden çağırabilirsiniz.
                verigoster("Select * from skortablo");
            }
        }
       

        private void button3_Click_1(object sender, EventArgs e) //Ay
        {

            DateTime bugun = DateTime.Today;//satırıyla bugünün tarihini alırız
            string tarih = bugun.ToString("yyyy-MM-dd");//bugünün tarihini "yyyy-MM-dd" formatına dönüştürerek tarih değişkenine atarız.
            string sorgu = string.Format("SELECT * FROM skortablo WHERE CONVERT(date, tarih) = '{0}'", tarih);
            // veritabanından çekilecek verilerin sorgusunu oluştururuz. Bu sorgu, skortablo tablosundan tarih alanı belirtilen tarihe eşit olan tüm verileri seçer.
            ds.Clear(); // önceki verileri siler ve yeni verileri yüklemek için temiz bir DataSet oluşturur.
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            dataGridView3.DataSource = ds.Tables[0]; // Verileri tabloya doldur.Verileri veritabanından çeker ve DataSet'e doldurur.
            dataGridView3.Refresh(); // DataGridView'i yenileriz. Bu, DataGridView'in görüntüsünü güncellemek için kullanılır.
        }

        private void button1_Click(object sender, EventArgs e) //GÜN
        {
            DateTime bugun = DateTime.Today;
            string tarih = bugun.ToString("yyyy-MM-dd");
            string sorgu = string.Format("SELECT * FROM skortablo WHERE CONVERT(date, tarih) = '{0}'", tarih);
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            dataGridView2.DataSource = ds.Tables[0]; // Verileri tabloya doldur
            dataGridView2.Refresh(); // DataGridView'i yenile
        }

        private void button4_Click_3(object sender, EventArgs e)//YILLIK
        {
            DateTime bugun = DateTime.Today;
            string yil = bugun.Year.ToString();
            string sorgu = string.Format("SELECT * FROM skortablo WHERE YEAR(tarih) = {0}", yil);
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            dataGridView4.DataSource = ds.Tables[0]; // Verileri tabloya doldur
            dataGridView4.Refresh(); // DataGridView'i yenile
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string sorgu = "SELECT TOP 5 * FROM skortablo ORDER BY skor DESC";// azalan sırada sıralar ve en yüksek 5 skoru alır.
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            dataGridView5.DataSource = ds.Tables[0]; // Verileri tabloya doldur
            dataGridView5.Refresh(); // DataGridView'i yenile
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT TOP 10 * FROM skortablo ORDER BY skor DESC";
            ds.Clear(); // DataSet'i temizle
            verigoster(sorgu); // Tabloyu güncellemek için verigoster metodunu çağırın
            dataGridView6.DataSource = ds.Tables[0]; // Verileri tabloya doldur
            dataGridView6.Refresh(); // DataGridView'i yenile
        }

        private void button7_Click(object sender, EventArgs e)
        {
            resim.Aç();

        }
    }
}
