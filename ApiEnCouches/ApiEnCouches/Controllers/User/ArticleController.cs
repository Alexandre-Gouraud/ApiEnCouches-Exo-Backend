namespace ApiEnCouches.Controllers.User
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleService.GetAllAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            if (article == null) return NotFound();
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArticleDTO createDto)
        {
            if (createDto == null) return BadRequest();
            var created = await _articleService.CreateAsync(createDto);
            // retourne 201 Created avec route vers la ressource
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateArticleDTO updateDto)
        {
            if (updateDto == null) return BadRequest();
            if (id != updateDto.Id) return BadRequest("Id in route and payload must match.");
            var updated = await _articleService.UpdateAsync(updateDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _articleService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}