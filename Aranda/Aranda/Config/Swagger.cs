using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Aranda.Config
{
    public static class Swagger
    {
        private static readonly IConfiguration _configuration;

        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Aranda API",
                    Description = "Web Api CatalogueDto ASP.NET Core Web API",
                });
            });

        }

      
    }
}
