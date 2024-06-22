using BilgisayariKapatmak.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace BilgisayariKapatmak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddToStartup();
            dateTimeSaatDakikaSaniye.Format = DateTimePickerFormat.Custom; dateTimeSaatDakikaSaniye.CustomFormat = "yyyy-MM-dd HH:mm:ss"; dateTimeSaatDakikaSaniye.ShowUpDown = true;
            sayac = ayarlar.sayac*60;
            progressBar1.Maximum =Convert.ToInt32(sayac);
            progressBar1.Minimum = 0;      
        }
   
        public string appname = "myapp";
        Settings ayarlar = new Settings();
        public double sayac;
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtsifre.Text))
            {
                MessageBox.Show("Lütfen Bir Şifre Belirleyiniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            button1.Enabled = false;

            ayarlar.pass = txtsifre.Text;
            ayarlar.date = dateTimeSaatDakikaSaniye.Value;
            ayarlar.unlock = false;
            ayarlar.Save();         
            timer1.Start();
           btnAyarlar.Visible = false;
            this.Hide();
            this.ShowInTaskbar = false;
            AddToStartup();
            Temizle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AddToStartup();
            TimeSpan fark = DateTime.Now - ayarlar.date;
            if(ayarlar.date.ToString()==DateTime.Now.ToString("d.MM.yyyy HH:mm:ss") || fark.TotalSeconds > 0)
            {
                this.Show();
                this.ShowInTaskbar=true;
                labelsayac.Text=sayac.ToString();           
                progressBar1.Value =Convert.ToInt32(sayac);
                sayac--;
                if (sayac == 0)
                {
                        timer1.Stop();                      
                        ayarlar.Save();
                        System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                }
               
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimeSaatDakikaSaniye.Format = DateTimePickerFormat.Custom;
            dateTimeSaatDakikaSaniye.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimeSaatDakikaSaniye.ShowUpDown = true;
            if (!ayarlar.unlock)
            {
                timer1.Start(); 
                progressBar1.Visible=true;             
                progressBar1.Minimum = 0;
                btnAyarlar.Visible=false;
                this.Hide();
                this.ShowInTaskbar = false;
            }

        }
        private void AddToStartup()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("ShutdownApp", Application.ExecutablePath);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Başlangıçta çalıştırma eklenirken hata oluştu: " + ex.Message);
            }
        }
        private void RemoveFromStartup()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.DeleteValue("ShutdownApp", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başlangıçtan kaldırma sırasında hata oluştu: " + ex.Message);
            }
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            if (txtsifre.Text == ayarlar.pass)
            {
                RemoveFromStartup();
                timer1.Stop();
                ayarlar.pass = "";
                progressBar1.Visible = false;
                ayarlar.unlock = true;
                ayarlar.Save();
                labelsayac.Text = "TUNÇ,PEKER YAZİLİM";
                button1.Enabled = true;                       
                ayarlar.Save();
                btnAyarlar.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Doğru Şifreyi Giriniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;             
            }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            Form_Ayarlar ayar = new Form_Ayarlar();
            ayar.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!ayarlar.unlock)
            {
                Process process = new Process();
                process.StartInfo.FileName = Application.StartupPath + "\\BilgisayariKapatmak.exe";
                process.Start();
           }
        }
        private void Temizle()
        {
            txtsifre.Text = "";
        }

        private void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("tpyazilim@hotmail.com"); //Hangi mailden gidecekse.
                message.To.Add("eren.peker@hotmail.com"); // Gideceği mailler
                message.To.Add("huseyint428@gmail.com");
                message.To.Add(ayarlar.Mailadresi);
                message.Subject = "TP Yazılım";
                message.Body = $"<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional //EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n<head>\r\n<!--[if gte mso 9]>\r\n<xml>\r\n  <o:OfficeDocumentSettings>\r\n    <o:AllowPNG/>\r\n    <o:PixelsPerInch>96</o:PixelsPerInch>\r\n  </o:OfficeDocumentSettings>\r\n</xml>\r\n<![endif]-->\r\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n  <meta name=\"x-apple-disable-message-reformatting\">\r\n  <!--[if !mso]><!--><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><!--<![endif]-->\r\n  <title></title>\r\n  \r\n    <style type=\"text/css\">\r\n      @media only screen and (min-width: 620px) {{\r\n  .u-row {{\r\n    width: 600px !important;\r\n  }}\r\n  .u-row .u-col {{\r\n    vertical-align: top;\r\n  }}\r\n\r\n  .u-row .u-col-100 {{\r\n    width: 600px !important;\r\n  }}\r\n\r\n}}\r\n\r\n@media (max-width: 620px) {{\r\n  .u-row-container {{\r\n    max-width: 100% !important;\r\n    padding-left: 0px !important;\r\n    padding-right: 0px !important;\r\n  }}\r\n  .u-row .u-col {{\r\n    min-width: 320px !important;\r\n    max-width: 100% !important;\r\n    display: block !important;\r\n  }}\r\n  .u-row {{\r\n    width: 100% !important;\r\n  }}\r\n  .u-col {{\r\n    width: 100% !important;\r\n  }}\r\n  .u-col > div {{\r\n    margin: 0 auto;\r\n  }}\r\n}}\r\nbody {{\r\n  margin: 0;\r\n  padding: 0;\r\n}}\r\n\r\ntable,\r\ntr,\r\ntd {{\r\n  vertical-align: top;\r\n  border-collapse: collapse;\r\n}}\r\n\r\np {{\r\n  margin: 0;\r\n}}\r\n\r\n.ie-container table,\r\n.mso-container table {{\r\n  table-layout: fixed;\r\n}}\r\n\r\n* {{\r\n  line-height: inherit;\r\n}}\r\n\r\na[x-apple-data-detectors='true'] {{\r\n  color: inherit !important;\r\n  text-decoration: none !important;\r\n}}\r\n\r\ntable, td {{ color: #000000; }} #u_body a {{ color: #0000ee; text-decoration: underline; }} @media (max-width: 480px) {{ #u_row_1 .v-row-background-image--inner {{ background-position: center center !important; background-repeat: no-repeat !important; }} #u_row_1 .v-row-background-image--outer {{ background-position: center center !important; background-repeat: no-repeat !important; }} #u_row_1.v-row-background-image--outer {{ background-position: center center !important; background-repeat: no-repeat !important; }} #u_content_text_1 .v-container-padding-padding {{ padding: 40px 10px 0px !important; }} #u_content_text_1 .v-font-size {{ font-size: 27px !important; }} #u_content_text_2 .v-font-size {{ font-size: 46px !important; }} #u_content_button_1 .v-container-padding-padding {{ padding: 10px 10px 40px !important; }} #u_content_button_1 .v-size-width {{ width: 65% !important; }} }}\r\n    </style>\r\n  \r\n  \r\n\r\n<!--[if !mso]><!--><link href=\"https://fonts.googleapis.com/css?family=Raleway:400,700&display=swap\" rel=\"stylesheet\" type=\"text/css\"><link href=\"https://fonts.googleapis.com/css2?family=Anton&display=swap\" rel=\"stylesheet\" type=\"text/css\"><!--<![endif]-->\r\n\r\n</head>\r\n\r\n<body class=\"clean-body u_body\" style=\"margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #ecf0f1;color: #000000\">\r\n  <!--[if IE]><div class=\"ie-container\"><![endif]-->\r\n  <!--[if mso]><div class=\"mso-container\"><![endif]-->\r\n  <table id=\"u_body\" style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #ecf0f1;width:100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n  <tbody>\r\n  <tr style=\"vertical-align: top\">\r\n    <td style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top\">\r\n    <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #ecf0f1;\"><![endif]-->\r\n    \r\n  \r\n  \r\n    <!--[if gte mso 9]>\r\n      <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"margin: 0 auto;min-width: 320px;max-width: 600px;\">\r\n        <tr>\r\n          <td background=\"https://cdn.templates.unlayer.com/assets/1707995257001-1.png\" valign=\"top\" width=\"100%\">\r\n      <v:rect xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"true\" stroke=\"false\" style=\"width: 600px;\">\r\n        <v:fill type=\"frame\" src=\"https://cdn.templates.unlayer.com/assets/1707995257001-1.png\" /><v:textbox style=\"mso-fit-shape-to-text:true\" inset=\"0,0,0,0\">\r\n      <![endif]-->\r\n  \r\n<div id=\"u_row_1\" class=\"u-row-container v-row-background-image--outer\" style=\"padding: 0px;background-image: url('https://i.hizliresim.com/cych88p.png');background-repeat: no-repeat;background-position: center top;background-color: transparent\">\r\n  <div class=\"u-row\" style=\"margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;\">\r\n    <div class=\"v-row-background-image--inner\" style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">\r\n      <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td class=\"v-row-background-image--outer\" style=\"padding: 0px;background-image: url('images/image-1.png');background-repeat: no-repeat;background-position: center top;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr class=\"v-row-background-image--inner\" style=\"background-color: transparent;\"><![endif]-->\r\n      \r\n<!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\" valign=\"top\"><![endif]-->\r\n<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">\r\n  <div style=\"height: 100%;width: 100% !important;\">\r\n  <!--[if (!mso)&(!IE)]><!--><div style=\"box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><!--<![endif]-->\r\n  \r\n<table id=\"u_content_text_1\" style=\"font-family:'Raleway',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\r\n  <tbody>\r\n    <tr>\r\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:71px 10px 0px;font-family:'Raleway',sans-serif;\" align=\"left\">\r\n        \r\n  <div class=\"v-font-size\" style=\"font-size: 28px; color: #a3a3ce; line-height: 140%; text-align: center; word-wrap: break-word;\">\r\n    <p style=\"line-height: 140%;\"><span data-metadata=\"&lt;!--(figmeta)eyJmaWxlS2V5IjoiTTRKVHp2RDIzZThXaUlzbXBxYWxndCIsInBhc3RlSUQiOjQ5MzQxNzY1MiwiZGF0YVR5cGUiOiJzY2VuZSJ9Cg==(/figmeta)--&gt;\" style=\"line-height: 39.2px;\"></span>TP YAZILIM</p>\r\n  </div>\r\n\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>\r\n\r\n<table id=\"u_content_text_2\" style=\"font-family:'Raleway',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\r\n  <tbody>\r\n    <tr>\r\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:0px 10px;font-family:'Raleway',sans-serif;\" align=\"left\">\r\n        \r\n  <div class=\"v-font-size\" style=\"font-family: Anton; font-size: 71px; font-weight: 400; color: #eb2f32; line-height: 120%; text-align: center; word-wrap: break-word;\">\r\n    <p style=\"line-height: 120%;\">BİLGİSAYARIN GÜVENDE</p>\r\n  </div>\r\n\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>\r\n\r\n<table id=\"u_content_button_1\" style=\"font-family:'Raleway',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\r\n  <tbody>\r\n    <tr>\r\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Raleway',sans-serif;\" align=\"left\">\r\n        \r\n  <!--[if mso]><style>.v-button {{background: transparent !important;}}</style><![endif]-->\r\n<div align=\"center\">\r\n  <!--[if mso]><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr><td align=\"center\" bgcolor=\"#eb2f32\" style=\"padding:10px 20px;\" valign=\"top\"><![endif]-->\r\n    <a href=\"https://unlayer.com\" target=\"_blank\" class=\"v-button v-size-width v-font-size\" style=\"box-sizing: border-box;display: inline-block;text-decoration: none;-webkit-text-size-adjust: none;text-align: center;color: #FFFFFF; background-color: #eb2f32; border-radius: 4px;-webkit-border-radius: 4px; -moz-border-radius: 4px; width:39%; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; mso-border-alt: none;font-size: 14px;\">\r\n      <span style=\"display:block;padding:10px 20px;line-height:120%;\">{ayarlar.pass}</span>\r\n    </a>\r\n    <!--[if mso]></td></tr></table><![endif]-->\r\n</div>\r\n\r\n      </td>\r\n    </tr>\r\n  </tbody>\r\n</table>\r\n\r\n  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->\r\n  </div>\r\n</div>\r\n<!--[if (mso)|(IE)]></td><![endif]-->\r\n      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n    </div>\r\n  </div>\r\n  </div>\r\n  \r\n    <!--[if gte mso 9]>\r\n      </v:textbox></v:rect>\r\n    </td>\r\n    </tr>\r\n    </table>\r\n    <![endif]-->\r\n    \r\n\r\n\r\n  \r\n  \r\n<div class=\"u-row-container v-row-background-image--outer\" style=\"padding: 0px;background-color: transparent\">\r\n  <div class=\"u-row\" style=\"margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;\">\r\n    <div class=\"v-row-background-image--inner\" style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">\r\n      <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td class=\"v-row-background-image--outer\" style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr class=\"v-row-background-image--inner\" style=\"background-color: transparent;\"><![endif]-->\r\n      \r\n<!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"background-color: #ffffff;width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\r\n<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">\r\n  <div style=\"background-color: #ffffff;height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\">\r\n  <!--[if (!mso)&(!IE)]><!--><div style=\"box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\"><!--<![endif]-->\r\n  \r\n  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->\r\n  </div>\r\n</div>\r\n<!--[if (mso)|(IE)]></td><![endif]-->\r\n      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n    </div>\r\n  </div>\r\n  </div>\r\n  \r\n\r\n\r\n    <!--[if (mso)|(IE)]></td></tr></table><![endif]-->\r\n    </td>\r\n  </tr>\r\n  </tbody>\r\n  </table>\r\n  <!--[if mso]></div><![endif]-->\r\n  <!--[if IE]></div><![endif]-->\r\n</body>\r\n\r\n</html>"; //İÇERİK
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.office365.com"; //HOTMAİL ADRESİ
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("tpyazilim@hotmail.com", "tuncpekeryazilim??");
                client.Send(message);
                MessageBox.Show("ŞİFRENİZ MAİLİNİZE GÖNDERİLMİŞTİR.MAİLİNİZİ KONTROL EDİNİZ.", "TEBRİKLER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                File.AppendAllText("log.txt", ex.Message);
            }

        }
    }
}
