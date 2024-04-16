using ShoppingSystemSematec.Domain.Entities;

namespace ShoppingSystemSematec.Application.Contracts;

public interface IProductService
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    bool AddProduct(Product product);
}

