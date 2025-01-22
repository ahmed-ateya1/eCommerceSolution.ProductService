using ProductService.RepositoryLayer.Models;
using ProductService.ServiceLayer.Dtos;
using System.Linq.Expressions;

namespace ProductService.ServiceLayer.ServiceContract
{
    public interface IProductServices
    {
        Task<ProductResponse> CreateAsync(ProductAddRequest request);
        Task<ProductResponse> UpdateAsync(ProductUpdateRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task<ProductResponse> GetByAsync(Expression<Func<Product, bool>> expression);

        Task<IEnumerable<ProductResponse>> GetAllAsync(Expression<Func<Product,bool>>?expression = null);

    }
}
