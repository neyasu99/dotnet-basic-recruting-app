using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public IActionResult AddLocation(Location location)
    {
        if (Validation(location).Equals(200))
            LocationsRepository.AddLocation(location);
        return CreatedAtAction(nameof(GetById), new {id = location.Id}, location);
    }

    [HttpDelete]
    public IActionResult DeleteLocation(Guid locationId)
    {
        LocationsRepository.DeleteLocation(locationId);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(LocationsRepository.GetAllLocations());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var location = LocationsRepository.GetLocationById(id);
        if (location is null)
        {
            return NotFound();
        }

        return Ok(location);
    }

    [HttpPut]
    public IActionResult UpdateLocation(Location location)
    {
        if (Validation(location).Equals(200))
            LocationsRepository.UpdateLocation(location);
        return Ok(location);
    }

    private int Validation(Location location)
    {
        var allLocations = LocationsRepository.GetAllLocations();

        if (allLocations.Any(locations => locations.Name.Equals(location.Name)))
            return 400;

        if (location.Name.Equals("") || location.Name.Equals(null))
            return 418;

        if (location.Name.Length > 255)
            return 411;

        if (location.City.Equals("") || location.City.Equals(null))
            return 418;

        if (location.City.Length > 55)
            return 411;

        return 200;
    }
}