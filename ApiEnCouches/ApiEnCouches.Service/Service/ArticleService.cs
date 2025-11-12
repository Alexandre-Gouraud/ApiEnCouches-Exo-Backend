namespace ApiEnCouches.Service.Service
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using ApiEnCouches.DataAccess.IDataAccess;
    using ApiEnCouches.DataAccess.Entity;
    using ApiEnCouches.Service.IService;
    using ApiEnCouches.Service.DataTransferObject;

    public class ArticleService : IArticleService
    {
        private readonly IArticleDataAccess _articleDataAccess;

        public ArticleService(IArticleDataAccess articleDataAccess)
        {
            _articleDataAccess = articleDataAccess;
        }

        // Mapping helper (Entity -> DTO)
        private static ArticleDTO ToDto(Article entity)
        {
            return new ArticleDTO
            {
                Id = entity.Id,
                Title = entity.Title ?? string.Empty,
                Content = entity.Content ?? string.Empty,
            };
        }

        public async Task<IList<ArticleDTO>> GetAllAsync()
        {
            var entities = await _articleDataAccess.GetAllAsync();
            return entities.Select(ToDto).ToList();
        }

        public async Task<ArticleDTO?> GetByIdAsync(int id)
        {
            var entity = await _articleDataAccess.GetByIdAsync(id);
            if (entity == null) return null;
            return ToDto(entity);
        }

        public async Task<ArticleDTO> CreateAsync(CreateArticleDTO createDto)
        {
            var entity = new Article
            {
                Title = createDto.Title,
                Content = createDto.Content,
            };

            var created = await _articleDataAccess.CreateAsync(entity);

            return ToDto(created);
        }

        public async Task<ArticleDTO?> UpdateAsync(UpdateArticleDTO updateDto)
        {
            var existing = await _articleDataAccess.GetByIdAsync(updateDto.Id);
            if (existing == null) return null;

            // Mettre à jour uniquement si non null (support pour partial update)
            if (updateDto.Title is not null) existing.Title = updateDto.Title;
            if (updateDto.Content is not null) existing.Content = updateDto.Content;

            var updated = await _articleDataAccess.UpdateAsync(existing);
            return ToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _articleDataAccess.GetByIdAsync(id);
            if (existing == null) return false;

            await _articleDataAccess.DeleteAsync(id);
            return true;
        }
    }
}