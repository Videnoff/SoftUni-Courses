using System;

namespace MovieRatings
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double highest = double.MinValue;
            double average = 0.0;
            double lowest = double.MaxValue;
            double currentR = 0.0;
            string currF = string.Empty;
            double sumRatings = 0.0;
            string currD = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                string filmName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                currentR = rating;
                sumRatings += rating;

                if (currentR < lowest)
                {
                    lowest = currentR;
                    currD = filmName;
                }
                if (currentR > highest)
                {
                    highest = currentR;
                    currF = filmName;
                }
            }
            average = sumRatings / n;

            Console.WriteLine($"{currF} is with highest rating: {highest:F1}");
            Console.WriteLine($"{currD} is with lowest rating: {lowest:F1}");
            Console.WriteLine($"Average rating: {average:F1}");
        }
    }
}
