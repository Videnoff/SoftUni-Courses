using System;

namespace Graduationpt
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int counter = 1;
            double sum = 0;
            double excluded = 0;
            bool isExcluded = false;


            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    excluded++;
                }
                else if (grade >= 4.00)
                {
                    sum += grade;
                    counter++;
                }
                if (excluded >= 2)
                {
                    isExcluded = true;
                    break;
                }
            }

            if (isExcluded == false)
            {
                double average = sum / 12;
                Console.WriteLine($"{s} graduated. Average grade: {average:F2}");
            }
            else
            {
                Console.WriteLine($"{s} has been excluded at {counter} grade");
            }
        }
    }
}
