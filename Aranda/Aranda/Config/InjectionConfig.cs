using System;
using Aranda.Infraestructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
namespace Aranda.Config
{
    public static class InjectionConfig
    {

        public static void InjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            Injection.AddDependency(services);
        }
    }
}
