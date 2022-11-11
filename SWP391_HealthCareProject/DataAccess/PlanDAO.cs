﻿using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class PlanDAO
    {
        public static List<Plan> GetPlansByRHId(int rhId)
        {
            using var db = new BloodDonorContext();
            var plans = db.Plans.Where(p => p.Rhid == rhId).ToList();
            return plans;
        }
        public static Plan GetPlansById(int planId)
        {
            using var db = new BloodDonorContext();
            var plan = db.Plans.Find(planId);
            return plan;
        }
    }
}