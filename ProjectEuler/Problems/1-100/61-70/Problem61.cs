using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem61
    {
        public void Method()
        {
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
                                    if (getSub(f) == a.Item1.Substring(0, 2))
                                    {
                                        var sum = int.Parse(a.Item1) + int.Parse(b.Item1)
                                                                     + int.Parse(c.Item1) + int.Parse(d.Item1)
                                                                     + int.Parse(e.Item1) + int.Parse(f.Item1);

                                        Console.WriteLine("match");
                                        Console.WriteLine($"{a.Item1} : {getCharString(a.Item2)}");
                                        Console.WriteLine($"{b.Item1} : {getCharString(b.Item2)}");
                                        Console.WriteLine($"{c.Item1} : {getCharString(c.Item2)}");
                                        Console.WriteLine($"{d.Item1} : {getCharString(d.Item2)}");
                                        Console.WriteLine($"{e.Item1} : {getCharString(e.Item2)}");
                                        Console.WriteLine($"{f.Item1} : {getCharString(f.Item2)}");
                                        Console.WriteLine($"sum: {sum}");
                                        return;
                                    }
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

                if (o < 1000)
                    continue;

                if (t > 10000)
                    break;

                if (t >= 1000 && t < 10000)
                    figurates.Add(new Tuple<string, char>(t.ToString(), 'T'));
                if (s >= 1000 && s < 10000)
                    figurates.Add(new Tuple<string, char>(s.ToString(), 'S'));
                if (p >= 1000 && p < 10000)
                    figurates.Add(new Tuple<string, char>(p.ToString(), 'P'));
                if (x >= 1000 && x < 10000)
                    figurates.Add(new Tuple<string, char>(x.ToString(), 'X'));
                if (h >= 1000 && h < 10000)
                    figurates.Add(new Tuple<string, char>(h.ToString(), 'H'));
                if (o >= 1000 && o < 10000)
                    figurates.Add(new Tuple<string, char>(o.ToString(), 'O'));
            }

            return figurates;
        }
    }
}
