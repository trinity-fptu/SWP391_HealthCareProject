using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject.Scheduler
{
    public class CampaignEnding
    {
        public void ScheduleCampaignEnding(object? state)
        {
            List<int>? removedCampaignId = CampaignDAO.UpdateStatus();
            
        }
    }
}