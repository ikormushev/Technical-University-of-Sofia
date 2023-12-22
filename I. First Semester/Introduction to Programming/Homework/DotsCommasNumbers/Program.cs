namespace homeworkDotsCommasNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enther the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine();
            int dotsCount = 0;
            int commasCount = 0;
            int wholeNumbersCount = 0;

            if (File.Exists(filePath))
            {
                var file = File.OpenText(filePath);
                int fileCharacterCode;
                string wholeNumber = "";

                while (true)
                {
                    fileCharacterCode = file.Read();
                    if (fileCharacterCode == -1)
                    {
                        if (wholeNumber != "") wholeNumbersCount += 1;
                        break;
                    }
                    char foundCharacter = (char)fileCharacterCode;

                    if (foundCharacter == '.') dotsCount += 1;
                    else if (foundCharacter == ',') commasCount += 1;
                    else if ((int)foundCharacter >= 48 && (int)foundCharacter <= 57)
                    {
                        wholeNumber += foundCharacter;
                        continue;
                    }

                    if (wholeNumber != "")
                    {
                        wholeNumbersCount += 1;
                        wholeNumber = "";
                    }
                }

                Console.WriteLine($"Count of dots: {dotsCount}");
                Console.WriteLine($"Count of commas: {commasCount}");
                Console.WriteLine($"Count of whole numbers: {wholeNumbersCount}");
            }
            else Console.WriteLine("There is no such file!");
        }
    }
}
