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
    public partial class Kaksikymmentäkahdeksan : Form
    {
        public List<PictureBox> Korttilista = new List<PictureBox>();
        Random random = new Random();
 
        Aloitus A;
        public Kaksikymmentäkahdeksan(Aloitus A)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //staattinen peliruudun koko 
            this.A = A;
            tsslP1.Text = A.tbPelaaja1.Text;
            A.btnAloita.Enabled = false;
            tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Bold); //Pelaaja 1 aloitaa, joten korostetaan pelaajan nimeä sen hahmottamiseksi 

            if (A.tbPelaaja2.Text.Length != 0) //jos pelaaja 2 on olemassa 
                tsslP2.Text = A.tbPelaaja2.Text;


            Korttilista.Add(pb28_1);
            Korttilista.Add(pb28_2);
            Korttilista.Add(pb28_3);
            Korttilista.Add(pb28_4);
            Korttilista.Add(pb28_5);
            Korttilista.Add(pb28_6);
            Korttilista.Add(pb28_7);
            Korttilista.Add(pb28_8);
            Korttilista.Add(pb28_9);
            Korttilista.Add(pb28_10);
            Korttilista.Add(pb28_11);
            Korttilista.Add(pb28_12);
            Korttilista.Add(pb28_13);
            Korttilista.Add(pb28_14);
            Korttilista.Add(pb28_15);
            Korttilista.Add(pb28_16);
            Korttilista.Add(pb28_17);
            Korttilista.Add(pb28_18);
            Korttilista.Add(pb28_19);
            Korttilista.Add(pb28_20);
            Korttilista.Add(pb28_21);
            Korttilista.Add(pb28_22);
            Korttilista.Add(pb28_23);
            Korttilista.Add(pb28_24);
            Korttilista.Add(pb28_25);
            Korttilista.Add(pb28_26);
            Korttilista.Add(pb28_27);
            Korttilista.Add(pb28_28);
 

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
 
        public int[] arvotut = new int[28]; //katsotaan tätä kautta onko samaa numeroa jo arvottu 
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
            for (int i = 0; i < 28; i++)
            {
                arvotut[i] = 99;
            }

            int arvottu;
 
            //arvonta, ja katsotaan että jokainen arvottu imagelistin indeksi esiintyy vain kerran 
            for (int i = 0; i < 28; i++)
            {
                arvottu = random.Next(28);

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

 
                pb28_1.Image = imageList1.Images[arvotut[0]];
                pb28_2.Image = imageList1.Images[arvotut[1]];
                pb28_3.Image = imageList1.Images[arvotut[2]];
                pb28_4.Image = imageList1.Images[arvotut[3]];
                pb28_5.Image = imageList1.Images[arvotut[4]];
                pb28_6.Image = imageList1.Images[arvotut[5]];
                pb28_7.Image = imageList1.Images[arvotut[6]];
                pb28_8.Image = imageList1.Images[arvotut[7]];
                pb28_9.Image = imageList1.Images[arvotut[8]];
                pb28_10.Image = imageList1.Images[arvotut[9]];
                pb28_11.Image = imageList1.Images[arvotut[10]];
                pb28_12.Image = imageList1.Images[arvotut[11]];
                pb28_13.Image = imageList1.Images[arvotut[12]];
                pb28_14.Image = imageList1.Images[arvotut[13]];
                pb28_15.Image = imageList1.Images[arvotut[14]];
                pb28_16.Image = imageList1.Images[arvotut[15]];
                pb28_17.Image = imageList1.Images[arvotut[16]];
                pb28_18.Image = imageList1.Images[arvotut[17]];
                pb28_19.Image = imageList1.Images[arvotut[18]];
                pb28_20.Image = imageList1.Images[arvotut[19]];
                pb28_21.Image = imageList1.Images[arvotut[20]];
                pb28_22.Image = imageList1.Images[arvotut[21]];
                pb28_23.Image = imageList1.Images[arvotut[22]];
                pb28_24.Image = imageList1.Images[arvotut[23]];
                pb28_25.Image = imageList1.Images[arvotut[24]];
                pb28_26.Image = imageList1.Images[arvotut[25]];
                pb28_27.Image = imageList1.Images[arvotut[26]];
                pb28_28.Image = imageList1.Images[arvotut[27]];
  
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


        private void pb28_Click_1(object sender, EventArgs e) 
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

            if (arvaukset == 14)
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

            pb28_1.Image = Properties.Resources.pelikortti;
            pb28_2.Image = Properties.Resources.pelikortti;
            pb28_3.Image = Properties.Resources.pelikortti;
            pb28_4.Image = Properties.Resources.pelikortti;
            pb28_5.Image = Properties.Resources.pelikortti;
            pb28_6.Image = Properties.Resources.pelikortti;
            pb28_7.Image = Properties.Resources.pelikortti;
            pb28_8.Image = Properties.Resources.pelikortti;
            pb28_9.Image = Properties.Resources.pelikortti;
            pb28_10.Image = Properties.Resources.pelikortti;
            pb28_11.Image = Properties.Resources.pelikortti;
            pb28_12.Image = Properties.Resources.pelikortti;
            pb28_13.Image = Properties.Resources.pelikortti;
            pb28_14.Image = Properties.Resources.pelikortti;
            pb28_15.Image = Properties.Resources.pelikortti;
            pb28_16.Image = Properties.Resources.pelikortti;
            pb28_17.Image = Properties.Resources.pelikortti;
            pb28_18.Image = Properties.Resources.pelikortti;
            pb28_19.Image = Properties.Resources.pelikortti;
            pb28_20.Image = Properties.Resources.pelikortti;
            pb28_21.Image = Properties.Resources.pelikortti;
            pb28_22.Image = Properties.Resources.pelikortti;
            pb28_23.Image = Properties.Resources.pelikortti;
            pb28_24.Image = Properties.Resources.pelikortti;
            pb28_25.Image = Properties.Resources.pelikortti;
            pb28_26.Image = Properties.Resources.pelikortti;
            pb28_27.Image = Properties.Resources.pelikortti;
            pb28_28.Image = Properties.Resources.pelikortti;



            pb28_1.Enabled = true;
            pb28_2.Enabled = true;
            pb28_3.Enabled = true;
            pb28_4.Enabled = true;
            pb28_5.Enabled = true;
            pb28_6.Enabled = true;
            pb28_7.Enabled = true;
            pb28_8.Enabled = true;
            pb28_9.Enabled = true;
            pb28_10.Enabled = true;
            pb28_11.Enabled = true;
            pb28_12.Enabled = true;
            pb28_13.Enabled = true;
            pb28_14.Enabled = true;
            pb28_15.Enabled = true;
            pb28_16.Enabled = true;
            pb28_17.Enabled = true;
            pb28_18.Enabled = true;
            pb28_19.Enabled = true;
            pb28_20.Enabled = true;
            pb28_21.Enabled = true;
            pb28_22.Enabled = true;
            pb28_23.Enabled = true;
            pb28_24.Enabled = true;
            pb28_25.Enabled = true;
            pb28_26.Enabled = true;
            pb28_27.Enabled = true;
            pb28_28.Enabled = true;


            btnAloita.Visible = false;
            btnAloita.Enabled = false;
        }


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



        private void pb28_1_Click(object sender, EventArgs e)
        {
            pb28_1.Image = imageList1.Images[arvotut[0]];
            pb28_Click_1(sender, e);
        }

        private void pb28_2_Click(object sender, EventArgs e)
        {
            pb28_2.Image = imageList1.Images[arvotut[1]];
            pb28_Click_1(sender, e);
        }

        private void pb28_3_Click(object sender, EventArgs e)
        {
            pb28_3.Image = imageList1.Images[arvotut[2]];
            pb28_Click_1(sender, e);
        }

        private void pb28_4_Click(object sender, EventArgs e)
        {
            pb28_4.Image = imageList1.Images[arvotut[3]];
            pb28_Click_1(sender, e);
        }

        private void pb28_5_Click(object sender, EventArgs e)
        {
            pb28_5.Image = imageList1.Images[arvotut[4]];
            pb28_Click_1(sender, e);
        }

        private void pb28_6_Click(object sender, EventArgs e)
        {
            pb28_6.Image = imageList1.Images[arvotut[5]];
            pb28_Click_1(sender, e);
        }

        private void pb28_7_Click(object sender, EventArgs e)
        {
            pb28_7.Image = imageList1.Images[arvotut[6]];
            pb28_Click_1(sender, e);
        }

        private void pb28_8_Click(object sender, EventArgs e)
        {
            pb28_8.Image = imageList1.Images[arvotut[7]];
            pb28_Click_1(sender, e);
        }

        private void pb28_9_Click(object sender, EventArgs e)
        {
            pb28_9.Image = imageList1.Images[arvotut[8]];
            pb28_Click_1(sender, e);
        }

        private void pb28_10_Click(object sender, EventArgs e)
        {
            pb28_10.Image = imageList1.Images[arvotut[9]];
            pb28_Click_1(sender, e);
        }

        private void pb28_11_Click(object sender, EventArgs e)
        {
            pb28_11.Image = imageList1.Images[arvotut[10]];
            pb28_Click_1(sender, e);
        }

        private void pb28_12_Click(object sender, EventArgs e)
        {
            pb28_12.Image = imageList1.Images[arvotut[11]];
            pb28_Click_1(sender, e);
        }

        private void pb28_13_Click(object sender, EventArgs e)
        {
            pb28_13.Image = imageList1.Images[arvotut[12]];
            pb28_Click_1(sender, e);
        }

        private void pb28_14_Click(object sender, EventArgs e)
        {
            pb28_14.Image = imageList1.Images[arvotut[13]];
            pb28_Click_1(sender, e);
        }

        private void pb28_15_Click(object sender, EventArgs e)
        {
            pb28_15.Image = imageList1.Images[arvotut[14]];
            pb28_Click_1(sender, e);
        }

        private void pb28_16_Click(object sender, EventArgs e)
        {
            pb28_16.Image = imageList1.Images[arvotut[15]];
            pb28_Click_1(sender, e);
        }

        private void pb28_17_Click(object sender, EventArgs e)
        {
            pb28_17.Image = imageList1.Images[arvotut[16]];
            pb28_Click_1(sender, e);
        }

        private void pb28_18_Click(object sender, EventArgs e)
        {
            pb28_18.Image = imageList1.Images[arvotut[17]];
            pb28_Click_1(sender, e);
        }

        private void pb28_19_Click(object sender, EventArgs e)
        {
            pb28_19.Image = imageList1.Images[arvotut[18]];
            pb28_Click_1(sender, e);
        }

        private void pb28_20_Click(object sender, EventArgs e)
        {
            pb28_20.Image = imageList1.Images[arvotut[19]];
            pb28_Click_1(sender, e);
        }

        private void pb28_21_Click(object sender, EventArgs e)
        {
            pb28_21.Image = imageList1.Images[arvotut[20]];
            pb28_Click_1(sender, e);
        }

        private void pb28_22_Click(object sender, EventArgs e)
        {
            pb28_22.Image = imageList1.Images[arvotut[21]];
            pb28_Click_1(sender, e);
        }

        private void pb28_23_Click(object sender, EventArgs e)
        {
            pb28_23.Image = imageList1.Images[arvotut[22]];
            pb28_Click_1(sender, e);
        }

        private void pb28_24_Click(object sender, EventArgs e)
        {
            pb28_24.Image = imageList1.Images[arvotut[23]];
            pb28_Click_1(sender, e);
        }

        private void pb28_25_Click(object sender, EventArgs e)
        {
            pb28_25.Image = imageList1.Images[arvotut[24]];
            pb28_Click_1(sender, e);
        }

        private void pb28_26_Click(object sender, EventArgs e)
        {
            pb28_26.Image = imageList1.Images[arvotut[25]];
            pb28_Click_1(sender, e);
        }

        private void pb28_27_Click(object sender, EventArgs e)
        {
            pb28_27.Image = imageList1.Images[arvotut[26]];
            pb28_Click_1(sender, e);
        }

        private void pb28_28_Click(object sender, EventArgs e)
        {
            pb28_28.Image = imageList1.Images[arvotut[27]];
            pb28_Click_1(sender, e);
        }

        private void Kaksikymmentäkahdeksan_FormClosed(object sender, FormClosedEventArgs e)
        {
            A.btnAloita.Enabled = true;
        }
    }
}
