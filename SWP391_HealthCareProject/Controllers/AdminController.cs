using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var ad = new AdminDAO();
            var userList = ad.getAllUser();
            ViewBag.name = HttpContext.Session.GetString("userName");
            return View();
        }
    }
}
