using BobMarley.Application.Static;
using BobMarley.Infra.Extensions;
using BobMarley.Infra.Ioc.Hangfire;
using BobMarley.Infra.Ioc.HealthCheck;
using BobMarley.Infra.Ioc.Serilog;
using BobMarley.Infra.Ioc.Swagger;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;
using System.Net.Mime;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilog(builder.Configuration);
SwaggerConfiguration.AddSwagger(builder.Services);
RunTimeConfig.SetConfigs(builder.Configuration);

builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddHttpClients();
builder.Services.AddServices();
builder.Services.AddCors(options => options.AddPolicy("All", opt => opt
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostname => true)));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHangfire(x =>
{
    x.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
    x.UseSimpleAssemblyNameTypeSerializer();
    x.UseRecommendedSerializerSettings();
    x.UseMemoryStorage();
});

builder.Services.AddHangfireServer();
var app = builder.Build();

if (Debugger.IsAttached)
{
    app.UseHangfireDashboard("/hangfire");
}
else
{
    app.UseHangfireDashboard("/hangfire", new DashboardOptions()
    {
        Authorization = new[] { new HangfireAuthorizationFilter() },
        IgnoreAntiforgeryToken = true
    });
}
var serviceProvider = builder.Services.BuildServiceProvider();
HangireJobs.RunHangFireJob(serviceProvider);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
});
app.UseHealthChecks("/env", new HealthCheckOptions
{
    ResultStatusCodes =
                {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                },
    ResponseWriter = async (context, report) =>
    {
        var result = JsonSerializer.Serialize(new
        {
            //Environment = env.EnvironmentName,
            SystemEnvironment = Environment.GetEnvironmentVariable("dev"),
        });
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    }
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();
app.UseCors("All");
app.MapHealthChecks();
app.MapControllers();
app.Run();