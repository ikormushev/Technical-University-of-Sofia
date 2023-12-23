using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string T = Console.ReadLine();
        string[] art = T.Split(" ");

        string numbers;
        int printingCharacter;
        string characterToPrint;
        string stringToPrint = "";
        for (int i = 0; i < art.Length; i++) {
            numbers = "";
            printingCharacter = 1;
            characterToPrint = "";
            for (int y = 0; y < art[i].Length; y++) {
                int characterValueASCII = (int)art[i][y];

                if ((characterValueASCII >= (int)'0' && characterValueASCII <= (int)'9') && (printingCharacter > 0) && (y < art[i].Length - 1)) {
                    numbers += art[i][y];
                } else {
                    characterToPrint += art[i][y];
                }
            }
            if (numbers != "") printingCharacter = int.Parse(numbers);

            if (characterToPrint == "nl") {
                Console.WriteLine(stringToPrint);
                stringToPrint = "";
                continue;
            } else {
                if (characterToPrint == "sp") characterToPrint = " ";
                else if (characterToPrint == "bS") characterToPrint = "\\";
                else if (characterToPrint == "sQ") characterToPrint = "'";
                for (int k = 0; k < printingCharacter; k++) {
                    stringToPrint += characterToPrint;
                }
            }
        }
        if (stringToPrint.Length >= 1) Console.WriteLine(stringToPrint);
        // To debug: Console.Error.WriteLine("Debug messages...");
    }
}
