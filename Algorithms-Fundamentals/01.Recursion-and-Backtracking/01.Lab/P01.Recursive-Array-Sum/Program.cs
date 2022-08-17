var array = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(CalcSum(array, array.Length - 1));

int CalcSum(int[] array, int index)
{
    if (index == 0)
    {
        return array[index];
    }

    return array[index] + CalcSum(array, index - 1);
}
    
