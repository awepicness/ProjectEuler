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
            for (int i = 0; i < stringMatrix.Length; i++)
                for (int j = 0; j < stringMatrix.Length; j++)
                    matrix[i][j] = int.Parse(stringMatrix[i][j]);

            // todo: solve the question :(
        }
    }
}
