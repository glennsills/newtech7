using AutoMapper;
using Newtech.Data.Entities;
using Newtech.Api.Features.Products.Dtos;


namespace Newtech.Api.Features.Products.Maps;

public class ProductToProductListingDto : Profile
{
    public ProductToProductListingDto()
    {
        CreateMap<Product, ProductListingDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => (src.ProductCategory == null? "": src.ProductCategory.Name)));
    }
}
