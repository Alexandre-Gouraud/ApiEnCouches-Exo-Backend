namespace ApiEnCouches.DataAccess.IDataAccess
{
    using ApiEnCouches.DataAccess.Entity;
    public interface IArticleDataAccess
    {
        Task<List<Article>> GetAllArticleAsync();
        Task<Article> AddArticleAsyn(Article article);
        Task<Article?> GetArticleByIdAsync(int id);
        Task<Article> CreateAsync(Article article);
        Task<Article> UpdateAsync(Article article);
        Task<bool> DeleteArticleAsync(int id);
    }
}
