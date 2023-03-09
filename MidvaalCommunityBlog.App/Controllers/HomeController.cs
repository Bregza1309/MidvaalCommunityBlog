using Microsoft.AspNetCore.Mvc;
using MidvaalCommunityBlog.App.Models;
using System.Diagnostics;
using MidvaalCommunityBlog.Common.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MidvaalCommunityBlog.App.Models.ViewModels;
namespace MidvaalCommunityBlog.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBlogRepository repo;
        private UserManager<User> UserManager;
        public HomeController(ILogger<HomeController> logger,McbDb db, IBlogRepository repo ,UserManager<User> userService)
        {
            _logger = logger;
            this.repo = repo;
            this.UserManager = userService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index(string ? category)
        {
            ViewData["Tag"] = category;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string ? category , Post post)
        {
            if (ModelState.IsValid)
            {
                await repo.CreatePost(post);
                Redirect($"/?{category}");
            }
            return View(post);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Users()
        {
            
            return View(UserManager.Users);
        }
        

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}