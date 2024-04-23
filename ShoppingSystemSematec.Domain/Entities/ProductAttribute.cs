using ShoppingSystemSematec.Domain.Contracts;

namespace ShoppingSystemSematec.Domain.Entities;

public class ProductAttribute : BaseEntity<int>
{
    public string Key { get; set; }
    public string Value { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
