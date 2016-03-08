using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace c_scaffold
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new blogContext())
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var expression =
                    from b in db.Blog
                    join p in db.Post on b.BlogId equals p.BlogId
                    select new {b.Url, p.Title, p.Content};

                long interpret = stopWatch.ElapsedMilliseconds;
                var items = expression.ToList();
                long read = stopWatch.ElapsedMilliseconds - interpret;
                var filtered = items.Where(i => i.Url == "768aea71-c405-4808-b1e6-150692142875").ToList();
                long scan = stopWatch.ElapsedMilliseconds - read;

                foreach(var item in filtered)
                {
                    Console.WriteLine("{0} - {1} - {2}", item.Url, item.Title, item.Content);
                }

                Console.WriteLine();
                Console.WriteLine("{0} records read in {1} ms", items.Count(), read);
                Console.WriteLine("Average {0} ms per record", Math.Round((double) read / items.Count(), 2));
                Console.WriteLine("Expression interpretation in {0} ms", interpret);
                Console.WriteLine("In-memory scan in {0} ms", scan);
            }
        }
    }
}