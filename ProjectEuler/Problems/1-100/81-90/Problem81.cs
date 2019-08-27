using System;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem81
    {
        public void Method()
        {
            Console.WriteLine("Find the minimal path sum in the provided file containing an 80x80 matrix from top left to bottom right by only moving right and down");

            const string filename = "81matrix.txt";

            const int n = 80;

            // read file
            string[] file = File.ReadAllLines(filename);

            // create string matrix
            string[][] stringMatrix = new string[file.Length][];
            for (int i = 0; i < file.Length; i++)
                stringMatrix[i] = file[i].Split(',');

            // initialize integer matrix
            int[][] matrix = new int[stringMatrix.Length][];
            for(int i = 0; i < matrix.Length; i++)
                matrix[i] = new int[stringMatrix.Length];

            // convert string matrix to integer matrix
            for (int i = 0; i < n; i++)
                matrix[i] = Array.ConvertAll(stringMatrix[i], int.Parse);

            int[,] pathMatrix = new int[n,n];
            pathMatrix[0, 0] = matrix[0][0];
            for (int i = 1; i < n; i++)
            {
                // initialize top row and left col
                pathMatrix[i, 0] = pathMatrix[i-1,0] + matrix[i][0];
                pathMatrix[0, i] = pathMatrix[0,i-1] + matrix[0][i];
            }

            for(int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                    pathMatrix[i, j] = Math.Min(pathMatrix[i - 1, j], pathMatrix[i, j - 1]) + matrix[i][j];
                
                Console.WriteLine($"pm[{i},{i}] = {pathMatrix[i,i]}");
            }

            Console.WriteLine($"minimal path sum: {pathMatrix[n-1,n-1]}");
        }
    }
}
