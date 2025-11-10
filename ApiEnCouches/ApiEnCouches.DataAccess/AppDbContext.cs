namespace ApiEnCouches.DataAccess
{
    using ApiEnCouches.DataAccess.Entity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Article> Articles => Set<Article>();
    }
}