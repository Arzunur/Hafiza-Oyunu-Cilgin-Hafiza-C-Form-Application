using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace HafızaOyun
{
    public partial class kolay : Form
    {
        private string kullaniciAdi;

        SqlConnection baglanti = new SqlConnection();


        Image[] resimler = {
                Properties.Resources._1, //resimlere bu koddan erişiyoruz. Resimleri Properties.Resources.resx eklemiştik.
                Properties.Resources._2,
                Properties.Resources._3,
                Properties.Resources._4,
                Properties.Resources._5,
                Properties.Resources._6,
                Properties.Resources._7,
                Properties.Resources._8,
            };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        PictureBox ilkkutu;
        int ilkIndeks, bulunan, deneme;
        int puan = 0; // Başlangıçta puanı 0 olarak ayarla


        private int geriSayimSuresi = 60; // Geriye sayım süresi (saniye)
        private Timer kronometre;

        public kolay(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            label1.Text = kullaniciAdi;
            plusscore.Visible = false;
            mixingpicture();
            label2.Text = "Puan: " + puan.ToString(); // label2'ye başlangıç puanını göster
            timer1.Interval = 3000; // Timer'ın süresini 3 saniye olarak ayarla
            timer1.Start(); // Timer'ı başlat
            pictureBox17.Controls.Add(close); //pictureBox17 arkaplan olan
            close.BackColor = Color.Transparent;
            pictureBox17.Controls.Add(minimized); 
            minimized.BackColor = Color.Transparent;
            pictureBox17.Controls.Add(label2); 
            label2.BackColor = Color.Transparent;
            pictureBox17.Controls.Add(label3);
            label3.BackColor = Color.Transparent;
            pictureBox17.Controls.Add(label1); 
            label1.BackColor = Color.Transparent;
            label3.Text = FormatZaman(geriSayimSuresi);// İlk değeri göster


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
        private int countDown = 3; // Başlangıç geri sayım değeri
        private void timer1_Tick(object sender, EventArgs e)
        {
            plusscore.Visible = false; // plusscore nesnesini gizle
            countDown--; // Geri sayımı azalt

            if (countDown <= 0)
            {
                timer1.Stop(); // Timer1'i durdur
                plusscore.Visible = false; 
            }
        }

        private void minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private bool isHakkimizdaShown = false; 

        private void timer2_Tick(object sender, EventArgs e)
        {
            geriSayimSuresi--;
            label3.Text = FormatZaman(geriSayimSuresi);

            if (geriSayimSuresi <= 0 && !isHakkimizdaShown)
            {
                timer2.Stop(); // Timer'ı durdur
                timer2.Enabled = false; // Timer'ı etkinleştirmeyi devre dışı bırak

                isHakkimizdaShown = true; // oyunbitti formunun gösterildiğini işaretle

                cankalmadi yeni = new cankalmadi();
                yeni.Show();

                this.Hide(); // Mevcut formu gizle
                             //this.Close(); // Mevcut formu kapat 

                DateTime tarih = DateTime.Now;
                string connectionString = "Data Source=";
                using (SqlConnection bag = new SqlConnection(connectionString))
                {
                    bag.Open();
                    string insertQuery = "INSERT INTO skortablo (kullaniciadi, skor, tarih) VALUES (@kullaniciadi, @skor, @tarih)";
                    string skor = label2.Text.Replace("Puan: ", ""); // "Puan: " metnini kaldırarak sadece skor değerini elde edin

                    SqlCommand command = new SqlCommand(insertQuery, bag);
                    command.Parameters.AddWithValue("@kullaniciadi", label1.Text);
                    command.Parameters.AddWithValue("@skor", skor); // Skor değerini kaydedin
                    command.Parameters.AddWithValue("@tarih", tarih);
                    command.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }
            }
        }
        private string FormatZaman(int saniye)
        {
            int dakika = saniye / 60;
            int kalanSaniye = saniye % 60;
            return string.Format("{0:00}:{1:00}", dakika, kalanSaniye);
        }
        private void mixingpicture() //Eşleşen kartların tümünü bulduktan sonra kartların yerlerini karıştırmak için kullanılan bir fonksiyon
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++) //16 yerine indeksler.Length de denilebilirdi.
            {
                int sayi = rnd.Next(16);//0-15 kadar rastgele bir sayı seç 
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
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
                    if (indeksNo == 1 || indeksNo == 3 || indeksNo == 5)
                    {
                        Random random = new Random();
                        if (random.Next(2) == 0)
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
                if (bulunan == 8) // tüm kartların eşleştirildiği durumu kontrol
                {
                    mixingpicture();
                    if (geriSayimSuresi > 0)
                    {

                    }
                }

            }
            if (bulunan == 8 || geriSayimSuresi < 0)
            {
                DateTime tarih = DateTime.Now;
                string connectionString = "Data Source=";
                using (SqlConnection bag = new SqlConnection(connectionString))
                {
                    bag.Open();
                    string insertQuery = "INSERT INTO skortablo (kullaniciadi, skor, tarih) VALUES (@kullaniciadi, @skor, @tarih)";

                    SqlCommand command = new SqlCommand(insertQuery, bag);
                    command.Parameters.AddWithValue("@kullaniciadi", label1.Text);
                    command.Parameters.AddWithValue("@skor", label2.Text); // Skor değerini kaydedin
                    command.Parameters.AddWithValue("@tarih", tarih);
                    command.ExecuteNonQuery(); // Tek bir kez çağırıldı, ikinci çağrı kaldırıldı
                }
                timer2.Stop();
                cankalmadi yeni = new cankalmadi();
                yeni.Show();
                this.Close(); 
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

