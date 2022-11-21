using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;
using System.Net;
using System.Net.Mail;

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
            string path = @"~\postImg";
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
        public ActionResult EditPost(int? id)
        {
            LoadSession();
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO rhDao = new HospitalRedCrossDAO();
            var post = rhDao.GetPostById(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditPost(int id, Post post)
        {


            try
            {
                if (id != post.PostId)
                {
                    return NotFound();
                }

                HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
                RHDAO.UpdatePostById(post);

                return RedirectToAction("ManagePost");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        public ActionResult DeletePost(int? id)
        {
            LoadSession();
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
            var post = RHDAO.GetPostById(id.Value);
            if (post == null) { return NotFound(); }
            return View(post);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            try
            {

                HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
                RHDAO.deletePost(id);
                return RedirectToAction("ManagePost");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }

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
            if (DateTime.Compare(campaign.StartDate.Add(duration), campaign.EndDate) > 0)
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


                MailMessage mail = new MailMessage();
                    mail.To.Add("lnphuc2006@gmail.com");
                    mail.To.Add("machaidangms@gmail.com");
                    mail.To.Add("pain1601@gmail.com");
                mail.To.Add("nguyenvuongbach933@gmail.com");
                mail.From = new MailAddress("phamtuancuonghg@gmail.com");
                mail.Subject = "Blood Donor Campaign";
                mail.Body = $"Campaign {campaign.Name} Has started, join now! \n https://localhost:44327/Home/CampaignList";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.EnableSsl= true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("phamtuancuonghg@gmail.com", "evqrvqurandnfffo");
                smtp.Send(mail);


                return RedirectToAction("ManageCampaign");
            }

        }

        public IActionResult ListVolunteerInOneCampaign(int id)
        {
            LoadSession();
            ParticipateDAO participateModel = new ParticipateDAO();
            ViewBag.CampaignId = id;
            return View(participateModel);
        }

        public IActionResult CreateLocation(int id)
        {
            LoadSession();
            ParticipateDAO participateModel = new ParticipateDAO();
            ViewBag.CampaignId = id;
            return View(participateModel);
        }

        [HttpPost]
        public IActionResult CreateLocation(CampaignLocation cl)
        {
            CampaignLocationDAO.CreateLocation(cl);
            return RedirectToAction("Index", "RH");
        }

        public IActionResult ManagePlan()
        {
            LoadSession();
            PlanDAO planDAO = new PlanDAO();
            return View(planDAO);
        }

        public IActionResult CreatePlan()
        {
            LoadSession();
            Plan p = new Plan();
            return View(p);
        }

        [HttpPost]
        public IActionResult CreatePlan(Plan p)
        {

            var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
            HospitalRedCrossAdmin hra = HospitalRedCrossAdminDAO.GetHRAdrByUserId(userInfo.UserId);
            HospitalRedCross hr = HospitalRedCrossDAO.GetHRById(hra.Rhid);
            p.Rhid = hr.Rhid;
            PlanDAO.CreatePlan(p);
            return RedirectToAction("ManagePlan", "RH");
        }
        public ActionResult EditPlan(int? id)
        {
            LoadSession();
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
            var plan = RHDAO.GetPlansById(id.Value);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditPlan(int id, Plan plan)
        {


            try
            {
                if (id != plan.PlanId)
                {
                    return NotFound();
                }

                HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
                RHDAO.UpdatePlanById(plan);

                return RedirectToAction("ManagePlan", "RH");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        public ActionResult DeletePlan(int? id)
        {
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO hospitalRedCrossDAO = new HospitalRedCrossDAO();
            var plan = hospitalRedCrossDAO.GetPlansById(id.Value);
            if (plan == null) { return NotFound(); }
            return View(plan);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeletePlan(int id)
        {
            try
            {

                HospitalRedCrossDAO hospitalRedCrossDAO=new HospitalRedCrossDAO();
                hospitalRedCrossDAO.deletePlan(id);
                return RedirectToAction("ManagePlan");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }

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


        public IActionResult EndCampaign(int id)
        {
            Campaign campaign = CampaignDAO.getCampaignById(id);
            campaign.EndDate = DateTime.Now;
            campaign.Status = false;
            HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
            RHDAO.updateCampaign(campaign);
            return RedirectToAction("Index", "RH");
        }

        public ActionResult EditCampaign(int? id)
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
        public ActionResult EditCampaign(int id, Campaign campaign)
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
        public ActionResult DeleteCampaign(int? id)
        {
            LoadSession();
            if (id == null) { return NotFound(); }
            HospitalRedCrossDAO RHDAO = new HospitalRedCrossDAO();
            var campaign = RHDAO.getCampaignById(id.Value);
            if (campaign == null) { return NotFound(); }
            return View(campaign);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteCampaign(int id)
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