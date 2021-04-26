using System;

namespace Volleyball
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsHome = int.Parse(Console.ReadLine());

            int weekendsSofia = 48 - weekendsHome;
            double sofiaWeekendsPlay = weekendsSofia * (3.0 / 4.0);
            double holidayPlay = holidays * (2.0 / 3.0);

            double totalPlay = sofiaWeekendsPlay + holidayPlay + weekendsHome;

            if (yearType == "leap")
            {
                totalPlay += (totalPlay * 15.0) / 100.0;
                Console.WriteLine($"{Math.Floor(totalPlay)}");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(totalPlay)}");
            }

        }
    }
}
