using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Domain.Entities;
using ShoppingSystemSematec.Infrastructure.Context;

namespace ShoppingSystemSematec.Infrastructure.Persistence.Repositories;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    public ProductService(ApplicationDbContext context) => _context = context;

    public async Task<List<Product>> GetProducts()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();
        return products;
    }

    public async Task<Product> GetProductById(int id)
    {
        var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        return product;
    }

    public bool AddProduct(Product product)
    {
        Console.WriteLine($"product Before add : {_context.Entry(product).State}");
        _context.Products.Add(product);
        Console.WriteLine($"product after add : {_context.Entry(product).State}");
        _context.SaveChanges();
        Console.WriteLine($"product after save change : {_context.Entry(product).State}");
        product.Name = "Testsdkjfnsdkjf";
        Console.WriteLine($"product after save change : {_context.Entry(product).State}");
        return true;
    }
}
