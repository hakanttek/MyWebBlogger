using Microsoft.AspNetCore.Mvc;
using MyWebBlogger.Contracts.Application.Posts;
using MyWebBlogger.Application.Posts;

namespace MyWebBlogger.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IPostDto>>> Get()
        {
            var posts = await _postAppService.ReadAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IPostDto>> Get(int id)
        {
            var post = await _postAppService.ReadByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postId = await _postAppService.CreateAsync(postDto);
            return CreatedAtAction(nameof(Get), new { id = postId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _postAppService.UpdateByIdAsync(id, postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postAppService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
