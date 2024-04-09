
using ShoppingSystemSematec.Domain.Contracts;

namespace ShoppingSystemSematec.Domain.Entities;

public class Brand: BaseEntity<short>
{
    public string Name { get; set; }
}
