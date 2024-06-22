namespace BilgisayariKapatmak
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateTimeSaatDakikaSaniye = new System.Windows.Forms.DateTimePicker();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.labelsayac = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSifremiUnuttum = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateTimeSaatDakikaSaniye
            // 
            this.dateTimeSaatDakikaSaniye.Location = new System.Drawing.Point(171, 12);
            this.dateTimeSaatDakikaSaniye.Name = "dateTimeSaatDakikaSaniye";
            this.dateTimeSaatDakikaSaniye.Size = new System.Drawing.Size(200, 20);
            this.dateTimeSaatDakikaSaniye.TabIndex = 7;
            // 
            // txtsifre
            // 
            this.txtsifre.Location = new System.Drawing.Point(249, 49);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.PasswordChar = '*';
            this.txtsifre.Size = new System.Drawing.Size(100, 20);
            this.txtsifre.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(121, 180);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(367, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "ŞİFRE :";
            // 
            // labelsayac
            // 
            this.labelsayac.AutoSize = true;
            this.labelsayac.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelsayac.ForeColor = System.Drawing.Color.Red;
            this.labelsayac.Location = new System.Drawing.Point(60, 209);
            this.labelsayac.Name = "labelsayac";
            this.labelsayac.Size = new System.Drawing.Size(125, 41);
            this.labelsayac.TabIndex = 14;
            this.labelsayac.Text = "SAYAC";
            // 
            // btnSifremiUnuttum
            // 
            this.btnSifremiUnuttum.BackColor = System.Drawing.Color.LightCoral;
            this.btnSifremiUnuttum.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSifremiUnuttum.ForeColor = System.Drawing.Color.Yellow;
            this.btnSifremiUnuttum.Image = global::BilgisayariKapatmak.Properties.Resources.forgot_password;
            this.btnSifremiUnuttum.Location = new System.Drawing.Point(336, 81);
            this.btnSifremiUnuttum.Name = "btnSifremiUnuttum";
            this.btnSifremiUnuttum.Size = new System.Drawing.Size(152, 93);
            this.btnSifremiUnuttum.TabIndex = 16;
            this.btnSifremiUnuttum.Text = "ŞİFREMİ UNUTTUM";
            this.btnSifremiUnuttum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSifremiUnuttum.UseVisualStyleBackColor = false;
            this.btnSifremiUnuttum.Click += new System.EventHandler(this.btnSifremiUnuttum_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.LightCoral;
            this.btnAyarlar.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyarlar.ForeColor = System.Drawing.Color.Yellow;
            this.btnAyarlar.Image = global::BilgisayariKapatmak.Properties.Resources.ayarlar_64;
            this.btnAyarlar.Location = new System.Drawing.Point(494, 81);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(152, 93);
            this.btnAyarlar.TabIndex = 15;
            this.btnAyarlar.Text = "AYARLAR";
            this.btnAyarlar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btniptal
            // 
            this.btniptal.BackColor = System.Drawing.Color.LightCoral;
            this.btniptal.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniptal.ForeColor = System.Drawing.Color.Yellow;
            this.btniptal.Image = global::BilgisayariKapatmak.Properties.Resources.cancel;
            this.btniptal.Location = new System.Drawing.Point(170, 81);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(155, 93);
            this.btniptal.TabIndex = 12;
            this.btniptal.Text = "GERİ SAYIMI İPTAL ET";
            this.btniptal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btniptal.UseVisualStyleBackColor = false;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Image = global::BilgisayariKapatmak.Properties.Resources.hourglass;
            this.button1.Location = new System.Drawing.Point(12, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 93);
            this.button1.TabIndex = 6;
            this.button1.Text = "GERİ SAYIMI BAŞLAT";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(658, 257);
            this.Controls.Add(this.btnSifremiUnuttum);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.labelsayac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btniptal);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.dateTimeSaatDakikaSaniye);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BİLGİSAYARINI GÜVENE AL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dateTimeSaatDakikaSaniye;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btniptal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelsayac;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnSifremiUnuttum;
    }
}

