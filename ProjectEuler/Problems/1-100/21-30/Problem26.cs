using System;

namespace ProjectEuler.Problems
{
    class Problem26
    {
        public void Method()
        {
            Console.WriteLine("Which fraction from 1/1 to 1/1000 contains the longest recurring cycle " +
                              "when represented as a decimal, and what is that cycle?");

            // thank you mathblog.dk

            int sequenceLength = 0;
            int num = 0;

            for (int i = 1000; i > 1; i--)
            {
                if (sequenceLength >= i)
                    break;
                
                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - foundRemainders[value] <= sequenceLength)
                    continue;

                num = i;
                sequenceLength = position - foundRemainders[value];
            }

            Console.WriteLine($"longest cycle is {num} with length of {sequenceLength}");
        }

    }
}
