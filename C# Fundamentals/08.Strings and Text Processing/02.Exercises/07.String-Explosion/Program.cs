using System;

namespace StringExplosion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splittedInput = input.Split(new[] { ">" }, StringSplitOptions.RemoveEmptyEntries);
            string result = splittedInput[0];
            int remainingPower = 0;

            for (int i = 1; i < splittedInput.Length; i++)
            {
                result += ">";
                int power = int.Parse(splittedInput[i][0].ToString()) + remainingPower;

                if (power > splittedInput[i].Length)
                {
                    remainingPower = power - splittedInput[i].Length;
                }
                else
                {
                    result += splittedInput[i].Substring(power);
                }
            }

            Console.WriteLine(result);

        }
    }
}
