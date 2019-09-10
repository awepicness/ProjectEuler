using System;

namespace ProjectEuler
{
    class Problem5
    {
        public void Method()
        {
            Console.WriteLine("what is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?");
            // result: 232792560
            bool go = true;
            int result = 20;
            while (go)
                if (isDivisibleByAll(result))
                    go = false;
                else
                    result += 20; // if our number is not divisible by 20, neither will the next 19 numbers, so add 20
            
            Console.WriteLine($"{result} is the smallest positive number evenly divisible by all numbers from 1 to 20");
        }

        private static bool isDivisibleByAll(int num)
        {
            // don't need to check every number 1-20. ex: if divisible by 20, then divisible by 2
            return num % 11 == 0 && num % 12 == 0 && num % 13 == 0 && num % 14 == 0 && num % 15 == 0 && 
                   num % 16 == 0 && num % 17 == 0 && num % 18 == 0 && num % 19 == 0 && num % 20 == 0;
        }
    }
}
