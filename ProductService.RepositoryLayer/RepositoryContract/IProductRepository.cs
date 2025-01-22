using ProductService.RepositoryLayer.Models;
using System.Linq.Expressions;

namespace ProductService.RepositoryLayer.RepositoryContract
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Guid id);
        Task<Product> GetByAsync(Expression<Func<Product,bool>> expression);
        Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product,bool>>?expression = null);
    }
}
