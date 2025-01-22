using AutoMapper;
using ProductService.RepositoryLayer.Models;
using ProductService.ServiceLayer.Dtos;

namespace ProductService.ServiceLayer.MappingProfile
{
    public class ProductMappingConfig : Profile
    {
        public ProductMappingConfig()
        {
            CreateMap<ProductAddRequest, Product>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
            CreateMap<ProductUpdateRequest, Product>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
            CreateMap<Product, ProductResponse>()
                .ReverseMap();
        }
    }
}
