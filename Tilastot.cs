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
    public partial class Tilastot : Form
    {/*Tilastot -formia käytetään aikaisemmin pelattujen pelitietojen näyttämiseen. Tiedot luetaan tilastotiedostosta datagridview -työkaluun niin, että jokaisen pelaajan
      pelitiedot tulevat aina yhdelle riville. Yhden pelaajan tiedot jakautuvat tiedostossa 7 eri riville, jonka vuoksi sr.Readline() suoritetaan aina yhden dgv -rivin aikana
        7 kertaa. */

        Aloitus A;

        public Tilastot(Aloitus A)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.A = A;

            A.btnTilastot.Enabled = false; 

            try
            {
                using (StreamReader sr = new StreamReader("c:\\temp\\KatanJaLaurinMuistipeliTilastot.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        dgvTilastot.Rows.Add(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Tilastot_FormClosed(object sender, FormClosedEventArgs e)
        {
            A.btnTilastot.Enabled = true;
        }

    }
}
