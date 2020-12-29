using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteCreator;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        public static HashSet<Kolegij> GetValuesForKolegijs(string fileName)
        {
            HashSet<Kolegij> entities = new HashSet<Kolegij>();
            DatotekaCreator<Kolegij> dc = (DatotekaCreator<Kolegij>)new KolegijConcreteCreator();
            DatotekaProduct<Kolegij> dp = dc.CreateProduct();
            entities = dp.GetEntities(fileName);
            return entities;
        }
        public static HashSet<Profesor> GetValuesForProfesors(string fileName)
        {
            HashSet<Profesor> entities = new HashSet<Profesor>();
            DatotekaCreator<Profesor> dc = (DatotekaCreator<Profesor>)new ProfesorConcreteCreator();
            DatotekaProduct<Profesor> dp = dc.CreateProduct();
            entities = dp.GetEntities(fileName);
            return entities;
        }
        public static HashSet<Dvorana> GetValuesForDvoranas(string fileName)
        {
            HashSet<Dvorana> entities = new HashSet<Dvorana>();
            DatotekaCreator<Dvorana> dc = (DatotekaCreator<Dvorana>)new DvoranaConcreteCreator();
            DatotekaProduct<Dvorana> dp = dc.CreateProduct();
            entities = dp.GetEntities(fileName);
            return entities;
        }
        public static HashSet<Kolokvij> GetValuesForKolokvijs(string fileName)
        {
            HashSet<Kolokvij> entities = new HashSet<Kolokvij>();
            DatotekaCreator<Kolokvij> dc = (DatotekaCreator<Kolokvij>)new KolokvijConcreteCreator();
            DatotekaProduct<Kolokvij> dp = dc.CreateProduct();
            entities = dp.GetEntities(fileName);
            return entities;
        }
    }

}
