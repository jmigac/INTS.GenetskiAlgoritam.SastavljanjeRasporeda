using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller
{
    class Data
    {
        private static Data INSTANCE = null;
        private static readonly object padlock = new object();

        public HashSet<Student> AllStudents { get; set; }
        public HashSet<Dvorana> AllDvorana { get; set; }
        public HashSet<Kolegij> AllKolegij { get; set; }
        public HashSet<Kolokvij> AllKolokvij { get; set; }
        public HashSet<Profesor> AllProfesor { get; set; }

        private Data() { }
        public static Data GetInstance()
        {
            if (INSTANCE == null)
            {
                lock (padlock)
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new Data();
                    }
                }
            }
            return INSTANCE;
        }

    }
}
