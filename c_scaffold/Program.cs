using System;
using System.Linq;
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
                var start = DateTime.UtcNow;
                var items =
                (
                    from p in db.Post
                    select new {p.Blog.Url, p.Title, p.Content}
                ).ToList();
                var duration = DateTime.UtcNow - start;

                foreach(var item in items)
                {
                    Console.WriteLine("{0} - {1} - {2}", item.Url, item.Title, item.Content);
                }

                Console.WriteLine();
                Console.WriteLine("{0} records read in {1} ms ", items.Count(), duration.TotalMilliseconds);
                Console.WriteLine("Total of {0} ms per record", duration.TotalMilliseconds / items.Count());

            }
        }
    }
}