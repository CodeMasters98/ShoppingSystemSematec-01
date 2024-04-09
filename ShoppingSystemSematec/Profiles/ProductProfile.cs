using AutoMapper;
using ShoppingSystemSematec.Domain.Entities;
using ShoppingSystemSematec.Dtos;

namespace ShoppingSystemSematec.Api.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        //Source,Dest
        CreateMap<AddProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
