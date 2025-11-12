namespace ApiEnCouches.DataAccess.Seed.DbSeeder
{
    using ApiEnCouches.DataAccess.Seed.IDbSeeder;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DbSeeder
    {
        private readonly IEnumerable<IDbSeeder> _seeders;

        public DbSeeder(IEnumerable<IDbSeeder> seeders)
        {
            _seeders = seeders;
        }

        public async Task SeedAsync(AppDbContext context, bool isProduction)
        {
            foreach (var seeder in _seeders)
            {
                await seeder.SeedAsync(context, isProduction);
            }
        }
    }
}