using SWP391_HealthCareProject.DataAccess;

namespace SWP391_HealthCareProject
{
    public class MyInitializer : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            CampaignDAO.UpdateStatus();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
