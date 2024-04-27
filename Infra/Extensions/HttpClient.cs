using BobMarley.Application.Static;
using BobMarley.Domain.Interfaces.ApiClientService;
using BobMarley.Infra.HttpClientBase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var flowerLogger = serviceProvider.GetService(typeof(ILogger<FlowerApiClient>)) as ILogger<FlowerApiClient>;
            var strainLogger = serviceProvider.GetService(typeof(ILogger<StrainApiClient>)) as ILogger<StrainApiClient>;
            var extractLogger = serviceProvider.GetService(typeof(ILogger<ExtractApiClient>)) as ILogger<ExtractApiClient>;

            services.AddHttpClient("Flower",
                client => { client.BaseAddress = new Uri(RunTimeConfig.CannabisEndpoint); });
            services.AddHttpClient("Strain",
                client => { client.BaseAddress = new Uri(RunTimeConfig.CannabisEndpoint); });
            services.AddHttpClient("Extract",
                client => { client.BaseAddress = new Uri(RunTimeConfig.CannabisEndpoint); });

            services.AddSingleton<IFlowerApiClient, FlowerApiClient>(x =>
                new FlowerApiClient(x.GetService<IHttpClientFactory>()!, flowerLogger, "Flower"));
            services.AddSingleton<IStrainApiClient, StrainApiClient>(x =>
                new StrainApiClient(x.GetService<IHttpClientFactory>()!, strainLogger, "Strain"));

            services.AddSingleton<IExtractApiClient, ExtractApiClient>(x =>
                new ExtractApiClient(x.GetService<IHttpClientFactory>()!, extractLogger, "Extract"));

            return services;
        }
    }
}