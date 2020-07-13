using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

namespace ProjectEuler
{
    /// <summary>
    /// My personal project for solving Project Euler problems, all in one solution and easily runnable
    /// Type a problem number to run it, or look at the available commands that are printed for alternate options.
    /// 
    /// Unfortunately I'm not experienced enough to understand or solve a good amount of the problems.
    /// When that occurs and I use a solution I found online, I make sure to comment where it was from.
    /// </summary>
    class Program
    {
        private static int lastProblem = 0;
        private static int run = 0;
        private static void Main()
        {
            if (run == 0)
                lastProblem = findLastProblem();
            bool nerd = false;
            Console.WriteLine("Hello! This program runs any ProjectEuler problem that I've completed.");
            while (true)
            {
                Console.WriteLine("Would you like to run a problem? type a problem number to run it.");
                Console.WriteLine("type 'completed' to see which problems I've done which have a solution");
                Console.WriteLine("type 'unfinished' to see problems I've started but haven't finished");
                Console.WriteLine("type 'not attempted' to see problems I haven't started");
                Console.WriteLine("Type 'test' to run the test class");
                Console.WriteLine("If you type anything else, the program will close");
                Console.WriteLine();
                string next = Console.ReadLine()?.ToLower();
                if (next == "completed")
                    ListCompleted();
                else if (next == "unfinished")
                    ListUnfinished();
                else if (next == "not attempted")
                    ListNotStarted();
                else if (next == "anything else")
                {
                    Console.Clear();
                    Console.WriteLine("haha, very funny. You've had your fun, now run along. From now on, please don't say anything funny");
                    Console.WriteLine();
                }
                else if (next == "anything funny")
                {
                    Console.Clear();
                    Console.WriteLine("Begone nerd");
                    Console.WriteLine();
                    nerd = true;
                }
                else if (next == "test")
                {
                    Console.Clear();
                    RunClass("Test");
                    Console.WriteLine();
                }
                else
                {
                    int.TryParse(next, out int nextNum);
                    if (nextNum == 0)
                        break;
                    RunClass(nextNum.ToString());
                    if (nerd)
                    {
                        switch (DateTime.Now.Millisecond % 3)
                        {
                            case 0:
                                Console.WriteLine("How'd you like that answer, nerd?");
                                break;
                            case 1:
                                Console.WriteLine("I hope you're enjoying this torment, nerd");
                                break;
                            case 2:
                                Console.WriteLine("I'm not gonna stop calling you a nerd, nerd. (until you restart the program)");
                                break;
                        }
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine("Press anything to close");
            Console.ReadLine();
        }

        private static void ListCompleted()
        {
            Console.Clear();
            Console.WriteLine("Completed problems:");
            Console.WriteLine();
            int count = 0;
            for (int i = 1; i <= lastProblem; i++)
            {
                object myclass = GetClassByString(i.ToString());
                if (myclass != null)
                    if (myclass.GetType().GetMethod("Method") != null)
                    {
                        Console.Write($"{i}, ");
                        count++;
                    }
            }

            Console.WriteLine();
            Console.WriteLine($"total completed: {count}");
            Console.WriteLine("\n");
        }

        private static void ListUnfinished()
        {
            Console.Clear();
            Console.WriteLine("Unfinished problems:");
            Console.WriteLine();
            int count = 0;
            for (int i = 1; i <= lastProblem; i++)
            {
                object myclass = GetClassByString(i.ToString());
                if (myclass?.GetType().GetMethod("Method") == null)
                {
                    Console.Write($"{i}, ");
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"total unfinished: {count}");
            Console.WriteLine("\n");
        }

        private static void ListNotStarted()
        {
            Console.Clear();
            Console.WriteLine("Not Attempted problems:");
            Console.WriteLine();
            int count = 0;
            for (int i = 1; i <= lastProblem; i++)
            {
                object myclass = GetClassByString(i.ToString());
                if (myclass == null)
                {
                    Console.Write($"{i}, ");
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"total not attempted (up to last completed problem, {lastProblem}): {count}");
            Console.WriteLine("\n");
        }

        private static int findLastProblem()
        {
            for (int i = 1000; i >= 0; i--)
            {
                object myclass = GetClassByString(i.ToString());
                if (myclass != null)
                    return i;
            }

            return 0;
        }

        private static void RunClass(string classNumber)
        {
            Console.Clear();
            Console.WriteLine("Problem " + classNumber);
            dynamic MyClass = GetClassByString(classNumber);

            if (MyClass != null)
            {
                var sw = Stopwatch.StartNew();
                try
                {
                    MyClass.Method();
                }
                catch (RuntimeBinderException)
                {
                    Console.WriteLine("problem unfinished");
                }
                sw.Stop();
                Console.WriteLine($"Time elapsed: {sw.ElapsedMilliseconds} ms");
                Console.WriteLine("---------------------------------------");
            }
            else
            {
                Console.WriteLine("problem not attempted");
            }
            Console.WriteLine();
        }

        private static object GetClassByString(string classNumber)
        {
            Type type;
            try
            {
                type = Assembly.GetExecutingAssembly().GetTypes().First(c => c.Name == $"Problem{classNumber}");
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            return Activator.CreateInstance(type);
        }
    }
}