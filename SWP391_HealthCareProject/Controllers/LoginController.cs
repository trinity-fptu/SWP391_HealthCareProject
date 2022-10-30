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
        public IActionResult Validate(Models.User obj)
        {
            HttpContext.Session.Clear();
            var user = LoginDAO.Login(obj.UserName, obj.Password);
            if (user != null)
            {
                HttpContext.Session.SetObjectAsJson("User", user);
                if (user.Role == 1)
                {
                    var volunteer = VolunteerDAO.GetVolunteerByUserId(user.UserId);
                    HttpContext.Session.SetObjectAsJson("Volunteer", volunteer);
                    return RedirectToAction("Index", "Home");
                }
                else if (user.Role == 2)
                {
                    var HRAdmin = HospitalRedCrossAdminDAO.GetHRAdrByUserId(user.UserId);
                    HttpContext.Session.SetObjectAsJson("HRAdmin", HRAdmin);
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