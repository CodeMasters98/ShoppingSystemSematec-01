using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using ShoppingSystemSematec.Infrastructure.Identity.Entities;

namespace ShoppingSystemSematec.Infrastructure.Identity.Context;

public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser>
{
    //public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options) : base(options)
    //{
    //}

}
