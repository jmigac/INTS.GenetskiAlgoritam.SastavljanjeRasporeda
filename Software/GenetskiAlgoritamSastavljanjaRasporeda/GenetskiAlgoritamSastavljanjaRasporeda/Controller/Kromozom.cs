using Accord.Genetic;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetskiAlgoritamSastavljanjaRasporeda.Controller
{
    

    class Kromozom : ChromosomeBase
    {
        public List<TimeSlotChromosome> Value;

        static Random Random = new Random();
        public struct TimeSlotChromosome
        {
            public int id { get; set; }
            public DateTime VrijemePocetka { get; set; }
            //nesmije poceti prije radnog vremena
            public Kolegij Kolegij { get; set; }
            public int TipKolokvija { get; set; }
            //lab=0 ili obicni=1
            public Dvorana Dvorana { get; set; }
            //mora odgovarati tipu kolokvija
            public DateTime VrijemeZavrsetka { get => VrijemePocetka.AddHours(1); set { } }

            public Profesor Profesor { get; set; }

            public List<Student> Students { get; set; }
        }


        public Kromozom()
        {
            Generate();
        }

        public Kromozom(List<TimeSlotChromosome> list)
        {
            Value = list.ToList();
        }

        public override void Generate()
        {
            IEnumerable<TimeSlotChromosome> generateRandomSlots()
            {
                var courses = Data.GetInstance().AllKolegij;

                foreach (var course in courses)
                {
                    foreach (var nesto in course.CiljaniDatum)
                    {
                        int brStudenata = GetBrojStudenataNaGodini(course.GodinaStudija);
                        int tk=Random.Next(0, 2);
                        yield return new TimeSlotChromosome()
                        {
                            VrijemePocetka = nesto.AddHours(Random.Next(6, 21)),
                            Kolegij = course,
                            TipKolokvija = tk,
                            Dvorana = Data.GetInstance().AllDvorana.FirstOrDefault(x => x.Kapacitet >= brStudenata && x.TipDvorane == tk),
                            //Profesor = Data.GetInstance().AllProfesor.Where(x => x.Kolegiji.Contains(course)).FirstOrDefault(),
                            Students = Data.GetInstance().AllStudents.Where(x => x.GodinaStudija == course.GodinaStudija).ToList()
                        };
                    }

                }
            }
            Value = generateRandomSlots().ToList();
        }

        public override IChromosome CreateNew()
        {
            var novi = new Kromozom();
            novi.Generate();
            return novi;
        }

        public override IChromosome Clone()
        {
            return new Kromozom(Value);
        }

        public override void Mutate()
        {
            var index = Random.Next(0, Value.Count - 1);
            var Mutirani = Value.ElementAt(index);
            if(Mutirani.VrijemePocetka.Hour<20&& Mutirani.VrijemePocetka.Hour > 6)
            {
                Mutirani.VrijemePocetka.AddHours(1);
            }

            int brStudenata = GetBrojStudenataNaGodini(Mutirani.Kolegij.GodinaStudija);



            Mutirani.Dvorana = Data.GetInstance().AllDvorana.FirstOrDefault(x => x.Kapacitet >= brStudenata && x.TipDvorane == Mutirani.TipKolokvija);
            Value[index] = Mutirani;
        }

        public override void Crossover(IChromosome pair)
        {
            var randomVal = Random.Next(0, Value.Count - 2);
            var otherChromsome = pair as Kromozom;
            for (int index = randomVal; index < otherChromsome.Value.Count; index++)
            {
                Value[index] = otherChromsome.Value[index];
            }
        }

        private int GetBrojStudenataNaGodini(int godina)
        {
            return Data.GetInstance().AllStudents.Where(x => x.GodinaStudija == godina).Count();
        }

        public class Fitness : IFitnessFunction
        {
            public double Evaluate(IChromosome chromosome)
            {
                double score = 1;
                var values = (chromosome as Kromozom).Value;
                var GetoverLaps = new Func<TimeSlotChromosome, List<TimeSlotChromosome>>(current => values
                    .Except(new[] { current })
                    .Where(slot => slot.VrijemePocetka.Day == current.VrijemePocetka.Day)
                    .Where(slot => slot.VrijemePocetka == current.VrijemePocetka
                                  || slot.VrijemePocetka <= current.VrijemeZavrsetka && slot.VrijemePocetka >= current.VrijemePocetka
                                  || slot.VrijemeZavrsetka >= current.VrijemePocetka && slot.VrijemeZavrsetka <= current.VrijemeZavrsetka)
                    .ToList());



                foreach (var value in values)
                {
                    var overLaps = GetoverLaps(value);
                    //score -= overLaps.GroupBy(slot => slot.Profesor.Id).Sum(x => x.Count() - 1);
                    score -= overLaps.GroupBy(slot => slot.Dvorana.Id).Sum(x => x.Count() - 1);
                    score -= overLaps.GroupBy(slot => slot.Kolegij.Id).Sum(x => x.Count() - 1);
                    score -= overLaps.Sum(item => item.Students.Intersect(value.Students).Count());
                }

                score -= values.GroupBy(v => v.VrijemePocetka.Day).Count() * 0.5;
                return Math.Pow(Math.Abs(score), -1);
            }
        }
    }
}
