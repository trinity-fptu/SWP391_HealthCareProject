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
                //ViewBag.UserName = userInfo.UserName;
                //ViewBag.Email = userInfo.Email;
                //ViewBag.FirstName = volunteer.FirstName;
                //ViewBag.LastName = volunteer.LastName;
                //ViewBag.DOB = volunteer.Dob.ToString("yyyy-MM-dd");
                //ViewBag.Gender = volunteer.Gender;
                //ViewBag.BloodGroup = volunteer.BloodType;
                //ViewBag.Attend = volunteer.Attended;
                //ViewBag.IdCardNumber = volunteer.IdCardNumber;
                //ViewBag.Phone = volunteer.Phone;
                //ViewBag.Email = userInfo.Email;
                //ViewBag.Address = volunteer.Address;
                //ViewBag.City = volunteer.City;
                //ViewBag.Avatar = userInfo.Avatar;
                ViewBag.UserId = userInfo.UserId;
                ViewBag.VolunteerId = volunteer.VolunteerId;
            }
            return View(us);
        }

        [HttpPost]
        public IActionResult Edit(Volunteer volunteer)
        {
            volunteer.VolunteerId = VolunteerDAO.GetVolunteerByUserId(GetUserSession().UserId).VolunteerId;
            volunteer.UserId = GetUserSession().UserId;
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