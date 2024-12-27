using System.Net;
using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(DataContext _data) : ITeamService
{
    public async Task<Response<List<TeamDTO>>> GetTeams()
    {
        var resHackatons = await _data.Teams.ToListAsync();
        var resDTO = resHackatons.Select(x => new TeamDTO()
        {
            Id = x.Id,
            Name = x.Name,
            HackathonId = x.HackathonId,
            CreatedDate = x.CreatedDate
        });
        return new Response<List<TeamDTO>>(resDTO.ToList());
    }

    public async Task<Response<string>> AddTeam(TeamDTO team)
    {
        var hac = new Team()
        {
            Name = team.Name,
            HackathonId = team.HackathonId,
            CreatedDate = team.CreatedDate,
        };
        await _data.Teams.AddAsync(hac);
        var resHackatons = await _data.SaveChangesAsync();
        return resHackatons == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Team not created")
            : new Response<string>("Team created successfully");
    }

    public async Task<Response<string>> UpdateTeam(TeamDTO team)
    {
        var resHackaton = await _data.Teams.FirstOrDefaultAsync(x=>x.Id == team.Id);
        if (resHackaton == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        }
      resHackaton.Name = team.Name;
      resHackaton.HackathonId = team.HackathonId;
      resHackaton.CreatedDate = team.CreatedDate;
        var res = await _data.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Team not updated")
            : new Response<string>("Team updated successfully");
    }
    

    public async Task<Response<string>> DeleteTeam(int id)
    {
        var resHackaton = await _data.Teams.FirstOrDefaultAsync(x=>x.Id == id);
        if (resHackaton == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        }
        _data.Teams.Remove(resHackaton);
        var res = await _data.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Team not deleted")
            : new Response<string>("Team deleted successfully");
    }

    public async Task<Response<Team>> GetHTeamParticipantById(int id)
    {
        var resHack = await _data.Teams
            .Include(x=>x.Participants)
            .FirstOrDefaultAsync(x=>x.Id == id);
        if (resHack == null)
        {
            return new Response<Team>(HttpStatusCode.NotFound,"Hackathon not found");
        }
        return new Response<Team>(resHack);
    }
}