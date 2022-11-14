using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class CampaignLocationDAO
    {
        public static List<CampaignLocation> GetLocationsByCampaignId(int campaignId)
        {
            using var db = new BloodDonorContext();
            var campaignLocations = db.CampaignLocations.Where(l => l.CampaignId == campaignId).ToList();   
            return campaignLocations;
        }

        public static void DeleteCampaignLocation(int campaignId)
        {
            var Location = GetLocationsByCampaignId(campaignId);
            using var db= new BloodDonorContext();
            db.CampaignLocations.RemoveRange(Location);
            db.SaveChanges();
        }

        public static void CreateLocation(CampaignLocation location)
        {
            if(location is not null)
            {
                using var db = new BloodDonorContext();
                db.CampaignLocations.Add(location);
                db.SaveChanges();
            }
        }
    }
}
