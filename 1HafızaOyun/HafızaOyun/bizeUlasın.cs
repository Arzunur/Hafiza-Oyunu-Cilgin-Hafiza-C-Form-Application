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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HafızaOyun
{
    public partial class bizeUlasın : Form
    {
        public bizeUlasın()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(close); //pictureBox17 arkaplan olan
            close.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(minimized); //pictureBox17 arkaplan olan
            minimized.BackColor = Color.Transparent;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-\\MSSQLSERVER;Initial Catalog=kayıt;Integrated Security=True";
            SqlConnection baglanti = new SqlConnection(connectionString);

            try
            { 
                baglanti.Open();
                SqlCommand ekleKomut = new SqlCommand("INSERT INTO bizeulasin (ad,mail,mesaj)  VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);
                int etkilenenSatir = ekleKomut.ExecuteNonQuery();
                if (etkilenenSatir == 1)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Gönderim başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    giris yeni = new giris();
                    yeni.Show();
                    this.Hide();
                }
            
                else
                {
                    MessageBox.Show("Kayıt eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            giris yeni = new giris();
            yeni.Show();
            this.Hide();
        }

        private void minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

