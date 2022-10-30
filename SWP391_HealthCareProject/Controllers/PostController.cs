using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}