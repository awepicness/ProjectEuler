using System;

namespace ProjectEuler.Problems
{
    class Problem104
    {
        public void Method()
        {
            Console.WriteLine("Given that Fk is the first Fibonacci number for which the first nine digits AND the last nine digits are 1-9 pandigital, find k");

            // my solution should work but it would take forever (multiple minutes if not dozens) to complete
            // I haven't completed it all the way through but I don't think I should run out of memory at any point
            // BigInteger is arbitrary floating point
            // string max length is int32.maxValue characters (~ 2 billion) and answer is only 300k chars

            //BigInteger n1 = 1;
            //BigInteger previous = 1;
            //int iterations = 2;
            //while (true)
            //{
            //    BigInteger n2 = n1;
            //    n1 = n2 + previous;
            //    previous = n2;
            //    iterations++;

            //    if (iterations < 45)
            //        continue;

            //    string n1s = n1.ToString();
            //    long firstNum = long.Parse(n1s.Substring(0, 9));
            //    long lastNum = long.Parse(n1s.Substring(n1s.Length - 9));

            //    bool first = HelperMethods.IsPandigital(firstNum);
            //    bool last = HelperMethods.IsPandigital(lastNum);

            //    if (first && last)
            //    {
            //        Console.WriteLine("Both!");
            //        Console.WriteLine($"Iter: {iterations}");
            //        break;
            //    }

            //    if (first)
            //        Console.WriteLine($"first: {iterations}");
            //    else if (last)
            //        Console.WriteLine($"last: {iterations}");

            //}

            // thank you mathblog.dk for a solution that's like 100,000 times faster

            long fn2 = 1;
            long fn1 = 1;

            long tailcut = 1000000000;

            int n = 2;
            bool found = false;

            while (!found)
            {
                n++;
                long fn = (fn1 + fn2) % tailcut;
                fn2 = fn1;
                fn1 = fn;

                if (HelperMethods.IsPandigital(fn))
                {
                    double t = (n * 0.20898764024997873 - 0.3494850021680094);
                    if (HelperMethods.IsPandigital((long) Math.Pow(10, t - (long) t + 8)))
                        found = true;
                }
            }
            Console.WriteLine($"F({n}) is the first fibonacci number where the first and last 9 digits are 1-9 pandigital");
        }
    }
}
