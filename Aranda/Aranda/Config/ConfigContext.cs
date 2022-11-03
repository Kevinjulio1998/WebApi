using Aranda.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Config
{
    public static class ConfigContext
    {
        public static void Setup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArandaConexion>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
