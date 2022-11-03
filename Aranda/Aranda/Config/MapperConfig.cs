using System;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Config
{
    public static class MapperConfig
    {
        public static void AutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
