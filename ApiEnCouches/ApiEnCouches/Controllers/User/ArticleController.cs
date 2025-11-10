namespace ApiEnCouches.Controllers.User
{
    using Microsoft.AspNetCore.Mvc;
    using ApiEnCouches.Service.IService;
    using ApiEnCouches.Service.DataTransferObject;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("add")]
        public IActionResult AddArticle([FromBody] CreateArticleDTO article)
        {
            if (article == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(article.Title) || string.IsNullOrWhiteSpace(article.Content))
            {
                return BadRequest("Title and Content are required.");
            }

            _articleService.AddArticle(article.Title!, article.Content!);
            return Ok();
        }

    }
}