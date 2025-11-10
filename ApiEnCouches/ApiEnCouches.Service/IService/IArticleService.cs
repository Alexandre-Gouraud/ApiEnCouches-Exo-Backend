namespace ApiEnCouches.Service.IService
{
    using ApiEnCouches.DataAccess.IDataAccess;
    using ApiEnCouches.Service.DataTransferObject;
    using ApiEnCouches.DataAccess.Entity;
    using System.Threading.Tasks;


    public interface IArticleService
    {
        Task<List<Article>> GetAllArticleAsync();
        Task<Article> AddArticleAsync(Article article);
        Task<Article?> GetArticleByIdAsync(int id);
        Task<bool> DeleteArticleAsync(int id);
    }
}