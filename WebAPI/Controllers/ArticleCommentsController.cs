using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCommentsController : ControllerBase
    {
        private readonly IArticleCommentService _articleCommentService;

        public ArticleCommentsController(IArticleCommentService articleCommentService)
        {
            _articleCommentService = articleCommentService;
        }

        [HttpGet("getall")]

        public IActionResult GetArticleComments()
        {
            var result = _articleCommentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcommentbyid")]
        public IActionResult GetArticleCommentsByArticleId(int articleId)
        {
            var result = _articleCommentService.GetAllCommentDto(articleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(ArticleComment articleComment)
        {
            var result = _articleCommentService.Add(articleComment);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
