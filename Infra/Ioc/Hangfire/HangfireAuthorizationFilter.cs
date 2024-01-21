using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace BobMarley.Infra.Ioc.Hangfire
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            throw new NotImplementedException();
        }
    }
}
