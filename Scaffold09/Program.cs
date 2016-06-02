using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace dotnet
{
  public class StatsContext : DbContext
  {
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          //Program.batch = 5000;
          //optionsBuilder.UseNpgsql("Host=localhost;Username=martinnilsson;Password=;Database=stats");
          optionsBuilder.UseSqlite("Filename=/Users/martinnilsson/devwork/efpad/Scaffold09/stats.db");
      }
    }

    public class Program
    {
        public static void Main()
        {
            using (var db = new StatsContext())
            {
                /* var query =
                    from b in db.Blog
                    join p in db.Post on b.BlogId equals p.BlogId
                    select new {b.Url, p.Title, p.Content};

                var result = JsonConvert.SerializeObject(query.Take(25).ToList());
*/
                Console.WriteLine("a");
            }
        }
    }
}
