using Microsoft.Extensions.Configuration;
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

        }
    }
}
