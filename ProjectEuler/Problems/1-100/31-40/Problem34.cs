using System;

namespace ProjectEuler.Problems
{
    class Problem34
    {
        public void Method()
        {
            Console.WriteLine("find the sum of all numbers which are equal to the sum of the factorials of their digits");

            // iterate through numbers and find factorials, if the sum of the factorials equals the number,
            // add the number to the sum
            // start loop at 3 - per problem description, 1 and 2 are not included

            int sum = 0;
            for (int i = 3; i < 1000000; i++)
            {
                int currSum = 0;
                foreach (char c in i.ToString())
                    currSum += HelperMethods.Factorial(c - '0');

                if (currSum == i)
                    sum += i;
            }

            Console.WriteLine($"Sum of all numbers which are equal to the sum of the factorial of their digits: {sum}");
        }
    }
}
