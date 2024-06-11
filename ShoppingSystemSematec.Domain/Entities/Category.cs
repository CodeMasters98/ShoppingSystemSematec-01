#nullable disable

using ShoppingSystemSematec.Domain.Contracts;

namespace ShoppingSystemSematec.Domain.Entities;

[Entity]
public class Category: BaseEntity<int>
{
    public string Name { get; set; }
    public bool IsActivate { get; set; }
}
