using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Zeros(string x, string y, string message) {

    }
    static void Main(string[] args)
    {
        string MESSAGE = Console.ReadLine();
        string startingMessage = "";

        for (int w = 0; w < MESSAGE.Length; w++) {
            int currentValue = (int)MESSAGE[w];
            string currentLetter = Convert.ToString(currentValue,2);
            if (currentLetter.Length < 7) {
                for (int p = 7 - currentLetter.Length; p > 0; p--) {
                        startingMessage += '0';
                }
                startingMessage += currentLetter;
            }
            else startingMessage += currentLetter;
        }

        string codedMessage = "";
        string zeros = "";
        string ones = "";

        for (int i = 0; i < startingMessage.Length; i++) {
            if (startingMessage[i] == '1') {
                if (zeros.Length > 0) {
                    codedMessage += "00 ";
                    for (int y = 0; y < zeros.Length; y++) {
                        if (y == zeros.Length - 1) {
                            codedMessage += "0 ";
                        }
                        else codedMessage += '0';
                    }
                    zeros = "";
                }
                ones += '1';
            }
            else if (startingMessage[i] == '0') {
                if (ones.Length > 0) {
                    codedMessage += "0 ";
                    for (int k = 0; k < ones.Length; k++) {
                        if (k == ones.Length - 1) {
                            codedMessage += "0 ";
                        }
                        else codedMessage += '0';
                    }
                    ones = "";
                }
                zeros += '0';
            }
        }

        if (zeros.Length > 0) {
            codedMessage += "00 ";
            for (int y = 0; y < zeros.Length; y++) {
                codedMessage += '0';
            }
            zeros = "";
        }
        
        if (ones.Length > 0) {
            codedMessage += "0 ";
            for (int y = 0; y < ones.Length; y++) {
                codedMessage += '0';
            }
            ones = "";
        }
        // To debug: Console.Error.WriteLine("Debug messages...");
        Console.WriteLine(codedMessage);
    }
}
