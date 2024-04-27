using BobMarley.Application.Static;
using BobMarley.Infra.Extensions;
using BobMarley.Infra.Ioc.Hangfire;
using BobMarley.Infra.Ioc.Serilog;
using BobMarley.Infra.Ioc.Swagger;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilog(builder.Configuration);
SwaggerConfiguration.AddSwagger(builder.Services);
RunTimeConfig.SetConfigs(builder.Configuration);


builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
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
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors("All");
app.MapControllers();
app.Run();
