namespace ApiEnCouches.DataAccess
{
    using ApiEnCouches.DataAccess.Entity;

    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
    }
}