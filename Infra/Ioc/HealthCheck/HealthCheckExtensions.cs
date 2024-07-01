using System;
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
            //var endpoints = provider.GetService<IOptions<EnpointIndexOption>>().Value;
            //var endpointsCollateral = provider.GetService<IOptions<EndpointCollateralSummaryOption>>().Value;
            //var rabbitSettings = provider.GetService<IOptions<MassTransitSettingsOption>>().Value;

            services
                .AddHealthChecks()
                .AddNpgSql(connectionString: RunTimeConfig.Auroraconnection, tags: ["postgres"]);
                //.AddUrlGroup(new Uri(endpoints.KatherineJohnsonEndPoint + "health"), name: "Katherine_Jhonson", tags: new[] { "kj" })
                //.AddUrlGroup(new Uri(endpoints.CalendarEndPoint + "health"), name: "Calendar", tags: new[] { "calendar" })
                //.AddUrlGroup(new Uri(endpoints.FalloutShelterEndPoint + "health"), name: "Fallout Shelter", tags: new[] { "fallout" })
                //.AddUrlGroup(new Uri(endpointsCollateral.CollateralSummary + "health"), name: "Collateral Summary", tags: new[] { "collateral" })
                //.AddRabbitMQ(rabbitSettings.ToString(), name: "RabbitMQ", tags: new[] { "rabbit" });

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