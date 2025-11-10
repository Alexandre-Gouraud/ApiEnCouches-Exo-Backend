namespace ApiEnCouches.DataAccess.Seed.ArticleSeeder
{
    using ApiEnCouches.DataAccess.Entity;
    using ApiEnCouches.DataAccess.Seed.IDbSeeder;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ArticleSeeder : IDbSeeder
    {
        public async Task SeedAsync(AppDbContext context, bool isProduction)
        {
            if (!context.Articles.Any())
            {

                var articles = new List<Article>
            {
                new Article { Title = "Seed 1 - ", Content = "Article 1" },
                new Article { Title = "Seed 2 - ", Content = "Article 2" },
                new Article { Title = "Seed 3 - ", Content = "Article 3" },
            };

                context.Articles.AddRange(articles);
                await context.SaveChangesAsync();
            }
        }
    }
}