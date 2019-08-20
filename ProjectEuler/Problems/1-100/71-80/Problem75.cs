using System;

namespace ProjectEuler.Problems
{
    class Problem75
    {
        public void Method()
        {
            Console.WriteLine("Given L length of wire, for how many values of L <= 1.5 million can exactly one integer-sided right-angle triangle be formed?");

            // answer from mathblog.dk yet again because my answer was wrong 🙃

            const int upperLimit = 1500000;
            int mLimit = (int) Math.Sqrt(upperLimit/2);

            int[] triangles = new int[upperLimit+1];
            int count = 0;

            for(long m = 2; m < mLimit; m++)
                for (long n = 1; n < m; n++)
                {
                    if ((n + m) % 2 == 1 && gcd(n, m) == 1)
                    {
                        long a = m * m + n * n;
                        long b = m * m - n * n;
                        long c = 2 * m * n;
                        long p = a + b + c;
                        while (p <= upperLimit)
                        {
                            triangles[p]++;
                            if (triangles[p] == 1)
                                count++;
                            if (triangles[p] == 2)
                                count--;
                            p += a + b + c;
                        }
                    }
                }

            Console.WriteLine($"There are {count} unique integer-sided right-triangles less than {upperLimit}");
        }

        private long gcd(long a, long b)
        {
            long y, x;

            if (a > b)
            {
                x = a;
                y = b;
            }
            else
            {
                x = b;
                y = a;
            }

            while (x % y != 0)
            {
                long temp = x;
                x = y;
                y = temp % x;
            }

            return y;
        }
    }
}
