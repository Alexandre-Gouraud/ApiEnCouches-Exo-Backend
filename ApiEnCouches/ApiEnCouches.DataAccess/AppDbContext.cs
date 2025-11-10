namespace ApiEnCouches.DataAccess
{
    using ApiEnCouches.DataAccess.Entity;

    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { Id = 1, Title = "First Article", Content = "This is the content of the first article." },
                new Article { Id = 2, Title = "Second Article", Content = "This is the content of the second article." }
            );
        }
    }
}