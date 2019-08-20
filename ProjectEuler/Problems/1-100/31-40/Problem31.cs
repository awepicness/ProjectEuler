using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem31
    {
        public void Method()
        {
            Console.WriteLine("How many ways can 2 pounds (English money) be generated using their currency?");
            // england uses pound and pence
            // there are 8 types of coins with values of: 1, 2, 5, 10, 20, 50, 100, and 200
            // how many different ways can 2 pounds (200p) be made using any number of coins?

            // answer from mathblog.dk because I couldn't figure it out

            // way 1 - brute force
            Console.WriteLine("Brute force solution:");

            int target = 200;
            int ways = 0;

            var sw = Stopwatch.StartNew();
            for (int a = target; a >= 0; a -= 200)
                for (int b = a; b >= 0; b -= 100)
                    for (int c = b; c >= 0; c -= 50)
                        for (int d = c; d >= 0; d -= 20)
                            for (int e = d; e >= 0; e -= 10)
                                for (int f = e; f >= 0; f -= 5)
                                    for (int g = f; g >= 0; g -= 2)
                                        ways++;
            sw.Stop();
            Console.WriteLine($"2 euro can be generated in {ways} ways");
            Console.WriteLine($"Time elapsed (BF): {sw.ElapsedMilliseconds} ms");

            // way 2 - dynamic programming
            Console.WriteLine("Dynamic programming solution:");

            sw = Stopwatch.StartNew();
            int[] coinSizes = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] wayz = new int[target + 1];
            wayz[0] = 1;

            for (int i = 0; i < coinSizes.Length; i++)
            for (int j = coinSizes[i]; j <= target; j++)
                wayz[j] += wayz[j - coinSizes[i]];
            sw.Stop();

            Console.WriteLine($"2 euros can be generated in {wayz.Last()} ways");
            Console.WriteLine($"Time elapsed (DP): {sw.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }
    }
}
