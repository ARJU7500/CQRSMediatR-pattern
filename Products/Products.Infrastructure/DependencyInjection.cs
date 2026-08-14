using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Products.Application.Interfaces;
using Products.Core.Options;
using Products.Infrastructure.Peristincy;
using Products.Infrastructure.Reposirties;
namespace Products.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((Serviceprovider, options) =>options.UseSqlServer(Serviceprovider.GetRequiredService<IOptionsMonitor<ConnectionStringOptions>>().CurrentValue.DefaultCon));
            services.AddScoped<IProductRepository, ProductsRepository>();
            return services;
        }
    }
}
