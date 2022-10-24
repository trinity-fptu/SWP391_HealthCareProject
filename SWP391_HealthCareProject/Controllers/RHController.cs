using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class RHController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
