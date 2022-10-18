using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    [HttpPost]
    public IActionResult AddTeam(Team team)
    {
        if (Validation(team).Equals(200))
            TeamsRepository.AddTeam(team);
        return CreatedAtAction(nameof(GetById), new {id = team.Id}, team);
    }

    [HttpDelete]
    public IActionResult DeleteTeam(Guid teamId)
    {
        TeamsRepository.DeleteTeam(teamId);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(TeamsRepository.GetAllTeams());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var location = TeamsRepository.GetTeamById(id);
        if (location is null)
        {
            return NotFound();
        }

        return Ok(location);
    }

    [HttpPut]
    public IActionResult UpdateTeam(Team team)
    {
        if (Validation(team).Equals(200))
            TeamsRepository.UpdateTeam(team);
        return Ok(team);
    }

    private int Validation(Team team)
    {
        var allTeams = TeamsRepository.GetAllTeams();

        if (allTeams.Any(teams => teams.Name.Equals(team.Name)))
            return 400;

        if (team.Name.Equals("") || team.Name.Equals(null))
            return 418;

        if (team.Name.Length > 255)
            return 411;

        if (team.CoachName.Length > 55)
            return 411;

        return 200;
    }
}