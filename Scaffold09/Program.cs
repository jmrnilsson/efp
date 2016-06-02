using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Text;

namespace Scaffold09
{
    //Program.batch = 5000;
    //optionsBuilder.UseNpgsql("Host=localhost;Username=__;Password=;Database=chin");
    // optionsBuilder.UseSqlite("Filename=/Users/martinnilsson/devwork/efpad/Scaffold09/chin.db");
    public class Program
    {
        public static void Main()
        {
            dynamic result;
            using (var db = new chinookContext())
            {
                var query =
                    from a in db.Album
                    join ar in db.Artist on a.ArtistId equals ar.ArtistId
                    where ar.Name.StartsWith("A")
                    select new
                    {
                        album = a.Title,
                        artist = ar.Name,
                        tracks = string.Join
                        (
                            ", ", a.Track.Select(t => t.Name).Take(3)
                        )
                    };

                result = JsonConvert.SerializeObject
                (
                    query.Take(5).ToList(),
                    Newtonsoft.Json.Formatting.Indented
                );
            }
            Console.WriteLine(result);
        }
    }
}
