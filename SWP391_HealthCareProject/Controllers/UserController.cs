using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    [RequestAuthentication]
    public class UserController : Controller
    {

        public User? GetUserSession()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                return userInfo;
            }
            return null;
        }

        public IActionResult UserProfile()
        {
            List<User> userModel = new List<User>();
            userModel = VolunteerDAO.getAllUser();
            List<Volunteer> volunteerList = new List<Volunteer>();
            VolunteerDAO vDao = new VolunteerDAO();
            volunteerList = vDao.getAllVolunteer();
            UserProfileModels us = new UserProfileModels();
            us.UserViewModel = userModel;
            us.VolunteerViewModel = volunteerList;

            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                var volunteer = VolunteerDAO.GetVolunteerByUserId(userInfo.UserId);
                string fullName = volunteer.LastName + " " + volunteer.FirstName;
                ViewBag.FullName = fullName;
                ViewBag.UserId = userInfo.UserId;
                ViewBag.VolunteerId = volunteer.VolunteerId;
            }
            return View(us);
        }

        [HttpPost]
        public IActionResult Edit(Volunteer volunteer, int attended)
        {
            Volunteer v = VolunteerDAO.GetVolunteerByUserId(GetUserSession().UserId);
            volunteer.VolunteerId = VolunteerDAO.GetVolunteerByUserId(GetUserSession().UserId).VolunteerId;
            volunteer.UserId = GetUserSession().UserId;
            if (attended == 0)
            {
                volunteer.Attended = v.Attended;

            }
            if (volunteer == null)
            {
                return NotFound();
            }
            else
            {
                VolunteerDAO volunteerdao = new VolunteerDAO();
                volunteerdao.updateVolunteer(volunteer);
            }
            return RedirectToAction("UserProfile", "User");
        }


        public IActionResult RHProfile()
        {
            return View();
        }
    }
}