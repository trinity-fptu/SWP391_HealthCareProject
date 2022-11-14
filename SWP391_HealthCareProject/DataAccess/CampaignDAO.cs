using Microsoft.SqlServer.Management.Smo;
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
        public static void UpdateCampaign(int id)
        {
            using var db = new BloodDonorContext();
            var updatedRecord = db.Campaigns.Find(id);
            updatedRecord.NumOfVolunteer += 1;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<int>? UpdateStatus()
        {
            using var db = new BloodDonorContext();
            var updatedCampaigns = db.Campaigns.Where(c => DateTime.Compare(DateTime.Now, c.EndDate) > 0).ToList();
            if (updatedCampaigns.Count != 0)
            {
                db.Campaigns.Where(c => DateTime.Compare(DateTime.Now, c.EndDate) > 0).ToList().ForEach(c => c.Status = false);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                List<int> removedCampaignId = new();
                foreach (var c in updatedCampaigns)
                {
                    removedCampaignId.Add(c.CampaignId);
                }
                return removedCampaignId;
            }
            return null;
            
        }
        public List<Campaign> getAllCampaign()
        {
            using var db = new BloodDonorContext();
            var us = db.Campaigns.ToList();
            return us;
        }
        public static Campaign getCampaignById(int camId)
        {
            using var db = new BloodDonorContext();
            var us = db.Campaigns.Find(camId);
            return us;
        }
        public static List<Campaign> searchCampaign(DateTime date, string location)
        {
            using var db = new BloodDonorContext();
            
                var model = (from item in db.Campaigns
                             where item.StartDate >= date && item.Province.Contains(location)
                             select item).ToList();
                return model.ToList();
            
        }
    }
}
