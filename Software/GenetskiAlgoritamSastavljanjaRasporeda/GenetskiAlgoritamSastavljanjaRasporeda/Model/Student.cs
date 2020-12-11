using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Model
{
    class Student
    {
        private int _id { get; set; }
        private string _ime { get; set; }
        private string _prezime { get; set; }
        private int _godinaStudija { get; set; }

        public int Id { get => this.Id; set => setId(value); }
        public string Ime { get => this._ime; set => setIme(value); }
        public string Prezime { get => this._prezime; set => setPrezime(value); }
        public int GodinaStudija { get => this._godinaStudija; set => setGodinaStudija(value); }

        public Student()
        {

        }
        public Student(int id,string ime,string prezime, int godinaStudija)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.GodinaStudija = godinaStudija;
        }
        private void setId(int id)
        {
            this._id = id;
        }
        private void setGodinaStudija(int value)
        {
            this._godinaStudija = value;
        }

        private void setPrezime(string value)
        {
            this._prezime = value;
        }

        private void setIme(string value)
        {
            this._ime = value;
        }
    }
}
