using System.Net.Mail;
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
            if (LoginDAO.CheckEmailPattern(user.Email) && LoginDAO.CheckPasswordPattern(user.Password) && user.Password == confirmedPassword)
            {
                //if (user.Password != confirmedPassword || LoginDAO.IsUserExist(user.UserName))
                //{
                //    if (user.Password != confirmedPassword)
                //    {
                //        ModelState.AddModelError("Confirmed password error", "Password and Confirmed Password is not matched");
                //    }
                //    if (LoginDAO.IsUserExist(user.UserName))
                //    {
                //        ModelState.AddModelError("Existed User", "Account already existed");
                //    }
                //    return View("Signup", user);
                //}
                //user.Role = 1;
                //LoginDAO.Register(user);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Message = "Invalid email or password";
                return View("Signup");
            }
        }

        public IActionResult RegisterRH(User user, string confirmedPassword, string hrAddress, string hrPhone)
        {
            if (user.Password != confirmedPassword || LoginDAO.IsUserExist(user.UserName)
                || HospitalRedCrossDAO.GetHRByAddress(hrAddress) == null)
            {
                if (HospitalRedCrossDAO.GetHRByAddress(hrAddress) == null)
                {
                    ModelState.AddModelError("HR error", "Hospital/Redcross doesn't exist");
                }

                if (user.Password != confirmedPassword)
                {
                    ModelState.AddModelError("Confirmed password error", "Password and Confirmed Password is not matched");
                }
                if (LoginDAO.IsUserExist(user.UserName))
                {
                    ModelState.AddModelError("Existed User", "Account already existed");
                }
                return View("SignupRH", user);
            }
            user.Role = 2;
            LoginDAO.Register(user);
            User newUser = LoginDAO.Login(user.UserName, user.Password);
            HospitalRedCrossAdminDAO.CreateHRAdmin(newUser, hrAddress, hrPhone);
            return RedirectToAction("Index", "Login");
        }
    }
}