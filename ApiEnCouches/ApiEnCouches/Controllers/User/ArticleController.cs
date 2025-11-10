namespace ApiEnCouches.Controllers.User
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly Service.IService.IArticleService _articleService;

        public ArticleController(Service.IService.IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("add")]
        public IActionResult AddArticle([FromBody] Models.ArticleModel article)
        {
            _articleService.AddArticle(article.Title, article.Content);
            return Ok();
        }

    }
}