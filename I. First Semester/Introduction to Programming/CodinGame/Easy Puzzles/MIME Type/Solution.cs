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
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        string[] extensions = new string[N];
        string[] MIMEtypes = new string[N];

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0]; // file extension
            string MT = inputs[1]; // MIME type.
            extensions[i] = EXT.ToLower();
            MIMEtypes[i] = MT;
        }

        for (int y = 0; y < Q; y++)
        {
            string[] FNAME = Console.ReadLine().Split("."); // One file name per line.
            if (FNAME.Length < 2) {
                Console.WriteLine("UNKNOWN");
                continue;
            }
            string givenExtension = FNAME[FNAME.Length - 1].ToLower();
            int elementIndex = Array.IndexOf(extensions, givenExtension);
            if (elementIndex == -1) Console.WriteLine("UNKNOWN");
            else {
                Console.WriteLine(MIMEtypes[elementIndex]);
            }
        }
        // To debug: Console.Error.WriteLine("Debug messages...");
    }
}
