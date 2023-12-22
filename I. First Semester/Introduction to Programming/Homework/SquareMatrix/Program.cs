namespace homeworkSquareMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write the number of rows/columns of the square matrix: ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Please enther the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine();

            int[,] matrix = new int[N, N];

            if (File.Exists(filePath))
            {
                var file = File.OpenText(filePath);
                int rowNum, columnNum, givenElement;
                string[] givenRow;
                int evenElementsSum = 0;
                int oddElementsSum = 0;
                int evenRowsSum = 0;
                int oddColumnsSum = 0;

                // Finding the elements of the matrix
                for (int i = 0; i < N * N; i++)
                {
                    givenRow = file.ReadLine().Split('\t');
                    rowNum = int.Parse(givenRow[0]);
                    columnNum = int.Parse(givenRow[1]);
                    if (givenRow.Length == 3)
                        givenElement = int.Parse(givenRow[2]);
                    else givenElement = -1;
                    
                    matrix[rowNum - 1, columnNum - 1] = givenElement;
                    if (givenElement % 2 == 0)
                        evenElementsSum += givenElement;
                    else oddElementsSum += givenElement;
                }

                // Printing the matrix
                for (int row = 0; row < N; row++)
                {
                    for (int column = 0; column < N; column++)
                    {
                        if (column == N - 1)
                            Console.Write($"{matrix[row, column]}");
                        else Console.Write($"{matrix[row, column]}\t");
                    }
                    Console.WriteLine();
                }

                // Finding the wanted sums
                for (int row = 0; row < N; row++)
                {
                    for (int column = 0; column < N; column++)
                    {
                        if ((row + 1) % 2 == 0)
                            evenRowsSum += matrix[row, column];

                        if ((column + 1) % 2 == 1)
                            oddColumnsSum += matrix[row, column];
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"The sum of even elements is: {evenElementsSum}");
                Console.WriteLine($"The sum of odd elements is: {oddElementsSum}");
                Console.WriteLine($"The sum of the elements on even rows is: {evenRowsSum}");
                Console.WriteLine($"The sum of the elements on odd columns is: {oddColumnsSum}");
            }
            else Console.WriteLine("There is no such file!");
        }
    }
}
