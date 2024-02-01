using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows (N) for the matrix:");
        int n = GetMatrixSize();

        Console.WriteLine("Enter the number of columns (M) for the matrix:");
        int m = GetMatrixSize();

        int[,] matrix = new int[n, m];

       
        int totalElements = n * m;

        int[] availableNumbers = new int[totalElements];
        for (int i = 0; i < totalElements; i++)
        {
            availableNumbers[i] = i + 1;
        }

        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int randomIndex = random.Next(0, availableNumbers.Length);
                matrix[i, j] = availableNumbers[randomIndex];

              
                availableNumbers[randomIndex] = availableNumbers[availableNumbers.Length - 1];
                Array.Resize(ref availableNumbers, availableNumbers.Length - 1);
            }
        }

        Console.WriteLine("Randomly filled NxM matrix with non-repeating numbers:");
        PrintMatrix(matrix);
    }

  
    static int GetMatrixSize()
    {
        int size;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the matrix size.");
        }
        return size;
    }

 
    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
