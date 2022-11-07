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
