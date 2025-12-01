using Wonderlust.Application.Common.Interfaces;
using Wonderlust.Domain.Entities;

namespace Wonderlust.Application.Tours;

public class TourPackageService : ITourPackageService
{
    private readonly IUnitOfWork _unitOfWork;

    public TourPackageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IReadOnlyList<TourPackage>> GetAllAsync()
        => _unitOfWork.TourPackages.ListAsync();

    public Task<TourPackage?> GetByIdAsync(int id)
        => _unitOfWork.TourPackages.GetByIdAsync(id);

    public async Task<TourPackage> CreateAsync(TourPackage tour)
    {
        await _unitOfWork.TourPackages.AddAsync(tour);
        await _unitOfWork.SaveChangesAsync();
        return tour;
    }

    public async Task<TourPackage?> UpdateAsync(int id, TourPackage updated)
    {
        var existing = await _unitOfWork.TourPackages.GetByIdAsync(id);
        if (existing is null) return null;

        existing.Name = updated.Name;
        existing.Description = updated.Description;
        existing.BasePrice = updated.BasePrice;
        existing.DurationDays = updated.DurationDays;
        existing.DepartureCity = updated.DepartureCity;
        existing.DestinationCity = updated.DestinationCity;
        existing.IsActive = updated.IsActive;

        _unitOfWork.TourPackages.Update(existing);
        await _unitOfWork.SaveChangesAsync();

        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _unitOfWork.TourPackages.GetByIdAsync(id);
        if (existing is null) return false;

        _unitOfWork.TourPackages.Delete(existing);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
