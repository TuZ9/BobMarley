using BobMarley.Infra.Ioc.Serilog;
using BobMarley.Infra.Ioc.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilog(builder.Configuration);
SwaggerConfiguration.AddSwagger(builder.Services);

builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("All", opt => opt
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostname => true)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("All");
app.MapControllers();
app.Run();