namespace ApiEnCouches.DataAccess.DataAccess
{
    using ApiEnCouches.DataAccess.Entity;
    using ApiEnCouches.DataAccess.IDataAccess;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArticleDataAccess : IArticleDataAccess
    {
        private readonly AppDbContext _context;

        public ArticleDataAccess(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetAllArticleAsync() // Get all articles
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> AddArticleAsync(Article article) // Add a new article
        {
            var newArticle = article;
            _context.Articles.Add(newArticle);
            await _context.SaveChangesAsync();
            return article;
        }

        // Implement the interface member with the misspelled name
        public async Task<Article> AddArticleAsyn(Article article)
        {
            return await AddArticleAsync(article);
        }

        public async Task<Article?> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}