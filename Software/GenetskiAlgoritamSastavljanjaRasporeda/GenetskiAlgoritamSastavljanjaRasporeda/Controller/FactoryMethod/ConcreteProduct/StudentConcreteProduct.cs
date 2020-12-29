using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct
{
    class StudentConcreteProduct : DatotekaProduct<Student>
    {
        public bool FileExist(string fileName)
        {
            return File.Exists(fileName) ? true : false;

        }

        public HashSet<Student> GetEntities(string fileName)
        {
            HashSet<Student> allStudent = new HashSet<Student>();
            if (!FileExist(fileName)) throw new FileNotFoundException("File doesnt exists!");
            bool firstRead = false;
            using(var read = new StreamReader(fileName))
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
                        allStudent.Add(CreateEntity(values));
                    }
                    catch (FormatException fe)
                    {
                        System.Windows.Forms.MessageBox.Show(fe.Message);
                    }
                }
            }
            return allStudent;
        }

        private Student CreateEntity(string[] values)
        {
            try
            {
                Student s = new Student();
                s.Id = int.Parse(values[0]);
                s.Ime = values[1];
                s.Prezime = values[2];
                s.GodinaStudija = int.Parse(values[3]);
                return s;
            }
            catch (Exception ex)
            {
                throw new FormatException("Datoteka ne sadrži dobar poredak znakova prema uputama Student.");
            }
        }
    }
}
