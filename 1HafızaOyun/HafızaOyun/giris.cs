using System;// Temel .NET sınıflarını ve işlevleri içeren System kütüphanesi.
using System.Collections.Generic;// Genel koleksiyon türleri ve veri yapıları için işlevler içeren kütüphane.
using System.ComponentModel;// Bileşen tabanlı programlama için bileşen modellerini ve olayları içeren kütüphane.
using System.Data;// Veritabanı işlemleri için veri tabanı nesneleri ve işlevler içeren kütüphane.
using System.Data.SqlClient; // Microsoft SQL Server veritabanıyla iletişim kurmak için kullanılan kütüphane.
using System.Drawing;// Grafik ve çizim işlemleri için sınıflar ve işlevler içeren kütüphane.
using System.Linq;// LINQ (Dil Entegre Sorgulama) işlevselliğini içeren kütüphane.
using System.Reflection.Emit;// Çalışma zamanında dinamik olarak derleme işlemleri yapmayı sağlayan kütüphane.
using System.Text;// Metin işleme ve kodlama işlemleri için yardımcı sınıflar içeren kütüphane.
using System.Threading.Tasks;
using System.Windows.Forms;// Windows Forms uygulamaları geliştirmek için GUI öğeleri ve işlevler içeren kütüphane.
using static System.Windows.Forms.VisualStyles.VisualStyleElement;// Görsel stiller için araçlar ve öğeler içeren kütüphane.
using System.Media; // Ses çalma işlemleri için yardımcı sınıflar içeren kütüphane.
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;// Araç çubuğu için görsel stiller içeren kütüphane.
using System.Net;
using System.Net.Mail;



namespace HafızaOyun
{
    public partial class giris : Form

    {
        private bool isPlaying = false;// müzik çalıyor mu?
        private string kullaniciAdi;


        SoundPlayer player = new SoundPlayer("C:H3.wav");
        public giris()
        {
            InitializeComponent();

            player = new SoundPlayer("C:H3.wav");
            //Tooltip kontrol 
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "UYARI"; //tooltipin başlık ismi
            toolTip1.AutomaticDelay = 200; //milisaniye sonra tooltiplerin görüntülenmesi. Varsayılan değeri =500ms
            toolTip1.SetToolTip(this.textBox1, "@ işaretini, büyük harf, küçük harflere dikkat ediniz.");
            toolTip1.SetToolTip(this.textBox5, "@ işaretini, büyük harf, küçük harflere dikkat ediniz.");
            // Tool mesaj 2 = Şifre harf, sayı, ve özel karakter içermelidir.
            toolTip1.SetToolTip(this.textBox6, "En az 8 karakter olmalıdır.");
            //Arkaplan seffaf
            linkLabel1.Parent = pictureBox1;
            linkLabel1.BackColor = Color.Transparent;
            hatırla.Parent = pictureBox1;
            hatırla.BackColor = Color.Transparent;
            #region ses
            //Form yüklendiğinde müzik çalacak şekilde düzenle
            player = new System.Media.SoundPlayer("C:\\H3.wav"); // müzik dosyasını uzantısı
            player.Play(); // müziği çal
            isPlaying = true; // müzik çalıyor olarak ayarla
            button1.BackgroundImage = ımageList1.Images[0]; // buton arka plan resmini ilk resim olarak ayarla
            button1.Padding = new Padding(10); // butonun dolgusunu ayarla
            #endregion
        }
        private void Player_PlayCompleted(object sender, EventArgs e)
        {
            // Müzik dosyası tamamlandığında tekrar başlat
            player.Play();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.PasswordChar = '•';
        }
        private void dilekVeÖnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bizeUlasın yeni = new bizeUlasın();
            yeni.Show();
            this.Close();
            this.Hide();
        }
        private void nasılOynanırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nasılOynanır yeni = new nasılOynanır();
            yeni.Show();
            this.Close();
            this.Hide();
        }
        private void giris_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserName != string.Empty) //UserName daha önce bir kullanıcı adı kaydedilmişse, if bloğunun içindeki kod çalışır
                                                                      //Empty boş bir string nesnesi oluşturarak, UserName özelliğinin şu anda boş olup olmadığını kontrol eder
            {
                textBox1.Text = Properties.Settings.Default.UserName;//önceden kaydedilmiş kullanıcı adı varsa sonraki sefer uygulamayı açtığında kaydedilmiş kullanıcı adı TextBox'ında görüntülenmesini sağlar.
                textBox2.Text = Properties.Settings.Default.Password;
                hatırla.Checked = true;//uygulama ilk yüklendiğinde daha önce kaydedilmiş bir kullanıcı adı ve şifre varsa işaretler
            }
        }
        private void hatırla_CheckedChanged(object sender, EventArgs e)
        {

            if (hatırla.Checked == true)
            {
                Properties.Settings.Default.UserName = textBox1.Text;//kullanıcının uygulamaya girerken girdiği kullanıcı adını, uygulama ayarlarına kaydetmek için kullanılır.
                Properties.Settings.Default.Password = textBox2.Text;
                //Properties- Ayarlar 
            }
            else
            {
                Properties.Settings.Default.UserName = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
            }

            Properties.Settings.Default.Save();
            //Settings.settings kısmında ayarları kaydederek kullanılacak son ayarların güncellenmesini sağlar.
        }

        Random rnd = new Random();
        String onaykodu;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string email = textBox1.Text;
                string query = "SELECT * FROM kayıtol WHERE email = '" + email + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string Sifre = reader["sifre"].ToString();
                    MailMessage message = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new NetworkCredential("", "");
                    client.Host = "smtp.office365.com";
                    client.EnableSsl = true;
                    message.To.Add(email);
                    client.Port = 587;
                    message.From = new MailAddress("");
                    message.Subject = "Aktivasyon Şifre";

                    string passwordText = "Şifre: "; // Fixed password
                    message.Body = passwordText;

                    client.Send(message);
                    MessageBox.Show("Mail adresinize aktivasyon şifresi gönderildi.");

                    onaykodu = "1234"; // Fixed password assigned to the onaykodu variable
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Mail adresini giriniz");
                }
                else
                {
                    MessageBox.Show("Mail adresi bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            connection.Close();
        

        }
        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkımızda yeni = new hakkımızda();
            yeni.Show();
            this.Close();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=";
            SqlConnection baglanti = new SqlConnection(connectionString);

            try
            {
                if (textBox6.Text.Length < 8)
                {
                    textBox6.PasswordChar = '•';
                    MessageBox.Show("Şifreniz en az 8 karakter uzunluğunda olmalıdır.", "Şifre Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kayıt ekleme işlemi
                baglanti.Open();
                SqlCommand ekleKomut = new SqlCommand("INSERT INTO kayıtol (ad,soyad,email,sifre)  VALUES ('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglanti);
                int etkilenenSatir = ekleKomut.ExecuteNonQuery();
                if (etkilenenSatir == 1)
                {
                    MessageBox.Show("Kayıt başarıyla eklendi.");
                    // Verileri listeleme işlemi
                    // temizle();
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
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        } 
        private void player_PlayComplete(object sender, EventArgs e)
        {
            //player_PlayComplete yöntemi, ses dosyasının tamamlandığını algıladığında yeniden başlatma işlemini gerçekleştirir. 
            player.Stop();
            player.Play();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            sifremiunuttum menu = new sifremiunuttum();
            menu.ShowDialog();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Butona tıklandığında müziği başlat veya durdur
            if (isPlaying)
            {
                player.Stop();
                isPlaying = false;
                button1.BackgroundImage = ımageList1.Images[1]; // İkinci resim seçildi
            }
            else
            {
                player.Play();
                isPlaying = true;
                button1.BackgroundImage = ımageList1.Images[0]; // İlk resim seçildi
            }
        }
      
        private void adminToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            admin yeni2 = new admin();
            yeni2.Show();
            this.Close();
            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Kayıt oluşturuldu.");
                string girisKullaniciAdi = textBox1.Text;
                string connectionString = "Data Source=";
                SqlConnection bag = new SqlConnection(connectionString);
                bag.Open();
                SqlCommand giris = new SqlCommand("SELECT * FROM kayıtol WHERE email = @email AND sifre = @sifre", bag);

                giris.Parameters.AddWithValue("@email", girisKullaniciAdi);
                giris.Parameters.AddWithValue("@sifre", textBox2.Text);
                SqlDataReader oku = giris.ExecuteReader();
                if (oku.Read())
                {
                    kullaniciAdi = oku["email"].ToString();
                    kolay menu = new kolay(kullaniciAdi);
                    menu.ShowDialog();
                    bag.Close();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş");
                    bag.Close();
                }
                player.Stop();
                isPlaying = false;
            }
        }
    }
}

