using System;
using System.IO;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem89
    {
        public void Method()
        {
            Console.WriteLine("The given text file contains 1000 valid, but not necessarily minimal, roman numerals.");
            Console.WriteLine("Find the number of characters saved by writing each number in its minimal form.");

            // solved on my own! although my solution is ~200 lines and the math blog version is 4 :((

            const string filename = "89roman.txt";

            string[] file = File.ReadAllLines(filename);

            // count characters
            int charCountBefore = 0;
            foreach(string numeral in file)
                foreach (char _ in numeral)
                    charCountBefore++;

            // convert each numeral to minimal form
            int charCountAfter = 0;
            string[] shortenedFile = new string[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                shortenedFile[i] = BaseTenToRoman(RomanToBaseTen(file[i]));
                foreach (char _ in shortenedFile[i])
                    charCountAfter++;
            }

            Console.WriteLine($"After minimizing the roman numeral file, {charCountBefore - charCountAfter} characters were saved");
        }

        private string BaseTenToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();

            while (num > 0)
            {
                if (num >= 1000)
                {
                    num -= 1000;
                    sb.Append('M');
                }
                else if (num >= 900)
                {
                    num -= 900;
                    sb.Append("CM");
                }
                else if (num >= 500)
                {
                    num -= 500;
                    sb.Append('D');
                }
                else if (num >= 400)
                {
                    num -= 400;
                    sb.Append("CD");
                }
                else if (num >= 100)
                {
                    num -= 100;
                    sb.Append('C');
                }
                else if (num >= 90)
                {
                    num -= 90;
                    sb.Append("XC");
                }
                else if (num >= 50)
                {
                    num -= 50;
                    sb.Append('L');
                }
                else if (num >= 40)
                {
                    num -= 40;
                    sb.Append("XL");
                }
                else if (num >= 10)
                {
                    num -= 10;
                    sb.Append('X');
                }
                else if (num >= 9)
                {
                    num -= 9;
                    sb.Append("IX");
                }
                else if (num >= 5)
                {
                    num -= 5;
                    sb.Append('V');
                }
                else if (num >= 4)
                {
                    num -= 4;
                    sb.Append("IV");
                }
                else if (num >= 1)
                {
                    num -= 1;
                    sb.Append('I');
                }
            }

            return sb.ToString();
        }

        private int RomanToBaseTen(string str)
        {
            string input = str.ToUpper();

            int result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                switch(input[i])
                {
                    case 'I':
                        if (i != input.Length - 1)
                        {
                            if (input[i + 1] == 'V')
                            {
                                result += 4;
                                i++;
                            }
                            else if (input[i + 1] == 'X')
                            {
                                result += 9;
                                i++;
                            }
                            else
                                result += 1;
                        }
                        else
                            result += 1;
                        break;
                    case 'V':
                        result += 5;
                        break;
                    case 'X':
                        if (i != input.Length - 1)
                        {
                            if (input[i + 1] == 'L')
                            {
                                result += 40;
                                i++;
                            }
                            else if (input[i + 1] == 'C')
                            {
                                result += 90;
                                i++;
                            }
                            else
                                result += 10;
                        }
                        else
                            result += 10;
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'C':
                        if (i != input.Length - 1)
                        {
                            if (input[i + 1] == 'D')
                            {
                                result += 400;
                                i++;
                            }
                            else if (input[i + 1] == 'M')
                            {
                                result += 900;
                                i++;
                            }
                            else
                                result += 100;
                        }
                        else
                            result += 100;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'M':
                        result += 1000;
                        break;
                }
            }

            return result;
        }
    }
}
