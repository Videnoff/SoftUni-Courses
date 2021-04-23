using System;

namespace Graduation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int counter = 1;
            double sum = 0;


            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum += grade;
                    counter++;
                }
            }
            double average = sum / 12;
            Console.WriteLine($"{s} graduated. Average grade: {average:F2}");
        }
    }
}
