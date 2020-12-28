using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct
{
    class KolegijConcreteProduct : DatotekaProduct<Kolegij>
    {
        public bool FileExist(string fileName)
        {
            return File.Exists(fileName) ? true : false;
        }

        public HashSet<Kolegij> GetEntities(string fileName)
        {
            HashSet<Kolegij> allKolegijs = new HashSet<Kolegij>();
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
                        allKolegijs.Add(CreateEntity(values));
                    }
                    catch (FormatException fe)
                    {
                        System.Windows.Forms.MessageBox.Show(fe.Message);
                    }
                }
            }
            return allKolegijs;
        }
        private Kolegij CreateEntity(string[] values)
        {
            try
            {
                Kolegij k = new Kolegij();
                k.Id = int.Parse(values[0]);
                k.Naziv = values[1];
                k.GodinaStudija = int.Parse(values[2]);
                return k;
            }
            catch (Exception ex)
            {
                throw new FormatException("Datoteka ne sadrži dobar poredak znakova prema uputama.");
            }
        }
    }
}
