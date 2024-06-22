using BilgisayariKapatmak.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgisayariKapatmak
{
    public partial class Form_Ayarlar : Form
    {
        public Form_Ayarlar() 
        {
            InitializeComponent();
        }

        private void Form_Ayarlar_Load(object sender, EventArgs e)
        {
           Settings ayarlar = new Settings();
            textBox1.Text=ayarlar.sayac.ToString();
            textBox2.Text = ayarlar.Mailadresi;          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) >= 0.05)
            {
                Settings ayarlar = new Settings();
                ayarlar.sayac = Convert.ToDouble(textBox1.Text);
                ayarlar.Mailadresi = textBox2.Text;
                ayarlar.Save();
                MessageBox.Show("AYARLARINIZ GÜNCELLENMİŞTİR.", "TEBRİKLER");
                Process process = new Process();
                process.StartInfo.FileName = Application.StartupPath + "\\BilgisayariKapatmak.exe";
                process.Start();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Değer 0.05 veya 0.05 den büyük olmalıdır.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
           
        }
    }
}
