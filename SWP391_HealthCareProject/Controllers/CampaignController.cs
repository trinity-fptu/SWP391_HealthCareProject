using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;

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

        public IActionResult HealthDeclare()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }
    }
}