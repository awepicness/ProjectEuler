using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem11
    {
        public void Method()
        {
            Console.WriteLine("Using the given grid, find the largest product of 4 adjacent numbers in the " +
                              "same direction (up, down, left, right, diagonally).");

            const string filename = "11grid.txt";

            string[] file = File.ReadAllLines(filename);

            int[][] matrix = new int[file.Length][];

            for (int i = 0; i < file.Length; i++)
                matrix[i] = Array.ConvertAll(file[i].Split(), int.Parse);

            int max = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    // dr/dl diag
                    if (i + 3 < matrix.Length)
                    {
                        if (j + 3 < matrix[i].Length)
                        {
                            int diag = matrix[i][j] * matrix[i + 1][j + 1] * matrix[i + 2][j + 2] * matrix[i + 3][j + 3];
                            if (diag > max)
                                max = diag;
                        }

                        if (j - 3 >= 0)
                        {
                            int diag = matrix[i][j] * matrix[i + 1][j - 1] * matrix[i + 2][j - 2] * matrix[i + 3][j - 3];
                            if (diag > max)
                                max = diag;
                        }
                    }

                    // ur/ul diag
                    if (i - 3 >= 0)
                    {
                        if (j + 3 < matrix[i].Length)
                        {
                            int diag = matrix[i][j] * matrix[i - 1][j + 1] * matrix[i - 2][j + 2] * matrix[i - 3][j + 3];
                            if (diag > max)
                                max = diag;
                        }

                        if (j - 3 >= 0)
                        {
                            int diag = matrix[i][j] * matrix[i - 1][j - 1] * matrix[i - 2][j - 2] * matrix[i - 3][j - 3];
                            if (diag > max)
                                max = diag;
                        }
                    }

                    // left/right
                    if (j + 3 < matrix.Length)
                    {
                        int right = matrix[i][j] * matrix[i][j + 1] * matrix[i][j + 2] * matrix[i][j + 3];
                        if (right > max)
                            max = right;
                    }

                    // up/down
                    if (i + 3 < matrix[i].Length)
                    {
                        int down = matrix[i][j] * matrix[i + 1][j] * matrix[i + 2][j] * matrix[i + 3][j];
                        if (down > max)
                            max = down;
                    }

                }
            }
            Console.WriteLine($"greatest product is {max}");
        }
    }
}
