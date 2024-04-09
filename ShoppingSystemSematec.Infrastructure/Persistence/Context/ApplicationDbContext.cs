using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Domain.Entities;
using System.Reflection;

namespace ShoppingSystemSematec.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        Console.WriteLine("Hello from Parham before save changes");

        return base.SaveChanges();
    }
}
