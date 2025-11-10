namespace ApiEnCouches.DataAccess.Seed.IDbSeeder
{
    using System.Threading.Tasks;

    public interface IDbSeeder
    {
        Task SeedAsync(AppDbContext context, bool isProduction);
    }
}