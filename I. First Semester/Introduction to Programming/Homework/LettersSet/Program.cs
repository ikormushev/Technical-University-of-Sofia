namespace homeworkLettersSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enther the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine();
            char[] englishLetters = new char[26];
            int[] englishLettersMaxCount = new int[26];
            
            for (int l = 0; l < 26; l++)
            {
                englishLetters[l] = (char)((int)'a' + l);
            }

            if (File.Exists(filePath)) {
                var file = File.OpenText(filePath);
                int totalLines = File.ReadAllLines(filePath).Length;
                for (int i = 0; i < totalLines; i++)
                {
                    string fileLine = file.ReadLine();
                    for (int y = 0; y < fileLine.Length; y++)
                    {
                        int wantedLetterIndex = 0;
                        int needLetterCount = 1;
                        for (int p = 0; p < englishLetters.Length; p++)
                        {
                            if (fileLine[y] == englishLetters[p])
                            {
                                wantedLetterIndex = p;
                                break;
                            }
                        }

                        for (int k = y + 1; k < fileLine.Length; k++)
                        {
                            if (fileLine[y] == fileLine[k])
                            {
                                needLetterCount += 1;
                            }
                        }

                        if (needLetterCount > englishLettersMaxCount[wantedLetterIndex])
                        {
                            englishLettersMaxCount[wantedLetterIndex] = needLetterCount;
                        }
                    }
                }
                bool firstPrintedLetter = false;
                for (int letter = 0; letter < englishLettersMaxCount.Length; letter++)
                {
                    if (englishLettersMaxCount[letter] == 0) continue;
                    for (int x = 0; x < englishLettersMaxCount[letter]; x++)
                    {
                        if (firstPrintedLetter == false)
                        {
                            firstPrintedLetter = true;
                            Console.Write(englishLetters[letter]);
                        }
                        else Console.Write($",{englishLetters[letter]}");
                    }
                }
            }
            else Console.WriteLine("There is no such file!");
        }
    }
}
