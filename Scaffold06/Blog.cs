using System;
using System.Collections.Generic;

namespace Scaffold06
{
    public partial class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }

        public long BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
