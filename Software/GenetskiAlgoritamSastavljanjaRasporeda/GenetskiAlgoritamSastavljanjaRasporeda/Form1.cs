using GenetskiAlgoritamSastavljanjaRasporeda.Controller;
using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod;
using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteCreator;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenetskiAlgoritamSastavljanjaRasporeda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UcitajDatoteke();
        }

        private void UcitajDatoteke()
        {
            Data.GetInstance().AllStudents= AbstractFactory.GetValuesForStudents("studenti.csv");
            Data.GetInstance().AllKolegij = AbstractFactory.GetValuesForKolegijs("kolegij.csv");
            Data.GetInstance().AllProfesor = AbstractFactory.GetValuesForProfesors("profesori.csv");
            Data.GetInstance().AllDvorana = AbstractFactory.GetValuesForDvoranas("dvorana.csv");
            Data.GetInstance().AllKolokvij = AbstractFactory.GetValuesForKolokvijs("kolokvij.csv");
        }
    }
}
