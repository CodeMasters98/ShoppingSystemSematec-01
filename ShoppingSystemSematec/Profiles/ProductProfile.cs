using AutoMapper;
using ShoppingSystemSematec.Dtos;
using ShoppingSystemSematec.Models;

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
