using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using HafızaOyun;


namespace HafızaOyun
{
    internal class resimC
    {
        //internal yalnızca aynı assembly içinden erişilebilir olması durumu
        //resim açma, boyutlandırma, konumlandırma gibi işlemleri gerçekleştiren metodlar

        private PictureBox pictureBox; // PictureBox nesnesi
        private int resimGenislik;
        private int resimYukseklik;
        private int resimKonumX;
        private int resimKonumY;

        public resimC(PictureBox pictureBox, int genislik, int yukseklik, int konumX, int konumY)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox = pictureBox;
            this.resimGenislik = genislik;
            this.resimYukseklik = yukseklik;
            this.resimKonumX = konumX;
            this.resimKonumY = konumY;
        }

        public void Aç()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.png;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(dosyaYolu);
                pictureBox.Size = new Size(resimGenislik, resimYukseklik);
                pictureBox.Location = new Point(resimKonumX, resimKonumY);
            }
        }
    }
    }

