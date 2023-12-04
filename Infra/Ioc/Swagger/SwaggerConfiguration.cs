using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BobMarley.Infra.Ioc.Swagger
{
    public class SwaggerConfiguration
    {
        public static void AddSwagger(IServiceCollection _collection)
        {
            _collection.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BobMarley", Version = "v1" });
                options.ResolveConflictingActions(d => d.First());

            });
        }
    }
}
