using System;

namespace SumSeconds
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstChall = int.Parse(Console.ReadLine());
            int secondChall = int.Parse(Console.ReadLine());
            int thirdChall = int.Parse(Console.ReadLine());

            int sum = firstChall + secondChall + thirdChall;
            int mins = sum / 60;
            int secs = sum % 60;

            Console.WriteLine($"{mins}:{secs:D2}");
        }
    }
}
