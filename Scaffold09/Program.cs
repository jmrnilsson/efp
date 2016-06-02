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
    public class Program
    {
        public static void Main()
        {
            dynamic result = null;
            /* comment using-statement while scaffolding */
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
                        tracks = string.Join(", ", a.Track.Select(t => t.Name).Take(3))
                    };
                result = JsonConvert.SerializeObject(query.Take(5).ToList(), Formatting.Indented);
            }
            /* comment-end */
            Console.WriteLine(result);
        }
    }
}
