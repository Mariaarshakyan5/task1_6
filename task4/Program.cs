using System;

class Program
{
    static void Main()
    {
       
        int[,] chessboard = new int[8, 8];

        Console.WriteLine("Enter the horse's initial position on the chessboard (e.g., A1):");
        string position = Console.ReadLine().ToUpper(); 
        if (position.Length != 2 || !char.IsLetter(position[0]) || !char.IsDigit(position[1]))
        {
            Console.WriteLine("Invalid input format. Please use the format 'A1'.");
            return;
        }

        int initialCol = position[0] - 'A';
        int initialRow = 8 - (position[1] - '0');


        if (initialCol < 0 || initialCol >= 8 || initialRow < 0 || initialRow >= 8)
        {
            Console.WriteLine("Invalid position. Please enter a valid position on the chessboard.");
            return;
        }

        chessboard[initialRow, initialCol] = 1;

        
        Console.WriteLine("Chessboard matrix with the initial horse position (1) and empty spaces (0):");
        PrintChessboard(chessboard);

        MakeRandomHorseMove(initialRow, initialCol, chessboard);

       
        Console.WriteLine("Chessboard matrix after the horse's move:");
        PrintChessboard(chessboard);
    }

    static void PrintChessboard(int[,] chessboard)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{chessboard[i, j]} ");
            }
            Console.WriteLine();
        }
    }

  
    static void MakeRandomHorseMove(int row, int col, int[,] chessboard)
    {
        Random random = new Random();

        int[] moveRows = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] moveCols = { 1, 2, 2, 1, -1, -2, -2, -1 };

      
        ShuffleMoves(moveRows, random);
        ShuffleMoves(moveCols, random);

        for (int i = 0; i < moveRows.Length; i++)
        {
            int newRow = row + moveRows[i];
            int newCol = col + moveCols[i];
            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && chessboard[newRow, newCol] == 0)
            {
             
                chessboard[row, col] = 0;
                chessboard[newRow, newCol] = 1;

                Console.WriteLine($"The horse moved to {Convert.ToChar('A' + newCol)}{8 - newRow + 1}");
                return;
            }
        }

        Console.WriteLine("The horse has no valid moves from the current position.");
    }

 
    static void ShuffleMoves(int[] moves, Random random)
    {
        int n = moves.Length;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            int temp = moves[k];
            moves[k] = moves[n];
            moves[n] = temp;
        }
    }
}
