using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem61
    {
        public void Method()
        {
            Console.WriteLine("Find the sum of the only ordered set of six 4-digit numbers for which " +
                              "each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal, and octagonal, " +
                              "is represented by a different number in the set, and the last 2 digits of each number " +
                              "matches the first 2 digits of the next number (including the last and the first numbers)\n");

            HashSet<Tuple<string, char>> figurates = BuildFigurates();
            foreach (var a in figurates)
            {
                List<char> aInvalids = new List<char>{a.Item2};
                var aMatches = getMatches(figurates, a, aInvalids);

                foreach (var b in aMatches)
                {
                    List<char> bInvalids = new List<char>{a.Item2, b.Item2};
                    var bMatches = getMatches(figurates, b, bInvalids);

                    foreach (var c in bMatches)
                    {
                        List<char> cInvalids = new List<char>{a.Item2, b.Item2, c.Item2};
                        var cMatches = getMatches(figurates, c, cInvalids);

                        foreach (var d in cMatches)
                        {
                            List<char> dInvalids = new List<char> { a.Item2, b.Item2, c.Item2, d.Item2 };
                            var dMatches = getMatches(figurates, d, dInvalids);

                            foreach (var e in dMatches)
                            {
                                List<char> eInvalids = new List<char> { a.Item2, b.Item2, c.Item2, d.Item2, e.Item2 };
                                var eMatches = getMatches(figurates, e, eInvalids);

                                foreach (var f in eMatches)
                                {
                                    if (getSub(f) != a.Item1.Substring(0, 2))
                                        continue;

                                    var sum = int.Parse(a.Item1) + int.Parse(b.Item1) + int.Parse(c.Item1) 
                                            + int.Parse(d.Item1) + int.Parse(e.Item1) + int.Parse(f.Item1);

                                    List<Tuple<string, char>> matches = new List<Tuple<string, char>>{a, b, c, d, e, f};
                                    foreach(var m in matches)
                                        Console.WriteLine($"{m.Item1} : {getCharString(m.Item2)}");
                                    Console.WriteLine($"sum: {sum}");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private string getCharString(char c)
        {
            switch (c)
            {
                case 'O': return "Octagonal";
                case 'X': return "Hexagonal";
                case 'T': return "Triangular";
                case 'H': return "Heptagonal";
                case 'S': return "Square";
                case 'P': return "Pentagonal";
            }

            return "";
        }

        private string getSub(Tuple<string, char> val) => val.Item1.Substring(2);

        private List<Tuple<string, char>> getMatches(HashSet<Tuple<string, char>> figurates, Tuple<string, char> val, List<char> invalids)
        {
            return figurates.Where(t => t.Item1.Substring(0, 2) == getSub(val) && !invalids.Contains(t.Item2)).ToList();
        }

        private HashSet<Tuple<string, char>> BuildFigurates()
        {
            HashSet<Tuple<string, char>> figurates = new HashSet<Tuple<string, char>>();
            for (int i = 1; i < 150; i++)
            {

                var t = i * (i + 1) / 2;
                var s = i * i;
                var p = i * (3 * i - 1) / 2;
                var x = i * (2 * i - 1);
                var h = i * (5 * i - 3) / 2;
                var o = i * (3 * i - 2);

                if (o < 1000) // o always has the max value
                    continue;

                if (t > 10000) // t always has the min value
                    break;

                AddTuple(ref figurates, t, 'T');
                AddTuple(ref figurates, s, 'S');
                AddTuple(ref figurates, p, 'P');
                AddTuple(ref figurates, x, 'X');
                AddTuple(ref figurates, h, 'H');
                AddTuple(ref figurates, o, 'O');
            }

            return figurates;
        }

        private void AddTuple(ref HashSet<Tuple<string, char>> figurates, int value, char type)
        {
            if (value >= 1000 && value < 10000)
                figurates.Add(new Tuple<string, char>(value.ToString(), type));
        }
    }
}
