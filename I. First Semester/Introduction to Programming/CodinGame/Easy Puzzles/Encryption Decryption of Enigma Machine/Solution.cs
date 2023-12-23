using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static string UpdatedMessage(string givenMessage, string firstRotor, string nextRotor) {
        char[] emptyRotor = new char[givenMessage.Length];
        for (int k = 0; k < emptyRotor.Length; k++) {
            for (int w = 0; w < firstRotor.Length; w++) {
                if (givenMessage[k] == firstRotor[w]) {
                    emptyRotor[k] = nextRotor[w];
                    break;
                }
            }
        }
        givenMessage = string.Join("", emptyRotor);
        return givenMessage;
    }
    
    static void Main(string[] args)
    {
        string operation = Console.ReadLine();
        int pseudoRandomNumber = int.Parse(Console.ReadLine());
        
        string alphabeticRotor = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string[] rotors = new string[3];
        for (int i = 0; i < 3; i++)
        {
            string rotor = Console.ReadLine();
            rotors[i] = rotor;
        }
        string message = Console.ReadLine();
        string updatedMessage = "";

        if (operation == "ENCODE") {
            for (int y = 0; y < message.Length; y++) {
                int newCharacterValue = (int)message[y] + pseudoRandomNumber + y;
                while (newCharacterValue > (int)'Z') {
                    newCharacterValue -= 26;
                }
                char newCharacter = (char)newCharacterValue;
                updatedMessage += newCharacter;
            }
            updatedMessage = UpdatedMessage(updatedMessage, alphabeticRotor, rotors[0]);
            updatedMessage = UpdatedMessage(updatedMessage, alphabeticRotor, rotors[1]);
            updatedMessage = UpdatedMessage(updatedMessage, alphabeticRotor, rotors[2]);
        } else if (operation == "DECODE"){
            message = UpdatedMessage(message, rotors[2], alphabeticRotor);
            message = UpdatedMessage(message, rotors[1], alphabeticRotor);
            message = UpdatedMessage(message, rotors[0], alphabeticRotor);
            for (int y = 0; y < message.Length; y++) {
                int newCharacterValue = (int)message[y] - pseudoRandomNumber - y;
                while (newCharacterValue < (int)'A') {
                    newCharacterValue += 26;
                }
                char newCharacter = (char)newCharacterValue;
                updatedMessage += newCharacter;
            }
        }

        // To debug: Console.Error.WriteLine("Debug messages...");
        Console.WriteLine(updatedMessage);
    }
}
