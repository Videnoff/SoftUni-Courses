using System;
using System.Linq;
namespace EvenandOddSubtraction
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evens = 0;
            int odds = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (num % 2 == 0)
                {
                    evens += num;
                }
                else
                {
                    odds += num;
                }
            }
            int diff = evens - odds;
            Console.WriteLine(diff);
        }
    }
}
