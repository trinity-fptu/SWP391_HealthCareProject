using Microsoft.AspNetCore.Mvc;
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
            var cD = CampaignDAO.getCampaignById(id);
            CampaignParticipationViewModel participateDetails = new CampaignParticipationViewModel()
            {
                Campaign = cD
            };
            return View(participateDetails);
        }

        public IActionResult Register(CampaignParticipationViewModel participateDetails)
        {
            var locations = CampaignLocationDAO.GetLocationsByCampaignId(participateDetails.Campaign.CampaignId);
            participateDetails.CampaignLocations= locations;
            return View(participateDetails);
        }

        [RequestAuthentication]
        public IActionResult Appointment(CampaignParticipationViewModel participateDetails)
        {
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