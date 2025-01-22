using FluentValidation;
using ProductService.ServiceLayer.Dtos;

namespace ProductService.ServiceLayer.Validators
{
    public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(x=>x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0")
                .NotEmpty().WithMessage("Unit price is required");

            RuleFor(x => x.QuantityInStock)
                .GreaterThan(0).WithMessage("Stock quantity must be greater than 0")
                .NotEmpty().WithMessage("Stock quantity is required");

            RuleFor(x => x.Category)
                .IsInEnum().WithMessage("Invalid category")
                .NotEmpty().WithMessage("Category Name is required");


        }
    }
}
