using AutoMapper;
using FluentValidation;
using ProductService.RepositoryLayer.Models;
using ProductService.RepositoryLayer.RepositoryContract;
using ProductService.ServiceLayer.Dtos;
using ProductService.ServiceLayer.ServiceContract;
using System.Linq.Expressions;

namespace ProductService.ServiceLayer.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductAddRequest> _productAddRequestValidator;
        private readonly IValidator<ProductUpdateRequest> _productUpdateRequestValidator;

        public ProductServices(
            IProductRepository productRepository,
            IMapper mapper,
            IValidator<ProductAddRequest> productAddRequestValidator,
            IValidator<ProductUpdateRequest> productUpdateRequestValidator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productAddRequestValidator = productAddRequestValidator;
            _productUpdateRequestValidator = productUpdateRequestValidator;
        }

        public async Task<ProductResponse> CreateAsync(ProductAddRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Validate the request
            _productAddRequestValidator.ValidateAndThrow(request);

            var product = _mapper.Map<Product>(request);
            var result = await _productRepository.CreateAsync(product).ConfigureAwait(false);
            return _mapper.Map<ProductResponse>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetByAsync(x => x.ProductID == id).ConfigureAwait(false);
            if (product == null)
            {
                return false;
            }
            return await _productRepository.DeleteAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductResponse>> GetAllAsync(Expression<Func<Product, bool>>? expression = null)
        {
            var result = await _productRepository.GetAllAsync(expression);
            return _mapper.Map<IEnumerable<ProductResponse>>(result);
        }

        public async Task<ProductResponse> GetByAsync(Expression<Func<Product, bool>> expression)
        {
            var result = await _productRepository.GetByAsync(expression);
            return _mapper.Map<ProductResponse>(result);
        }

        public async Task<ProductResponse> UpdateAsync(ProductUpdateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Validate the request
            _productUpdateRequestValidator.ValidateAndThrow(request);

            var productToUpdate = await _productRepository.GetByAsync(x => x.ProductID == request.ProductID).ConfigureAwait(false);
            if (productToUpdate == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductID} not found.");
            }

            var updatedProduct = _mapper.Map(request, productToUpdate);
            var result = await _productRepository.UpdateAsync(updatedProduct).ConfigureAwait(false);
            return _mapper.Map<ProductResponse>(result);
        }
    }
}
