using Domein.DTOs;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class ParticiantController(IParticiantService _service)
{
    [HttpGet("GetParticiants")]
    public async Task<Response<List<ParticiantDTO>>> GetParticiants()
        => await _service.GetParticiants();
    
    [HttpPost("AddParticiant")]
    public async Task<Response<string>> AddParticiant(ParticiantDTO particiant)
        => await _service.AddParticiant(particiant);
    
    [HttpPost("UpdateParticiant")]
    public async Task<Response<string>> UpdateParticiant(ParticiantDTO particiant)
        => await _service.UpdateParticant(particiant);
    
    [HttpPost("DeleteParticiant")]
    public async Task<Response<string>> DeleteParticiant(int id)
        => await _service.DeleteParticiant(id);
}