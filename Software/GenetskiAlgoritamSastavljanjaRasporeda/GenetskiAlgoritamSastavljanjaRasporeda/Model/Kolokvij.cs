using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Model
{
    public class Kolokvij
    {
        public int id { get; set; }
        public DateTime vrijemePocetka { get; set; }
        //nesmije poceti prije radnog vremena
        public double trajanje { get; set; }
        //ne smije trajati izvan kraja radnog vremena
        public Kolegij kolegij { get; set; }
        public Profesor profesor { get; set; }
        public int tipKolokvija { get; set; }
        //lab=0 ili obicni=1
        public Dvorana dvorana { get; set; }
        //mora odgovarati tipu kolokvija


        public Kolokvij(int id, DateTime vrijemePocetka, double trajanje, Kolegij kolegij, Profesor profesor, int tipKolokvija, Dvorana dvorana)
        {
            this.id = id;
            this.vrijemePocetka = vrijemePocetka;
            this.trajanje = trajanje;
            this.kolegij = kolegij;
            this.profesor = profesor;
            this.tipKolokvija = tipKolokvija;
            this.dvorana = dvorana;
        }
        public Kolokvij()
        {

        }


    }
}
