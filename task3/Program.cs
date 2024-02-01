using System;

class Program
{
    static void Main()
    {
        
        int[,] chessboard = new int[8, 8];

        
        Random random = new Random();
        int queen1Row = random.Next(8);
        int queen1Col = random.Next(8);
        chessboard[queen1Row, queen1Col] = 1;

      
        int queen2Row, queen2Col;
        do
        {
            queen2Row = random.Next(8);
            queen2Col = random.Next(8);
        } while (ConflictWithQueen(queen2Row, queen2Col, chessboard));

        chessboard[queen2Row, queen2Col] = 1;

        
        Console.WriteLine("Chessboard matrix with queens (1) and empty spaces (0):");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{chessboard[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    
    static bool ConflictWithQueen(int row, int col, int[,] chessboard)
    {
        
        for (int i = 0; i < 8; i++)
        {
            if (chessboard[row, i] == 1 || chessboard[i, col] == 1)
                return true;
        }

      
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (chessboard[i, j] == 1)
                return true;
        }

        for (int i = row, j = col; i < 8 && j < 8; i++, j++)
        {
            if (chessboard[i, j] == 1)
                return true;
        }

        for (int i = row, j = col; i >= 0 && j < 8; i--, j++)
        {
            if (chessboard[i, j] == 1)
                return true;
        }

        for (int i = row, j = col; i < 8 && j >= 0; i++, j--)
        {
            if (chessboard[i, j] == 1)
                return true;
        }

        return false;
    }
}
