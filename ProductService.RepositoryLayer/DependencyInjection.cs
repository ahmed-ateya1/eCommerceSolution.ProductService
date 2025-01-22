using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.RepositoryLayer.Data;
using ProductService.RepositoryLayer.Repositories;
using ProductService.RepositoryLayer.RepositoryContract;

namespace ProductService.RepositoryLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(
                    configuration.GetConnectionString("DefaultConnection")!
                );
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
