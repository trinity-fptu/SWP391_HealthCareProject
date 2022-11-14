using SWP391_HealthCareProject.Models;

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

        public static void CreatePlan(Plan plan)
        {
            using var db = new BloodDonorContext();
            db.Plans.Add(plan);
            db.SaveChanges();
        }

        public Plan GetPlansById(int planId)
        {
            using var db = new BloodDonorContext();
            var plan = db.Plans.Find(planId);
            return plan;
        }
        public List<Plan> getAllPlan()
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Plans
                      select item).ToList();
            return us;
        }
    }
}
