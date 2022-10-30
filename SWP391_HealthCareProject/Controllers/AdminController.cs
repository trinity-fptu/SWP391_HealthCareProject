using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var ad = new AdminDAO();
            var userList = ad.getAllUser();
            ViewBag.name = HttpContext.Session.GetString("userName");
            return View();
        }
        //Get
        public ActionResult Create() => View();
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AdminDAO adminDAO = new AdminDAO();
                    adminDAO.addUser(user);
                }
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View(user);
            }
        }

    }
}
