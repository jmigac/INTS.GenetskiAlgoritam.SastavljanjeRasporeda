using GenetskiAlgoritamSastavljanjaRasporeda.Controller;
using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod;
using GenetskiAlgoritamSastavljanjaRasporeda.Controller.FactoryMethod.ConcreteCreator;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Data.GetInstance().AllStudents= AbstractFactory.GetValuesForStudents(@"D:\Workspace\Projekt\INTS\INTS.GenetskiAlgoritam.SastavljanjeRasporeda\Software\GenetskiAlgoritamSastavljanjaRasporeda\GenetskiAlgoritamSastavljanjaRasporeda\Datoteke\studenti.csv");
            string st = "";
            foreach (var item in Data.GetInstance().AllStudents)
            {
                st += item.Ime + " " + item.Prezime + " | ";
            }
            //MessageBox.Show(st);
        }
    }
}
