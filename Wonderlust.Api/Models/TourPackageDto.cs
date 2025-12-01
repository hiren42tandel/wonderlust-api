namespace Wonderlust.Api.Models;

public class TourPackageDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public int DurationDays { get; set; }
    public string DepartureCity { get; set; } = string.Empty;
    public string DestinationCity { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
