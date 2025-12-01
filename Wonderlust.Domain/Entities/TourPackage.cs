namespace Wonderlust.Domain.Entities;

public class TourPackage
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;        // e.g. "GOA-3D2N"
    public string Name { get; set; } = string.Empty;        // "Goa Beach Escape"
    public string Description { get; set; } = string.Empty;

    public decimal BasePrice { get; set; }                  // per person
    public int DurationDays { get; set; }                   // in days

    public string DepartureCity { get; set; } = string.Empty;
    public string DestinationCity { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}
