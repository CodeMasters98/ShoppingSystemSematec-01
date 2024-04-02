using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Api.Models;
using ShoppingSystemSematec.Models;

namespace ShoppingSystemSematec.Api.Context;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Product> Products { get; set; }
}
