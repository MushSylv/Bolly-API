using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BollyAPI.DependencyInjection.Extensions
{
    public static class SwaggerExtensions
    {
        private const string VERSION = "v1";
        private const string SWAGGER_DOCNAME = "Bolly.API." + VERSION;

        public static IServiceCollection AddMasterClassSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(genOptions
                => genOptions.SwaggerDoc(SWAGGER_DOCNAME,
                    new OpenApiInfo
                    {
                        Title = "Bolly API",
                        Version = VERSION
                    }));

            return services;
        }

        public static IApplicationBuilder UseMasterClassSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(uiOptions => uiOptions.SwaggerEndpoint($"/swagger/{SWAGGER_DOCNAME}/swagger.json", "Bolly API"));

            return app;
        }
    }
}
