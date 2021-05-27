using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem82
    {
        public void Method()
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
            int gridSize = matrix.Length;
            int[] sol = new int[gridSize];

            //initialise solution
            for (int i = 0; i < gridSize; i++)
            {
                sol[i] = matrix[i][gridSize - 1];
            }
            for (int i = gridSize - 2; i >= 0; i--)
            {
                // Traverse down
                sol[0] += matrix[0][i];
                for (int j = 1; j < gridSize; j++)
                {
                    sol[j] = Math.Min(sol[j - 1] + matrix[j][i], sol[j] + matrix[j][i]);
                }

                //Traverse up
                for (int j = gridSize - 2; j >= 0; j--)
                {
                    sol[j] = Math.Min(sol[j], sol[j + 1] + matrix[j][i]);
                }
            }

            Console.WriteLine($"minimal path sum: {sol.Min()}");

        }
    }

}
