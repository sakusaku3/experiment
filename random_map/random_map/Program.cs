using System;
using System.Collections.Generic;
using System.Linq;

namespace random_map
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 14)
                .Select(x => x * 0.5)
                .Select(x => (x, 7.5 - x))
                .ToList();

            var combinations = RecursiveGetCombinations(list, 5)
                .Where(IsTarget);

            foreach(var c in combinations)
            {
                var value = string.Join(',', c.Select(x => $"({x.Item1},{x.Item2})"));
                var value1 = c.Select(x => x.Item1).Sum();
                var value2 = c.Select(x => x.Item2).Sum();
                Console.WriteLine($"[{value}], {value1}, {value2}");
            }

        }

        static IEnumerable<IList<(double, double)>> RecursiveGetCombinations(
            IEnumerable<(double, double)> list, int count)
        {
            if (count == 1)
            {
                foreach (var l in list)
                {
                    yield return new List<(double, double)> { l };
                }
            }
            else
            {
                var done = RecursiveGetCombinations(list, count - 1);
                foreach (var l in list)
                {
                    foreach (var d in done)
                    {
                        d.Insert(0, l);
                        yield return d;
                    }
                }
            }
        }

        static bool IsTarget(IList<(double i, double j)> list)
        {
            return list.Select(x => x.i).Average() == 6.0 &&
                list.Select(x => x.j).Average() == 1.5;
        }
    }
}
