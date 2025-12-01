using System.Threading;
using System.Threading.Tasks;
using Wonderlust.Application.Common.Interfaces;
using Wonderlust.Application.Tours;

namespace Wonderlust.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ITourPackageRepository TourPackages { get; }

    public UnitOfWork(AppDbContext context, ITourPackageRepository tourPackages)
    {
        _context = context;
        TourPackages = tourPackages;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(cancellationToken);
}
