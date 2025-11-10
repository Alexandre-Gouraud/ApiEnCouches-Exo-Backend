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

        // New API compatibility methods expected by IArticleDataAccess
        public async Task<List<Article>> GetAllAsync()
        {
            return await GetAllArticleAsync();
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

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await GetArticleByIdAsync(id);
        }

        public async Task<Article> CreateAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<bool> DeleteAsync(int id)
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

        public async Task<bool> DeleteArticleAsync(int id)
        {
            return await DeleteAsync(id);
        }

    }
}