using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Model
{
    public class Dvorana
    {
        private int _id { get; set; }
        private string _naziv { get; set; }
        private int _kapacitet { get; set; }
        private string _lokacija { get; set; }
        private int _tipDvorane { get; set; }

        public int Id { get=>this._id; set=>this._id=value; }
        public string Naziv { get => this._naziv; set => this._naziv = value; }
        public int Kapacitet { get=>this._kapacitet; set=>this._kapacitet=value; }
        public string Lokacija { get=>this._lokacija; set=>this._lokacija=value; }
        public int TipDvorane { get => this._tipDvorane; set => this._tipDvorane = value; }

        public Dvorana()
        {

        }

        public Dvorana(int id, string naziv, int kapacitet, string lokacija, int tipDvorane)
        {
            Id = id;
            Naziv = naziv;
            Kapacitet = kapacitet;
            Lokacija = lokacija;
            TipDvorane = tipDvorane;
        }
    }
}
