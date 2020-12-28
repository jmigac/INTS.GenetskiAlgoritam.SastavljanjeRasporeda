using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Model
{
    class Profesor
    {
        private int _id { get; set; }
        private string _ime { get; set; }
        private string _prezime { get; set; }
        private List<Kolegij> _kolegiji { get; set; }

        public int Id { get=>this._id; set=>_id=value; }
        public string Ime { get=>this._ime; set=>_ime=value; }
        public string Prezime { get=>this._prezime; set=>_prezime=value; }
        public List<Kolegij> Kolegiji { get=>this._kolegiji; set=>_kolegiji=value; }

        public Profesor()
        {

        }
        public Profesor(int id,string ime,string prezime,List<Kolegij> kolegiji)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Kolegiji = kolegiji;
        }
    }
}
