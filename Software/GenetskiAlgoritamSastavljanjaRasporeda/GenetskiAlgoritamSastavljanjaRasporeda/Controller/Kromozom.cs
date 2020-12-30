using Accord.Genetic;
using Accord.Math;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            public int GodinaStudija { get; set; }
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
                        int idGeneratora = 1;
                        yield return new TimeSlotChromosome()
                        {
                            id = idGeneratora++,
                            VrijemePocetka = nesto.AddHours(Random.Next(6, 21)),
                            Kolegij = course,
                            TipKolokvija = tk,
                            Dvorana = Data.GetInstance().AllDvorana.OrderBy(x=>Guid.NewGuid()).FirstOrDefault(x => x.Kapacitet >= brStudenata && x.TipDvorane == tk),
                            Profesor = GetProfesor(course),
                            Students = Data.GetInstance().AllStudents.Where(x => x.GodinaStudija == course.GodinaStudija).ToList(),
                            GodinaStudija = course.GodinaStudija
                        
                        };
                    }

                }
            }
            Value = generateRandomSlots().ToList();
            
        }

        private Profesor GetProfesor(Kolegij course)
        {
            Profesor returnMe = null;
            foreach (var p in Data.GetInstance().AllProfesor)
            {
                if (p.Kolegiji.Count > 0)
                {
                    foreach (var k in p.Kolegiji)
                    {
                        if (k.Id == course.Id)
                        {
                            returnMe = p;
                            break;
                        }

                    }
                }
                   
            }
            return returnMe;
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
            Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
            if (Mutirani.VrijemePocetka.Hour<20&& Mutirani.VrijemePocetka.Hour > 6)
            {
                Dictionary<int,List<TimeSlotChromosome>> kolokvijiPoTjednima = CheckIfThreeKolokvijsInAWeek();
                int tjedanKolokvija = cal.GetWeekOfYear(Mutirani.VrijemePocetka, 0, DayOfWeek.Monday);
                if (kolokvijiPoTjednima.ContainsKey(tjedanKolokvija))
                {
                    if (kolokvijiPoTjednima[tjedanKolokvija].Count >= 3)
                    {
                        Mutirani.VrijemePocetka= Mutirani.VrijemePocetka.AddDays(7);
                        string ispis = "";
                        foreach (var item in kolokvijiPoTjednima[tjedanKolokvija])
                        {
                            ispis += item.Kolegij.Naziv + " " + "\n";
                        }
                        //System.Windows.Forms.MessageBox.Show("Tjedan:"+tjedanKolokvija+"\n"+"Kolegiji:"+"\n"+ispis+"\n"+"Mutirani:"+"\n"+Mutirani.Kolegij.Naziv+"\n"+Mutirani.VrijemePocetka+"\n"+Mutirani.VrijemeZavrsetka);
                    }
                }
                
                
            }


            int brStudenata = GetBrojStudenataNaGodini(Mutirani.Kolegij.GodinaStudija);
            Mutirani.Dvorana = Data.GetInstance().AllDvorana.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Kapacitet >= brStudenata && x.TipDvorane == Mutirani.TipKolokvija);
            Value[index] = Mutirani;

            


        }

        private Dictionary<int, List<TimeSlotChromosome>> CheckIfThreeKolokvijsInAWeek()
        {
            Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
            int count = 0;
            int MAX_KOLOKVIJS = 3;
            Dictionary<int, List<TimeSlotChromosome>> kolokviji = new Dictionary<int, List<TimeSlotChromosome>>();
            for(int i = 0; i < 54; i++)
            {
                kolokviji.Add(i, new List<TimeSlotChromosome>());
            }
            for(int i = 0; i < Value.Count; i++)
            {
                int tjedanGodine = cal.GetWeekOfYear(Value[i].VrijemePocetka, 0, DayOfWeek.Monday);
                kolokviji[tjedanGodine].Add(Value[i]);
            }
            return kolokviji;
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
                List<TimeSlotChromosome> toDelete = new List<TimeSlotChromosome>();

                var GetoverLaps = new Func<TimeSlotChromosome, List<TimeSlotChromosome>>(current => values
                    .Except(new[] { current })
                    .Where(slot => slot.VrijemePocetka.Day == current.VrijemePocetka.Day)
                    .Where(slot => slot.VrijemePocetka == current.VrijemePocetka
                                  || slot.VrijemePocetka <= current.VrijemeZavrsetka && slot.VrijemePocetka >= current.VrijemePocetka
                                  || slot.VrijemeZavrsetka >= current.VrijemePocetka && slot.VrijemeZavrsetka <= current.VrijemeZavrsetka)
                    .ToList());

                Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
                
                foreach (var value in values)
                {
                    var overLaps = GetoverLaps(value);
                    score -= overLaps.GroupBy(slot => slot.Profesor.Id).Sum(x => x.Count() - 1);
                    score -= overLaps.GroupBy(slot => slot.Dvorana.Id).Sum(x => x.Count() - 1);
                    score -= overLaps.GroupBy(slot => slot.Kolegij.Id).Sum(x => x.Count() - 1);
                    score -= overLaps.Sum(item => item.Students.Intersect(value.Students).Count());
                    score -= overLaps.GroupBy(slot => slot.Kolegij.GodinaStudija).Sum(x => x.Count() - 1);
                    score -= (overLaps.GroupBy(s => cal.GetWeekOfYear(s.VrijemePocetka,0,DayOfWeek.Monday)).Sum(s=>s.Count()-1)*3);
                }

                score -= values.GroupBy(v => v.VrijemePocetka.Day).Count() * 0.5;
                return Math.Pow(Math.Abs(score), -1);
            }
        }
    }
}
