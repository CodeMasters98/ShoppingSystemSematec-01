using ShoppingSystemSematec.Domain.Contracts;
using ShoppingSystemSematec.Domain.Entities;

namespace ShoppingSystemSematec.Infrastructure.Persistence.Seeder;

public class ProductSeeder: IBaseSeeder<Product>
{
    public IEnumerable<Product> GetSeedData()
            => new List<Product>()
                {
                    new()
                    {
                        CreateAt = DateTime.Now,
                        Id = 1,
                        Name = "test",
                        BuyPrice = 1,
                        Color = Domain.Enums.ColorEnum.WHITE,
                        Rate = 5,
                        Price = 1,
                    }
                };
}
