using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;
using SWP391_HealthCareProject.ViewModels;

namespace SWP391_HealthCareProject.Controllers
{
    public class CampaignController : Controller
    {

        public void LoadSession()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                ViewBag.UserName = userInfo.UserName;
                ViewBag.UserId = userInfo.UserId;
                ViewBag.User = userInfo;
            }
        }
        public IActionResult Detail(int id)
        {
            LoadSession();
            var cD = CampaignDAO.getCampaignById(id);
            CampaignParticipationViewModel participateDetails = new CampaignParticipationViewModel()
            {
                Campaign = cD
            };
            return View(participateDetails);
        }


        [RequestAuthentication]
        public IActionResult Register(int id)
        {
            LoadSession();
            var locations = CampaignLocationDAO.GetLocationsByCampaignId(id);
            CampaignParticipationViewModel participateDetails = new CampaignParticipationViewModel();
            ViewBag.CampaignId = id;
            participateDetails.CampaignLocations = locations;
            return View(participateDetails);
        }

        public IActionResult ErrorCampaign()
        {
            LoadSession();
            return View();
        }
        public ActionResult ShowSearch(DateTime date, string location)
        {
            LoadSession();
            var model = CampaignDAO.searchCampaign(date, location);
            if (model.Count == 0) { return RedirectToAction("ErrorCampaign"); }
            else
                return View(model);
        }

        [RequestAuthentication]
        public IActionResult Appointment(CampaignParticipationViewModel participateDetails)
        {
            LoadSession();
            var cD = CampaignDAO.getCampaignById(participateDetails.Participate.CampaignId);
            var volunteer = HttpContext.Session.GetObjectFromJson<Volunteer>("Volunteer");
            participateDetails.Campaign = cD;
            participateDetails.Participate.VolunteerId = volunteer.VolunteerId;
            participateDetails.Participate.RegisteredDate = DateTime.Now;
            ParticipateDAO.AddParticipate(participateDetails.Participate);
            CampaignDAO.UpdateCampaign(participateDetails.Participate.CampaignId);
            ViewBag.Volunteer = volunteer;
            return View(participateDetails);
        }


    }
}