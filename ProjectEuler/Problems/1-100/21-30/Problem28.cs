using System;

namespace ProjectEuler.Problems
{
    class Problem28
    {
        public void Method()
        {
            Console.WriteLine("Find the sum of the numbers in the diagonals of a 1001x1001 square spiral");

            long sum = 1; // start with sum of 1x1

            int num = 1;
            int dist = 2;
            for (int sl = 3; sl <= 1001; sl += 2) // side length of each outer spiral
            {
                for (int i = 0; i < 4; i++)
                {
                    num += dist;
                    sum += num;
                }
                dist += 2;
            }

            Console.WriteLine($"sum: {sum}");
        }
    }
}
