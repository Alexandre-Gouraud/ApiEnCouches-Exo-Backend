namespace ApiEnCouches.Service.IService
{
    using ApiEnCouches.DataAccess.IDataAccess;
    using ApiEnCouches.Service.DataTransferObject;
    using ApiEnCouches.DataAccess.Entity;
    using System.Threading.Tasks;


    public interface IArticleService
    {
        Task<List<Article>> GetAllArticleAsync();
        Task<ArticleDTO?> AddArticleAsync(CreateArticleDTO createArticleDTO);
        Task<ArticleDTO?> CreateArticleAsync(CreateArticleDTO createArticleDTO);
        Task<ArticleDTO> GetArticleByIdAsync(UpdateArticleDTO articleDTO);
        Task<ArticleDTO?> UpdateArticleAsync(UpdateArticleDTO updateArticleDTO);
        Task<bool> DeleteArticleAsync(int id);
    }
}