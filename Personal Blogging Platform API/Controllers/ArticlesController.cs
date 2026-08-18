using Blog.Application.DTOs;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

  
        [HttpGet]
        public async Task<ActionResult<List<ArticleDTO>>> GetAll()
        {
            var articles = await _articleService.GetAllAsync();

            return Ok(articles);
        }

   
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArticleDTO>> GetById(int id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article == null)
                return NotFound();

            return Ok(article);
        }


        [HttpPost]
        public async Task<ActionResult> Create(
            CreateArticleDTO dto)
        {
            var articleId = await _articleService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = articleId },
                new { ArticleId = articleId });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(
            int id,
            UpdateArticleDTO dto)
        {
            var updated = await _articleService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _articleService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}