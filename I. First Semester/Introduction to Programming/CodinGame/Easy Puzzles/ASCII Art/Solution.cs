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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine().ToUpper();
        char[,] matrix = new char[H,27*L];

        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            for (int y = 0; y < 27*L; y++) {
                matrix[i, y] = ROW[y];
            }
        }

        for (int k = 0; k < H; k++) {
            for (int j = 0; j < T.Length; j++) {
                bool secretLetter = true;
                int wantedIndex = 0;
                for (int w = (int)'A'; w < (int)'Z' + 1; w++) {
                    wantedIndex++;
                    if (w == (int)T[j]) {
                        secretLetter = false;
                        break;
                    }
                }
                if (secretLetter == true) wantedIndex = 27;
                for (int p = ((wantedIndex - 1) * L); p < (wantedIndex - 1) * L + L; p++) {
                    Console.Write(matrix[k,p]);
                }
            }
            Console.WriteLine();
        }
    }
}
