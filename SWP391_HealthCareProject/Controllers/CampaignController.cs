﻿using Microsoft.AspNetCore.Mvc;

namespace SWP391_HealthCareProject.Controllers
{
    public class CampaignController : Controller
    {
        public IActionResult Detail()
        {
            return View();
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