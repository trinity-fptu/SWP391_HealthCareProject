using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.ViewModels
{
    public class CampaignParticipationViewModel
    {
        public CampaignParticipationViewModel() { }
        public Campaign Campaign { get; set; }
        public Participate Participate { get; set; }
        public CampaignLocation CampaignLocation { get; set; }  
        public List<CampaignLocation> CampaignLocations { get; set; }
    }
}
