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
    }
}