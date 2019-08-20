using System;

namespace ProjectEuler.Problems
{
    class Problem114
    {
        private long[] cache;
        public void Method()
        {
            Console.WriteLine("How many ways can you fill a row of 50 blocks?");

            // I didn't make the algorithm, but I discovered part of the pattern.
            // the base of the pattern is OEIS 124, or the Lazy Caterer's sequence
            // the equation for it is (n*(n+1)/2) + 1,
            // where n is the amount of blocks in each row - min length of block sequence + 1
            // unfortunately, this doesn't include cases where you have multiple sequences of blocks
            // separated by 1 or more blocks in the same row, and I didn't know how to approach that 
            // so I ended up looking up the answer

            int m = 50;
            int n = 3;
            cache = new long[m+1];
            long solutions = F(m, n);

            Console.WriteLine($"A row of {m} blocks can be filled in {solutions} ways, " +
                              $"assuming the minimum length of blocks that can be filled is {n}");

        }
        
        // thank you mathblog.dk
        private long F(int m, int n)
        {

            //The rest is empty
            long solutions = 1;

            //we can't fill out more
            if (n > m) return solutions;

            if (cache[m] != 0) return cache[m];

            for (int startpos = 0; startpos <= m - n; startpos++)
            {
                for (int blocklength = n; blocklength <= m - startpos; blocklength++)
                {
                    solutions += F(m - startpos - blocklength - 1, n);
                }
            }

            cache[m] = solutions;
            return solutions;
        }
    }
}
