using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.Models;
using System.Diagnostics;
using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
            }
            HomeDAO dao = new HomeDAO();
            List<Post> listPost = dao.getPostDetail();
            ViewBag.Post = new Post();
            foreach (var item in listPost)
            {
                ViewBag.Post.Img = item.Img;
                ViewBag.Post.Title = item.Title;
                ViewBag.Post.Description = item.Description;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CampaignList()
        {
            return View();
        }

        public IActionResult PostList()
        {
            return View();
        }

        public IActionResult SearchCampaign()
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