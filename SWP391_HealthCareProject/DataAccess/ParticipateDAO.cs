using SWP391_HealthCareProject.Models;

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

        public List<Volunteer> GetAllVolunteers() => _db.Volunteers.ToList();

        public Volunteer GetVolunteerById(int id) => _db.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

        public Campaign GetCampaignById(int id) => _db.Campaigns.Where(x => x.CampaignId == id).FirstOrDefault();

    }
}
