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
    public partial class Kolmekymmentäneljä : Form
    {
        public List<PictureBox> Korttilista = new List<PictureBox>();
        Random random = new Random();

        Aloitus A;
        public Kolmekymmentäneljä(Aloitus A)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //staattinen peliruudun koko 
            this.A = A;
            tsslP1.Text = A.tbPelaaja1.Text;
            A.btnAloita.Enabled = false;
            tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Bold); //Pelaaja 1 aloitaa, joten korostetaan pelaajan nimeä sen hahmottamiseksi 

            if (A.tbPelaaja2.Text.Length != 0) //jos pelaaja 2 on olemassa 
                tsslP2.Text = A.tbPelaaja2.Text;


            Korttilista.Add(pb34_1);
            Korttilista.Add(pb34_2);
            Korttilista.Add(pb34_3);
            Korttilista.Add(pb34_4);
            Korttilista.Add(pb34_5);
            Korttilista.Add(pb34_6);
            Korttilista.Add(pb34_7);
            Korttilista.Add(pb34_8);
            Korttilista.Add(pb34_9);
            Korttilista.Add(pb34_10);
            Korttilista.Add(pb34_11);
            Korttilista.Add(pb34_12);
            Korttilista.Add(pb34_13);
            Korttilista.Add(pb34_14);
            Korttilista.Add(pb34_15);
            Korttilista.Add(pb34_16);
            Korttilista.Add(pb34_17);
            Korttilista.Add(pb34_18);
            Korttilista.Add(pb34_19);
            Korttilista.Add(pb34_20);
            Korttilista.Add(pb34_21);
            Korttilista.Add(pb34_22);
            Korttilista.Add(pb34_23);
            Korttilista.Add(pb34_24);
            Korttilista.Add(pb34_25);
            Korttilista.Add(pb34_26);
            Korttilista.Add(pb34_27);
            Korttilista.Add(pb34_28);
            Korttilista.Add(pb34_29);
            Korttilista.Add(pb34_30);
            Korttilista.Add(pb34_31);
            Korttilista.Add(pb34_32);
            Korttilista.Add(pb34_33);
            Korttilista.Add(pb34_34);


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

        public int[] arvotut = new int[34]; //katsotaan tätä kautta onko samaa numeroa jo arvottu 
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

            for (int i = 0; i < 34; i++)
            {
                arvotut[i] = 99;
            }

            int arvottu;

            //arvonta, ja katsotaan että jokainen arvottu imagelistin indeksi esiintyy vain kerran 

            for (int i = 0; i < 34; i++)
            {
                arvottu = random.Next(34);

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

                pb34_1.Image = imageList1.Images[arvotut[0]];
                pb34_2.Image = imageList1.Images[arvotut[1]];
                pb34_3.Image = imageList1.Images[arvotut[2]];
                pb34_4.Image = imageList1.Images[arvotut[3]];
                pb34_5.Image = imageList1.Images[arvotut[4]];
                pb34_6.Image = imageList1.Images[arvotut[5]];
                pb34_7.Image = imageList1.Images[arvotut[6]];
                pb34_8.Image = imageList1.Images[arvotut[7]];
                pb34_9.Image = imageList1.Images[arvotut[8]];
                pb34_10.Image = imageList1.Images[arvotut[9]];
                pb34_11.Image = imageList1.Images[arvotut[10]];
                pb34_12.Image = imageList1.Images[arvotut[11]];
                pb34_13.Image = imageList1.Images[arvotut[12]];
                pb34_14.Image = imageList1.Images[arvotut[13]];
                pb34_15.Image = imageList1.Images[arvotut[14]];
                pb34_16.Image = imageList1.Images[arvotut[15]];
                pb34_17.Image = imageList1.Images[arvotut[16]];
                pb34_18.Image = imageList1.Images[arvotut[17]];
                pb34_19.Image = imageList1.Images[arvotut[18]];
                pb34_20.Image = imageList1.Images[arvotut[19]];
                pb34_21.Image = imageList1.Images[arvotut[20]];
                pb34_22.Image = imageList1.Images[arvotut[21]];
                pb34_23.Image = imageList1.Images[arvotut[22]];
                pb34_24.Image = imageList1.Images[arvotut[23]];
                pb34_25.Image = imageList1.Images[arvotut[24]];
                pb34_26.Image = imageList1.Images[arvotut[25]];
                pb34_27.Image = imageList1.Images[arvotut[26]];
                pb34_28.Image = imageList1.Images[arvotut[27]];
                pb34_29.Image = imageList1.Images[arvotut[28]];
                pb34_30.Image = imageList1.Images[arvotut[29]];
                pb34_31.Image = imageList1.Images[arvotut[30]];
                pb34_32.Image = imageList1.Images[arvotut[31]];
                pb34_33.Image = imageList1.Images[arvotut[32]];
                pb34_34.Image = imageList1.Images[arvotut[33]];

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

        private void pb34_Click_1(object sender, EventArgs e)
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
            if (arvaukset == 17)
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
            pb34_1.Image = Properties.Resources.pelikortti;
            pb34_2.Image = Properties.Resources.pelikortti;
            pb34_3.Image = Properties.Resources.pelikortti;
            pb34_4.Image = Properties.Resources.pelikortti;
            pb34_5.Image = Properties.Resources.pelikortti;
            pb34_6.Image = Properties.Resources.pelikortti;
            pb34_7.Image = Properties.Resources.pelikortti;
            pb34_8.Image = Properties.Resources.pelikortti;
            pb34_9.Image = Properties.Resources.pelikortti;
            pb34_10.Image = Properties.Resources.pelikortti;
            pb34_11.Image = Properties.Resources.pelikortti;
            pb34_12.Image = Properties.Resources.pelikortti;
            pb34_13.Image = Properties.Resources.pelikortti;
            pb34_14.Image = Properties.Resources.pelikortti;
            pb34_15.Image = Properties.Resources.pelikortti;
            pb34_16.Image = Properties.Resources.pelikortti;
            pb34_17.Image = Properties.Resources.pelikortti;
            pb34_18.Image = Properties.Resources.pelikortti;
            pb34_19.Image = Properties.Resources.pelikortti;
            pb34_20.Image = Properties.Resources.pelikortti;
            pb34_21.Image = Properties.Resources.pelikortti;
            pb34_22.Image = Properties.Resources.pelikortti;
            pb34_23.Image = Properties.Resources.pelikortti;
            pb34_24.Image = Properties.Resources.pelikortti;
            pb34_25.Image = Properties.Resources.pelikortti;
            pb34_26.Image = Properties.Resources.pelikortti;
            pb34_27.Image = Properties.Resources.pelikortti;
            pb34_28.Image = Properties.Resources.pelikortti;
            pb34_29.Image = Properties.Resources.pelikortti;
            pb34_30.Image = Properties.Resources.pelikortti;
            pb34_31.Image = Properties.Resources.pelikortti;
            pb34_32.Image = Properties.Resources.pelikortti;
            pb34_33.Image = Properties.Resources.pelikortti;
            pb34_34.Image = Properties.Resources.pelikortti;


            pb34_1.Enabled = true;
            pb34_2.Enabled = true;
            pb34_3.Enabled = true;
            pb34_4.Enabled = true;
            pb34_5.Enabled = true;
            pb34_6.Enabled = true;
            pb34_7.Enabled = true;
            pb34_8.Enabled = true;
            pb34_9.Enabled = true;
            pb34_10.Enabled = true;
            pb34_11.Enabled = true;
            pb34_12.Enabled = true;
            pb34_13.Enabled = true;
            pb34_14.Enabled = true;
            pb34_15.Enabled = true;
            pb34_16.Enabled = true;
            pb34_17.Enabled = true;
            pb34_18.Enabled = true;
            pb34_19.Enabled = true;
            pb34_20.Enabled = true;
            pb34_21.Enabled = true;
            pb34_22.Enabled = true;
            pb34_23.Enabled = true;
            pb34_24.Enabled = true;
            pb34_25.Enabled = true;
            pb34_26.Enabled = true;
            pb34_27.Enabled = true;
            pb34_28.Enabled = true;
            pb34_29.Enabled = true;
            pb34_30.Enabled = true;
            pb34_31.Enabled = true;
            pb34_32.Enabled = true;
            pb34_33.Enabled = true;
            pb34_34.Enabled = true;

            btnAloita.Visible = false;
            btnAloita.Enabled = false;

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

        private void pb34_1_Click(object sender, EventArgs e)
        {
            pb34_1.Image = imageList1.Images[arvotut[0]];
            pb34_Click_1(sender, e);
        }

        private void pb34_2_Click(object sender, EventArgs e)
        {
            pb34_2.Image = imageList1.Images[arvotut[1]];
            pb34_Click_1(sender, e);
        }

        private void pb34_3_Click(object sender, EventArgs e)
        {
            pb34_3.Image = imageList1.Images[arvotut[2]];
            pb34_Click_1(sender, e);
        }

        private void pb34_4_Click(object sender, EventArgs e)
        {
            pb34_4.Image = imageList1.Images[arvotut[3]];
            pb34_Click_1(sender, e);
        }

        private void pb34_5_Click(object sender, EventArgs e)
        {
            pb34_5.Image = imageList1.Images[arvotut[4]];
            pb34_Click_1(sender, e);
        }

        private void pb34_6_Click(object sender, EventArgs e)
        {
            pb34_6.Image = imageList1.Images[arvotut[5]];
            pb34_Click_1(sender, e);
        }

        private void pb34_7_Click(object sender, EventArgs e)
        {
            pb34_7.Image = imageList1.Images[arvotut[6]];
            pb34_Click_1(sender, e);
        }

        private void pb34_8_Click(object sender, EventArgs e)
        {
            pb34_8.Image = imageList1.Images[arvotut[7]];
            pb34_Click_1(sender, e);
        }

        private void pb34_9_Click(object sender, EventArgs e)
        {
            pb34_9.Image = imageList1.Images[arvotut[8]];
            pb34_Click_1(sender, e);
        }

        private void pb34_10_Click(object sender, EventArgs e)
        {
            pb34_10.Image = imageList1.Images[arvotut[9]];
            pb34_Click_1(sender, e);
        }

        private void pb34_11_Click(object sender, EventArgs e)
        {
            pb34_11.Image = imageList1.Images[arvotut[10]];
            pb34_Click_1(sender, e);
        }

        private void pb34_12_Click(object sender, EventArgs e)
        {
            pb34_12.Image = imageList1.Images[arvotut[11]];
            pb34_Click_1(sender, e);
        }

        private void pb34_13_Click(object sender, EventArgs e)
        {
            pb34_13.Image = imageList1.Images[arvotut[12]];
            pb34_Click_1(sender, e);
        }

        private void pb34_14_Click(object sender, EventArgs e)
        {
            pb34_14.Image = imageList1.Images[arvotut[13]];
            pb34_Click_1(sender, e);
        }

        private void pb34_15_Click(object sender, EventArgs e)
        {
            pb34_15.Image = imageList1.Images[arvotut[14]];
            pb34_Click_1(sender, e);
        }

        private void pb34_16_Click(object sender, EventArgs e)
        {
            pb34_16.Image = imageList1.Images[arvotut[15]];
            pb34_Click_1(sender, e);
        }

        private void pb34_17_Click(object sender, EventArgs e)
        {
            pb34_17.Image = imageList1.Images[arvotut[16]];
            pb34_Click_1(sender, e);
        }

        private void pb34_18_Click(object sender, EventArgs e)
        {
            pb34_18.Image = imageList1.Images[arvotut[17]];
            pb34_Click_1(sender, e);
        }

        private void pb34_19_Click(object sender, EventArgs e)
        {
            pb34_19.Image = imageList1.Images[arvotut[18]];
            pb34_Click_1(sender, e);
        }

        private void pb34_20_Click(object sender, EventArgs e)
        {
            pb34_20.Image = imageList1.Images[arvotut[19]];
            pb34_Click_1(sender, e);
        }

        private void pb34_21_Click(object sender, EventArgs e)
        {
            pb34_21.Image = imageList1.Images[arvotut[20]];
            pb34_Click_1(sender, e);
        }

        private void pb34_22_Click(object sender, EventArgs e)
        {
            pb34_22.Image = imageList1.Images[arvotut[21]];
            pb34_Click_1(sender, e);
        }

        private void pb34_23_Click(object sender, EventArgs e)
        {
            pb34_23.Image = imageList1.Images[arvotut[22]];
            pb34_Click_1(sender, e);
        }

        private void pb34_24_Click(object sender, EventArgs e)
        {
            pb34_24.Image = imageList1.Images[arvotut[23]];
            pb34_Click_1(sender, e);
        }

        private void pb34_25_Click(object sender, EventArgs e)
        {
            pb34_25.Image = imageList1.Images[arvotut[24]];
            pb34_Click_1(sender, e);
        }

        private void pb34_26_Click(object sender, EventArgs e)
        {
            pb34_26.Image = imageList1.Images[arvotut[25]];
            pb34_Click_1(sender, e);
        }

        private void pb34_27_Click(object sender, EventArgs e)
        {
            pb34_27.Image = imageList1.Images[arvotut[26]];
            pb34_Click_1(sender, e);
        }

        private void pb34_28_Click(object sender, EventArgs e)
        {
            pb34_28.Image = imageList1.Images[arvotut[27]];
            pb34_Click_1(sender, e);
        }

        private void pb34_29_Click(object sender, EventArgs e)
        {
            pb34_29.Image = imageList1.Images[arvotut[28]];
            pb34_Click_1(sender, e);
        }

        private void pb34_30_Click(object sender, EventArgs e)
        {
            pb34_30.Image = imageList1.Images[arvotut[29]];
            pb34_Click_1(sender, e);
        }

        private void pb34_31_Click(object sender, EventArgs e)
        {
            pb34_31.Image = imageList1.Images[arvotut[30]];
            pb34_Click_1(sender, e);
        }

        private void pb34_32_Click(object sender, EventArgs e)
        {
            pb34_32.Image = imageList1.Images[arvotut[31]];
            pb34_Click_1(sender, e);
        }

        private void pb34_33_Click(object sender, EventArgs e)
        {
            pb34_33.Image = imageList1.Images[arvotut[32]];
            pb34_Click_1(sender, e);
        }

        private void pb34_34_Click(object sender, EventArgs e)
        {
            pb34_34.Image = imageList1.Images[arvotut[33]];
            pb34_Click_1(sender, e);
        }

        private void Kolmekymmentäneljä_FormClosed(object sender, FormClosedEventArgs e)
        {
            A.btnAloita.Enabled = true;
        }
    }
}
