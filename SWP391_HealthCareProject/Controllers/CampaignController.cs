using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;

namespace SWP391_HealthCareProject.Controllers
{
    public class CampaignController : Controller
    {
        public IActionResult Detail(int id)
        {
            var campaignDao = new CampaignDAO();
            var cD = campaignDao.getCampaignById(id);
            return View(cD);
        }

        [RequestAuthentication]
        public IActionResult HealthDeclare()
        {
            return View();
        }

        [RequestAuthentication]
        public IActionResult Appointment()
        {
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