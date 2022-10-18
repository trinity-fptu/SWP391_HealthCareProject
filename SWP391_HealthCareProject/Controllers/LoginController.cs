using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
