using Microsoft.SqlServer.Management.Smo;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HospitalRedCrossDAO
    {
        public static HospitalRedCross? GetHRByAddress(string hrAddress)
        {
            using var db = new BloodDonorContext();
            var HR = db.HospitalRedCrosses.FirstOrDefault(x => x.Address == hrAddress);
            return HR;
        }
        public static HospitalRedCross? GetHRById(int rhId)
        {
            using var db = new BloodDonorContext();
            var HR = db.HospitalRedCrosses.FirstOrDefault(x => x.Rhid == rhId);
            return HR;
        }
        public Campaign getCampaignById(int id)
        {
            using var db = new BloodDonorContext();
            var cam = db.Campaigns.Find(id);
            return cam;
        }
        public void updateCampaign(Campaign campaign)
        {
            try
            {
                using var db = new BloodDonorContext();
                Campaign _campaign = getCampaignById(campaign.CampaignId);
                if (_campaign != null)
                {
                    int currentNumb = (from c in db.Campaigns
                                       where c.CampaignId == campaign.CampaignId
                                       select c).SingleOrDefault().NumOfVolunteer;
                    (from c in db.Campaigns
                     where c.CampaignId == campaign.CampaignId
                     select c).SingleOrDefault().NumOfVolunteer = currentNumb + 1;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Campaign does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}