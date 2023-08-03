namespace HafızaOyun
{
    partial class oyunbitti2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(oyunbitti2));
            this.minimized = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.anasayfa = new System.Windows.Forms.PictureBox();
            this.sonraki_seviye = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.minimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anasayfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sonraki_seviye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // minimized
            // 
            this.minimized.BackColor = System.Drawing.Color.White;
            this.minimized.Image = ((System.Drawing.Image)(resources.GetObject("minimized.Image")));
            this.minimized.Location = new System.Drawing.Point(389, 12);
            this.minimized.Name = "minimized";
            this.minimized.Size = new System.Drawing.Size(24, 24);
            this.minimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minimized.TabIndex = 30;
            this.minimized.TabStop = false;
            this.minimized.Click += new System.EventHandler(this.minimized_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.White;
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.Location = new System.Drawing.Point(437, 12);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(24, 24);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close.TabIndex = 29;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // anasayfa
            // 
            this.anasayfa.Image = ((System.Drawing.Image)(resources.GetObject("anasayfa.Image")));
            this.anasayfa.Location = new System.Drawing.Point(134, 159);
            this.anasayfa.Name = "anasayfa";
            this.anasayfa.Size = new System.Drawing.Size(230, 57);
            this.anasayfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.anasayfa.TabIndex = 28;
            this.anasayfa.TabStop = false;
            this.anasayfa.Click += new System.EventHandler(this.anasayfa_Click);
            // 
            // sonraki_seviye
            // 
            this.sonraki_seviye.Image = ((System.Drawing.Image)(resources.GetObject("sonraki_seviye.Image")));
            this.sonraki_seviye.Location = new System.Drawing.Point(134, 260);
            this.sonraki_seviye.Name = "sonraki_seviye";
            this.sonraki_seviye.Size = new System.Drawing.Size(230, 60);
            this.sonraki_seviye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sonraki_seviye.TabIndex = 27;
            this.sonraki_seviye.TabStop = false;
            this.sonraki_seviye.Click += new System.EventHandler(this.sonraki_seviye_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(473, 349);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // oyunbitti2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 349);
            this.Controls.Add(this.minimized);
            this.Controls.Add(this.close);
            this.Controls.Add(this.anasayfa);
            this.Controls.Add(this.sonraki_seviye);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "oyunbitti2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "oyunbitti2";
            ((System.ComponentModel.ISupportInitialize)(this.minimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anasayfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sonraki_seviye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox minimized;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox anasayfa;
        private System.Windows.Forms.PictureBox sonraki_seviye;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}