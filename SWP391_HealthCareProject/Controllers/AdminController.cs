using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (AdminDAO.IsUserExist(user.UserName))
                {
                    ModelState.AddModelError("Existed User", "Account already existed");

                }
                else if (ModelState.IsValid)
                {
                    AdminDAO adminDAO = new AdminDAO();
                    adminDAO.addUser(user);
                }
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                if (AdminDAO.IsUserExist(user.UserName))
                {
                    AdminDAO adminDAO = new AdminDAO();
                    adminDAO.deleteUser(user);
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("Delete Error","User does not exist!");
                return View("Admin", user);
            }
            catch (Exception ex) 
            { 
                ViewBag.message = ex.Message;
                return View();
            }

        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                AdminDAO adminDAO = new AdminDAO();
                adminDAO.updateUser(user);
                return RedirectToAction("Index", "Admin");
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
    }
}