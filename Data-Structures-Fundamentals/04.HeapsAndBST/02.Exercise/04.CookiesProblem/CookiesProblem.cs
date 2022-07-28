using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>(cookies);
            var smallestElement = bag.GetFirst();
            var steps = 0;

            while (smallestElement < k && bag.Count > 1)
            {
                var smallestCookie = bag.RemoveFirst();
                var secondSmallestCookie = bag.RemoveFirst();

                steps++;

                bag.Add(smallestCookie + 2 * secondSmallestCookie);
                smallestElement = bag.GetFirst();
            }

            return smallestElement >= k ? steps : -1;
        }
    }
}
