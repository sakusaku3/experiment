using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace performance
{
    class Program
    {
        static void Main()
        {
            var table = new Dictionary<string, string>(
                StringComparer.InvariantCultureIgnoreCase);

            int[] array = { 1, 2, 3, 4 };
            Console.WriteLine(string.Join(",", array));

            ref int r = ref array[2];
            r += 4;
            Console.WriteLine(string.Join(",", array));

            var nums = Enumerable.Range(0, 10);
            Console.WriteLine("[[ PLINQ <1> ]]");
            nums.AsParallel()
                .ForAll(x =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"{x} ThreadID:{Thread.CurrentThread.ManagedThreadId}");
                });

            Console.WriteLine("Hit any key to exit...");
            Console.ReadKey();
        }
    }
}
