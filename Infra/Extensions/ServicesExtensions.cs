using BobMarley.Application.Static;
using BobMarley.Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace BobMarley.Infra.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .RegisterServices()
                .RegisterRepositories();
        }
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;
        }
        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton(_ => new AuroraDbContext(RunTimeConfig.Auroraconnection));
        }
    }
}
