using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Smo;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using User = SWP391_HealthCareProject.Models.User;

namespace SWP391_HealthCareProject.Controllers
{
    [RequestAuthentication]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly BloodDonorContext _db;

        public UserController(BloodDonorContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }

        public string UploadedFile(User user)
        {
            string uniqueFileName = null;
            if(user.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "assets/userAvatar");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    user.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


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


        public IActionResult RegisteredCampaign()
        {
            UserProfileModels us = new UserProfileModels();
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
        public IActionResult ChangePassword(string oldPwd, string newPwd)
        {
            bool isUpdated;
            User user = GetUserSession();
            if (UserProfileModels.CheckPasswordPattern(newPwd) && oldPwd == newPwd)
            {
                user.Password = newPwd;
                VolunteerDAO volunteerDAO = new VolunteerDAO();
                volunteerDAO.updateUser(user);
                isUpdated = true;
                ViewBag.Updated = isUpdated; 
                return RedirectToAction("UserProfile", "User");
            }
            isUpdated = false;
            ViewBag.Updated = isUpdated;
            return RedirectToAction("UserProfile", "User");
        }


        [HttpPost]
        public IActionResult EditUser(User user)
        {
            User u = GetUserSession();
            user.UserId = u.UserId;
            user.Password = u.Password;
            user.Role = u.Role;
            user.CreatedDate = u.CreatedDate;
            Console.WriteLine(user.UserId + user.UserName + user.Role + user.Avatar + user.Email);
            VolunteerDAO volunteerDAO = new VolunteerDAO();
            string uniqueFileName = UploadedFile(user);
            user.Avatar = uniqueFileName;
            if (user.Avatar == null)
            {
                user.Avatar = u.Avatar;
            }
            volunteerDAO.updateUser(user);
            
            return RedirectToAction("UserProfile", "User");
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


        [HttpPost]
        public IActionResult EditUserRH(User user)
        {
            User u = GetUserSession();
            user.UserId = u.UserId;
            user.Password = u.Password;
            user.Role = u.Role;
            user.CreatedDate = u.CreatedDate;
            Console.WriteLine(user.UserId + user.UserName + user.Role + user.Avatar + user.Email);
            VolunteerDAO volunteerDAO = new VolunteerDAO();
            string uniqueFileName = UploadedFile(user);
            user.Avatar = uniqueFileName;
            if (user.Avatar == null)
            {
                user.Avatar = u.Avatar;
            }
            volunteerDAO.updateUser(user);

            return RedirectToAction("RHProfile", "User");
        }

        [HttpPost]
        public IActionResult EditRH(HospitalRedCross HR)
        {
            User u = GetUserSession();
            HospitalRedCrossAdmin hra = HospitalRedCrossAdminDAO.GetHRAdrByUserId(u.UserId);
            HospitalRedCross oldHR = HospitalRedCrossDAO.GetHRById(hra.Rhid);
            HR.Rhid = oldHR.Rhid;
            Console.WriteLine($"{HR.Rhid} {HR.Name}");
            HospitalRedCrossDAO.UpdateHR(HR);
            return RedirectToAction("RHProfile", "User");
        }

        public IActionResult RHProfile()
        {
            User u = GetUserSession();
            UserProfileModels us = new UserProfileModels();
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.User = u;
            return View(us);
        }
    }
}