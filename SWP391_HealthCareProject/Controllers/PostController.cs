using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class PostController : Controller
    {
        public void LoadSession()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                ViewBag.UserName = userInfo.UserName;
                ViewBag.UserId = userInfo.UserId;
                ViewBag.User = userInfo;
                ViewBag.Volunteer = VolunteerDAO.GetVolunteerByUserId(userInfo.UserId);
            }
        }

        public IActionResult Index(int id)
        {
            LoadSession();
            var pD = new PostDAO();
            var p = pD.getPostById(id);
            return View(p);
        }
       
       
    }
}