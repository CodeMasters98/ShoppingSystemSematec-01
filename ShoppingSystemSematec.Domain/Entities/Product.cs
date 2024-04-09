using ShoppingSystemSematec.Domain.Contracts;

namespace ShoppingSystemSematec.Domain.Entities;

public class Product:BaseEntity<int>
{
    public string Name { get; set; }
    public decimal Discount { get; set; }
    public decimal Price { get; set; }
}
