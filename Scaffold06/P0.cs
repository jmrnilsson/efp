using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace Scaffold05
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new blogContext())
            {
                Console.WriteLine("Starting...");
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var expression =
                    from b in db.Blog
                    join p in db.Post on b.BlogId equals p.BlogId
                    select new {b.Url, p.Title, p.Content};

                long interpret = stopWatch.ElapsedTicks;
                var items = expression.ToList();
                long read = stopWatch.ElapsedTicks;
                var filtered = items.Where(i => i.Url == "768aea71-c405-4808-b1e6-150692142875").ToList();
                long scan = stopWatch.ElapsedTicks;
                var firstable = filtered.First();
                long first = stopWatch.ElapsedTicks;
                var five = filtered[5];
                stopWatch.Stop();

                foreach(var item in filtered.Take(9))
                {
                    Console.WriteLine("1:{0}", item.Url);
                    Console.WriteLine("2:{0}", item.Title);
                    Console.WriteLine("3:{0}", item.Content);
                }

                const double kμ = 0.001;
                Console.WriteLine();
                Console.WriteLine("Read {0} records in {1:N0} μs", items.Count(), (read - interpret) * kμ);
                Console.WriteLine("Assigned expression in {0:N0} μs", interpret * kμ);
                Console.WriteLine("Scan in {0:N0} μs", (scan - read) * kμ);
                Console.WriteLine("Enumerate next in {0:N0} μs", (first - scan) * kμ);
                Console.WriteLine("Index 5 in {0:N2} μs", (stopWatch.ElapsedTicks - first) * kμ);
                Console.WriteLine("Total time was {0:N0} μs", stopWatch.ElapsedTicks * kμ);
            }
        }
    }
}
    