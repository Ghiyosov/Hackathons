using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface ITeamService
{
    Task<Response<List<TeamDTO>>> GetTeams();
    public Task<Response<string>> AddTeam(TeamDTO team);
    public Task<Response<string>> UpdateTeam(TeamDTO team);
    public Task<Response<string>> DeleteTeam(int id);
    public Task<Response<Team>> GetHTeamParticipantById(int id);
}