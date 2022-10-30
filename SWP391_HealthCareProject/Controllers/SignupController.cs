using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Register(User user)
        {
            if (LoginDAO.IsUserExist(user.UserName))
            {
                ModelState.AddModelError("Existed User", "Account already existed");
                return View("Signup", user);
            }
            LoginDAO.Register(user);
            return RedirectToAction("Index", "Login");
        }
    }
}
