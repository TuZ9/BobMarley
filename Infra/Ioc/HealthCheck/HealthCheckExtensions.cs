using System.Diagnostics.CodeAnalysis;
using BobMarley.Application.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BobMarley.Infra.Ioc.HealthCheck
{
    [ExcludeFromCodeCoverage]
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = services.BuildServiceProvider();

            services
                .AddHealthChecks()
                .AddNpgSql(connectionString: RunTimeConfig.Auroraconnection, tags: ["postgres"]);

            return services;
        }

        public static void MapHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/ping", async context => await context.Response.WriteAsync("pong"));
            endpoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = HealthCheckHelper.WriteHealthCheckResponse
            });
            endpoints.MapHealthChecks("/health/postgres", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("postgres"),
            });
        }
    }
}