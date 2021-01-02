using Accord.Genetic;
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
using System.Threading;
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
        }

        private void StartGenetskiAlgoritam(double fitnessMax,int brGeneracija)
        {
            dgvRasporedKolokvija.DataSource = null;
            Population population = new Population(brGeneracija, new Kromozom(), new Kromozom.Fitness(), new EliteSelection());

            int i = 0;
            while (true)
            {
                population.RunEpoch();
                i++;
                lblScore.Text = "Fitness:" + population.FitnessMax;
                if (population.FitnessMax >= fitnessMax || i >= brGeneracija)
                {
                    break;
                }
            }

            var najbolji = (population.BestChromosome as Kromozom).Value.ToList();

            dgvRasporedKolokvija.DataSource = null;
            najbolji.Sort((x, y) => DateTime.Compare(x.VrijemePocetka, y.VrijemePocetka));
            dgvRasporedKolokvija.DataSource = najbolji;
        }

        private void btnGeneriraj_Click(object sender, EventArgs e)
        {
            try
            {
                double fitnessMax = double.Parse(txtFitnessMax.Text);
                int brGeneracija = int.Parse(txtBrGeneracija.Text);
                StartGenetskiAlgoritam(fitnessMax, brGeneracija);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Pogreška kod parsiranja unesenih vrijednosti."+Environment.NewLine+"Koristim sljedeće vrijednosti: maksimalna vrijednost za fitness = 0.99, a broj generacija = 35");
                StartGenetskiAlgoritam(0.99, 35);
            }
            
            
        }
    }
}
