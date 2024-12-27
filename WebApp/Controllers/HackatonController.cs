using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class HackatonController(IHackathonService _service)
{
    [HttpGet("GetHackatons")]
    public async Task<Response<List<HackatonDTO>>> GetHackatons()
        => await _service.GetHackathons();
    
    [HttpPost("AddHackaton")]
    public async Task<Response<string>> AddHackaton(HackatonDTO hackaton)
        => await _service.AddHackathon(hackaton);
    
    [HttpPut("UpdateHackaton")]
    public async Task<Response<string>> UpdateHackaton(HackatonDTO hackaton)
        => await _service.UpdateHackathon(hackaton);

    [HttpDelete("DeleteHackaton")]
    public async Task<Response<string>> DeleteHackaton(int id)
        => await _service.DeleteHackathon(id);

    [HttpGet("GetHackathonTeamById")]
    public async Task<Response<Hackathon>> GetHackathonTeamById(int id)
        => await _service.GetHackathonTeamsById(id);
}