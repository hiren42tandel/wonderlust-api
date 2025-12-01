using Wonderlust.Application.Tours;
using Wonderlust.Domain.Entities;
using Wonderlust.Infrastructure.Persistence;

namespace Wonderlust.Infrastructure.Repositories;

public class TourPackageRepository 
    : GenericRepository<TourPackage>, ITourPackageRepository
{
    public TourPackageRepository(AppDbContext context) : base(context)
    {
    }
}
