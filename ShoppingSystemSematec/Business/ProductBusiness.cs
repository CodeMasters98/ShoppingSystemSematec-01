using ShoppingSystemSematec.Api.Contracts;
using ShoppingSystemSematec.Models;

namespace ShoppingSystemSematec.Business;

public class ProductBusiness : IProductBusiness
{

    static public List<Product> Products = new List<Product>()
    {
        new Product() { Id = 1, Name = "Test", Price = 10000, CreateAt = DateTime.Now },
        new Product() { Id = 2, Name = "Test", Price = 12000, CreateAt = DateTime.Now },
        new Product() { Id = 3, Name = "Test", Price = 13000, CreateAt = DateTime.Now },
    };

    public List<Product> GetProducts()
    {
        return Products;
    }

    public Product GetProductById(int id)
    {
        var product = Products.Where(x => x.Id == id).FirstOrDefault();
        return product;
    }

    public bool AddProduct(Product product)
    {
        Products.Add(product);
        return true;
    }
}
