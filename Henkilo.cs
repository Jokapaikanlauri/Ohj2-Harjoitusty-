using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Harkkatyö_Ohj2
{
        /*TILASTOINTI:
      * Täällä hoidetaan kaikki varsinaiseen tilastointiin liittyvä. Käytetään Henkilo -oliota tietojen keräämiseen ja koostamiseen, jotta ne viedään listan kautta tiedostoon. 
      * Alla olion muodostimia, gettereitä ja settereitä, sekä string muotoinen lista. Henkilon jäsenmuuttujista Vaikeustasoa käytetään vain tuomaan tieto pelatusta vaikeusasteesta.*/

        public class Henkilo
        {
            public string Nimi { get; set; }
            public int Voitot { get; set; }
            public int Tappiot { get; set; }
            public int Tasapelit { get; set; }
            public string Vaikeustaso { get; set; }
            int Helppo { get; set; }
            int Keskivaikea { get; set; }
            int Vaikea { get; set; }


            List<string> spelitiedot = new List<string>();

            public Henkilo()
            {

            }
            public Henkilo(string nimi, int voitot, int helppo)
            {
                Nimi = nimi;
                Voitot = voitot;
                Helppo = helppo;
            }

            public Henkilo(string nimi, int voitot, int tappiot, int tasapelit, int helppo, int keskivaikea, int vaikea)
            {
                Nimi = nimi;
                Voitot = voitot;
                Tappiot = tappiot;
                Tasapelit = tasapelit;
                Helppo = helppo;
                Keskivaikea = keskivaikea;
                Vaikea = vaikea;
            }
            public Henkilo(string nimi, int voitot, int tappiot, int tasapelit, string vaikeustaso, int helppo, int keskivaikea, int vaikea)
            {
                Nimi = nimi;
                Voitot = voitot;
                Tappiot = tappiot;
                Tasapelit = tasapelit;
                Vaikeustaso = vaikeustaso; //käytetään vain tiedonsiirrossa: kertoo mitä vaikeustasoa käytetään
                Helppo = helppo;
                Keskivaikea = keskivaikea;
                Vaikea = vaikea;
            }



            public void Tilastointi(Henkilo voittaja, Henkilo haviaja, string vaikeustaso, bool tasapeli)
            {
                /* Ensin katsotaan viimeisimmän pelin pisteet. Mikäli tuli tasapeli, kummankin pelaajan "Tasapelit" - lukema kasvaa yhdellä. Samalla katsotaan, mitä vaikeustasoa
                pelattiin, ja kasvatetaan kyseistä vaikeustasolukemaa yhdellä.

                Mikäli jompi kumpi voitti, niin voittajat "Voitot" - lukema kasvaa yhdellä -ja vastavuoroisesti haviajan "Tappiot" - lukema kasvaa yhdellä.*/

                if (tasapeli == true) //tilanteessa tasapeli
                {

                    voittaja.Tasapelit++;
                    haviaja.Tasapelit++;

                    switch (vaikeustaso)
                    {
                        case "helppo":
                            voittaja.Helppo++;
                            haviaja.Helppo++;
                            break;
                        case "keskivaikea":
                            voittaja.Keskivaikea++;
                            haviaja.Keskivaikea++;
                            break;
                        case "vaikea":
                            voittaja.Vaikea++;
                            haviaja.Vaikea++;
                            break;
                    }

                }

                else //tilanteessa, jossa jompikumpi on voittaja
                {


                    voittaja.Voitot++;
                    haviaja.Tappiot++;

                    switch (vaikeustaso)
                    {
                        case "helppo":
                            voittaja.Helppo++;
                            haviaja.Helppo++;
                            break;
                        case "keskivaikea":
                            voittaja.Keskivaikea++;
                            haviaja.Keskivaikea++;
                            break;
                        case "vaikea":
                            voittaja.Vaikea++;
                            haviaja.Vaikea++;
                            break;
                    }

                }

                /* Jo "Aloitus" -formilla on katsottu, onko tilastotiedosto ja hakemisto jo olemassa. Mikäli peli avataan ensimmäisen kerran tai jos jostain syystä tiedostoa ei vielä ole, 
                 * niin luodaan se. Sen jälkeen luetaan tilastotiedoston tiedot "spelitiedot" - listaan. Mikäli tiedosto on tyhjä, niin lista on tyhjä. Tämä tarkoittaa sitä, että peli on avattu
                   ensimmäisen kerran, eikä listauksia vielä ole.

                   Alustetaan paikalliset muuttujat tilaston päivittämistä varten. On hyvä huomata, että tilastossa voi olla aina vain 1 saman niminen pelaaja. Mikäli pelaajan nimi löytyy
                   tiedostosta, tiedoston pelaajatiedot päivitetään.

                   Tarkistetaan, onko juuri hakemamme "spelitiedostot" lista tyhjä. Jos on, niin viemme sinne ensimmäisen pelaajan tietoineen. Mikäli pääsemme listan loppuun asti, eikä
                   pelaajan nimeä ole vielä löytynyt, viemme pelaajan listaan. Jos kumpikaan näistä ei toteutunut, se tarkoittaa, että pelaajan nimi löytyy listasta -ja tiedot
                   päivitetään. Päivityksestä on hyvä huomata, että päivitämme listan indeksejä. Sen takia joudumme pomppimaan hiukan eri indeksien välillä, kun pelaaja on löytetty
                   listasta.

                   Nyt tiedämme, että lista ei ole tyhjä. Tarkistetaan myös, löytyykö toisen pelaajan nimi listasta ja tehdään tarvittavat päivitykset/ lisäykset. Lopuksi päivitetään
                   tiedosto.*/
               
                try
                {
                    using (StreamReader sr = new StreamReader("c:\\temp\\KatanJaLaurinMuistipeliTilastot.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            spelitiedot.Add(sr.ReadLine());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                int vo = 0; //voitot
                int ta = 0; //tappiot
                int tp = 0; //tasapelit
                int v = 0; //vaikea
                int kv = 0; //keskivaikea
                int h = 0; //helppo

                //jos listassa ei ole vielä ketään, niin viedään pelaaja listaan. Vain pelin ensimmäisellä käynnistyskerralla
                if (spelitiedot.Count == 0)
                {
                    spelitiedot.Add(voittaja.Nimi);
                    spelitiedot.Add(voittaja.Voitot.ToString());
                    spelitiedot.Add(voittaja.Tappiot.ToString());
                    spelitiedot.Add(voittaja.Tasapelit.ToString());
                    spelitiedot.Add(voittaja.Helppo.ToString());
                    spelitiedot.Add(voittaja.Keskivaikea.ToString());
                    spelitiedot.Add(voittaja.Vaikea.ToString());
                }
                else
                {//katsotaan, löytyykö voittajamme tiedostosta(/listasta)

                    for (int i = 0; i < spelitiedot.Count; i++)
                    {
                        //jos päästään listan loppuun ja nimeä ei edelleenkään ole, niin lisätään henkilö. 
                        if (i == spelitiedot.Count - 1 && spelitiedot[i] != voittaja.Nimi)
                        {
                            spelitiedot.Add(voittaja.Nimi);
                            spelitiedot.Add(voittaja.Voitot.ToString());
                            spelitiedot.Add(voittaja.Tappiot.ToString());
                            spelitiedot.Add(voittaja.Tasapelit.ToString());
                            spelitiedot.Add(voittaja.Helppo.ToString());
                            spelitiedot.Add(voittaja.Keskivaikea.ToString());
                            spelitiedot.Add(voittaja.Vaikea.ToString());

                            i = spelitiedot.Count;
                        }
                        else if (spelitiedot[i] == voittaja.Nimi) //jos pelaaja löytyy tiedostosta, niin tiedot päivitetään
                        {

                            if (voittaja.Voitot == 1)
                            {
                                i++; //päästään voitot indeksiin
                                vo = int.Parse(spelitiedot[i]);
                                vo += 1;
                                spelitiedot[i] = vo.ToString();
                                i += 2; //pitää hypätä sopivaan indeksiin, ettei mene tilastot sekaisin (hypätään pelaajan "tasapelit" indeksiin)
                            }
                            else if (voittaja.Tasapelit == 1)
                            {
                                i += 3;
                                tp = int.Parse(spelitiedot[i]);
                                tp += 1;
                                spelitiedot[i] = tp.ToString();
                            }


                            if (voittaja.Helppo == 1)
                            {
                                i++;
                                h = int.Parse(spelitiedot[i]);
                                h += 1;
                                spelitiedot[i] = h.ToString();
                            }
                            else if (voittaja.Keskivaikea == 1)
                            {
                                i += 2;
                                kv = int.Parse(spelitiedot[i]);
                                kv += 1;
                                spelitiedot[i] = kv.ToString();
                            }
                            else if (voittaja.Vaikea == 1)
                            {
                                i += 3;
                                v = int.Parse(spelitiedot[i]);
                                v += 1;
                                spelitiedot[i] = v.ToString();
                            }

                            i = spelitiedot.Count;
                        }
                    }

                }

                //nyt listassa on ainakin 1 pelaaja, joten sitä ei tarvitse enää tarkistaa toisen pelaajan kohdalla


                for (int i = 0; i < spelitiedot.Count; i++)
                {
                    //jos päästään listan loppuun ja nimeä ei edelleenkään ole, niin lisätään henkilö. 
                    if (i == spelitiedot.Count - 1 && spelitiedot[i] != haviaja.Nimi)
                    {
                        spelitiedot.Add(haviaja.Nimi);
                        spelitiedot.Add(haviaja.Voitot.ToString());
                        spelitiedot.Add(haviaja.Tappiot.ToString());
                        spelitiedot.Add(haviaja.Tasapelit.ToString());
                        spelitiedot.Add(haviaja.Helppo.ToString());
                        spelitiedot.Add(haviaja.Keskivaikea.ToString());
                        spelitiedot.Add(haviaja.Vaikea.ToString());

                        i = spelitiedot.Count;
                    }
                    else if (spelitiedot[i] == haviaja.Nimi) //jos pelaaja löytyy tiedostosta, niin tiedot päivitetään
                    {

                        if (haviaja.Tappiot == 1)
                        {
                            i += 2;
                            ta = int.Parse(spelitiedot[i]);
                            ta = ta + 1;
                            spelitiedot[i] = ta.ToString();
                            i++;
                        }
                        else if (haviaja.Tasapelit == 1)
                        {
                            i += 3;
                            tp = int.Parse(spelitiedot[i]);
                            tp += 1;
                            spelitiedot[i] = tp.ToString();
                        }


                        if (haviaja.Helppo == 1)
                        {
                            i++;
                            h = int.Parse(spelitiedot[i]);
                            h += 1;
                            spelitiedot[i] = h.ToString();
                        }

                        else if (haviaja.Keskivaikea == 1)
                        {
                            i += 2;
                            kv = int.Parse(spelitiedot[i]);
                            kv += 1;
                            spelitiedot[i] = kv.ToString();
                        }
                        else if (haviaja.Vaikea == 1)
                        {
                            i += 3;
                            v = int.Parse(spelitiedot[i]);
                            v += 1;
                            spelitiedot[i] = v.ToString();
                        }

                        i = spelitiedot.Count;
                    }

                }

                //lopuksi yritetään päivittää tiedosto
                try
                {
                    using (StreamWriter sw = new StreamWriter("c:\\temp\\KatanJaLaurinMuistipeliTilastot.txt"))
                    {
                        for (int i = 0; i < spelitiedot.Count; i++)
                        {
                            sw.WriteLine(spelitiedot[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }