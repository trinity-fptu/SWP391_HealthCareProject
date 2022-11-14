using SWP391_HealthCareProject.Scheduler;

namespace SWP391_HealthCareProject.StartupServices
{
    public class MyInitializer : IHostedService
    {
        private Timer? _timer = null;
        private CampaignEnding job;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            job = new CampaignEnding();
            _timer = new Timer(job.ScheduleCampaignEnding, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}