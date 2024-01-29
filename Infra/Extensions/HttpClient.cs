using BobMarley.Application.Static;
using BobMarley.Domain.Interfaces.ApiClientService;
using BobMarley.Infra.HttpClientBase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BobMarley.Infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddSingleton(services.AddHttpClient<IFlowerApiClient, FlowerApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.CannabisEndpoint)));

            return services;
        }
    }
}
