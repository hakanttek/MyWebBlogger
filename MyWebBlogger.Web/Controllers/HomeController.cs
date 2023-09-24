using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebBlogger.Contracts.Application.Posts;
using MyWebBlogger.Contracts.Application.Projects;
using MyWebBlogger.Web.Models;  
using MyWebBlogger.Web.Models.Home;
using System.Diagnostics;

namespace MyWebBlogger.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostAppService _postAppService;
        private readonly IProjectAppService _projectAppService;

        public HomeController(ILogger<HomeController> logger, IPostAppService postAppService, IProjectAppService projectAppService)
        {
            _logger = logger;
            _postAppService = postAppService;
            _projectAppService = projectAppService;
            ViewBag.HomeModel = HomeModel.DEFAULT;
        }

        [Route("~/")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("project")]
        public async Task<IActionResult> Projects()
        {
            var projects = await _projectAppService.ReadAllAsync();
            return View(projects);
        }

        [Route("post")]
        public async Task<IActionResult> Post()
        {
            var posts = await _postAppService.ReadAllAsync();
            return View(posts);
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int status)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}