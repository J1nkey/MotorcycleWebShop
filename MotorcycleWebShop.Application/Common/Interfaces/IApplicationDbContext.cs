using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Motorcycle> Motorcycles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
