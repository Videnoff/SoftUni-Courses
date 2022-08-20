var n = int.Parse(Console.ReadLine());
Console.WriteLine(CalcFact(n));

int CalcFact(int n)
{
    if (n == 0)
    {
        return 1;
    }

    return n * CalcFact(n - 1);
}
