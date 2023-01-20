using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harkkatyö_Ohj2
{
    public partial class Neljätoista : Form
    {

        public List<PictureBox> Korttilista = new List<PictureBox>();
        Random random = new Random();

        Aloitus A;
        public Neljätoista(Aloitus A)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //staattinen peliruudun koko
            this.A = A;
            tsslP1.Text = A.tbPelaaja1.Text;
            A.btnAloita.Enabled = false;
            tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Bold); //Pelaaja 1 aloitaa, joten korostetaan pelaajan nimeä sen hahmottamiseksi

            if (A.tbPelaaja2.Text.Length != 0) //jos pelaaja 2 on olemassa
                tsslP2.Text = A.tbPelaaja2.Text;


            Korttilista.Add(pb14_1);
            Korttilista.Add(pb14_2);
            Korttilista.Add(pb14_3);
            Korttilista.Add(pb14_4);
            Korttilista.Add(pb14_5);
            Korttilista.Add(pb14_6);
            Korttilista.Add(pb14_7);
            Korttilista.Add(pb14_8);
            Korttilista.Add(pb14_9);
            Korttilista.Add(pb14_10);
            Korttilista.Add(pb14_11);
            Korttilista.Add(pb14_12);
            Korttilista.Add(pb14_13);
            Korttilista.Add(pb14_14);
            


            if (A.rbHelppo.Checked == true)
            {
                vaikeustaso = "helppo";
                //mikäli vaikeustaso on helppo: ei pystytä koskemaan kortteihin, ennen kuin peli alkaa/"Aloita" -nappia on painettu
                for (int i = 0; i < Korttilista.Count; i++)
                {
                    Korttilista[i].Enabled = false;
                }
            }
            else if (A.rbKeskivaikea.Checked == true)
            {
                vaikeustaso = "keskivaikea";
            }
            else
            {
                vaikeustaso = "vaikea";
            }

            //kutsutaan arpomisfunktiota   
            Arpominen();
        }

        public int[] arvotut = new int[14]; //katsotaan tätä kautta onko samaa numeroa jo arvottu
        public int laskuri1 = 0;
        public int laskuri2 = 0;
        public PictureBox ekaclikki;
        public PictureBox tokaclikki;
        public PictureBox loydetty1;
        public PictureBox loydetty2;

        public int x = 1;

        //tilastointia varten
        public string vaikeustaso;
        bool tasapeli = false;


        private void Arpominen()
        {
            //alustetaan arvottujen indeksienlista


            for (int i = 0; i < 14; i++)
            {
                arvotut[i] = 99;
            }

            int arvottu;

            //arvonta, ja katsotaan että jokainen arvottu imagelistin indeksi esiintyy vain kerran

            for (int i = 0; i < 14; i++)
            {
                arvottu = random.Next(14);
                if (!arvotut.Contains(arvottu))
                {
                    arvotut[i] = arvottu;
                }

                else
                {
                    i--;
                }
            }

            if (vaikeustaso == "helppo")
            {
                btnAloita.Visible = true;
                btnAloita.Enabled = true;
                gameTimer.Interval = 1000;
                clickkiTimer.Interval = 1100;

                pb14_1.Image = imageList1.Images[arvotut[0]];
                pb14_2.Image = imageList1.Images[arvotut[1]];
                pb14_3.Image = imageList1.Images[arvotut[2]];
                pb14_4.Image = imageList1.Images[arvotut[3]];
                pb14_5.Image = imageList1.Images[arvotut[4]];
                pb14_6.Image = imageList1.Images[arvotut[5]];
                pb14_7.Image = imageList1.Images[arvotut[6]];
                pb14_8.Image = imageList1.Images[arvotut[7]];
                pb14_9.Image = imageList1.Images[arvotut[8]];
                pb14_10.Image = imageList1.Images[arvotut[9]];
                pb14_11.Image = imageList1.Images[arvotut[10]];
                pb14_12.Image = imageList1.Images[arvotut[11]];
                pb14_13.Image = imageList1.Images[arvotut[12]];
                pb14_14.Image = imageList1.Images[arvotut[13]];
                
            }

            else if (vaikeustaso == "keskivaikea")
            {
                btnAloita.Visible = false;
                btnAloita.Enabled = false;
                gameTimer.Interval = 1000;
                clickkiTimer.Interval = 1100;
            }

            else
            {
                btnAloita.Visible = false;
                btnAloita.Enabled = false;
                gameTimer.Interval = 500;
                clickkiTimer.Interval = 600;

            }
        }


        private void pb14_Click_1(object sender, EventArgs e)
        {

            PictureBox klikattu_pb = sender as PictureBox;

            if (klikattu_pb == null)
                return; //jos senderin kääntäminen pictureboxiksi ei onnistu

            //falsetetaan kuvat kun painetaan, jotta ei voi klikata uudestaan. 
            //HUOM! Jos kuvapari väärin, enabloidaan uudestaan. Jos oikein, jätetään falseksi

            if (ekaclikki == null)
            {
                ekaclikki = klikattu_pb;
                loydetty1 = klikattu_pb;
                ekaclikki.Enabled = false;

                return;
            }

            tokaclikki = klikattu_pb;
            loydetty2 = klikattu_pb;
            tokaclikki.Enabled = false;

            for (int i = 0; i < Korttilista.Count; i++)
            {
                Korttilista[i].Enabled = false;
            }

            clickkiTimer.Start();

            List<bool> iHash1 = GetHash(new Bitmap(ekaclikki.Image));
            List<bool> iHash2 = GetHash(new Bitmap(tokaclikki.Image));

            //Verrataan samojen pikselien määrää (max=256)
            int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);


            if (equalElements == 256)
            {
                if (tsslP2.Text.Length != 0) //jos pelaaja 2 on olemassa
                {
                    if (x % 2 == 1) //Pelaaja 1 pisteet
                    {
                        laskuri1++;
                        tsslP1.Text = A.tbPelaaja1.Text + " " + laskuri1;
                    }

                    else if (x % 2 == 0) //pelaaja 2 pisteet
                    {
                        laskuri2++;
                        tsslP2.Text = A.tbPelaaja2.Text + " " + laskuri2;
                    }
                }

                else //jos yksinpeli
                {
                    laskuri1++;
                    tsslP1.Text = A.tbPelaaja1.Text + " " + laskuri1;
                }

                ekaclikki = null;
                tokaclikki = null;
            }

            else
            {
                loydetty1 = null;
                loydetty2 = null;
                gameTimer.Start(); //Tämä timeri määrää kuinka pitkään kortit näkyvät klikkauksen jälkeen!
                x++;

                if (x % 2 != 0)//Korostetaan sitä pelaajaa, kenen vuoro on
                {
                    tsslP2.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                else if (x % 2 == 0)
                {
                    if (tsslP2.Text.Length != 0)//korostetaan pelaaja 2:n nimeä tarvittaessa vain, jos kyseessä on kaksinpeli
                    {
                        tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                        tsslP2.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                }
            }

            //Tämä messagebox on pelin jälkeen ilmestyvä dialogi joka mahdollistaa uudelleen pelaamisen
            MessageBoxButtons napit = MessageBoxButtons.YesNo;
            DialogResult uudestaan;
            Henkilo voittaja = new Henkilo();
            Henkilo haviaja = new Henkilo();
            int arvaukset = 0;

            arvaukset = laskuri1 + laskuri2;
            if (arvaukset == 7)
            {
                if (laskuri1 > laskuri2)//voittaja on pelaaja 1
                {
                    uudestaan = MessageBox.Show(A.tbPelaaja1.Text + " on voittaja! \nUusi peli?", "Onneksi olkoon!", napit);

                    if (A.tbPelaaja2.Text != "")//jos pelattiin kaksinpeliä, niin tilastoidaan. Otetaan huomioon vain täällä, koska yksinpelissä käytetään vain laskuria 1
                    {
                        voittaja.Nimi = A.tbPelaaja1.Text;
                        haviaja.Nimi = A.tbPelaaja2.Text;
                        voittaja.Tilastointi(voittaja, haviaja, vaikeustaso, tasapeli);
                    }
                }

                else if (laskuri1 < laskuri2)//voittaja on pelaaja 2
                {
                    uudestaan = MessageBox.Show(A.tbPelaaja2.Text + " on voittaja! \nUusi peli?", "Onneksi olkoon!", napit);

                    voittaja.Nimi = A.tbPelaaja2.Text;
                    haviaja.Nimi = A.tbPelaaja1.Text;
                    voittaja.Tilastointi(voittaja, haviaja, vaikeustaso, tasapeli);
                }

                else//tasapeli
                {
                    uudestaan = MessageBox.Show("Tuli tasapeli! \nUusi peli?", "Onneksi olkoon!", napit);

                    tasapeli = true;
                    voittaja.Nimi = A.tbPelaaja2.Text; //oikeasti kumpikin voittaa, näillä viedään vain tiedot Henkilo olioon
                    haviaja.Nimi = A.tbPelaaja1.Text;
                    voittaja.Tilastointi(voittaja, haviaja, vaikeustaso, tasapeli);
                }

                if (uudestaan == DialogResult.Yes)
                {

                    Arpominen();


                    if (vaikeustaso == "keskivaikea" || vaikeustaso == "vaikea")
                        btnAloita_Click(sender, e);

                    //Nollataan laskurit ja muut peliin vaikuttavat tekijät
                    laskuri1 = 0;
                    tsslP1.Text = A.tbPelaaja1.Text;
                    laskuri2 = 0;
                    tsslP2.Text = A.tbPelaaja2.Text;
                    voittaja = null;
                    haviaja = null;
                    tasapeli = false;
                }
                else
                {
                    A.btnAloita.Enabled = true;
                    this.Close(); //palaa aloitussivulle
                }
            }
        }


        private void btnAloita_Click(object sender, EventArgs e)
        {
            pb14_1.Image = Properties.Resources.pelikortti;
            pb14_2.Image = Properties.Resources.pelikortti;
            pb14_3.Image = Properties.Resources.pelikortti;
            pb14_4.Image = Properties.Resources.pelikortti;
            pb14_5.Image = Properties.Resources.pelikortti;
            pb14_6.Image = Properties.Resources.pelikortti;
            pb14_7.Image = Properties.Resources.pelikortti;
            pb14_8.Image = Properties.Resources.pelikortti;
            pb14_9.Image = Properties.Resources.pelikortti;
            pb14_10.Image = Properties.Resources.pelikortti;
            pb14_11.Image = Properties.Resources.pelikortti;
            pb14_12.Image = Properties.Resources.pelikortti;
            pb14_13.Image = Properties.Resources.pelikortti;
            pb14_14.Image = Properties.Resources.pelikortti;
            

            pb14_1.Enabled = true;
            pb14_2.Enabled = true;
            pb14_3.Enabled = true;
            pb14_4.Enabled = true;
            pb14_5.Enabled = true;
            pb14_6.Enabled = true;
            pb14_7.Enabled = true;
            pb14_8.Enabled = true;
            pb14_9.Enabled = true;
            pb14_10.Enabled = true;
            pb14_11.Enabled = true;
            pb14_12.Enabled = true;
            pb14_13.Enabled = true;
            pb14_14.Enabled = true;

            btnAloita.Visible = false;
            btnAloita.Enabled = false;

            //Yritettiin tehdä sama asia loopin kautta, mutta tuli bugeja -> siksi manuaalinen toteutus
        }


        /*Täällä muutetaan kuvakoko & värit vertailua varten*/


        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //luodaan uusi kuva koossa 16x16 pikseliä
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //vaihdetaan värit mustavalkoiseksi josta erotellaan mustat (true) ja valkoiset (false) pikselit        
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gameTimer.Stop();

            ekaclikki.Enabled = true;
            ekaclikki.Image = Properties.Resources.pelikortti;
            ekaclikki = null;
            tokaclikki.Enabled = true;
            tokaclikki.Image = Properties.Resources.pelikortti;
            tokaclikki = null;
        }


        private void clickkiTimer_Tick(object sender, EventArgs e)
        {
            clickkiTimer.Stop();

            if (loydetty1 != null)
            {
                for (int i = 0; i < Korttilista.Count; i++)
                {
                    if (Korttilista[i] == loydetty1)
                    {
                        Korttilista.RemoveAt(i);
                    }
                    else if (Korttilista[i] == loydetty2)
                    {
                        Korttilista.RemoveAt(i);
                    }
                }
            }

            for (int i = 0; i < Korttilista.Count; i++)
            {

                if (Korttilista[i].Image == Properties.Resources.pelikortti)
                {
                    Korttilista[i].Enabled = false;
                }
                else
                    Korttilista[i].Enabled = true;
            }
        }


        private void pb14_1_Click(object sender, EventArgs e)
        {
            pb14_1.Image = imageList1.Images[arvotut[0]];
            pb14_Click_1(sender, e);
        }

        private void pb14_2_Click(object sender, EventArgs e)
        {
            pb14_2.Image = imageList1.Images[arvotut[1]];
            pb14_Click_1(sender, e);
        }

        private void pb14_3_Click(object sender, EventArgs e)
        {
            pb14_3.Image = imageList1.Images[arvotut[2]];
            pb14_Click_1(sender, e);
        }

        private void pb14_4_Click(object sender, EventArgs e)
        {
            pb14_4.Image = imageList1.Images[arvotut[3]];
            pb14_Click_1(sender, e);
        }

        private void pb14_5_Click(object sender, EventArgs e)
        {
            pb14_5.Image = imageList1.Images[arvotut[4]];
            pb14_Click_1(sender, e);
        }

        private void pb14_6_Click(object sender, EventArgs e)
        {
            pb14_6.Image = imageList1.Images[arvotut[5]];
            pb14_Click_1(sender, e);
        }

        private void pb14_7_Click(object sender, EventArgs e)
        {
            pb14_7.Image = imageList1.Images[arvotut[6]];
            pb14_Click_1(sender, e);
        }

        private void pb14_8_Click(object sender, EventArgs e)
        {
            pb14_8.Image = imageList1.Images[arvotut[7]];
            pb14_Click_1(sender, e);
        }

        private void pb14_9_Click(object sender, EventArgs e)
        {
            pb14_9.Image = imageList1.Images[arvotut[8]];
            pb14_Click_1(sender, e);
        }

        private void pb14_10_Click(object sender, EventArgs e)
        {
            pb14_10.Image = imageList1.Images[arvotut[9]];
            pb14_Click_1(sender, e);
        }

        private void pb14_11_Click(object sender, EventArgs e)
        {
            pb14_11.Image = imageList1.Images[arvotut[10]];
            pb14_Click_1(sender, e);
        }

        private void pb14_12_Click(object sender, EventArgs e)
        {
            pb14_12.Image = imageList1.Images[arvotut[11]];
            pb14_Click_1(sender, e);
        }

        private void pb14_13_Click(object sender, EventArgs e)
        {
            pb14_13.Image = imageList1.Images[arvotut[12]];
            pb14_Click_1(sender, e);
        }

        private void pb14_14_Click(object sender, EventArgs e)
        {
            pb14_14.Image = imageList1.Images[arvotut[13]];
            pb14_Click_1(sender, e);
        }

        private void Neljätoista_FormClosed(object sender, FormClosedEventArgs e)
        {
            A.btnAloita.Enabled = true;
        }
    }
}
