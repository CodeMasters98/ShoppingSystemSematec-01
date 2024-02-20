using ShoppingSystemSematec.Contracts;

namespace ShoppingSystemSematec.Models;

public class Brand: BaseEntity<short>
{
    public string Name { get; set; }
}
