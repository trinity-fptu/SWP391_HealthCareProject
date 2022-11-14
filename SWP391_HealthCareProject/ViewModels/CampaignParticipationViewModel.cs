using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.ViewModels
{
    public class CampaignParticipationViewModel
    {
        BloodDonorContext _db = new BloodDonorContext();
        public CampaignParticipationViewModel() { }
        public Campaign Campaign { get; set; }
        public Participate Participate { get; set; }
        public CampaignLocation CampaignLocation { get; set; }  
        public List<CampaignLocation> CampaignLocations { get; set; }

        public User GetUserByVolunteerId(int iVolunteerId) => _db.Users.Where(x=>x.UserId== iVolunteerId).FirstOrDefault();

        public Post GetPostByCampaignId(int id) => _db.Posts.Where(x => x.CampaignId == id).FirstOrDefault();

        public Campaign GetCampaignById(int id) => _db.Campaigns.Where(x => x.CampaignId == id).FirstOrDefault();
    }
}
