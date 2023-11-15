using BobMarley.Infra.Ioc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilog(builder.Configuration);
