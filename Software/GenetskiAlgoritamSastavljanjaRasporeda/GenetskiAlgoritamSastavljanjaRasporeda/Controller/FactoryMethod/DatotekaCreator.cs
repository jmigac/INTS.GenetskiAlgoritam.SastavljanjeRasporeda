using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod
{
    public interface DatotekaCreator<T>
    {
        DatotekaProduct<T> CreateProduct();
    }
}
