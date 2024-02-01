using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the horse's position on the chessboard (e.g., A1):");
        string position = Console.ReadLine().ToUpper();

    
        if (position.Length != 2 || !char.IsLetter(position[0]) || !char.IsDigit(position[1]))
        {
            Console.WriteLine("Invalid input format. Please use the format 'A1'.");
            return;
        }
        int col = position[0] - 'A';
        int row = 8 - (position[1] - '0');

        if (col < 0 || col >= 8 || row < 0 || row >= 8)
        {
            Console.WriteLine("Invalid position. Please enter a valid position on the chessboard.");
            return;
        }

        int[] moveRows = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] moveCols = { 1, 2, 2, 1, -1, -2, -2, -1 };

        
        int[,] chessboard = new int[8, 8];

        for (int i = 0; i < moveRows.Length; i++)
        {
            int newRow = row + moveRows[i];
            int newCol = col + moveCols[i];

            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
            {
                chessboard[newRow, newCol] = 1;
            }
        }

        
        Console.WriteLine("Chessboard matrix with 0s and 1s:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{chessboard[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
