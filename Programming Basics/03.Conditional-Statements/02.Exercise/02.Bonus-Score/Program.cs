using System;

namespace BonusScore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double bonus = 0;
            if (n <= 100)
            {
                bonus += 5;
                if (n % 2 == 0)
                {
                    bonus++;
                }
                if (n % 10 == 5)
                {
                    bonus += 2;
                }
               
            }
            else if (n > 100 && n <= 1000)
            {
                if (n % 2 == 0)
                {
                    bonus++;
                }
                if (n % 10 == 5)
                {
                    bonus += 2;
                }
                bonus += n * 0.2;
            }
            else if (n > 1000)
            {
                if (n % 2 == 0)
                {
                    bonus++;
                }
                if (n % 10 == 5)
                {
                    bonus += 2;
                }
                bonus += n * 0.1;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(n + bonus);
        }
    }
}
