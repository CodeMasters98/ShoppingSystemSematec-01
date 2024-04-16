using AutoMapper;
using ShoppingSystemSematec.Domain.Entities;
using ShoppingSystemSematec.Application.Dtos;

namespace ShoppingSystemSematec.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        //Source,Dest
        CreateMap<AddProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
