namespace homeworkMatrixEvenOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the count of rows of the matrix:");
            int matrixRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Write the count of colums of the matrix:");
            int matrixCol = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixRow, matrixCol];
            int sumEvenOddRow = 0;
            int sumOddEvenCol = 0;

            for (int i = 0; i < matrixRow; i++)
            {
                Console.WriteLine($"Write the elements of row number {i + 1}, separated by a single space.");
                string[] rowElements = Console.ReadLine().Split(" ");
                for (int j = 0; j < rowElements.Length; j++)
                    matrix[i, j] = int.Parse(rowElements[j]);
            }

            for (int row = 1; row < matrixRow + 1; row++)
            {
                for (int col = 1; col < matrixCol + 1; ++col)
                {
                    if ((matrix[row - 1, col - 1] % 2 == 1) && (col % 2 == 0))
                        sumOddEvenCol += matrix[row - 1, col - 1];
                    if ((matrix[row - 1, col - 1] % 2 == 0) && (row % 2 == 1))
                        sumEvenOddRow += matrix[row - 1, col - 1];
                }
            }
            Console.WriteLine($"The sum of even elements on odd rows is {sumEvenOddRow}.");
            Console.WriteLine($"The sum of odd elements on even columns is {sumOddEvenCol}.");
        }
    }
}
