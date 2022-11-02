using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    public class RHController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
            }
            return View();
        }

        public IActionResult ManagePost()
        {
            return View();
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPost(Post post, IFormFile postImage)
        {
            try
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                HospitalRedCrossAdmin hrAd = HospitalRedCrossAdminDAO.GetHRAdrByUserId(userInfo.UserId);
                post.Rhaid = hrAd.Rhaid;
                string imgExtension = postImage.FileName.Substring(postImage.FileName.IndexOf('.') + 1);
                int lastPostId = PostDAO.GetLastRecord().PostId;
                string savedName = $"PostPic{lastPostId + 1}.{imgExtension}";
                savedName = Path.GetFileName(savedName);
                string uploadFilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\postImg", savedName);
                using (var stream = new FileStream(uploadFilepath, FileMode.Create))
                {
                    postImage.CopyTo(stream);
                }
                post.Img = uploadFilepath;
                PostDAO.AddPost(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("ManagePost");
        }

        public IActionResult ManageCampaign()
        {
            return View();
        }

        public IActionResult CreateCampaign()
        {
            return View();
        }

        public IActionResult ManagePlan()
        {
            return View();
        }

        public IActionResult CreatePlan()
        {
            return View();
        }

        public IActionResult ManageUser()
        {
            return View();
        }
    }
}