using System.Threading;
using System.Threading.Tasks;
using Wonderlust.Application.Tours;

namespace Wonderlust.Application.Common.Interfaces;

public interface IUnitOfWork
{
    ITourPackageRepository TourPackages { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
