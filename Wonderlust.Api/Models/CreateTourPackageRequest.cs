using System.ComponentModel.DataAnnotations;

namespace Wonderlust.Api.Models;

public class CreateTourPackageRequest
{
    [Required, MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal BasePrice { get; set; }

    [Range(1, 365)]
    public int DurationDays { get; set; }

    [Required]
    public string DepartureCity { get; set; } = string.Empty;

    [Required]
    public string DestinationCity { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
