using BilgisayariKapatmak.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgisayariKapatmak
{
    public partial class Form_KullaniciGirisi : Form
    {
        public Form_KullaniciGirisi()
        {
            InitializeComponent();
        }
        Settings ayarlar = new Settings();
        private void Form_KullaniciGirisi_Load(object sender, EventArgs e)
        {

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == ayarlar.KullaniciAdi && txtSifre.Text == ayarlar.KullaniciSifre) 
            {           
              MessageBox.Show("TEBRİKLER DOĞRU GİRİŞ YAPTINIZ.","TEBRİKLER",MessageBoxButtons.OK,MessageBoxIcon.Information);
              Form1 ayar = new Form1();
              this.Hide();
              ayar.ShowDialog();
            } 
            else
            {
                MessageBox.Show("KULLANICI ADI veya ŞİFRE HATALI.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
