using Microsoft.EntityFrameworkCore;
using Wonderlust.Domain.Entities;

namespace Wonderlust.Infrastructure.Persistence;

public static class AppDbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Ensure database and schema are created/migrated
        await context.Database.MigrateAsync();

        if (!context.TourPackages.Any())
        {
            var tours = new List<TourPackage>
            {
                new()
                {
                    Code = "GOA-3D2N",
                    Name = "Goa Beach Escape",
                    Description = "3 days, 2 nights stay with beach activities and sightseeing.",
                    BasePrice = 15000,
                    DurationDays = 3,
                    DepartureCity = "Mumbai",
                    DestinationCity = "Goa",
                    IsActive = true
                },
                new()
                {
                    Code = "KER-5D4N",
                    Name = "Kerala Backwaters",
                    Description = "Houseboat stay, backwater cruise and local sightseeing.",
                    BasePrice = 28000,
                    DurationDays = 5,
                    DepartureCity = "Ahmedabad",
                    DestinationCity = "Kochi",
                    IsActive = true
                },
                new()
                {
                    Code = "HIM-7D6N",
                    Name = "Himalayan Trek Adventure",
                    Description = "Moderate trek with camping in the Himalayas.",
                    BasePrice = 35000,
                    DurationDays = 7,
                    DepartureCity = "Delhi",
                    DestinationCity = "Manali",
                    IsActive = true
                }
            };

            await context.TourPackages.AddRangeAsync(tours);
            await context.SaveChangesAsync();
        }
    }
}
