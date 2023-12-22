using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static string Winner(int firstPlayerNum, string firstPlayerSign, int secondPlayerNum, string secondPlayerSign)
    {
        bool firstPlayerWin = false; // return $"{firstPlayerNum} {firstPlayerSign}";
        bool secondPlayerWin = false; // return $"{secondPlayerNum} {secondPlayerSign}";
        if (firstPlayerSign == secondPlayerSign)
        {
            if (firstPlayerNum > secondPlayerNum) secondPlayerWin = true;
            else if (firstPlayerNum < secondPlayerNum) firstPlayerWin = true;
        }

        else if (firstPlayerSign == "C")
        {
            if (secondPlayerSign == "P" || secondPlayerSign == "L") firstPlayerWin = true;
            else if ((secondPlayerSign == "S" || secondPlayerSign == "R")) secondPlayerWin = true;
        }
        else if (firstPlayerSign == "P")
        {
            if (secondPlayerSign == "R" || secondPlayerSign == "S") firstPlayerWin = true;
            else if ((secondPlayerSign == "C" || secondPlayerSign == "L")) secondPlayerWin = true;
        }
        else if (firstPlayerSign == "R")
        {
            if (secondPlayerSign == "L" || secondPlayerSign == "C") firstPlayerWin = true;
            else if ((secondPlayerSign == "S" || secondPlayerSign == "P")) secondPlayerWin = true;
        }
        else if (firstPlayerSign == "L")
        {
            if (secondPlayerSign == "P" || secondPlayerSign == "S") firstPlayerWin = true;
            else if ((secondPlayerSign == "R" || secondPlayerSign == "C")) secondPlayerWin = true;
        }
        else if (firstPlayerSign == "S")
        {
            if (secondPlayerSign == "C" || secondPlayerSign == "R") firstPlayerWin = true;
            else if ((secondPlayerSign == "L" || secondPlayerSign == "P")) secondPlayerWin = true;
        }

        if (firstPlayerWin) return $"{firstPlayerNum} {firstPlayerSign}";
        else if (secondPlayerWin) return $"{secondPlayerNum} {secondPlayerSign}";
        return "";
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int roundsNum = 0;
        int participants = N;
        while (participants > 1)
        {
            roundsNum++;
            participants /= 2;
        }

        string[] playersOpponents = new string[N];

        string playersLeft = "";
        int winnerIndex = 0;
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int NUMPLAYER = int.Parse(inputs[0]);
            string SIGNPLAYER = inputs[1];
            if (i == N - 1) playersLeft += $"{NUMPLAYER} {SIGNPLAYER}";
            else playersLeft += $"{NUMPLAYER} {SIGNPLAYER},";
            playersOpponents[NUMPLAYER - 1] = "";
        }

        for (int y = 0; y < roundsNum; y++)
        {
            string[] playersFighting = playersLeft.Split(",");
            playersLeft = "";
            for (int battleNum = 0; battleNum < playersFighting.Length; battleNum += 2)
            {
                string[] firstPlayer = playersFighting[battleNum].Split(" ");
                string[] secondPlayer = playersFighting[battleNum + 1].Split(" ");
                string winner = Winner(int.Parse($"{firstPlayer[0]}"), firstPlayer[1], int.Parse($"{secondPlayer[0]}"), secondPlayer[1]);
                if (battleNum == playersFighting.Length - 2) playersLeft += $"{winner}";
                else playersLeft += $"{winner},";
                winnerIndex = int.Parse($"{winner.Substring(0, winner.Length - 1)}") - 1;
                if (string.Join(" ", firstPlayer) == winner) playersOpponents[winnerIndex] += $"{secondPlayer[0]} ";
                else if (string.Join(" ", secondPlayer) == winner) playersOpponents[winnerIndex] += $"{firstPlayer[0]} ";
            }
        }
        string[] lastWinner = playersLeft.Split(" ");
        winnerIndex = int.Parse($"{lastWinner[0]}") - 1;
        string winnerOpponents = playersOpponents[winnerIndex]; 
        winnerOpponents = winnerOpponents.Substring(0, winnerOpponents.Length - 1);
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(lastWinner[0]);
        Console.WriteLine(winnerOpponents);
    }
}
