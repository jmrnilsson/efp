using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.RemoveRange(db.Blogs);
                db.Posts.RemoveRange(db.Posts);
                db.SaveChanges();
                var start = DateTime.UtcNow;
                foreach (var index in Enumerable.Range(0, 100))
                {
                    var blog = new Blog();
                    blog.Url = Guid.NewGuid().ToString();
                    blog.Posts = new List<Post>();
                    foreach (var indexPost in Enumerable.Range(0, index % 20))
                    {
                        var post = new Post();
                        post.Title = Guid.NewGuid().ToString();
                        post.Content = Guid.NewGuid().ToString();
                        blog.Posts.Add(post);
                    }
                    db.Blogs.Add(blog);
                }
                var count = db.SaveChanges();
                var duration = (DateTime.UtcNow - start).TotalMilliseconds;
                Console.WriteLine("{0} records updated in {1} ms ", count, duration);
                Console.WriteLine("Total of {0} ms per record", duration/count);
            }
        }
    }
}