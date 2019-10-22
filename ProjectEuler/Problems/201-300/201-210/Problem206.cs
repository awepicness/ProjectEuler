using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem206
    {
        public void Method()
        {
            Console.WriteLine("Find the unique positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0, where each '_' is a single digit.");
            Console.WriteLine("I wasn't sure how to optimize this problem and didn't wanna look it up. it takes ~60 seconds to run");
            // answer is 1389019170

            string placeholder = "1_2_3_4_5_6_7_8_9_0";
            long max = 1929394959697989990;
            long min = 1020304050607080900;
            long uLim = (long) Math.Ceiling(Math.Sqrt(max));
            long lLim = (long) Math.Floor(Math.Sqrt(min));

            Console.WriteLine($"lower limit: {lLim}");
            Console.WriteLine($"upper limit: {uLim}");

            long i = lLim;
            for (; i <= uLim; i+=2)
            {
                string sq = (i * i).ToString("###################");

                if (sq[0] != '1') continue;
                if (sq[2] != '2') continue;
                if (sq[4] != '3') continue;
                if (sq[6] != '4') continue;
                if (sq[8] != '5') continue;
                if (sq[10] != '6') continue;
                if (sq[12] != '7') continue;
                if (sq[14] != '8') continue;
                if (sq[16] != '9') continue;
                if (sq[18] != '0') continue;
                break;
            }

            Console.WriteLine();

            if(i >= uLim)
                Console.WriteLine("ERROR: incorrect answer");
            Console.WriteLine($"{placeholder}");
            Console.WriteLine($"{(i * i).ToString("###################")}");
            Console.WriteLine($"result: {i}");
        }
    }
}
