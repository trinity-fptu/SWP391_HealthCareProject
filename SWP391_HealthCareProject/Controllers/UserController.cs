using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                if (HttpContext.Session.GetObjectFromJson<Volunteer>("Volunteer") != null)
                {
                    var volunteerInfo = HttpContext.Session.GetObjectFromJson<Volunteer>("Volunteer");
                    string fullName = volunteerInfo.LastName + " " + volunteerInfo.FirstName;
                    ViewBag.FullName = fullName;
                }
                else if (HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin") != null)
                {
                    var hrAdminInfo = HttpContext.Session.GetObjectFromJson<Volunteer>("HRAdmin");
                    string fullName = hrAdminInfo.LastName + " " + hrAdminInfo.FirstName;
                    ViewBag.FullName = fullName;
                }
                ViewBag.UserName = userInfo.UserName;
                ViewBag.Email = userInfo.Email;
            }
            
            return View();
        }
    }
}
