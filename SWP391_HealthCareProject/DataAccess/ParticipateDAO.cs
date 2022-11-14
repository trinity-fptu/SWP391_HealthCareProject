using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class ParticipateDAO
    {
        public static void AddParticipate(Participate participate)
        {
            using var db = new BloodDonorContext();
            db.Participates.Add(participate);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static Participate? GetParticipate(int volunteerId, int campaignId)
        {
            using var db = new BloodDonorContext();
            var participate = db.Participates.SingleOrDefault(p => p.VolunteerId== volunteerId && p.CampaignId == campaignId);
            return participate;
        }

        public static void RemoveParticipate(int volunteerId, int campaignId) {
            using var db = new BloodDonorContext();
            var participate = GetParticipate(volunteerId, campaignId);
            if(participate != null)
            {
                db.Participates.Remove(participate);
                db.SaveChanges();
            }
        }
    }
}
