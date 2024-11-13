using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace BobMarley.Application.Static
{
    public static class RunTimeConfig
    {
        public static string? Auroraconnection;
        public static string? Mongoconnection = "";

        public static string CannabisEndpoint = "https://api.otreeba.com/";

        public static void SetConfigs(ConfigurationManager configuration)
        {
            if (Debugger.IsAttached)
            {
                Auroraconnection = "host=localhost;Database=postgres;username=postgres;password=12345678;";
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
