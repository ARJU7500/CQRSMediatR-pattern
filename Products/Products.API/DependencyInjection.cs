using Products.Application;
using Products.Core;
using Products.Infrastructure;

namespace Products.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCoreDI(configuration);
            services.AddInfrastructureDI();
            services.AddApplicationDI();
            return services;
        }
    }
}
