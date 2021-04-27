using System;

namespace Threebrothers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double firstBrotherTime = double.Parse(Console.ReadLine());
            double secondBrotherTime = double.Parse(Console.ReadLine());
            double thirdBrotherTime = double.Parse(Console.ReadLine());
            double fathersFishing = double.Parse(Console.ReadLine());

            double FBcleaningTime = 1 / firstBrotherTime;
            double SBcleaningTime = 1 / secondBrotherTime;
            double TBcleaningTime = 1 / thirdBrotherTime;

            double totalTime = 1 / (FBcleaningTime + SBcleaningTime + TBcleaningTime);
            double finalTime = totalTime + totalTime * 15 / 100;

            double time = fathersFishing - finalTime;
            double diff = Math.Abs(fathersFishing - finalTime);


            Console.WriteLine("Cleaning time: {0:F2}", finalTime);

            if (time >= 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(diff)} hours.");
            }
            else
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(diff)} hours.");
            }
        }
    }
}
