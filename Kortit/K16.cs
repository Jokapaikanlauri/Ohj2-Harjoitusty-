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
    public partial class Kuusitoista : Form
    {
        /*Muistipelin alustaminen: 
        
        Pelikortit ovat pictureboxeja. Pictureboxit viedään "Korttilistaan", josta on helpompi
        mm. jakaa korttien kuvia. Randomilla arvotaan kuvien järjestys, jotta pelitilanne on joka pelikerralla erilainen. Kun
        aloituksessa on valittu monellako kortilla halutaan pelata, avautuu kyseisen korttimäärän formi. Formit on nimetty 
        korttimäärän perusteella, esim K16. 
        
        Kun form avautuu, välitetään koko aloitussivun info uudelle formille, erityisesti pelaajien nimet sekä vaikeustaso. 
        Pelin aloitusmuoto riippuu vaikeustasosta: mikäli vaikeustaso on helppo, näkyvät korttien kuvat - mutta niitä ei voi 
        klikata, ennen kuin "Aloita" nappia on painettu. Kun nappia painetaan, niin kortit kääntyvät väärin päin, ja 
        varsinainen peli alkaa. Keskivaikeassa ja vaikeassa tasossa kortit ovat valmiiksi käännetty väärin päin ja peli alkaa 
        saman tien. Ainoa ero näiden kahden tason välilä on se, kuinka pitkään korttien kuvia pystyy katsomaan. Keskivaikeassa 
        käännetyt kuvat (väärä pari) näkyvät yhtä pitkään kuin helpossakin tasossa, vaikeassa aika on huomattavasti pienempi.*/



        public List<PictureBox> Korttilista = new List<PictureBox>();
        Random random = new Random();
        
        Aloitus A;
        public Kuusitoista(Aloitus A)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //staattinen peliruudun koko
            this.A = A;
            tsslP1.Text = A.tbPelaaja1.Text;
            A.btnAloita.Enabled = false;
            tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Bold); //Pelaaja 1 aloitaa, joten korostetaan pelaajan nimeä sen hahmottamiseksi

            if (A.tbPelaaja2.Text.Length != 0) //jos pelaaja 2 on olemassa
                tsslP2.Text = A.tbPelaaja2.Text;

            
            Korttilista.Add(pb16_1);
            Korttilista.Add(pb16_2);
            Korttilista.Add(pb16_3);
            Korttilista.Add(pb16_4);
            Korttilista.Add(pb16_5);
            Korttilista.Add(pb16_6);
            Korttilista.Add(pb16_7);
            Korttilista.Add(pb16_8);
            Korttilista.Add(pb16_9);
            Korttilista.Add(pb16_10);
            Korttilista.Add(pb16_11);
            Korttilista.Add(pb16_12);
            Korttilista.Add(pb16_13);
            Korttilista.Add(pb16_14);
            Korttilista.Add(pb16_15);
            Korttilista.Add(pb16_16);
            

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



        /*Luodaan taulukko arvotuille kuville. Kuvat tullaan arpomaan Imagelistin indeksien perusteella, siksi taulukko on int
        muodossa, ja taulukon koko on Imagelistin indeksien määrä. Laskureita käytetään pisteiden määrittämiseen. 
        Pictureboxien kääntämiseen ja löydettyjen parien tunnistamiseen käytetään Picturebox muuttujia, joiden 
        toiminnallisuuteen perehdymme hiukan myöhemmin."X" -muuttujaa käytetään seuraamaan sitä, kumman pelaajan vuoro on. 
        "Vaikeustaso" -muuttujaa käytetään tilastoinnin yhteydessä selvittämään, mitä vaikeustasoa ollaan pelattu. 
        Bool muuttuja "tasapeli" taas viestittää tilastointiin, tuliko pelissä tasapeli vai ei.*/
        


        public int[] arvotut = new int[16]; //katsotaan tätä kautta onko samaa numeroa jo arvottu
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

        /*Kun pelin alustus on tehty, kutsutaan Arpominen() -funktiota. Ensin pohjustetaan "arvotut" -taulukko, jotta indeksien
        arpominen sujuisi mutkattomasti. Mikäli taulukkoa ei alusta, 0 -indeksin arpominen ei onnistuisi. Seuraavaksi arvotaan
        Imagelistin indeksit - tai tarkemmin sanottuna niiden järjestys - ja sijoitetaan ne taulukkon. Tämän jälkeen lähdetään
        sijoittaamaan kuvat: kukin pelissä käytettävä kuva on lisätty Imagelistiin 2 kertaa, jolloin voidaan olla varmoja siitä, 
        että kukin kuva esiintyy pelissä täsmälleen 2 kertaa. 
        
        Vaikeustasoja käsitellään myös tässä kohtaa, jotta saadaan kuvien uudelleen arpominen onnistumaan, kun halutaan pelata peliä
        uudelleen. Mikäli vaikeustaso on "helppo", laitetaan "Aloita" -nappi näkyviin, alustetaan "gameTimer" (kuinka pitkään kuvat
        näkyvät kääntämisen jälkeen) & "clickkiTimer" (pitää huolta ettei rikota peliä klikkaamalla liian nopeasti), ja näytetään 
        arvottujen kuvien järjestys pelitilanteessa. Kuvia ei voi kuitenkaan klikata, koska "Enabled = false" on tehty 
        jokaiselle kuvalle pelin alustamisen yhteydessä. Mikäli vaikeustaso on "keskivaikea" tai "vaikea", niin "Aloita" nappia ei
        ole, ja alustetaan timerit jälleen kullekin tasolle erikseen.  */


            private void Arpominen()
            {
            //alustetaan arvottujen indeksienlista


            for (int i = 0; i < 16; i++)
                {
                    arvotut[i] = 99;
                }

                int arvottu;

                //arvonta, ja katsotaan että jokainen arvottu imagelistin indeksi esiintyy vain kerran

                for (int i = 0; i < 16; i++)
                {
                    arvottu = random.Next(16);
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

                //Yritimme jakaa kuvat loopin/listan kautta, mutta jostain syystä se vaihtoehto aiheutti bugeja - siksi tehty manuaalisesti

                /*for (int i = 0; i < Korttilista.Count; i++)
                {
                    Korttilista[i].Image = imageList1.Images[arvotut[i]];
                }*/

                pb16_1.Image = imageList1.Images[arvotut[0]];
                pb16_2.Image = imageList1.Images[arvotut[1]];
                pb16_3.Image = imageList1.Images[arvotut[2]];
                pb16_4.Image = imageList1.Images[arvotut[3]];
                pb16_5.Image = imageList1.Images[arvotut[4]];
                pb16_6.Image = imageList1.Images[arvotut[5]];
                pb16_7.Image = imageList1.Images[arvotut[6]];
                pb16_8.Image = imageList1.Images[arvotut[7]];
                pb16_9.Image = imageList1.Images[arvotut[8]];
                pb16_10.Image = imageList1.Images[arvotut[9]];
                pb16_11.Image = imageList1.Images[arvotut[10]];
                pb16_12.Image = imageList1.Images[arvotut[11]];
                pb16_13.Image = imageList1.Images[arvotut[12]];
                pb16_14.Image = imageList1.Images[arvotut[13]];
                pb16_15.Image = imageList1.Images[arvotut[14]];
                pb16_16.Image = imageList1.Images[arvotut[15]];
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
        


        /*pb16_Click_1 on yleinen klikkitoiminto kaikille PictureBoxeille. Kun yksittäistä PictureBoxia on painettu, se tuo tiedon 
        (mitä ollaan painettu ja missä) "klikattu_pb" muuttujaan. Mikäli yhtään kuvaa ei ole vielä pelivuorolla klikattu, viedään
        tiedot "ekaclikki" :in ja "loydetty1" :seen. Samalla klikattu kuva muuttuu "Enabled = false" :ksi, jotta ei saada pisteitä
        klikkaamalla samaa kuvaa uudelleen. 
        
        Ekaclikin jälkeen on luonnollisesti vuorossa "tokaclikki", jonne talletetaan tieto siitä, mitä PictureBoxia on klikattu 
        seuraavaksi. Viedään tieto myös samalla "loydetty2" :seen ja laitetaan myös tämän PictureBoxin enable "false" tilaan. 
        Samalla "falsetetaan" myös kaikki muut kortit, jotta ei voida klikata mitään muuta, ennen kuin ollaan selvitetty, 
        ovatko kortit pari.

        Tämän jälkeen "clickkiTimer" aktivoituu, ja sen toiminnallisuus on sidottu pitkälti "loydetty1" ja "loydetty2" muuttujiin.
        Itse "clickkiTimer" löytyy myöhemmin, riviltä 511 alkaen.

        Kyseisen timerin päätoiminto on siis estää pelin rikkoutuminen, jos klikataan kuvia liian nopeasti: kun kahta eri PictureBoxia
        on klikattu, niin tutkitaan ensin, olivatko löydetyt kuvat samanlaisia. Jos olivat ja pari muodostui, pari poistetaan 
        korttilistasta ja jätetään kuvapuoli ylöspäin. Kaikki muut kuvat, joissa näkyy pelikortin väärä puoli, falsetetaan 
        väliaikaisesti, jotta ylimääräisiä valintoja ei voi tehdä ja jotta peli ei mene rikki. Sinällään hassua ja ei ehkä kaikkein
        helpoin tapa, mutta näin saimme homman toimimaan. Ilmeisesti piti kyseisessä timerissa vielä erikseen falsettaa kaikki, 
        jotta pystyimme enabloimaan kaiken jälleen uudelleen. 
        
        Itse kuvien vertaileminen tapahtuu tutkimalla kuvien pikseleitä. Kuvien koko muutetaan 16x16 kooksi ja värit vaihdetaan
        mustaan ja valkoiseen (true/false). Mikäli kuvissa on täsmälleen yhtä monta valkoista/mustaa ruutua ja juuri oikeissa paikoissa, 
        ovat kuvat samanlaiset.

        Mikäli kuvat ovat samanlaiset, jaetaan pisteet. Mikäli pelaaja2 on olemassa (eli pelataan kaksinpeliä), katsotaan "x"
        laskurin perusteella, kumman vuoro oli, ja jaetaan pisteet sen mukaan. Jos pelattiin yksinpelinä, niin käytetään vain
        yhtä laskuria koko pelin ajan. (Pelaajien vuorot näkyvät pelaajille pelin aikana lihavoituna tekstinä.)
        
        Pisteiden jakamisen jälkeen nollataan myös muuttujat "ekaclikki" ja "tokaclikki", jotta saadaan uudet tiedot 
        seuraavaksi klikatuista kuvista. On myös hyvä huomata, että mikäli paria ei löytynyt, pisteiden lasku jätetään suoraan
        välistä: muuttuja "x" kasvaa (eli vuoro vaihtuu), "nullitaan ekaclikki ja tokaclikki" ja käynnistetään "gameTimer" 
        -ajastin, joka määrittää, miten pitkään kuvien kuvia pystyy vielä katsomaan, ennen kuin ne käännetään takaisin väärin päin.*/


        private void pb16_Click_1(object sender, EventArgs e)
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

             for (int i=0; i < Korttilista.Count; i++)
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

                    if(x % 2 != 0)//Korostetaan sitä pelaajaa, kenen vuoro on
                    {
                        tsslP2.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                        tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    else if(x % 2 == 0)
                    {
                        if(tsslP2.Text.Length != 0)//korostetaan pelaaja 2:n nimeä tarvittaessa vain, jos kyseessä on kaksinpeli
                        {
                            tsslP1.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                            tsslP2.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        }
                    }
                }
                
                

            /*Tässä kohtaa katsotaan, milloin peli loppuu - ja kuka silloin voitti. Luodaan Henkilo -oliot "voittaja" ja "haviaja".
            Alustetaan arvauksien määrä joka kerta nollaksi, kun tähän tullaan, jotta pysytään kärryillä siitä, milloin peli loppuu.

            "Arvaukset" saakin arvonsa laskureista: kun laskureiden (eli kerättyjen pisteiden) yhteismäärä täsmää korttiparien määrään, 
            on peli loppunut. Voittaja riippuu siitä, kummassa laskurissa (eli kummalla pelaajalla) oli enemmän pisteitä. Tämän 
            perusteella määritetään, kumpi pelaaja oli voittaja ja ilmoitetaan voitosta MessageBoxilla. Samalla kysytään, halutaanko
            pelata uudelleen.
            
            Pelin päätyttyä viedään myös Henkilo -luokassa olevaan tilastointiin tieto "voittajan" & "haviajan" nimestä, pelatusta 
            vaikeustasosta sekä siitä, tuliko tasapeli vai ei. Onkin hyvä huomata, että "voittajaa" ja "haviajaa" käytetään 
            tasapeli- tilanteessa vain ja ainoastaan kuljettamaan tietoa tilastointiin, eivätkä ne silloin kuvaa todellista 
            pelitilannetta - sillä kumpikin voitti!
            HUOM! Tilastointia ei tehdä, jos kyseessä on yksinpeli.
            
            Mikäli ei haluttu pelata uudelleen, palataan takaisin Aloitus -formille. Mikäli haluttiin pelata uudestaan, mennään
            takaisin Arpominen() -funktioon, jossa arvotaan korttien uusi järjestys. Kun pelataan uudestaan, pelataan samalla 
            vaikeustasolla kuin aiemmin: "helppo" vaikeustason toiminnot suoritetaan edelleen Arpominen() -funktiossa. 
            
            Kuitenkin: mikäli vakeustaso oli "keskivaikea" tai "vaikea", siirrytään arpomisen jälkeen suoraan "btnAloita_Click" 
            -funktioon, johon mennään myös "helpossa" vaikeustasossa: sen jälkeen kun "Aloita" -nappia on klikattu. Eli 
            skipataan napin painallus, sillä nappia "ei ole olemassa" vaikeammissa tasoissa, vaan peli alkaa saman tien ja kortit 
            ovat suoraan väärin päin käännettyjä.
            
            Uutta peliä varten myös nollataan kaikki tarvittavat muuttujat ja laskurit.*/



            //Tämä messagebox on pelin jälkeen ilmestyvä dialogi joka mahdollistaa uudelleen pelaamisen
            MessageBoxButtons napit = MessageBoxButtons.YesNo;
            DialogResult uudestaan;
            Henkilo voittaja = new Henkilo();
            Henkilo haviaja = new Henkilo();
            int arvaukset = 0;

            arvaukset = laskuri1 + laskuri2;
            if (arvaukset == 8)
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


        /*btnAloita_Click: tänne siirrytään, kun aloita nappia on painettu - tai jos pelataan uudelleen "keskivaikeaa" tai 
        "vaikeaa" tasoa. Tällöin kortit kääntyvät väärinpäin ja status muuttuu korteissa "Enabled = true". Myös "Aloita" nappi
        hävitetään pelinäytöltä.*/


        private void btnAloita_Click(object sender, EventArgs e)
        {
            pb16_1.Image = Properties.Resources.pelikortti;
            pb16_2.Image = Properties.Resources.pelikortti;
            pb16_3.Image = Properties.Resources.pelikortti;                           
            pb16_4.Image = Properties.Resources.pelikortti;
            pb16_5.Image = Properties.Resources.pelikortti;                           
            pb16_6.Image = Properties.Resources.pelikortti;
            pb16_7.Image = Properties.Resources.pelikortti;
            pb16_8.Image = Properties.Resources.pelikortti;
            pb16_9.Image = Properties.Resources.pelikortti;                           
            pb16_10.Image = Properties.Resources.pelikortti;
            pb16_11.Image = Properties.Resources.pelikortti;
            pb16_12.Image = Properties.Resources.pelikortti;
            pb16_13.Image = Properties.Resources.pelikortti;                           
            pb16_14.Image = Properties.Resources.pelikortti;
            pb16_15.Image = Properties.Resources.pelikortti;
            pb16_16.Image = Properties.Resources.pelikortti;

            pb16_1.Enabled = true;
            pb16_2.Enabled = true;
            pb16_3.Enabled = true;
            pb16_4.Enabled = true;
            pb16_5.Enabled = true;
            pb16_6.Enabled = true;
            pb16_7.Enabled = true;
            pb16_8.Enabled = true;
            pb16_9.Enabled = true;
            pb16_10.Enabled = true;
            pb16_11.Enabled = true;
            pb16_12.Enabled = true;
            pb16_13.Enabled = true;
            pb16_14.Enabled = true;
            pb16_15.Enabled = true;
            pb16_16.Enabled = true;


            btnAloita.Visible = false;
            btnAloita.Enabled = false;

            //Yritettiin tehdä sama asia loopin kautta, mutta tuli bugeja -> siksi manuaalinen toteutus

            /*for (int i = 0; i < Korttilista.Count; i++)
            {
                Korttilista[i].Image = Properties.Resources.pelikortti;
                Korttilista[i].Enabled = true;
            }*/
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


        /*gameTimer_Tick: tänne tullaan, jos paria ei löytynyt. Kuvat näkyvät tämän timerin intervallin ajan. Kun intervalli on 
        kulunut, pysäytetään timeri. Sen jälkeen "enabloidaan" jälleen PictureBoxit "ekaclikki" ja "tokaclikki", käännetään 
        kortit väärin päin ja nollataan klikit.*/


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
     
        /*clickkiTimer_Tick: nopeusrajoitus klikkauksille. Tämä käynnistyy, kun ollaan klikattu 2 korttia, ja otettu niiden tiedot
        talteen. Kun tämä timeri on käynnissä, kortteja ei pysty klikkaamaan. Kun tämä timeri pysäytetään, katsotaan ensin, 
        löydettiinkö korttipari. Jos löydettiin (eli "loydetty1 != null), niin etsitään se korttilistasta ja poistetaan se sieltä.
        Tehdään sama myös korttiparin toiselle puoliskolle, "loydetty2" :lle. Sen jälkeen käydään lista uudelleen läpi ja 
        laitetaan jokainen jäljellä oleva kortti "enabled = false" tilaan. Ei kuulosta loogiselle, mutta tämä toimii meillä jotenkin
        "nurinkurin", eli oikeasti kortteja pystyy jälleen klikkaamaan (jostain tunnistamattomasta syystä, jota emme ole keksineet).*/

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
                    else if(Korttilista[i] == loydetty2)
                    {
                        Korttilista.RemoveAt(i);
                    }
                }
            }

             for (int i = 0; i < Korttilista.Count; i++)
             {

                if(Korttilista[i].Image == Properties.Resources.pelikortti)
                {
                    Korttilista[i].Enabled = false;
                }
                else
                    Korttilista[i].Enabled = true;
             }
        }


        /*Täällä on jokaisen kortin omat klikkikohtaiset funktiot. Eli kun PictureBoxia "X" klikataan, se näyttää sille arvotun 
        kuvan ja vie kaikkien korttien yhteiseen klikkifunktioon: pb16_Click_1.*/


        private void pb16_1_Click(object sender, EventArgs e)
        {
            pb16_1.Image = imageList1.Images[arvotut[0]];
            pb16_Click_1(sender, e);
        }

        private void pb16_2_Click(object sender, EventArgs e)
        {
            pb16_2.Image = imageList1.Images[arvotut[1]];
            pb16_Click_1(sender, e);
        }

        private void pb16_3_Click(object sender, EventArgs e)
        {
            pb16_3.Image = imageList1.Images[arvotut[2]];
            pb16_Click_1(sender, e);
        }

        private void pb16_4_Click(object sender, EventArgs e)
        {
            pb16_4.Image = imageList1.Images[arvotut[3]];
            pb16_Click_1(sender, e);
        }

        private void pb16_5_Click(object sender, EventArgs e)
        {
            pb16_5.Image = imageList1.Images[arvotut[4]];
            pb16_Click_1(sender, e);
        }

        private void pb16_6_Click(object sender, EventArgs e)
        {
            pb16_6.Image = imageList1.Images[arvotut[5]];
            pb16_Click_1(sender, e);
        }

        private void pb16_7_Click(object sender, EventArgs e)
        {
            pb16_7.Image = imageList1.Images[arvotut[6]];
            pb16_Click_1(sender, e);
        }

        private void pb16_8_Click(object sender, EventArgs e)
        {
            pb16_8.Image = imageList1.Images[arvotut[7]];
            pb16_Click_1(sender, e);
        }

        private void pb16_9_Click(object sender, EventArgs e)
        {
            pb16_9.Image = imageList1.Images[arvotut[8]];
            pb16_Click_1(sender, e);
        }

        private void pb16_10_Click(object sender, EventArgs e)
        {
            pb16_10.Image = imageList1.Images[arvotut[9]];
            pb16_Click_1(sender, e);
        }

        private void pb16_11_Click(object sender, EventArgs e)
        {
            pb16_11.Image = imageList1.Images[arvotut[10]];
            pb16_Click_1(sender, e);
        }

        private void pb16_12_Click(object sender, EventArgs e)
        {
            pb16_12.Image = imageList1.Images[arvotut[11]];
            pb16_Click_1(sender, e);
        }

        private void pb16_13_Click(object sender, EventArgs e)
        {
            pb16_13.Image = imageList1.Images[arvotut[12]];
            pb16_Click_1(sender, e);
        }

        private void pb16_14_Click(object sender, EventArgs e)
        {
            pb16_14.Image = imageList1.Images[arvotut[13]];
            pb16_Click_1(sender, e);
        }

        private void pb16_15_Click(object sender, EventArgs e)
        {
            pb16_15.Image = imageList1.Images[arvotut[14]];
            pb16_Click_1(sender, e);
        }

        private void pb16_16_Click(object sender, EventArgs e)
        {
            pb16_16.Image = imageList1.Images[arvotut[15]];
            pb16_Click_1(sender, e);
        }

        private void Kuusitoista_FormClosed(object sender, FormClosedEventArgs e)
        {
            A.btnAloita.Enabled = true;
        }
    }
}
