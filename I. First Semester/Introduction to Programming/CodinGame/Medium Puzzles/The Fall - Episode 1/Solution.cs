using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Player
{
    static string Coordinates(int[,] givenMatrix, int x, int y, string position) {
        int roomType = givenMatrix[y, x];

        if (roomType == 0)
            return $"{x} {y}";
        else if (roomType == 1)
            return $"{x} {y + 1}";
        else if (roomType == 2) {
            if (position == "RIGHT")
               return $"{x - 1} {y}";
            else if (position == "LEFT")
                return $"{x + 1} {y}";
        }
        else if (roomType == 3) {
            if (position == "TOP")
                return $"{x} {y + 1}";
        }
        else if (roomType == 4) {
            if (position == "RIGHT")
               return $"{x} {y + 1}";
            else if (position == "TOP")
                return $"{x - 1} {y}";
        }
        else if (roomType == 5) {
            if (position == "TOP")
               return $"{x + 1} {y}";
            else if (position == "LEFT")
                return $"{x} {y + 1}";
        }
        else if (roomType == 6) {
            if (position == "RIGHT")
                return $"{x - 1} {y}";
            else if (position == "LEFT")
                return $"{x + 1} {y}";
        }
        else if (roomType == 7) {
            if (position == "TOP" || position == "RIGHT")
                return $"{x} {y + 1}";
        }
        else if (roomType == 8) {
            if (position == "LEFT" || position == "RIGHT")
                return $"{x} {y + 1}";
        }
        else if (roomType == 9) {
            if (position == "TOP" || position == "LEFT")
                return $"{x} {y + 1}";
        }
        else if (roomType == 10) {
            if (position == "TOP")
                return $"{x - 1} {y}";
        }
        else if (roomType == 11) {
            if (position == "TOP")
                return $"{x + 1} {y}";
        }
        else if (roomType == 12) {
            if (position == "RIGHT")
                return $"{x} {y + 1}";
        }
        else if (roomType == 13) {
            if (position == "LEFT")
                return $"{x} {y + 1}";
        }

        return $"{x} {y}";
    }

    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        int[,] matrix = new int[H, W];

        for (int i = 0; i < H; i++)
        {
            string[] LINE = Console.ReadLine().Split(" "); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            for (int y = 0; y < LINE.Length; y++) {
                matrix[i, y] = int.Parse(LINE[y]);
            }
        }

        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            string POS = inputs[2];
            string nextRoomCoordinates = Coordinates(matrix, XI, YI, POS);

            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
            Console.WriteLine(nextRoomCoordinates);
        }
    }
}

// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");
