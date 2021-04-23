using System;

namespace ExamPreparation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int poorGrades = int.Parse(Console.ReadLine());
            int countPoorGrades = 0;
            double sumGrades = 0;
            int counterForGrades = 0;
            string lastProblem = "";

            while (countPoorGrades < poorGrades)
            {
                string problemName = Console.ReadLine();
                if (problemName != "Enough")
                {
                    lastProblem = problemName;
                }
                if (problemName == "Enough")
                {
                    double averageGrade = sumGrades / counterForGrades;
                    Console.WriteLine($"Average score: {averageGrade:F2}");
                    Console.WriteLine($"Number of problems: {counterForGrades}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }
                int grade = int.Parse(Console.ReadLine());

                sumGrades += grade;
                counterForGrades++;

                if (grade <= 4)
                {
                    countPoorGrades ++;;
                }

            }

            if (countPoorGrades == poorGrades)
            {
                Console.WriteLine($"You need a break, {countPoorGrades} poor grades.");
            }
        }
    }
}
