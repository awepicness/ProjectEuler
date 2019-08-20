using System;

namespace ProjectEuler.Problems
{
    class Problem9
    {
        public void Method()
        {
            Console.WriteLine("find the pythagorean triplet (a^2 + b^2 = c^2) where a + b + c = 1000");

            int a = 0, b = 0, c = 0;
            int loopLimit = 1000;
            for (int i = 0; i < loopLimit; i++)
                for (int j = i + 1; j < loopLimit; j++)
                    for (int k = j + 1; k < loopLimit; k++)
                        if (i + j + k == 1000)
                            if (i * i + j * j == k * k)
                            {
                                a = i;
                                b = j;
                                c = k;
                            }

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            Console.WriteLine($"{a}^2 + {b}^2 = {c}^2");
            Console.WriteLine($"({a * a} + {b * b} = {c * c})");
            Console.WriteLine($"{a} + {b} + {c} = 1000");
            Console.WriteLine($"The product of a*b*c = {a * b * c}");
        }
    }
}
