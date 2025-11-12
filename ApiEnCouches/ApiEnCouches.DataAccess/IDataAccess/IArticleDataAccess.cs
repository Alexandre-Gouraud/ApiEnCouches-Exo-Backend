namespace ApiEnCouches.DataAccess.IDataAccess
{
    using ApiEnCouches.DataAccess.Entity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleDataAccess
    {
        // Existing / older API
        Task<List<Article>> GetAllArticleAsync();
        Task<Article> AddArticleAsyn(Article article);
        Task<Article?> GetArticleByIdAsync(int id);
        Task<Article> CreateAsync(Article article);
        Task<Article> UpdateAsync(Article article);
        Task<bool> DeleteArticleAsync(int id);

        // New method names expected by service implementation
        Task<List<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
