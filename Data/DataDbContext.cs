using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using App.Models;
using App.Areas.Action.Models;
using App.Areas.Management.Models;

namespace App.Data
{
    public class DataDbContext(DbContextOptions<DataDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<CategoryMovie>(entity =>
            {
                entity.HasKey(c => new { c.CategoryId, c.MovieId });
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(c => new { c.UserId, c.MovieId });
            });


            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(c => new { c.UserId, c.MovieId });
            });

            modelBuilder.Entity<View>(entity =>
            {
                entity.HasKey(c => new { c.UserId, c.MovieId });
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CategoryMovie> CategoryMovie { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}
