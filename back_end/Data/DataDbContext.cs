using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using App.Models;
using App.Areas.Action.Models;
using App.Areas.Management.Models;

namespace App.Data
{
    public class DataDbContext : IdentityDbContext<AppUser>
    {
        
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
            
        }
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
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            
            modelBuilder.Entity<CategoryMovie>( entity => {
                entity.HasKey( c => new {c.CategoryId, c.MovieId});
            });  

            modelBuilder.Entity<Follow>( entity => {
                entity.HasKey( c => new {c.UserId, c.MovieId});
            });
              
            modelBuilder.Entity<LikeComment>( entity => {
                entity.HasKey( c => new {c.UserId, c.CommentId});

                entity.HasOne(lc => lc.User)
                    .WithMany(u => u.LikeComments)
                    .HasForeignKey(lc => lc.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(lc => lc.Comment)
                    .WithMany(c => c.Like)
                    .HasForeignKey(lc => lc.CommentId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
                          
            modelBuilder.Entity<Rating>( entity => {
                entity.HasKey( c => new {c.UserId, c.MovieId});
            });
        } 

        
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Episode> episodes { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<CategoryMovie> CategoryMovie { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}