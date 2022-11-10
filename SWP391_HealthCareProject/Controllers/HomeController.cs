using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;
using System.Diagnostics;
using static SWP391_HealthCareProject.DataAccess.HomeDAO;

namespace SWP391_HealthCareProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
            }
            View3 view = new View3();
            PostDAO postDao = new PostDAO();
            CampaignDAO campaignDAO = new CampaignDAO();

            view.post = postDao.getPostById(id);
            view.campaigns = campaignDAO.getCampaignById(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CampaignList()
        {
            var camDao = new CampaignDAO();
            var cD = camDao.getAllCampaign();
            return View(cD);
        }

        public IActionResult PostList()
        {
            var postDao = new PostDAO();
            var pD = postDao.getAllPost();
            return View(pD);
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