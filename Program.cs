using BobMarley.Infra.Ioc;
using BobMarley.Infra.Ioc.Serilog;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilog(builder.Configuration);

Console.WriteLine("Hello, World!");
