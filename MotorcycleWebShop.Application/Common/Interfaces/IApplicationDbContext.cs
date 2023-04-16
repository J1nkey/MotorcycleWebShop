using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<ApplicationRole> Roles { get; set; }
        DbSet<Motorcycle> Motorcycles { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<Provider> Providers { get; set; }
        DbSet<Post> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
