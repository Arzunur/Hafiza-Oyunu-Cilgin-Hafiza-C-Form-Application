using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyun
{
    public partial class orta : Form
    {
        Image[] resimler = {
            Properties.Resources.avokado, //resimlere bu koddan erişiyoruz. Resimleri Properties.Resources.resx eklemiştik.
            Properties.Resources.ananaas,
            Properties.Resources.donut,
            Properties.Resources.donuts,
            Properties.Resources.havuc,
            Properties.Resources.karpuz,
            Properties.Resources.kurabiye,
            Properties.Resources.mantar,
            Properties.Resources.pizza,
            Properties.Resources.popcorn,
            Properties.Resources.sushi,
            Properties.Resources.waffle,
        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16 };
        PictureBox ilkkutu;
        int ilkIndeks, bulunan, deneme;
        int puan = 0; // Başlangıçta puanı 0 olarak ayarla




        private int geriSayimSuresi = 60; // Geriye sayım süresi (saniye)
        private Timer kronometre;

        public orta()
        {
            InitializeComponent();
            plusscore.Visible = false;
            mixingpicture();
            label2.Text = "Puan: " + puan.ToString(); 
            timer1.Interval = 3000; 
            timer1.Start(); 


            pictureBox25.Controls.Add(close); //pictureBox17 arkaplan olan
            close.BackColor = Color.Transparent;
            pictureBox25.Controls.Add(minimized); 
            minimized.BackColor = Color.Transparent;

            pictureBox25.Controls.Add(label2); 
            label2.BackColor = Color.Transparent;
            
            pictureBox25.Controls.Add(label3); 
            label3.BackColor = Color.Transparent;
            
            kronometre = new Timer();
            kronometre.Interval = 1000; // 1 saniye
            kronometre.Tick += timer2_Tick;
            kronometre.Start();
        }
        private void yARDIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nasılOynanır yeni = new nasılOynanır();
            yeni.Show();
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

        private bool isHakkimizdaShown = false; // hakkımızda formunun daha önce gösterilip gösterilmediğini takip etmek için bir değişken
        private int countDown = 3; // Başlangıç geri sayım değeri
        private void timer1_Tick(object sender, EventArgs e)
        {
            plusscore.Visible = false; // plusscore nesnesini gizle
            countDown--; // Geri sayımı azalt

            if (countDown <= 0)
            {
                timer1.Stop(); // Timer1'i durdur
                plusscore.Visible = false; // Hide the picture box
            }
        }
        private string FormatZaman(int saniye)
        {
            int dakika = saniye / 60;
            int kalanSaniye = saniye % 60;
            return string.Format("{0:00}:{1:00}", dakika, kalanSaniye);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            geriSayimSuresi--;
            label3.Text = FormatZaman(geriSayimSuresi);

            if (geriSayimSuresi <= 0 && !isHakkimizdaShown)
            {
                timer2.Stop(); // Timer'ı durdur
                timer2.Enabled = false; // Timer'ı etkinleştirmeyi devre dışı bırak

                isHakkimizdaShown = true; // oyunbitti2 formunun gösterildiğini işaretle

                oyunbitti2 yeni = new oyunbitti2();
                yeni.Show();

                this.Hide(); 
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void mixingpicture()
        {
            Random rnd = new Random();
            for (int i = 0; i < 24; i++)
            {
                int sayi = rnd.Next(24);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo - 1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                // İlk kartın seçimi
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;
            }
            else
            {
                // İkinci kartın seçimi
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = null;
                kutu.Image = null;


                if (ilkIndeks == indeksNo)// Eşleşme durumu

                {
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    label2.Text = "Puan: " + puan.ToString(); // Skor etiketini güncelle
                    // belirli indeks numaralarına göre puan ve süre artışı
                    if (indeksNo == 4 || indeksNo == 10 || indeksNo == 13 || indeksNo==2 ||indeksNo==6)
                    {
                        Random random = new Random();
                        if (random.Next(1) == 0)
                        {
                            // Plusscore görüntüsünü kullanarak puan ve süre artışı
                            if (plusscore.Visible)
                            {
                                plusscore.Visible = false;
                                puan += 10; // Aynı resim eşleşmesi olduğunda 10 puan ekler
                            }
                            else
                            {
                                plusscore.Visible = true;
                                puan += 30; // Belirli resimlerde eşleşme olduğunda 30 puan ekler
                            }

                            label2.Text = "Puan: " + puan.ToString(); // Skor etiketini güncelle
                            plusscore.Refresh();
                            System.Threading.Thread.Sleep(2000);
                            plusscore.Visible = false;
                            // Süre Artırma
                            ArtirSuresi(10); // Süreyi 10 saniye artır
                        }
                        else
                        {
                            puan += 10; // Belirli kartlar eşleştiğinde rastgele olarak 10 puan ekler
                            label2.Text = "Puan: " + puan.ToString(); // Skor etiketini güncelle
                        }

                        // Süre artışı
                        if (indeksNo == 6 || indeksNo == 7)
                        {
                            geriSayimSuresi += 10; // Süreyi 10 saniye artır
                            label3.Text = FormatZaman(geriSayimSuresi); // Süreyi güncelle
                        }
                    }
                    else
                    {
                        puan += 10; // Diğer kartlar eşleştiğinde 10 puan ekler
                        label2.Text = "Puan: " + puan.ToString(); // Skor etiketini güncelle
                    }
                }

                ilkkutu = null;
                if (bulunan == 24) // tüm kartların eşleştirildiği durumu kontrol
                {
                    mixingpicture();
                    if (geriSayimSuresi > 0)
                    {
                        string connectionString = "Data Source=";
                        SqlConnection bag = new SqlConnection(connectionString);
                        bag.Open();
                        string insertQuery = "INSERT INTO skortablo (kullaniciadi,skor,tarih) VALUES (@kullaniciadi,@skor,@tarih)";
                        SqlCommand command = new SqlCommand(insertQuery, bag);

                        //command.Parameters.AddWithValue("@kullanıcıadi", kullanıcıadi);
                        command.Parameters.AddWithValue("@skor", puan);
                        command.Parameters.AddWithValue("@tarih", DateTime.Now);

                        command.ExecuteNonQuery();
                        bag.Close();
                    }
                }
            }
        }
        private PictureBox eksure;
        private void ArtirSuresi(int artis)
        {
            geriSayimSuresi += artis; // Süreyi artır
            label3.Text = FormatZaman(geriSayimSuresi); // Süreyi güncelle
        }
    }
}
