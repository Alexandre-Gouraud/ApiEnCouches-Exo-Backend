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
                new Article { Title = "First Article", Content = "Content of the first article." },
                new Article { Title = "Second Article", Content = "Content of the second article." },
            };

                context.Articles.AddRange(articles);
                await context.SaveChangesAsync();
            }
        }
    }
}