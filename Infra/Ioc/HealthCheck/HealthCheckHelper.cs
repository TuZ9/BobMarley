using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;
using System.Text.Json;

namespace BobMarley.Infra.Ioc.HealthCheck
{
    public static class HealthCheckHelper
    {
        public static Task WriteHealthCheckResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var stream = new MemoryStream();
            WriteJson(result, options, stream);

            return context.Response.WriteAsync(Encoding.UTF8.GetString(stream.ToArray()));
        }

        private static void WriteJson(HealthReport result, JsonWriterOptions options, MemoryStream stream)
        {
            using var writer = new Utf8JsonWriter(stream, options);

            writer.WriteStartObject();
            writer.WriteString("status", result.Status.ToString());

            writer.WriteStartObject("results");
            foreach (var entry in result.Entries)
                writer.WriteString(entry.Key, $"{entry.Value.Status}{(string.IsNullOrEmpty(entry.Value.Description) ? "" : $" - {entry.Value.Description}")}");

            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}