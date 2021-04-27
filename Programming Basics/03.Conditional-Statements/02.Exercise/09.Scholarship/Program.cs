using System;

namespace Scholarship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double socialScholarship = minimalSalary * 35 / 100;
            double gradeScholarship = grade * 25;

            if (grade >= 5.5)
            {
                if (income >= minimalSalary)
                {
                    Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(gradeScholarship));
                }
                else if (income < minimalSalary)
                {
                    if (gradeScholarship >= socialScholarship)
                    {
                        Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(gradeScholarship));
                    }
                    else
                    {
                        Console.WriteLine("You get a Social scholarship {0} BGN", Math.Floor(socialScholarship));
                    }
                }
            }
            else if (grade > 4.5)
            {
                if (income < minimalSalary)
                {
                    Console.WriteLine("You get a Social scholarship {0} BGN", Math.Floor(socialScholarship));
                }
                else if (income >= minimalSalary)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
            else if (grade <= 4.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
