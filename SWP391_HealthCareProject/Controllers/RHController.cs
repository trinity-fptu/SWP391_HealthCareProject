using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class RHController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = HttpContext.Session.GetString("userName");
            return View();
        }

        public IActionResult ManagePost()
        {
            return View();
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        public IActionResult ManageCampaign()
        {
            return View();
        }

        public IActionResult CreateCampaign()
        {
            return View();
        }

        public IActionResult ManagePlan()
        {
            return View();
        }

        public IActionResult CreatePlan()
        {
            return View();
        }

        public IActionResult ManageUser()
        {
            return View();
        }

    }
}