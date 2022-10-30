using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.Models;
using System.Diagnostics;

namespace SWP391_HealthCareProject.Controllers
{
    public class RHController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
            }
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