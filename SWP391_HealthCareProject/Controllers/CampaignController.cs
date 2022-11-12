using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;
using SWP391_HealthCareProject.ViewModels;

namespace SWP391_HealthCareProject.Controllers
{
    public class CampaignController : Controller
    {
        public IActionResult Detail(int id)
        {
            var campaignDao = new CampaignDAO();
            var cD = campaignDao.getCampaignById(id);
            CampaignParticipationViewModel participateDetails = new CampaignParticipationViewModel()
            {
                Campaign = cD
            };
            return View(participateDetails);
        }

        

        [RequestAuthentication]
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult JoinCampaign(CampaignParticipationViewModel participateDetails)
        {
            var volunteer = HttpContext.Session.GetObjectFromJson<Volunteer>("Volunteer");
            participateDetails.Participate.VolunteerId = volunteer.VolunteerId;
            participateDetails.Participate.RegisteredDate = DateTime.Now;
            return View();
        }
        public IActionResult ErrorCampaign()
        {
            return View();
        }
        public ActionResult ShowSearch(DateTime date, string location)
        {
            var cD = new CampaignDAO();
            var model = cD.searchCampaign(date, location);
            if(model.Count==0) { return RedirectToAction("ErrorCampaign"); }
            else
            return View(model);
        }
    }
}