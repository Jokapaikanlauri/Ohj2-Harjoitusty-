using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Harkkatyö_Ohj2
{
    public partial class Aloitus : Form
    {
        /*TERVETULOA PELAAMAAN KATAN JA LAURIN MUISTIPELIÄ!
        
        Aloitus -sivun toiminnot ovat kutakuinkin seuraavat: käyttäjä syöttää pelaajien nimet, valitsee haluamansa vaikeustason ja korttimäärän. Kun "Aloita" -nappia painetaan, siirrytään
        pelaamaan sille formille, joka vastaa haluttua korttimäärää. "Tilastot" -napin painallus taas näyttää pelaajien tiedot aiemmin pelattujen pelien perusteella. Eli esim. montako
        voittoa tai tappiota kyseisellä pelaajalla on, ja montako kertaa hän on pelannut mitäkin vaikeustasoa.
        
        Pelin aloituksessa yritetään ensin luoda temp hakemisto ja tilastotiedosto, jos niitä ei ole vielä olemassa. Näitä käytetään pelaaja-/pelitietojen ylläpitämiseen ja päivittämiseen.
        Sen jälkeen siirrytään uuden pelin tietojen syöttämiseen ja ko tietojen tarkistamiseen.
        
        Kaikki pelin ikkunat/formit ovat staattisessa koossa, joten niiden kokoa ei voi muokata. */

        public Aloitus()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            try
            {
                DirectoryInfo drInfo = new DirectoryInfo("c:\\temp");
                FileInfo tiedosto = new FileInfo("c:\\temp\\KatanJaLaurinMuistipeliTilastot.txt");

                if (drInfo.Exists != true)
                    drInfo.Create();

                if (tiedosto.Exists != true)
                    tiedosto.Create().Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnTilastot_Click(object sender, EventArgs e)
        {
            Tilastot tilastot = new Tilastot(this);
            tilastot.Show();
        }


        /*Tarkistetaan Pelaajan 1 tiedot. "Pelaaja1" on aina pakollinen -tieto. "Pelaaja1" -tekstikentästä lähteminen aiheuttaa 
        validoinnin. Mikäli nimeä ei ole annettu, fokusoidaan kyseiseen textBoxiin ja pyydetään käyttäjää syöttämään nimi.*/


        private void tbPelaaja1_Leave(object sender, EventArgs e)
        {
            CausesValidation = true;
        }
        private void tbPelaaja1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbPelaaja1, "");
        }

        private void tbPelaaja1_Validating(object sender, CancelEventArgs e)
        {
            string nimi1 = "Anna nimi pelaajalle 1";
            
            if (tbPelaaja1.TextLength == 0)
            {
                e.Cancel = true;
                tbPelaaja1.Select(0, tbPelaaja1.Text.Length);
                this.errorProvider1.SetError(tbPelaaja1, nimi1);
            }
        }

        /*Mikäli Pelaaja2 - tekstikenttä on näkyvissä, on sekin tieto pakollinen (eli silloin pelaaja alustaa kaksinpelin tietoja). Validoidaan silloin siis sekin tieto, 
         * samalla tavalla kuin Pelaaja1:n kohdalla. Pelaaja2 tekstikenttä tulee näkyviin, jos "kaksinpeli" -checkboxia on klikattu. Tekstikenttä myös häviää näkyvistä, 
         * jos "kaksinpeli" -checkboxia klikataan uudelleen.*/

        private void tbPelaaja2_Leave(object sender, EventArgs e)
        {
            CausesValidation = true;
        }
        private void tbPelaaja2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbPelaaja2, "");
        }

        private void tbPelaaja2_Validating(object sender, CancelEventArgs e)
        {
            string nimi2 = "Anna nimi pelaajalle 2";

            if(tbPelaaja2.Visible == true)
            {
                if (tbPelaaja2.TextLength == 0)
                {
                    e.Cancel = true;
                    tbPelaaja2.Select(0, tbPelaaja2.Text.Length);
                    this.errorProvider1.SetError(tbPelaaja2, nimi2);
                }
            }
        }

        private void cbKaksinpeli_Click(object sender, EventArgs e)
        { 

            if (cbKaksinpeli.Checked)
            {
                label2.Visible = true;
                tbPelaaja2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                tbPelaaja2.Visible = false;
                tbPelaaja2.Text = "";
            }
           
        }


        /*Pelaaja(t) voi valita parillisen korttimäärän 8-40 kortin väliltä. Kun pelaaja kirjoittaa sopivan luvun korttimäärään, vaihtuu esikatselukuvakkeeseen kyseistä 
         * pelimoodia havainnollistava kuva. "Korttien määrä" -kentästä lähteminen aiheuttaa validoinnin. Mikäli korttimäärä jätetään tyhjäksi tai se ei ole parillinen kokonaisluku
         * annetulta väliltä, niin annetaan virheilmoitus ja fokusoidaan kyseiseen tekstikenttään.*/


        private void tbKortit_TextChanged(object sender, EventArgs e)
        {

            if (tbKortit.Text == "8")
            {
                pbKortit.Image = Properties.Resources.pelikortti_8;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "10")
            {
                pbKortit.Image = Properties.Resources.pelikortti_10;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "12")
            {
                pbKortit.Image = Properties.Resources.pelikortti_12;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "14")
            {
                pbKortit.Image = Properties.Resources.pelikortti_141;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "16")
            {
                pbKortit.Image = Properties.Resources.pelikortti_16;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "18")
            {
                pbKortit.Image = Properties.Resources.pelikortti_18;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "20")
            {
                pbKortit.Image = Properties.Resources.pelikortti_20;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "22")
            {
                pbKortit.Image = Properties.Resources.pelikortti_221;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "24")
            {
                pbKortit.Image = Properties.Resources.pelikortti_24;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "26")
            {
                pbKortit.Image = Properties.Resources.pelikortti_26;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "28")
            {
                pbKortit.Image = Properties.Resources.pelikortti_28;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "30")
            {
                pbKortit.Image = Properties.Resources.pelikortti_301;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "32")
            {
                pbKortit.Image = Properties.Resources.pelikortti_321;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "34")
            {
                pbKortit.Image = Properties.Resources.pelikortti_341;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "36")
            {
                pbKortit.Image = Properties.Resources.pelikortti_361;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "38")
            {
                pbKortit.Image = Properties.Resources.pelikortti_38;
                pbEsikatselu.Visible = false;
            }
            else if (tbKortit.Text == "40")
            {
                pbKortit.Image = Properties.Resources.pelikortti_40;
                pbEsikatselu.Visible = false;
            }
        }
        
        private void tbKortit_Leave(object sender, EventArgs e)
        {
            CausesValidation = true;
        }

        private void tbKortit_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbKortit, "");
        }

        private void tbKortit_Validating(object sender, CancelEventArgs e)
        {
            string ohje = "Käytä parillisia kokonaislukuja 8-40 väliltä!";
            int iKortit = 0;
            try
            {
                iKortit = int.Parse(tbKortit.Text);

                if (iKortit % 2 != 0)
                {
                    e.Cancel = true;
                    tbKortit.Select(0, tbKortit.Text.Length);
                    this.errorProvider1.SetError(tbKortit, ohje);
                }
                else if (iKortit > 40 || iKortit < 8)
                {
                    e.Cancel = true;
                    tbKortit.Select(0, tbKortit.Text.Length);
                    this.errorProvider1.SetError(tbKortit, ohje);
                }
            }
            catch
            {
                e.Cancel = true;
                tbKortit.Select(0, tbKortit.Text.Length);
                this.errorProvider1.SetError(tbKortit, ohje);
            }
           
        }

        /*Ennen pelin aloittamista tarkistetaan vielä tiedot. Esim. jos pelaaja on unohtanut syöttää korttien määrän kokonaan (eli ei ole käynyt ko tekstikentässä -> ei aiheuta validointia), 
         niin fokusoidaan kohtaan, josta tarvittava tieto puuttuu. Mikäli vaikeustason valinta on jäänyt tekemättä, niin fokusoinnin lisäksi laitetaan oletukseksi "helppo" -taso. 
        
         Kun kaikki tarvittavat tiedot on kerätty ja "Aloita" -nappia painettu, ohjataan pelaaja(t) sille formille, joka vastaa valittua korttimäärää. */

        private void btnAloita_Click(object sender, EventArgs e)
        {

            Aloitus A = new Aloitus();
     

            if (tbPelaaja1.TextLength == 0)
            {
                tbPelaaja1.Focus();
            }
            else if(tbPelaaja2.Visible == true && tbPelaaja2.TextLength == 0)//jos pelataan kaksinpeliä, niin myös Pelaaja2 -tieto on pakollinen
            {
                tbPelaaja2.Focus();
            }
            else if(tbKortit.TextLength == 0)
            {
                tbKortit.Focus();
            }
            else if(!rbHelppo.Checked && !rbKeskivaikea.Checked && !rbVaikea.Checked)
            {
                rbHelppo.Focus(); 
            }
            else
            {
                //Jos kaikki ehdot täyttyvät, avataan haluttu peli-ikkuna
                switch(tbKortit.Text)
                {
                    case "8":
                        Kahdeksan K8 = new Kahdeksan(this);
                        K8.Show();
                        break;
                    case "10":
                        Kymmenen K10 = new Kymmenen(this);
                        K10.Show();
                        break;
                    case "12":
                        Kaksitoista K12 = new Kaksitoista(this);
                        K12.Show();
                        break;
                    case "14":
                        Neljätoista K14 = new Neljätoista(this);
                        K14.Show();
                        break;
                    case "16":
                        Kuusitoista K16 = new Kuusitoista(this);
                        K16.Show();
                        break;
                    case "18":
                        Kahdeksantoista K18 = new Kahdeksantoista(this);
                        K18.Show();
                        break;
                    case "20":
                        Kaksikymmentä K20 = new Kaksikymmentä(this);
                        K20.Show();
                        break;
                    case "22":
                        Kaksikymmentäkaksi K22 = new Kaksikymmentäkaksi(this);
                        K22.Show();
                        break;
                    case "24":
                        Kaksikymmentäneljä K24 = new Kaksikymmentäneljä(this);
                        K24.Show();
                        break;
                    case "26":
                        Kaksikymmentäkuusi K26 = new Kaksikymmentäkuusi(this);
                        K26.Show();
                        break;
                    case "28":
                        Kaksikymmentäkahdeksan K28 = new Kaksikymmentäkahdeksan(this);
                        K28.Show();
                        break;
                    case "30":
                        Kolmekymmentä K30 = new Kolmekymmentä(this);
                        K30.Show();
                        break;
                    case "32":
                        Kolmekymmentäkaksi K32 = new Kolmekymmentäkaksi(this);
                        K32.Show();
                        break;
                    case "34":
                        Kolmekymmentäneljä K34 = new Kolmekymmentäneljä(this);
                        K34.Show();
                        break;
                    case "36":
                        Kolmekymmentäkuusi K36 = new Kolmekymmentäkuusi(this);
                        K36.Show();
                        break;
                    case "38":
                        Kolmekymmentäkahdeksan K38 = new Kolmekymmentäkahdeksan(this);
                        K38.Show();
                        break;
                    case "40":
                        Neljäkymmentä K40 = new Neljäkymmentä(this);
                        K40.Show();
                        break;
                }
            }
        }

        
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KATSO PELITILASTOJA: \nPaina 'Tilastot' -nappia nähdäksesi kaksinpeliä pelanneiden pelaajien pelitilastot. \n\nSYÖTÄ PYYDETYT PELITIEDOT: \nOletuksena on yksinpeli. " +
                "Mikäli haluat pelata kaksinpeliä, paina 'Pelaa kaksinpeliä' ruutua. Näin pääset syöttämään toisen pelaajan tiedot.\n" + "Valitse sopiva vaikeustaso ja parillinen korttimäärä " +
                "8-40 väliltä. \nPaina 'Aloita' -nappia aloittaaksesi pelin. \n\nPELIOHJEET: \nPelikortit sekoitetaan ja asetetaan pöydällä väärin päin niin, ettei pelaaja tiedä missä mikäkin " +
                "kuva on. \nPeli alkaa ja jokaisella vuorolla pelaaja kääntää kaksi mitä tahansa pöydällä olevaa korttia oikein päin. \nJos käännettyjen korttien kuvat eivät ole samat, " +
                 "ne käännetään uudestaan nurin. Jos kuvat ovat samanlaiset, pelaaja saa pisteen ja kuvat jätetään oikein päin. \n\nKaksinpeliä pelattaessa vuoroa saa jatkaa, jos on löytänyt " +
                 "kuvaparin - ja vuoro vaihtuu, mikäli kuvat eivät ole samat. \nVoittaja on se, joka löytää eniten kuvapareja pelin loppuun mennessä. \n\nPelaajan pelivuoron näkee siitä, että " +
                 "pelaajan nimi on korostettu. \n\nVAIKEUSTASOT: \nHelppo: kaikki kuvat ovat näkyvillä pelin aluksi. Peli alkaa painamalla 'Aloita' -nappia, jolloin kuvat kääntyvät väärin päin. " +
                 "\n\nKeskivaikea: Kuvat ovat väärin päin käännettyjä ja peli alkaa saman tien. Valitut kuvat näkyvät yhtä aikaa 1 sekunnin ajan. \n\nVaikea: Kuvat ovat väärin päin käännettyjä " +
                 "ja peli alkaa saman tien. Valitut kuvat näkyvät yhtä aikaa 0,5 sekunnin ajan.");
        }
    }
}