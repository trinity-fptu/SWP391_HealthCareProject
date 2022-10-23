using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class User : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
