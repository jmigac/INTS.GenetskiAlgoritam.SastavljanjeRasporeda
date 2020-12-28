using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct
{
    class DvoranaConcreteProduct : DatotekaProduct<Dvorana>
    {
        public bool FileExist(string fileName)
        {
            return File.Exists(fileName) ? true : false;
        }

        public HashSet<Dvorana> GetEntities(string fileName)
        {
            HashSet<Dvorana> allDvoranas = new HashSet<Dvorana>();
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
                        allDvoranas.Add(CreateEntity(values));
                    }
                    catch (FormatException fe)
                    {
                        System.Windows.Forms.MessageBox.Show(fe.Message);
                    }
                }
            }
            return allDvoranas;
        }
        private Dvorana CreateEntity(string[] values)
        {
            try
            {
                Dvorana d = new Dvorana();
                d.Id = int.Parse(values[0]);
                d.Kapacitet = int.Parse(values[2]);
                d.Lokacija = values[4];
                d.Naziv = values[1];
                d.TipDvorane = int.Parse(values[3]);
                return d;
            }
            catch (Exception ex)
            {
                throw new FormatException("Datoteka ne sadrži dobar poredak znakova prema uputama.");
            }
        }
    }
}
