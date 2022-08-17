var n = int.Parse(Console.ReadLine());

DrawFigure(n);

void DrawFigure(int size)
{
    if (size == 0)
    {
        return;
    }

    Console.WriteLine(new string('*', size));
    
    DrawFigure(size - 1);

    Console.WriteLine(new string('#', size));
}
