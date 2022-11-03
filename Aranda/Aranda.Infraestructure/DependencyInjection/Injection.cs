using Aranda.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Infraestructure.DependencyInjection
{
    public static class Injection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

           
            return services;
        }
    }
}
