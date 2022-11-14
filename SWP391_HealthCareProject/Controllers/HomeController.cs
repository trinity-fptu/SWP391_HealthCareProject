using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;
using System.Diagnostics;
using SWP391_HealthCareProject.DataAccess;
using Microsoft.SqlServer.Management.Smo;
using NuGet.ContentModel;
using User = SWP391_HealthCareProject.Models.User;

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
                VolunteerDAO volunteerDAO = new VolunteerDAO();
                var volunteer = VolunteerDAO.GetVolunteerByUserId(userInfo.UserId);
                ViewBag.UserName = userInfo.UserName;
                ViewBag.UserId = userInfo.UserId;
                ViewBag.User = userInfo;
                ViewBag.Volunteer = volunteer;
            }
        }

        public IActionResult Index()
        {
            LoadSession();
            PostDAO postDAO = new PostDAO();
            CampaignDAO campaignDAO = new CampaignDAO();    
            VolunteerDAO volunteerDAO = new VolunteerDAO();
            PlanDAO planDAO = new PlanDAO();


            List<Post> postList = new List<Post>();
            postList = postDAO.getAllPost();
            List<Campaign> campaignList = new List<Campaign>();
            campaignList = campaignDAO.getAllCampaign();
            List<Volunteer> volunteerList = new List<Volunteer>();
            volunteerList = volunteerDAO.getAllVolunteer();
            List<Plan> planplist = new List<Plan>();
            planplist = planDAO.getAllPlan();

            List<User> userList = VolunteerDAO.getAllUser();
            HomeModels homeModels = new HomeModels();
            homeModels.PostViewModel = postList;
            homeModels.CampaignViewModel = campaignList; 
            homeModels.VolunteerViewModel = volunteerList;
            homeModels.PlanViewModel = planplist;
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
            HomeModels homeModels = new HomeModels();
            return View(homeModels);
        }

        public IActionResult PostList()
        {
            LoadSession();
            var postDao = new PostDAO();
            var pD = postDao.getAllPost();
            return View(pD);
        }

        public IActionResult SearchCampaign()
        {
            LoadSession();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}