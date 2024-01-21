
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace BobMarley.Application.Static
{
    public static class RunTimeConfig
    {
        public static string? Auroraconnection = "";
        public static string? Mongoconnection = "";

        public static void SetConfigs(ConfigurationManager configuration)
        {
            if (Debugger.IsAttached)
            {
                Auroraconnection = configuration.GetConnectionString("Auroraconnection");
                Mongoconnection = configuration.GetConnectionString("Mongoconnection");
            }
            else
            {
                Auroraconnection = Environment.GetEnvironmentVariable("Auroraconnection");
                Mongoconnection = Environment.GetEnvironmentVariable("Mongoconnection");
            }
        }

    }
}
