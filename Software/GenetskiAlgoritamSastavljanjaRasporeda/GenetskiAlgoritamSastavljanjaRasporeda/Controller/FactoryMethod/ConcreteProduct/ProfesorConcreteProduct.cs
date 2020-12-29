using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct
{
    class ProfesorConcreteProduct : DatotekaProduct<Profesor>
    {
        public bool FileExist(string fileName)
        {
            return File.Exists(fileName) ? true : false;
        }

        public HashSet<Profesor> GetEntities(string fileName)
        {
            HashSet<Profesor> allProfs = new HashSet<Profesor>();
            if (!FileExist(fileName)) throw new FileNotFoundException("File doesnt exists!");
            bool firstRead = false;
            using (var read = new StreamReader(fileName))
            {
                while (!read.EndOfStream)
                {
                    if (!firstRead)
                    {
                        var lineFirstRead = read.ReadLine();
                        firstRead = true;
                    }
                    var line = read.ReadLine();
                    var values = line.Split(';');
                    try
                    {
                        allProfs.Add(CreateEntity(values));
                    }
                    catch (FormatException fe)
                    {
                        System.Windows.Forms.MessageBox.Show(fe.Message);
                    }
                }
            }
            return allProfs;
        }
        private Profesor CreateEntity(string[] values)
        {
            try
            {
                Profesor p = new Profesor();
                p.Id = int.Parse(values[0]);
                p.Ime = values[1];
                p.Prezime = values[2];
                string[] kolegiji = values[3].Split(',');
                List<Kolegij> profesoroviKolegiji = new List<Kolegij>();
                foreach (var k in kolegiji)
                {
                    int idKolegija = int.Parse(k);
                    Kolegij test = Data.GetInstance().AllKolegij.FirstOrDefault(x => x.Id == idKolegija);
                    profesoroviKolegiji.Add(test);
                }
                p.Kolegiji = profesoroviKolegiji;
                return p;
            }
            catch (Exception ex)
            {
                throw new FormatException("Datoteka ne sadrži dobar poredak znakova prema uputama Profesor.");
            }
        }
    }
}
