namespace MatrixManipulation;

internal class Program
{
    static void Main(string[] args)
    {
        int[,] randomMatrix = GenerateRandomMatrix();
        Console.WriteLine("Generated Matrix:");
        PrintMatrix(randomMatrix);

        (int evenCount, int oddCount, double evenPercentage, double oddPercentage) = CountEvenOdds(randomMatrix);
        Console.WriteLine($"\nEven numbers: {evenCount} ({evenPercentage:F2}%)");
        Console.WriteLine($"Odd numbers: {oddCount} ({oddPercentage:F2}%)");
    }

    /// <summary>
    /// Generates a random matrix with dimensions and values.
    /// </summary>
    /// <returns>A randomly generated matrix.</returns>
    public static int[,] GenerateRandomMatrix()
    {
        Random rand = new Random();
        int rows = rand.Next(1, 9);
        int cols = rand.Next(1, 9);

        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int minValue = i * 10 + 1;
            int maxValue = i * 10 + 10;

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue);
            }
        }
        return matrix;
    }

    /// <summary>
    /// Counts and calculates the percentage of even and odd numbers in the matrix.
    /// </summary>
    /// <param name="matrix">The input matrix.</param>
    /// <returns>A tuple containing the count of even numbers, odd numbers, and their respective percentages.</returns>
    public static (int evenCount, int oddCount, double evenPercentage, double oddPercentage) CountEvenOdds(int[,] matrix)
    {
        int evenCount = 0;
        int oddCount = 0;
        int totalCount = matrix.Length;

        foreach (int value in matrix)
        {
            if (value % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        double evenPercentage = (double)evenCount / totalCount * 100;
        double oddPercentage = (double)oddCount / totalCount * 100;

        return (evenCount, oddCount, evenPercentage, oddPercentage);
    }

    /// <summary>
    /// Prints the matrix to the console.
    /// </summary>
    /// <param name="matrix">The input matrix.</param>
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],4} ");
            }
            Console.WriteLine();
        }
    }
}