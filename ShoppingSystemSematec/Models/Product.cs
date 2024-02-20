using ShoppingSystemSematec.Contracts;

namespace ShoppingSystemSematec.Models;

public class Product:BaseEntity<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
