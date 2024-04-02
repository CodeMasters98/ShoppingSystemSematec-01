using ShoppingSystemSematec.Api.Context;
using ShoppingSystemSematec.Api.Contracts;
using ShoppingSystemSematec.Models;

namespace ShoppingSystemSematec.Business;

public class ProductBusiness : IProductBusiness
{
    private readonly ApplicationDbContext _context;
    public ProductBusiness(ApplicationDbContext context) => _context = context;

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        //var product = Products.Where(x => x.Id == id).FirstOrDefault();
        var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
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
