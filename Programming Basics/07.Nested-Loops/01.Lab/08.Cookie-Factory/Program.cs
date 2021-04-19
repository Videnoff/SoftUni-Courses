using System;

namespace CookieFactory
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int batchesCount = int.Parse(Console.ReadLine());
            bool containsEggs = false;
            bool containsFlour = false;
            bool containsSugar = false;

            for (int i = 1; i <= batchesCount; i++)
            {
                

                string product = string.Empty;

                while (!containsEggs && !containsFlour && !containsSugar)
                {
                    product = Console.ReadLine();

                    if (product == "eggs")
                    {
                        containsEggs = true;
                    }
                    else if (product == "flour")
                    {
                        containsFlour = true;
                    }
                    else if (product == "sugar")
                    {
                        containsSugar = true;
                    }
                    else if (product == "Bake!")
                    {
                        if (containsEggs && containsFlour && containsSugar)
                        {
                            Console.WriteLine($"Baking batch number {i} …");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                    }
                }
            }
        }
    }
}
