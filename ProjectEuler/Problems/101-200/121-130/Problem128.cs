using System;

namespace ProjectEuler.Problems._101_200._121_130
{
    class Problem128
    {
        public void Method2()
        {

            // generates the top number of each ring of consecutive rings of hexagons
            int sum = 1;
            for (int i = 1; i < 100; i++)
            {
                int hex = 2 * i * i - i;
                int secondHex = i > 1
                    ? (i - 2) * (2 * (i - 2) + 1)
                    : 0;
                sum += hex - secondHex;
                Console.WriteLine($"hex[{i}] = {hex}, secondHex[{i-2}] = {secondHex}, sum = {sum}");
            }
            // interestingly, the sequence of each consecutive sum is 2, 8, 20, 38, 62, 92, 128...
            // which, according to oeis, is the maximum number of regions into which "the plane" is divided by n triangles
            // I've apparently already viewed this page before too, which means I've used this sequence in a problem already...

            // patterns
            // one proximal number is always 1 away.
            //      if the number n is some number in the sequence of sums - 1, n - 1 appears nearby.
            //      otherwise n + 1 will always be nearby
            // unfortunately, that's only one nearby number and I need to figure out how to find the other 5
            // unfortunately, this problem must be impossible
        }
    }
}
