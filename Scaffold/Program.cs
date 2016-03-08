using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace Scaffold
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
                var first = filtered.First();
                stopWatch.Stop();

                foreach(var item in filtered)
                {
                    Console.WriteLine("{0} - {1} - {2}", item.Url, item.Title, item.Content);
                }

                const double kμ = 0.001;
                Console.WriteLine();
                Console.WriteLine("Read {0} records in {1:N0} μs", items.Count(), (read - interpret) * kμ);
                Console.WriteLine("Assigned expression in {0:N0} μs", interpret * kμ);
                Console.WriteLine("Scan in {0:N0} μs", (scan - read) * kμ);
                Console.WriteLine("Enumerate next in {0:N0} μs", (stopWatch.ElapsedTicks - scan) * kμ);
                Console.WriteLine("Total time was {0:N0} μs", stopWatch.ElapsedTicks * kμ);
            }
        }
    }
}