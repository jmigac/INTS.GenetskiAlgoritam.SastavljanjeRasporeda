using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteCreator;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod
{
    public class AbstractFactory
    {
        public static HashSet<Student> GetValuesForStudents(string fileName)
        {
            HashSet<Student> entities = new HashSet<Student>();
            DatotekaCreator<Student> dc =(DatotekaCreator<Student>) new StudentConcreteCreator();
            DatotekaProduct<Student> dp = dc.CreateProduct();
            entities = dp.GetEntities(fileName);
            return entities;
        }
    }

}
