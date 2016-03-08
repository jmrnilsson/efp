using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace 03-scaffold
{
    public partial class blogsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Filename=/Users/martinnilsson/devwork/efp/03-scaffold/blogs.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}