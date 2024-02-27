using ShoppingSystemSematec.Models;

namespace ShoppingSystemSematec.Api.Contracts;

public interface IProductBusiness
{
    List<Product> GetProducts();
    Product GetProductById(int id);
    bool AddProduct(Product product);
}
