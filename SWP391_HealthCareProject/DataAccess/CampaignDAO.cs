using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class CampaignDAO
    {
        public static void AddCampaign(Campaign campaign)
        {
            Console.WriteLine($"Name: {campaign.Name}, Num: {campaign.NumOfVolunteer}, {campaign.StartDate}, {campaign.EndDate}, Plan: {campaign.PlanId}");
            using var db = new BloodDonorContext();
            db.Campaigns.Add(campaign);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void UpdateCampaign(Campaign campaign)
        {
            using var db = new BloodDonorContext();
            int currentNumb = (from c in db.Campaigns
             where c.CampaignId == campaign.CampaignId
             select c).SingleOrDefault().NumOfVolunteer;
            (from c in db.Campaigns
             where c.CampaignId == campaign.CampaignId
             select c).SingleOrDefault().NumOfVolunteer = currentNumb + 1;
            db.SaveChanges();
        }
        public List<Campaign> getAllCampaign()
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Campaigns
                      select item).ToList();
            return us;
        }
        public List<Campaign> getCampaignById(int camId)
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Campaigns
                      where item.CampaignId == camId
                      select item).ToList();
            return us;
        }
    }
}
