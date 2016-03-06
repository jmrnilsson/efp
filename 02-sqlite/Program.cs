using System;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");

                var evenBlogs =
                    from b in db.Blogs
                    where b.BlogId % 2 == 0
                    select b;


                Console.WriteLine("Blogs with even blog_ids");
                foreach (var blog in evenBlogs)
                {
                    Console.WriteLine(String.Join(", ", blog.Url, blog.BlogId, blog.Name, blog.Posts));
                }
            }
        }
    }
}