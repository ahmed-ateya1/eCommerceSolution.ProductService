using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProductService.ServiceLayer.Dtos;
using ProductService.ServiceLayer.ServiceContract;
using ProductService.ServiceLayer.Services;

namespace ProductService.ServiceLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ProductAddRequest>();
            services.AddScoped<IProductServices, ProductServices>();
            return services;
        }
    }
}
