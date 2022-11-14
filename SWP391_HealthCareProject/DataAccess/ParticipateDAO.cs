using SWP391_HealthCareProject.Models;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.DataAccess
{
    public class ParticipateDAO
    {
        BloodDonorContext _db = new BloodDonorContext();

        public List<Participate> GetAllParticipates() => _db.Participates.ToList();
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

        public List<Participate> GetParticipatesByCampaignId(int id) => _db.Participates.Where(x => x.CampaignId == id).ToList();

        public List<Volunteer> GetVolunteerListInParticipate(int id) => _db.Volunteers.Where(x => x.VolunteerId == id).ToList();

        public List<Volunteer> GetAllVolunteers() => _db.Volunteers.ToList();

        public Volunteer GetVolunteerById(int id) => _db.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

        public Campaign GetCampaignById(int id) => _db.Campaigns.Where(x => x.CampaignId == id).FirstOrDefault();
        public static Participate? GetParticipate(int volunteerId, int campaignId)
        {
            using var db = new BloodDonorContext();
            var participate = db.Participates.SingleOrDefault(p => p.VolunteerId == volunteerId && p.CampaignId == campaignId);
            return participate;
        }

        public static void RemoveParticipate(int volunteerId, int campaignId)
        {
            using var db = new BloodDonorContext();
            var participate = GetParticipate(volunteerId, campaignId);
            if (participate != null)
            {
                db.Participates.Remove(participate);
                db.SaveChanges();
            }
        }

    }
}
