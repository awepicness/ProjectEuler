using System;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem99
    {
        public void Method()
        {
            Console.WriteLine("Using the given file containing base and exponent pairs, determine which line number has the greatest numerical value");

            const string filename = "99base_exp.txt";

            string[] file = File.ReadAllLines(filename);

            int lineNumber = 0;
            double max = 0;
            for (int i = 0; i < file.Length; i++)
            {
                string[] str = file[i].Split(',');

                int baseValue = int.Parse(str[0]);
                int exponent = int.Parse(str[1]);

                double result = exponent * Math.Log(baseValue);

                if (result <= max) continue;

                max = result;
                lineNumber = i + 1;
            }

            Console.WriteLine("Max value on line " + lineNumber);
        }
    }
}
