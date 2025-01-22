using Microsoft.EntityFrameworkCore;
using ProductService.RepositoryLayer.Data;
using ProductService.RepositoryLayer.Models;
using ProductService.RepositoryLayer.RepositoryContract;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductService.RepositoryLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? expression = null)
        {
            if (expression == null)
            {
                return _context.Products.ToList();
            }
            var products = _context.Products.Where(expression);

            
            return await products.ToListAsync();
        }

        public async Task<Product> GetByAsync(Expression<Func<Product, bool>> expression)
        {
            var product = _context.Products.Where(expression);

            return await product.FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
