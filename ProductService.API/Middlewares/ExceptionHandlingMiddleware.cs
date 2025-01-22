﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace ProductService.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public  async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                if(ex.InnerException != null)
                {
                    _logger.LogError($"{ex.InnerException} , {ex.InnerException.Message}");
                }
                else
                {
                    _logger.LogError($"{ex} , {ex.Message}");
                }
                httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message , Type = ex.GetType().ToString() });
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExecptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExecptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
