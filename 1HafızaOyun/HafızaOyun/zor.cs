using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyun
{
    public partial class zor : Form
    {
        Image[] resimler = {
            Properties.Resources.arı, 
            Properties.Resources.aslan,
            Properties.Resources.ayı,
            Properties.Resources.baykus,
            Properties.Resources.esek,
            Properties.Resources.fil,
            Properties.Resources.inek,
            Properties.Resources.kedi,
            Properties.Resources.kus,
            Properties.Resources.maymun,
            Properties.Resources.panda2,
            Properties.Resources.rakum,
            Properties.Resources.suaygırı,
            Properties.Resources.tavsan,
            Properties.Resources.tavuk,
            Properties.Resources.timsah,
            Properties.Resources.tırtıl,
            Properties.Resources.penguen,
        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12 ,13 , 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18};
        PictureBox ilkkutu; 
        int ilkIndeks, bulunan, deneme;
        private int yanlisEslesme = 0;
        private bool oyunTamamlandi = false;

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo - 1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = null;
                kutu.Image = null;

                if (ilkIndeks == indeksNo)
                {
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    bulunan++;


                    if (bulunan == 36)
                    {
                        bulunan = 0;
                        deneme = 0;
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;

                        }
                    }
                }
                else
                {
                    yanlisEslesme++;

                    if (yanlisEslesme % 5 == 0)
                    {
                        if (yanlisEslesme / 5 == 1)
                        {
                            if (Controls.Contains(can1))
                            {
                                Controls.Remove(can1);
                            }
                        }
                        else if (yanlisEslesme / 5 == 2)
                        {
                            if (Controls.Contains(can2))
                            {
                                Controls.Remove(can2);
                            }
                        }
                        else if (yanlisEslesme / 5 == 3)
                        {
                            if (Controls.Contains(can3))
                            {
                                Controls.Remove(can3);
                                oyunTamamlandi = true;
                            }
                        }
                    }

                    if (oyunTamamlandi)
                    {

                        this.Hide(); // Mevcut formu gizle
                        oyunbitti3 yen = new oyunbitti3();
                        yen.Show(); // Hed
                        //Application.Exit();
                        // Oyun tamamlandı, burada yapılması gereken işlemleri gerçekleştirin
                        // Örneğin, bir mesaj gösterip oyunu yeniden başlatabilirsiniz
                    }

                    ilkkutu = null;
                }
            }
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
        public zor()
        {
            InitializeComponent();
            mixingpicture();
            pictureBox37.Controls.Add(close); //pictureBox17 arkaplan olan
            close.BackColor = Color.Transparent;
            pictureBox37.Controls.Add(minimized); //pictureBox17 arkaplan olan
            minimized.BackColor = Color.Transparent;
        }
        private void mixingpicture()
        {
            Random rnd = new Random();
            for (int i = 0; i < 36; i++)
            {
                int sayi = rnd.Next(36);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }

    }
}
