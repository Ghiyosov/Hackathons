using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class TeamController(ITeamService _service)
{
    [HttpGet("GetTeams")]
    public async Task<Response<List<TeamDTO>>> GetTeams()
        => await _service.GetTeams();
    
    [HttpPost("AddTeam")]
    public async Task<Response<string>> AddTeam(TeamDTO team)
        => await _service.AddTeam(team);
    
    [HttpPut("UpdateTeam")]
    public async Task<Response<string>> UpdateTeam(TeamDTO team)
        => await _service.UpdateTeam(team);
    
    [HttpDelete("DeleteTeam")]
    public async Task<Response<string>> DeleteTeam(int id)
        => await _service.DeleteTeam(id);

    [HttpGet("GetTeamParticipant/{id}")]
    public async Task<Response<Team>> GetTeamParticipant(int id)
        => await _service.GetHTeamParticipantById(id);
}