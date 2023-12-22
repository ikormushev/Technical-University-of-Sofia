namespace homeworkProcessingMatrixFromFile
{
    internal class Program
    {
        static void PrintMatrix(decimal[,] matrixToPrint)
        {
            for (int row = 0; row < matrixToPrint.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToPrint.GetLength(1); col++)
                {
                    if (col == matrixToPrint.GetLength(1) - 1) Console.Write($"{matrixToPrint[row, col]}");
                    else Console.Write($"{matrixToPrint[row, col]}\t");
                }
                Console.WriteLine();
            }
        }

        static bool CheckIdentity(decimal[,] matrixToCheck)
        {
            if (matrixToCheck.GetLength(0) != matrixToCheck.GetLength(1)) return false; // За да е единична една матрица, то трябва първо да е квадратна

            for (int row = 0; row < matrixToCheck.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToCheck.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        if (matrixToCheck[row, col] != 1) return false;
                    }
                    else
                    {
                        if (matrixToCheck[row, col] != 0) return false;
                    }
                }
            }
            return true;
        }

        static decimal SumNegativeOnAntiDiagonal(decimal[,] matrixToSum)
        {
            decimal antiDiagonalSum = 0;
            if (matrixToSum.GetLength(0) != matrixToSum.GetLength(1)) return antiDiagonalSum; // За да можем да сметнем числата по вторичния диагонал, то матрицата трябва да е квадратна.
                for (int row = 0; row < matrixToSum.GetLength(0); row++)
            {
                int antiDiagonalColumn = matrixToSum.GetLength(1) - 1 - row;
                decimal antiDiagonalElement = matrixToSum[row, antiDiagonalColumn];
                if (antiDiagonalElement < 0) antiDiagonalSum += antiDiagonalElement;
            }

            return antiDiagonalSum;
        }

        static void NormalizeRows(decimal[,] matrixToNormalize)
        {
            for (int row = 0; row < matrixToNormalize.GetLength(0); row++)
            {
                decimal rowSum = 0;
                for (int col = 0; col < matrixToNormalize.GetLength(1); col++)
                {
                    rowSum += (matrixToNormalize[row, col] * matrixToNormalize[row, col]);
                }
                double squareRootRowSum = Math.Sqrt((double)rowSum); // Math.Sqrt() не работи с decimal числа
                if (squareRootRowSum != 0)
                {
                    decimal newsquareRootRowSum = (decimal)squareRootRowSum;
                    for (int col = 0; col < matrixToNormalize.GetLength(1); col++)
                    {
                        matrixToNormalize[row, col] /= newsquareRootRowSum;
                    }
                }
                
            }
        }
        
        static void SortMatrix(decimal[,] matrixToSort)
        {
            decimal temporaryElement;
            int sortedElementsCount = 0;
            for (int col = 0; col < matrixToSort.GetLength(1); col++)
            {
                sortedElementsCount = 0;
                if (col % 2 == 0)
                {
                    while (sortedElementsCount < matrixToSort.GetLength(0) - 1)
                    {
                        sortedElementsCount = 0;
                        for (int row = 0; row < matrixToSort.GetLength(0) - 1; row++)
                        {
                            if (matrixToSort[row, col] > matrixToSort[row + 1, col])
                            {
                                temporaryElement = matrixToSort[row, col];
                                matrixToSort[row, col] = matrixToSort[row + 1, col];
                                matrixToSort[row + 1, col] = temporaryElement;
                            }
                            else sortedElementsCount++;
                        }
                    }
                }
                else
                {
                    while (sortedElementsCount < matrixToSort.GetLength(0) - 1)
                    {
                        sortedElementsCount = 0;
                        for (int row = 0; row < matrixToSort.GetLength(0) - 1; row++)
                        {
                            if (matrixToSort[row, col] < matrixToSort[row + 1, col])
                            {
                                temporaryElement = matrixToSort[row, col];
                                matrixToSort[row, col] = matrixToSort[row + 1, col];
                                matrixToSort[row + 1, col] = temporaryElement;
                            }
                            else sortedElementsCount++;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Please enther the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine();
            int rowsCount = 0;
            int columnsCount = 0;

            if (File.Exists(filePath))
            {
                var file = File.OpenText(filePath);
                int totalLines = File.ReadAllLines(filePath).Length;
                for (int y = 0; y < 2; y++)
                {
                    string fileLine = file.ReadLine();
                    if (y == 0) rowsCount = int.Parse(fileLine);
                    else if (y == 1) columnsCount = int.Parse(fileLine);
                }
                decimal[,] matrix = new decimal[rowsCount, columnsCount];

                for (int i = 0; i < totalLines - 2; i++)
                {
                    string[] fileLine = file.ReadLine().Split(" ");
                    for (int j = 0; j < fileLine.Length; j++)
                    {
                        matrix[i, j] = decimal.Parse(fileLine[j]);
                    }
                }
                // 1
                Console.WriteLine("1) The matrix is:");
                PrintMatrix(matrix);

                // 2
                Console.WriteLine();
                if (CheckIdentity(matrix)) Console.WriteLine("2) Matrix is an identity matrix.");
                else Console.WriteLine("2) Matrix is not an identity matrix.");

                // 3
                Console.WriteLine();
                decimal antiDiagonalSum = SumNegativeOnAntiDiagonal(matrix);
                Console.WriteLine($"3) The sum of negative elements on the anti diagonal: {antiDiagonalSum}");

                // 4
                Console.WriteLine();
                NormalizeRows(matrix);
                Console.WriteLine("4) The normalized matrix is:");
                PrintMatrix(matrix);

                // 5
                Console.WriteLine();
                SortMatrix(matrix);
                Console.WriteLine("5) The sorted matrix is:");
                PrintMatrix(matrix);

            }
            else Console.WriteLine("There is no such file!");
        }
    }
}
