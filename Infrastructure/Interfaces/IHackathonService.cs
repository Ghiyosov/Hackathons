using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IHackathonService
{
    public Task<Response<List<HackatonDTO>>> GetHackathons();
    public Task<Response<string>> AddHackathon(HackatonDTO hackaton);
    public Task<Response<string>> UpdateHackathon(HackatonDTO hackaton);
    public Task<Response<string>> DeleteHackathon(int id);
    public Task<Response<Hackathon>> GetHackathonTeamsById(int id);
    
}