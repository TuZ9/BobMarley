using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.Extensions
{
    public class BackgroundJobs : BackgroundService
    {
        private readonly ILogger<BackgroundJobs> _logger;
        private readonly IServiceProvider _service;
        public BackgroundJobs(ILogger<BackgroundJobs> logger, IServiceProvider service)
        {
            _service = service;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var job = Task.Run(() => Start(stoppingToken), stoppingToken);
            _logger.LogInformation("Start Background Jobs");
            //await Task.WhenAll(job);
            await job;
        }

        private async Task Start(CancellationToken tokenStop)
        {
            await using var scoped = _service.CreateAsyncScope();
            var scopedService = scoped.ServiceProvider;

            while (!tokenStop.IsCancellationRequested)
            {
                
            }
        }
    }
}
