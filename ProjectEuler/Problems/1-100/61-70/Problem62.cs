using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem62
    {
        private HashSet<long> cubePermutations;
        public void Method2()
        {
            // doesn't work: takes forever to get to answer (5027)
            // but it has an error before it ever gets there
            // guess I'll die :)

            Console.WriteLine("find the smallest cube for which exactly five permutations of its digits are cube");

            const int permLimit = 5;

            int baseNumber = 5026;
            List<long> cubePerms = new List<long>();
            while (true)
            {
                cubePermutations = new HashSet<long>();
                cubePerms = new List<long>();

                long cube = baseNumber * baseNumber * baseNumber;
                string cubeString = cube.ToString();
                int n = cubeString.Length;
                int[] cubeDigits = new int[n];
                for (int i = 0; i < n; i++)
                    cubeDigits[i] = cubeString[i] - '0';

                GeneratePermutations(cubeDigits, n, n);

                int cubeCount = 0;
                foreach (long p in cubePermutations)
                {
                    if (cubeCount > permLimit)
                        break;
                    var cuberoot = Math.Pow(p, (1.0 / 3.0));
                    if (Math.Abs(cuberoot % 1) > 0.00001)
                    {
                        cubeCount++;
                        cubePerms.Add((long)cuberoot);
                    }
                }

                if (cubeCount == permLimit)
                    break;

                baseNumber++;
            }

            Console.WriteLine($"smallest cube with {permLimit} permutations is {baseNumber}^3 = {baseNumber*baseNumber*baseNumber}");
        }

        private void GeneratePermutations(int[] digits, int size, int n)
        {
            if (size == 1)
                cubePermutations.Add(long.Parse(string.Join("", digits)));
            for (int i = 0; i < size; i++)
            {
                GeneratePermutations(digits, size-1, n);

                int index = size % 2 == 1 ? 0 : i;
                
                int temp = digits[index];
                digits[index] = digits[size - 1];
                digits[size - 1] = temp;
            }
        }
    }
}
