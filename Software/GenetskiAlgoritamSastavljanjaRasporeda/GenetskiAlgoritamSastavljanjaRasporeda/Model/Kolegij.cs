using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Model
{
    class Kolegij
    {
        private int _id { get; set; }
        private string _naziv { get; set; }
        private int _godinaStudija { get; set; }
        public int Id { get=>this._id; set=>setId(value); }
        public string Naziv { get=>this._naziv; set=>setNaziv(value); }
        public int GodinaStudija { get=>this._godinaStudija; set=>setGodinaStudija(value); }

        public Kolegij()
        {

        }
        public Kolegij(int id, string naziv, int godinaStudija)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.GodinaStudija = godinaStudija;
        }
        private void setNaziv(string value)
        {
            this._naziv = value;
        }
        private void setId(int value)
        {
            this._id = value;
        }
        private void setGodinaStudija(int value)
        {
            this._godinaStudija = value;
        }

    }
}
