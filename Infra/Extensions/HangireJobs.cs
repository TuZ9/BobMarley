using BobMarley.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BobMarley.Infra.Extensions
{
    public static class HangireJobs
    {
        public static async void RunHangFireJob(ServiceProvider services)
        {
            await RunJobs(services);
        }
        public static async Task RunJobs(ServiceProvider services)
        {
            using var scope = services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IFlowerService>();

            await service.BuildBase();
        }
    }
}
