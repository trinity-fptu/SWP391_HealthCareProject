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

        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
            }
            PostDAO postDAO = new PostDAO();
            CampaignDAO campaignDAO = new CampaignDAO();    
            VolunteerDAO volunteerDAO = new VolunteerDAO();

            List<Post> postList = new List<Post>();
            postList = postDAO.getAllPost();
            List<Campaign> campaignList = new List<Campaign>();
            campaignList = campaignDAO.getAllCampaign();
            List<Volunteer> volunteerList = new List<Volunteer>();
            volunteerList = volunteerDAO.getAllVolunteer();

            HomeModels homeModels = new HomeModels();
            homeModels.PostViewModel = postList;
            homeModels.CampaignViewModel = campaignList; 
            homeModels.VolunteerViewModel = volunteerList;
            return View(homeModels);
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