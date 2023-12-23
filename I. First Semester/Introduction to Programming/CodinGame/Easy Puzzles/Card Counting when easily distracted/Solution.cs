using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static int Points(char x) {
        if (x == 'K' || x =='Q'|| x =='J' || x =='T') {
            return 10;
        }
        else if (x == 'A') {
            return 1;
        }
        else if (x == '2' || x =='3' || x =='4' || x =='5' || x =='6' || x =='7' || x =='8' || x =='9') {
            string y = $"{x}";
            return int.Parse(y);
        }
        return 0;
    }
    
    static void Main(string[] args)
    {
        string[] streamOfConsciousness = Console.ReadLine().Split('.');
        int bustThreshold = int.Parse(Console.ReadLine());
        char[] validCards = new char[] {'K', 'Q', 'J', 'T', 'A', '2', '3', '4', '5', '6', '7', '8', '9'};
        
        int totalFoundCards = 0;
        int cardsUnderThreshold = 0;
        int possibleCardsUnderThreshold = (bustThreshold - 1) * 4;

        foreach (string deck in streamOfConsciousness) {
            int validCardsCount = 0;
            for (int i = 0; i < deck.Length; i++) {
                for (int y = 0; y < validCards.Length; y++) {
                    if (deck[i] == validCards[y]) {
                        validCardsCount++;
                        break;
                    }
                }
            }
            if (validCardsCount != deck.Length) continue;
            Console.Error.WriteLine(deck);
            for (int w = 0; w < deck.Length; w++) {
                totalFoundCards++;
                if (Points(deck[w]) < bustThreshold) {
                    cardsUnderThreshold++;
                }
            }
        }
        int cardsLeft = 52 - totalFoundCards; // totalCards in general == 52
        double cardsUnderThresholdLeft = possibleCardsUnderThreshold - cardsUnderThreshold;
        double cardsPercentage = cardsUnderThresholdLeft / cardsLeft;
        Console.WriteLine($"{Math.Round(cardsPercentage * 100)}%");
    }
}
