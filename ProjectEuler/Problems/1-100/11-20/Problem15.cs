using System;

namespace ProjectEuler.Problems
{
    class Problem15
    {
        public void Method()
        {
            Console.WriteLine("How many unique paths are there in a 20x20 grid if you can only move right or down?");

            // thank you mathblog.dk for this dynamic programming solution!
            // I literally just learned about dynamic programming in csce 310 five days ago

            const int len = 20;

            long[][] grid = new long[len+1][];
            for(int i = 0; i < len+1; i++)
                grid[i] = new long[len+1];

            for (int i = 0; i < len; i++)
            {
                grid[i][len] = 1;
                grid[len][i] = 1;
            }

            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = len - 1; j >= 0; j--)
                {
                    grid[i][j] = grid[i + 1][j] + grid[i][j + 1];
                }
            }

            Console.WriteLine($"there are {grid[0][0]} paths");
        }
    }
}
