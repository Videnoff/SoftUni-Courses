HashSet<int> attackedRows = new HashSet<int>();
HashSet<int> attackedCols = new HashSet<int>();
HashSet<int> attackedLeftDiagonals = new HashSet<int>();
HashSet<int> attackedRightDiagonals = new HashSet<int>();

var board = new bool[8, 8];

PutQueens(board, 0);

void PutQueens(bool[,] board, int row)
{
    if (row == board.GetLength(0))
    {
        PrintBoard(board);
        return;
    }

    for (int col = 0; col < board.GetLength(1); col++)
    {
        if (!IsAttacked(row, col))
        {
            board[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(row - col);
            attackedRightDiagonals.Add(row + col);
            
            PutQueens(board, row + 1);
            
            board[row, col] = false;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(row - col);
            attackedRightDiagonals.Remove(row + col);
        }
    }
}

void PrintBoard(bool[,] board)
{
    for (int r = 0; r < board.GetLength(0); r++)
    {
        for (int c = 0; c < board.GetLength(1); c++)
        {
            if (board[r, c])
            {
                Console.Write($"* ");
            }
            else
            {
                Console.Write($"- ");
            }
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}

bool IsAttacked(int row, int col)
{
    return attackedRows.Contains(row) ||
           attackedCols.Contains(col) ||
           attackedLeftDiagonals.Contains(row - col) ||
           attackedRightDiagonals.Contains(row + col);
}
