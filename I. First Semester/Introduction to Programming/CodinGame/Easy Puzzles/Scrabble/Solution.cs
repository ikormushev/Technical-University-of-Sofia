using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static int Points(char letter)
    {
        if (letter == 'e' || letter == 'a' || letter == 'i' || letter == 'o' || letter == 'n' || letter == 'r' || letter == 't' || letter == 'l' || letter == 's' || letter == 'u')
        {
            return 1;
        }
        else if (letter == 'd' || letter == 'g')
            return 2;
        else if (letter == 'b' || letter == 'c' || letter == 'm' || letter == 'p')
            return 3;
        else if (letter == 'f' || letter == 'h' || letter == 'v' || letter == 'w' || letter == 'y')
            return 4;
        else if (letter == 'k')
            return 5;
        else if (letter == 'j' || letter == 'x')
            return 8;
        else if (letter == 'q' || letter == 'z')
            return 10;
        return 0;
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string[] dictionary = new string[N];
        for (int i = 0; i < N; i++)
        {
            dictionary[i] = Console.ReadLine();
        }


        char[] englishLetters = new char[26];
        for (int p = 0; p < 26; p++) {
            englishLetters[p] = (char)((int)'a' + p);
        }
        int[] lettersAvailable = new int[26];

        string LETTERS = Console.ReadLine();
        for (int h = 0; h < LETTERS.Length; h++)
        {
            for (int u = 0; u < 26; u++) {
                if (LETTERS[h] == englishLetters[u]) lettersAvailable[u] += 1;
            }
        }

        int highestPoints = 0;
        string wordWithHighestPoints = "";

        for (int y = 0; y < dictionary.Length; y++)
        {
            string foundWord = dictionary[y];
            int[] wordLettersCount = new int[26];
            int[] lettersIndexes = new int[dictionary[y].Length];
            bool invalidWord = false;
            int currentPoints = 0;
            for (int k = 0; k < dictionary[y].Length; k++) {
                int letterIndex = (int)dictionary[y][k] - (int)'a';
                wordLettersCount[letterIndex] += 1;
                lettersIndexes[k] = letterIndex;
            }

            for (int w = 0; w < lettersIndexes.Length; w++) {
                int index = lettersIndexes[w];
                if (lettersAvailable[index] < wordLettersCount[index]) {
                    invalidWord = true;
                }
                else {
                    currentPoints += Points(englishLetters[index]);
                }
            }
            if (invalidWord) continue;
            
            if (currentPoints > highestPoints) {
                highestPoints = currentPoints;
                wordWithHighestPoints = foundWord;
            }
        }
        // To debug: Console.Error.WriteLine("Debug messages...");
        Console.WriteLine(wordWithHighestPoints);
    }
}
