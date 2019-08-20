using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem40
    {
        public void Method()
        {
            Console.WriteLine("if dn represents the nth digit of the irrational fraction 0.1234567891011121314...");
            Console.WriteLine("find d1 x d10 x d100 x d1000 x d10000 x d100000 x d1000000");

            List<int> numbers = new List<int>();
            int limit = 1000000;
            for (int i = 1; i <= limit; i++)
                numbers.Add(i);

            string concat = string.Concat(numbers);

            int result = 1;
            for (int i = 1; i.ToString().Length < limit.ToString().Length; i *= 10)
                result *= concat[i - 1] - '0';

            Console.WriteLine($"Result: {result}");
        }
    }
}
