using System;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem67
    {
        public void Method()
        {
            Console.WriteLine("find the maximum total from top to bottom of a triangle of numbers using only the 2 adjacent numbers below each number");

            int[,] inputTriangle = readInput("67triangle.txt");
            int lines = inputTriangle.GetLength(0);
            int[] largestValues = new int[lines];

            // initialize algorithm
            for (int i = 0; i < lines; i++)
                largestValues[i] = inputTriangle[lines - 1, i];

            for (int i = lines - 2; i >= 0; i--)
                for (int j = 0; j <= i; j++)
                    largestValues[j] = inputTriangle[i, j] + Math.Max(largestValues[j], largestValues[j + 1]);

            Console.WriteLine($"The largest sum through the triangle is {largestValues[0]}");
        }

        private static int[,] readInput(string filename)
        {
            string line;
            int lines = 0;

            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
                lines++;

            int[,] inputTriangle = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                string[] linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                    inputTriangle[j, i] = int.Parse(linePieces[i]);
                j++;
            }

            r.Close();

            return inputTriangle;
        }
    }
}
