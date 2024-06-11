using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Domain.Contracts;
using ShoppingSystemSematec.Domain.Entities;
using ShoppingSystemSematec.Infrastructure.Extensions;
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
        builder.RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //   => modelBuilder
    //       .HasDefaultSchema(EntitySchema.Ens)
    //       .RegisterAllEntities(typeof(EntityAttribute).Assembly)
    //       .RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly)
    //       .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public override int SaveChanges()
    {
        Console.WriteLine("Hello from Parham before save changes");
        return base.SaveChanges();
    }
}
