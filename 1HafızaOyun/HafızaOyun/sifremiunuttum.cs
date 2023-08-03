using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HafızaOyun
{
    public partial class sifremiunuttum : Form
    {
        public sifremiunuttum()
        {
            InitializeComponent();
            close.Parent = pictureBox1;
            close.BackColor = Color.Transparent;
            minimized.Parent = pictureBox1;
            minimized.BackColor = Color.Transparent;


        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
                    SmtpClient client = new SmtpClient();// e-postanın gönderileceği sunucuya bağlanmak için gerkli bilgilerin içerdiği kod.
                    client.Credentials = new NetworkCredential("", "");//client.Credentials satırı, SMTP sunucusuna erişmek için kullanılacak kimlik bilgilerini
                    client.Port = 587;//port numarası
                    client.Host = "smtp.office365.com";// Office 365 SMTP sunucusu
                    client.EnableSsl = true;//iletişimlerin güvenliğini sağlamak için kullanılan bir şifreleme protokolüdür.
                    message.To.Add(email);//e-postanın gönderileceği alıcının e-posta adresini eklemeyi sağlar
                    message.From = new MailAddress("");
                    message.Subject = "Şifremi Unuttum";
                    message.Body = "Şifre: " + "";//unuttuğu şifre, veritabanından okunan değer kullanılarak oluşturuluyor.
                    client.Send(message); //e - posta göndermek için SmtpClient nesnesinin Send() metodu çağrılıyor
                    MessageBox.Show("Mail adresinize şifre gönderildi.");
                    connection.Close();
                    this.Hide();
                    giris grs = new giris();
                    grs.Show();
                    this.Close();
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
            this.Hide();
            giris menu = new giris();
            menu.ShowDialog();
            this.Close();
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

