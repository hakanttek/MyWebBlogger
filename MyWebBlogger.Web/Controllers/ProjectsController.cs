using Microsoft.AspNetCore.Mvc;
using MyWebBlogger.Contracts.Application.Projects;
using MyWebBlogger.Application.Projects;

namespace MyWebBlogger.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectsController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IProjectDto>>> Get()
        {
            var projects = await _projectAppService.ReadAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IProjectDto>> Get(int id)
        {
            var project = await _projectAppService.ReadByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectId = await _projectAppService.CreateAsync(projectDto);
            return CreatedAtAction(nameof(Get), new { id = projectId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectAppService.UpdateByIdAsync(id, projectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectAppService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}