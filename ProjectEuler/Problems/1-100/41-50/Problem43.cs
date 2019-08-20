using System;

namespace ProjectEuler.Problems
{
    class Problem43
    {
        public static int[] perm = { 1, 0, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void Method()
        {
            Console.WriteLine("find the sum of all 0-9 pandigital numbers in which each 3-character substring is divisible by a continuing sequence of prime numbers");
            // ex: 1406357289 is 0-9 pandigital
            // 406 % 2 == 0
            // 063 % 3 == 0
            // 635 % 5 == 0
            // 357 % 7 == 0
            // etc

            // no idea, result from mathblog.dk

            long result = 0;
            int[] divisors = { 1, 2, 3, 5, 7, 11, 13, 17 };

            int count = 1;
            int numPerm = 3265920;

            while (count < numPerm)
            {
                int N = perm.Length;
                int i = N - 1;
                while (perm[i - 1] >= perm[i])
                    i -= 1;

                int j = N;
                while (perm[j - 1] <= perm[i - 1])
                    j -= 1;

                // swap values at position i-1 and j-1
                swap(i - 1, j - 1);

                i++;
                j = N;
                while (i < j)
                {
                    swap(i - 1, j - 1);
                    i++;
                    j--;
                }
                bool divisible = true;
                for (int k = 1; k < divisors.Length; k++)
                {
                    int num = 100 * perm[k] + 10 * perm[k + 1] + perm[k + 2];
                    if (num % divisors[k] != 0)
                    {
                        divisible = false;
                        break;
                    }
                }
                if (divisible)
                {
                    long num = 0;
                    foreach (int permSub in perm)
                        num = 10 * num + permSub;
                    result += num;
                }
                count++;
            }

            Console.WriteLine($"The sum of numbers is {result}");
        }
        private static void swap(int i, int j)
        {
            int k = perm[i];
            perm[i] = perm[j];
            perm[j] = k;
        }
    }
}
