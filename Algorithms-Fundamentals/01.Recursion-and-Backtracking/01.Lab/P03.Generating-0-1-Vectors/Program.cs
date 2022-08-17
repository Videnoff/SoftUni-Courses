var n = int.Parse(Console.ReadLine());
var vector = new int[n];

Gen01(vector, 0);

void Gen01(int[] vector, int index)
{
    for (int number = 0; number <= 1; number++)
    {
        if (index == vector.Length)
        {
            Console.WriteLine(string.Join(" ", vector));
            return;
        }
        
        vector[index] = number;
        Gen01(vector, index + 1);
    }
}
