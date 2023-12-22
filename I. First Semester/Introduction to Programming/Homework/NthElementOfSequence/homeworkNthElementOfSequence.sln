namespace homeworkNthElementOfSequence
{
    internal class Program
    {
        static int IterativeElement(int n, int[] sequence)
        {
            if (n <= 0)
            {
                return 0;
            }

            for (int i = 3; i < n; i++)
            {
                int ni = 3 * sequence[i - 3] + 4 * sequence[i - 2] - 7 * sequence[i - 1];
                sequence[i] = ni;
            }
            return sequence[n - 1];
        }

        static int RecursiveElement(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 2;
            else if (n == 2)
                return 4;
            else if (n == 3)
                return 6;

            int recursionNumber = 3 * RecursiveElement(n - 3) + (4 * RecursiveElement(n - 2)) - (7 * RecursiveElement(n - 1));
            return recursionNumber;
        }
        static void Main(string[] args)
        {
            int firstNum = 2;
            int secondNum = 4;
            int thirdNum = 6;
            int[] usedSequence;

            Console.Write("Write the number of the element from the sequence you want: ");
            int wantedElement = int.Parse(Console.ReadLine());
            if (wantedElement <= 3)
            {
                usedSequence = new int[3];
            }
            else
            {
                usedSequence = new int[wantedElement];
            }
            usedSequence[0] = firstNum;
            usedSequence[1] = secondNum;
            usedSequence[2] = thirdNum;

            int foundIterativeElement = IterativeElement(wantedElement, usedSequence);
            int foundRecursiveElement = RecursiveElement(wantedElement);
            Console.WriteLine($"Iterative way: {foundIterativeElement}");
            Console.WriteLine($"Recursive way: {foundRecursiveElement}");
        
        }
    }
}
