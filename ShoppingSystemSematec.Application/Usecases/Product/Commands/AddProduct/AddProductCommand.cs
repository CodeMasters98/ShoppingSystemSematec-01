#nullable disable

using MediatR;
using ShoppingSystemSematec.Application.Wrappers;

namespace ShoppingSystemSematec.Application.Usecases.Product.Commands;

public record AddProductCommand : IRequest<Response<int>>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
