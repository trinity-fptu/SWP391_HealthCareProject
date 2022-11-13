using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    [RequestAuthentication]
    public class RHController : Controller
    {
        public void LoadSession()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
                ViewBag.User = userInfo;
            }
            
            PostDAO postDAO = new PostDAO();
            CampaignDAO campaignDAO = new CampaignDAO();

            List<Post> postList = new List<Post>();
            postList = postDAO.getAllPost();
            List<Campaign> campaignList = new List<Campaign>();
            campaignList = campaignDAO.getAllCampaign();

            HomeModels homeModels = new HomeModels();
            homeModels.PostViewModel = postList;
            homeModels.CampaignViewModel = campaignList;
            return View(homeModels);
        }


        public IActionResult Index()
        {
            LoadSession();
            return View();
        }

        public IActionResult ManagePost()
        {
            var hrAdminInfo = HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin");
            List<Post> posts = PostDAO.GetPostsByRHaid(hrAdminInfo.Rhaid);
            return View(posts);
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPost(Post post, IFormFile postImage)
        {
            var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
            HospitalRedCrossAdmin hrAd = HospitalRedCrossAdminDAO.GetHRAdrByUserId(userInfo.UserId);
            post.Rhaid = hrAd.Rhaid;
            // Save uploaded image.
            string path = @"wwwroot\assets\postImg";
            Post? lastPost = PostDAO.GetLastRecord();
            string savedName = $"PostPic{1}";
            if (lastPost != null)
            {
                savedName = $"PostPic{lastPost.PostId + 1}";
            }         
            string uploadFilepath = postImage.SaveUploadedFile(path, savedName);
            // Set filepath for Img attribute.
            post.Img = uploadFilepath;
            // Add post.
            PostDAO.AddPost(post);
            return RedirectToAction("ManagePost");
        }
        public IActionResult DeletePost(int postId)
        {
            PostDAO.DeletePostById(postId);
            return RedirectToAction("ManagePost");
        }

        public IActionResult ManageCampaign()
        {
            return View();
        }

        public IActionResult CreateCampaign()
        {
            var rhaInfo = HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin");
            var plans = PlanDAO.GetPlansByRHId(rhaInfo.Rhid);
            ViewBag.Plans = plans;
            return View();
        }
        public IActionResult StartCampaign(Campaign campaign, string selectedPlan)
        {
            TimeSpan duration = new TimeSpan(30, 0, 0, 0);
            if(DateTime.Compare(campaign.StartDate.Add(duration),campaign.EndDate) > 0)
            {
                ModelState.AddModelError("Date error", "End date must be at least 30 days after start date!");
                var rhaInfo = HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin");
                var plans = PlanDAO.GetPlansByRHId(rhaInfo.Rhid);
                ViewBag.Plans = plans;
                return View("CreateCampaign", campaign);
            }
            else
            {
                campaign.NumOfVolunteer = 0;
                string[] splittedPlan = selectedPlan.Split("_");
                int planId = int.Parse(splittedPlan[1]);
                campaign.PlanId = planId;
                CampaignDAO.AddCampaign(campaign);
                return RedirectToAction("ManageCampaign");
            }
            
        }

        public IActionResult ManagePlan()
        {
            return View();
        }

        public IActionResult CreatePlan()
        {
            return View();
        }

        public IActionResult ManageVolunteer()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
            var campaigns = RHDAO.getCampaignById(id.Value);
            if (campaigns == null)
            {
                return NotFound();
            }
            return View(campaigns);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Campaign campaign)
        {
            try
            {
                if (id != campaign.CampaignId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
                    RHDAO.updateCampaign(campaign);
                }
                return RedirectToAction("Index", "RH");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
    }
}