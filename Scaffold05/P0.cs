using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq.Expressions;

namespace Scaffold05
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new blogContext())
            {
                var expression =
                    from b in db.Blog
                    join p in db.Post on b.BlogId equals p.BlogId
                    select new {b.Url, p.Title, p.Content};

                var exp = expression.Expression;
                Console.WriteLine("Expression: {0}", exp.ToString());
            }
        }
    }
}
    