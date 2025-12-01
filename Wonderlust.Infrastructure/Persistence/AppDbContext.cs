using Microsoft.EntityFrameworkCore;
using Wonderlust.Domain.Entities;

namespace Wonderlust.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TourPackage> TourPackages => Set<TourPackage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TourPackage>(entity =>
        {
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Code).IsRequired().HasMaxLength(50);
            entity.Property(p => p.BasePrice).HasPrecision(18, 2);
        });
    }
}
