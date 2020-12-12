using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod
{
    public interface DatotekaProduct<T>
    {
        HashSet<T> GetEntities(string fileName);
        bool FileExist(string fileName);
    }
}
