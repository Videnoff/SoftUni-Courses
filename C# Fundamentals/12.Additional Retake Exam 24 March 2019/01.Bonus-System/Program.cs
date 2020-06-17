using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace BonusSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            int maxAttendance = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double studentBonus = (double)attendances / lecturesCount * (5 + additionalBonus);

                if (studentBonus > maxBonus)
                {
                    maxBonus = studentBonus;
                    maxAttendance = attendances;
                }
            }

            Console.WriteLine($"The maximum bonus score for this course is {Math.Ceiling(maxBonus)}.The student has attended {maxAttendance} lectures.");
        }
    }
}
