using Microsoft.AspNetCore.Mvc;
using Wonderlust.Application.Tours;
using Wonderlust.Domain.Entities;
using Wonderlust.Api.Models;

namespace Wonderlust.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourPackagesController : ControllerBase
{
    private readonly ITourPackageService _service;

    public TourPackagesController(ITourPackageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TourPackageDto>>> GetAll()
    {
        var tours = await _service.GetAllAsync();
        var result = tours.Select(MapToDto);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TourPackageDto>> GetById(int id)
    {
        var tour = await _service.GetByIdAsync(id);
        if (tour is null) return NotFound();
        return Ok(MapToDto(tour));
    }

    [HttpPost]
    public async Task<ActionResult<TourPackageDto>> Create([FromBody] CreateTourPackageRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var entity = new TourPackage
        {
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            BasePrice = request.BasePrice,
            DurationDays = request.DurationDays,
            DepartureCity = request.DepartureCity,
            DestinationCity = request.DestinationCity,
            IsActive = request.IsActive
        };

        var created = await _service.CreateAsync(entity);
        var dto = MapToDto(created);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TourPackageDto>> Update(int id, [FromBody] UpdateTourPackageRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var entity = new TourPackage
        {
            Name = request.Name,
            Description = request.Description,
            BasePrice = request.BasePrice,
            DurationDays = request.DurationDays,
            DepartureCity = request.DepartureCity,
            DestinationCity = request.DestinationCity,
            IsActive = request.IsActive
        };

        var updated = await _service.UpdateAsync(id, entity);
        if (updated is null) return NotFound();

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    private static TourPackageDto MapToDto(TourPackage t) =>
        new()
        {
            Id = t.Id,
            Code = t.Code,
            Name = t.Name,
            Description = t.Description,
            BasePrice = t.BasePrice,
            DurationDays = t.DurationDays,
            DepartureCity = t.DepartureCity,
            DestinationCity = t.DestinationCity,
            IsActive = t.IsActive
        };
}
