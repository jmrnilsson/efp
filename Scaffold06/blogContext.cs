using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Scaffold06
{
    public partial class blogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Filename=/Users/martinnilsson/devwork/efp/Scaffold06/db/blog.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Blog).WithMany(p => p.Post).HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<__EFMigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.Property(e => e.ProductVersion).IsRequired();
            });
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<__EFMigrationsHistory> __EFMigrationsHistory { get; set; }
    }
}