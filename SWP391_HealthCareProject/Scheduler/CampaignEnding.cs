using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject.Scheduler
{
    public class CampaignEnding
    {
        public static void ScheduleCampaignEnding()
        {
            var periodTimeSpan = TimeSpan.FromSeconds(10);
            while (true)
            {
                List<int>? removedCampaignId = CampaignDAO.UpdateStatus();
                if (removedCampaignId is not null)
                {
                    ParticipateDAO.RemoveParticipate(removedCampaignId);
                }
                Console.WriteLine("Hello World");
                Thread.Sleep(periodTimeSpan);
            }
        }
    }
}
