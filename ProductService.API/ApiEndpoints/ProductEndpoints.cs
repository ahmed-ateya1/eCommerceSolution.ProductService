using ProductService.ServiceLayer.Dtos;
using ProductService.ServiceLayer.ServiceContract;

namespace ProductService.API.ApiEndpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder MapProductApiEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", async (IProductServices productService) =>
            {
                var products = await productService.GetAllAsync();
                return Results.Ok(products);
            });
            app.MapGet("/api/products/search/{searchString}",async(IProductServices productService ,string searchString) =>
            {
                var products = await productService.GetAllAsync(x=>x.ProductName.ToLower().Contains(searchString.ToUpper()));
                return Results.Ok(products);
            });
            app.MapGet("/api/products/search/productid/{ProductID:guid}", async (IProductServices productService , Guid ProductID) =>
            {
                var product = await productService.GetByAsync(x => x.ProductID == x.ProductID);
                return Results.Ok(product);
            });

            app.MapPost("/api/products", async (IProductServices productService, ProductAddRequest request) =>
            {
                var product = await productService.CreateAsync(request);
                return Results.Ok(product);
            });
            app.MapPut("/api/products", async (IProductServices productService, ProductUpdateRequest request) =>
            {
                var product = await productService.UpdateAsync(request);
                return Results.Ok(product);
            });
            app.MapDelete("/api/products/{id}", async (IProductServices productService, Guid id) =>
            {
                var result = await productService.DeleteAsync(id);
                return Results.Ok(result);
            });

            return app;
        }
    }
}
