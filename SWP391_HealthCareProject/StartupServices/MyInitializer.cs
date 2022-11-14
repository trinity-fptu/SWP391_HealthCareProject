using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Scheduler;

namespace SWP391_HealthCareProject.StartupServices
{
    public class MyInitializer : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            CampaignEnding.ScheduleCampaignEnding();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
