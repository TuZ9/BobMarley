using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BobMarley.Infra.Extensions
{
    public static class HangireJobs
    {
        public static void RunHangFireJob(ServiceProvider services, ConfigurationManager configuration)
        {
            RunJobs(services, configuration);
        }
        public static void RunJobs(ServiceProvider services, ConfigurationManager configuration)
        {

        }
    }
}
