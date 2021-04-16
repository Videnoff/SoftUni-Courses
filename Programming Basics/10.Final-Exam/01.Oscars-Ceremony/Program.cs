using System;

namespace OscarsCeremony
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double figures = rent - (rent * 30) / 100;
            double catering = figures - (figures * 15) / 100;
            double sound = catering / 2;

            double total = rent + figures + catering + sound;

            Console.WriteLine($"{total:F2}");
        }
    }
}
