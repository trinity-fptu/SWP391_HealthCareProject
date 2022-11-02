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
            return View(userList);
        }
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View(user);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            AdminDAO ad = new AdminDAO();
            var user = ad.getUserById(id.Value);
            if(user == null) { return NotFound(); }
            return View(user);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                
                AdminDAO adminDAO = new AdminDAO();
                adminDAO.deleteUser(id);
                return RedirectToAction(nameof(Index));    
            }
            catch (Exception ex) 
            { 
                ViewBag.message = ex.Message;
                return View();
            }

        }
        //Get: Edit
        public ActionResult Edit(int? id)
        {
            if(id == null) { return NotFound(); }
            AdminDAO adminDAO=new AdminDAO();
            var user = adminDAO.getUserById(id.Value);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id,User user)
        {
            try
            {
                if(id != user.UserId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    AdminDAO adminDAO = new AdminDAO();
                    adminDAO.updateUser(user);
                }
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