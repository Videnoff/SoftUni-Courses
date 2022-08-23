var n = 10;
Console.WriteLine(GetFibonacci(n));

int GetFibonacci(int n)
{
    if (n <= 1)
    {
        return 1;
    }

    return GetFibonacci(n - 1) + GetFibonacci(n - 2);
}
