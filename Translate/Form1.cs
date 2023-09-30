using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;  // İnternet Kütüphanesini en basta ekliyoruz 


namespace Translate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool test() // Burada test adında metot oluşturdum.  Bool kullanmamıızn sebebi isteğe yanıt alıyorsa true döndürecek .
        {
            string adres = "https://www.google.com"; // Adres adlı değişkeni googleye yönlendirdim. 
            try
            {
                WebRequest istek = WebRequest.Create(adres); // Adrese gitmek için bir istek oluşturdum kapıyı çaldım burada.
                WebResponse yanit=istek.GetResponse(); // isteğine geri dönüş alabiliyor musun yanıt alabiliyor musun 
            }
            catch (Exception)
            {

                return false; // sağlmazsa false dondur.
            }
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (test())
            {
                this.Text = "Bağlanti Var"; // Çalıştırdıgım zaman ekranın sol üst köşesinde bağlantı var veya baglantı yok dıye üstte göstreiyor.
            }
            else
            {
                this.Text= "Bağlanti Yok";
            }

            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("Source").InnerText = richTextBox1.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://translate.google.com.tr/#tr/en/");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://translate.google.com.tr/#en/tr/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                richTextBox2.Text = webBrowser1.Document.GetElementById("Result_Box").InnerText;
            }
            if(radioButton2.Checked == true)
            {
                richTextBox1.Text = webBrowser1.Document.GetElementById("Result_Box").InnerText;
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("Source").InnerText = richTextBox2.Text;
        }
    }
}
