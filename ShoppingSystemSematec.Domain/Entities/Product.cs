#nullable disable

using ShoppingSystemSematec.Domain.Contracts;
using ShoppingSystemSematec.Domain.Enums;

namespace ShoppingSystemSematec.Domain.Entities;

[Entity]
public class Product : BaseEntity<int>, IFullEntity
{
    public string Name { get; set; }
    public decimal Discount { get; set; }
    public decimal Price { get; set; }
    public decimal BuyPrice { get; set; }
    public int Rate { get; set; }
    public ColorEnum Color { get; set; }
    public string Description { get; set; }
    public bool IsActivate { get; private set; }
    public string MetaDescription { get; set; }
    public string ImagePath { get; set; }
    public void Activate() => IsActivate = true;
    public void Disactive() => IsActivate = false;

    public ICollection<ProductAttribute> ProductAttributes { get; set; }
    public int DeletedByUserId { get; set; }
    public int EditedByUserId { get; set; }
    public DateTime DeletedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
