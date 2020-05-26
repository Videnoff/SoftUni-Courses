using System;

namespace BackIn30Minutes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int hoursInMins = hours * 60;
            int totalTime = hoursInMins + minutes;
            int timeAfterThirty = totalTime + 30;
            int afterHours = timeAfterThirty / 60;
            int afterMins = timeAfterThirty % 60;

            if (afterHours > 23)
            {
                afterHours = afterHours - 24;
            }
            if (afterMins > 60)
            {
                afterHours++;
            }
            Console.WriteLine($"{afterHours}:{afterMins:D2}");
        }
    }
}
