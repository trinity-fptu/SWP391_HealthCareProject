using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class SignupController : Controller
    {


        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly BloodDonorContext _db;


        public SignupController(BloodDonorContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }

        public string UploadedFile(IFormFile File)
        {
            string uniqueFileName = null;
            if (File != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "assets/license");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult SignupRH()
        {
            return View();
        }

        public IActionResult Register(User user, Volunteer volunteer ,string confirmedPassword)
        {
            if (!SignupDAO.IsUserExist(user.UserName) && SignupDAO.CheckEmailPattern(user.Email) &&
                SignupDAO.CheckPasswordPattern(user.Password) && user.Password == confirmedPassword)
            {
                user.Role = 1;
                SignupDAO.Register(user);
                SignupDAO.RegisterVolunteer(volunteer, user);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (SignupDAO.IsUserExist(user.UserName))
                {
                    ModelState.AddModelError("Existed User", "Account already existed");
                }
                if (!SignupDAO.CheckEmailPattern(user.Email))
                {
                    ModelState.AddModelError("Email Error", "Invalid email");
                }
                if (!SignupDAO.CheckPasswordPattern(user.Password))
                {
                    ModelState.AddModelError("Password Error", "Invalid password");
                }
                if (user.Password != confirmedPassword)
                {
                    ModelState.AddModelError("Confirmed Error", "Confirmed password is not matched");
                }

                return View("Signup", user);
            }
        }

        public IActionResult RegisterRH(User user, string confirmedPassword, string hrAddress, string hrPhone, IFormFile File)
        {
            if (user.Password != confirmedPassword || SignupDAO.IsUserExist(user.UserName)
                || HospitalRedCrossDAO.GetHRByAddress(hrAddress) == null)
            {
                if (HospitalRedCrossDAO.GetHRByAddress(hrAddress) == null)
                {
                    ModelState.AddModelError("HR error", "Hospital/Redcross doesn't exist");
                }

                if (user.Password != confirmedPassword)
                {
                    ModelState.AddModelError("Confirmed password error", "Password and Confirmed Password is not matched");
                }
                if (SignupDAO.IsUserExist(user.UserName))
                {
                    ModelState.AddModelError("Existed User", "Account already existed");
                }
                return View("SignupRH", user);
            }
            user.Role = 2;
            SignupDAO.Register(user);
            User newUser = LoginDAO.Login(user.UserName, user.Password);
            HospitalRedCrossAdmin hrAdmin = new HospitalRedCrossAdmin();
            HospitalRedCross hr = HospitalRedCrossDAO.GetHRByAddress(hrAddress);
            hrAdmin.UserId = newUser.UserId;
            hrAdmin.Rhid = hr.Rhid;
            hrAdmin.FirstName = ".";
            hrAdmin.LastName= ".";
            string uniqueName = UploadedFile(File);
            hrAdmin.License = uniqueName;
            HospitalRedCrossAdminDAO.CreateHRAdmin(hrAdmin);
            return RedirectToAction("Index", "Login");
        }
    }
}