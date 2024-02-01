using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows (M) for the matrix:");
        int m = GetMatrixSize();

        Console.WriteLine("Enter the number of columns (N) for the matrix:");
        int n = GetMatrixSize();

        int[,] matrix = new int[m, n];

        Console.WriteLine("Enter the matrix elements row-wise:");

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Enter element at position {i + 1},{j + 1}: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

       
        FindLargestInRowSmallestInColumn(matrix);
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

    
    static void FindLargestInRowSmallestInColumn(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        bool foundElement = false;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int currentElement = matrix[i, j];

                bool largestInRow = true;
                for (int k = 0; k < n; k++)
                {
                    if (k != j && matrix[i, k] > currentElement)
                    {
                        largestInRow = false;
                        break;
                    }
                }

                bool smallestInColumn = true;
                for (int k = 0; k < m; k++)
                {
                    if (k != i && matrix[k, j] < currentElement)
                    {
                        smallestInColumn = false;
                        break;
                    }
                }

                if (largestInRow && smallestInColumn)
                {
                    Console.WriteLine($"The matrix element at position {i + 1},{j + 1} is {currentElement}.");
                    foundElement = true;
                    break;
                }
            }
        }

        if (!foundElement)
        {
            Console.WriteLine("No such element exists.");
        }
    }
}
