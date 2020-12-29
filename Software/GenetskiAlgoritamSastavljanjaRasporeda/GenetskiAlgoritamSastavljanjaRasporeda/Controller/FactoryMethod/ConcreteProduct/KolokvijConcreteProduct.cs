using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct
{
    class KolokvijConcreteProduct : DatotekaProduct<Kolokvij>
    {
        public bool FileExist(string fileName)
        {
            return File.Exists(fileName) ? true : false;
        }

        public HashSet<Kolokvij> GetEntities(string fileName)
        {
            HashSet<Kolokvij> allKolovijs = new HashSet<Kolokvij>();
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
                        allKolovijs.Add(CreateEntity(values));
                    }
                    catch (FormatException fe)
                    {
                        System.Windows.Forms.MessageBox.Show(fe.Message);
                    }
                }
            }
            return allKolovijs;
        }

        private Kolokvij CreateEntity(string[] values)
        {
            try
            {
                Kolokvij k = new Kolokvij();
                k.id = int.Parse(values[0]);
                k.vrijemePocetka = DateTime.Parse(values[1]);
                k.trajanje = double.Parse(values[2]);
                k.kolegij = Data.GetInstance().AllKolegij.First(x => x.Id == int.Parse(values[3]));
                k.profesor = Data.GetInstance().AllProfesor.First(x=>x.Id==int.Parse(values[4]));
                k.tipKolokvija = int.Parse(values[5]);
                k.dvorana = Data.GetInstance().AllDvorana.First(x=>x.Id == int.Parse(values[6]));
                return k;
            }
            catch (Exception ex)
            {
                throw new FormatException("Datoteka ne sadrži dobar poredak znakova prema uputama.");
            }
        }
    }
}
