using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Application.Exceptions;
using ShoppingSystemSematec.Application.Wrappers;
using ShoppingSystemSematec.Infrastructure.Context;

namespace ShoppingSystemSematec.Infrastructure.Persistence.Repositories;

public class ProductService : GenericRepository<Domain.Entities.Product>, IProductService
{
    private readonly ApplicationDbContext _context;
    public ProductService(ApplicationDbContext context) : base(context)
    {

    }

    public Response<bool> Activate(int productId)
    {
        var product =_context.Products.Where(x => x.Id == productId).FirstOrDefault();
        if (product is null)
            throw new ApiException($"Product Not Found.");

        product.Activate();

        _context.SaveChanges();

        return new Response<bool>(true);
    }
}
