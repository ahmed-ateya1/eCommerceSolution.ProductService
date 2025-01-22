using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using ProductService.API.ApiEndpoints;
using ProductService.API.Middlewares;
using ProductService.RepositoryLayer;
using ProductService.ServiceLayer;
using ProductService.ServiceLayer.Dtos;
namespace ProductService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRepositoryLayer(builder.Configuration);
            builder.Services.AddServiceLayer();
            builder.Services.AddAutoMapper(typeof(ProductAddRequest).Assembly);
            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
           
            app.UseExecptionHandlingMiddleware();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapProductApiEndpoints();
            app.Run();
        }
    }
}
