using ShoppingSystemSematec.Domain.Entities;

namespace ShoppingSystemSematec.Application.Contracts;

public interface IProductAttributeService
{
    bool AddProductAttribute(ProductAttribute productAttribute);
}
