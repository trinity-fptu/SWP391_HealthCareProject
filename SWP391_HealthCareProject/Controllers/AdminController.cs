using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = HttpContext.Session.GetString("userName");
            return View();
        }
    }
}