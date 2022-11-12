using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
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

        public void LoadSession()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                ViewBag.UserName = userInfo.UserName;
                ViewBag.UserId = userInfo.UserId;
                ViewBag.Avatar = userInfo.Avatar;
            }
        }

        public IActionResult Index()
        {
            LoadSession();
            PostDAO postDAO = new PostDAO();
            CampaignDAO campaignDAO = new CampaignDAO();    
            VolunteerDAO volunteerDAO = new VolunteerDAO();


            List<Post> postList = new List<Post>();
            postList = postDAO.getAllPost();
            List<Campaign> campaignList = new List<Campaign>();
            campaignList = campaignDAO.getAllCampaign();
            List<Volunteer> volunteerList = new List<Volunteer>();
            volunteerList = volunteerDAO.getAllVolunteer();
            List<User> userList = VolunteerDAO.getAllUser();

            HomeModels homeModels = new HomeModels();
            homeModels.PostViewModel = postList;
            homeModels.CampaignViewModel = campaignList; 
            homeModels.VolunteerViewModel = volunteerList;
            homeModels.UserViewModel = userList;
            return View(homeModels);
        }
 
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CampaignList()
        {
            LoadSession();
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