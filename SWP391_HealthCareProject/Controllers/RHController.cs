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
        }


        public IActionResult Index()
        {
            LoadSession();
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

        public IActionResult ManagePost()
        {
            LoadSession();
            PostDAO postDAO = new PostDAO();
            List<Post> posts = postDAO.getAllPost();
            return View(posts);
        }

        public IActionResult CreatePost()
        {
            LoadSession();
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
            LoadSession();
            ParticipateDAO participateModel = new ParticipateDAO();
            return View(participateModel);
        }

        public IActionResult CreateCampaign()
        {
            LoadSession();
            var rhaInfo = HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin");
            var plans = PlanDAO.GetPlansByRHId(rhaInfo.Rhid);
            ViewBag.Plans = plans;
            return View();
        }
        public IActionResult StartCampaign(Campaign campaign, string selectedPlan)
        {
            LoadSession();
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
            LoadSession();
            return View();
        }

        public IActionResult CreatePlan()
        {
            LoadSession();
            return View();
        }

        public IActionResult ManageVolunteer(int id)
        {
            LoadSession();
            ParticipateDAO participateDAO = new ParticipateDAO();
            Volunteer volunteer = participateDAO.GetVolunteerById(id);
            VolunteerDAO volunteerDAO = new VolunteerDAO();
            var user = volunteerDAO.getUserById(volunteer.UserId);
            ViewBag.User = user;
            return View(volunteer);
        }
        public ActionResult Edit(int? id)
        {
            LoadSession();
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
                
                    HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
                    RHDAO.updateCampaign(campaign);
                
                return RedirectToAction("Index", "RH");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        public ActionResult Delete(int? id)
        {
            LoadSession();
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
            var campaign = RHDAO.getCampaignById(id.Value);
            if (campaign == null) { return NotFound(); }
            return View(campaign);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            try
            {

                HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
                RHDAO.deleteCampaign(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }

        }
    }
}