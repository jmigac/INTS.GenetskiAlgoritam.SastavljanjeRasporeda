using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenetskiAlgoritamSastavljanjaRasporeda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Trenutni datum = pocetak godine
            //Dan  Prostorija godinaStudija + (slobodan profesor)
            //Prolazi kroz predmete i pronadi prvi datum zahtjeva kolokvija
                //Da li taj dan ima slobodan termin , dvoranu (istog tipa sa dovoljno kapaciteta), u istom tjednu godinaStudija ima manje od 3 kolokvija, da li je slobodan profesor
                //Prolazimo kroz kolokvije, te gledamo podudaranost datuma pa dvorane (one koje su istog tipa sa dovoljno kapaciteta) i studenteGodine
                    //Ako da stvori Kolokvij i dodaj ga u Data te obrisi sa kolegija zahtjev kolokvija
                    //Ako ne dodaj jedan dan i ponovi loop
                //Kada si gotov sa predmetom - resetiraj trenutni_datum




        }
    }
}
