using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Model
{
    public class Student
    {
        private int _id { get; set; }
        private string _ime { get; set; }
        private string _prezime { get; set; }
        private int _godinaStudija { get; set; }
        private List<Kolegij> _kolegiji { get; set; }

        public int Id { get => this.Id; set => SetId(value); }
        public string Ime { get => this._ime; set => SetIme(value); }
        public string Prezime { get => this._prezime; set => SetPrezime(value); }
        public int GodinaStudija { get => this._godinaStudija; set => SetGodinaStudija(value); }
        public List<Kolegij> Kolegiji { get => this._kolegiji; set => _kolegiji = value; }

        public Student()
        {

        }
        public Student(int id,string ime,string prezime, int godinaStudija, List<Kolegij> kolegiji)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.GodinaStudija = godinaStudija;
            this.Kolegiji = kolegiji;
        }
        private void SetId(int id)
        {
            this._id = id;
        }
        private void SetGodinaStudija(int value)
        {
            this._godinaStudija = value;
        }

        private void SetPrezime(string value)
        {
            this._prezime = value;
        }

        private void SetIme(string value)
        {
            this._ime = value;
        }
    }
}
