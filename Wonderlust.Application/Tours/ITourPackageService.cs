using Wonderlust.Domain.Entities;

namespace Wonderlust.Application.Tours;

public interface ITourPackageService
{
    Task<IReadOnlyList<TourPackage>> GetAllAsync();
    Task<TourPackage?> GetByIdAsync(int id);
    Task<TourPackage> CreateAsync(TourPackage tour);
    Task<TourPackage?> UpdateAsync(int id, TourPackage updated);
    Task<bool> DeleteAsync(int id);
}
