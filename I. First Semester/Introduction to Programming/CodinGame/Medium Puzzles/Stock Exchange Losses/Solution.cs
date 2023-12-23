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
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        
        long highestValue = long.Parse(inputs[0]);
        long highestLoss = 0;

        for (int i = 1; i < n; i++)
        {
            long v = long.Parse(inputs[i]);
            if (v < highestValue) {
                long currentLoss = highestValue - v;
                if (currentLoss > highestLoss)
                    highestLoss = currentLoss;
            }
            else highestValue = v;
        }

        if (highestLoss != 0){
            Console.WriteLine(-highestLoss);
        }
        else Console.WriteLine(0);
    }
}
