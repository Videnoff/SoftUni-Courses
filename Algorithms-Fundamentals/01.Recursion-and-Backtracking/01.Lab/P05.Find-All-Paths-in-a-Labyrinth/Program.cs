using Microsoft.VisualBasic;

var rows = int.Parse(Console.ReadLine());
var cols = int.Parse(Console.ReadLine());

var lab = new char[rows, cols];

for (int r = 0; r < rows; r++)
{
    var line = Console.ReadLine();

    for (int c = 0; c < line.Length; c++)
    {
        lab[r, c] = line[c];
    }
}

var directions = new List<char>();

FindAllPaths(lab, 0, 0, directions, '\0');

void FindAllPaths(char[,] lab, int row, int col, List<char> directions, char direction)
{
    if (IsOutside(lab, row, col) || IsWall(lab, row, col) || IsVisited(lab, row, col))
    {
        return;
    }
    
    directions.Add(direction);

    if (IsSolution(lab, row, col))
    {
        Console.WriteLine(string.Join("", directions));
        directions.RemoveAt(directions.Count - 1);

        return;
    }
 
    lab[row, col] = 'v';

    FindAllPaths(lab, row, col + 1, directions, 'R');
    FindAllPaths(lab, row, col - 1, directions, 'L');
    FindAllPaths(lab, row - 1, col, directions, 'U');
    FindAllPaths(lab, row + 1, col, directions, 'D');

    directions.RemoveAt(directions.Count - 1);
    lab[row, col] = '-';
}

bool IsOutside(char[,] lab, int row, int col)
{
    return row < 0 ||
           row >= lab.GetLength(0) ||
           col < 0 ||
           col >= lab.GetLength(1);
}

bool IsWall(char[,] lab, int row, int col)
{
    return lab[row, col] == '*';
}

bool IsVisited(char[,] lab, int row, int col)
{
    return lab[row, col] == 'v';
}

bool IsSolution(char[,] lab, int row, int col)
{
    return lab[row, col] == 'e';
}
