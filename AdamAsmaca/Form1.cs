using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayac = 0;
        String[] sehirler = { "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AMASYA", "ANKARA", "ANTALYA", "ARTVİN",
            "AYDIN", "BALIKESİR", "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR", "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM",
            "DENİZLİ", "DİYARBAKIR", "EDİRNE", "ELAZIĞ", "ERZİNCAN", "ERZURUM", "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE",
            "HAKKARİ", "HATAY", "ISPARTA", "MERSİN", "İSTANBUL", "İZMİR", "KARS", "KASTAMONU", "KAYSERİ", "KIRIKKALE", "KIRKLARELİ",
            "KIRŞEHİR", "KOCAELİ", "KONYA", "KÜTAHYA", "MALATYA", "MANİSA", "KAHRAMANMARAŞ", "MARDİN", "MUĞLA", "MUŞ", "NEVŞEHİR",
            "NİĞDE", "ORDU", "RİZE", "SAKARYA", "SAMSUN", "SİİRT", "SİNOP", "SİVAS", "TEKİRDAĞ", "TOKAT", "TRABZON", "TUNCELİ",
            "ŞANLIURFA", "UŞAK", "VAN", "YOZGAT", "ZONGULDAK", "AKSARAY", "BAYBURT", "KARAMAN", "KIRIKKALE", "BATMAN", "ŞIRNAK",
            "BARTIN", "ARDAHAN", "IĞDIR", "YALOVA", "KARABÜK", "KİLİS", "OSMANİYE" };
        String secilenKelime;
        String gizlenenSehir = "";
        
        


        private void Form1_Load(object sender, EventArgs e)
        {
            kelimeSec();
            kelimeGizle(secilenKelime);
            label3.Text = gizlenenSehir;
            label5.Text = (6 - sayac).ToString();
            resimGoster(sayac);
        }

        private void kelimeSec()
        {
            Random rnd = new Random();
            secilenKelime = sehirler[rnd.Next(sehirler.Length)];
            
        }

        private void kelimeGizle(String secilenKelime)
        {
            for(int i = 0; i< secilenKelime.Length; i++)
            {
                gizlenenSehir += "_";
            }
       
        }

        private void kelimeAc(String girilenDeger)
        {
            girilenDeger = girilenDeger.ToUpper();
            Boolean varMi = false;
            for (int i = 0; i<secilenKelime.Length; i++)
            {
                if (girilenDeger[0] == secilenKelime[i])
                {
                    char[] s = gizlenenSehir.ToCharArray();
                    s[i] = girilenDeger[0];
                    string s1 = new string(s);
                    gizlenenSehir = s1;
                    varMi = true;
                }
            }
            if (varMi == false)
            {
                sayac++;
            }
            label3.Text = gizlenenSehir;
            label5.Text = (6 - sayac).ToString();
            resimGoster(sayac);
            kontrol(sayac, gizlenenSehir);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            kelimeAc(textBox1.Text);
            textBox1.Text = "";
        }

        private void kontrol(int sayac, String gizlenenSehir)
        {
            if (!gizlenenSehir.Contains("_"))
            {
                oyunBitir(true);
            }
       
            if(sayac == 6)
            {
                oyunBitir(false);
            }
            
        }

        private void oyunBitir(Boolean kazandiMi)
        {
            if (kazandiMi == true)
            {
                MessageBox.Show("Tebrikler Şehiri Bildiniz");
                oyunuYenidenBaslat();
            }
            if (kazandiMi == false)
            {
                MessageBox.Show("Maalesef Kazanamadınız Tekrar Deneyin. Cevap: " + secilenKelime);
                oyunuYenidenBaslat();
            }
        }

        private void oyunuYenidenBaslat()
        {
            sayac = 0;
            kelimeSec();
            gizlenenSehir = "";
            kelimeGizle(secilenKelime);
            label5.Text = (6-sayac).ToString();
            label3.Text = gizlenenSehir;
            resimGoster(sayac);
        }

        private void resimGoster(int sayac)
        {
            pictureBox1.Load("Resim/" + sayac + ".png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
