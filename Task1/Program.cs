using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public enum Frequency { Weekly = 1, Monthly = 2, Yearly = 3}
    class Magazine
    {
        public string Title { get; set; }
        public Frequency Periodicity { get; set; }
        public DateTime Release { get; set; }
        public int Edition { get; set; }

        public Magazine(string title, Frequency periodicity, DateTime release, int edition)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Periodicity = periodicity;
            Release = release;
            Edition = edition;
        }
        public Magazine()
        {
            Title = null;
            Periodicity = Frequency.Weekly;
            Release = new DateTime();
            Edition = 0;
        }
        public override string ToString()
        {
            return $"{Title}, {Periodicity}, {Release}, {Edition}";
        }
    }

    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            var listMagazine = new List<Magazine>();
            for (int i = 0; i < 5; i++)
            {
                var title = "Title " + i;
                var periodicity = RandomFrequency();
                var release = RandomDay();
                var edition = rnd.Next(30, 400);
                listMagazine.Add(new Magazine(title, periodicity, release, edition));
            }
            Console.WriteLine("Список всех журналов:");
            Output(listMagazine);
            Console.WriteLine("Введите параметр поиска: 'A' - еженедельный выпуск, 'B' - ежемесячный, 'С' - ежегодный");
            string key = Console.ReadLine();
            bool flag = true;
            while (flag)
            {
                switch (key)
                {
                    case "A":
                        Output(listMagazine.Where(s => s.Periodicity == Frequency.Weekly).ToList());
                        flag = false;
                        break;
                    case "B":
                        Output(listMagazine.Where(s => s.Periodicity == Frequency.Weekly).ToList());
                        flag = false;
                        break;
                    case "C":
                        Output(listMagazine.Where(s => s.Periodicity == Frequency.Weekly).ToList());
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное значение");
                        flag = false;
                        break;

                }
            }
        }
        private static void Output(List<Magazine> list)
        {
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
        }
        private static DateTime RandomDay()
        {
            var start = new DateTime(2010, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
        private static Frequency RandomFrequency()
        {
            switch (rnd.Next(1, 3))
            {
                case 1:
                    return Frequency.Weekly;
                case 2:
                    return Frequency.Monthly;
                case 3:
                    return Frequency.Yearly;
                default:
                    return Frequency.Weekly;
            }
        }
    }
}
