using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteCreator
{
    class StudentConcreteCreator : DatotekaCreator<Student>
    {
        public DatotekaProduct<Student> CreateProduct()
        {
            return new StudentConcreteProduct();
        }
    }
}
