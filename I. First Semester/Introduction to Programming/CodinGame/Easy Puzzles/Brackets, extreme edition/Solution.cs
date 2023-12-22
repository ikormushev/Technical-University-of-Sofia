using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution {

    static bool IsValidExpression(string onlyBrackets) {
        string bracketsStack = "";
        for (int k = 0; k < onlyBrackets.Length; k++) {
            if (onlyBrackets[k] == '(' || onlyBrackets[k] == '[' || onlyBrackets[k] == '{') {
                bracketsStack += onlyBrackets[k];
            }

            else if (onlyBrackets[k] == ')' || onlyBrackets[k] == ']' || onlyBrackets[k] == '}') {
                if (bracketsStack.Length == 0) return false;
                char popedElement = bracketsStack[bracketsStack.Length - 1];
                bracketsStack = bracketsStack.Substring(0, bracketsStack.Length - 1);
                if (onlyBrackets[k] != ClosingBracket(popedElement)) {
                    return false;
                }
            }
        }
        return bracketsStack.Length == 0;
    }

    static char ClosingBracket(char bracket)
    {
        if (bracket == '(') return ')';
        else if (bracket == '[') return ']';
        else if (bracket == '{') return '}';
        return ' ';
    }

    static void Main() {
        string expression = Console.ReadLine();
        string totalBrackets = "";

        for (int i = 0; i < expression.Length; i++) {
            if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{' || expression[i] == ')' || expression[i] == ']' || expression[i] == '}') {
                totalBrackets += expression[i];
            }
        }

        if (IsValidExpression(totalBrackets)) {
            Console.WriteLine("true");
        }
        else {
            Console.WriteLine("false");
        }
    }
}
