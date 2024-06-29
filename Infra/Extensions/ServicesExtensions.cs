using BobMarley.Application.Services;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Domain.Interfaces.Services;
using BobMarley.Infra.Context;
using BobMarley.Infra.Repositories.Postgree;
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
            return services
                .AddScoped<IFlowerService, FlowerService>();
        }
        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(_ => new AuroraDbContext())
                .AddScoped<IFlowerRepository, FlowerRepository>()
                .AddScoped<IStrainRepository, StrainRepository>();
        }
    }
}
