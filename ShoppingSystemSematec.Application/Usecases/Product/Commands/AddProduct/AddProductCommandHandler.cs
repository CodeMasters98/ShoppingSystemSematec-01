using AutoMapper;
using MediatR;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Application.Wrappers;

namespace ShoppingSystemSematec.Application.Usecases.Product.Commands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Response<int>>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IProductService productService, IMapper mapper)
    {
        _mapper = mapper;
        _productService = productService;
    }

    public async Task<Response<int>> Handle(AddProductCommand request, CancellationToken ct)
    {
        var product = _mapper.Map<ShoppingSystemSematec.Domain.Entities.Product>(request);
        await _productService.AddAsync(product, ct);
        return new Response<int>();
    }
}
