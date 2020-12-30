using Accord.Genetic;
using Accord.Math;
using GenetskiAlgoritamSastavljanjaRasporeda.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                int idGeneratora = 1;

                foreach (var course in courses)
                {
                    foreach (var nesto in course.CiljaniDatum)
                    {
                        int brStudenata = GetBrojStudenataNaGodini(course.GodinaStudija);
                        int tk=Random.Next(0, 2);
                        
                        yield return new TimeSlotChromosome()
                        {
                            id = idGeneratora++,
                            VrijemePocetka = nesto.AddHours(Random.Next(6, 21)),
                            Kolegij = course,
                            TipKolokvija = tk,
                            //Dvorana sa kapacitetom i dobrog tipa
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

            while (BrojKolokvijaUTjednu(Mutirani.VrijemePocetka) >= 3)
            {
                if (Mutirani.VrijemePocetka.DayOfWeek == DayOfWeek.Saturday)
                {
                    Mutirani.VrijemePocetka = Mutirani.VrijemePocetka.AddDays(Random.Next(2,5));
                }else if (Mutirani.VrijemePocetka.DayOfWeek == DayOfWeek.Sunday)
                {
                    Mutirani.VrijemePocetka = Mutirani.VrijemePocetka.AddDays(Random.Next(1, 5));
                }
                else
                {
                    Mutirani.VrijemePocetka = Mutirani.VrijemePocetka.AddDays(7);
                }
                
                Value[index] = Mutirani;
            }

            if(Mutirani.VrijemePocetka.Hour>=19 && Mutirani.VrijemePocetka.Hour <= 6)
            {
                Mutirani.VrijemePocetka = Mutirani.VrijemePocetka.AddHours(1);
            }else if(Mutirani.VrijemePocetka.Hour >= 20 && Mutirani.VrijemePocetka.Hour <= 7)
            {
                Mutirani.VrijemePocetka = Mutirani.VrijemePocetka.AddHours(-1);
            }


            int brStudenata = GetBrojStudenataNaGodini(Mutirani.Kolegij.GodinaStudija);
            Mutirani.Dvorana = Data.GetInstance().AllDvorana.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Kapacitet >= brStudenata && x.TipDvorane == Mutirani.TipKolokvija);

            Value[index] = Mutirani;

        }

        private int BrojKolokvijaUTjednu(DateTime vrijemePocetka)
        {
           
            Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;
            
            Dictionary<int, List<TimeSlotChromosome>> kolokviji = new Dictionary<int, List<TimeSlotChromosome>>();
            for (int i = 0; i < 54; i++)
            {
                kolokviji.Add(i, new List<TimeSlotChromosome>());
            }

             for(int i = 0; i < Value.Count; i++)
            {
                int tjedanGodine = cal.GetWeekOfYear(Value[i].VrijemePocetka, 0, DayOfWeek.Monday);
                kolokviji[tjedanGodine].Add(Value[i]);
            }


            return kolokviji[cal.GetWeekOfYear(vrijemePocetka, 0, DayOfWeek.Monday)].Count;
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

                Calendar cal = DateTimeFormatInfo.CurrentInfo.Calendar;

                var GetoverLapsWeek = new Func<TimeSlotChromosome, List<TimeSlotChromosome>>(current => values
                    .Except(new[] { current })
                    .Where(slot => cal.GetWeekOfYear(slot.VrijemePocetka, 0, DayOfWeek.Monday) == cal.GetWeekOfYear(current.VrijemePocetka, 0, DayOfWeek.Monday))
                    .ToList());

                var GetoverLapsDay = new Func<TimeSlotChromosome, List<TimeSlotChromosome>>(current => values
                    .Except(new[] { current })
                    .Where(slot => slot.VrijemePocetka == current.VrijemePocetka)
                    .ToList());



                foreach (var value in values)
                {
                    Debug.WriteLine("Velicina Overlap Tjedna: " + GetoverLapsWeek(value).Count());
                    Debug.WriteLine("Velicina Overlap Dana: " + GetoverLapsDay(value).Count());

                    var dayOverLaps = GetoverLapsDay(value);
                    var weekOverLaps = GetoverLapsWeek(value);

                    //Profesor u isto vrijeme
                    score -= dayOverLaps.GroupBy(slot => slot.Profesor.Id).Sum(x => x.Count() - 1);
                    if (dayOverLaps.GroupBy(slot => slot.Profesor.Id).Sum(x => x.Count() - 1) >= 1)
                    {
                        Debug.WriteLine("Kazna za Profesor u isto vrijeme - " + value.VrijemePocetka + " " + value.Kolegij);
                    }

                    //Dvorana u isto vrijeme
                    score -= dayOverLaps.GroupBy(slot => slot.Dvorana.Id).Sum(x => x.Count() - 1);
                    if (dayOverLaps.GroupBy(slot => slot.Dvorana.Id).Sum(x => x.Count() - 1) >= 1)
                    {
                        Debug.WriteLine("Kazna za Dvorana u isto vrijeme - " + value.VrijemePocetka + " " + value.Kolegij);
                    }

                    //Godina Studija u isto vrijeme
                    score -= dayOverLaps.GroupBy(slot => slot.GodinaStudija).Sum(x => x.Count() - 1);
                    if (dayOverLaps.GroupBy(slot => slot.GodinaStudija).Sum(x => x.Count() - 1) >= 1)
                    {
                        Debug.WriteLine("Kazna za Studija u isto vrijeme - " + value.VrijemePocetka + " " + value.Kolegij);
                    }

                    //Dvorana dobrog tipa
                    if (value.TipKolokvija != value.Dvorana.TipDvorane)
                    {
                        score -= 1;
                        Debug.WriteLine("Kazna za Dvorana krivog tipa - " + value.VrijemePocetka + " " + value.Kolegij);
                    }

                    //Dvorana sa dosta kapaciteta
                    if (value.Students.Count > value.Dvorana.Kapacitet)
                    {
                        score -= 1;
                        Debug.WriteLine("Kazna za Dvorana bez kapaciteta - " + value.VrijemePocetka + " " + value.Kolegij);
                    }

                    int[] godineStudija = new int[5];

                    //3 kolokvija u GodiniStudija
                    foreach (var nesto in weekOverLaps)
                    {
                        godineStudija[nesto.GodinaStudija - 1]++;
                    }
                    foreach (var nesto in godineStudija)
                    {
                        if (nesto > 3)
                        {
                            score -= (nesto - 3)*1.5;
                            Debug.WriteLine("Kazna za 3 kolokvija iste godine studija u jednom tjednu - " + value.VrijemePocetka + " / Godina Studija: " + value.Kolegij.GodinaStudija + " -> komada: " + nesto);
                        }
                    }

                    //Kazna za kolokvij u subotu ili nedjelju
                    if (value.VrijemePocetka.DayOfWeek == DayOfWeek.Saturday|| value.VrijemePocetka.DayOfWeek == DayOfWeek.Sunday)
                    {
                        score -= 1;
                        Debug.WriteLine("Kazna za subotu ili nedjelju - " + value.VrijemePocetka + " " + value.Kolegij );
                    }

                    //Kazna za kolokvij izvan radnog vremena
                    if (value.VrijemePocetka.Hour > 20 || value.VrijemePocetka.Hour < 6)
                    {
                        score -= 1;
                        Debug.WriteLine("Kazna za kolokvij izvan radnog vremena - " + value.VrijemePocetka + " " + value.Kolegij);
                    }
                }




                return Math.Pow(Math.Abs(score), -1);
            }
        }
    }
}
