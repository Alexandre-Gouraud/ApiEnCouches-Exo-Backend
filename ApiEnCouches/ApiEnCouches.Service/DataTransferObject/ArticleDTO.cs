// ApiEnCouches.Service/DataTransferObject/ArticleDTO.cs
namespace ApiEnCouches.Service.DataTransferObject
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        // public DateTime CreatedAt { get; set; }    si ton entity a une date
        // public DateTime? UpdatedAt { get; set; }   si présent
    }
}
