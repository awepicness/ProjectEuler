using System;

namespace ProjectEuler.Problems
{
    class Problem76
    {
        public void Method()
        {
            Console.WriteLine("Determine the number of unique ways that any amount of integers can sum to 100");

            int target = 100;
            int[] ways = new int[target + 1];
            ways[0] = 1;

            for (int i = 1; i < target; i++)
                for (int j = i; j <= target; j++)
                    ways[j] += ways[j - i];
            
            Console.WriteLine($"{target} can be generated in {ways[ways.Length-1]} ways");
        }
    }
}
