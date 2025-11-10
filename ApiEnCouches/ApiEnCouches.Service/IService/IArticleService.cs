namespace ApiEnCouches.Service.IService
{
    using ApiEnCouches.Service.DataTransferObject;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        // New API matching the service implementation and controller usage
        Task<IList<ArticleDTO>> GetAllAsync();
        Task<ArticleDTO?> GetByIdAsync(int id);
        Task<ArticleDTO> CreateAsync(CreateArticleDTO createDto);
        Task<ArticleDTO?> UpdateAsync(UpdateArticleDTO updateDto);
        Task<bool> DeleteAsync(int id);

    // (Removed older/alternate names to match current implementation)
    }
}