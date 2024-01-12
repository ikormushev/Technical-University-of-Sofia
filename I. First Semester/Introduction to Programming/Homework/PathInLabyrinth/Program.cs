using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace homeworkPathInLabyrinth
{
    internal class Program
    {
        static string NextPositions(int[,] matrix, int X, int Y, string tries, string end)
        {
            string top = $"({X}, {Y - 1})";
            string bottom = $"({X}, {Y + 1})";
            string left = $"({X - 1}, {Y})";
            string right = $"({X + 1}, {Y})";

            if (top == end | bottom == end | left == end | right == end)
            {
                return end;
            }
            if (Y + 1 < matrix.Length)
            {
                if (matrix[Y + 1, X] == 0 && tries.Contains(bottom) == false)
                {
                    return $"{bottom};";
                }
            }
            if (X + 1 < matrix.Length)
            {
                if (matrix[Y, X + 1] == 0 && tries.Contains(right) == false)
                {
                    return $"{right};";
                }
            }
            if (Y - 1 > 0)
            {
                if (matrix[Y - 1, X] == 0 && tries.Contains(top) == false)
                {
                    return $"{top};";
                }

            }
            if (X - 1 > 0)
            {
                if (matrix[Y, X - 1] == 0 && tries.Contains(left) == false)
                {
                    return $"{left};";
                }
            }
            return "";
        }

        static void Main(string[] args)
        {
            Console.Write("Please enther the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine();

            if (File.Exists(filePath))
            {
                var file = File.OpenText(filePath);
                int labyrinthN = int.Parse(file.ReadLine());
                int[,] labyrinth = new int[labyrinthN, labyrinthN];

                int startX = int.Parse(file.ReadLine());
                int startY = int.Parse(file.ReadLine());

                int exitX = int.Parse(file.ReadLine());
                int exitY = int.Parse(file.ReadLine());

                for (int row = 0; row < labyrinthN; row++)
                {
                    string[] cols = file.ReadLine().Split(" ");
                    for (int col = 0; col < cols.Length; col++)
                    {
                        labyrinth[row, col] = int.Parse(cols[col]);
                    }
                }
                string exit = $"({exitX}, {exitY})";
                bool endReached = false;
                bool noExitAtAll = false;

                string exitPath = $"({startX}, {startY});";
                string alreadyPassed = $"({startX}, {startY});";
                string previousStep = "";
                string[] coordinates;
                int nextX, nextY;

                while (true)
                {
                    string next = NextPositions(labyrinth, startX, startY, alreadyPassed, exit);
                    if (next == exit)
                    {
                        exitPath += next;
                        exitPath += ";EXIT";
                        endReached = true;
                        break;
                    }
                    else if (next == "")
                    {
                        string[] changingPassed = alreadyPassed.Split(";");
                        int index = changingPassed.Length - 2;
                        while (next == "")
                        {
                            coordinates = changingPassed[index].Split(",");
                            nextX = int.Parse(coordinates[0][1..]);
                            nextY = int.Parse(coordinates[1][1..^1]);
                            previousStep = changingPassed[index];
                            next = NextPositions(labyrinth, nextX, nextY, alreadyPassed, exit);
                            index--;
                            if (index < 0)
                            {
                                Console.WriteLine("NO PATH");
                                noExitAtAll = true;
                                break;
                            }
                        }
                        if (noExitAtAll) break;
                        string[] nextExitPath = exitPath.Split(";");
                        string swapExits = "";
                        for (int i = 0; i < nextExitPath.Length - 1; i++)
                        {
                            if (nextExitPath[i] == previousStep)
                            {
                                swapExits += $"{nextExitPath[i]};";
                                break;
                            }
                            swapExits += $"{nextExitPath[i]};";
                        }
                        exitPath = swapExits;
                    }

                    exitPath += next;
                    alreadyPassed += next;
                    previousStep = next;
                    coordinates = next.Split(",");
                    nextX = int.Parse(coordinates[0][1..]);
                    nextY = int.Parse(coordinates[1][1..^2]);
                    startX = nextX;
                    startY = nextY;

                }
                if (endReached)
                {
                    exitPath = exitPath.Replace(";", " -> ");
                    Console.WriteLine(exitPath);
                }
            }
            else Console.WriteLine("There is no such file!");
        }
    }
}
