using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteProduct;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteCreator
{
    class KolokvijConcreteCreator : DatotekaCreator<Kolokvij>
    {
        public DatotekaProduct<Kolokvij> CreateProduct()
        {
            return new KolokvijConcreteProduct();
        }
    }
}
