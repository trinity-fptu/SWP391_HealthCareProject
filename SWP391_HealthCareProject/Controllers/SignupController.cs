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

        public IActionResult SignupRH()
        {
            return View();
        }

        public IActionResult Register(User user, string confirmedPassword)
        {
            if(user.Password != confirmedPassword || LoginDAO.IsUserExist(user.UserName))
            {
                if(user.Password != confirmedPassword)
                {
                    ModelState.AddModelError("Confirmed password error", "Password and Confirmed Password is not matched");
                }
                if (LoginDAO.IsUserExist(user.UserName))
                {
                    ModelState.AddModelError("Existed User", "Account already existed");
                    
                }
                return View("Signup", user);
            }
            LoginDAO.Register(user);
            return RedirectToAction("Index", "Login");
        }
    }
}
