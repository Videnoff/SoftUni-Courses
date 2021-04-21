using System;

namespace LeftandRightSum
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                leftSum += a;
            }
            for (int i = 1; i <= n; i++)
            {
                int b = int.Parse(Console.ReadLine());
                rightSum += b;
            }
            int diff = Math.Abs(leftSum - rightSum);

            if (diff == 0)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
