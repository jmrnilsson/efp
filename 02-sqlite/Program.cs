using System;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var random = new Random();
            using (var db = new BloggingContext())
            {
                new string[]
                {
                    "http://blogs.msdn.com/adonet",
                    "http://microsoft.com",
                    "https://github.com/dotnet/coreclr",
                    "https://github.com/aspnet/"
                }.ToList().ForEach(url => db.Blogs.Add(new Blog
                {
                    Url = url,
                    Posts = Enumerable.Range(1, random.Next(1, 4)).Select(r => new Post
                    {
                        Title = "Title" + random.Next(0, 999),
                        Content = "Content" + random.Next(0, 999)
                    }).ToList()
                }));
                var count = db.SaveChanges();

                Console.WriteLine("{0} records saved to database", count);
                Console.WriteLine("All blogs in database:");

                var blogs =
                    from b in db.Blogs
                    where b.Posts.Any()
                    select new {b.Url, b.Posts.First().Title};

                foreach (var blog in blogs)
                {
                    Console.WriteLine(string.Format("{0} - {1}", blog.Url, blog.Title));
                }
            }
        }
    }
}