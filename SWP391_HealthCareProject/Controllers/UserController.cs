using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    [RequestAuthentication]
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                string fullName = null;
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                var volunteerInfo = userInfo.Volunteers.Where(x=>x.UserId==userInfo.UserId).FirstOrDefault();
                ViewBag.FullName = $"{volunteerInfo.LastName} {volunteerInfo.FirstName}";
                ViewBag.UserName = userInfo.UserName;
                ViewBag.Email = userInfo.Email;
            }
            return View();
        }

        public IActionResult RHProfile()
        {
            return View();
        }
    }
}