using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validate(string userName, string userPassword)
        {
            var user = LoginDAO.Login(userName, userPassword);
            if (user != null)
            {
                HttpContext.Session.SetString("userName", user.UserName);
                HttpContext.Session.SetString("userPassword", user.Password);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}