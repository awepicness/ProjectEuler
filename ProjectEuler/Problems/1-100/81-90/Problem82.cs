using System;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem82
    {
        public void Method2()
        {
            Console.WriteLine("Find the minimal path sum in the provided file containing an 80x80 matrix from any number in the left column " +
                              "to any number in the right column by moving right, up, and down");

            const string filename = "82matrix.txt";

            const int n = 80;

            // read file
            string[] file = File.ReadAllLines(filename);

            // create string matrix
            string[][] stringMatrix = new string[file.Length][];
            for (int i = 0; i < file.Length; i++)
                stringMatrix[i] = file[i].Split(',');

            // initialize integer matrix
            int[][] matrix = new int[stringMatrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = new int[stringMatrix.Length];

            // convert string matrix to integer matrix
            for (int i = 0; i < n; i++)
                matrix[i] = Array.ConvertAll(stringMatrix[i], int.Parse);

            // solve
        }
    }
}
