using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.XEvent;
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
        public IActionResult Validate(Models.User obj)
        {
            var user = LoginDAO.Login(obj.UserName, obj.Password);
            if (user != null)
            {
                HttpContext.Session.SetString("userName", user.UserName);
                if (user.Role == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user.Role == 2)
                {
                    return RedirectToAction("Index", "RH");
                }
                else return RedirectToAction("Index", "Admin");

            }
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}