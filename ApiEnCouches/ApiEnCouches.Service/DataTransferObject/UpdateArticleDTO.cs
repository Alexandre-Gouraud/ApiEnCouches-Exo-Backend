// ApiEnCouches.Service/DataTransferObject/UpdateArticleDTO.cs
namespace ApiEnCouches.Service.DataTransferObject
{
    public class UpdateArticleDTO
    {
        // Id requis pour identifier l'article à mettre à jour
        public int Id { get; set; }

        // Champs modifiables
        public string? Title { get; set; }
        public string? Content { get; set; }

        // Si tu veux partiels : laisse les propriétés nullable et ne mets à jour que celles non-nulles.
    }
}
