using Business_Layer;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Repository.Model;

namespace StackOverflow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        private PostBL _postBL;

        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _postBL = new PostBL();
            _logger = logger;
        }

        [HttpGet("GetAllArticles")]
        public IEnumerable<Post> Get()
        {
            return _postBL.GetArticles();
        }

        // GET: Articles/{id}
        //[HttpGet("GetArticleById/{id}")]
        //public ActionResult<Article> GetArticalById(Guid id)
        //{
        //    var article = _articleBL.GetArticleById(id);
        //    if (article == null)
        //    {
        //        _logger.LogError($"GetArticleById endpoint failed on getting article id - {id} ");
        //        return NotFound();
        //    }
        //    return Ok(article);
        //}

        ////PUT: /Article/UpdateById/{id}
        //[HttpPut("UpdateById/{id}")]
        //public IActionResult UpdateById(Guid id, [FromBody] Article updateArticle)
        //{
        //    var updatedArticle = _articleBL.Update(id, updateArticle);
        //    if (updatedArticle == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(updatedArticle);
        //}

        //// DELETE: /Article/DeleteById/{id}
        //[HttpDelete("DeleteById/{id}")]
        //public IActionResult DeleteById(Guid id)
        //{
        //    if (_articleBL.RemoveById(id))
        //    {
        //        return NoContent();
        //    }
        //    return NotFound();
        //}

    }
}