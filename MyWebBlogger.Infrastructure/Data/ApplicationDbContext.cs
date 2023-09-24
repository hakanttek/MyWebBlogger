using Microsoft.EntityFrameworkCore;
using MyWebBlogger.Domain.Posts;
using MyWebBlogger.Domain.Projects;

namespace MyWebBlogger.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Posts");
                entity.HasKey(p => p.Id);
                entity.HasData(
                    new Post { Id = 1, Title = "Post 1", CreatedDate = DateTime.Now},
                    new Post { Id = 2, Title = "Post 2", CreatedDate = DateTime.Now}
                );
            });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects");
                entity.HasKey(p => p.Id);
                entity.HasData(
                    new Project { Id = 1, Name = "Project 1" , CreatedDate = DateTime.Now },
                    new Project { Id = 2, Name = "Project 2" , CreatedDate = DateTime.Now }
                );
            });
        }
    }
}
