using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject
{
    public class MyInitializer : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            List<int>? removedCampaignId = CampaignDAO.UpdateStatus();
            if(removedCampaignId is not null)
            {
                ParticipateDAO.RemoveParticipate(removedCampaignId);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
