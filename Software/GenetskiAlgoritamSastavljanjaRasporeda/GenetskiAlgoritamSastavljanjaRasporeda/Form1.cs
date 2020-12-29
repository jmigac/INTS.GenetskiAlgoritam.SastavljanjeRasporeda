﻿using Accord.Genetic;
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


            Population population = new Population(1000, new Kromozom(), new Kromozom.Fitness(), new EliteSelection());

            int i = 0;
            while (true)
            {
                population.RunEpoch();
                i++;
                if (population.FitnessMax >= 0.99 || i >= 1000)
                {
                    break;
                }
            }

            var najbolji = (population.BestChromosome as Kromozom).Value.ToList();

            foreach(var neki in najbolji) {
                MessageBox.Show(neki.VrijemePocetka.ToString());
            }

        }

        private void UcitajDatoteke()
        {
            Data.GetInstance().AllStudents= AbstractFactory.GetValuesForStudents("studenti.csv");
            Data.GetInstance().AllKolegij = AbstractFactory.GetValuesForKolegijs("kolegij.csv");
            Data.GetInstance().AllProfesor = AbstractFactory.GetValuesForProfesors("profesori.csv");
            Data.GetInstance().AllDvorana = AbstractFactory.GetValuesForDvoranas("dvorana.csv");
            //Data.GetInstance().AllKolokvij = AbstractFactory.GetValuesForKolokvijs("kolokvij.csv");
        }
    }
}
